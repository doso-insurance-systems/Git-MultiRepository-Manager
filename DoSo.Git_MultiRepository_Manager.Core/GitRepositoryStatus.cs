namespace DoSo.Git_MultiRepository_Manager.Core
{
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
}