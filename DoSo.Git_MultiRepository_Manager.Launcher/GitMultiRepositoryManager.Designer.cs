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
            this.Repository = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CurrentBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllBranches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MasterBehindBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenGitExtensions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.createBranchButton = new System.Windows.Forms.Button();
            this.createBranchTextBox = new System.Windows.Forms.TextBox();
            this.commitButton = new System.Windows.Forms.Button();
            this.commitMessageTexBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.remotePushButton = new System.Windows.Forms.Button();
            this.rebaseOriginMasterButton = new System.Windows.Forms.Button();
            this.commandLogTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Repository,
            this.CurrentBranch,
            this.AllBranches,
            this.MasterBehindBy,
            this.PendingChanges,
            this.OpenGitExtensions});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1808, 853);
            this.dataGridView1.TabIndex = 0;
            // 
            // Repository
            // 
            this.Repository.HeaderText = "Repository";
            this.Repository.Name = "Repository";
            this.Repository.ReadOnly = true;
            this.Repository.Width = 200;
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
            // MasterBehindBy
            // 
            this.MasterBehindBy.HeaderText = "MasterBehindBy";
            this.MasterBehindBy.Name = "MasterBehindBy";
            this.MasterBehindBy.ReadOnly = true;
            // 
            // PendingChanges
            // 
            this.PendingChanges.HeaderText = "PendingChanges";
            this.PendingChanges.Name = "PendingChanges";
            this.PendingChanges.ReadOnly = true;
            // 
            // OpenGitExtensions
            // 
            this.OpenGitExtensions.HeaderText = "OpenGitExtensions";
            this.OpenGitExtensions.Name = "OpenGitExtensions";
            this.OpenGitExtensions.ReadOnly = true;
            // 
            // createBranchButton
            // 
            this.createBranchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createBranchButton.Location = new System.Drawing.Point(321, 895);
            this.createBranchButton.Name = "createBranchButton";
            this.createBranchButton.Size = new System.Drawing.Size(189, 56);
            this.createBranchButton.TabIndex = 1;
            this.createBranchButton.Text = "Create Branch";
            this.createBranchButton.UseVisualStyleBackColor = true;
            this.createBranchButton.Click += new System.EventHandler(this.CreateBranchButton_Click);
            // 
            // createBranchTextBox
            // 
            this.createBranchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createBranchTextBox.Location = new System.Drawing.Point(12, 931);
            this.createBranchTextBox.Name = "createBranchTextBox";
            this.createBranchTextBox.Size = new System.Drawing.Size(303, 20);
            this.createBranchTextBox.TabIndex = 2;
            // 
            // commitButton
            // 
            this.commitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commitButton.Location = new System.Drawing.Point(1070, 878);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(189, 47);
            this.commitButton.TabIndex = 1;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // commitMessageTexBox
            // 
            this.commitMessageTexBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commitMessageTexBox.Location = new System.Drawing.Point(570, 878);
            this.commitMessageTexBox.Multiline = true;
            this.commitMessageTexBox.Name = "commitMessageTexBox";
            this.commitMessageTexBox.Size = new System.Drawing.Size(494, 92);
            this.commitMessageTexBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 895);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Branch Name";
            // 
            // remotePushButton
            // 
            this.remotePushButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remotePushButton.Location = new System.Drawing.Point(1070, 931);
            this.remotePushButton.Name = "remotePushButton";
            this.remotePushButton.Size = new System.Drawing.Size(189, 39);
            this.remotePushButton.TabIndex = 1;
            this.remotePushButton.Text = "Push";
            this.remotePushButton.UseVisualStyleBackColor = true;
            this.remotePushButton.Click += new System.EventHandler(this.RemotePushButton_Click);
            // 
            // rebaseOriginMasterButton
            // 
            this.rebaseOriginMasterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rebaseOriginMasterButton.Location = new System.Drawing.Point(1355, 895);
            this.rebaseOriginMasterButton.Name = "rebaseOriginMasterButton";
            this.rebaseOriginMasterButton.Size = new System.Drawing.Size(189, 56);
            this.rebaseOriginMasterButton.TabIndex = 1;
            this.rebaseOriginMasterButton.Text = "Rebase current branch\r\non origin/master";
            this.rebaseOriginMasterButton.UseVisualStyleBackColor = true;
            // 
            // commandLogTextBox
            // 
            this.commandLogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandLogTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandLogTextBox.Location = new System.Drawing.Point(1827, 13);
            this.commandLogTextBox.Multiline = true;
            this.commandLogTextBox.Name = "commandLogTextBox";
            this.commandLogTextBox.Size = new System.Drawing.Size(507, 852);
            this.commandLogTextBox.TabIndex = 4;
            // 
            // GitMultiRepositoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2346, 982);
            this.Controls.Add(this.commandLogTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commitMessageTexBox);
            this.Controls.Add(this.createBranchTextBox);
            this.Controls.Add(this.remotePushButton);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.rebaseOriginMasterButton);
            this.Controls.Add(this.createBranchButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GitMultiRepositoryManager";
            this.Text = "Git MultiRepository Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Button createBranchButton;
        private TextBox createBranchTextBox;
        private DataGridViewLinkColumn Repository;
        private DataGridViewTextBoxColumn CurrentBranch;
        private DataGridViewTextBoxColumn AllBranches;
        private DataGridViewTextBoxColumn MasterBehindBy;
        private DataGridViewTextBoxColumn PendingChanges;
        private DataGridViewButtonColumn OpenGitExtensions;
        private Button commitButton;
        private TextBox commitMessageTexBox;
        private Label label1;
        private Button remotePushButton;
        private Button rebaseOriginMasterButton;
        private TextBox commandLogTextBox;
    }
}

