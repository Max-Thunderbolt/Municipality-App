using MaterialSkin;
using MaterialSkin.Controls;

namespace Municipality_App.Forms.Issues
{
	partial class FormReportIssue : MaterialForm
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
            this.labelLocation = new MaterialSkin.Controls.MaterialLabel();
            this.textLocation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.labelCategory = new MaterialSkin.Controls.MaterialLabel();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.labelDescription = new MaterialSkin.Controls.MaterialLabel();
            this.richDescription = new System.Windows.Forms.RichTextBox();
            this.buttonAttach = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listAttachments = new System.Windows.Forms.ListBox();
            this.buttonSubmit = new MaterialSkin.Controls.MaterialRaisedButton();
            this.progressEngagement = new System.Windows.Forms.ProgressBar();
            this.labelEngagement = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Depth = 0;
            this.labelLocation.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelLocation.Location = new System.Drawing.Point(12, 74);
            this.labelLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(68, 19);
            this.labelLocation.TabIndex = 1;
            this.labelLocation.Text = "Location";
            // 
            // textLocation
            // 
            this.textLocation.Depth = 0;
            this.textLocation.Hint = "";
            this.textLocation.Location = new System.Drawing.Point(86, 70);
            this.textLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.textLocation.Name = "textLocation";
            this.textLocation.PasswordChar = '\0';
            this.textLocation.SelectedText = "";
            this.textLocation.SelectionLength = 0;
            this.textLocation.SelectionStart = 0;
            this.textLocation.Size = new System.Drawing.Size(344, 23);
            this.textLocation.TabIndex = 2;
            this.textLocation.UseSystemPasswordChar = false;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Depth = 0;
            this.labelCategory.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCategory.Location = new System.Drawing.Point(12, 122);
            this.labelCategory.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(69, 19);
            this.labelCategory.TabIndex = 3;
            this.labelCategory.Text = "Category";
            // 
            // comboCategory
            // 
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(87, 122);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(200, 21);
            this.comboCategory.TabIndex = 4;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Depth = 0;
            this.labelDescription.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDescription.Location = new System.Drawing.Point(12, 170);
            this.labelDescription.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(86, 19);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Description";
            // 
            // richDescription
            // 
            this.richDescription.Location = new System.Drawing.Point(16, 192);
            this.richDescription.Name = "richDescription";
            this.richDescription.Size = new System.Drawing.Size(420, 120);
            this.richDescription.TabIndex = 6;
            this.richDescription.Text = "";
            // 
            // buttonAttach
            // 
            this.buttonAttach.Depth = 0;
            this.buttonAttach.Location = new System.Drawing.Point(12, 318);
            this.buttonAttach.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAttach.Name = "buttonAttach";
            this.buttonAttach.Primary = true;
            this.buttonAttach.Size = new System.Drawing.Size(120, 30);
            this.buttonAttach.TabIndex = 7;
            this.buttonAttach.Text = "Attach Files";
            this.buttonAttach.UseVisualStyleBackColor = true;
            this.buttonAttach.Click += new System.EventHandler(this.buttonAttach_Click);
            // 
            // listAttachments
            // 
            this.listAttachments.FormattingEnabled = true;
            this.listAttachments.Location = new System.Drawing.Point(12, 354);
            this.listAttachments.Name = "listAttachments";
            this.listAttachments.Size = new System.Drawing.Size(284, 69);
            this.listAttachments.TabIndex = 8;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Depth = 0;
            this.buttonSubmit.Location = new System.Drawing.Point(167, 439);
            this.buttonSubmit.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Primary = true;
            this.buttonSubmit.Size = new System.Drawing.Size(120, 36);
            this.buttonSubmit.TabIndex = 10;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // progressEngagement
            // 
            this.progressEngagement.Location = new System.Drawing.Point(9, 508);
            this.progressEngagement.Name = "progressEngagement";
            this.progressEngagement.Size = new System.Drawing.Size(420, 18);
            this.progressEngagement.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressEngagement.TabIndex = 11;
            // 
            // labelEngagement
            // 
            this.labelEngagement.AutoSize = true;
            this.labelEngagement.Depth = 0;
            this.labelEngagement.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelEngagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelEngagement.Location = new System.Drawing.Point(6, 489);
            this.labelEngagement.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelEngagement.Name = "labelEngagement";
            this.labelEngagement.Size = new System.Drawing.Size(318, 19);
            this.labelEngagement.TabIndex = 12;
            this.labelEngagement.Text = "Help us help you: add more details if possible.";
            // 
            // FormReportIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 541);
            this.Controls.Add(this.labelEngagement);
            this.Controls.Add(this.progressEngagement);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.listAttachments);
            this.Controls.Add(this.buttonAttach);
            this.Controls.Add(this.richDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.textLocation);
            this.Controls.Add(this.labelLocation);
            this.Name = "FormReportIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report an Issue";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private MaterialSkin.Controls.MaterialLabel labelLocation;
		private MaterialSkin.Controls.MaterialSingleLineTextField textLocation;
		private MaterialSkin.Controls.MaterialLabel labelCategory;
		private System.Windows.Forms.ComboBox comboCategory;
		private MaterialSkin.Controls.MaterialLabel labelDescription;
		private System.Windows.Forms.RichTextBox richDescription;
		private MaterialSkin.Controls.MaterialRaisedButton buttonAttach;
		private System.Windows.Forms.ListBox listAttachments;
		private MaterialSkin.Controls.MaterialRaisedButton buttonSubmit;
		private System.Windows.Forms.ProgressBar progressEngagement;
		private MaterialSkin.Controls.MaterialLabel labelEngagement;
    }
}