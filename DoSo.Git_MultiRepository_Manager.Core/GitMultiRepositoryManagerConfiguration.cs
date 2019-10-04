using System;
using System.Collections.Generic;

namespace DoSo.Git_MultiRepository_Manager.Core
{
    public class GitMultiRepositoryManagerConfiguration
    {
        public GitMultiRepositoryManagerConfiguration(string rootFolderPath, List<RepositoryItem> repositoryItemsList,
            string gitUsername, string gitPassword, string email, string userDisplayName, string devenvPath)
        {
            RootFolderPath = rootFolderPath ?? throw new ArgumentNullException(nameof(rootFolderPath));
            RepositoryItemsList = repositoryItemsList ?? throw new ArgumentNullException(nameof(repositoryItemsList));
            GitUsername = gitUsername ?? throw new ArgumentNullException(nameof(gitUsername));
            GitPassword = gitPassword ?? throw new ArgumentNullException(nameof(gitPassword));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            UserDisplayName = userDisplayName ?? throw new ArgumentNullException(nameof(userDisplayName));
            DevenvPath = devenvPath ?? throw new ArgumentNullException(nameof(devenvPath));
        }

        public class RepositoryItem
        {
            public RepositoryItem(string repositoryItemName, string repositoryLocalPathRelativeToRoot,
                string repositoryItemRemoteAddressRelative)
            {
                RepositoryItemName = repositoryItemName;
                RepositoryLocalPathRelativeToRoot = repositoryLocalPathRelativeToRoot;
                RepositoryItemRemoteAddressRelative = repositoryItemRemoteAddressRelative;
            }

            public string RepositoryItemName { get; }
            public string RepositoryLocalPathRelativeToRoot { get; }
            public string RepositoryItemRemoteAddressRelative { get; }
        }

        public string RootFolderPath { get; }

        //public List<string> RepositoryFoldersList { get;  }
        public List<RepositoryItem> RepositoryItemsList { get; }

        public string GitUsername { get; }
        public string GitPassword { get; }
        public string Email { get; }
        public string UserDisplayName { get; }
        public string DevenvPath { get; }
    }
}