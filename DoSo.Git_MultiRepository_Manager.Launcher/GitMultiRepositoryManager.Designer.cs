using System.Windows.Forms;

namespace DoSo.Git_MultiRepository_Manager.Win.Launcher
{
    partial class GitMultiRepositoryManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.createBranchButton = new System.Windows.Forms.Button();
            this.commitButton = new System.Windows.Forms.Button();
            this.commitMessageTexBox = new System.Windows.Forms.TextBox();
            this.remotePushButton = new System.Windows.Forms.Button();
            this.rebaseOriginMasterButton = new System.Windows.Forms.Button();
            this.commandLogTextBox = new System.Windows.Forms.TextBox();
            this.ticketAddressTextBox = new System.Windows.Forms.TextBox();
            this.ticketSetStatusComboBox = new System.Windows.Forms.ComboBox();
            this.createBranchComboBox = new System.Windows.Forms.ComboBox();
            this.forcePushCheckBox = new System.Windows.Forms.CheckBox();
            this.removeMergedLocalBranches = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fetchAndPruneButton = new System.Windows.Forms.Button();
            this.gitLabOpenComboBox = new System.Windows.Forms.ComboBox();
            this.forceCreateCheckoutCheckBox = new System.Windows.Forms.CheckBox();
            this.gitlabBranchesButton = new System.Windows.Forms.Button();
            this.Repository = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CurrentBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllBranches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MasterAheadAndBehindBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VSCode = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OpenGitExtensions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Explorer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Devenv = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Repository,
            this.CurrentBranch,
            this.AllBranches,
            this.MasterAheadAndBehindBy,
            this.PendingChanges,
            this.VSCode,
            this.OpenGitExtensions,
            this.Explorer,
            this.Devenv});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(15, 15);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 7;
            this.dataGridView1.Size = new System.Drawing.Size(1641, 759);
            this.dataGridView1.TabIndex = 0;
            // 
            // createBranchButton
            // 
            this.createBranchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createBranchButton.Location = new System.Drawing.Point(6, 135);
            this.createBranchButton.Margin = new System.Windows.Forms.Padding(6);
            this.createBranchButton.Name = "createBranchButton";
            this.createBranchButton.Size = new System.Drawing.Size(231, 68);
            this.createBranchButton.TabIndex = 1;
            this.createBranchButton.Text = "Create / Checkout Branch";
            this.createBranchButton.UseVisualStyleBackColor = true;
            this.createBranchButton.Click += new System.EventHandler(this.CreateBranchButton_Click);
            // 
            // commitButton
            // 
            this.commitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commitButton.Location = new System.Drawing.Point(1203, 55);
            this.commitButton.Margin = new System.Windows.Forms.Padding(6);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(231, 68);
            this.commitButton.TabIndex = 1;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // commitMessageTexBox
            // 
            this.commitMessageTexBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commitMessageTexBox.Location = new System.Drawing.Point(248, 55);
            this.commitMessageTexBox.Margin = new System.Windows.Forms.Padding(6);
            this.commitMessageTexBox.Multiline = true;
            this.commitMessageTexBox.Name = "commitMessageTexBox";
            this.commitMessageTexBox.Size = new System.Drawing.Size(941, 144);
            this.commitMessageTexBox.TabIndex = 2;
            // 
            // remotePushButton
            // 
            this.remotePushButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remotePushButton.Location = new System.Drawing.Point(1302, 135);
            this.remotePushButton.Margin = new System.Windows.Forms.Padding(6);
            this.remotePushButton.Name = "remotePushButton";
            this.remotePushButton.Size = new System.Drawing.Size(132, 68);
            this.remotePushButton.TabIndex = 1;
            this.remotePushButton.Text = "Push";
            this.remotePushButton.UseVisualStyleBackColor = true;
            this.remotePushButton.Click += new System.EventHandler(this.RemotePushButton_Click);
            // 
            // rebaseOriginMasterButton
            // 
            this.rebaseOriginMasterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rebaseOriginMasterButton.Location = new System.Drawing.Point(1445, 55);
            this.rebaseOriginMasterButton.Margin = new System.Windows.Forms.Padding(6);
            this.rebaseOriginMasterButton.Name = "rebaseOriginMasterButton";
            this.rebaseOriginMasterButton.Size = new System.Drawing.Size(231, 68);
            this.rebaseOriginMasterButton.TabIndex = 1;
            this.rebaseOriginMasterButton.Text = "Rebase current branch\r\non origin/master";
            this.rebaseOriginMasterButton.UseVisualStyleBackColor = true;
            this.rebaseOriginMasterButton.Click += new System.EventHandler(this.RebaseOriginMasterButton_Click);
            // 
            // commandLogTextBox
            // 
            this.commandLogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandLogTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandLogTextBox.Location = new System.Drawing.Point(1668, 15);
            this.commandLogTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.commandLogTextBox.Multiline = true;
            this.commandLogTextBox.Name = "commandLogTextBox";
            this.commandLogTextBox.Size = new System.Drawing.Size(761, 759);
            this.commandLogTextBox.TabIndex = 4;
            // 
            // ticketAddressTextBox
            // 
            this.ticketAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ticketAddressTextBox.Location = new System.Drawing.Point(6, 7);
            this.ticketAddressTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.ticketAddressTextBox.Name = "ticketAddressTextBox";
            this.ticketAddressTextBox.Size = new System.Drawing.Size(974, 29);
            this.ticketAddressTextBox.TabIndex = 2;
            // 
            // ticketSetStatusComboBox
            // 
            this.ticketSetStatusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ticketSetStatusComboBox.FormattingEnabled = true;
            this.ticketSetStatusComboBox.Items.AddRange(new object[] {
            "Fix",
            "Touch"});
            this.ticketSetStatusComboBox.Location = new System.Drawing.Point(994, 6);
            this.ticketSetStatusComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.ticketSetStatusComboBox.Name = "ticketSetStatusComboBox";
            this.ticketSetStatusComboBox.Size = new System.Drawing.Size(195, 32);
            this.ticketSetStatusComboBox.TabIndex = 5;
            // 
            // createBranchComboBox
            // 
            this.createBranchComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createBranchComboBox.FormattingEnabled = true;
            this.createBranchComboBox.Items.AddRange(new object[] {
            "Fix / Close",
            "Touch"});
            this.createBranchComboBox.Location = new System.Drawing.Point(6, 59);
            this.createBranchComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.createBranchComboBox.Name = "createBranchComboBox";
            this.createBranchComboBox.Size = new System.Drawing.Size(228, 32);
            this.createBranchComboBox.TabIndex = 6;
            // 
            // forcePushCheckBox
            // 
            this.forcePushCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.forcePushCheckBox.AutoSize = true;
            this.forcePushCheckBox.Location = new System.Drawing.Point(1203, 138);
            this.forcePushCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.forcePushCheckBox.Name = "forcePushCheckBox";
            this.forcePushCheckBox.Size = new System.Drawing.Size(88, 29);
            this.forcePushCheckBox.TabIndex = 7;
            this.forcePushCheckBox.Text = "Force";
            this.forcePushCheckBox.UseVisualStyleBackColor = true;
            // 
            // removeMergedLocalBranches
            // 
            this.removeMergedLocalBranches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeMergedLocalBranches.Location = new System.Drawing.Point(1445, 135);
            this.removeMergedLocalBranches.Margin = new System.Windows.Forms.Padding(6);
            this.removeMergedLocalBranches.Name = "removeMergedLocalBranches";
            this.removeMergedLocalBranches.Size = new System.Drawing.Size(231, 66);
            this.removeMergedLocalBranches.TabIndex = 8;
            this.removeMergedLocalBranches.Text = "Remove Merged Local Branches";
            this.removeMergedLocalBranches.UseVisualStyleBackColor = true;
            this.removeMergedLocalBranches.Click += new System.EventHandler(this.RemoveMergedLocalBranches_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.fetchAndPruneButton);
            this.panel1.Controls.Add(this.gitLabOpenComboBox);
            this.panel1.Controls.Add(this.forceCreateCheckoutCheckBox);
            this.panel1.Controls.Add(this.ticketAddressTextBox);
            this.panel1.Controls.Add(this.removeMergedLocalBranches);
            this.panel1.Controls.Add(this.createBranchButton);
            this.panel1.Controls.Add(this.forcePushCheckBox);
            this.panel1.Controls.Add(this.rebaseOriginMasterButton);
            this.panel1.Controls.Add(this.createBranchComboBox);
            this.panel1.Controls.Add(this.commitButton);
            this.panel1.Controls.Add(this.ticketSetStatusComboBox);
            this.panel1.Controls.Add(this.gitlabBranchesButton);
            this.panel1.Controls.Add(this.remotePushButton);
            this.panel1.Controls.Add(this.commitMessageTexBox);
            this.panel1.Location = new System.Drawing.Point(26, 818);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2106, 212);
            this.panel1.TabIndex = 9;
            // 
            // fetchAndPruneButton
            // 
            this.fetchAndPruneButton.Location = new System.Drawing.Point(1205, 6);
            this.fetchAndPruneButton.Margin = new System.Windows.Forms.Padding(6);
            this.fetchAndPruneButton.Name = "fetchAndPruneButton";
            this.fetchAndPruneButton.Size = new System.Drawing.Size(229, 39);
            this.fetchAndPruneButton.TabIndex = 11;
            this.fetchAndPruneButton.Text = "Manual Refresh";
            this.fetchAndPruneButton.UseVisualStyleBackColor = true;
            this.fetchAndPruneButton.Click += new System.EventHandler(this.FetchAndPruneButton_Click);
            // 
            // gitLabOpenComboBox
            // 
            this.gitLabOpenComboBox.FormattingEnabled = true;
            this.gitLabOpenComboBox.Items.AddRange(new object[] {
            "merge_requests",
            "issues",
            "branches"});
            this.gitLabOpenComboBox.Location = new System.Drawing.Point(1689, 55);
            this.gitLabOpenComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.gitLabOpenComboBox.Name = "gitLabOpenComboBox";
            this.gitLabOpenComboBox.Size = new System.Drawing.Size(228, 32);
            this.gitLabOpenComboBox.TabIndex = 10;
            this.gitLabOpenComboBox.Text = "GitLab Open:";
            this.gitLabOpenComboBox.SelectedValueChanged += new System.EventHandler(this.GitLabOpenComboBox_SelectedValueChanged);
            // 
            // forceCreateCheckoutCheckBox
            // 
            this.forceCreateCheckoutCheckBox.AutoSize = true;
            this.forceCreateCheckoutCheckBox.Location = new System.Drawing.Point(7, 103);
            this.forceCreateCheckoutCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.forceCreateCheckoutCheckBox.Name = "forceCreateCheckoutCheckBox";
            this.forceCreateCheckoutCheckBox.Size = new System.Drawing.Size(88, 29);
            this.forceCreateCheckoutCheckBox.TabIndex = 9;
            this.forceCreateCheckoutCheckBox.Text = "Force";
            this.forceCreateCheckoutCheckBox.UseVisualStyleBackColor = true;
            // 
            // gitlabBranchesButton
            // 
            this.gitlabBranchesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gitlabBranchesButton.Location = new System.Drawing.Point(1687, 159);
            this.gitlabBranchesButton.Margin = new System.Windows.Forms.Padding(6);
            this.gitlabBranchesButton.Name = "gitlabBranchesButton";
            this.gitlabBranchesButton.Size = new System.Drawing.Size(194, 42);
            this.gitlabBranchesButton.TabIndex = 1;
            this.gitlabBranchesButton.Text = "GitLab Branches";
            this.gitlabBranchesButton.UseVisualStyleBackColor = true;
            this.gitlabBranchesButton.Click += new System.EventHandler(this.GitlabBranchesButton_Click);
            // 
            // Repository
            // 
            this.Repository.Frozen = true;
            this.Repository.HeaderText = "Repository";
            this.Repository.MinimumWidth = 9;
            this.Repository.Name = "Repository";
            this.Repository.ReadOnly = true;
            this.Repository.Width = 150;
            // 
            // CurrentBranch
            // 
            this.CurrentBranch.HeaderText = "CurrentBranch";
            this.CurrentBranch.MinimumWidth = 9;
            this.CurrentBranch.Name = "CurrentBranch";
            this.CurrentBranch.ReadOnly = true;
            this.CurrentBranch.Width = 75;
            // 
            // AllBranches
            // 
            this.AllBranches.HeaderText = "AllBranches";
            this.AllBranches.MinimumWidth = 9;
            this.AllBranches.Name = "AllBranches";
            this.AllBranches.ReadOnly = true;
            this.AllBranches.Width = 175;
            // 
            // MasterAheadAndBehindBy
            // 
            this.MasterAheadAndBehindBy.HeaderText = "MasterAheadBy(+)\r\nMasterBehindBy(-)";
            this.MasterAheadAndBehindBy.MinimumWidth = 9;
            this.MasterAheadAndBehindBy.Name = "MasterAheadAndBehindBy";
            this.MasterAheadAndBehindBy.ReadOnly = true;
            this.MasterAheadAndBehindBy.Width = 75;
            // 
            // PendingChanges
            // 
            this.PendingChanges.HeaderText = "Pending\r\nChanges";
            this.PendingChanges.MinimumWidth = 9;
            this.PendingChanges.Name = "PendingChanges";
            this.PendingChanges.ReadOnly = true;
            this.PendingChanges.Width = 55;
            // 
            // VSCode
            // 
            this.VSCode.HeaderText = "VSCode";
            this.VSCode.MinimumWidth = 9;
            this.VSCode.Name = "VSCode";
            this.VSCode.ReadOnly = true;
            this.VSCode.Width = 30;
            // 
            // OpenGitExtensions
            // 
            this.OpenGitExtensions.HeaderText = "GitExt";
            this.OpenGitExtensions.MinimumWidth = 9;
            this.OpenGitExtensions.Name = "OpenGitExtensions";
            this.OpenGitExtensions.ReadOnly = true;
            this.OpenGitExtensions.Width = 30;
            // 
            // Explorer
            // 
            this.Explorer.HeaderText = "Explorer";
            this.Explorer.MinimumWidth = 9;
            this.Explorer.Name = "Explorer";
            this.Explorer.ReadOnly = true;
            this.Explorer.Width = 30;
            // 
            // Devenv
            // 
            this.Devenv.HeaderText = "Devenv";
            this.Devenv.MinimumWidth = 9;
            this.Devenv.Name = "Devenv";
            this.Devenv.ReadOnly = true;
            this.Devenv.Width = 30;
            // 
            // GitMultiRepositoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2444, 1177);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.commandLogTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "GitMultiRepositoryManager";
            this.Text = "Git MultiRepository Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Button createBranchButton;
        private Button commitButton;
        private TextBox commitMessageTexBox;
        private Button remotePushButton;
        private Button rebaseOriginMasterButton;
        private TextBox commandLogTextBox;
        private TextBox ticketAddressTextBox;
        private ComboBox ticketSetStatusComboBox;
        private ComboBox createBranchComboBox;
        private CheckBox forcePushCheckBox;
        private Button removeMergedLocalBranches;
        private Panel panel1;
        private CheckBox forceCreateCheckoutCheckBox;
        private ComboBox gitLabOpenComboBox;
        private Button gitlabBranchesButton;
        private Button fetchAndPruneButton;
        private DataGridViewLinkColumn Repository;
        private DataGridViewTextBoxColumn CurrentBranch;
        private DataGridViewTextBoxColumn AllBranches;
        private DataGridViewTextBoxColumn MasterAheadAndBehindBy;
        private DataGridViewTextBoxColumn PendingChanges;
        private DataGridViewButtonColumn VSCode;
        private DataGridViewButtonColumn OpenGitExtensions;
        private DataGridViewButtonColumn Explorer;
        private DataGridViewButtonColumn Devenv;
    }
}

