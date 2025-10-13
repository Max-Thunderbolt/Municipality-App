using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Municipality_App.Forms.Engagement;
using Municipality_App.Forms.Gamification;
using Municipality_App.Forms.Issues;

namespace Municipality_App.Forms.Main
{
    public partial class FormMain : MaterialForm
    {
        public FormMain()
        {
            InitializeComponent();
            ApplyMaterialTheme();
        }

        // MaterialSkin theme
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
            this.StartPosition = FormStartPosition.CenterScreen;

            // Additional styling to prevent rendering artifacts
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
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

        private void progressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormGamification())
            {
                form.ShowDialog(this);
            }
        }
    }
}
