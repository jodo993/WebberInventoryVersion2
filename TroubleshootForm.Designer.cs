namespace Webber_Inventory_Search_2017_2018
{
    partial class TroubleshootForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TroubleshootForm));
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.problemTextBox = new System.Windows.Forms.TextBox();
            this.solutionListBox = new System.Windows.Forms.ListBox();
            this.solutionLabel = new System.Windows.Forms.Label();
            this.showAllButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.explanationLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuButton.Location = new System.Drawing.Point(454, 516);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(80, 25);
            this.mainMenuButton.TabIndex = 5;
            this.mainMenuButton.Text = "Main Menu";
            this.mainMenuButton.UseVisualStyleBackColor = true;
            this.mainMenuButton.Click += new System.EventHandler(this.mainMenuButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(544, 516);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 25);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(390, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Possible Solution(s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description of Problem";
            // 
            // problemTextBox
            // 
            this.problemTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.problemTextBox.Location = new System.Drawing.Point(22, 66);
            this.problemTextBox.Name = "problemTextBox";
            this.problemTextBox.Size = new System.Drawing.Size(204, 22);
            this.problemTextBox.TabIndex = 1;
            // 
            // solutionListBox
            // 
            this.solutionListBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solutionListBox.FormattingEnabled = true;
            this.solutionListBox.ItemHeight = 14;
            this.solutionListBox.Location = new System.Drawing.Point(22, 94);
            this.solutionListBox.Name = "solutionListBox";
            this.solutionListBox.Size = new System.Drawing.Size(257, 410);
            this.solutionListBox.TabIndex = 3;
            this.solutionListBox.SelectedIndexChanged += new System.EventHandler(this.solutionListBox_SelectedIndexChanged);
            // 
            // solutionLabel
            // 
            this.solutionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.solutionLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solutionLabel.Location = new System.Drawing.Point(285, 184);
            this.solutionLabel.Name = "solutionLabel";
            this.solutionLabel.Size = new System.Drawing.Size(334, 321);
            this.solutionLabel.TabIndex = 10;
            // 
            // showAllButton
            // 
            this.showAllButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAllButton.Location = new System.Drawing.Point(184, 516);
            this.showAllButton.Name = "showAllButton";
            this.showAllButton.Size = new System.Drawing.Size(95, 25);
            this.showAllButton.TabIndex = 4;
            this.showAllButton.Text = "Show All Issues";
            this.showAllButton.UseVisualStyleBackColor = true;
            this.showAllButton.Click += new System.EventHandler(this.showAllButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(226, 65);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(53, 25);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(18, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "* For best results, avoid punctuations and contractions. ";
            // 
            // explanationLabel
            // 
            this.explanationLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.explanationLabel.Location = new System.Drawing.Point(285, 65);
            this.explanationLabel.Name = "explanationLabel";
            this.explanationLabel.Size = new System.Drawing.Size(334, 86);
            this.explanationLabel.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(401, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "Possible Cause";
            // 
            // TroubleshootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 554);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.explanationLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.showAllButton);
            this.Controls.Add(this.solutionLabel);
            this.Controls.Add(this.solutionListBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.problemTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.mainMenuButton);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TroubleshootForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Troubleshoot Guide";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mainMenuButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox problemTextBox;
        private System.Windows.Forms.ListBox solutionListBox;
        private System.Windows.Forms.Label solutionLabel;
        private System.Windows.Forms.Button showAllButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label explanationLabel;
        private System.Windows.Forms.Label label4;
    }
}