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
            this.gitLabOpenComboBox = new System.Windows.Forms.ComboBox();
            this.forceCreateCheckoutCheckBox = new System.Windows.Forms.CheckBox();
            this.Repository = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CurrentBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllBranches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MasterAheadAndBehindBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VSCode = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OpenGitExtensions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Explorer = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Repository,
            this.CurrentBranch,
            this.AllBranches,
            this.MasterAheadAndBehindBy,
            this.PendingChanges,
            this.VSCode,
            this.OpenGitExtensions,
            this.Explorer});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(647, 479);
            this.dataGridView1.TabIndex = 0;
            // 
            // createBranchButton
            // 
            this.createBranchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createBranchButton.Location = new System.Drawing.Point(3, 73);
            this.createBranchButton.Name = "createBranchButton";
            this.createBranchButton.Size = new System.Drawing.Size(126, 37);
            this.createBranchButton.TabIndex = 1;
            this.createBranchButton.Text = "Create / Checkout Branch";
            this.createBranchButton.UseVisualStyleBackColor = true;
            this.createBranchButton.Click += new System.EventHandler(this.CreateBranchButton_Click);
            // 
            // commitButton
            // 
            this.commitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commitButton.Location = new System.Drawing.Point(656, 30);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(126, 37);
            this.commitButton.TabIndex = 1;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // commitMessageTexBox
            // 
            this.commitMessageTexBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commitMessageTexBox.Location = new System.Drawing.Point(135, 30);
            this.commitMessageTexBox.Multiline = true;
            this.commitMessageTexBox.Name = "commitMessageTexBox";
            this.commitMessageTexBox.Size = new System.Drawing.Size(515, 80);
            this.commitMessageTexBox.TabIndex = 2;
            // 
            // remotePushButton
            // 
            this.remotePushButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remotePushButton.Location = new System.Drawing.Point(710, 73);
            this.remotePushButton.Name = "remotePushButton";
            this.remotePushButton.Size = new System.Drawing.Size(72, 37);
            this.remotePushButton.TabIndex = 1;
            this.remotePushButton.Text = "Push";
            this.remotePushButton.UseVisualStyleBackColor = true;
            this.remotePushButton.Click += new System.EventHandler(this.RemotePushButton_Click);
            // 
            // rebaseOriginMasterButton
            // 
            this.rebaseOriginMasterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rebaseOriginMasterButton.Location = new System.Drawing.Point(788, 30);
            this.rebaseOriginMasterButton.Name = "rebaseOriginMasterButton";
            this.rebaseOriginMasterButton.Size = new System.Drawing.Size(126, 37);
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
            this.commandLogTextBox.Location = new System.Drawing.Point(665, 13);
            this.commandLogTextBox.Multiline = true;
            this.commandLogTextBox.Name = "commandLogTextBox";
            this.commandLogTextBox.Size = new System.Drawing.Size(569, 478);
            this.commandLogTextBox.TabIndex = 4;
            // 
            // ticketAddressTextBox
            // 
            this.ticketAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ticketAddressTextBox.Location = new System.Drawing.Point(3, 4);
            this.ticketAddressTextBox.Name = "ticketAddressTextBox";
            this.ticketAddressTextBox.Size = new System.Drawing.Size(533, 20);
            this.ticketAddressTextBox.TabIndex = 2;
            // 
            // ticketSetStatusComboBox
            // 
            this.ticketSetStatusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ticketSetStatusComboBox.FormattingEnabled = true;
            this.ticketSetStatusComboBox.Items.AddRange(new object[] {
            "Fix",
            "Touch"});
            this.ticketSetStatusComboBox.Location = new System.Drawing.Point(542, 3);
            this.ticketSetStatusComboBox.Name = "ticketSetStatusComboBox";
            this.ticketSetStatusComboBox.Size = new System.Drawing.Size(108, 21);
            this.ticketSetStatusComboBox.TabIndex = 5;
            // 
            // createBranchComboBox
            // 
            this.createBranchComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createBranchComboBox.FormattingEnabled = true;
            this.createBranchComboBox.Items.AddRange(new object[] {
            "Fix / Close",
            "Touch"});
            this.createBranchComboBox.Location = new System.Drawing.Point(3, 32);
            this.createBranchComboBox.Name = "createBranchComboBox";
            this.createBranchComboBox.Size = new System.Drawing.Size(126, 21);
            this.createBranchComboBox.TabIndex = 6;
            // 
            // forcePushCheckBox
            // 
            this.forcePushCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.forcePushCheckBox.AutoSize = true;
            this.forcePushCheckBox.Location = new System.Drawing.Point(656, 73);
            this.forcePushCheckBox.Name = "forcePushCheckBox";
            this.forcePushCheckBox.Size = new System.Drawing.Size(53, 17);
            this.forcePushCheckBox.TabIndex = 7;
            this.forcePushCheckBox.Text = "Force";
            this.forcePushCheckBox.UseVisualStyleBackColor = true;
            // 
            // removeMergedLocalBranches
            // 
            this.removeMergedLocalBranches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeMergedLocalBranches.Location = new System.Drawing.Point(788, 73);
            this.removeMergedLocalBranches.Name = "removeMergedLocalBranches";
            this.removeMergedLocalBranches.Size = new System.Drawing.Size(126, 36);
            this.removeMergedLocalBranches.TabIndex = 8;
            this.removeMergedLocalBranches.Text = "Remove Merged Local Branches";
            this.removeMergedLocalBranches.UseVisualStyleBackColor = true;
            this.removeMergedLocalBranches.Click += new System.EventHandler(this.RemoveMergedLocalBranches_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.panel1.Controls.Add(this.remotePushButton);
            this.panel1.Controls.Add(this.commitMessageTexBox);
            this.panel1.Location = new System.Drawing.Point(12, 497);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1222, 115);
            this.panel1.TabIndex = 9;
            // 
            // gitLabOpenComboBox
            // 
            this.gitLabOpenComboBox.FormattingEnabled = true;
            this.gitLabOpenComboBox.Items.AddRange(new object[] {
            "merge_requests",
            "issues",
            "branches"});
            this.gitLabOpenComboBox.Location = new System.Drawing.Point(921, 30);
            this.gitLabOpenComboBox.Name = "gitLabOpenComboBox";
            this.gitLabOpenComboBox.Size = new System.Drawing.Size(126, 21);
            this.gitLabOpenComboBox.TabIndex = 10;
            this.gitLabOpenComboBox.Text = "GitLab Open:";
            this.gitLabOpenComboBox.SelectedValueChanged += new System.EventHandler(this.GitLabOpenComboBox_SelectedValueChanged);
            // 
            // forceCreateCheckoutCheckBox
            // 
            this.forceCreateCheckoutCheckBox.AutoSize = true;
            this.forceCreateCheckoutCheckBox.Location = new System.Drawing.Point(4, 56);
            this.forceCreateCheckoutCheckBox.Name = "forceCreateCheckoutCheckBox";
            this.forceCreateCheckoutCheckBox.Size = new System.Drawing.Size(53, 17);
            this.forceCreateCheckoutCheckBox.TabIndex = 9;
            this.forceCreateCheckoutCheckBox.Text = "Force";
            this.forceCreateCheckoutCheckBox.UseVisualStyleBackColor = true;
            // 
            // Repository
            // 
            this.Repository.Frozen = true;
            this.Repository.HeaderText = "Repository";
            this.Repository.Name = "Repository";
            this.Repository.ReadOnly = true;
            this.Repository.Width = 150;
            // 
            // CurrentBranch
            // 
            this.CurrentBranch.HeaderText = "CurrentBranch";
            this.CurrentBranch.Name = "CurrentBranch";
            this.CurrentBranch.ReadOnly = true;
            // 
            // AllBranches
            // 
            this.AllBranches.HeaderText = "AllBranches";
            this.AllBranches.Name = "AllBranches";
            this.AllBranches.ReadOnly = true;
            // 
            // MasterAheadAndBehindBy
            // 
            this.MasterAheadAndBehindBy.HeaderText = "MasterAheadBy(+)\r\nMasterBehindBy(-)";
            this.MasterAheadAndBehindBy.Name = "MasterAheadAndBehindBy";
            this.MasterAheadAndBehindBy.ReadOnly = true;
            // 
            // PendingChanges
            // 
            this.PendingChanges.HeaderText = "Pending\r\nChanges";
            this.PendingChanges.Name = "PendingChanges";
            this.PendingChanges.ReadOnly = true;
            this.PendingChanges.Width = 55;
            // 
            // VSCode
            // 
            this.VSCode.HeaderText = "VSCode";
            this.VSCode.Name = "VSCode";
            this.VSCode.ReadOnly = true;
            this.VSCode.Width = 30;
            // 
            // OpenGitExtensions
            // 
            this.OpenGitExtensions.HeaderText = "GitExt";
            this.OpenGitExtensions.Name = "OpenGitExtensions";
            this.OpenGitExtensions.ReadOnly = true;
            this.OpenGitExtensions.Width = 30;
            // 
            // Explorer
            // 
            this.Explorer.HeaderText = "Explorer";
            this.Explorer.Name = "Explorer";
            this.Explorer.ReadOnly = true;
            this.Explorer.Width = 30;
            // 
            // GitMultiRepositoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 616);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.commandLogTextBox);
            this.Controls.Add(this.dataGridView1);
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
        private DataGridViewLinkColumn Repository;
        private DataGridViewTextBoxColumn CurrentBranch;
        private DataGridViewTextBoxColumn AllBranches;
        private DataGridViewTextBoxColumn MasterAheadAndBehindBy;
        private DataGridViewTextBoxColumn PendingChanges;
        private DataGridViewButtonColumn VSCode;
        private DataGridViewButtonColumn OpenGitExtensions;
        private DataGridViewButtonColumn Explorer;
    }
}

