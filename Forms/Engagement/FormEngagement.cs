using System;
using System.Windows.Forms;
using Municipality_App.Services;

namespace Municipality_App.Forms.Engagement
{
    public partial class FormEngagement : Form
    {
        public FormEngagement()
        {
            InitializeComponent();
        }

        private void buttonAttendEvent_Click(object sender, EventArgs e)
        {
            GamificationService.AddPoints(25, "Attended local event", "event_attended");
            MessageBox.Show(
                this,
                "Thanks for attending! You earned 25 points.",
                "Event",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void buttonReadAnnouncement_Click(object sender, EventArgs e)
        {
            GamificationService.AddPoints(5, "Read announcement", "announcement_read");
            MessageBox.Show(
                this,
                "Thanks for reading! You earned 5 points.",
                "Announcement",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
