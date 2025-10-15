using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Municipality_App.Models;
using Municipality_App.Services;

namespace Municipality_App.Forms.Issues
{
    public partial class FormReportIssue : MaterialForm
    {
        private readonly List<string> _attachments = new List<string>();

        public FormReportIssue()
        {
            InitializeComponent();
            ApplyMaterialTheme();
            ConfigureFormStyles();
            PopulateCategories();
            SetupProgressTracking();
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

        private void ApplyMaterialTheme()
        {
            ThemeService.ApplyTheme(this, isMainForm: false);

            // Configure responsive layout
            var optimalSize = ThemeService.ResponsiveLayout.GetOptimalFormSize(
                ThemeService.FormSizes.IssueForm
            );
            this.Size = optimalSize;
        }

        private void PopulateCategories()
        {
            comboCategory.Items.Clear();
            comboCategory.Items.AddRange(
                new object[] { "Sanitation", "Roads", "Utilities", "Parks", "Other" }
            );
        }

        private void SetupProgressTracking()
        {
            textLocation.TextChanged += OnFormFieldChanged;
            comboCategory.SelectedIndexChanged += OnFormFieldChanged;
            richDescription.TextChanged += OnFormFieldChanged;

            UpdateProgress();
        }

        private void OnFormFieldChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            int progress = 0;
            string message = "Let's get started! Fill in the details below.";

            if (!string.IsNullOrWhiteSpace(textLocation.Text))
            {
                progress += 25;
                message = "Great start! Location helps us find the issue quickly.";
            }

            if (comboCategory.SelectedItem != null)
            {
                progress += 25;
                message = "Excellent! Category helps us route your report to the right team.";
            }

            if (!string.IsNullOrWhiteSpace(richDescription.Text))
            {
                progress += 25;
                message = "Perfect! Detailed descriptions help us understand the issue better.";
            }

            if (_attachments.Count > 0)
            {
                progress += 25;
                message = "Outstanding! Photos and documents provide valuable context.";
            }

            if (progress >= 75 && progress < 100)
            {
                message = "Almost there! You're doing great - just a few more details.";
            }
            else if (progress == 100)
            {
                message = "Perfect! Your report is complete and ready to submit. Thank you!";
            }
            else if (progress >= 50)
            {
                message = "You're making excellent progress! Keep going!";
            }
            else if (progress >= 25)
            {
                message = "Good progress! Every detail you add helps us serve you better.";
            }

            progressEngagement.Value = progress;
            labelEngagement.Text = message;
        }

        private void buttonAttach_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Attach images or documents";
                dialog.Filter =
                    "Images and Documents|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.pdf;*.doc;*.docx;*.xls;*.xlsx|All files|*.*";
                dialog.Multiselect = true;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (var filePath in dialog.FileNames)
                    {
                        _attachments.Add(filePath);
                        listAttachments.Items.Add(Path.GetFileName(filePath));
                    }
                    UpdateProgress();
                }
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var location = textLocation.Text.Trim();
            var category = comboCategory.SelectedItem as string;
            var description = richDescription.Text.Trim();

            // Enhanced validation with better feedback
            if (!FeedbackService.ValidateRequiredField(textLocation, "Location"))
                return;

            if (!FeedbackService.ValidateRequiredField(comboCategory, "Category"))
                return;

            if (!FeedbackService.ValidateRequiredField(richDescription, "Description"))
                return;

            // Validate description length
            if (description.Length < 20)
            {
                FeedbackService.ShowWarning(
                    "Please provide a more detailed description (at least 20 characters).\nThis helps us better understand and address your issue.",
                    "Description Too Short"
                );
                richDescription.Focus();
                return;
            }

            var issue = new IssueReport
            {
                Location = location,
                Category = category,
                Description = description,
                AttachmentFilePaths = _attachments.ToList(),
            };

            // Add to both repository and user profile
            IssueRepository.Add(issue);
            GamificationService.AddIssue(issue);

            // Award points: base for submission + bonuses for details
            int points = 10; // base for submitting a report
            if (!string.IsNullOrWhiteSpace(location))
                points += 5;
            if (!string.IsNullOrWhiteSpace(category))
                points += 5;
            if (!string.IsNullOrWhiteSpace(description) && description.Length >= 50)
                points += 10; // detailed description
            if (_attachments.Count > 0)
                points += Math.Min(20, _attachments.Count * 5); // up to +20 for attachments
            GamificationService.AddPoints(points, "Issue submitted", "issue_submitted", issue.Id);

            progressEngagement.Value = 100;
            labelEngagement.Text = "Thank you! Your report has been submitted successfully.";

            // Enhanced success feedback
            FeedbackService.ShowSuccess(
                $"Your issue has been reported successfully!\n\n"
                    + $"Issue ID: {issue.Id}\n"
                    + $"Category: {category}\n"
                    + $"Location: {location}\n\n"
                    + $"You earned {points} points for submitting this report.\n"
                    + $"We will investigate and update you on the progress.",
                "Issue Submitted Successfully"
            );

            this.Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
