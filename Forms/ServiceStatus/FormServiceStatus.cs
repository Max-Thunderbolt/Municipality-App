using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Municipality_App.Models;
using Municipality_App.Services;
using Municipality_App.Structures;

namespace Municipality_App.Forms.ServiceStatus
{
    public partial class FormServiceStatus : MaterialForm
    {
        private CustomList<ServiceRequest> _requests = new CustomList<ServiceRequest>();
        private ServiceRequestAnalytics _analytics;
        private bool _isLoading = false;

        public FormServiceStatus()
        {
            InitializeComponent();
            ThemeService.ApplyTheme(this);
            InitializeFilters();
            LoadRequests();
        }

        private void InitializeFilters()
        {
            _isLoading = true;

            comboStatus.Items.Clear();
            comboStatus.Items.Add(new FilterOption<ServiceRequestState?>("All statuses", null));
            foreach (ServiceRequestState state in Enum.GetValues(typeof(ServiceRequestState)))
            {
                comboStatus.Items.Add(
                    new FilterOption<ServiceRequestState?>(state.ToString(), state)
                );
            }

            comboPriority.Items.Clear();
            comboPriority.Items.Add(
                new FilterOption<ServiceRequestPriority?>("All priorities", null)
            );
            foreach (
                ServiceRequestPriority priority in Enum.GetValues(typeof(ServiceRequestPriority))
            )
            {
                comboPriority.Items.Add(
                    new FilterOption<ServiceRequestPriority?>(priority.ToString(), priority)
                );
            }

            comboStatus.SelectedIndex = 0;
            comboPriority.SelectedIndex = 0;
            PopulateCategoryFilter(null);

            _isLoading = false;
        }

        private void LoadRequests(bool reloadFromDisk = true)
        {
            if (reloadFromDisk)
            {
                _requests = ServiceRequestRepository.GetAll();
                _analytics = new ServiceRequestAnalytics(_requests);
            }
            else if (_analytics == null)
            {
                _analytics = new ServiceRequestAnalytics(_requests);
            }

            PopulateCategoryFilter(comboCategory.SelectedItem as FilterOption<string>);
            RenderRequestList(GetFilteredRequests());
        }

        private void PopulateCategoryFilter(FilterOption<string> previousSelection)
        {
            _isLoading = true;
            comboCategory.Items.Clear();
            comboCategory.Items.Add(new FilterOption<string>("All categories", null));

            foreach (var category in _requests.Select(r => r.Category).Where(c => !string.IsNullOrWhiteSpace(c)).Distinct().OrderBy(c => c))
            {
                comboCategory.Items.Add(new FilterOption<string>(category, category));
            }

            if (previousSelection != null && !string.IsNullOrWhiteSpace(previousSelection.Value))
            {
                int matchIndex = -1;
                for (int i = 0; i < comboCategory.Items.Count; i++)
                {
                    var option = comboCategory.Items[i] as FilterOption<string>;
                    if (option != null && string.Equals(option.Value, previousSelection.Value, StringComparison.OrdinalIgnoreCase))
                    {
                        matchIndex = i;
                        break;
                    }
                }

                comboCategory.SelectedIndex = matchIndex >= 0 ? matchIndex : 0;
            }
            else
            {
                comboCategory.SelectedIndex = 0;
            }

            _isLoading = false;
        }

        private IEnumerable<ServiceRequest> GetFilteredRequests()
        {
            var statusFilter = comboStatus.SelectedItem as FilterOption<ServiceRequestState?>;
            var priorityFilter =
                comboPriority.SelectedItem as FilterOption<ServiceRequestPriority?>;
            var categoryFilter = comboCategory.SelectedItem as FilterOption<string>;

            IEnumerable<ServiceRequest> query = _requests;

            if (statusFilter?.Value.HasValue == true)
            {
                query = query.Where(r => r.CurrentStatus == statusFilter.Value.Value);
            }

            if (priorityFilter?.Value.HasValue == true)
            {
                query = query.Where(r => r.Priority == priorityFilter.Value.Value);
            }

            if (!string.IsNullOrWhiteSpace(categoryFilter?.Value))
            {
                query = query.Where(r =>
                    string.Equals(r.Category, categoryFilter.Value, StringComparison.OrdinalIgnoreCase)
                );
            }

            var searchTerm = textSearch.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(r =>
                    r.RequestId.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0
                    || (r.Title?.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) ?? -1) >= 0
                );
            }

            return query.OrderByDescending(r => r.Priority).ThenBy(r => r.CreatedAt);
        }

        private void RenderRequestList(IEnumerable<ServiceRequest> requests)
        {
            listRequests.BeginUpdate();
            listRequests.Items.Clear();

            foreach (var request in requests)
            {
                var item = new ListViewItem(request.RequestId);
                item.SubItems.Add(request.Title);
                item.SubItems.Add(request.Category);
                item.SubItems.Add(request.Priority.ToString());
                item.SubItems.Add(request.CurrentStatus.ToString());
                item.SubItems.Add(request.AssignedTeam);
                item.SubItems.Add(request.CreatedAt.ToString("yyyy-MM-dd"));
                item.Tag = request;
                listRequests.Items.Add(item);
            }

            listRequests.EndUpdate();

            if (listRequests.Items.Count > 0)
            {
                listRequests.Items[0].Selected = true;
            }
            else
            {
                UpdateStatusHistory(null);
                UpdateInsights(null);
            }
        }

        private void UpdateStatusHistory(ServiceRequest request)
        {
            listStatusHistory.BeginUpdate();
            listStatusHistory.Items.Clear();

            var timeline = _analytics?.GetStatusTimeline(request);
            if (timeline != null)
            {
                foreach (var status in timeline)
                {
                    var item = new ListViewItem(status.Status.ToString());
                    item.SubItems.Add(status.Timestamp.ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(status.Notes);
                    listStatusHistory.Items.Add(item);
                }
            }

            listStatusHistory.EndUpdate();
        }

        private void UpdateInsights(ServiceRequest request)
        {
            listInsights.Items.Clear();

            if (request == null)
            {
                listInsights.Items.Add("Select a request to view traversal and priority insights.");
                labelSelected.Text = string.Empty;
                return;
            }

            labelSelected.Text = $"Selected: {request.RequestId} • {request.Title}";

            if (_analytics == null)
            {
                listInsights.Items.Add("Analytics not initialised.");
                return;
            }

            var insights = _analytics.BuildInsights(request);
            if (insights.Count == 0)
            {
                listInsights.Items.Add("No analytics available for this request yet.");
            }
            else
            {
                foreach (var insight in insights)
                {
                    listInsights.Items.Add(insight);
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var query = textSearch.Text?.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show(
                    this,
                    "Enter search text (request ID or title fragment).",
                    "Search Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            var request = _analytics?.FindById(query);
            if (request == null)
            {
                request = _requests.FirstOrDefault(r =>
                    r.Title != null
                    && r.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
                );
                if (request == null)
                {
                    MessageBox.Show(
                        this,
                        $"No service request found matching '{query}'.",
                        "Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            comboStatus.SelectedIndex = 0;
            comboPriority.SelectedIndex = 0;
            comboCategory.SelectedIndex = 0;
            textSearch.SelectAll();

            var items = listRequests.Items.Cast<ListViewItem>();
            var targetItem = items.FirstOrDefault(item =>
                string.Equals(item.Text, request.RequestId, StringComparison.OrdinalIgnoreCase)
            );

            if (targetItem == null)
            {
                LoadRequests(false);
                items = listRequests.Items.Cast<ListViewItem>();
                targetItem = items.FirstOrDefault(item =>
                    string.Equals(item.Text, request.RequestId, StringComparison.OrdinalIgnoreCase)
                );
            }

            if (targetItem != null)
            {
                targetItem.Selected = true;
                targetItem.EnsureVisible();
            }
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            LoadRequests(true);
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;
            LoadRequests(false);
        }

        private void comboPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;
            LoadRequests(false);
        }

        private void buttonClearFilters_Click(object sender, EventArgs e)
        {
            _isLoading = true;
            comboStatus.SelectedIndex = 0;
            comboPriority.SelectedIndex = 0;
            comboCategory.SelectedIndex = 0;
            textSearch.Text = string.Empty;
            _isLoading = false;
            LoadRequests(false);
        }

        private void listRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listRequests.SelectedItems.Count == 0)
            {
                UpdateStatusHistory(null);
                UpdateInsights(null);
                return;
            }

            var request = listRequests.SelectedItems[0].Tag as ServiceRequest;
            UpdateStatusHistory(request);
            UpdateInsights(request);
        }

        private void textSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearch_Click(sender, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;
            LoadRequests(false);
        }

        private class FilterOption<T>
        {
            public string Display { get; }
            public T Value { get; }

            public FilterOption(string display, T value)
            {
                Display = display;
                Value = value;
            }

            public override string ToString() => Display;
        }
    }
}
