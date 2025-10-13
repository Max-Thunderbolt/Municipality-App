namespace Municipality_App.Forms.Engagement
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageEvents = new System.Windows.Forms.TabPage();
			this.listBoxEvents = new System.Windows.Forms.ListBox();
			this.buttonRegisterEvent = new System.Windows.Forms.Button();
			this.labelEvents = new System.Windows.Forms.Label();
			this.tabPageAnnouncements = new System.Windows.Forms.TabPage();
			this.listBoxAnnouncements = new System.Windows.Forms.ListBox();
			this.buttonReadAnnouncement = new System.Windows.Forms.Button();
			this.labelAnnouncements = new System.Windows.Forms.Label();
			this.tabPageRecommendations = new System.Windows.Forms.TabPage();
			this.listBoxRecommendations = new System.Windows.Forms.ListBox();
			this.labelRecommendations = new System.Windows.Forms.Label();
			this.buttonViewRecommendations = new System.Windows.Forms.Button();
			this.groupBoxSearch = new System.Windows.Forms.GroupBox();
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			this.labelSearch = new System.Windows.Forms.Label();
			this.comboBoxCategory = new System.Windows.Forms.ComboBox();
			this.labelCategory = new System.Windows.Forms.Label();
			this.comboBoxLocation = new System.Windows.Forms.ComboBox();
			this.labelLocation = new System.Windows.Forms.Label();
			this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
			this.labelEventStats = new System.Windows.Forms.Label();
			this.labelAnnouncementStats = new System.Windows.Forms.Label();
			this.labelSearchStats = new System.Windows.Forms.Label();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tabPageEvents.SuspendLayout();
			this.tabPageAnnouncements.SuspendLayout();
			this.tabPageRecommendations.SuspendLayout();
			this.groupBoxSearch.SuspendLayout();
			this.groupBoxStatistics.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelHeader
			// 
			this.labelHeader.AutoSize = true;
			this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
			this.labelHeader.Location = new System.Drawing.Point(12, 9);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new System.Drawing.Size(246, 25);
			this.labelHeader.TabIndex = 0;
			this.labelHeader.Text = "Events & Announcements Center";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageEvents);
			this.tabControl.Controls.Add(this.tabPageAnnouncements);
			this.tabControl.Controls.Add(this.tabPageRecommendations);
			this.tabControl.Location = new System.Drawing.Point(12, 50);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(560, 300);
			this.tabControl.TabIndex = 1;
			// 
			// tabPageEvents
			// 
			this.tabPageEvents.Controls.Add(this.listBoxEvents);
			this.tabPageEvents.Controls.Add(this.buttonRegisterEvent);
			this.tabPageEvents.Controls.Add(this.labelEvents);
			this.tabPageEvents.Location = new System.Drawing.Point(4, 22);
			this.tabPageEvents.Name = "tabPageEvents";
			this.tabPageEvents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageEvents.Size = new System.Drawing.Size(552, 274);
			this.tabPageEvents.TabIndex = 0;
			this.tabPageEvents.Text = "Events";
			this.tabPageEvents.UseVisualStyleBackColor = true;
			// 
			// listBoxEvents
			// 
			this.listBoxEvents.FormattingEnabled = true;
			this.listBoxEvents.Location = new System.Drawing.Point(6, 25);
			this.listBoxEvents.Name = "listBoxEvents";
			this.listBoxEvents.Size = new System.Drawing.Size(540, 199);
			this.listBoxEvents.TabIndex = 0;
			// 
			// buttonRegisterEvent
			// 
			this.buttonRegisterEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
			this.buttonRegisterEvent.ForeColor = System.Drawing.Color.White;
			this.buttonRegisterEvent.Location = new System.Drawing.Point(6, 230);
			this.buttonRegisterEvent.Name = "buttonRegisterEvent";
			this.buttonRegisterEvent.Size = new System.Drawing.Size(120, 30);
			this.buttonRegisterEvent.TabIndex = 1;
			this.buttonRegisterEvent.Text = "Register for Event";
			this.buttonRegisterEvent.UseVisualStyleBackColor = false;
			this.buttonRegisterEvent.Click += new System.EventHandler(this.buttonRegisterEvent_Click);
			// 
			// labelEvents
			// 
			this.labelEvents.AutoSize = true;
			this.labelEvents.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.labelEvents.Location = new System.Drawing.Point(6, 6);
			this.labelEvents.Name = "labelEvents";
			this.labelEvents.Size = new System.Drawing.Size(50, 19);
			this.labelEvents.TabIndex = 2;
			this.labelEvents.Text = "Events";
			// 
			// tabPageAnnouncements
			// 
			this.tabPageAnnouncements.Controls.Add(this.listBoxAnnouncements);
			this.tabPageAnnouncements.Controls.Add(this.buttonReadAnnouncement);
			this.tabPageAnnouncements.Controls.Add(this.labelAnnouncements);
			this.tabPageAnnouncements.Location = new System.Drawing.Point(4, 22);
			this.tabPageAnnouncements.Name = "tabPageAnnouncements";
			this.tabPageAnnouncements.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAnnouncements.Size = new System.Drawing.Size(552, 274);
			this.tabPageAnnouncements.TabIndex = 1;
			this.tabPageAnnouncements.Text = "Announcements";
			this.tabPageAnnouncements.UseVisualStyleBackColor = true;
			// 
			// listBoxAnnouncements
			// 
			this.listBoxAnnouncements.FormattingEnabled = true;
			this.listBoxAnnouncements.Location = new System.Drawing.Point(6, 25);
			this.listBoxAnnouncements.Name = "listBoxAnnouncements";
			this.listBoxAnnouncements.Size = new System.Drawing.Size(540, 199);
			this.listBoxAnnouncements.TabIndex = 0;
			// 
			// buttonReadAnnouncement
			// 
			this.buttonReadAnnouncement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
			this.buttonReadAnnouncement.ForeColor = System.Drawing.Color.White;
			this.buttonReadAnnouncement.Location = new System.Drawing.Point(6, 230);
			this.buttonReadAnnouncement.Name = "buttonReadAnnouncement";
			this.buttonReadAnnouncement.Size = new System.Drawing.Size(120, 30);
			this.buttonReadAnnouncement.TabIndex = 1;
			this.buttonReadAnnouncement.Text = "Read Announcement";
			this.buttonReadAnnouncement.UseVisualStyleBackColor = false;
			this.buttonReadAnnouncement.Click += new System.EventHandler(this.buttonReadAnnouncement_Click);
			// 
			// labelAnnouncements
			// 
			this.labelAnnouncements.AutoSize = true;
			this.labelAnnouncements.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.labelAnnouncements.Location = new System.Drawing.Point(6, 6);
			this.labelAnnouncements.Name = "labelAnnouncements";
			this.labelAnnouncements.Size = new System.Drawing.Size(100, 19);
			this.labelAnnouncements.TabIndex = 2;
			this.labelAnnouncements.Text = "Announcements";
			// 
			// tabPageRecommendations
			// 
			this.tabPageRecommendations.Controls.Add(this.listBoxRecommendations);
			this.tabPageRecommendations.Controls.Add(this.labelRecommendations);
			this.tabPageRecommendations.Location = new System.Drawing.Point(4, 22);
			this.tabPageRecommendations.Name = "tabPageRecommendations";
			this.tabPageRecommendations.Size = new System.Drawing.Size(552, 274);
			this.tabPageRecommendations.TabIndex = 2;
			this.tabPageRecommendations.Text = "Recommendations";
			this.tabPageRecommendations.UseVisualStyleBackColor = true;
			// 
			// listBoxRecommendations
			// 
			this.listBoxRecommendations.FormattingEnabled = true;
			this.listBoxRecommendations.Location = new System.Drawing.Point(6, 25);
			this.listBoxRecommendations.Name = "listBoxRecommendations";
			this.listBoxRecommendations.Size = new System.Drawing.Size(540, 240);
			this.listBoxRecommendations.TabIndex = 0;
			// 
			// labelRecommendations
			// 
			this.labelRecommendations.AutoSize = true;
			this.labelRecommendations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.labelRecommendations.Location = new System.Drawing.Point(6, 6);
			this.labelRecommendations.Name = "labelRecommendations";
			this.labelRecommendations.Size = new System.Drawing.Size(110, 19);
			this.labelRecommendations.TabIndex = 1;
			this.labelRecommendations.Text = "Recommendations";
			// 
			// buttonViewRecommendations
			// 
			this.buttonViewRecommendations.Location = new System.Drawing.Point(12, 356);
			this.buttonViewRecommendations.Name = "buttonViewRecommendations";
			this.buttonViewRecommendations.Size = new System.Drawing.Size(150, 30);
			this.buttonViewRecommendations.TabIndex = 2;
			this.buttonViewRecommendations.Text = "View Recommendations";
			this.buttonViewRecommendations.UseVisualStyleBackColor = true;
			this.buttonViewRecommendations.Click += new System.EventHandler(this.buttonViewRecommendations_Click);
			// 
			// groupBoxSearch
			// 
			this.groupBoxSearch.Controls.Add(this.textBoxSearch);
			this.groupBoxSearch.Controls.Add(this.labelSearch);
			this.groupBoxSearch.Controls.Add(this.comboBoxCategory);
			this.groupBoxSearch.Controls.Add(this.labelCategory);
			this.groupBoxSearch.Controls.Add(this.comboBoxLocation);
			this.groupBoxSearch.Controls.Add(this.labelLocation);
			this.groupBoxSearch.Location = new System.Drawing.Point(12, 392);
			this.groupBoxSearch.Name = "groupBoxSearch";
			this.groupBoxSearch.Size = new System.Drawing.Size(560, 80);
			this.groupBoxSearch.TabIndex = 3;
			this.groupBoxSearch.TabStop = false;
			this.groupBoxSearch.Text = "Search & Filter";
			// 
			// textBoxSearch
			// 
			this.textBoxSearch.Location = new System.Drawing.Point(60, 20);
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new System.Drawing.Size(200, 20);
			this.textBoxSearch.TabIndex = 0;
			// 
			// labelSearch
			// 
			this.labelSearch.AutoSize = true;
			this.labelSearch.Location = new System.Drawing.Point(6, 23);
			this.labelSearch.Name = "labelSearch";
			this.labelSearch.Size = new System.Drawing.Size(44, 13);
			this.labelSearch.TabIndex = 1;
			this.labelSearch.Text = "Search:";
			// 
			// comboBoxCategory
			// 
			this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCategory.FormattingEnabled = true;
			this.comboBoxCategory.Location = new System.Drawing.Point(60, 46);
			this.comboBoxCategory.Name = "comboBoxCategory";
			this.comboBoxCategory.Size = new System.Drawing.Size(120, 21);
			this.comboBoxCategory.TabIndex = 2;
			// 
			// labelCategory
			// 
			this.labelCategory.AutoSize = true;
			this.labelCategory.Location = new System.Drawing.Point(6, 49);
			this.labelCategory.Name = "labelCategory";
			this.labelCategory.Size = new System.Drawing.Size(52, 13);
			this.labelCategory.TabIndex = 3;
			this.labelCategory.Text = "Category:";
			// 
			// comboBoxLocation
			// 
			this.comboBoxLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLocation.FormattingEnabled = true;
			this.comboBoxLocation.Location = new System.Drawing.Point(280, 46);
			this.comboBoxLocation.Name = "comboBoxLocation";
			this.comboBoxLocation.Size = new System.Drawing.Size(120, 21);
			this.comboBoxLocation.TabIndex = 4;
			// 
			// labelLocation
			// 
			this.labelLocation.AutoSize = true;
			this.labelLocation.Location = new System.Drawing.Point(220, 49);
			this.labelLocation.Name = "labelLocation";
			this.labelLocation.Size = new System.Drawing.Size(51, 13);
			this.labelLocation.TabIndex = 5;
			this.labelLocation.Text = "Location:";
			// 
			// groupBoxStatistics
			// 
			this.groupBoxStatistics.Controls.Add(this.labelEventStats);
			this.groupBoxStatistics.Controls.Add(this.labelAnnouncementStats);
			this.groupBoxStatistics.Controls.Add(this.labelSearchStats);
			this.groupBoxStatistics.Location = new System.Drawing.Point(12, 478);
			this.groupBoxStatistics.Name = "groupBoxStatistics";
			this.groupBoxStatistics.Size = new System.Drawing.Size(560, 60);
			this.groupBoxStatistics.TabIndex = 4;
			this.groupBoxStatistics.TabStop = false;
			this.groupBoxStatistics.Text = "Statistics";
			// 
			// labelEventStats
			// 
			this.labelEventStats.AutoSize = true;
			this.labelEventStats.Location = new System.Drawing.Point(6, 20);
			this.labelEventStats.Name = "labelEventStats";
			this.labelEventStats.Size = new System.Drawing.Size(35, 13);
			this.labelEventStats.TabIndex = 0;
			this.labelEventStats.Text = "Events: 0";
			// 
			// labelAnnouncementStats
			// 
			this.labelAnnouncementStats.AutoSize = true;
			this.labelAnnouncementStats.Location = new System.Drawing.Point(6, 37);
			this.labelAnnouncementStats.Name = "labelAnnouncementStats";
			this.labelAnnouncementStats.Size = new System.Drawing.Size(80, 13);
			this.labelAnnouncementStats.TabIndex = 1;
			this.labelAnnouncementStats.Text = "Announcements: 0";
			// 
			// labelSearchStats
			// 
			this.labelSearchStats.AutoSize = true;
			this.labelSearchStats.Location = new System.Drawing.Point(280, 20);
			this.labelSearchStats.Name = "labelSearchStats";
			this.labelSearchStats.Size = new System.Drawing.Size(50, 13);
			this.labelSearchStats.TabIndex = 2;
			this.labelSearchStats.Text = "Searches: 0";
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Location = new System.Drawing.Point(180, 356);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(75, 30);
			this.buttonRefresh.TabIndex = 5;
			this.buttonRefresh.Text = "Refresh";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(497, 544);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 30);
			this.buttonClose.TabIndex = 6;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// FormEngagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 586);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.groupBoxStatistics);
			this.Controls.Add(this.groupBoxSearch);
			this.Controls.Add(this.buttonViewRecommendations);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEngagement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Events & Announcements";
			this.tabControl.ResumeLayout(false);
			this.tabPageEvents.ResumeLayout(false);
			this.tabPageEvents.PerformLayout();
			this.tabPageAnnouncements.ResumeLayout(false);
			this.tabPageAnnouncements.PerformLayout();
			this.tabPageRecommendations.ResumeLayout(false);
			this.tabPageRecommendations.PerformLayout();
			this.groupBoxSearch.ResumeLayout(false);
			this.groupBoxSearch.PerformLayout();
			this.groupBoxStatistics.ResumeLayout(false);
			this.groupBoxStatistics.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.Label labelHeader;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageEvents;
		private System.Windows.Forms.ListBox listBoxEvents;
		private System.Windows.Forms.Button buttonRegisterEvent;
		private System.Windows.Forms.Label labelEvents;
		private System.Windows.Forms.TabPage tabPageAnnouncements;
		private System.Windows.Forms.ListBox listBoxAnnouncements;
		private System.Windows.Forms.Button buttonReadAnnouncement;
		private System.Windows.Forms.Label labelAnnouncements;
		private System.Windows.Forms.TabPage tabPageRecommendations;
		private System.Windows.Forms.ListBox listBoxRecommendations;
		private System.Windows.Forms.Label labelRecommendations;
		private System.Windows.Forms.Button buttonViewRecommendations;
		private System.Windows.Forms.GroupBox groupBoxSearch;
		private System.Windows.Forms.TextBox textBoxSearch;
		private System.Windows.Forms.Label labelSearch;
		private System.Windows.Forms.ComboBox comboBoxCategory;
		private System.Windows.Forms.Label labelCategory;
		private System.Windows.Forms.ComboBox comboBoxLocation;
		private System.Windows.Forms.Label labelLocation;
		private System.Windows.Forms.GroupBox groupBoxStatistics;
		private System.Windows.Forms.Label labelEventStats;
		private System.Windows.Forms.Label labelAnnouncementStats;
		private System.Windows.Forms.Label labelSearchStats;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button buttonClose;
	}
}


