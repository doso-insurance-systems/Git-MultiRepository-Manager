using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CliWrap;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using YAXLib;

namespace DoSo.Git_MultiRepository_Manager.Core
{
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
        public static void OpenGitExtensions(string repositoryPath) => Cli.Wrap("GitExtensions").SetArguments($"browse {repositoryPath}").Execute();

        public void CreateBranch(string branchName)
        {
            AllRepositories
                .Select(r => (repo: r, branch: r.Branches[branchName] ?? r.CreateBranch(branchName)))
                .Select(r => Commands.Checkout(r.repo, r.branch))
                .ToList();

            timerElapsed(false);
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
                .Where(r => r.Status != null).ToList()
                .ForEach(r =>
                {
                    var status = r.Repo.RetrieveStatus();
                    var filePaths = status.Modified.Select(mods => mods.FilePath).ToList();
                    filePaths.ForEach(f => r.Repo.Index.Add(f));

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

        PushOptions PushOptions => new PushOptions { CredentialsProvider = Credentials, };

        public void PushAllLocalBranches() => AllRepositories.ForEach(r =>
        {
            var remote = r.Network.Remotes["origin"];

            // The local branch "buggy-3" will track a branch also named "buggy-3"
            // in the repository pointed at by "origin"

            

            r.Branches.Update(r.Head,
                b => b.Remote = remote.Name,
                b => b.UpstreamBranch = r.Head.CanonicalName);
            r.Network.Push(r.Head, PushOptions);
            Add2CommandLog(true, r, "Push successful");
        });

        public void RebaseCurrentBranchOnOriginMaster()
        {
            AllRepositories.ForEach(r =>
            {


                var originMaster = r.Branches["origin/master"];


                var head = r.Head;
                var tracked = head.TrackedBranch;

                //var sig = new Signature();

                //var result = r.Rebase.Start(head, tracked, null, new Identity(sig.Name, sig.Email), new RebaseOptions());
                try
                {
                    r.Rebase.Start(r.Head, originMaster, originMaster, new Identity(Config.UserDisplayName, Config.Email), new RebaseOptions());
                    Add2CommandLog(true, r, $"Rebased {head.FriendlyName} on origin/master successful");
                }
                catch (Exception e){Add2CommandLog(false, r, e.Message);}
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
                            Commands.Fetch(r, remote.Name, refSpecs, FetchOptions, "logMessage");
                        }
                        return r;
                    })
                    .Select(f =>
                    {

                        //var head = f.Head; // this is vNext
                        ////Console.WriteLine("Head branch: {0}, {1}", head.Name, head.Tip.Sha.Substring(0, 7));

                        //foreach (var branch in f.Branches.OrderByDescending(s => s.Tip.Author.When))
                        //{
                        //    if (head == branch)
                        //        continue;

                        //    var commitLog = f.Commits;
                        //    var commonAncestor = commitLog.FindCommonAncestor(head.Tip, branch.Tip);
                        //    var ahead = commitLog.QueryBy(new CommitFilter { Since = branch.Tip, Until = commonAncestor });
                        //    var behind = commitLog.QueryBy(new CommitFilter { Since = head.Tip, Until = commonAncestor });

                        //    var Ahead = ahead.Count();
                        //    var Behind = behind.Count();

                        //    //Console.WriteLine("Branch: {0,30} {1}, Ahead: {2,2}, Behind: {3,3}", branch.Name, branch.Tip.Sha.Substring(0, 7), Ahead, Behind);
                        //}



                        var master = f.Branches["master"];

                        var repoStatus = f.RetrieveStatus(new StatusOptions());

                        return new GitRepositoryStatus(
                            GetRepoNameByRepo(f),
                            f.Head.FriendlyName,
                            string.Join(";", f.Branches.OfType<Branch>().Where(b => !b.IsRemote).Select(b => b.FriendlyName)),
                            master.TrackingDetails.BehindBy, repoStatus.Staged.Count() + repoStatus.Added.Count() + repoStatus.Modified.Count() + repoStatus.Removed.Count() + repoStatus.Untracked.Count());
                    })
                    //.AsParallel()
                    .Where(f => f.MasterBehindOriginBy > 0 || f.PendingChanges > 0)
                    //.Select(f => CliWrap.Cli.Wrap("GitExtensions").SetArguments($"browse {f.path}").Execute() )
                    .ToList());

            GitRepositoryStatusRefreshed?.Invoke(this, GitRepositoryStatuses = repoFoldersAbsolute);
        }
    }
}