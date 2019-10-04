using System;
using LibGit2Sharp;
using static DoSo.Git_MultiRepository_Manager.Core.GitMultiRepositoryManagerConfiguration;

namespace DoSo.Git_MultiRepository_Manager.Core
{
    public class GitRepositoryStatus
    {
        public GitRepositoryStatus(Repository repository, RepositoryItem repositoryItem, string currentBranch,
            string allLocalBranches,
            int? headBehindOriginMasterBy, int? headAheadOriginMasterBy, int pendingChanges, bool isDirty,
            RepositoryStatus repoStatus)
        {
            Repository = repository;
            RepositoryItem = repositoryItem ?? throw new ArgumentNullException(nameof(repositoryItem));
            //RepositoryDescription = repositoryDescription;
            //RepositoryPath = repositoryPath;
            //RepositoryRemoteAddress = repositoryRemoteAddress;
            CurrentBranch = currentBranch ?? throw new ArgumentNullException(nameof(currentBranch));
            AllLocalBranches = allLocalBranches ?? throw new ArgumentNullException(nameof(allLocalBranches));
            HeadBehindOriginMasterBy = headBehindOriginMasterBy;
            PendingChanges = pendingChanges;
            IsDirty = isDirty;
            RepoStatus = repoStatus;
            HeadAheadOriginMasterBy = headAheadOriginMasterBy;
        }

        public Repository Repository { get; }

        public RepositoryItem RepositoryItem { get; }

        //public string RepositoryDescription { get; }
        //public string RepositoryPath { get; }
        //public string RepositoryRemoteAddress { get; }
        public string CurrentBranch { get; }
        public string AllLocalBranches { get; }
        public int? HeadBehindOriginMasterBy { get; }
        public int? HeadAheadOriginMasterBy { get; }
        public int PendingChanges { get; }
        public bool IsDirty { get; }
        public RepositoryStatus RepoStatus { get; }
    }
}