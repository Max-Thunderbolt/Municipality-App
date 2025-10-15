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
            this.labelFormCompletions = new MaterialSkin.Controls.MaterialLabel();
            this.labelSocialShares = new MaterialSkin.Controls.MaterialLabel();
            this.labelChallengeParticipations = new MaterialSkin.Controls.MaterialLabel();
            this.groupBoxBadges = new System.Windows.Forms.GroupBox();
            this.listBoxBadges = new System.Windows.Forms.ListBox();
            this.groupBoxAchievements = new System.Windows.Forms.GroupBox();
            this.listBoxAchievements = new System.Windows.Forms.ListBox();
            this.groupBoxChallenges = new System.Windows.Forms.GroupBox();
            this.listBoxChallenges = new System.Windows.Forms.ListBox();
            this.groupBoxRecentActivities = new System.Windows.Forms.GroupBox();
            this.listBoxActivities = new System.Windows.Forms.ListBox();
            this.groupBoxRecentIssues = new System.Windows.Forms.GroupBox();
            this.listBoxIssues = new System.Windows.Forms.ListBox();
            this.groupBoxBadges.SuspendLayout();
            this.groupBoxAchievements.SuspendLayout();
            this.groupBoxChallenges.SuspendLayout();
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
            this.labelActivities.Location = new System.Drawing.Point(11, 143);
            this.labelActivities.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelActivities.Name = "labelActivities";
            this.labelActivities.Size = new System.Drawing.Size(127, 19);
            this.labelActivities.TabIndex = 5;
            this.labelActivities.Text = "Total Activities: 0";
            // 
            // labelFormCompletions
            // 
            this.labelFormCompletions.AutoSize = true;
            this.labelFormCompletions.Depth = 0;
            this.labelFormCompletions.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelFormCompletions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelFormCompletions.Location = new System.Drawing.Point(11, 162);
            this.labelFormCompletions.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelFormCompletions.Name = "labelFormCompletions";
            this.labelFormCompletions.Size = new System.Drawing.Size(145, 19);
            this.labelFormCompletions.TabIndex = 6;
            this.labelFormCompletions.Text = "Forms Completed: 0";
            // 
            // labelSocialShares
            // 
            this.labelSocialShares.AutoSize = true;
            this.labelSocialShares.Depth = 0;
            this.labelSocialShares.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelSocialShares.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSocialShares.Location = new System.Drawing.Point(199, 162);
            this.labelSocialShares.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelSocialShares.Name = "labelSocialShares";
            this.labelSocialShares.Size = new System.Drawing.Size(117, 19);
            this.labelSocialShares.TabIndex = 7;
            this.labelSocialShares.Text = "Social Shares: 0";
            // 
            // labelChallengeParticipations
            // 
            this.labelChallengeParticipations.AutoSize = true;
            this.labelChallengeParticipations.Depth = 0;
            this.labelChallengeParticipations.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelChallengeParticipations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelChallengeParticipations.Location = new System.Drawing.Point(349, 162);
            this.labelChallengeParticipations.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelChallengeParticipations.Name = "labelChallengeParticipations";
            this.labelChallengeParticipations.Size = new System.Drawing.Size(99, 19);
            this.labelChallengeParticipations.TabIndex = 8;
            this.labelChallengeParticipations.Text = "Challenges: 0";
            // 
            // groupBoxBadges
            // 
            this.groupBoxBadges.Controls.Add(this.listBoxBadges);
            this.groupBoxBadges.Location = new System.Drawing.Point(11, 189);
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
            // groupBoxAchievements
            // 
            this.groupBoxAchievements.Controls.Add(this.listBoxAchievements);
            this.groupBoxAchievements.Location = new System.Drawing.Point(317, 189);
            this.groupBoxAchievements.Name = "groupBoxAchievements";
            this.groupBoxAchievements.Size = new System.Drawing.Size(300, 120);
            this.groupBoxAchievements.TabIndex = 9;
            this.groupBoxAchievements.TabStop = false;
            this.groupBoxAchievements.Text = "Achievements";
            // 
            // listBoxAchievements
            // 
            this.listBoxAchievements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAchievements.FormattingEnabled = true;
            this.listBoxAchievements.Location = new System.Drawing.Point(3, 16);
            this.listBoxAchievements.Name = "listBoxAchievements";
            this.listBoxAchievements.Size = new System.Drawing.Size(294, 101);
            this.listBoxAchievements.TabIndex = 0;
            // 
            // groupBoxChallenges
            // 
            this.groupBoxChallenges.Controls.Add(this.listBoxChallenges);
            this.groupBoxChallenges.Location = new System.Drawing.Point(317, 315);
            this.groupBoxChallenges.Name = "groupBoxChallenges";
            this.groupBoxChallenges.Size = new System.Drawing.Size(300, 120);
            this.groupBoxChallenges.TabIndex = 10;
            this.groupBoxChallenges.TabStop = false;
            this.groupBoxChallenges.Text = "Community Challenges";
            // 
            // listBoxChallenges
            // 
            this.listBoxChallenges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxChallenges.FormattingEnabled = true;
            this.listBoxChallenges.Location = new System.Drawing.Point(3, 16);
            this.listBoxChallenges.Name = "listBoxChallenges";
            this.listBoxChallenges.Size = new System.Drawing.Size(294, 101);
            this.listBoxChallenges.TabIndex = 0;
            // 
            // groupBoxRecentActivities
            // 
            this.groupBoxRecentActivities.Controls.Add(this.listBoxActivities);
            this.groupBoxRecentActivities.Location = new System.Drawing.Point(11, 315);
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
            this.groupBoxRecentIssues.Location = new System.Drawing.Point(11, 441);
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
            // FormGamification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(833, 641);
            this.Controls.Add(this.groupBoxRecentIssues);
            this.Controls.Add(this.groupBoxChallenges);
            this.Controls.Add(this.groupBoxAchievements);
            this.Controls.Add(this.groupBoxRecentActivities);
            this.Controls.Add(this.groupBoxBadges);
            this.Controls.Add(this.labelChallengeParticipations);
            this.Controls.Add(this.labelSocialShares);
            this.Controls.Add(this.labelFormCompletions);
            this.Controls.Add(this.labelActivities);
            this.Controls.Add(this.labelIssuesSubmitted);
            this.Controls.Add(this.labelCurrentBadge);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelPoints);
            this.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Name = "FormGamification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Your Progress";
            this.groupBoxBadges.ResumeLayout(false);
            this.groupBoxAchievements.ResumeLayout(false);
            this.groupBoxChallenges.ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialLabel labelFormCompletions;
        private MaterialSkin.Controls.MaterialLabel labelSocialShares;
        private MaterialSkin.Controls.MaterialLabel labelChallengeParticipations;
        private System.Windows.Forms.GroupBox groupBoxBadges;
        private System.Windows.Forms.ListBox listBoxBadges;
        private System.Windows.Forms.GroupBox groupBoxAchievements;
        private System.Windows.Forms.ListBox listBoxAchievements;
        private System.Windows.Forms.GroupBox groupBoxChallenges;
        private System.Windows.Forms.ListBox listBoxChallenges;
        private System.Windows.Forms.GroupBox groupBoxRecentActivities;
        private System.Windows.Forms.ListBox listBoxActivities;
        private System.Windows.Forms.GroupBox groupBoxRecentIssues;
        private System.Windows.Forms.ListBox listBoxIssues;
    }
}