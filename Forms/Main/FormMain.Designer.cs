namespace Municipality_App.Forms.Main
{
	partial class FormMain
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonReportIssues = new System.Windows.Forms.Button();
            this.buttonEvents = new System.Windows.Forms.Button();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(78, 35);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(319, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Municipality Services - Main Menu";
            // 
            // buttonReportIssues
            // 
            this.buttonReportIssues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.buttonReportIssues.ForeColor = System.Drawing.Color.White;
            this.buttonReportIssues.Location = new System.Drawing.Point(112, 83);
            this.buttonReportIssues.Name = "buttonReportIssues";
            this.buttonReportIssues.Size = new System.Drawing.Size(260, 40);
            this.buttonReportIssues.TabIndex = 1;
            this.buttonReportIssues.Text = "Report Issues";
            this.buttonReportIssues.UseVisualStyleBackColor = false;
            this.buttonReportIssues.Click += new System.EventHandler(this.buttonReportIssues_Click);
            // 
            // buttonEvents
            // 
            this.buttonEvents.Enabled = true;
            this.buttonEvents.Location = new System.Drawing.Point(112, 129);
            this.buttonEvents.Name = "buttonEvents";
            this.buttonEvents.Size = new System.Drawing.Size(260, 40);
            this.buttonEvents.TabIndex = 2;
            this.buttonEvents.Text = "Events and Announcements";
            this.buttonEvents.UseVisualStyleBackColor = true;
            this.buttonEvents.Click += new System.EventHandler(this.buttonEvents_Click);
            // 
            // buttonStatus
            // 
            this.buttonStatus.Enabled = false;
            this.buttonStatus.Location = new System.Drawing.Point(112, 175);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(260, 40);
            this.buttonStatus.TabIndex = 3;
            this.buttonStatus.Text = "Service Request Status (coming soon)";
            this.buttonStatus.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View Activity";
            // 
            // progressToolStripMenuItem
            // 
            this.progressToolStripMenuItem.Name = "progressToolStripMenuItem";
            this.progressToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.progressToolStripMenuItem.Text = "Your Progress";
            this.progressToolStripMenuItem.Click += new System.EventHandler(this.progressToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.buttonStatus);
            this.Controls.Add(this.buttonEvents);
            this.Controls.Add(this.buttonReportIssues);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipality Services";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Button buttonReportIssues;
		private System.Windows.Forms.Button buttonEvents;
		private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem progressToolStripMenuItem;
	}
}