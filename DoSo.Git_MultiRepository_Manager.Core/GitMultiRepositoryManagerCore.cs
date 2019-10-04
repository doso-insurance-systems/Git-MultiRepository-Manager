using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CliWrap;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using Newtonsoft.Json;
using static DoSo.Git_MultiRepository_Manager.Core.GitMultiRepositoryManagerConfiguration;

namespace DoSo.Git_MultiRepository_Manager.Core
{
    public static class ExtensionMethods
    {
        public static bool IsAnyOf<T>(this T item, params T[] compareWith) => compareWith.Any(i => i.Equals(item));
    }

    public class GitMultiRepositoryManagerCore
    {
        public GitMultiRepositoryManagerConfiguration Config { get; }
        readonly string _newLine = Environment.NewLine;

        string AppendSlashesToFront(string text)
        {
            var splitText = text.Split(new[] { _newLine }, StringSplitOptions.RemoveEmptyEntries);
            var appendedSlashes = splitText.Select(t => $"<!-- {t} -->");
            return string.Join(_newLine, appendedSlashes);
        }

        public GitMultiRepositoryManagerCore()
        {
            //var configSerializer = JsonConvert. YAXSerializer(typeof(GitMultiRepositoryManagerConfiguration));
            var serializedFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                nameof(GitMultiRepositoryManagerConfiguration) + ".JSON.config");

            if (File.Exists(serializedFilePath))
            {
                var configFileContent = File.ReadAllText(serializedFilePath);

                try
                {
                    Config = JsonConvert.DeserializeObject<GitMultiRepositoryManagerConfiguration>(configFileContent);

                    var _20SecondTimer = new System.Timers.Timer(36000000);
                    _20SecondTimer.Elapsed += async (s, e) => await RefreshRepoStatuses();

                    _20SecondTimer.Start();

                    _ = RefreshRepoStatuses();
                }
                catch (Exception e)
                {
                    File.WriteAllText(serializedFilePath,
                        $"{configFileContent} {_newLine}{_newLine}{AppendSlashesToFront(e.Message)}");
                    Cli.Wrap("notepad").SetArguments(serializedFilePath).Execute();
                    throw;
                }
            }
            else
            {
                File.WriteAllText(serializedFilePath, JsonConvert.SerializeObject(
                    new GitMultiRepositoryManagerConfiguration
                    (
                        "---put-root-folder-path-here---",
                        new List<RepositoryItem>
                        {
                            new RepositoryItem(
                                "doso-core-insurance",
                                "doso-core-insurance",
                                "doso-core-insurance"
                            ),
                            new RepositoryItem
                                ("doso-compiled-binaries", "doso-compiled-binaries", "doso-compiled-binaries")
                        },
                        "---put-git-username-here---",
                        "---put-git-password-here---",
                        //RepositoryFoldersList = new List<string>
                        //{
                        //    "doso-core-insurance",
                        //    "doso-compiled-binaries",
                        //},
                        "--put-git-email-here--", "--put-git-displayname-here--", "--devenv-path--"
                    ), Formatting.Indented));


                Cli.Wrap("notepad").SetArguments(serializedFilePath).Execute();
            }
        }

        public static void OpenDevenv(string devenvPath, string repositoryPath) =>
            StartProcessWithArgsAndForget(Path.Combine(devenvPath, "devenv.exe"), $" {repositoryPath}");

        public static void OpenGitExtensions(string repositoryPath) =>
            StartProcessWithArgsAndForget("GitExtensions", $"browse {repositoryPath}");

        public static void OpenVisualStudioCode(string repositoryPath) =>
            StartProcessWithArgsAndForget("Code", repositoryPath);

        public static void OpenWindowsExplorer(string repositoryPath) =>
            StartProcessWithArgsAndForget("Explorer", repositoryPath);

        //StartProcessWithArgsAndForget("/*Code*/")

        public static void StartProcessWithArgsAndForget(string process, string args)
        {
            var proc = Process.Start(new ProcessStartInfo
            { Arguments = $"/C start {process} {args}", FileName = "cmd", WindowStyle = ProcessWindowStyle.Hidden });

            //Cli.Wrap(process).SetArguments($" {args}").ExecuteAndForget();
        }

        public async void CreateOrCheckoutBranch(string branchName, bool force)
        {
            GitRepositoryStatuses.Where(r => force || r.PendingChanges > 0)
                .Select(r => (repo: r.Repository,
                    branch: r.Repository.Branches[branchName] ?? r.Repository.CreateBranch(branchName)))
                .ToList()
                .ForEach(r => Commands.Checkout(r.repo, r.branch));

            await RefreshRepoStatuses(false);
        }

        public void RemoveMergedLocalBranches()
        {
            AllRepositories
                .ForEach(r =>
                {
                    var originMaster = r.repo.Branches[OriginMaster];

                    r.repo.Branches
                        .Where(b => !b.IsRemote)
                        .ToList()
                        .ForEach(b =>
                        {
                            try
                            {
                                if (r.repo.Head.FriendlyName == b.FriendlyName) return;

                                var branchDivergence =
                                    r.repo.ObjectDatabase.CalculateHistoryDivergence(b.Tip, originMaster.Tip);

                                var branchName = b.FriendlyName;
                                var tip = r.repo.Head.FriendlyName;

                                if (branchDivergence.AheadBy == 0 && branchDivergence.BehindBy >= 0)
                                {
                                    r.repo.Branches.Remove(b);
                                    Add2CommandLog(true, r.repo, $"Removed branch: [{b.FriendlyName}]");
                                }
                            }
                            catch (Exception ex)
                            {
                                Add2CommandLog(false, r.repo,
                                    $"Couldn't remove branch: [{b.FriendlyName}] due to error - {ex.Message}");
                            }
                        });
                });


            //    using (var repository = new Repository(path))
            //{
            //    var remote = repository.Network.Remotes["origin"];
            //    var options = new PushOptions();
            //    var credentials = options.CredentialsProvider = GetUserCredentialsProvider();
            //    options.CredentialsProvider = credentials;
            //    string pushRefSpec = @"refs/heads/:{0}".FormatWith(branch);
            //    repository.Network.Push(remote, pushRefSpec);
            //    repository.Branches.Remove(repository.Branches[branch]);
            //}
        }

        public string CommandLog { get; set; } = "";
        public EventHandler<string> CommandLogChanged;

        public string GetRepoNameByRepo(Repository repo)
        {
            if (repo == null) throw new ArgumentNullException(nameof(repo));
            return repo.Info
                .WorkingDirectory.Split('\\')
                .LastOrDefault(s => !string.IsNullOrEmpty(s));
        }
        //=> Config.RepositoryItemsList
        //        .Single(r => r.RepositoryLocalPathRelativeToRoot == repo.Info.WorkingDirectory.Split('\\').LastOrDefault(s => !string.IsNullOrEmpty(s))).RepositoryItemName;

        public void Add2CommandLog(bool isSuccess, Repository repo, string message)
        {
            if (repo == null) throw new ArgumentNullException(nameof(repo));
            if (message == null) throw new ArgumentNullException(nameof(message));
            CommandLogChanged?.Invoke(this,
                $"\r\n{DateTime.Now,10:dd-MMM-yy hh:mm:ss} | {(isSuccess ? "+" : "-"),1} | {GetRepoNameByRepo(repo),-22} | {message}");
        }

        public void Add2CommandLog(bool isSuccess, string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            CommandLogChanged?.Invoke(this,
                $"\r\n{DateTime.Now,10:dd-MMM-yy hh:mm:ss} | {(isSuccess ? "+" : "-"),1} | ---- | {message}");
        }

        public void CommitAllBranches(string commitMessage, bool forceIfAheadMaster)
        {
            GitRepositoryStatuses
                .Select(r => (r, Repo: r.Repository))
                .Where(r => r.r.IsDirty || r.r.HeadAheadOriginMasterBy > 0 && forceIfAheadMaster).ToList()
                .ForEach(r =>
                {
                    //r.repoStatus.Removed.Select(mods => mods.FilePath)
                    //.ToList()
                    //.ForEach(f => r.Repo.Index.Remove(f));

                    r.r.RepoStatus.Where(rs => rs.State != FileStatus.Ignored).ToList()
                        .ForEach(rs => Commands.Stage(r.Repo, rs.FilePath));


                    //r.repoStatus.Modified.Select(mods => mods.FilePath)
                    //.ToList()
                    //.ForEach(f => r.Repo.Index.Add(f));


                    ////r.Repo.Commit

                    //var untrackedFilePaths = r.repoStatus.Untracked.Select(f => f.FilePath).ToList();
                    //untrackedFilePaths.ForEach(f => Commands.Stage(r.Repo, f));

                    ////r.Index.Add(filePaths);

                    //// Stage the file
                    ////r.Index.Add(".");
                    //r.Repo.Index.Write();

                    var author = new Signature(Config.UserDisplayName, Config.Email, DateTime.Now);
                    var committer = author;

                    // Commit to the repository
                    try
                    {
                        var modifyingExistingCommit =
                            r.r.HeadAheadOriginMasterBy > 0 && r.r.PendingChanges == 0;

                        var commit = r.Repo.Commit(commitMessage, author, committer,
                            new CommitOptions
                            {
                                AmendPreviousCommit = modifyingExistingCommit,
                                AllowEmptyCommit = modifyingExistingCommit
                            });
                        Add2CommandLog(true, r.Repo, commit.ToString());
                    }
                    catch (Exception e)
                    {
                        Add2CommandLog(false, r.Repo, e.Message);
                    }
                });
        }

        const string OriginMaster = "origin/master";
        const string Master = "master";

        public void PushLocalHeadBranchesAheadOfMaster(bool forcePush) =>
            AllRepositories.ForEach(r =>
            {
                var remote = r.repo.Network.Remotes["origin"];

                var pushOptions = new PushOptions { CredentialsProvider = Credentials, };

                var originMasterBranch = r.repo.Branches[OriginMaster];

                var headTip = r.repo.Head.Tip;
                var originMasterTipSha = originMasterBranch.Tip;

                var repoName = r.repo.Info.Path;

                var historyDivergence =
                    r.repo.ObjectDatabase.CalculateHistoryDivergence(r.repo.Head.Tip, originMasterBranch.Tip);
                var headAheadOfMasterBy = historyDivergence.AheadBy;

                if (headAheadOfMasterBy > 0)
                {
                    r.repo.Branches.Update(r.repo.Head,
                        b => b.Remote = remote.Name,
                        b => b.UpstreamBranch = r.repo.Head.CanonicalName
                    );
                    try
                    {
                        if (forcePush)
                        {
                            var pushRefSpec = string.Format("+{0}:{0}", r.repo.Head.CanonicalName);
                            r.repo.Network.Push(remote, pushRefSpec, pushOptions);

                            Add2CommandLog(true, r.repo, "FORCE Push successful");
                        }
                        else
                        {
                            r.repo.Network.Push(r.repo.Head, pushOptions);
                            Add2CommandLog(true, r.repo, "Push successful");
                        }
                    }
                    catch (Exception e)
                    {
                        Add2CommandLog(false, r.repo, e.Message);
                    }
                }
            });

        public void RebaseCurrentBranchOnOriginMaster()
        {
            AllRepositories.ForEach(r =>
            {
                var originMaster = r.repo.Branches[OriginMaster];


                var head = r.repo.Head;
                var tracked = head.TrackedBranch;

                //var sig = new Signature();

                //var result = r.Rebase.Start(head, tracked, null, new Identity(sig.Name, sig.Email), new RebaseOptions());
                try
                {
                    r.repo.Rebase.Start(r.repo.Head, originMaster, originMaster,
                        new Identity(Config.UserDisplayName, Config.Email), new RebaseOptions());
                    Add2CommandLog(true, r.repo, $"Rebased {head.FriendlyName} on origin/master successful");
                }
                catch (Exception e)
                {
                    Add2CommandLog(false, r.repo, e.Message);
                }
            });
        }

        //List<Repository> /*AllRepositories*/ => AllRepositoriesWithStatus2.Select(r => r.Repo).ToList();

        List<(Repository, RepositoryItem)> _allRepositories;

        List<(Repository repo, RepositoryItem repositoryItem)> AllRepositories //WithStatus2
            => _allRepositories ?? (_allRepositories = Config
                   .RepositoryItemsList
                   //.Select(f => )
                   .Select(f =>
                       (new Repository(Path.Combine(Config.RootFolderPath, f.RepositoryLocalPathRelativeToRoot)), f))
                   //Status: GitRepositoryStatuses?.SingleOrDefault(s =>s.RepositoryItem.RepositoryItemName == f.RepositoryItemName))
                   .ToList());


        //List<(Repository Repo, GitRepositoryStatus Status)> AllRepositoresWithStatus
        //    => AllRepositories
        //        .Select(r =>
        //            (Repo: r,
        //            Status: GitRepositoryStatuses?.SingleOrDefault(s => s.RepositoryItem.RepositoryItemName == r.)))
        //        .ToList();

        FetchOptions FetchOptions => new FetchOptions
        {
            Prune = true,
            CredentialsProvider = Credentials
        };

        CredentialsHandler Credentials => (url, usernameFromUrl, types) => new UsernamePasswordCredentials
        { Username = Config.GitUsername, Password = Config.GitPassword };

        IEnumerable<GitRepositoryStatus> GitRepositoryStatuses;
        public event EventHandler<IEnumerable<GitRepositoryStatus>> GitRepositoryStatusRefreshed;
        readonly object _locker = new object();

        public async Task RefreshRepoStatuses(bool fetchRepositories = true)
        {
            if (Monitor.TryEnter(_locker))
            {
                //GitRepositoryStatuses = Config.RepositoryItemsList.Select(r =>
                //{
                //    var repoStatus = f.Repo.RetrieveStatus(new StatusOptions());

                //    return new GitRepositoryStatus(r,);
                //})

                Add2CommandLog(true, "Started refreshing repository statuses");

                GitRepositoryStatuses = await Task.Run(() =>
                    AllRepositories
                        .Select(r =>
                        {
                            if (!fetchRepositories) return r;

                            foreach (var remote in r.repo.Network.Remotes)
                            {
                                var refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                                try
                                {
                                    Commands.Fetch(r.repo, remote.Name, refSpecs, FetchOptions, "logMessage");
                                }
                                catch (Exception e)
                                {
                                    Add2CommandLog(false, r.repo, e.Message);
                                }
                            }

                            return r;
                        })
                        .Select(f =>
                        {
                            var master = f.repo.Branches["master"];

                            var repoStatus = f.repo.RetrieveStatus(new StatusOptions());

                            var historyDivergence =
                                f.repo.ObjectDatabase.CalculateHistoryDivergence(f.repo.Head.Tip,
                                    f.repo.Branches[OriginMaster].Tip);
                            //var headAheadOfMasterBy = historyDivergence.AheadBy;

                            var repoName = GetRepoNameByRepo(f.repo);

                            return new GitRepositoryStatus(f.repo, f.repositoryItem,
                                f.repo.Head.FriendlyName,
                                string.Join(";",
                                    f.repo.Branches.Where(b => !b.IsRemote)
                                        .Select(b => b.FriendlyName)),
                                historyDivergence.BehindBy,
                                historyDivergence.AheadBy,
                                pendingChanges: repoStatus.Count(r => r.State != FileStatus.Ignored),
                                isDirty: repoStatus.IsDirty,
                                repoStatus: repoStatus
                            );
                        })
                        //.AsParallel()
                        //.Where(f => f.HeadBehindOriginMasterBy > 0 || f.PendingChanges > 0)
                        //.Select(f => CliWrap.Cli.Wrap("GitExtensions").SetArguments($"browse {f.path}").Execute() )
                        .ToList());


                Add2CommandLog(true, "Refreshed repository statuses");
                Monitor.Exit(_locker);

                OnGitRepositoryStatusRefreshed(GitRepositoryStatuses);
            }
            else
            {
                Add2CommandLog(false, null, "Already refreshing repositories!");
            }
        }

        protected virtual void OnGitRepositoryStatusRefreshed(IEnumerable<GitRepositoryStatus> e)
        {
            GitRepositoryStatusRefreshed?.Invoke(this, e);
        }
    }
}