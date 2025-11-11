using MaterialSkin;
using MaterialSkin.Controls;

namespace Municipality_App.Forms.ServiceStatus
{
    partial class FormServiceStatus : MaterialForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelTitle = new MaterialSkin.Controls.MaterialLabel();
            this.textSearch = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.buttonSearch = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonReload = new MaterialSkin.Controls.MaterialFlatButton();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.comboPriority = new System.Windows.Forms.ComboBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.labelStatusFilter = new MaterialSkin.Controls.MaterialLabel();
            this.labelPriorityFilter = new MaterialSkin.Controls.MaterialLabel();
            this.labelCategoryFilter = new MaterialSkin.Controls.MaterialLabel();
            this.buttonClearFilters = new MaterialSkin.Controls.MaterialFlatButton();
            this.listRequests = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAssigned = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelRequestList = new MaterialSkin.Controls.MaterialLabel();
            this.labelHistory = new MaterialSkin.Controls.MaterialLabel();
            this.listStatusHistory = new System.Windows.Forms.ListView();
            this.columnHeaderHistoryStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHistoryTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHistoryNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelInsights = new MaterialSkin.Controls.MaterialLabel();
            this.listInsights = new System.Windows.Forms.ListBox();
            this.labelSelected = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Depth = 0;
            this.labelTitle.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelTitle.Location = new System.Drawing.Point(16, 74);
            this.labelTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(275, 19);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Track Municipal Service Request Status";
            // 
            // textSearch
            // 
            this.textSearch.Depth = 0;
            this.textSearch.Hint = "Search by ID or Title";
            this.textSearch.Location = new System.Drawing.Point(20, 108);
            this.textSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.textSearch.Name = "textSearch";
            this.textSearch.PasswordChar = '\0';
            this.textSearch.SelectedText = "";
            this.textSearch.SelectionLength = 0;
            this.textSearch.SelectionStart = 0;
            this.textSearch.Size = new System.Drawing.Size(320, 23);
            this.textSearch.TabIndex = 1;
            this.textSearch.UseSystemPasswordChar = false;
            this.textSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSearch_KeyDown);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Depth = 0;
            this.buttonSearch.Location = new System.Drawing.Point(350, 102);
            this.buttonSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Primary = true;
            this.buttonSearch.Size = new System.Drawing.Size(140, 36);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Find Request";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonReload
            // 
            this.buttonReload.AutoSize = true;
            this.buttonReload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReload.Depth = 0;
            this.buttonReload.Location = new System.Drawing.Point(497, 102);
            this.buttonReload.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonReload.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Primary = false;
            this.buttonReload.Size = new System.Drawing.Size(102, 36);
            this.buttonReload.TabIndex = 3;
            this.buttonReload.Text = "Reload Data";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // comboStatus
            // 
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Location = new System.Drawing.Point(20, 170);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(200, 21);
            this.comboStatus.TabIndex = 4;
            this.comboStatus.SelectedIndexChanged += new System.EventHandler(this.comboStatus_SelectedIndexChanged);
            // 
            // comboPriority
            // 
            this.comboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPriority.FormattingEnabled = true;
            this.comboPriority.Location = new System.Drawing.Point(238, 170);
            this.comboPriority.Name = "comboPriority";
            this.comboPriority.Size = new System.Drawing.Size(200, 21);
            this.comboPriority.TabIndex = 5;
            this.comboPriority.SelectedIndexChanged += new System.EventHandler(this.comboPriority_SelectedIndexChanged);
            // 
            // comboCategory
            // 
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(456, 170);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(200, 21);
            this.comboCategory.TabIndex = 6;
            this.comboCategory.SelectedIndexChanged += new System.EventHandler(this.comboCategory_SelectedIndexChanged);
            // 
            // labelStatusFilter
            // 
            this.labelStatusFilter.AutoSize = true;
            this.labelStatusFilter.Depth = 0;
            this.labelStatusFilter.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelStatusFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelStatusFilter.Location = new System.Drawing.Point(16, 148);
            this.labelStatusFilter.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelStatusFilter.Name = "labelStatusFilter";
            this.labelStatusFilter.Size = new System.Drawing.Size(113, 19);
            this.labelStatusFilter.TabIndex = 6;
            this.labelStatusFilter.Text = "Filter by Status:";
            // 
            // labelPriorityFilter
            // 
            this.labelPriorityFilter.AutoSize = true;
            this.labelPriorityFilter.Depth = 0;
            this.labelPriorityFilter.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelPriorityFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPriorityFilter.Location = new System.Drawing.Point(234, 148);
            this.labelPriorityFilter.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPriorityFilter.Name = "labelPriorityFilter";
            this.labelPriorityFilter.Size = new System.Drawing.Size(118, 19);
            this.labelPriorityFilter.TabIndex = 7;
            this.labelPriorityFilter.Text = "Filter by Priority:";
            // 
            // labelCategoryFilter
            // 
            this.labelCategoryFilter.AutoSize = true;
            this.labelCategoryFilter.Depth = 0;
            this.labelCategoryFilter.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelCategoryFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCategoryFilter.Location = new System.Drawing.Point(452, 148);
            this.labelCategoryFilter.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCategoryFilter.Name = "labelCategoryFilter";
            this.labelCategoryFilter.Size = new System.Drawing.Size(130, 19);
            this.labelCategoryFilter.TabIndex = 7;
            this.labelCategoryFilter.Text = "Filter by Category:";
            // 
            // buttonClearFilters
            // 
            this.buttonClearFilters.AutoSize = true;
            this.buttonClearFilters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonClearFilters.Depth = 0;
            this.buttonClearFilters.Location = new System.Drawing.Point(674, 162);
            this.buttonClearFilters.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonClearFilters.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonClearFilters.Name = "buttonClearFilters";
            this.buttonClearFilters.Primary = false;
            this.buttonClearFilters.Size = new System.Drawing.Size(109, 36);
            this.buttonClearFilters.TabIndex = 8;
            this.buttonClearFilters.Text = "Clear Filters";
            this.buttonClearFilters.UseVisualStyleBackColor = true;
            this.buttonClearFilters.Click += new System.EventHandler(this.buttonClearFilters_Click);
            // 
            // listRequests
            // 
            this.listRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderTitle,
            this.columnHeaderCategory,
            this.columnHeaderPriority,
            this.columnHeaderStatus,
            this.columnHeaderAssigned,
            this.columnHeaderCreated});
            this.listRequests.FullRowSelect = true;
            this.listRequests.HideSelection = false;
            this.listRequests.Location = new System.Drawing.Point(20, 226);
            this.listRequests.MultiSelect = false;
            this.listRequests.Name = "listRequests";
            this.listRequests.Size = new System.Drawing.Size(1130, 220);
            this.listRequests.TabIndex = 9;
            this.listRequests.UseCompatibleStateImageBehavior = false;
            this.listRequests.View = System.Windows.Forms.View.Details;
            this.listRequests.SelectedIndexChanged += new System.EventHandler(this.listRequests_SelectedIndexChanged);
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Request ID";
            this.columnHeaderId.Width = 100;
            // 
            // columnHeaderTitle
            // 
            this.columnHeaderTitle.Text = "Title";
            this.columnHeaderTitle.Width = 200;
            // 
            // columnHeaderCategory
            // 
            this.columnHeaderCategory.Text = "Category";
            this.columnHeaderCategory.Width = 140;
            // 
            // columnHeaderPriority
            // 
            this.columnHeaderPriority.Text = "Priority";
            this.columnHeaderPriority.Width = 80;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 120;
            // 
            // columnHeaderAssigned
            // 
            this.columnHeaderAssigned.Text = "Assigned Team";
            this.columnHeaderAssigned.Width = 180;
            // 
            // columnHeaderCreated
            // 
            this.columnHeaderCreated.Text = "Created";
            this.columnHeaderCreated.Width = 120;
            // 
            // labelRequestList
            // 
            this.labelRequestList.AutoSize = true;
            this.labelRequestList.Depth = 0;
            this.labelRequestList.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelRequestList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelRequestList.Location = new System.Drawing.Point(16, 204);
            this.labelRequestList.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelRequestList.Name = "labelRequestList";
            this.labelRequestList.Size = new System.Drawing.Size(248, 19);
            this.labelRequestList.TabIndex = 10;
            this.labelRequestList.Text = "Open and Historical Service Tickets";
            // 
            // labelHistory
            // 
            this.labelHistory.AutoSize = true;
            this.labelHistory.Depth = 0;
            this.labelHistory.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelHistory.Location = new System.Drawing.Point(16, 458);
            this.labelHistory.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelHistory.Name = "labelHistory";
            this.labelHistory.Size = new System.Drawing.Size(189, 19);
            this.labelHistory.TabIndex = 11;
            this.labelHistory.Text = "Status Timeline (BST/AVL)";
            // 
            // listStatusHistory
            // 
            this.listStatusHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderHistoryStatus,
            this.columnHeaderHistoryTime,
            this.columnHeaderHistoryNotes});
            this.listStatusHistory.FullRowSelect = true;
            this.listStatusHistory.HideSelection = false;
            this.listStatusHistory.Location = new System.Drawing.Point(20, 480);
            this.listStatusHistory.MultiSelect = false;
            this.listStatusHistory.Name = "listStatusHistory";
            this.listStatusHistory.Size = new System.Drawing.Size(600, 186);
            this.listStatusHistory.TabIndex = 12;
            this.listStatusHistory.UseCompatibleStateImageBehavior = false;
            this.listStatusHistory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderHistoryStatus
            // 
            this.columnHeaderHistoryStatus.Text = "Status";
            this.columnHeaderHistoryStatus.Width = 110;
            // 
            // columnHeaderHistoryTime
            // 
            this.columnHeaderHistoryTime.Text = "Timestamp";
            this.columnHeaderHistoryTime.Width = 140;
            // 
            // columnHeaderHistoryNotes
            // 
            this.columnHeaderHistoryNotes.Text = "Notes";
            this.columnHeaderHistoryNotes.Width = 150;
            // 
            // labelInsights
            // 
            this.labelInsights.AutoSize = true;
            this.labelInsights.Depth = 0;
            this.labelInsights.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelInsights.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelInsights.Location = new System.Drawing.Point(622, 458);
            this.labelInsights.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelInsights.Name = "labelInsights";
            this.labelInsights.Size = new System.Drawing.Size(215, 19);
            this.labelInsights.TabIndex = 13;
            this.labelInsights.Text = "Graph & Heap Insights Summary";
            // 
            // listInsights
            // 
            this.listInsights.FormattingEnabled = true;
            this.listInsights.Location = new System.Drawing.Point(626, 480);
            this.listInsights.Name = "listInsights";
            this.listInsights.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listInsights.Size = new System.Drawing.Size(524, 186);
            this.listInsights.TabIndex = 14;
            // 
            // labelSelected
            // 
            this.labelSelected.AutoSize = true;
            this.labelSelected.Depth = 0;
            this.labelSelected.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSelected.Location = new System.Drawing.Point(620, 204);
            this.labelSelected.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelSelected.Name = "labelSelected";
            this.labelSelected.Size = new System.Drawing.Size(0, 19);
            this.labelSelected.TabIndex = 15;
            // 
            // FormServiceStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 819);
            this.Controls.Add(this.labelSelected);
            this.Controls.Add(this.listInsights);
            this.Controls.Add(this.labelInsights);
            this.Controls.Add(this.listStatusHistory);
            this.Controls.Add(this.labelHistory);
            this.Controls.Add(this.labelRequestList);
            this.Controls.Add(this.listRequests);
            this.Controls.Add(this.buttonClearFilters);
            this.Controls.Add(this.labelPriorityFilter);
            this.Controls.Add(this.labelCategoryFilter);
            this.Controls.Add(this.labelStatusFilter);
            this.Controls.Add(this.comboPriority);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.labelTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormServiceStatus";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Service Request Status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel labelTitle;
        private MaterialSkin.Controls.MaterialSingleLineTextField textSearch;
        private MaterialSkin.Controls.MaterialRaisedButton buttonSearch;
        private MaterialSkin.Controls.MaterialFlatButton buttonReload;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.ComboBox comboPriority;
        private System.Windows.Forms.ComboBox comboCategory;
        private MaterialSkin.Controls.MaterialLabel labelStatusFilter;
        private MaterialSkin.Controls.MaterialLabel labelPriorityFilter;
        private MaterialSkin.Controls.MaterialLabel labelCategoryFilter;
        private MaterialSkin.Controls.MaterialFlatButton buttonClearFilters;
        private System.Windows.Forms.ListView listRequests;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderCategory;
        private System.Windows.Forms.ColumnHeader columnHeaderPriority;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderAssigned;
        private System.Windows.Forms.ColumnHeader columnHeaderCreated;
        private MaterialSkin.Controls.MaterialLabel labelRequestList;
        private MaterialSkin.Controls.MaterialLabel labelHistory;
        private System.Windows.Forms.ListView listStatusHistory;
        private System.Windows.Forms.ColumnHeader columnHeaderHistoryStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderHistoryTime;
        private System.Windows.Forms.ColumnHeader columnHeaderHistoryNotes;
        private MaterialSkin.Controls.MaterialLabel labelInsights;
        private System.Windows.Forms.ListBox listInsights;
        private MaterialSkin.Controls.MaterialLabel labelSelected;
    }
}

