using System;
using System.CodeDom;
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
        GitMultiRepositoryManagerConfiguration Config { get; }
        string NewLine = Environment.NewLine;

        string appendSlashesToFront(string text)
        {
            var splitText = text.Split(new[] { NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var appendedSlashes = splitText.Select(t => $"<!-- {t} -->");
            return string.Join(NewLine, appendedSlashes);
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
                    _20SecondTimer.Elapsed += (s, e) => _20SecondTimer_Elapsed();

                    _20SecondTimer.Start();

                    _20SecondTimer_Elapsed();
                }
                catch (Exception e)
                {
                    File.WriteAllText(serializedFilePath, $"{configFileContent} {NewLine}{NewLine}{appendSlashesToFront(e.Message)}");
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
                        "solution-files",
                        "doso-core-insurance",
                        "general-modules",
                        "doso-compiled-binaries",
                        "tbcinsurance",
                        "primeinsurance"
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
        }

        public string CommandLog { get; set; } = "";
        public EventHandler<string> CommandLogChanged;

        public string GetRepoNameByRepo(Repository repo) 
            => repo.Info.WorkingDirectory.Split('\\')
                    .LastOrDefault(s => !string.IsNullOrEmpty(s));

        public void Add2CommandLog(bool isSuccess, Repository repo, string message)
        {
            //CommandLog += $"|{isSuccess,}|{repo.Info.Path,-30} | {message,70}|";
            CommandLog += $"\r\n{DateTime.Now,10:dd-MMM-yy hh:mm:ss} | {(isSuccess ? "+" : "-"),1} | {GetRepoNameByRepo(repo),-22} | {message}";
            CommandLogChanged?.Invoke(this, CommandLog);
        }

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

        PushOptions PushOptions => new PushOptions { CredentialsProvider = Credentials,  };

        public void PushAllLocalBranches() => AllRepositories.ForEach(r =>
        {
            var remote = r.Network.Remotes["origin"];

            // The local branch "buggy-3" will track a branch also named "buggy-3"
            // in the repository pointed at by "origin"

            r.Branches.Update(r.Head,
                b => b.Remote = remote.Name,
                b => b.UpstreamBranch = r.Head.CanonicalName);
            r.Network.Push(r.Head, PushOptions);
        });

        List<Repository> AllRepositories
            => Config
                .RepositoryFoldersList
                .Select(f => Path.Combine(Config.RootFolderPath, f))
                .Select(f => new Repository(f))
                .ToList();


        List<(Repository Repo, GitRepositoryStatus Status)> AllRepositoresWithStatus
            => AllRepositories
                .Select(r => 
                    (Repo : r,
                    Status : GitRepositoryStatuses?.SingleOrDefault(s => s.RepositoryDescription == GetRepoNameByRepo(r))))
                .ToList();

        FetchOptions FetchOptions => new FetchOptions
        {
            Prune = true,
            CredentialsProvider = Credentials
        };

        CredentialsHandler Credentials => (url, usernameFromUrl, types) => new UsernamePasswordCredentials { Username = Config.GitUsername, Password = Config.GitPassword };

        IEnumerable<GitRepositoryStatus> GitRepositoryStatuses;
        public event EventHandler<IEnumerable<GitRepositoryStatus>> GitRepositoryStatusRefreshed;
        async void _20SecondTimer_Elapsed()
        {
            var repoFoldersAbsolute = await Task.Run(() =>
                AllRepositories
                    .Select(r =>
                    {
                        foreach (var remote in r.Network.Remotes)
                        {
                            var refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                            Commands.Fetch(r, remote.Name, refSpecs, FetchOptions, "logMessage");
                        }
                        return r;
                    })
                    .Select(f =>
                    {
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