namespace Webber_Inventory_Search_2017_2018
{
    partial class MainMenuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.chromebookButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Select an Option";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(74, 112);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(126, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add Inventory";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(74, 141);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(126, 35);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search/Update Inventory";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // chromebookButton
            // 
            this.chromebookButton.Location = new System.Drawing.Point(74, 83);
            this.chromebookButton.Name = "chromebookButton";
            this.chromebookButton.Size = new System.Drawing.Size(126, 23);
            this.chromebookButton.TabIndex = 3;
            this.chromebookButton.Text = "Manage Chromebook";
            this.chromebookButton.UseVisualStyleBackColor = true;
            this.chromebookButton.Click += new System.EventHandler(this.chromebookButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(74, 182);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(126, 23);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Log Out and Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 271);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.chromebookButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label1);
            this.Name = "MainMenuForm";
            this.Text = "Webber Inventory Search Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button chromebookButton;
        private System.Windows.Forms.Button quitButton;
    }
}