using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Municipality_App.Services
{
    /// <summary>
    /// Centralized theme service for consistent UI appearance across all forms
    /// </summary>
    public static class ThemeService
    {
        private static readonly ColorScheme _applicationColorScheme = new ColorScheme(
            Primary.Orange800,
            Primary.Orange900,
            Primary.Green600,
            Accent.Purple400,
            TextShade.WHITE
        );

        // Standard form sizing for consistency
        public static class FormSizes
        {
            public static readonly Size MainForm = new Size(600, 500);
            public static readonly Size EngagementForm = new Size(750, 625);
            public static readonly Size IssueForm = new Size(600, 700);
            public static readonly Size GamificationForm = new Size(650, 650);
        }

        // Standard spacing and padding
        public static class Spacing
        {
            public const int StandardPadding = 20;
            public const int SmallPadding = 10;
            public const int LargePadding = 30;
            public const int ButtonSpacing = 15;
        }

        /// <summary>
        /// Applies consistent MaterialSkin theme to a form
        /// </summary>
        /// <param name="form">The form to apply theme to</param>
        /// <param name="isMainForm">Whether this is the main application form</param>
        public static void ApplyTheme(MaterialForm form, bool isMainForm = false)
        {
            if (form == null)
                return;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = _applicationColorScheme;

            // Configure form for MaterialSkin borderless design
            form.FormBorderStyle = FormBorderStyle.None;
            form.StartPosition = isMainForm
                ? FormStartPosition.CenterScreen
                : FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Gets consistent font settings for labels and text
        /// </summary>
        public static class Fonts
        {
            public static readonly Font HeaderFont = new Font("Roboto", 14F, FontStyle.Bold);
            public static readonly Font SubHeaderFont = new Font("Roboto", 12F, FontStyle.Bold);
            public static readonly Font BodyFont = new Font("Roboto", 11F, FontStyle.Regular);
            public static readonly Font SmallFont = new Font("Roboto", 10F, FontStyle.Regular);
        }

        /// <summary>
        /// Standard button configurations for consistency
        /// </summary>
        public static void ConfigureButton(
            MaterialRaisedButton button,
            bool isPrimary = true,
            string tooltip = ""
        )
        {
            button.Depth = 0;
            button.Primary = isPrimary;
            button.UseVisualStyleBackColor = true;

            if (!string.IsNullOrEmpty(tooltip))
            {
                // Add tooltip if provided
                var toolTip = new ToolTip();
                toolTip.SetToolTip(button, tooltip);
            }
        }

        /// <summary>
        /// Standard label configurations for consistency
        /// </summary>
        public static void ConfigureLabel(MaterialLabel label, bool isHeader = false)
        {
            label.Depth = 0;
            label.Font = isHeader ? Fonts.HeaderFont : Fonts.BodyFont;
            label.ForeColor = Color.FromArgb(222, 0, 0, 0); // Standard text color
        }

        /// <summary>
        /// Responsive layout helper for different screen sizes
        /// </summary>
        public static class ResponsiveLayout
        {
            public static Size GetOptimalFormSize(Size baseSize, Screen screen = null)
            {
                if (screen == null)
                    screen = Screen.PrimaryScreen;

                var screenBounds = screen.WorkingArea;
                var maxWidth = (int)(screenBounds.Width * 0.9);
                var maxHeight = (int)(screenBounds.Height * 0.9);

                return new Size(
                    Math.Min(baseSize.Width, maxWidth),
                    Math.Min(baseSize.Height, maxHeight)
                );
            }

            public static Point CenterForm(Size formSize, Screen screen = null)
            {
                if (screen == null)
                    screen = Screen.PrimaryScreen;

                var screenBounds = screen.WorkingArea;
                return new Point(
                    (screenBounds.Width - formSize.Width) / 2,
                    (screenBounds.Height - formSize.Height) / 2
                );
            }
        }
    }
}
