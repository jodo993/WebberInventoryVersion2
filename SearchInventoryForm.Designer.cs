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
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.updateGroupBox = new System.Windows.Forms.GroupBox();
            this.removeGroupBox = new System.Windows.Forms.GroupBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.updateLocationButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.updateTagTextBox = new System.Windows.Forms.TextBox();
            this.updateLocationComboBox = new System.Windows.Forms.ComboBox();
            this.locationCheckLabel = new System.Windows.Forms.Label();
            this.yesLocationButton = new System.Windows.Forms.Button();
            this.noLocationButton = new System.Windows.Forms.Button();
            this.noStatusButton = new System.Windows.Forms.Button();
            this.yesStatusButton = new System.Windows.Forms.Button();
            this.statusCheckLabel = new System.Windows.Forms.Label();
            this.updateStatusButton = new System.Windows.Forms.Button();
            this.updateStatusComboBox = new System.Windows.Forms.ComboBox();
            this.updateTag2TextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.clearRemoveButton = new System.Windows.Forms.Button();
            this.removeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.removeCheckLabel = new System.Windows.Forms.Label();
            this.yesRemoveButton = new System.Windows.Forms.Button();
            this.noRemoveButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchGroupBox.SuspendLayout();
            this.updateGroupBox.SuspendLayout();
            this.removeGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.clearButton);
            this.searchGroupBox.Controls.Add(this.searchButton);
            this.searchGroupBox.Controls.Add(this.label1);
            this.searchGroupBox.Controls.Add(this.searchTextBox);
            this.searchGroupBox.Location = new System.Drawing.Point(21, 38);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(150, 100);
            this.searchGroupBox.TabIndex = 0;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Search";
            // 
            // updateGroupBox
            // 
            this.updateGroupBox.Controls.Add(this.groupBox2);
            this.updateGroupBox.Controls.Add(this.groupBox1);
            this.updateGroupBox.Location = new System.Drawing.Point(186, 38);
            this.updateGroupBox.Name = "updateGroupBox";
            this.updateGroupBox.Size = new System.Drawing.Size(439, 206);
            this.updateGroupBox.TabIndex = 1;
            this.updateGroupBox.TabStop = false;
            this.updateGroupBox.Text = "Update";
            // 
            // removeGroupBox
            // 
            this.removeGroupBox.Controls.Add(this.clearRemoveButton);
            this.removeGroupBox.Controls.Add(this.removeButton);
            this.removeGroupBox.Controls.Add(this.removeTextBox);
            this.removeGroupBox.Controls.Add(this.label8);
            this.removeGroupBox.Location = new System.Drawing.Point(21, 144);
            this.removeGroupBox.Name = "removeGroupBox";
            this.removeGroupBox.Size = new System.Drawing.Size(150, 100);
            this.removeGroupBox.TabIndex = 1;
            this.removeGroupBox.TabStop = false;
            this.removeGroupBox.Text = "Remove";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(26, 42);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(100, 20);
            this.searchTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "WSD Tag Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(26, 68);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(51, 22);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(75, 68);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(51, 22);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // updateLocationButton
            // 
            this.updateLocationButton.Location = new System.Drawing.Point(9, 64);
            this.updateLocationButton.Name = "updateLocationButton";
            this.updateLocationButton.Size = new System.Drawing.Size(185, 25);
            this.updateLocationButton.TabIndex = 2;
            this.updateLocationButton.Text = "Update Location";
            this.updateLocationButton.UseVisualStyleBackColor = true;
            this.updateLocationButton.Click += new System.EventHandler(this.updateLocationButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noLocationButton);
            this.groupBox1.Controls.Add(this.yesLocationButton);
            this.groupBox1.Controls.Add(this.locationCheckLabel);
            this.groupBox1.Controls.Add(this.updateLocationButton);
            this.groupBox1.Controls.Add(this.updateLocationComboBox);
            this.groupBox1.Controls.Add(this.updateTagTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Location";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.noStatusButton);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.updateTag2TextBox);
            this.groupBox2.Controls.Add(this.yesStatusButton);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.updateStatusComboBox);
            this.groupBox2.Controls.Add(this.statusCheckLabel);
            this.groupBox2.Controls.Add(this.updateStatusButton);
            this.groupBox2.Location = new System.Drawing.Point(225, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 157);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tag Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "New Location";
            // 
            // updateTagTextBox
            // 
            this.updateTagTextBox.Location = new System.Drawing.Point(9, 38);
            this.updateTagTextBox.Name = "updateTagTextBox";
            this.updateTagTextBox.Size = new System.Drawing.Size(87, 20);
            this.updateTagTextBox.TabIndex = 2;
            // 
            // updateLocationComboBox
            // 
            this.updateLocationComboBox.FormattingEnabled = true;
            this.updateLocationComboBox.Items.AddRange(new object[] {
            "Office",
            "District",
            "MPR",
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
            this.updateLocationComboBox.Location = new System.Drawing.Point(104, 38);
            this.updateLocationComboBox.Name = "updateLocationComboBox";
            this.updateLocationComboBox.Size = new System.Drawing.Size(90, 21);
            this.updateLocationComboBox.TabIndex = 3;
            // 
            // locationCheckLabel
            // 
            this.locationCheckLabel.AutoSize = true;
            this.locationCheckLabel.Location = new System.Drawing.Point(18, 101);
            this.locationCheckLabel.Name = "locationCheckLabel";
            this.locationCheckLabel.Size = new System.Drawing.Size(166, 13);
            this.locationCheckLabel.TabIndex = 4;
            this.locationCheckLabel.Text = "Are you sure you want to update?";
            this.locationCheckLabel.Visible = false;
            // 
            // yesLocationButton
            // 
            this.yesLocationButton.Location = new System.Drawing.Point(21, 119);
            this.yesLocationButton.Name = "yesLocationButton";
            this.yesLocationButton.Size = new System.Drawing.Size(75, 23);
            this.yesLocationButton.TabIndex = 5;
            this.yesLocationButton.Text = "Yes";
            this.yesLocationButton.UseVisualStyleBackColor = true;
            this.yesLocationButton.Visible = false;
            this.yesLocationButton.Click += new System.EventHandler(this.yesLocationButton_Click);
            // 
            // noLocationButton
            // 
            this.noLocationButton.Location = new System.Drawing.Point(105, 119);
            this.noLocationButton.Name = "noLocationButton";
            this.noLocationButton.Size = new System.Drawing.Size(75, 23);
            this.noLocationButton.TabIndex = 6;
            this.noLocationButton.Text = "No";
            this.noLocationButton.UseVisualStyleBackColor = true;
            this.noLocationButton.Visible = false;
            this.noLocationButton.Click += new System.EventHandler(this.noLocationButton_Click);
            // 
            // noStatusButton
            // 
            this.noStatusButton.Location = new System.Drawing.Point(105, 119);
            this.noStatusButton.Name = "noStatusButton";
            this.noStatusButton.Size = new System.Drawing.Size(75, 23);
            this.noStatusButton.TabIndex = 14;
            this.noStatusButton.Text = "No";
            this.noStatusButton.UseVisualStyleBackColor = true;
            this.noStatusButton.Visible = false;
            this.noStatusButton.Click += new System.EventHandler(this.noStatusButton_Click);
            // 
            // yesStatusButton
            // 
            this.yesStatusButton.Location = new System.Drawing.Point(21, 119);
            this.yesStatusButton.Name = "yesStatusButton";
            this.yesStatusButton.Size = new System.Drawing.Size(75, 23);
            this.yesStatusButton.TabIndex = 13;
            this.yesStatusButton.Text = "Yes";
            this.yesStatusButton.UseVisualStyleBackColor = true;
            this.yesStatusButton.Visible = false;
            this.yesStatusButton.Click += new System.EventHandler(this.yesStatusButton_Click);
            // 
            // statusCheckLabel
            // 
            this.statusCheckLabel.AutoSize = true;
            this.statusCheckLabel.Location = new System.Drawing.Point(18, 101);
            this.statusCheckLabel.Name = "statusCheckLabel";
            this.statusCheckLabel.Size = new System.Drawing.Size(166, 13);
            this.statusCheckLabel.TabIndex = 12;
            this.statusCheckLabel.Text = "Are you sure you want to update?";
            this.statusCheckLabel.Visible = false;
            // 
            // updateStatusButton
            // 
            this.updateStatusButton.Location = new System.Drawing.Point(9, 64);
            this.updateStatusButton.Name = "updateStatusButton";
            this.updateStatusButton.Size = new System.Drawing.Size(185, 25);
            this.updateStatusButton.TabIndex = 9;
            this.updateStatusButton.Text = "Update Status";
            this.updateStatusButton.UseVisualStyleBackColor = true;
            this.updateStatusButton.Click += new System.EventHandler(this.updateStatusButton_Click);
            // 
            // updateStatusComboBox
            // 
            this.updateStatusComboBox.FormattingEnabled = true;
            this.updateStatusComboBox.Items.AddRange(new object[] {
            "Office",
            "District",
            "MPR",
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
            this.updateStatusComboBox.Location = new System.Drawing.Point(104, 38);
            this.updateStatusComboBox.Name = "updateStatusComboBox";
            this.updateStatusComboBox.Size = new System.Drawing.Size(90, 21);
            this.updateStatusComboBox.TabIndex = 11;
            // 
            // updateTag2TextBox
            // 
            this.updateTag2TextBox.Location = new System.Drawing.Point(9, 38);
            this.updateTag2TextBox.Name = "updateTag2TextBox";
            this.updateTag2TextBox.Size = new System.Drawing.Size(87, 20);
            this.updateTag2TextBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "New Location";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tag Number";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(26, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "WSD Tag Number";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(26, 70);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(51, 23);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // clearRemoveButton
            // 
            this.clearRemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearRemoveButton.Location = new System.Drawing.Point(75, 70);
            this.clearRemoveButton.Name = "clearRemoveButton";
            this.clearRemoveButton.Size = new System.Drawing.Size(51, 23);
            this.clearRemoveButton.TabIndex = 8;
            this.clearRemoveButton.Text = "Clear";
            this.clearRemoveButton.UseVisualStyleBackColor = true;
            this.clearRemoveButton.Click += new System.EventHandler(this.clearRemoveButton_Click);
            // 
            // removeTextBox
            // 
            this.removeTextBox.Location = new System.Drawing.Point(26, 44);
            this.removeTextBox.Name = "removeTextBox";
            this.removeTextBox.Size = new System.Drawing.Size(100, 20);
            this.removeTextBox.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.noRemoveButton);
            this.groupBox3.Controls.Add(this.removeCheckLabel);
            this.groupBox3.Controls.Add(this.yesRemoveButton);
            this.groupBox3.Location = new System.Drawing.Point(21, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Verification";
            this.groupBox3.Visible = false;
            // 
            // removeCheckLabel
            // 
            this.removeCheckLabel.Location = new System.Drawing.Point(6, 16);
            this.removeCheckLabel.Name = "removeCheckLabel";
            this.removeCheckLabel.Size = new System.Drawing.Size(138, 45);
            this.removeCheckLabel.TabIndex = 0;
            this.removeCheckLabel.Text = "This will remove all data about this item. Are you sure you want to remove?";
            this.removeCheckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.removeCheckLabel.Visible = false;
            // 
            // yesRemoveButton
            // 
            this.yesRemoveButton.Location = new System.Drawing.Point(26, 64);
            this.yesRemoveButton.Name = "yesRemoveButton";
            this.yesRemoveButton.Size = new System.Drawing.Size(51, 23);
            this.yesRemoveButton.TabIndex = 1;
            this.yesRemoveButton.Text = "Yes";
            this.yesRemoveButton.UseVisualStyleBackColor = true;
            this.yesRemoveButton.Visible = false;
            this.yesRemoveButton.Click += new System.EventHandler(this.yesRemoveButton_Click);
            // 
            // noRemoveButton
            // 
            this.noRemoveButton.Location = new System.Drawing.Point(75, 64);
            this.noRemoveButton.Name = "noRemoveButton";
            this.noRemoveButton.Size = new System.Drawing.Size(51, 23);
            this.noRemoveButton.TabIndex = 3;
            this.noRemoveButton.Text = "No";
            this.noRemoveButton.UseVisualStyleBackColor = true;
            this.noRemoveButton.Visible = false;
            this.noRemoveButton.Click += new System.EventHandler(this.noRemoveButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(267, 314);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // SearchInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 476);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.updateGroupBox);
            this.Controls.Add(this.removeGroupBox);
            this.Controls.Add(this.searchGroupBox);
            this.Name = "SearchInventoryForm";
            this.Text = "SearchInventoryForm";
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.updateGroupBox.ResumeLayout(false);
            this.removeGroupBox.ResumeLayout(false);
            this.removeGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.GroupBox updateGroupBox;
        private System.Windows.Forms.GroupBox removeGroupBox;
        private System.Windows.Forms.Button updateLocationButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox updateLocationComboBox;
        private System.Windows.Forms.TextBox updateTagTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button noStatusButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox updateTag2TextBox;
        private System.Windows.Forms.Button yesStatusButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox updateStatusComboBox;
        private System.Windows.Forms.Label statusCheckLabel;
        private System.Windows.Forms.Button updateStatusButton;
        private System.Windows.Forms.Button noLocationButton;
        private System.Windows.Forms.Button yesLocationButton;
        private System.Windows.Forms.Label locationCheckLabel;
        private System.Windows.Forms.Button clearRemoveButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.TextBox removeTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button noRemoveButton;
        private System.Windows.Forms.Label removeCheckLabel;
        private System.Windows.Forms.Button yesRemoveButton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}