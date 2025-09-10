namespace Municipality_App
{
	partial class FormReportIssue
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
            this.labelLocation = new System.Windows.Forms.Label();
            this.textLocation = new System.Windows.Forms.TextBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.richDescription = new System.Windows.Forms.RichTextBox();
            this.buttonAttach = new System.Windows.Forms.Button();
            this.listAttachments = new System.Windows.Forms.ListBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.progressEngagement = new System.Windows.Forms.ProgressBar();
            this.labelEngagement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelHeader.Location = new System.Drawing.Point(24, 18);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(110, 21);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Report Issues";
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(26, 58);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(48, 13);
            this.labelLocation.TabIndex = 1;
            this.labelLocation.Text = "Location";
            // 
            // textLocation
            // 
            this.textLocation.Location = new System.Drawing.Point(29, 74);
            this.textLocation.Name = "textLocation";
            this.textLocation.Size = new System.Drawing.Size(420, 20);
            this.textLocation.TabIndex = 2;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(26, 106);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(49, 13);
            this.labelCategory.TabIndex = 3;
            this.labelCategory.Text = "Category";
            // 
            // comboCategory
            // 
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(29, 122);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(200, 21);
            this.comboCategory.TabIndex = 4;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(26, 156);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Description";
            // 
            // richDescription
            // 
            this.richDescription.Location = new System.Drawing.Point(29, 172);
            this.richDescription.Name = "richDescription";
            this.richDescription.Size = new System.Drawing.Size(420, 120);
            this.richDescription.TabIndex = 6;
            this.richDescription.Text = "";
            // 
            // buttonAttach
            // 
            this.buttonAttach.Location = new System.Drawing.Point(329, 298);
            this.buttonAttach.Name = "buttonAttach";
            this.buttonAttach.Size = new System.Drawing.Size(120, 30);
            this.buttonAttach.TabIndex = 7;
            this.buttonAttach.Text = "Attach Files";
            this.buttonAttach.UseVisualStyleBackColor = true;
            this.buttonAttach.Click += new System.EventHandler(this.buttonAttach_Click);
            // 
            // listAttachments
            // 
            this.listAttachments.FormattingEnabled = true;
            this.listAttachments.Location = new System.Drawing.Point(28, 298);
            this.listAttachments.Name = "listAttachments";
            this.listAttachments.Size = new System.Drawing.Size(284, 69);
            this.listAttachments.TabIndex = 8;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.buttonSubmit.ForeColor = System.Drawing.Color.White;
            this.buttonSubmit.Location = new System.Drawing.Point(329, 396);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(120, 36);
            this.buttonSubmit.TabIndex = 10;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(29, 396);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(120, 36);
            this.buttonBack.TabIndex = 9;
            this.buttonBack.Text = "Back to Main Menu";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // progressEngagement
            // 
            this.progressEngagement.Location = new System.Drawing.Point(29, 452);
            this.progressEngagement.Name = "progressEngagement";
            this.progressEngagement.Size = new System.Drawing.Size(420, 18);
            this.progressEngagement.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressEngagement.TabIndex = 11;
            // 
            // labelEngagement
            // 
            this.labelEngagement.AutoSize = true;
            this.labelEngagement.Location = new System.Drawing.Point(26, 433);
            this.labelEngagement.Name = "labelEngagement";
            this.labelEngagement.Size = new System.Drawing.Size(221, 13);
            this.labelEngagement.TabIndex = 12;
            this.labelEngagement.Text = "Help us help you: add more details if possible.";
            // 
            // FormReportIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 491);
            this.Controls.Add(this.labelEngagement);
            this.Controls.Add(this.progressEngagement);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.listAttachments);
            this.Controls.Add(this.buttonAttach);
            this.Controls.Add(this.richDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.textLocation);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report an Issue";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private System.Windows.Forms.Label labelHeader;
		private System.Windows.Forms.Label labelLocation;
		private System.Windows.Forms.TextBox textLocation;
		private System.Windows.Forms.Label labelCategory;
		private System.Windows.Forms.ComboBox comboCategory;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.RichTextBox richDescription;
		private System.Windows.Forms.Button buttonAttach;
		private System.Windows.Forms.ListBox listAttachments;
		private System.Windows.Forms.Button buttonSubmit;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.ProgressBar progressEngagement;
		private System.Windows.Forms.Label labelEngagement;
	}
}


