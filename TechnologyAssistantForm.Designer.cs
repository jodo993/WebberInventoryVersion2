namespace Webber_Inventory_Search_2017_2018
{
    partial class TechnologyAssistantForm
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
            this.programComboBox = new System.Windows.Forms.ComboBox();
            this.issueComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // programComboBox
            // 
            this.programComboBox.FormattingEnabled = true;
            this.programComboBox.Location = new System.Drawing.Point(39, 63);
            this.programComboBox.Name = "programComboBox";
            this.programComboBox.Size = new System.Drawing.Size(150, 21);
            this.programComboBox.TabIndex = 5;
            this.programComboBox.SelectedIndexChanged += new System.EventHandler(this.programComboBox_SelectedIndexChanged);
            // 
            // issueComboBox
            // 
            this.issueComboBox.FormattingEnabled = true;
            this.issueComboBox.Location = new System.Drawing.Point(257, 63);
            this.issueComboBox.Name = "issueComboBox";
            this.issueComboBox.Size = new System.Drawing.Size(200, 21);
            this.issueComboBox.TabIndex = 6;
            this.issueComboBox.SelectedIndexChanged += new System.EventHandler(this.issueComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Instructions";
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.Location = new System.Drawing.Point(301, 335);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(75, 23);
            this.mainMenuButton.TabIndex = 8;
            this.mainMenuButton.Text = "Main Menu";
            this.mainMenuButton.UseVisualStyleBackColor = true;
            this.mainMenuButton.Click += new System.EventHandler(this.mainMenuButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(382, 335);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Program";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Issues";
            // 
            // instructionLabel
            // 
            this.instructionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.instructionLabel.Location = new System.Drawing.Point(39, 114);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(418, 218);
            this.instructionLabel.TabIndex = 12;
            // 
            // TechnologyAssistantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 380);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.mainMenuButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.issueComboBox);
            this.Controls.Add(this.programComboBox);
            this.Name = "TechnologyAssistantForm";
            this.Text = "Technology Assistant";
            this.Load += new System.EventHandler(this.TechnologyAssistantForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox programComboBox;
        private System.Windows.Forms.ComboBox issueComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mainMenuButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label instructionLabel;
    }
}