using System;
using System.Windows.Forms;

namespace Municipality_App
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
    }
}
