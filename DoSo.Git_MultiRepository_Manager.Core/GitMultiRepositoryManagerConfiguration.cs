using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CliWrap;
using CSharpFunctionalExtensions;
using LibGit2Sharp;
using YAXLib;

namespace DoSo.Git_MultiRepository_Manager.Core
{
    public class GitMultiRepositoryManagerConfiguration
    {
        public string RootFolderPath { get; set; }
        public List<string> RepositoryFoldersList { get; set; }
        public string GitUsername { get; set; }
        public string GitPassword { get; set; }
        public string GitEmail { get; set; }
    }

    public class GitRepositoryStatus
    {
        public GitRepositoryStatus(string repositoryDescription, string currentBranch, string allLocalBranches, int? masterBehindOriginBy, int pendingChanges)
        {
            RepositoryDescription = repositoryDescription;
            CurrentBranch = currentBranch;
            AllLocalBranches = allLocalBranches;
            MasterBehindOriginBy = masterBehindOriginBy;
            PendingChanges = pendingChanges;
        }

        public string RepositoryDescription { get; }
        public string CurrentBranch { get; }
        public string AllLocalBranches { get; }
        public int? MasterBehindOriginBy { get; }
        public int PendingChanges { get; }
    }

    public class GitMultiRepositoryManagerCore
    {
        public static void OpenGitExtensions(string repositoryPath) => Cli.Wrap("GitExtensions").SetArguments($"browse {repositoryPath}").Execute();

        public void CreateBranch(string branchName)
        {
            AllRepositories
                .Select(r => (repo: r, branch: r.CreateBranch(branchName)))
                .Select(r => Commands.Checkout(r.repo, r.branch))
                .ToList();
        }

        public void CommitAllBranches(string commitMessage)
        {
            //AllRepositories.Select(r => r.Commit(commitMessage, r.Config.new Signature(),  ).CreateBranch(branchName));
        }

        public GitMultiRepositoryManagerCore()
        {
            var configSerializer = new YAXSerializer(typeof(GitMultiRepositoryManagerConfiguration));
            var serializedFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), nameof(GitMultiRepositoryManagerConfiguration) + ".config");

            if (File.Exists(serializedFile))
            {
                var configFile = File.ReadAllText(serializedFile);

                try
                {
                    GitMultiRepositoryManagerConfiguration = (GitMultiRepositoryManagerConfiguration)configSerializer.Deserialize(configFile);

                    var _20SecondTimer = new System.Timers.Timer(10000);
                    _20SecondTimer.Elapsed += (s, e) => _20SecondTimer_Elapsed();

                    _20SecondTimer.Start();

                    _20SecondTimer_Elapsed();
                }
                catch (Exception e)
                { Cli.Wrap("notepad").SetArguments(serializedFile).ExecuteAndForget(); }
            }
            else
            {
                File.WriteAllText(serializedFile, configSerializer.Serialize(new GitMultiRepositoryManagerConfiguration
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

                Cli.Wrap("notepad").SetArguments(serializedFile).Execute();
            }
        }

        GitMultiRepositoryManagerConfiguration GitMultiRepositoryManagerConfiguration { get; }

        List<Repository> AllRepositories => GitMultiRepositoryManagerConfiguration.RepositoryFoldersList
            .Select(f => Path.Combine(GitMultiRepositoryManagerConfiguration.RootFolderPath, f))
            .Select(f => new Repository(f))
            .ToList();

        FetchOptions FetchOptions => new FetchOptions
        {
            CredentialsProvider = (url, usernameFromUrl, types) =>
                new UsernamePasswordCredentials { Username = GitMultiRepositoryManagerConfiguration.GitUsername, Password = GitMultiRepositoryManagerConfiguration.GitPassword }
        };

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
                                  f.Info.WorkingDirectory,
                                  f.Head.FriendlyName,
                                  string.Join(";", f.Branches.OfType<Branch>().Where(b => !b.IsRemote).Select(b => b.FriendlyName)),
                                  master.TrackingDetails.BehindBy, repoStatus.Staged.Count() + repoStatus.Added.Count() + repoStatus.Modified.Count() + repoStatus.Removed.Count() + repoStatus.Untracked.Count());
                          })
                          //.AsParallel()
                          .Where(f => f.MasterBehindOriginBy > 0 || f.PendingChanges > 0)
                          //.Select(f => CliWrap.Cli.Wrap("GitExtensions").SetArguments($"browse {f.path}").Execute() )
                          .ToList());

            GitRepositoryStatusRefreshed?.Invoke(null, repoFoldersAbsolute);
        }
    }
}
