namespace CanvasRubricExporter
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Control declarations
        private System.Windows.Forms.TextBox BaseUrlTextBox;
        private System.Windows.Forms.TextBox ApiTokenTextBox;
        private System.Windows.Forms.TextBox CourseIdTextBox;
        private System.Windows.Forms.ListBox AssignmentsListBox;
        private System.Windows.Forms.ComboBox ModulesComboBox;
        private System.Windows.Forms.Button FetchAssignmentsButton;
        private System.Windows.Forms.Button ExportToPdfButton;
        private System.Windows.Forms.Button FetchModulesButton;
        private System.Windows.Forms.Label BaseUrlLabel;
        private System.Windows.Forms.Label ApiTokenLabel;
        private System.Windows.Forms.Label CourseIdLabel;
        private System.Windows.Forms.Label ModulesLabel;
        private System.Windows.Forms.Label AssignmentsLabel; // Added AssignmentsLabel
        private System.Windows.Forms.CheckBox ShortTableCheckBox;

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
            this.BaseUrlTextBox = new System.Windows.Forms.TextBox();
            this.ApiTokenTextBox = new System.Windows.Forms.TextBox();
            this.CourseIdTextBox = new System.Windows.Forms.TextBox();
            this.AssignmentsListBox = new System.Windows.Forms.ListBox();
            this.ModulesComboBox = new System.Windows.Forms.ComboBox();
            this.FetchAssignmentsButton = new System.Windows.Forms.Button();
            this.ExportToPdfButton = new System.Windows.Forms.Button();
            this.FetchModulesButton = new System.Windows.Forms.Button();
            this.BaseUrlLabel = new System.Windows.Forms.Label();
            this.ApiTokenLabel = new System.Windows.Forms.Label();
            this.CourseIdLabel = new System.Windows.Forms.Label();
            this.ModulesLabel = new System.Windows.Forms.Label();
            this.AssignmentsLabel = new System.Windows.Forms.Label(); // Initialize AssignmentsLabel
            this.ShortTableCheckBox = new System.Windows.Forms.CheckBox();

            this.SuspendLayout();

            // BaseUrlLabel
            this.BaseUrlLabel.AutoSize = true;
            this.BaseUrlLabel.Location = new System.Drawing.Point(20, 23);
            this.BaseUrlLabel.Name = "BaseUrlLabel";
            this.BaseUrlLabel.Size = new System.Drawing.Size(58, 13);
            this.BaseUrlLabel.TabIndex = 0;
            this.BaseUrlLabel.Text = "Base URL:";

            // BaseUrlTextBox
            this.BaseUrlTextBox.Location = new System.Drawing.Point(120, 20);
            this.BaseUrlTextBox.Name = "BaseUrlTextBox";
            this.BaseUrlTextBox.Size = new System.Drawing.Size(250, 20);
            this.BaseUrlTextBox.TabIndex = 1;
            this.BaseUrlTextBox.Text = "https://fhict.instructure.com";

            // ApiTokenLabel
            this.ApiTokenLabel.AutoSize = true;
            this.ApiTokenLabel.Location = new System.Drawing.Point(20, 63);
            this.ApiTokenLabel.Name = "ApiTokenLabel";
            this.ApiTokenLabel.Size = new System.Drawing.Size(61, 13);
            this.ApiTokenLabel.TabIndex = 2;
            this.ApiTokenLabel.Text = "API Token:";

            // ApiTokenTextBox
            this.ApiTokenTextBox.Location = new System.Drawing.Point(120, 60);
            this.ApiTokenTextBox.Name = "ApiTokenTextBox";
            this.ApiTokenTextBox.Size = new System.Drawing.Size(250, 20);
            this.ApiTokenTextBox.TabIndex = 3;

            // CourseIdLabel
            this.CourseIdLabel.AutoSize = true;
            this.CourseIdLabel.Location = new System.Drawing.Point(20, 103);
            this.CourseIdLabel.Name = "CourseIdLabel";
            this.CourseIdLabel.Size = new System.Drawing.Size(58, 13);
            this.CourseIdLabel.TabIndex = 4;
            this.CourseIdLabel.Text = "Course ID:";

            // CourseIdTextBox
            this.CourseIdTextBox.Location = new System.Drawing.Point(120, 100);
            this.CourseIdTextBox.Name = "CourseIdTextBox";
            this.CourseIdTextBox.Size = new System.Drawing.Size(250, 20);
            this.CourseIdTextBox.TabIndex = 5;

            // FetchModulesButton
            this.FetchModulesButton.Location = new System.Drawing.Point(20, 140);
            this.FetchModulesButton.Name = "FetchModulesButton";
            this.FetchModulesButton.Size = new System.Drawing.Size(100, 23);
            this.FetchModulesButton.TabIndex = 6;
            this.FetchModulesButton.Text = "Fetch Modules";
            this.FetchModulesButton.UseVisualStyleBackColor = true;
            this.FetchModulesButton.Click += new System.EventHandler(this.FetchModulesButton_Click);

            // ModulesLabel
            this.ModulesLabel.AutoSize = true;
            this.ModulesLabel.Location = new System.Drawing.Point(20, 173);
            this.ModulesLabel.Name = "ModulesLabel";
            this.ModulesLabel.Size = new System.Drawing.Size(52, 13);
            this.ModulesLabel.TabIndex = 7;
            this.ModulesLabel.Text = "Modules:";

            // ModulesComboBox
            this.ModulesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModulesComboBox.Location = new System.Drawing.Point(120, 170);
            this.ModulesComboBox.Name = "ModulesComboBox";
            this.ModulesComboBox.Size = new System.Drawing.Size(250, 21);
            this.ModulesComboBox.TabIndex = 8;

            // FetchAssignmentsButton
            this.FetchAssignmentsButton.Location = new System.Drawing.Point(20, 210);
            this.FetchAssignmentsButton.Name = "FetchAssignmentsButton";
            this.FetchAssignmentsButton.Size = new System.Drawing.Size(150, 23);
            this.FetchAssignmentsButton.TabIndex = 9;
            this.FetchAssignmentsButton.Text = "Fetch Assignments";
            this.FetchAssignmentsButton.UseVisualStyleBackColor = true;
            this.FetchAssignmentsButton.Click += new System.EventHandler(this.FetchAssignmentsButton_Click);

            // AssignmentsLabel
            this.AssignmentsLabel.AutoSize = true;
            this.AssignmentsLabel.Location = new System.Drawing.Point(20, 243);
            this.AssignmentsLabel.Name = "AssignmentsLabel";
            this.AssignmentsLabel.Size = new System.Drawing.Size(73, 13);
            this.AssignmentsLabel.TabIndex = 10;
            this.AssignmentsLabel.Text = "Assignments:";

            // AssignmentsListBox
            this.AssignmentsListBox.FormattingEnabled = true;
            this.AssignmentsListBox.Location = new System.Drawing.Point(20, 260);
            this.AssignmentsListBox.Name = "AssignmentsListBox";
            this.AssignmentsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AssignmentsListBox.Size = new System.Drawing.Size(350, 108);
            this.AssignmentsListBox.TabIndex = 11;

            // ShortTableCheckBox
            this.ShortTableCheckBox.AutoSize = true;
            this.ShortTableCheckBox.Checked = true;
            this.ShortTableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShortTableCheckBox.Location = new System.Drawing.Point(20, 380);
            this.ShortTableCheckBox.Name = "ShortTableCheckBox";
            this.ShortTableCheckBox.Size = new System.Drawing.Size(180, 17);
            this.ShortTableCheckBox.TabIndex = 12;
            this.ShortTableCheckBox.Text = "Export to Excel (Short Table)";
            this.ShortTableCheckBox.UseVisualStyleBackColor = true;

            // ExportToPdfButton
            this.ExportToPdfButton.Location = new System.Drawing.Point(220, 375);
            this.ExportToPdfButton.Name = "ExportToPdfButton";
            this.ExportToPdfButton.Size = new System.Drawing.Size(150, 23);
            this.ExportToPdfButton.TabIndex = 13;
            this.ExportToPdfButton.Text = "Export";
            this.ExportToPdfButton.UseVisualStyleBackColor = true;
            this.ExportToPdfButton.Click += new System.EventHandler(this.ExportToPdfButton_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(400, 420);
            this.Controls.Add(this.ExportToPdfButton);
            this.Controls.Add(this.ShortTableCheckBox);
            this.Controls.Add(this.AssignmentsListBox);
            this.Controls.Add(this.AssignmentsLabel);
            this.Controls.Add(this.FetchAssignmentsButton);
            this.Controls.Add(this.ModulesComboBox);
            this.Controls.Add(this.ModulesLabel);
            this.Controls.Add(this.FetchModulesButton);
            this.Controls.Add(this.CourseIdTextBox);
            this.Controls.Add(this.CourseIdLabel);
            this.Controls.Add(this.ApiTokenTextBox);
            this.Controls.Add(this.ApiTokenLabel);
            this.Controls.Add(this.BaseUrlTextBox);
            this.Controls.Add(this.BaseUrlLabel);
            this.Name = "MainForm";
            this.Text = "Canvas Rubric Exporter";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}