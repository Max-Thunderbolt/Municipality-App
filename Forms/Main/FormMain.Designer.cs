using MaterialSkin;
using MaterialSkin.Controls;


namespace Municipality_App.Forms.Main
{
	partial class FormMain : MaterialForm     
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.buttonReportIssues = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonEvents = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonStatus = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonClose = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.labelDescription = new MaterialSkin.Controls.MaterialLabel();
            this.labelWelcome = new MaterialSkin.Controls.MaterialLabel();
            this.tabPageProgress = new System.Windows.Forms.TabPage();
            this.labelProgressTitle = new MaterialSkin.Controls.MaterialLabel();
            this.labelPoints = new MaterialSkin.Controls.MaterialLabel();
            this.labelLevel = new MaterialSkin.Controls.MaterialLabel();
            this.labelBadge = new MaterialSkin.Controls.MaterialLabel();
            this.labelIssuesSubmitted = new MaterialSkin.Controls.MaterialLabel();
            this.labelActivities = new MaterialSkin.Controls.MaterialLabel();
            this.labelLastActivity = new MaterialSkin.Controls.MaterialLabel();
            this.buttonProgress = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialTabControl1.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReportIssues
            // 
            this.buttonReportIssues.Depth = 0;
            this.buttonReportIssues.Location = new System.Drawing.Point(150, 80);
            this.buttonReportIssues.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonReportIssues.Name = "buttonReportIssues";
            this.buttonReportIssues.Primary = true;
            this.buttonReportIssues.Size = new System.Drawing.Size(300, 48);
            this.buttonReportIssues.TabIndex = 0;
            this.buttonReportIssues.Text = "Report Community Issues";
            this.buttonReportIssues.UseVisualStyleBackColor = true;
            this.buttonReportIssues.Click += new System.EventHandler(this.buttonReportIssues_Click);
            // 
            // buttonEvents
            // 
            this.buttonEvents.Depth = 0;
            this.buttonEvents.Location = new System.Drawing.Point(150, 140);
            this.buttonEvents.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonEvents.Name = "buttonEvents";
            this.buttonEvents.Primary = true;
            this.buttonEvents.Size = new System.Drawing.Size(300, 48);
            this.buttonEvents.TabIndex = 1;
            this.buttonEvents.Text = "View Events & Announcements";
            this.buttonEvents.UseVisualStyleBackColor = true;
            this.buttonEvents.Click += new System.EventHandler(this.buttonEvents_Click);
            // 
            // buttonStatus
            // 
            this.buttonStatus.Depth = 0;
            this.buttonStatus.Enabled = false;
            this.buttonStatus.Location = new System.Drawing.Point(150, 200);
            this.buttonStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Primary = false;
            this.buttonStatus.Size = new System.Drawing.Size(300, 48);
            this.buttonStatus.TabIndex = 2;
            this.buttonStatus.Text = "Track Request Status (Coming Soon)";
            this.buttonStatus.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Salmon;
            this.buttonClose.Depth = 0;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonClose.FlatAppearance.BorderSize = 50;
            this.buttonClose.Location = new System.Drawing.Point(150, 260);
            this.buttonClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Primary = false;
            this.buttonClose.Size = new System.Drawing.Size(300, 48);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Exit Application";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 0);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(600, 48);
            this.materialTabSelector1.TabIndex = 3;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPageMain);
            this.materialTabControl1.Controls.Add(this.tabPageProgress);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 48);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(600, 452);
            this.materialTabControl1.TabIndex = 4;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.labelDescription);
            this.tabPageMain.Controls.Add(this.labelWelcome);
            this.tabPageMain.Controls.Add(this.buttonClose);
            this.tabPageMain.Controls.Add(this.buttonStatus);
            this.tabPageMain.Controls.Add(this.buttonEvents);
            this.tabPageMain.Controls.Add(this.buttonReportIssues);
            this.tabPageMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(592, 426);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main Menu";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // labelDescription
            // 
            this.labelDescription.Depth = 0;
            this.labelDescription.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDescription.Location = new System.Drawing.Point(50, 45);
            this.labelDescription.MaximumSize = new System.Drawing.Size(500, 0);
            this.labelDescription.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(500, 0);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Report community issues, discover local events, and track your civic engagement i" +
    "n the City of Gold";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Depth = 0;
            this.labelWelcome.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelWelcome.Location = new System.Drawing.Point(137, 12);
            this.labelWelcome.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(334, 19);
            this.labelWelcome.TabIndex = 3;
            this.labelWelcome.Text = "Welcome to Johannesburg Municipality Services";
            // 
            // tabPageProgress
            // 
            this.tabPageProgress.Controls.Add(this.labelProgressTitle);
            this.tabPageProgress.Controls.Add(this.labelPoints);
            this.tabPageProgress.Controls.Add(this.labelLevel);
            this.tabPageProgress.Controls.Add(this.labelBadge);
            this.tabPageProgress.Controls.Add(this.labelIssuesSubmitted);
            this.tabPageProgress.Controls.Add(this.labelActivities);
            this.tabPageProgress.Controls.Add(this.labelLastActivity);
            this.tabPageProgress.Controls.Add(this.buttonProgress);
            this.tabPageProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageProgress.Location = new System.Drawing.Point(4, 22);
            this.tabPageProgress.Name = "tabPageProgress";
            this.tabPageProgress.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProgress.Size = new System.Drawing.Size(592, 426);
            this.tabPageProgress.TabIndex = 1;
            this.tabPageProgress.Text = "Your Progress";
            this.tabPageProgress.UseVisualStyleBackColor = true;
            // 
            // labelProgressTitle
            // 
            this.labelProgressTitle.AutoSize = true;
            this.labelProgressTitle.Depth = 0;
            this.labelProgressTitle.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelProgressTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelProgressTitle.Location = new System.Drawing.Point(20, 20);
            this.labelProgressTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelProgressTitle.Name = "labelProgressTitle";
            this.labelProgressTitle.Size = new System.Drawing.Size(164, 19);
            this.labelProgressTitle.TabIndex = 1;
            this.labelProgressTitle.Text = "Your Civic Engagement";
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Depth = 0;
            this.labelPoints.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPoints.Location = new System.Drawing.Point(20, 60);
            this.labelPoints.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(68, 19);
            this.labelPoints.TabIndex = 2;
            this.labelPoints.Text = "Points: 0";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Depth = 0;
            this.labelLevel.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelLevel.Location = new System.Drawing.Point(20, 90);
            this.labelLevel.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(60, 19);
            this.labelLevel.TabIndex = 3;
            this.labelLevel.Text = "Level: 1";
            // 
            // labelBadge
            // 
            this.labelBadge.AutoSize = true;
            this.labelBadge.Depth = 0;
            this.labelBadge.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelBadge.Location = new System.Drawing.Point(20, 120);
            this.labelBadge.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelBadge.Name = "labelBadge";
            this.labelBadge.Size = new System.Drawing.Size(131, 19);
            this.labelBadge.TabIndex = 4;
            this.labelBadge.Text = "Badge: Newcomer";
            // 
            // labelIssuesSubmitted
            // 
            this.labelIssuesSubmitted.AutoSize = true;
            this.labelIssuesSubmitted.Depth = 0;
            this.labelIssuesSubmitted.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelIssuesSubmitted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelIssuesSubmitted.Location = new System.Drawing.Point(20, 150);
            this.labelIssuesSubmitted.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelIssuesSubmitted.Name = "labelIssuesSubmitted";
            this.labelIssuesSubmitted.Size = new System.Drawing.Size(141, 19);
            this.labelIssuesSubmitted.TabIndex = 5;
            this.labelIssuesSubmitted.Text = "Issues Submitted: 0";
            // 
            // labelActivities
            // 
            this.labelActivities.AutoSize = true;
            this.labelActivities.Depth = 0;
            this.labelActivities.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelActivities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelActivities.Location = new System.Drawing.Point(20, 180);
            this.labelActivities.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelActivities.Name = "labelActivities";
            this.labelActivities.Size = new System.Drawing.Size(88, 19);
            this.labelActivities.TabIndex = 6;
            this.labelActivities.Text = "Activities: 0";
            // 
            // labelLastActivity
            // 
            this.labelLastActivity.AutoSize = true;
            this.labelLastActivity.Depth = 0;
            this.labelLastActivity.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelLastActivity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelLastActivity.Location = new System.Drawing.Point(20, 210);
            this.labelLastActivity.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelLastActivity.Name = "labelLastActivity";
            this.labelLastActivity.Size = new System.Drawing.Size(139, 19);
            this.labelLastActivity.TabIndex = 7;
            this.labelLastActivity.Text = "Last Activity: Never";
            // 
            // buttonProgress
            // 
            this.buttonProgress.Depth = 0;
            this.buttonProgress.Location = new System.Drawing.Point(8, 232);
            this.buttonProgress.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonProgress.Name = "buttonProgress";
            this.buttonProgress.Primary = true;
            this.buttonProgress.Size = new System.Drawing.Size(202, 44);
            this.buttonProgress.TabIndex = 0;
            this.buttonProgress.Text = "View Detailed Progress";
            this.buttonProgress.UseVisualStyleBackColor = true;
            this.buttonProgress.Click += new System.EventHandler(this.progressToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Johannesburg Municipality Services";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageProgress.ResumeLayout(false);
            this.tabPageProgress.PerformLayout();
            this.ResumeLayout(false);

		}
		private MaterialSkin.Controls.MaterialRaisedButton buttonReportIssues;
		private MaterialSkin.Controls.MaterialRaisedButton buttonEvents;
		private MaterialSkin.Controls.MaterialRaisedButton buttonStatus;
		private MaterialSkin.Controls.MaterialRaisedButton buttonClose;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageProgress;
        private MaterialSkin.Controls.MaterialLabel labelWelcome;
        private MaterialSkin.Controls.MaterialLabel labelDescription;
        private MaterialSkin.Controls.MaterialRaisedButton buttonProgress;
        private MaterialSkin.Controls.MaterialLabel labelProgressTitle;
        private MaterialSkin.Controls.MaterialLabel labelPoints;
        private MaterialSkin.Controls.MaterialLabel labelLevel;
        private MaterialSkin.Controls.MaterialLabel labelBadge;
        private MaterialSkin.Controls.MaterialLabel labelIssuesSubmitted;
        private MaterialSkin.Controls.MaterialLabel labelActivities;
        private MaterialSkin.Controls.MaterialLabel labelLastActivity;
	}
}