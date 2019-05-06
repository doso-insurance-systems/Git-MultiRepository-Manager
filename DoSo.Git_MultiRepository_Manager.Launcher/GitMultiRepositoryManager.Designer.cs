using System.Windows.Forms;

namespace WindowsFormsApp1
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
            this.dataGridView1.Size = new System.Drawing.Size(2322, 853);
            this.dataGridView1.TabIndex = 0;
            // 
            // Repository
            // 
            this.Repository.HeaderText = "Repository";
            this.Repository.Name = "Repository";
            this.Repository.ReadOnly = true;
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
            this.createBranchButton.Location = new System.Drawing.Point(321, 914);
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
            this.createBranchTextBox.Location = new System.Drawing.Point(12, 914);
            this.createBranchTextBox.Name = "createBranchTextBox";
            this.createBranchTextBox.Size = new System.Drawing.Size(303, 20);
            this.createBranchTextBox.TabIndex = 2;
            // 
            // GitMultiRepositoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2346, 982);
            this.Controls.Add(this.createBranchTextBox);
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
        private DataGridViewLinkColumn Repository;
        private DataGridViewTextBoxColumn CurrentBranch;
        private DataGridViewTextBoxColumn AllBranches;
        private DataGridViewTextBoxColumn MasterBehindBy;
        private DataGridViewTextBoxColumn PendingChanges;
        private DataGridViewButtonColumn OpenGitExtensions;
        private Button createBranchButton;
        private TextBox createBranchTextBox;
    }
}

