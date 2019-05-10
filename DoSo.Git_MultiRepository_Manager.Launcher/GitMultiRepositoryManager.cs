using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DoSo.Git_MultiRepository_Manager.Core;
using GitLabApiClient;

namespace DoSo.Git_MultiRepository_Manager.Win.Launcher
{
    public partial class GitMultiRepositoryManager : Form
    {
        public GitMultiRepositoryManagerCore GitRepoManager { get; }

        public GitMultiRepositoryManager()
        {
            InitializeComponent();

            ticketSetStatusComboBox.SelectedItem = ticketSetStatusComboBox.Items[0];

            //foreach (var gridColumn in dataGridView1.Columns.OfType<DataGridViewColumn>())
            //    gridColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dataGridView1.CellContentClick += (sender, e) =>
            {
                var senderGrid = (DataGridView)sender;

                var clickedColumn = senderGrid.Columns[e.ColumnIndex];
                if (e.RowIndex < 0) return;
                if (!(clickedColumn is DataGridViewButtonColumn)) return;

                //var clickedColumnName = clickedColumn.Name;
                var repositoryForCurrentRow = senderGrid.Rows[e.RowIndex].Cells[Repository.Name].Value.ToString();

                if (clickedColumn == OpenGitExtensions)
                {
                    GitMultiRepositoryManagerCore.OpenGitExtensions(Path.Combine(GitRepoManager.Config.RootFolderPath, repositoryForCurrentRow));
                }
                else if (clickedColumn == VSCode)
                {
                    GitMultiRepositoryManagerCore.OpenVisualStudioCode(Path.Combine(GitRepoManager.Config.RootFolderPath, repositoryForCurrentRow));
                }
                else if (clickedColumn == Explorer)
                {
                    GitMultiRepositoryManagerCore.OpenWindowsExplorer(Path.Combine(GitRepoManager.Config.RootFolderPath, repositoryForCurrentRow));
                }

            };

            GitRepoManager = new GitMultiRepositoryManagerCore();

            GitRepoManager.CommandLogChanged += (sender, s) => commandLogTextBox.Invoke(new Action(() => commandLogTextBox.Text += s));

            GitRepoManager.GitRepositoryStatusRefreshed += (sender, statuses) =>
            {
                dataGridView1.Invoke(new Action(() =>
                {
                    var (rowIndex, columnIndex) = (dataGridView1.CurrentCell?.RowIndex, dataGridView1.CurrentCell?.ColumnIndex);// = dataGridView1.Rows[1].Cells[0];

                    dataGridView1.Rows.Clear();

                    statuses
                        .Select(r => dataGridView1.Rows.Add(r.RepositoryDescription, r.CurrentBranch, r.AllLocalBranches,
                                $"+{r.HeadBehindOriginMasterBy}; -{r.HeadAheadOriginMasterBy}", r.PendingChanges)).ToList();

                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex ?? 0].Cells[columnIndex ?? 0];

                    createBranchComboBox.Items.Clear();
                    createBranchComboBox
                        .Items
                        .AddRange(statuses.SelectMany(s => s.AllLocalBranches.Split(';'))
                        .Distinct().OrderBy(s => s).ToArray());
                }));
            };
        }


        void CreateBranchButton_Click(object sender, EventArgs e) => GitRepoManager.CreateOrCheckoutBranch(createBranchComboBox.Text, forceCreateCheckoutCheckBox.Checked);

        void CommitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ticketAddressTextBox.Text) || string.IsNullOrWhiteSpace(commitMessageTexBox.Text))
            {
                MessageBox.Show("Please provide a ticket URL AND a commit message!");
                return;
            }

            if (!string.IsNullOrWhiteSpace(createBranchComboBox.Text)) { GitRepoManager.CreateOrCheckoutBranch(createBranchComboBox.Text, false); }

            //var gitLabClient = new GitLabClient("https://gitlab.com", GitRepoManager.Config.GitPassword);
            //var issueWithId = gitLabClient.Projects.GetAsync(o => o.IsMemberOf = true).Result;

            GitRepoManager.CommitAllBranches($"{commitMessageTexBox.Text}\r\n\r\n{ticketSetStatusComboBox.Text} {ticketAddressTextBox.Text}");

            ticketAddressTextBox.Text = null;
            commitMessageTexBox.Text = null;
        }

        void RemotePushButton_Click(object sender, EventArgs e) => GitRepoManager.PushLocalHeadBranchesAheadOfMaster(forcePushCheckBox.Checked);

        void RebaseOriginMasterButton_Click(object sender, EventArgs e) => GitRepoManager.RebaseCurrentBranchOnOriginMaster();

        private void RemoveMergedLocalBranches_Click(object sender, EventArgs e)
        {
            GitRepoManager.RemoveMergedLocalBranches();
        }

        private void GitLabOpenComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedText = ((ComboBox)sender).SelectedItem;
            var gridSelectedRowProject = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[Repository.Name].Value.ToString();

            GitMultiRepositoryManagerCore.StartProcessWithArgsAndForget("chrome.exe", $"https://gitlab.com/doso/insurance/{gridSelectedRowProject}/{selectedText}");

        }
    }
}
