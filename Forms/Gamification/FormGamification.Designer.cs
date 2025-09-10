namespace Municipality_App.Forms.Gamification
{
    partial class FormGamification
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.labelCurrentBadge = new System.Windows.Forms.Label();
            this.labelIssuesSubmitted = new System.Windows.Forms.Label();
            this.labelActivities = new System.Windows.Forms.Label();
            this.groupBoxBadges = new System.Windows.Forms.GroupBox();
            this.listBoxBadges = new System.Windows.Forms.ListBox();
            this.groupBoxRecentActivities = new System.Windows.Forms.GroupBox();
            this.listBoxActivities = new System.Windows.Forms.ListBox();
            this.groupBoxRecentIssues = new System.Windows.Forms.GroupBox();
            this.listBoxIssues = new System.Windows.Forms.ListBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.groupBoxBadges.SuspendLayout();
            this.groupBoxRecentActivities.SuspendLayout();
            this.groupBoxRecentIssues.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(200, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Your Progress & Achievements";
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.labelPoints.Location = new System.Drawing.Point(12, 44);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(95, 19);
            this.labelPoints.TabIndex = 1;
            this.labelPoints.Text = "Total Points: 0";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.labelLevel.Location = new System.Drawing.Point(12, 67);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(95, 19);
            this.labelLevel.TabIndex = 2;
            this.labelLevel.Text = "Current Level: 1";
            // 
            // labelCurrentBadge
            // 
            this.labelCurrentBadge.AutoSize = true;
            this.labelCurrentBadge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelCurrentBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.labelCurrentBadge.Location = new System.Drawing.Point(12, 90);
            this.labelCurrentBadge.Name = "labelCurrentBadge";
            this.labelCurrentBadge.Size = new System.Drawing.Size(120, 19);
            this.labelCurrentBadge.TabIndex = 3;
            this.labelCurrentBadge.Text = "Current Badge: N/A";
            // 
            // labelIssuesSubmitted
            // 
            this.labelIssuesSubmitted.AutoSize = true;
            this.labelIssuesSubmitted.Location = new System.Drawing.Point(12, 113);
            this.labelIssuesSubmitted.Name = "labelIssuesSubmitted";
            this.labelIssuesSubmitted.Size = new System.Drawing.Size(95, 13);
            this.labelIssuesSubmitted.TabIndex = 4;
            this.labelIssuesSubmitted.Text = "Issues Submitted: 0";
            // 
            // labelActivities
            // 
            this.labelActivities.AutoSize = true;
            this.labelActivities.Location = new System.Drawing.Point(12, 130);
            this.labelActivities.Name = "labelActivities";
            this.labelActivities.Size = new System.Drawing.Size(95, 13);
            this.labelActivities.TabIndex = 5;
            this.labelActivities.Text = "Total Activities: 0";
            // 
            // groupBoxBadges
            // 
            this.groupBoxBadges.Controls.Add(this.listBoxBadges);
            this.groupBoxBadges.Location = new System.Drawing.Point(12, 153);
            this.groupBoxBadges.Name = "groupBoxBadges";
            this.groupBoxBadges.Size = new System.Drawing.Size(300, 120);
            this.groupBoxBadges.TabIndex = 6;
            this.groupBoxBadges.TabStop = false;
            this.groupBoxBadges.Text = "Unlocked Badges";
            // 
            // listBoxBadges
            // 
            this.listBoxBadges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxBadges.FormattingEnabled = true;
            this.listBoxBadges.Location = new System.Drawing.Point(3, 16);
            this.listBoxBadges.Name = "listBoxBadges";
            this.listBoxBadges.Size = new System.Drawing.Size(294, 101);
            this.listBoxBadges.TabIndex = 0;
            // 
            // groupBoxRecentActivities
            // 
            this.groupBoxRecentActivities.Controls.Add(this.listBoxActivities);
            this.groupBoxRecentActivities.Location = new System.Drawing.Point(12, 279);
            this.groupBoxRecentActivities.Name = "groupBoxRecentActivities";
            this.groupBoxRecentActivities.Size = new System.Drawing.Size(300, 120);
            this.groupBoxRecentActivities.TabIndex = 7;
            this.groupBoxRecentActivities.TabStop = false;
            this.groupBoxRecentActivities.Text = "Recent Activities";
            // 
            // listBoxActivities
            // 
            this.listBoxActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxActivities.FormattingEnabled = true;
            this.listBoxActivities.Location = new System.Drawing.Point(3, 16);
            this.listBoxActivities.Name = "listBoxActivities";
            this.listBoxActivities.Size = new System.Drawing.Size(294, 101);
            this.listBoxActivities.TabIndex = 0;
            // 
            // groupBoxRecentIssues
            // 
            this.groupBoxRecentIssues.Controls.Add(this.listBoxIssues);
            this.groupBoxRecentIssues.Location = new System.Drawing.Point(12, 405);
            this.groupBoxRecentIssues.Name = "groupBoxRecentIssues";
            this.groupBoxRecentIssues.Size = new System.Drawing.Size(300, 120);
            this.groupBoxRecentIssues.TabIndex = 8;
            this.groupBoxRecentIssues.TabStop = false;
            this.groupBoxRecentIssues.Text = "Recent Issues Submitted";
            // 
            // listBoxIssues
            // 
            this.listBoxIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxIssues.FormattingEnabled = true;
            this.listBoxIssues.Location = new System.Drawing.Point(3, 16);
            this.listBoxIssues.Name = "listBoxIssues";
            this.listBoxIssues.Size = new System.Drawing.Size(294, 101);
            this.listBoxIssues.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(237, 540);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(156, 540);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 10;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // FormGamification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 575);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxRecentIssues);
            this.Controls.Add(this.groupBoxRecentActivities);
            this.Controls.Add(this.groupBoxBadges);
            this.Controls.Add(this.labelActivities);
            this.Controls.Add(this.labelIssuesSubmitted);
            this.Controls.Add(this.labelCurrentBadge);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGamification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Your Progress";
            this.groupBoxBadges.ResumeLayout(false);
            this.groupBoxRecentActivities.ResumeLayout(false);
            this.groupBoxRecentIssues.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelCurrentBadge;
        private System.Windows.Forms.Label labelIssuesSubmitted;
        private System.Windows.Forms.Label labelActivities;
        private System.Windows.Forms.GroupBox groupBoxBadges;
        private System.Windows.Forms.ListBox listBoxBadges;
        private System.Windows.Forms.GroupBox groupBoxRecentActivities;
        private System.Windows.Forms.ListBox listBoxActivities;
        private System.Windows.Forms.GroupBox groupBoxRecentIssues;
        private System.Windows.Forms.ListBox listBoxIssues;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonRefresh;
    }
}
