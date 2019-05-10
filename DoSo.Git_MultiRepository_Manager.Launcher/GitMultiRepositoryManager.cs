﻿using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DoSo.Git_MultiRepository_Manager.Core;

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

                if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

                var repositoryForCurrentRow = senderGrid.Rows[e.RowIndex].Cells[Repository.Name].Value.ToString();
                GitMultiRepositoryManagerCore.OpenGitExtensions(Path.Combine(GitRepoManager.Config.RootFolderPath, repositoryForCurrentRow));
            };

            GitRepoManager = new GitMultiRepositoryManagerCore();

            GitRepoManager.CommandLogChanged += (sender, s) => { commandLogTextBox.Text += s; };

            GitRepoManager.GitRepositoryStatusRefreshed += (sender, statuses) =>
            {
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.Rows.Clear();

                    statuses
                        .Select(r => dataGridView1.Rows.Add(r.RepositoryDescription, r.CurrentBranch, r.AllLocalBranches, 
                                $"+{r.HeadBehindOriginMasterBy}; -{r.HeadAheadOriginMasterBy}", r.PendingChanges)).ToList();

                    createBranchComboBox.Items.Clear();
                    createBranchComboBox
                        .Items
                        .AddRange(statuses.SelectMany(s => s.AllLocalBranches.Split(';'))
                        .Distinct().OrderBy(s => s).ToArray());
                }));
            };
        }


        void CreateBranchButton_Click(object sender, EventArgs e) => GitRepoManager.CreateBranch(createBranchComboBox.Text);

        void CommitButton_Click(object sender, EventArgs e) => GitRepoManager.CommitAllBranches(commitMessageTexBox.Text);

        void RemotePushButton_Click(object sender, EventArgs e) => GitRepoManager.PushLocalHeadBranchesAheadOfMaster(forcePushCheckBox.Checked);

        void RebaseOriginMasterButton_Click(object sender, EventArgs e) => GitRepoManager.RebaseCurrentBranchOnOriginMaster();

        private void RemoveMergedLocalBranches_Click(object sender, EventArgs e)
        {
            GitRepoManager.RemoveMergedLocalBranches();
        }
    }
}
