using MaterialSkin;
using MaterialSkin.Controls;

namespace Municipality_App.Forms.Gamification
{
    partial class FormGamification : MaterialForm
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
            this.labelPoints = new MaterialSkin.Controls.MaterialLabel();
            this.labelLevel = new MaterialSkin.Controls.MaterialLabel();
            this.labelCurrentBadge = new MaterialSkin.Controls.MaterialLabel();
            this.labelIssuesSubmitted = new MaterialSkin.Controls.MaterialLabel();
            this.labelActivities = new MaterialSkin.Controls.MaterialLabel();
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
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Depth = 0;
            this.labelPoints.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPoints.Location = new System.Drawing.Point(12, 67);
            this.labelPoints.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(107, 19);
            this.labelPoints.TabIndex = 1;
            this.labelPoints.Text = "Total Points: 0";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Depth = 0;
            this.labelLevel.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelLevel.Location = new System.Drawing.Point(12, 86);
            this.labelLevel.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(113, 19);
            this.labelLevel.TabIndex = 2;
            this.labelLevel.Text = "Current Level: 1";
            // 
            // labelCurrentBadge
            // 
            this.labelCurrentBadge.AutoSize = true;
            this.labelCurrentBadge.Depth = 0;
            this.labelCurrentBadge.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelCurrentBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCurrentBadge.Location = new System.Drawing.Point(12, 124);
            this.labelCurrentBadge.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCurrentBadge.Name = "labelCurrentBadge";
            this.labelCurrentBadge.Size = new System.Drawing.Size(138, 19);
            this.labelCurrentBadge.TabIndex = 3;
            this.labelCurrentBadge.Text = "Current Badge: N/A";
            // 
            // labelIssuesSubmitted
            // 
            this.labelIssuesSubmitted.AutoSize = true;
            this.labelIssuesSubmitted.Depth = 0;
            this.labelIssuesSubmitted.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelIssuesSubmitted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelIssuesSubmitted.Location = new System.Drawing.Point(12, 105);
            this.labelIssuesSubmitted.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelIssuesSubmitted.Name = "labelIssuesSubmitted";
            this.labelIssuesSubmitted.Size = new System.Drawing.Size(141, 19);
            this.labelIssuesSubmitted.TabIndex = 4;
            this.labelIssuesSubmitted.Text = "Issues Submitted: 0";
            // 
            // labelActivities
            // 
            this.labelActivities.AutoSize = true;
            this.labelActivities.Depth = 0;
            this.labelActivities.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelActivities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelActivities.Location = new System.Drawing.Point(12, 143);
            this.labelActivities.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelActivities.Name = "labelActivities";
            this.labelActivities.Size = new System.Drawing.Size(127, 19);
            this.labelActivities.TabIndex = 5;
            this.labelActivities.Text = "Total Activities: 0";
            // 
            // groupBoxBadges
            // 
            this.groupBoxBadges.Controls.Add(this.listBoxBadges);
            this.groupBoxBadges.Location = new System.Drawing.Point(12, 177);
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
            this.groupBoxRecentActivities.Location = new System.Drawing.Point(12, 303);
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
            this.groupBoxRecentIssues.Location = new System.Drawing.Point(12, 429);
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
            this.buttonClose.Location = new System.Drawing.Point(237, 564);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(156, 564);
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
            this.ClientSize = new System.Drawing.Size(334, 594);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGamification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Your Progress";
            this.groupBoxBadges.ResumeLayout(false);
            this.groupBoxRecentActivities.ResumeLayout(false);
            this.groupBoxRecentIssues.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private MaterialSkin.Controls.MaterialLabel labelPoints;
        private MaterialSkin.Controls.MaterialLabel labelLevel;
        private MaterialSkin.Controls.MaterialLabel labelCurrentBadge;
        private MaterialSkin.Controls.MaterialLabel labelIssuesSubmitted;
        private MaterialSkin.Controls.MaterialLabel labelActivities;
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
