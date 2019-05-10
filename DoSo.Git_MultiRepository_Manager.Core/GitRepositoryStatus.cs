namespace DoSo.Git_MultiRepository_Manager.Core
{
    public class GitRepositoryStatus
    {
        public GitRepositoryStatus(string repositoryDescription, string currentBranch, string allLocalBranches, int? headBehindOriginMasterBy, int? headAheadOriginMasterBy, int pendingChanges )
        {
            RepositoryDescription = repositoryDescription;
            CurrentBranch = currentBranch;
            AllLocalBranches = allLocalBranches;
            HeadBehindOriginMasterBy = headBehindOriginMasterBy;
            PendingChanges = pendingChanges;
            HeadAheadOriginMasterBy = headAheadOriginMasterBy;
        }

        public string RepositoryDescription { get; }
        public string CurrentBranch { get; }
        public string AllLocalBranches { get; }
        public int? HeadBehindOriginMasterBy { get; }
        public int? HeadAheadOriginMasterBy { get; }
        public int PendingChanges { get; }
    }
}