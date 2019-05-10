using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CliWrap;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using YAXLib;

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

        string appendSlashesToFront(string text)
        {
            var splitText = text.Split(new[] { _newLine }, StringSplitOptions.RemoveEmptyEntries);
            var appendedSlashes = splitText.Select(t => $"<!-- {t} -->");
            return string.Join(_newLine, appendedSlashes);
        }

        public GitMultiRepositoryManagerCore()
        {
            var configSerializer = new YAXSerializer(typeof(GitMultiRepositoryManagerConfiguration));
            var serializedFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), nameof(GitMultiRepositoryManagerConfiguration) + ".config");

            if (File.Exists(serializedFilePath))
            {
                var configFileContent = File.ReadAllText(serializedFilePath);

                try
                {
                    Config =
                        (GitMultiRepositoryManagerConfiguration)configSerializer.Deserialize(configFileContent);

                    var _20SecondTimer = new System.Timers.Timer(10000);
                    _20SecondTimer.Elapsed += (s, e) => timerElapsed();

                    _20SecondTimer.Start();

                    timerElapsed();
                }
                catch (Exception e)
                {
                    File.WriteAllText(serializedFilePath, $"{configFileContent} {_newLine}{_newLine}{appendSlashesToFront(e.Message)}");
                    Cli.Wrap("notepad").SetArguments(serializedFilePath).Execute();
                    throw;
                }
            }
            else
            {
                File.WriteAllText(serializedFilePath, configSerializer.Serialize(new GitMultiRepositoryManagerConfiguration
                {
                    RepositoryFoldersList = new List<string>
                    {
                        "doso-core-insurance",
                        "doso-compiled-binaries",
                    },
                    RootFolderPath = "---put-root-folder-path-here---",
                    GitUsername = "---put-git-username-here---",
                    GitPassword = "---put-git-password-here---"
                }));

                Cli.Wrap("notepad").SetArguments(serializedFilePath).Execute();
            }
        }
        public static void OpenGitExtensions(string repositoryPath) => StartProcessWithArgsAndForget("GitExtensions", $"browse {repositoryPath}");

        public static void OpenVisualStudioCode(string repositoryPath) => StartProcessWithArgsAndForget("Code", repositoryPath);
        public static void OpenWindowsExplorer(string repositoryPath) => StartProcessWithArgsAndForget("Explorer", repositoryPath);

        //StartProcessWithArgsAndForget("/*Code*/")

        public static void StartProcessWithArgsAndForget(string process, string args)
        {
            var proc = Process.Start(new ProcessStartInfo { Arguments = $"/C {process} {args}", FileName = "cmd", WindowStyle = ProcessWindowStyle.Hidden });

            //Cli.Wrap("explorer").SetArguments($"{repositoryPath}").Execute();
        }

        public void CreateOrCheckoutBranch(string branchName, bool force)
        {
            AllRepositoresWithStatus.Where(r => force || r.Status.PendingChanges > 0)
                .Select(r => (repo: r.Repo, branch: r.Repo.Branches[branchName] ?? r.Repo.CreateBranch(branchName)))
                .Select(r => Commands.Checkout(r.repo, r.branch))
                .ToList();

            timerElapsed(false);
        }

        public void RemoveMergedLocalBranches()
        {
            AllRepositories
                .ForEach(r =>
                        {
                            var originMaster = r.Branches[OriginMaster];

                            r.Branches
                              .Where(b => !b.IsRemote)
                              .ToList()
                              .ForEach(b =>
                              {
                                  try
                                  {
                                      if (r.Head.FriendlyName == b.FriendlyName) return;

                                      var branchDivergence = r.ObjectDatabase.CalculateHistoryDivergence(b.Tip, originMaster.Tip);

                                      var branchName = b.FriendlyName;
                                      var tip = r.Head.FriendlyName;

                                      if (branchDivergence.AheadBy == 0 && branchDivergence.BehindBy >= 0)
                                      {
                                          r.Branches.Remove(b);
                                          Add2CommandLog(true, r, $"Removed branch: [{b.FriendlyName}]");
                                      }
                                  }
                                  catch (Exception ex) { Add2CommandLog(false, r, $"Couldn't remove branch: [{b.FriendlyName}] due to error - {ex.Message}"); }
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
            => repo.Info.WorkingDirectory.Split('\\')
                    .LastOrDefault(s => !string.IsNullOrEmpty(s));

        public void Add2CommandLog(bool isSuccess, Repository repo, string message)
            => CommandLogChanged?.Invoke(this, $"\r\n{DateTime.Now,10:dd-MMM-yy hh:mm:ss} | {(isSuccess ? "+" : "-"),1} | {GetRepoNameByRepo(repo),-22} | {message}");

        public void CommitAllBranches(string commitMessage)
        {
            AllRepositoresWithStatus
                .Where(r => r.Status?.PendingChanges > 0).ToList()
                .ForEach(r =>
                {
                    var status = r.Repo.RetrieveStatus();
                    var modifiedFilePaths = status.Modified.Select(mods => mods.FilePath).ToList();
                    modifiedFilePaths.ForEach(f =>
                    {
                        r.Repo.Index.Add(f);
                    }
                    );

                    var untrackedFilePaths = status.Untracked.Select(f => f.FilePath).ToList();
                    untrackedFilePaths.ForEach(f => Commands.Stage(r.Repo, f));

                    //r.Index.Add(filePaths);

                    // Stage the file
                    //r.Index.Add(".");
                    r.Repo.Index.Write();

                    var author = new Signature(Config.UserDisplayName, Config.Email, DateTime.Now);
                    var committer = author;

                    // Commit to the repository
                    try
                    {
                        var commit = r.Repo.Commit(commitMessage, author, committer);
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
                var remote = r.Network.Remotes["origin"];

                var pushOptions = new PushOptions { CredentialsProvider = Credentials, };

                var originMasterBranch = r.Branches[OriginMaster];

                var headTip = r.Head.Tip;
                var originMasterTipSha = originMasterBranch.Tip;

                var repoName = r.Info.Path;

                var historyDivergence = r.ObjectDatabase.CalculateHistoryDivergence(r.Head.Tip, originMasterBranch.Tip);
                var headAheadOfMasterBy = historyDivergence.AheadBy;

                if (headAheadOfMasterBy > 0)
                {
                    r.Branches.Update(r.Head,
                        b => b.Remote = remote.Name,
                        b => b.UpstreamBranch = r.Head.CanonicalName
                    );
                    try
                    {
                        if (forcePush)
                        {
                            var pushRefSpec = string.Format("+{0}:{0}", r.Head.CanonicalName);
                            r.Network.Push(remote, pushRefSpec, pushOptions);

                            Add2CommandLog(true, r, "FORCE Push successful");
                        }
                        else
                        {
                            r.Network.Push(r.Head, pushOptions);
                            Add2CommandLog(true, r, "Push successful");
                        }

                    }
                    catch (Exception e) { Add2CommandLog(false, r, e.Message); }

                }
                else
                {

                }
            });

        public void RebaseCurrentBranchOnOriginMaster()
        {
            AllRepositories.ForEach(r =>
            {


                var originMaster = r.Branches[OriginMaster];


                var head = r.Head;
                var tracked = head.TrackedBranch;

                //var sig = new Signature();

                //var result = r.Rebase.Start(head, tracked, null, new Identity(sig.Name, sig.Email), new RebaseOptions());
                try
                {
                    r.Rebase.Start(r.Head, originMaster, originMaster, new Identity(Config.UserDisplayName, Config.Email), new RebaseOptions());
                    Add2CommandLog(true, r, $"Rebased {head.FriendlyName} on origin/master successful");
                }
                catch (Exception e) { Add2CommandLog(false, r, e.Message); }
            });
        }

        List<Repository> AllRepositories
            => Config
                .RepositoryFoldersList
                .Select(f => Path.Combine(Config.RootFolderPath, f))
                .Select(f => new Repository(f))
                .ToList();


        List<(Repository Repo, GitRepositoryStatus Status)> AllRepositoresWithStatus
            => AllRepositories
                .Select(r =>
                    (Repo: r,
                    Status: GitRepositoryStatuses?.SingleOrDefault(s => s.RepositoryDescription == GetRepoNameByRepo(r))))
                .ToList();

        FetchOptions FetchOptions => new FetchOptions
        {
            Prune = true,
            CredentialsProvider = Credentials
        };

        CredentialsHandler Credentials => (url, usernameFromUrl, types) => new UsernamePasswordCredentials { Username = Config.GitUsername, Password = Config.GitPassword };

        IEnumerable<GitRepositoryStatus> GitRepositoryStatuses;
        public event EventHandler<IEnumerable<GitRepositoryStatus>> GitRepositoryStatusRefreshed;
        async void timerElapsed(bool fetchRepositories = true)
        {
            var repoFoldersAbsolute = await Task.Run(() =>
                AllRepositories
                    .Select(r =>
                    {
                        if (!fetchRepositories) return r;

                        foreach (var remote in r.Network.Remotes)
                        {
                            var refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                            try { Commands.Fetch(r, remote.Name, refSpecs, FetchOptions, "logMessage"); }
                            catch (Exception e) { Add2CommandLog(false, r, e.Message); }
                        }
                        return r;
                    })
                    .Select(f =>
                    {
                        var master = f.Branches["master"];

                        var repoStatus = f.RetrieveStatus(new StatusOptions());

                        var historyDivergence = f.ObjectDatabase.CalculateHistoryDivergence(f.Head.Tip, f.Branches[OriginMaster].Tip);
                        //var headAheadOfMasterBy = historyDivergence.AheadBy;

                        return new GitRepositoryStatus(
                            GetRepoNameByRepo(f),
                            f.Head.FriendlyName,
                            string.Join(";", f.Branches.OfType<Branch>().Where(b => !b.IsRemote).Select(b => b.FriendlyName)),
                            historyDivergence.BehindBy, historyDivergence.AheadBy, repoStatus.Staged.Count() + repoStatus.Added.Count() + repoStatus.Modified.Count() + repoStatus.Removed.Count() + repoStatus.Untracked.Count());
                    })
                    //.AsParallel()
                    //.Where(f => f.HeadBehindOriginMasterBy > 0 || f.PendingChanges > 0)
                    //.Select(f => CliWrap.Cli.Wrap("GitExtensions").SetArguments($"browse {f.path}").Execute() )
                    .ToList());

            GitRepositoryStatusRefreshed?.Invoke(this, GitRepositoryStatuses = repoFoldersAbsolute);
        }
    }
}