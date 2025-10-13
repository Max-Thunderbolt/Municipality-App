using System;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Municipality_App.Services;

namespace Municipality_App.Forms.Gamification
{
    public partial class FormGamification : MaterialForm
    {
        public FormGamification()
        {
            InitializeComponent();
            ApplyMaterialTheme();
            LoadGamificationData();
        }

        private void ApplyMaterialTheme()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600,
                Primary.Blue700,
                Primary.Blue500,
                Accent.Blue400,
                TextShade.WHITE
            );

            // Configure form for MaterialSkin borderless design
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;

            // Additional styling to prevent rendering artifacts
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void LoadGamificationData()
        {
            try
            {
                var profile = GamificationService.GetProfile();
                var currentBadge = GamificationService.GetCurrentBadge();
                var level = GamificationService.GetLevel();
                var unlockedBadges = GamificationService.GetUnlockedBadges();

                labelPoints.Text = $"Total Points: {profile.Points}";
                labelLevel.Text = $"Current Level: {level}";
                labelCurrentBadge.Text = $"Current Badge: {currentBadge}";
                labelIssuesSubmitted.Text = $"Issues Submitted: {profile.SubmittedIssues.Count}";
                labelActivities.Text = $"Total Activities: {profile.Activities.Count}";

                listBoxBadges.Items.Clear();
                if (unlockedBadges.Length > 0)
                {
                    foreach (var badge in unlockedBadges)
                    {
                        listBoxBadges.Items.Add($"✓ {badge}");
                    }
                }
                else
                {
                    listBoxBadges.Items.Add("No badges unlocked yet. Keep participating!");
                }

                listBoxActivities.Items.Clear();
                var recentActivities = profile
                    .Activities.OrderByDescending(a => a.Timestamp)
                    .Take(10)
                    .ToList();

                if (recentActivities.Count > 0)
                {
                    foreach (var activity in recentActivities)
                    {
                        var timeAgo = GetTimeAgo(activity.Timestamp);
                        listBoxActivities.Items.Add(
                            $"{activity.Description} (+{activity.PointsEarned} pts) - {timeAgo}"
                        );
                    }
                }
                else
                {
                    listBoxActivities.Items.Add("No activities yet. Start by reporting an issue!");
                }

                listBoxIssues.Items.Clear();
                if (profile.SubmittedIssues.Count > 0)
                {
                    foreach (var issue in profile.SubmittedIssues.Take(5))
                    {
                        var timeAgo = GetTimeAgo(issue.CreatedAt);
                        listBoxIssues.Items.Add(
                            $"{issue.Category} at {issue.Location} - {timeAgo}"
                        );
                    }

                    if (profile.SubmittedIssues.Count > 5)
                    {
                        listBoxIssues.Items.Add(
                            $"... and {profile.SubmittedIssues.Count - 5} more issues"
                        );
                    }
                }
                else
                {
                    listBoxIssues.Items.Add("No issues submitted yet.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading gamification data: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string GetTimeAgo(DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            if (timeSpan.TotalDays >= 1)
                return $"{(int)timeSpan.TotalDays} day(s) ago";
            else if (timeSpan.TotalHours >= 1)
                return $"{(int)timeSpan.TotalHours} hour(s) ago";
            else if (timeSpan.TotalMinutes >= 1)
                return $"{(int)timeSpan.TotalMinutes} minute(s) ago";
            else
                return "Just now";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadGamificationData();
        }
    }
}
