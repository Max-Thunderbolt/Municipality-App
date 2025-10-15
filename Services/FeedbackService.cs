using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Municipality_App.Services
{
    /// <summary>
    /// Centralized feedback service for consistent user notifications and progress indicators
    /// </summary>
    public static class FeedbackService
    {
        /// <summary>
        /// Shows a success message with consistent styling
        /// </summary>
        public static void ShowSuccess(string message, string title = "Success")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows a warning message with consistent styling
        /// </summary>
        public static void ShowWarning(string message, string title = "Warning")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Shows an error message with consistent styling
        /// </summary>
        public static void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows a confirmation dialog with consistent styling
        /// </summary>
        public static bool ShowConfirmation(string message, string title = "Confirm")
        {
            var result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            return result == DialogResult.Yes;
        }

        public static bool ShowConfirmation(
            string message,
            string title,
            string confirmText,
            string cancelText
        )
        {
            var result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            return result == DialogResult.Yes;
        }

        /// <summary>
        /// Shows a progress dialog for long-running operations
        /// </summary>
        public static ProgressDialog ShowProgress(string title, string message)
        {
            return new ProgressDialog(title, message);
        }

        /// <summary>
        /// Updates a progress bar with feedback message
        /// </summary>
        public static void UpdateProgress(
            ProgressBar progressBar,
            int value,
            string message,
            Label statusLabel = null
        )
        {
            if (progressBar != null)
            {
                progressBar.Value = Math.Max(0, Math.Min(100, value));
            }

            if (statusLabel != null)
            {
                statusLabel.Text = message;
                statusLabel.Refresh();
            }
        }

        /// <summary>
        /// Shows a toast notification (simplified version)
        /// </summary>
        public static void ShowToast(string message, ToastType type = ToastType.Info)
        {
            // For now, use MessageBox as toast alternative
            // In a full implementation, this would show a non-blocking toast
            MessageBoxIcon icon;
            switch (type)
            {
                case ToastType.Success:
                    icon = MessageBoxIcon.Information;
                    break;
                case ToastType.Warning:
                    icon = MessageBoxIcon.Warning;
                    break;
                case ToastType.Error:
                    icon = MessageBoxIcon.Error;
                    break;
                default:
                    icon = MessageBoxIcon.Information;
                    break;
            }

            MessageBox.Show(message, "Notification", MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Validates form input and shows appropriate feedback
        /// </summary>
        public static bool ValidateRequiredField(Control control, string fieldName)
        {
            bool isEmpty = false;

            if (control is TextBox textBox)
            {
                isEmpty = string.IsNullOrWhiteSpace(textBox.Text);
            }
            else if (control is ComboBox comboBox)
            {
                isEmpty = comboBox.SelectedItem == null;
            }
            else if (control is RichTextBox richTextBox)
            {
                isEmpty = string.IsNullOrWhiteSpace(richTextBox.Text);
            }

            if (isEmpty)
            {
                ShowWarning($"Please provide a {fieldName.ToLower()}.", $"Missing {fieldName}");
                control.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Shows detailed information in a formatted dialog
        /// </summary>
        public static void ShowDetails(string title, string content)
        {
            var form = new Form()
            {
                Text = title,
                Size = new Size(500, 400),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
            };

            var textBox = new RichTextBox()
            {
                Text = content,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 10F),
                BackColor = Color.White,
                ForeColor = Color.Black,
            };

            var button = new Button()
            {
                Text = "Close",
                Size = new Size(75, 25),
                Location = new Point(410, 330),
                DialogResult = DialogResult.OK,
            };

            form.Controls.Add(textBox);
            form.Controls.Add(button);
            form.AcceptButton = button;

            form.ShowDialog();
        }
    }

    /// <summary>
    /// Toast notification types
    /// </summary>
    public enum ToastType
    {
        Info,
        Success,
        Warning,
        Error,
    }

    /// <summary>
    /// Progress dialog for long-running operations
    /// </summary>
    public class ProgressDialog : Form
    {
        private ProgressBar progressBar;
        private Label statusLabel;
        private Label titleLabel;

        public ProgressDialog(string title, string initialMessage)
        {
            InitializeComponent(title, initialMessage);
        }

        private void InitializeComponent(string title, string initialMessage)
        {
            this.Text = title;
            this.Size = new Size(400, 150);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;

            titleLabel = new Label()
            {
                Text = title,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold),
                Location = new Point(20, 20),
                Size = new Size(350, 20),
            };

            statusLabel = new Label()
            {
                Text = initialMessage,
                Location = new Point(20, 50),
                Size = new Size(350, 20),
            };

            progressBar = new ProgressBar()
            {
                Location = new Point(20, 80),
                Size = new Size(350, 20),
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
            };

            this.Controls.Add(titleLabel);
            this.Controls.Add(statusLabel);
            this.Controls.Add(progressBar);
        }

        public void UpdateProgress(string message)
        {
            if (statusLabel != null)
            {
                statusLabel.Text = message;
                statusLabel.Refresh();
            }
        }

        public void SetProgress(int value)
        {
            if (progressBar != null)
            {
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Value = Math.Max(0, Math.Min(100, value));
            }
        }
    }
}
