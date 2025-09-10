using System;
using System.Windows.Forms;
using Municipality_App.Forms.Engagement;
using Municipality_App.Forms.Gamification;
using Municipality_App.Forms.Issues;

namespace Municipality_App.Forms.Main
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
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
