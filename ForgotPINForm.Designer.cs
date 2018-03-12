namespace Webber_Inventory_Search_2017_2018
{
    partial class ForgotPINForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPINForm));
            this.goButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.securityQuestionLabel = new System.Windows.Forms.Label();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(333, 24);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 22);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "What is your first name?";
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(333, 222);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(75, 22);
            this.checkButton.TabIndex = 5;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(162, 26);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(165, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Security Question";
            // 
            // securityQuestionLabel
            // 
            this.securityQuestionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.securityQuestionLabel.Location = new System.Drawing.Point(42, 173);
            this.securityQuestionLabel.Name = "securityQuestionLabel";
            this.securityQuestionLabel.Size = new System.Drawing.Size(366, 23);
            this.securityQuestionLabel.TabIndex = 6;
            // 
            // answerTextBox
            // 
            this.answerTextBox.Location = new System.Drawing.Point(42, 223);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(285, 20);
            this.answerTextBox.TabIndex = 4;
            this.answerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.answerTextBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Answer";
            // 
            // nameListBox
            // 
            this.nameListBox.FormattingEnabled = true;
            this.nameListBox.Location = new System.Drawing.Point(42, 68);
            this.nameListBox.Name = "nameListBox";
            this.nameListBox.Size = new System.Drawing.Size(366, 82);
            this.nameListBox.TabIndex = 3;
            this.nameListBox.SelectedIndexChanged += new System.EventHandler(this.nameListBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Select Last Name -";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "1.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "3.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "2.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ForgotPINForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 262);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nameListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.securityQuestionLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ForgotPINForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Forgot PIN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label securityQuestionLabel;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox nameListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}