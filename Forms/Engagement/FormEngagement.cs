using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Municipality_App.Models;
using Municipality_App.Services;

namespace Municipality_App.Forms.Engagement
{
    public partial class FormEngagement : MaterialForm
    {
        private List<Event> _currentEvents = new List<Event>();
        private List<Announcement> _currentAnnouncements = new List<Announcement>();
        private List<object> _recommendations = new List<object>();

        public FormEngagement()
        {
            InitializeComponent();
            ApplyMaterialTheme();
            LoadData();
            SetupEventHandlers();
            PopulateComboBoxes();
        }

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
            this.StartPosition = FormStartPosition.CenterParent;

            // Additional styling to prevent rendering artifacts
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void LoadData()
        {
            LoadEvents();
            LoadAnnouncements();
            LoadRecommendations();
            UpdateStatistics();
        }

        private void LoadEvents()
        {
            _currentEvents = EventService.GetUpcomingEvents();
            listBoxEvents.Items.Clear();

            foreach (var evt in _currentEvents)
            {
                listBoxEvents.Items.Add($"{evt.EventName} - {evt.EventDate:MMM dd, yyyy}");
            }
        }

        private void LoadAnnouncements()
        {
            _currentAnnouncements = AnnouncementService.GetRecentAnnouncements(30);
            listBoxAnnouncements.Items.Clear();

            foreach (var announcement in _currentAnnouncements)
            {
                listBoxAnnouncements.Items.Add(
                    $"{announcement.AnnouncementTitle} - {announcement.AnnouncementDate:MMM dd}"
                );
            }
        }

        private void LoadRecommendations()
        {
            _recommendations = RecommendationService.GetPersonalizedRecommendations();
            listBoxRecommendations.Items.Clear();

            foreach (var rec in _recommendations.Take(10))
            {
                if (rec is Event evt)
                {
                    listBoxRecommendations.Items.Add(
                        $"🎪 {evt.EventName} - {evt.EventDate:MMM dd}"
                    );
                }
                else if (rec is Announcement announcement)
                {
                    listBoxRecommendations.Items.Add(
                        $"📢 {announcement.AnnouncementTitle} - {announcement.AnnouncementDate:MMM dd}"
                    );
                }
            }
        }

        private void UpdateStatistics()
        {
            var eventStats = EventService.GetEventStatistics();
            var announcementStats = AnnouncementService.GetAnnouncementStatistics();
            var searchAnalytics = SearchService.GetSearchAnalytics();

            labelEventStats.Text =
                $"Events: {eventStats["Upcoming Events"]} upcoming, {eventStats["Total Registrations"]} registrations";
            labelAnnouncementStats.Text =
                $"Announcements: {announcementStats["Recent (7 days)"]} recent, {announcementStats["Categories"]} categories";
            labelSearchStats.Text =
                $"Searches: {searchAnalytics["Total Searches"]} total, {searchAnalytics["Search Success Rate"]:F1}% success rate";
        }

        private void SetupEventHandlers()
        {
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            comboBoxCategory.SelectedIndexChanged += ComboBoxCategory_SelectedIndexChanged;
            comboBoxLocation.SelectedIndexChanged += ComboBoxLocation_SelectedIndexChanged;
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            var searchQuery = textBoxSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchQuery))
            {
                LoadEvents();
                LoadAnnouncements();
                return;
            }

            // Track search
            var search = new UserSearch
            {
                SearchQuery = searchQuery,
                SearchCategory = "General",
                SearchLocation = "All",
                WasSuccessful = true,
            };
            SearchService.TrackSearch(search);

            // Search events
            var eventResults = EventService.SearchEvents(searchQuery);
            listBoxEvents.Items.Clear();
            foreach (var evt in eventResults)
            {
                listBoxEvents.Items.Add($"{evt.EventName} - {evt.EventDate:MMM dd, yyyy}");
            }

            // Search announcements
            var announcementResults = AnnouncementService.SearchAnnouncements(searchQuery);
            listBoxAnnouncements.Items.Clear();
            foreach (var announcement in announcementResults)
            {
                listBoxAnnouncements.Items.Add(
                    $"{announcement.AnnouncementTitle} - {announcement.AnnouncementDate:MMM dd}"
                );
            }
        }

        private void ComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCategory = comboBoxCategory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCategory) || selectedCategory == "All Categories")
            {
                LoadEvents();
                LoadAnnouncements();
                return;
            }

            // Filter events by category
            var categoryEvents = EventService.GetEventsByCategory(selectedCategory);
            listBoxEvents.Items.Clear();
            foreach (var evt in categoryEvents)
            {
                listBoxEvents.Items.Add($"{evt.EventName} - {evt.EventDate:MMM dd, yyyy}");
            }

            // Filter announcements by category
            var categoryAnnouncements = AnnouncementService.GetAnnouncementsByCategory(
                selectedCategory
            );
            listBoxAnnouncements.Items.Clear();
            foreach (var announcement in categoryAnnouncements)
            {
                listBoxAnnouncements.Items.Add(
                    $"{announcement.AnnouncementTitle} - {announcement.AnnouncementDate:MMM dd}"
                );
            }
        }

        private void ComboBoxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLocation = comboBoxLocation.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedLocation) || selectedLocation == "All Locations")
            {
                LoadEvents();
                LoadAnnouncements();
                return;
            }

            // Filter events by location
            var locationEvents = EventService.GetEventsByLocation(selectedLocation);
            listBoxEvents.Items.Clear();
            foreach (var evt in locationEvents)
            {
                listBoxEvents.Items.Add($"{evt.EventName} - {evt.EventDate:MMM dd, yyyy}");
            }

            // Filter announcements by location
            var locationAnnouncements = AnnouncementService.GetAnnouncementsByLocation(
                selectedLocation
            );
            listBoxAnnouncements.Items.Clear();
            foreach (var announcement in locationAnnouncements)
            {
                listBoxAnnouncements.Items.Add(
                    $"{announcement.AnnouncementTitle} - {announcement.AnnouncementDate:MMM dd}"
                );
            }
        }

        private void buttonRegisterEvent_Click(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Please select an event to register for.",
                    "No Event Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var selectedEvent = _currentEvents[listBoxEvents.SelectedIndex];

            // Simple registration dialog
            var userName = ShowInputDialog("Enter your name:", "Event Registration");
            if (string.IsNullOrEmpty(userName))
                return;

            var userEmail = ShowInputDialog("Enter your email:", "Event Registration");
            if (string.IsNullOrEmpty(userEmail))
                return;

            if (EventService.RegisterForEvent(selectedEvent.EventId, userName, userEmail))
            {
                GamificationService.AddPoints(
                    25,
                    "Registered for event",
                    "event_registration",
                    selectedEvent.EventId
                );
                MessageBox.Show(
                    $"Successfully registered for {selectedEvent.EventName}!",
                    "Registration Confirmed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                LoadData(); // Refresh data
            }
            else
            {
                MessageBox.Show(
                    "Registration failed. Please try again.",
                    "Registration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void buttonReadAnnouncement_Click(object sender, EventArgs e)
        {
            if (listBoxAnnouncements.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Please select an announcement to read.",
                    "No Announcement Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var selectedAnnouncement = _currentAnnouncements[listBoxAnnouncements.SelectedIndex];

            // Mark as read
            AnnouncementService.MarkAnnouncementAsRead(selectedAnnouncement.AnnouncementId);

            // Show announcement details
            var details =
                $"Title: {selectedAnnouncement.AnnouncementTitle}\n\n"
                + $"Description: {selectedAnnouncement.AnnouncementDescription}\n\n"
                + $"Category: {selectedAnnouncement.AnnouncementCategory}\n"
                + $"Location: {selectedAnnouncement.AnnouncementLocation}\n"
                + $"Date: {selectedAnnouncement.AnnouncementDate:MMM dd, yyyy}";

            MessageBox.Show(
                details,
                "Announcement Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            GamificationService.AddPoints(5, "Read announcement", "announcement_read");
            LoadData(); // Refresh data
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonViewRecommendations_Click(object sender, EventArgs e)
        {
            LoadRecommendations();
            tabControl.SelectedTab = tabPageRecommendations;
        }

        private void PopulateComboBoxes()
        {
            // Populate category combo box
            comboBoxCategory.Items.Clear();
            comboBoxCategory.Items.Add("All Categories");

            var eventCategories = new[]
            {
                "Community Service",
                "Government",
                "Education",
                "Sports",
                "Social",
            };
            var announcementCategories = AnnouncementService.GetAnnouncementCategories();
            var allCategories = eventCategories
                .Union(announcementCategories)
                .Distinct()
                .OrderBy(c => c);

            foreach (var category in allCategories)
            {
                comboBoxCategory.Items.Add(category);
            }
            comboBoxCategory.SelectedIndex = 0;

            // Populate location combo box
            comboBoxLocation.Items.Clear();
            comboBoxLocation.Items.Add("All Locations");
            comboBoxLocation.Items.Add("Central Park");
            comboBoxLocation.Items.Add("Town Hall");
            comboBoxLocation.Items.Add("Community Center");
            comboBoxLocation.Items.Add("Sports Complex");
            comboBoxLocation.Items.Add("Senior Center");
            comboBoxLocation.Items.Add("Main Street");
            comboBoxLocation.Items.Add("Downtown Area");
            comboBoxLocation.Items.Add("City Wide");
            comboBoxLocation.Items.Add("Municipal Library");
            comboBoxLocation.SelectedIndex = 0;
        }

        private string ShowInputDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
            };

            Label textLabel = new Label()
            {
                Left = 20,
                Top = 20,
                Text = text,
                Width = 350,
            };
            TextBox textBox = new TextBox()
            {
                Left = 20,
                Top = 50,
                Width = 350,
            };
            Button confirmation = new Button()
            {
                Text = "OK",
                Left = 250,
                Width = 100,
                Top = 80,
                DialogResult = DialogResult.OK,
            };
            Button cancel = new Button()
            {
                Text = "Cancel",
                Left = 150,
                Width = 100,
                Top = 80,
                DialogResult = DialogResult.Cancel,
            };

            confirmation.Click += (sender, e) =>
            {
                prompt.Close();
            };
            cancel.Click += (sender, e) =>
            {
                prompt.Close();
            };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void FormEngagement_Load(object sender, EventArgs e) { }
    }
}
