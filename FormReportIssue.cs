using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Municipality_App
{
    public partial class FormReportIssue : Form
    {
        private readonly List<string> _attachments = new List<string>();

        public FormReportIssue()
        {
            InitializeComponent();
            PopulateCategories();
            SetupProgressTracking();
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

            if (string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show(
                    this,
                    "Please enter the location of the issue.",
                    "Missing Location",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show(
                    this,
                    "Please select a category.",
                    "Missing Category",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show(
                    this,
                    "Please provide a brief description.",
                    "Missing Description",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var issue = new IssueReport
            {
                Location = location,
                Category = category,
                Description = description,
                AttachmentFilePaths = _attachments.ToList(),
            };

            IssueRepository.Add(issue);

            progressEngagement.Value = 100;
            labelEngagement.Text = "Thank you! Your report has been submitted successfully.";
            MessageBox.Show(
                this,
                "Your issue has been reported successfully.",
                "Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            this.Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
