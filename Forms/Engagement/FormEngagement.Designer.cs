using MaterialSkin;
using MaterialSkin.Controls;

namespace Municipality_App.Forms.Engagement
{
	partial class FormEngagement : MaterialForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageEvents = new System.Windows.Forms.TabPage();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.labelEvents = new MaterialSkin.Controls.MaterialLabel();
            this.tabPageAnnouncements = new System.Windows.Forms.TabPage();
            this.listBoxAnnouncements = new System.Windows.Forms.ListBox();
            this.labelAnnouncements = new MaterialSkin.Controls.MaterialLabel();
            this.tabPageRecommendations = new System.Windows.Forms.TabPage();
            this.listBoxRecommendations = new System.Windows.Forms.ListBox();
            this.labelRecommendations = new MaterialSkin.Controls.MaterialLabel();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.textBoxSearch = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.labelSearch = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelCategory = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxLocation = new System.Windows.Forms.ComboBox();
            this.labelLocation = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelDateFrom = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelDateTo = new MaterialSkin.Controls.MaterialLabel();
            this.buttonRefresh = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonClose = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonViewRecommendations = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonShare = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonJoinChallenge = new MaterialSkin.Controls.MaterialRaisedButton();
            this.labelSearchStats = new MaterialSkin.Controls.MaterialLabel();
            this.labelAnnouncementStats = new MaterialSkin.Controls.MaterialLabel();
            this.labelEventStats = new MaterialSkin.Controls.MaterialLabel();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.tabControl.SuspendLayout();
            this.tabPageEvents.SuspendLayout();
            this.tabPageAnnouncements.SuspendLayout();
            this.tabPageRecommendations.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageEvents);
            this.tabControl.Controls.Add(this.tabPageAnnouncements);
            this.tabControl.Controls.Add(this.tabPageRecommendations);
            this.tabControl.Location = new System.Drawing.Point(1, 64);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(571, 286);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageEvents
            // 
            this.tabPageEvents.Controls.Add(this.listBoxEvents);
            this.tabPageEvents.Controls.Add(this.labelEvents);
            this.tabPageEvents.Location = new System.Drawing.Point(4, 22);
            this.tabPageEvents.Name = "tabPageEvents";
            this.tabPageEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEvents.Size = new System.Drawing.Size(563, 260);
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
            // labelEvents
            // 
            this.labelEvents.AutoSize = true;
            this.labelEvents.Depth = 0;
            this.labelEvents.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelEvents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelEvents.Location = new System.Drawing.Point(6, 6);
            this.labelEvents.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelEvents.Name = "labelEvents";
            this.labelEvents.Size = new System.Drawing.Size(54, 19);
            this.labelEvents.TabIndex = 2;
            this.labelEvents.Text = "Events";
            // 
            // tabPageAnnouncements
            // 
            this.tabPageAnnouncements.Controls.Add(this.listBoxAnnouncements);
            this.tabPageAnnouncements.Controls.Add(this.labelAnnouncements);
            this.tabPageAnnouncements.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnnouncements.Name = "tabPageAnnouncements";
            this.tabPageAnnouncements.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnnouncements.Size = new System.Drawing.Size(563, 260);
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
            // labelAnnouncements
            // 
            this.labelAnnouncements.AutoSize = true;
            this.labelAnnouncements.Depth = 0;
            this.labelAnnouncements.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelAnnouncements.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelAnnouncements.Location = new System.Drawing.Point(6, 6);
            this.labelAnnouncements.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelAnnouncements.Name = "labelAnnouncements";
            this.labelAnnouncements.Size = new System.Drawing.Size(118, 19);
            this.labelAnnouncements.TabIndex = 2;
            this.labelAnnouncements.Text = "Announcements";
            // 
            // tabPageRecommendations
            // 
            this.tabPageRecommendations.Controls.Add(this.listBoxRecommendations);
            this.tabPageRecommendations.Controls.Add(this.labelRecommendations);
            this.tabPageRecommendations.Location = new System.Drawing.Point(4, 22);
            this.tabPageRecommendations.Name = "tabPageRecommendations";
            this.tabPageRecommendations.Size = new System.Drawing.Size(563, 260);
            this.tabPageRecommendations.TabIndex = 2;
            this.tabPageRecommendations.Text = "Recommendations";
            this.tabPageRecommendations.UseVisualStyleBackColor = true;
            // 
            // listBoxRecommendations
            // 
            this.listBoxRecommendations.FormattingEnabled = true;
            this.listBoxRecommendations.Location = new System.Drawing.Point(7, 28);
            this.listBoxRecommendations.Name = "listBoxRecommendations";
            this.listBoxRecommendations.Size = new System.Drawing.Size(540, 199);
            this.listBoxRecommendations.TabIndex = 0;
            // 
            // labelRecommendations
            // 
            this.labelRecommendations.AutoSize = true;
            this.labelRecommendations.Depth = 0;
            this.labelRecommendations.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelRecommendations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelRecommendations.Location = new System.Drawing.Point(6, 6);
            this.labelRecommendations.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelRecommendations.Name = "labelRecommendations";
            this.labelRecommendations.Size = new System.Drawing.Size(135, 19);
            this.labelRecommendations.TabIndex = 1;
            this.labelRecommendations.Text = "Recommendations";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.textBoxSearch);
            this.groupBoxSearch.Controls.Add(this.labelSearch);
            this.groupBoxSearch.Controls.Add(this.comboBoxCategory);
            this.groupBoxSearch.Controls.Add(this.labelCategory);
            this.groupBoxSearch.Controls.Add(this.comboBoxLocation);
            this.groupBoxSearch.Controls.Add(this.labelLocation);
            this.groupBoxSearch.Controls.Add(this.dateTimePickerFrom);
            this.groupBoxSearch.Controls.Add(this.labelDateFrom);
            this.groupBoxSearch.Controls.Add(this.dateTimePickerTo);
            this.groupBoxSearch.Controls.Add(this.labelDateTo);
            this.groupBoxSearch.Location = new System.Drawing.Point(12, 392);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(560, 120);
            this.groupBoxSearch.TabIndex = 3;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search & Filter";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Depth = 0;
            this.textBoxSearch.Hint = "";
            this.textBoxSearch.Location = new System.Drawing.Point(60, 20);
            this.textBoxSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PasswordChar = '\0';
            this.textBoxSearch.SelectedText = "";
            this.textBoxSearch.SelectionLength = 0;
            this.textBoxSearch.SelectionStart = 0;
            this.textBoxSearch.Size = new System.Drawing.Size(200, 23);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.UseSystemPasswordChar = false;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Depth = 0;
            this.labelSearch.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSearch.Location = new System.Drawing.Point(6, 23);
            this.labelSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(59, 19);
            this.labelSearch.TabIndex = 1;
            this.labelSearch.Text = "Search:";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(85, 50);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(120, 21);
            this.comboBoxCategory.TabIndex = 2;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Depth = 0;
            this.labelCategory.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCategory.Location = new System.Drawing.Point(6, 49);
            this.labelCategory.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(73, 19);
            this.labelCategory.TabIndex = 3;
            this.labelCategory.Text = "Category:";
            // 
            // comboBoxLocation
            // 
            this.comboBoxLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocation.FormattingEnabled = true;
            this.comboBoxLocation.Location = new System.Drawing.Point(436, 53);
            this.comboBoxLocation.Name = "comboBoxLocation";
            this.comboBoxLocation.Size = new System.Drawing.Size(120, 21);
            this.comboBoxLocation.TabIndex = 4;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Depth = 0;
            this.labelLocation.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelLocation.Location = new System.Drawing.Point(358, 55);
            this.labelLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(72, 19);
            this.labelLocation.TabIndex = 5;
            this.labelLocation.Text = "Location:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(85, 80);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerFrom.TabIndex = 6;
            // 
            // labelDateFrom
            // 
            this.labelDateFrom.AutoSize = true;
            this.labelDateFrom.Depth = 0;
            this.labelDateFrom.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelDateFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDateFrom.Location = new System.Drawing.Point(6, 80);
            this.labelDateFrom.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelDateFrom.Name = "labelDateFrom";
            this.labelDateFrom.Size = new System.Drawing.Size(48, 19);
            this.labelDateFrom.TabIndex = 7;
            this.labelDateFrom.Text = "From:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(280, 80);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerTo.TabIndex = 8;
            // 
            // labelDateTo
            // 
            this.labelDateTo.AutoSize = true;
            this.labelDateTo.Depth = 0;
            this.labelDateTo.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelDateTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDateTo.Location = new System.Drawing.Point(200, 80);
            this.labelDateTo.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelDateTo.Name = "labelDateTo";
            this.labelDateTo.Size = new System.Drawing.Size(31, 19);
            this.labelDateTo.TabIndex = 9;
            this.labelDateTo.Text = "To:";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Depth = 0;
            this.buttonRefresh.Location = new System.Drawing.Point(476, 356);
            this.buttonRefresh.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Primary = true;
            this.buttonRefresh.Size = new System.Drawing.Size(75, 30);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Depth = 0;
            this.buttonClose.Location = new System.Drawing.Point(497, 584);
            this.buttonClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Primary = true;
            this.buttonClose.Size = new System.Drawing.Size(75, 30);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonViewRecommendations
            // 
            this.buttonViewRecommendations.Depth = 0;
            this.buttonViewRecommendations.Location = new System.Drawing.Point(12, 356);
            this.buttonViewRecommendations.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonViewRecommendations.Name = "buttonViewRecommendations";
            this.buttonViewRecommendations.Primary = true;
            this.buttonViewRecommendations.Size = new System.Drawing.Size(226, 30);
            this.buttonViewRecommendations.TabIndex = 2;
            this.buttonViewRecommendations.Text = "View Recommendations";
            this.buttonViewRecommendations.UseVisualStyleBackColor = true;
            this.buttonViewRecommendations.Click += new System.EventHandler(this.buttonViewRecommendations_Click);
            // 
            // buttonShare
            // 
            this.buttonShare.Depth = 0;
            this.buttonShare.Location = new System.Drawing.Point(244, 356);
            this.buttonShare.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonShare.Name = "buttonShare";
            this.buttonShare.Primary = true;
            this.buttonShare.Size = new System.Drawing.Size(100, 30);
            this.buttonShare.TabIndex = 7;
            this.buttonShare.Text = "Share";
            this.buttonShare.UseVisualStyleBackColor = true;
            this.buttonShare.Click += new System.EventHandler(this.buttonShare_Click);
            // 
            // buttonJoinChallenge
            // 
            this.buttonJoinChallenge.Depth = 0;
            this.buttonJoinChallenge.Location = new System.Drawing.Point(350, 356);
            this.buttonJoinChallenge.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonJoinChallenge.Name = "buttonJoinChallenge";
            this.buttonJoinChallenge.Primary = true;
            this.buttonJoinChallenge.Size = new System.Drawing.Size(120, 30);
            this.buttonJoinChallenge.TabIndex = 8;
            this.buttonJoinChallenge.Text = "Challenges";
            this.buttonJoinChallenge.UseVisualStyleBackColor = true;
            this.buttonJoinChallenge.Click += new System.EventHandler(this.buttonJoinChallenge_Click);
            // 
            // labelSearchStats
            // 
            this.labelSearchStats.AutoSize = true;
            this.labelSearchStats.Depth = 0;
            this.labelSearchStats.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelSearchStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSearchStats.Location = new System.Drawing.Point(280, 20);
            this.labelSearchStats.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelSearchStats.Name = "labelSearchStats";
            this.labelSearchStats.Size = new System.Drawing.Size(87, 19);
            this.labelSearchStats.TabIndex = 2;
            this.labelSearchStats.Text = "Searches: 0";
            // 
            // labelAnnouncementStats
            // 
            this.labelAnnouncementStats.AutoSize = true;
            this.labelAnnouncementStats.Depth = 0;
            this.labelAnnouncementStats.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelAnnouncementStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelAnnouncementStats.Location = new System.Drawing.Point(6, 37);
            this.labelAnnouncementStats.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelAnnouncementStats.Name = "labelAnnouncementStats";
            this.labelAnnouncementStats.Size = new System.Drawing.Size(134, 19);
            this.labelAnnouncementStats.TabIndex = 1;
            this.labelAnnouncementStats.Text = "Announcements: 0";
            // 
            // labelEventStats
            // 
            this.labelEventStats.AutoSize = true;
            this.labelEventStats.Depth = 0;
            this.labelEventStats.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelEventStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelEventStats.Location = new System.Drawing.Point(6, 20);
            this.labelEventStats.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelEventStats.Name = "labelEventStats";
            this.labelEventStats.Size = new System.Drawing.Size(70, 19);
            this.labelEventStats.TabIndex = 0;
            this.labelEventStats.Text = "Events: 0";
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Controls.Add(this.labelEventStats);
            this.groupBoxStatistics.Controls.Add(this.labelAnnouncementStats);
            this.groupBoxStatistics.Controls.Add(this.labelSearchStats);
            this.groupBoxStatistics.Location = new System.Drawing.Point(12, 518);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(560, 60);
            this.groupBoxStatistics.TabIndex = 4;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "Statistics";
            // 
            // FormEngagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 635);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.groupBoxStatistics);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.buttonJoinChallenge);
            this.Controls.Add(this.buttonShare);
            this.Controls.Add(this.buttonViewRecommendations);
            this.Controls.Add(this.tabControl);
            this.Name = "FormEngagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Events & Announcements";
            this.Load += new System.EventHandler(this.FormEngagement_Load);
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

		}
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageEvents;
		private System.Windows.Forms.ListBox listBoxEvents;
		private MaterialSkin.Controls.MaterialLabel labelEvents;
		private System.Windows.Forms.TabPage tabPageAnnouncements;
		private System.Windows.Forms.ListBox listBoxAnnouncements;
		private MaterialSkin.Controls.MaterialLabel labelAnnouncements;
		private System.Windows.Forms.TabPage tabPageRecommendations;
		private System.Windows.Forms.ListBox listBoxRecommendations;
		private MaterialSkin.Controls.MaterialLabel labelRecommendations;
		private System.Windows.Forms.GroupBox groupBoxSearch;
		private MaterialSkin.Controls.MaterialSingleLineTextField textBoxSearch;
		private MaterialSkin.Controls.MaterialLabel labelSearch;
		private System.Windows.Forms.ComboBox comboBoxCategory;
		private MaterialSkin.Controls.MaterialLabel labelCategory;
		private MaterialSkin.Controls.MaterialLabel labelLocation;
		private System.Windows.Forms.ComboBox comboBoxLocation;
		private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
		private MaterialSkin.Controls.MaterialLabel labelDateFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerTo;
		private MaterialSkin.Controls.MaterialLabel labelDateTo;
		private MaterialSkin.Controls.MaterialRaisedButton buttonRefresh;
		private MaterialSkin.Controls.MaterialRaisedButton buttonClose;
        private MaterialRaisedButton buttonViewRecommendations;
        private MaterialRaisedButton buttonShare;
        private MaterialRaisedButton buttonJoinChallenge;
        private MaterialLabel labelSearchStats;
        private MaterialLabel labelAnnouncementStats;
        private MaterialLabel labelEventStats;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
    }
}