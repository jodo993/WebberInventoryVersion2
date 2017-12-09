namespace Webber_Inventory_Search_2017_2018
{
    partial class SearchInventoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchInventoryForm));
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.updateGroupBox = new System.Windows.Forms.GroupBox();
            this.statusRadioButton = new System.Windows.Forms.RadioButton();
            this.locationRadioButton = new System.Windows.Forms.RadioButton();
            this.update2GroupBox = new System.Windows.Forms.GroupBox();
            this.updateTagTextBox = new System.Windows.Forms.MaskedTextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.updateLocationComboBox = new System.Windows.Forms.ComboBox();
            this.updateStatusComboBox = new System.Windows.Forms.ComboBox();
            this.newLabel = new System.Windows.Forms.Label();
            this.tagLabel = new System.Windows.Forms.Label();
            this.removeGroupBox = new System.Windows.Forms.GroupBox();
            this.removeTextBox = new System.Windows.Forms.TextBox();
            this.clearRemoveButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.removeTagLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.exitButton = new System.Windows.Forms.Button();
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.showAllButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.categorySearchComboBox = new System.Windows.Forms.ComboBox();
            this.findButton = new System.Windows.Forms.Button();
            this.printPreviewDialogSearch = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocumentSearch = new System.Drawing.Printing.PrintDocument();
            this.printButton = new System.Windows.Forms.Button();
            this.searchGroupBox.SuspendLayout();
            this.updateGroupBox.SuspendLayout();
            this.update2GroupBox.SuspendLayout();
            this.removeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.clearButton);
            this.searchGroupBox.Controls.Add(this.searchTextBox);
            this.searchGroupBox.Controls.Add(this.searchButton);
            this.searchGroupBox.Controls.Add(this.label1);
            this.searchGroupBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchGroupBox.Location = new System.Drawing.Point(21, 38);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(200, 100);
            this.searchGroupBox.TabIndex = 0;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Search";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(132, 31);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(51, 22);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(26, 57);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(100, 22);
            this.searchTextBox.TabIndex = 21;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(132, 56);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(51, 22);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "WSD Tag #";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateGroupBox
            // 
            this.updateGroupBox.Controls.Add(this.statusRadioButton);
            this.updateGroupBox.Controls.Add(this.locationRadioButton);
            this.updateGroupBox.Controls.Add(this.update2GroupBox);
            this.updateGroupBox.Location = new System.Drawing.Point(249, 38);
            this.updateGroupBox.Name = "updateGroupBox";
            this.updateGroupBox.Size = new System.Drawing.Size(516, 206);
            this.updateGroupBox.TabIndex = 1;
            this.updateGroupBox.TabStop = false;
            this.updateGroupBox.Text = "Update";
            // 
            // statusRadioButton
            // 
            this.statusRadioButton.AutoSize = true;
            this.statusRadioButton.Location = new System.Drawing.Point(122, 19);
            this.statusRadioButton.Name = "statusRadioButton";
            this.statusRadioButton.Size = new System.Drawing.Size(55, 17);
            this.statusRadioButton.TabIndex = 1;
            this.statusRadioButton.Text = "Status";
            this.statusRadioButton.UseVisualStyleBackColor = true;
            this.statusRadioButton.CheckedChanged += new System.EventHandler(this.statusRadioButton_CheckedChanged);
            // 
            // locationRadioButton
            // 
            this.locationRadioButton.AutoSize = true;
            this.locationRadioButton.Checked = true;
            this.locationRadioButton.Location = new System.Drawing.Point(31, 19);
            this.locationRadioButton.Name = "locationRadioButton";
            this.locationRadioButton.Size = new System.Drawing.Size(66, 17);
            this.locationRadioButton.TabIndex = 0;
            this.locationRadioButton.TabStop = true;
            this.locationRadioButton.Text = "Location";
            this.locationRadioButton.UseVisualStyleBackColor = true;
            this.locationRadioButton.CheckedChanged += new System.EventHandler(this.locationRadioButton_CheckedChanged);
            // 
            // update2GroupBox
            // 
            this.update2GroupBox.Controls.Add(this.updateTagTextBox);
            this.update2GroupBox.Controls.Add(this.updateButton);
            this.update2GroupBox.Controls.Add(this.updateLocationComboBox);
            this.update2GroupBox.Controls.Add(this.updateStatusComboBox);
            this.update2GroupBox.Controls.Add(this.newLabel);
            this.update2GroupBox.Controls.Add(this.tagLabel);
            this.update2GroupBox.Location = new System.Drawing.Point(22, 49);
            this.update2GroupBox.Name = "update2GroupBox";
            this.update2GroupBox.Size = new System.Drawing.Size(203, 131);
            this.update2GroupBox.TabIndex = 0;
            this.update2GroupBox.TabStop = false;
            this.update2GroupBox.Text = "Update Location";
            // 
            // updateTagTextBox
            // 
            this.updateTagTextBox.Location = new System.Drawing.Point(9, 43);
            this.updateTagTextBox.Mask = "999999000";
            this.updateTagTextBox.Name = "updateTagTextBox";
            this.updateTagTextBox.Size = new System.Drawing.Size(87, 20);
            this.updateTagTextBox.TabIndex = 23;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(9, 83);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(185, 25);
            this.updateButton.TabIndex = 5;
            this.updateButton.Text = "Update Location";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // updateLocationComboBox
            // 
            this.updateLocationComboBox.FormattingEnabled = true;
            this.updateLocationComboBox.Items.AddRange(new object[] {
            "Office",
            "District",
            "MPR",
            "Library",
            "K1",
            "K2",
            "A1",
            "A2",
            "A3",
            "A4",
            "B1",
            "B2",
            "B3",
            "B4",
            "C1",
            "C2",
            "C3",
            "C4",
            "D1",
            "D2",
            "D3",
            "D4",
            "E1",
            "E2",
            "E3",
            "E4",
            "F1",
            "F2",
            "F3",
            "F4",
            "Other"});
            this.updateLocationComboBox.Location = new System.Drawing.Point(102, 43);
            this.updateLocationComboBox.Name = "updateLocationComboBox";
            this.updateLocationComboBox.Size = new System.Drawing.Size(90, 21);
            this.updateLocationComboBox.TabIndex = 4;
            // 
            // updateStatusComboBox
            // 
            this.updateStatusComboBox.FormattingEnabled = true;
            this.updateStatusComboBox.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            "Repair",
            "Surplus",
            "Unknown"});
            this.updateStatusComboBox.Location = new System.Drawing.Point(102, 43);
            this.updateStatusComboBox.Name = "updateStatusComboBox";
            this.updateStatusComboBox.Size = new System.Drawing.Size(90, 21);
            this.updateStatusComboBox.TabIndex = 9;
            // 
            // newLabel
            // 
            this.newLabel.AutoSize = true;
            this.newLabel.Location = new System.Drawing.Point(99, 27);
            this.newLabel.Name = "newLabel";
            this.newLabel.Size = new System.Drawing.Size(73, 13);
            this.newLabel.TabIndex = 1;
            this.newLabel.Text = "New Location";
            // 
            // tagLabel
            // 
            this.tagLabel.AutoSize = true;
            this.tagLabel.Location = new System.Drawing.Point(6, 27);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(66, 13);
            this.tagLabel.TabIndex = 0;
            this.tagLabel.Text = "Tag Number";
            // 
            // removeGroupBox
            // 
            this.removeGroupBox.Controls.Add(this.removeTextBox);
            this.removeGroupBox.Controls.Add(this.clearRemoveButton);
            this.removeGroupBox.Controls.Add(this.removeButton);
            this.removeGroupBox.Controls.Add(this.removeTagLabel);
            this.removeGroupBox.Location = new System.Drawing.Point(21, 144);
            this.removeGroupBox.Name = "removeGroupBox";
            this.removeGroupBox.Size = new System.Drawing.Size(200, 100);
            this.removeGroupBox.TabIndex = 1;
            this.removeGroupBox.TabStop = false;
            this.removeGroupBox.Text = "Remove";
            // 
            // removeTextBox
            // 
            this.removeTextBox.Location = new System.Drawing.Point(26, 52);
            this.removeTextBox.Name = "removeTextBox";
            this.removeTextBox.Size = new System.Drawing.Size(100, 20);
            this.removeTextBox.TabIndex = 21;
            // 
            // clearRemoveButton
            // 
            this.clearRemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearRemoveButton.Location = new System.Drawing.Point(132, 26);
            this.clearRemoveButton.Name = "clearRemoveButton";
            this.clearRemoveButton.Size = new System.Drawing.Size(51, 23);
            this.clearRemoveButton.TabIndex = 8;
            this.clearRemoveButton.Text = "Clear";
            this.clearRemoveButton.UseVisualStyleBackColor = true;
            this.clearRemoveButton.Click += new System.EventHandler(this.clearRemoveButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(132, 51);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(51, 23);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // removeTagLabel
            // 
            this.removeTagLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.removeTagLabel.Location = new System.Drawing.Point(26, 26);
            this.removeTagLabel.Name = "removeTagLabel";
            this.removeTagLabel.Size = new System.Drawing.Size(100, 23);
            this.removeTagLabel.TabIndex = 6;
            this.removeTagLabel.Text = "WSD Tag Number";
            this.removeTagLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 292);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(744, 185);
            this.dataGridView1.TabIndex = 3;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(690, 483);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 19;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.Location = new System.Drawing.Point(610, 483);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(75, 23);
            this.mainMenuButton.TabIndex = 18;
            this.mainMenuButton.Text = "Main Menu";
            this.mainMenuButton.UseVisualStyleBackColor = true;
            this.mainMenuButton.Click += new System.EventHandler(this.mainMenuButton_Click);
            // 
            // showAllButton
            // 
            this.showAllButton.Location = new System.Drawing.Point(432, 483);
            this.showAllButton.Name = "showAllButton";
            this.showAllButton.Size = new System.Drawing.Size(95, 23);
            this.showAllButton.TabIndex = 16;
            this.showAllButton.Text = "Show All Data";
            this.showAllButton.UseVisualStyleBackColor = true;
            this.showAllButton.Click += new System.EventHandler(this.showAllButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(531, 483);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(74, 23);
            this.refreshButton.TabIndex = 17;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Search By Category";
            // 
            // categorySearchComboBox
            // 
            this.categorySearchComboBox.FormattingEnabled = true;
            this.categorySearchComboBox.Items.AddRange(new object[] {
            "Desktop",
            "Laptop",
            "Monitor",
            "Printer",
            "Smartboard",
            "Projector",
            "Tablet",
            "Accessories",
            "Webber",
            "Active",
            "Inactive",
            "Repair",
            "Surplus",
            "Unknown",
            "Office",
            "District",
            "MPR",
            "Library",
            "K1",
            "K2",
            "A1",
            "A2",
            "A3",
            "A4",
            "B1",
            "B2",
            "B3",
            "B4",
            "C1",
            "C2",
            "C3",
            "C4",
            "D1",
            "D2",
            "D3",
            "D4",
            "E1",
            "E2",
            "E3",
            "E4",
            "F1",
            "F2",
            "F3",
            "F4",
            "Other"});
            this.categorySearchComboBox.Location = new System.Drawing.Point(533, 265);
            this.categorySearchComboBox.Name = "categorySearchComboBox";
            this.categorySearchComboBox.Size = new System.Drawing.Size(154, 21);
            this.categorySearchComboBox.TabIndex = 14;
            // 
            // findButton
            // 
            this.findButton.BackColor = System.Drawing.SystemColors.Control;
            this.findButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.findButton.Location = new System.Drawing.Point(690, 263);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 15;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // printPreviewDialogSearch
            // 
            this.printPreviewDialogSearch.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialogSearch.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialogSearch.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialogSearch.Document = this.printDocumentSearch;
            this.printPreviewDialogSearch.Enabled = true;
            this.printPreviewDialogSearch.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialogSearch.Icon")));
            this.printPreviewDialogSearch.Name = "printPreviewDialogSearch";
            this.printPreviewDialogSearch.Visible = false;
            // 
            // printDocumentSearch
            // 
            this.printDocumentSearch.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentSearch_PrintPage);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(351, 483);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 20;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // SearchInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(787, 517);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.categorySearchComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.showAllButton);
            this.Controls.Add(this.mainMenuButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.updateGroupBox);
            this.Controls.Add(this.removeGroupBox);
            this.Controls.Add(this.searchGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchInventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search and Update ";
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.updateGroupBox.ResumeLayout(false);
            this.updateGroupBox.PerformLayout();
            this.update2GroupBox.ResumeLayout(false);
            this.update2GroupBox.PerformLayout();
            this.removeGroupBox.ResumeLayout(false);
            this.removeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox updateGroupBox;
        private System.Windows.Forms.GroupBox removeGroupBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.GroupBox update2GroupBox;
        private System.Windows.Forms.ComboBox updateLocationComboBox;
        private System.Windows.Forms.Label newLabel;
        private System.Windows.Forms.Label tagLabel;
        private System.Windows.Forms.ComboBox updateStatusComboBox;
        private System.Windows.Forms.Button clearRemoveButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label removeTagLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button mainMenuButton;
        private System.Windows.Forms.Button showAllButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox categorySearchComboBox;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogSearch;
        private System.Drawing.Printing.PrintDocument printDocumentSearch;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.MaskedTextBox updateTagTextBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox removeTextBox;
        private System.Windows.Forms.RadioButton statusRadioButton;
        private System.Windows.Forms.RadioButton locationRadioButton;
    }
}