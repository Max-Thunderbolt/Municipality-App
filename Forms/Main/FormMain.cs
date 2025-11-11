using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Municipality_App.Forms.Engagement;
using Municipality_App.Forms.Gamification;
using Municipality_App.Forms.Issues;
using Municipality_App.Forms.ServiceStatus;
using Municipality_App.Services;

namespace Municipality_App.Forms.Main
{
    public partial class FormMain : MaterialForm
    {
        public FormMain()
        {
            InitializeComponent();
            ApplyMaterialTheme();
            ConfigureResponsiveLayout();
            ConfigureFormStyles();
            LoadProgressData();
            SetupEventHandlers();
        }

        // Configure form styles for better rendering
        private void ConfigureFormStyles()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        // Apply centralized theme for consistency
        private void ApplyMaterialTheme()
        {
            ThemeService.ApplyTheme(this, isMainForm: true);
        }

        // Configure responsive layout for different screen sizes
        private void ConfigureResponsiveLayout()
        {
            // Set optimal form size based on screen resolution
            var optimalSize = ThemeService.ResponsiveLayout.GetOptimalFormSize(
                ThemeService.FormSizes.MainForm
            );
            this.Size = optimalSize;

            // Center the form on screen
            var centerPoint = ThemeService.ResponsiveLayout.CenterForm(this.Size);
            this.Location = centerPoint;
        }

        private void buttonReportIssues_Click(object sender, EventArgs e)
        {
            using (var form = new FormReportIssue())
            {
                form.ShowDialog(this);
            }
        }

        private void buttonEvents_Click(object sender, EventArgs e)
        {
            using (var form = new FormEngagement())
            {
                form.ShowDialog(this);
            }
        }

        private void buttonStatus_Click(object sender, EventArgs e)
        {
            using (var form = new FormServiceStatus())
            {
                form.ShowDialog(this);
            }
        }

        private void progressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormGamification())
            {
                form.ShowDialog(this);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Show confirmation dialog before closing
            var result = FeedbackService.ShowConfirmation(
                "Are you sure you want to exit the application?\n\nAny unsaved data will be lost.",
                "Exit Application"
            );

            if (result)
            {
                Application.Exit();
            }
        }

        private void SetupEventHandlers()
        {
            // Add event handler for tab selection to refresh progress data
            materialTabControl1.SelectedIndexChanged += MaterialTabControl1_SelectedIndexChanged;
        }

        private void MaterialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresh progress data when switching to progress tab
            if (materialTabControl1.SelectedTab == tabPageProgress)
            {
                LoadProgressData();
            }
        }

        private void LoadProgressData()
        {
            try
            {
                // Initialize gamification service
                GamificationService.Initialize();

                // Get user profile
                var profile = GamificationService.GetProfile();

                // Update progress labels
                labelPoints.Text = $"Points: {profile.Points}";
                labelLevel.Text = $"Level: {GamificationService.GetLevel()}";
                labelBadge.Text = $"Badge: {GamificationService.GetCurrentBadge()}";
                labelIssuesSubmitted.Text = $"Issues Submitted: {profile.SubmittedIssues.Count}";
                labelActivities.Text = $"Activities: {profile.Activities.Count}";

                // Format last activity date
                if (profile.LastActivityAt > DateTime.MinValue)
                {
                    var timeSince = DateTime.Now - profile.LastActivityAt;
                    if (timeSince.TotalDays >= 1)
                    {
                        labelLastActivity.Text = $"Last Activity: {timeSince.Days} days ago";
                    }
                    else if (timeSince.TotalHours >= 1)
                    {
                        labelLastActivity.Text = $"Last Activity: {timeSince.Hours} hours ago";
                    }
                    else if (timeSince.TotalMinutes >= 1)
                    {
                        labelLastActivity.Text = $"Last Activity: {timeSince.Minutes} minutes ago";
                    }
                    else
                    {
                        labelLastActivity.Text = "Last Activity: Just now";
                    }
                }
                else
                {
                    labelLastActivity.Text = "Last Activity: Never";
                }
            }
            catch (Exception)
            {
                // Handle any errors gracefully
                labelPoints.Text = "Points: 0";
                labelLevel.Text = "Level: 1";
                labelBadge.Text = "Badge: Newcomer";
                labelIssuesSubmitted.Text = "Issues Submitted: 0";
                labelActivities.Text = "Activities: 0";
                labelLastActivity.Text = "Last Activity: Never";
            }
        }

        private void labelDescription_Click(object sender, EventArgs e) { }
    }
}
