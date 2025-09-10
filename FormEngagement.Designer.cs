namespace Municipality_App
{
	partial class FormEngagement
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
			this.labelHeader = new System.Windows.Forms.Label();
			this.buttonAttendEvent = new System.Windows.Forms.Button();
			this.buttonReadAnnouncement = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelHeader
			// 
			this.labelHeader.AutoSize = true;
			this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.labelHeader.Location = new System.Drawing.Point(12, 9);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new System.Drawing.Size(246, 21);
			this.labelHeader.TabIndex = 0;
			this.labelHeader.Text = "Events & Announcements Center";
			// 
			// buttonAttendEvent
			// 
			this.buttonAttendEvent.Location = new System.Drawing.Point(16, 44);
			this.buttonAttendEvent.Name = "buttonAttendEvent";
			this.buttonAttendEvent.Size = new System.Drawing.Size(248, 40);
			this.buttonAttendEvent.TabIndex = 1;
			this.buttonAttendEvent.Text = "Mark attendance for a local event (+25 pts)";
			this.buttonAttendEvent.UseVisualStyleBackColor = true;
			this.buttonAttendEvent.Click += new System.EventHandler(this.buttonAttendEvent_Click);
			// 
			// buttonReadAnnouncement
			// 
			this.buttonReadAnnouncement.Location = new System.Drawing.Point(16, 90);
			this.buttonReadAnnouncement.Name = "buttonReadAnnouncement";
			this.buttonReadAnnouncement.Size = new System.Drawing.Size(248, 40);
			this.buttonReadAnnouncement.TabIndex = 2;
			this.buttonReadAnnouncement.Text = "I read a municipal announcement (+5 pts)";
			this.buttonReadAnnouncement.UseVisualStyleBackColor = true;
			this.buttonReadAnnouncement.Click += new System.EventHandler(this.buttonReadAnnouncement_Click);
			// 
			// FormEngagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 151);
			this.Controls.Add(this.buttonReadAnnouncement);
			this.Controls.Add(this.buttonAttendEvent);
			this.Controls.Add(this.labelHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEngagement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Engagement";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.Label labelHeader;
		private System.Windows.Forms.Button buttonAttendEvent;
		private System.Windows.Forms.Button buttonReadAnnouncement;
	}
}


