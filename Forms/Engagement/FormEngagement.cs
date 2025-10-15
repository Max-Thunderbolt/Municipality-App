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
            ConfigureFormStyles();
            LoadData();
            SetupEventHandlers();
            PopulateComboBoxes();
        }

        // Configure form styles for better rendering
        private void ConfigureFormStyles()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void ApplyMaterialTheme()
        {
            ThemeService.ApplyTheme(this, isMainForm: false);

            // Configure responsive layout
            var optimalSize = ThemeService.ResponsiveLayout.GetOptimalFormSize(
                ThemeService.FormSizes.EngagementForm
            );
            this.Size = optimalSize;
        }

        private void LoadData()
        {
            LoadEvents();
            LoadAnnouncements();
            LoadRecommendations();
            UpdateStatistics();
            UpdateAdaptiveButton(); // Set initial button text
            InitializeDatePickers();
        }

        private void InitializeDatePickers()
        {
            // Set default date range to last 30 days
            dateTimePickerFrom.Value = DateTime.Now.AddDays(-30);
            dateTimePickerTo.Value = DateTime.Now.AddDays(30);
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
            dateTimePickerFrom.ValueChanged += DateTimePickerFrom_ValueChanged;
            dateTimePickerTo.ValueChanged += DateTimePickerTo_ValueChanged;
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            listBoxRecommendations.SelectedIndexChanged +=
                ListBoxRecommendations_SelectedIndexChanged;
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            var searchQuery = textBoxSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchQuery))
            {
                ApplyDateFilter(); // Use date filter instead of loading all
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

            // Get date range
            var fromDate = dateTimePickerFrom.Value.Date;
            var toDate = dateTimePickerTo.Value.Date;

            // Search events with date filter
            var eventResults = EventService
                .SearchEvents(searchQuery)
                .Where(evt => evt.EventDate.Date >= fromDate && evt.EventDate.Date <= toDate)
                .ToList();
            listBoxEvents.Items.Clear();
            foreach (var evt in eventResults)
            {
                listBoxEvents.Items.Add($"{evt.EventName} - {evt.EventDate:MMM dd, yyyy}");
            }

            // Search announcements with date filter
            var announcementResults = AnnouncementService
                .SearchAnnouncements(searchQuery)
                .Where(ann =>
                    ann.AnnouncementDate.Date >= fromDate && ann.AnnouncementDate.Date <= toDate
                )
                .ToList();
            listBoxAnnouncements.Items.Clear();
            foreach (var announcement in announcementResults)
            {
                listBoxAnnouncements.Items.Add(
                    $"{announcement.AnnouncementTitle} - {announcement.AnnouncementDate:MMM dd}"
                );
            }

            // Search recommendations with date filter
            SearchRecommendations(searchQuery);
        }

        private void SearchRecommendations(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                ApplyDateFilter(); // Use date filter instead of loading all
                return;
            }

            // Get date range
            var fromDate = dateTimePickerFrom.Value.Date;
            var toDate = dateTimePickerTo.Value.Date;

            // Filter recommendations based on search query and date range
            var filteredRecommendations = _recommendations
                .Where(rec =>
                {
                    bool matchesSearch = false;
                    bool matchesDate = false;

                    if (rec is Event evt)
                    {
                        matchesSearch =
                            evt.EventName.ToLower().Contains(searchQuery.ToLower())
                            || evt.EventDescription.ToLower().Contains(searchQuery.ToLower())
                            || evt.EventLocation.ToLower().Contains(searchQuery.ToLower())
                            || evt.EventCategory.ToLower().Contains(searchQuery.ToLower());
                        matchesDate =
                            evt.EventDate.Date >= fromDate && evt.EventDate.Date <= toDate;
                    }
                    else if (rec is Announcement announcement)
                    {
                        matchesSearch =
                            announcement.AnnouncementTitle.ToLower().Contains(searchQuery.ToLower())
                            || announcement
                                .AnnouncementDescription.ToLower()
                                .Contains(searchQuery.ToLower())
                            || announcement
                                .AnnouncementLocation.ToLower()
                                .Contains(searchQuery.ToLower())
                            || announcement
                                .AnnouncementCategory.ToLower()
                                .Contains(searchQuery.ToLower());
                        matchesDate =
                            announcement.AnnouncementDate.Date >= fromDate
                            && announcement.AnnouncementDate.Date <= toDate;
                    }
                    return matchesSearch && matchesDate;
                })
                .ToList();

            // Update recommendations listbox
            listBoxRecommendations.Items.Clear();
            foreach (var rec in filteredRecommendations.Take(10))
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

        private void ComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCategory = comboBoxCategory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCategory) || selectedCategory == "All Categories")
            {
                ApplyDateFilter(); // Use date filter instead of loading all
                return;
            }

            // Get date range
            var fromDate = dateTimePickerFrom.Value.Date;
            var toDate = dateTimePickerTo.Value.Date;

            // Filter events by category and date
            var categoryEvents = EventService
                .GetEventsByCategory(selectedCategory)
                .Where(evt => evt.EventDate.Date >= fromDate && evt.EventDate.Date <= toDate)
                .ToList();
            listBoxEvents.Items.Clear();
            foreach (var evt in categoryEvents)
            {
                listBoxEvents.Items.Add($"{evt.EventName} - {evt.EventDate:MMM dd, yyyy}");
            }

            // Filter announcements by category and date
            var categoryAnnouncements = AnnouncementService
                .GetAnnouncementsByCategory(selectedCategory)
                .Where(ann =>
                    ann.AnnouncementDate.Date >= fromDate && ann.AnnouncementDate.Date <= toDate
                )
                .ToList();
            listBoxAnnouncements.Items.Clear();
            foreach (var announcement in categoryAnnouncements)
            {
                listBoxAnnouncements.Items.Add(
                    $"{announcement.AnnouncementTitle} - {announcement.AnnouncementDate:MMM dd}"
                );
            }

            // Filter recommendations by category and date
            FilterRecommendationsByCategory(selectedCategory);
        }

        private void ComboBoxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLocation = comboBoxLocation.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedLocation) || selectedLocation == "All Locations")
            {
                ApplyDateFilter(); // Use date filter instead of loading all
                return;
            }

            // Get date range
            var fromDate = dateTimePickerFrom.Value.Date;
            var toDate = dateTimePickerTo.Value.Date;

            // Filter events by location and date
            var locationEvents = EventService
                .GetEventsByLocation(selectedLocation)
                .Where(evt => evt.EventDate.Date >= fromDate && evt.EventDate.Date <= toDate)
                .ToList();
            listBoxEvents.Items.Clear();
            foreach (var evt in locationEvents)
            {
                listBoxEvents.Items.Add($"{evt.EventName} - {evt.EventDate:MMM dd, yyyy}");
            }

            // Filter announcements by location and date
            var locationAnnouncements = AnnouncementService
                .GetAnnouncementsByLocation(selectedLocation)
                .Where(ann =>
                    ann.AnnouncementDate.Date >= fromDate && ann.AnnouncementDate.Date <= toDate
                )
                .ToList();
            listBoxAnnouncements.Items.Clear();
            foreach (var announcement in locationAnnouncements)
            {
                listBoxAnnouncements.Items.Add(
                    $"{announcement.AnnouncementTitle} - {announcement.AnnouncementDate:MMM dd}"
                );
            }

            // Filter recommendations by location and date
            FilterRecommendationsByLocation(selectedLocation);
        }

        private void FilterRecommendationsByCategory(string selectedCategory)
        {
            // Get date range
            var fromDate = dateTimePickerFrom.Value.Date;
            var toDate = dateTimePickerTo.Value.Date;

            var filteredRecommendations = _recommendations
                .Where(rec =>
                {
                    bool matchesCategory = false;
                    bool matchesDate = false;

                    if (rec is Event evt)
                    {
                        matchesCategory = evt
                            .EventCategory.ToLower()
                            .Equals(selectedCategory.ToLower());
                        matchesDate =
                            evt.EventDate.Date >= fromDate && evt.EventDate.Date <= toDate;
                    }
                    else if (rec is Announcement announcement)
                    {
                        matchesCategory = announcement
                            .AnnouncementCategory.ToLower()
                            .Equals(selectedCategory.ToLower());
                        matchesDate =
                            announcement.AnnouncementDate.Date >= fromDate
                            && announcement.AnnouncementDate.Date <= toDate;
                    }
                    return matchesCategory && matchesDate;
                })
                .ToList();

            // Update recommendations listbox
            listBoxRecommendations.Items.Clear();
            foreach (var rec in filteredRecommendations.Take(10))
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

        private void FilterRecommendationsByLocation(string selectedLocation)
        {
            // Get date range
            var fromDate = dateTimePickerFrom.Value.Date;
            var toDate = dateTimePickerTo.Value.Date;

            var filteredRecommendations = _recommendations
                .Where(rec =>
                {
                    bool matchesLocation = false;
                    bool matchesDate = false;

                    if (rec is Event evt)
                    {
                        matchesLocation = evt
                            .EventLocation.ToLower()
                            .Equals(selectedLocation.ToLower());
                        matchesDate =
                            evt.EventDate.Date >= fromDate && evt.EventDate.Date <= toDate;
                    }
                    else if (rec is Announcement announcement)
                    {
                        matchesLocation = announcement
                            .AnnouncementLocation.ToLower()
                            .Equals(selectedLocation.ToLower());
                        matchesDate =
                            announcement.AnnouncementDate.Date >= fromDate
                            && announcement.AnnouncementDate.Date <= toDate;
                    }
                    return matchesLocation && matchesDate;
                })
                .ToList();

            // Update recommendations listbox
            listBoxRecommendations.Items.Clear();
            foreach (var rec in filteredRecommendations.Take(10))
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

        private void buttonRegisterEvent_Click(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedIndex < 0)
            {
                FeedbackService.ShowWarning(
                    "Please select an event to register for.",
                    "No Event Selected"
                );
                return;
            }

            var selectedEvent = _currentEvents[listBoxEvents.SelectedIndex];

            // Enhanced registration dialog with validation
            var userName = ShowInputDialog("Enter your name:", "Event Registration");
            if (string.IsNullOrEmpty(userName))
            {
                FeedbackService.ShowWarning(
                    "Name is required for registration.",
                    "Missing Information"
                );
                return;
            }

            var userEmail = ShowInputDialog("Enter your email:", "Event Registration");
            if (string.IsNullOrEmpty(userEmail))
            {
                FeedbackService.ShowWarning(
                    "Email is required for registration.",
                    "Missing Information"
                );
                return;
            }

            // Validate email format
            if (!IsValidEmail(userEmail))
            {
                FeedbackService.ShowError("Please enter a valid email address.", "Invalid Email");
                return;
            }

            // Show progress for registration
            using (
                var progress = FeedbackService.ShowProgress(
                    "Registering...",
                    "Processing your registration..."
                )
            )
            {
                if (EventService.RegisterForEvent(selectedEvent.EventId, userName, userEmail))
                {
                    GamificationService.AddPoints(
                        25,
                        "Registered for event",
                        "event_registration",
                        selectedEvent.EventId
                    );

                    // Record form completion for engagement tracking
                    GamificationService.RecordFormCompletion("event_registration");

                    FeedbackService.ShowSuccess(
                        $"Successfully registered for {selectedEvent.EventName}!\n\n"
                            + $"You will receive a confirmation email at {userEmail}.\n\n"
                            + $"You earned 25 points for registering!",
                        "Registration Confirmed"
                    );
                    LoadData(); // Refresh data
                }
                else
                {
                    FeedbackService.ShowError(
                        "Registration failed. This event may be full or no longer available.\nPlease try again or contact support.",
                        "Registration Error"
                    );
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void buttonReadAnnouncement_Click(object sender, EventArgs e)
        {
            if (listBoxAnnouncements.SelectedIndex < 0)
            {
                FeedbackService.ShowWarning(
                    "Please select an announcement to read.",
                    "No Announcement Selected"
                );
                return;
            }

            var selectedAnnouncement = _currentAnnouncements[listBoxAnnouncements.SelectedIndex];

            // Mark as read
            AnnouncementService.MarkAnnouncementAsRead(selectedAnnouncement.AnnouncementId);

            // Show announcement details in a formatted dialog
            var details =
                $"Title: {selectedAnnouncement.AnnouncementTitle}\n\n"
                + $"Description:\n{selectedAnnouncement.AnnouncementDescription}\n\n"
                + $"Category: {selectedAnnouncement.AnnouncementCategory}\n"
                + $"Location: {selectedAnnouncement.AnnouncementLocation}\n"
                + $"Date: {selectedAnnouncement.AnnouncementDate:MMMM dd, yyyy 'at' HH:mm}";

            FeedbackService.ShowDetails("Announcement Details", details);

            // Award points and show feedback
            GamificationService.AddPoints(5, "Read announcement", "announcement_read");
            GamificationService.RecordFormCompletion("announcement_read");
            FeedbackService.ShowToast(
                "You earned 5 points for reading this announcement!",
                ToastType.Success
            );

            LoadData(); // Refresh data
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonJoinChallenge_Click(object sender, EventArgs e)
        {
            ShowCommunityChallengesDialog();
        }

        private void ShowCommunityChallengesDialog()
        {
            var challenges = GamificationService.GetActiveChallenges();
            var profile = GamificationService.GetProfile();

            var challengeForm = new Form()
            {
                Text = "Community Challenges",
                Size = new System.Drawing.Size(500, 400),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
            };

            var labelTitle = new Label()
            {
                Text = "Join Community Challenges:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(450, 20),
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
            };

            var listBoxChallenges = new ListBox()
            {
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(450, 250),
                SelectionMode = SelectionMode.One,
            };

            foreach (var challenge in challenges)
            {
                var isParticipated = profile.ParticipatedChallenges.Any(pc =>
                    pc.Id == challenge.Id
                );
                var status = isParticipated ? "✓ Participated" : "Available";
                listBoxChallenges.Items.Add(
                    $"{challenge.Title} ({challenge.PointsReward} pts) - {status}"
                );
            }

            var buttonJoin = new Button()
            {
                Text = "Join Challenge",
                Location = new System.Drawing.Point(20, 320),
                Size = new System.Drawing.Size(100, 30),
                Enabled = false,
            };

            var buttonClose = new Button()
            {
                Text = "Close",
                Location = new System.Drawing.Point(370, 320),
                Size = new System.Drawing.Size(100, 30),
                DialogResult = DialogResult.OK,
            };

            listBoxChallenges.SelectedIndexChanged += (s, ev) =>
            {
                buttonJoin.Enabled = listBoxChallenges.SelectedIndex >= 0;
            };

            buttonJoin.Click += (s, ev) =>
            {
                if (listBoxChallenges.SelectedIndex >= 0)
                {
                    var selectedChallenge = challenges[listBoxChallenges.SelectedIndex];
                    var isAlreadyParticipated = profile.ParticipatedChallenges.Any(pc =>
                        pc.Id == selectedChallenge.Id
                    );

                    if (!isAlreadyParticipated)
                    {
                        GamificationService.ParticipateInChallenge(selectedChallenge.Id);
                        FeedbackService.ShowSuccess(
                            $"You joined the '{selectedChallenge.Title}' challenge!\nYou earned {selectedChallenge.PointsReward} points!",
                            "Challenge Joined"
                        );
                        challengeForm.Close();
                    }
                    else
                    {
                        FeedbackService.ShowWarning(
                            "You have already participated in this challenge!",
                            "Already Participated"
                        );
                    }
                }
            };

            challengeForm.Controls.AddRange(
                new Control[] { labelTitle, listBoxChallenges, buttonJoin, buttonClose }
            );
            challengeForm.ShowDialog();
        }

        private void DateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyDateFilter();
        }

        private void DateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyDateFilter();
        }

        private void ApplyDateFilter()
        {
            var fromDate = dateTimePickerFrom.Value.Date;
            var toDate = dateTimePickerTo.Value.Date;

            // Ensure to date is not before from date
            if (toDate < fromDate)
            {
                dateTimePickerTo.Value = fromDate;
                toDate = fromDate;
            }

            // Filter events by date range
            var filteredEvents = _currentEvents
                .Where(evt => evt.EventDate.Date >= fromDate && evt.EventDate.Date <= toDate)
                .ToList();

            listBoxEvents.Items.Clear();
            foreach (var evt in filteredEvents)
            {
                listBoxEvents.Items.Add($"{evt.EventName} - {evt.EventDate:MMM dd, yyyy}");
            }

            // Filter announcements by date range
            var filteredAnnouncements = _currentAnnouncements
                .Where(ann =>
                    ann.AnnouncementDate.Date >= fromDate && ann.AnnouncementDate.Date <= toDate
                )
                .ToList();

            listBoxAnnouncements.Items.Clear();
            foreach (var announcement in filteredAnnouncements)
            {
                listBoxAnnouncements.Items.Add(
                    $"{announcement.AnnouncementTitle} - {announcement.AnnouncementDate:MMM dd}"
                );
            }

            // Filter recommendations by date range
            var filteredRecommendations = _recommendations
                .Where(rec =>
                {
                    if (rec is Event evt)
                    {
                        return evt.EventDate.Date >= fromDate && evt.EventDate.Date <= toDate;
                    }
                    else if (rec is Announcement announcement)
                    {
                        return announcement.AnnouncementDate.Date >= fromDate
                            && announcement.AnnouncementDate.Date <= toDate;
                    }
                    return false;
                })
                .ToList();

            listBoxRecommendations.Items.Clear();
            foreach (var rec in filteredRecommendations.Take(10))
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonShare_Click(object sender, EventArgs e)
        {
            ShowSocialSharingDialog();
        }

        private void ShowSocialSharingDialog()
        {
            var shareForm = new Form()
            {
                Text = "Share Your Engagement",
                Size = new System.Drawing.Size(500, 450),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
            };

            var labelTitle = new Label()
            {
                Text = "Share your municipal engagement:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(450, 30),
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
            };

            var textBoxContent = new TextBox()
            {
                Text =
                    "I'm actively engaged with my municipality through the Municipal App! \n\n"
                    + "I've been participating in community events, staying informed with announcements, "
                    + "and contributing to local improvements. Join me in making our community better! "
                    + "#MunicipalityApp #CommunityEngagement #LocalGovernment #CivicParticipation",
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(450, 200),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new System.Drawing.Font("Arial", 9),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            };

            var labelPlatforms = new Label()
            {
                Text = "Choose platform to share:",
                Location = new System.Drawing.Point(20, 280),
                Size = new System.Drawing.Size(200, 20),
                Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold),
            };

            var buttonFacebook = new Button()
            {
                Text = "Share on Facebook",
                Location = new System.Drawing.Point(20, 310),
                Size = new System.Drawing.Size(140, 45),
                Font = new System.Drawing.Font("Arial", 9),
                BackColor = System.Drawing.Color.FromArgb(66, 103, 178),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
            };

            var buttonTwitter = new Button()
            {
                Text = "Share on Twitter",
                Location = new System.Drawing.Point(180, 310),
                Size = new System.Drawing.Size(140, 45),
                Font = new System.Drawing.Font("Arial", 9),
                BackColor = System.Drawing.Color.FromArgb(29, 161, 242),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
            };

            var buttonLinkedIn = new Button()
            {
                Text = "Share on LinkedIn",
                Location = new System.Drawing.Point(340, 310),
                Size = new System.Drawing.Size(140, 45),
                Font = new System.Drawing.Font("Arial", 9),
                BackColor = System.Drawing.Color.FromArgb(0, 119, 181),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
            };

            var buttonClose = new Button()
            {
                Text = "Close",
                Location = new System.Drawing.Point(400, 370),
                Size = new System.Drawing.Size(80, 35),
                DialogResult = DialogResult.OK,
                Font = new System.Drawing.Font("Arial", 9),
            };

            // Style the buttons
            buttonFacebook.FlatAppearance.BorderSize = 0;
            buttonFacebook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(
                54,
                88,
                153
            );

            buttonTwitter.FlatAppearance.BorderSize = 0;
            buttonTwitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(
                21,
                132,
                196
            );

            buttonLinkedIn.FlatAppearance.BorderSize = 0;
            buttonLinkedIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(
                0,
                96,
                151
            );

            buttonFacebook.Click += (s, ev) => ShareOnPlatform("Facebook", textBoxContent.Text);
            buttonTwitter.Click += (s, ev) => ShareOnPlatform("Twitter", textBoxContent.Text);
            buttonLinkedIn.Click += (s, ev) => ShareOnPlatform("LinkedIn", textBoxContent.Text);

            shareForm.Controls.AddRange(
                new Control[]
                {
                    labelTitle,
                    textBoxContent,
                    labelPlatforms,
                    buttonFacebook,
                    buttonTwitter,
                    buttonLinkedIn,
                    buttonClose,
                }
            );
            shareForm.ShowDialog();
        }

        private void ShareOnPlatform(string platform, string content)
        {
            // Record the social share
            GamificationService.RecordSocialShare(platform, content, "engagement_share");

            // Show success message
            FeedbackService.ShowSuccess(
                $"Content shared on {platform}!\nYou earned 10 points for sharing!",
                "Share Successful"
            );

            // Show achievement notification if applicable
            var profile = GamificationService.GetProfile();
            if (profile.SocialSharesCount == 5)
            {
                FeedbackService.ShowToast(
                    "Achievement Unlocked: Social Butterfly!",
                    ToastType.Success
                );
            }
        }

        private void buttonViewRecommendations_Click(object sender, EventArgs e)
        {
            // Determine current context and adapt button behavior
            if (tabControl.SelectedTab == tabPageEvents)
            {
                // If on Events tab, register for selected event
                if (listBoxEvents.SelectedIndex >= 0)
                {
                    buttonRegisterEvent_Click(sender, e);
                }
                else
                {
                    FeedbackService.ShowWarning(
                        "Please select an event to register for.",
                        "No Event Selected"
                    );
                }
            }
            else if (tabControl.SelectedTab == tabPageAnnouncements)
            {
                // If on Announcements tab, read selected announcement
                if (listBoxAnnouncements.SelectedIndex >= 0)
                {
                    buttonReadAnnouncement_Click(sender, e);
                }
                else
                {
                    FeedbackService.ShowWarning(
                        "Please select an announcement to read.",
                        "No Announcement Selected"
                    );
                }
            }
            else
            {
                // If on Recommendations tab, show detailed popup
                if (listBoxRecommendations.SelectedIndex >= 0)
                {
                    ShowRecommendationDetails();
                }
                else
                {
                    FeedbackService.ShowWarning(
                        "Please select a recommendation to view details.",
                        "No Recommendation Selected"
                    );
                }
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAdaptiveButton();
        }

        private void ListBoxRecommendations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageRecommendations)
            {
                UpdateAdaptiveButton();
            }
        }

        private void UpdateAdaptiveButton()
        {
            if (tabControl.SelectedTab == tabPageEvents)
            {
                buttonViewRecommendations.Text = "Register for Event";
                buttonViewRecommendations.Enabled = true;
            }
            else if (tabControl.SelectedTab == tabPageAnnouncements)
            {
                buttonViewRecommendations.Text = "Read Announcement";
                buttonViewRecommendations.Enabled = true;
            }
            else if (tabControl.SelectedTab == tabPageRecommendations)
            {
                buttonViewRecommendations.Text = "View Details";
                buttonViewRecommendations.Enabled = listBoxRecommendations.SelectedIndex >= 0;
            }
        }

        private void ShowRecommendationDetails()
        {
            var selectedIndex = listBoxRecommendations.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= _recommendations.Count)
                return;

            var recommendation = _recommendations[selectedIndex];

            if (recommendation is Event evt)
            {
                ShowEventDetailsPopup(evt);
            }
            else if (recommendation is Announcement announcement)
            {
                ShowAnnouncementDetailsPopup(announcement);
            }
        }

        private void ShowEventDetailsPopup(Event evt)
        {
            var details =
                $"Event: {evt.EventName}\n\n"
                + $"Description:\n{evt.EventDescription}\n\n"
                + $"Date: {evt.EventDate:MMMM dd, yyyy 'at' HH:mm}\n"
                + $"Location: {evt.EventLocation}\n"
                + $"Category: {evt.EventCategory}\n"
                + $"Status: {evt.EventStatus}";

            var result = FeedbackService.ShowConfirmation(details, "Event Details - Register?");

            if (result)
            {
                // Show registration dialog
                var userName = ShowInputDialog("Enter your name:", "Event Registration");
                if (string.IsNullOrEmpty(userName))
                {
                    FeedbackService.ShowWarning(
                        "Name is required for registration.",
                        "Missing Information"
                    );
                    return;
                }

                var userEmail = ShowInputDialog("Enter your email:", "Event Registration");
                if (string.IsNullOrEmpty(userEmail))
                {
                    FeedbackService.ShowWarning(
                        "Email is required for registration.",
                        "Missing Information"
                    );
                    return;
                }

                if (!IsValidEmail(userEmail))
                {
                    FeedbackService.ShowError(
                        "Please enter a valid email address.",
                        "Invalid Email"
                    );
                    return;
                }

                // Register for event
                using (
                    var progress = FeedbackService.ShowProgress(
                        "Registering...",
                        "Processing your registration..."
                    )
                )
                {
                    if (EventService.RegisterForEvent(evt.EventId, userName, userEmail))
                    {
                        GamificationService.AddPoints(
                            25,
                            "Registered for event",
                            "event_registration",
                            evt.EventId
                        );
                        FeedbackService.ShowSuccess(
                            $"Successfully registered for {evt.EventName}!\n\nYou will receive a confirmation email at {userEmail}.",
                            "Registration Confirmed"
                        );
                        LoadData(); // Refresh data
                    }
                    else
                    {
                        FeedbackService.ShowError(
                            "Registration failed. This event may be full or no longer available.\nPlease try again or contact support.",
                            "Registration Error"
                        );
                    }
                }
            }
        }

        private void ShowAnnouncementDetailsPopup(Announcement announcement)
        {
            var details =
                $"Title: {announcement.AnnouncementTitle}\n\n"
                + $"Description:\n{announcement.AnnouncementDescription}\n\n"
                + $"Category: {announcement.AnnouncementCategory}\n"
                + $"Location: {announcement.AnnouncementLocation}\n"
                + $"Date: {announcement.AnnouncementDate:MMMM dd, yyyy 'at' HH:mm}";

            var result = FeedbackService.ShowConfirmation(
                details,
                "Announcement Details - Mark as Read?"
            );

            if (result)
            {
                // Mark as read
                AnnouncementService.MarkAnnouncementAsRead(announcement.AnnouncementId);
                GamificationService.AddPoints(5, "Read announcement", "announcement_read");
                FeedbackService.ShowToast(
                    "You earned 5 points for reading this announcement!",
                    ToastType.Success
                );
                LoadData(); // Refresh data
            }
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
