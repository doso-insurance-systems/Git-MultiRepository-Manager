using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace DoSo.Git_MultiRepository_Manager.Core
{
    public class GitMultiRepositoryManagerConfiguration
    {
        public string RootFolderPath { get; set; }
        public List<string> RepositoryFoldersList { get; set; }
        public string GitUsername { get; set; }
        public string GitPassword { get; set; }
        public string Email { get; set; }
        public string UserDisplayName { get; set; }
    }
}
