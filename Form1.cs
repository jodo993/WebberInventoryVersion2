﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webber_Inventory_Search_2017_2018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void teacherButton_Click(object sender, EventArgs e)
        {
            webberLabel.ForeColor = Color.FromArgb(0, 0, 64);
            elementaryLabel.ForeColor = Color.FromArgb(0, 0, 64);
            teacherPictureBox.Visible = true;
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;

            teacherButton.Visible = false;
            adminButton.Visible = false;
            teacherPasswordTextbox.Visible = true;
            passLabel.Visible = true;
            signButton.Visible = true;
            clearButton.Visible = true;
            backButton.Visible = true;
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            teacherButton.Visible = false;
            adminButton.Visible = false;
            adminPasswordTextBox.Visible = true;
            passLabel.Visible = true;
            signButton.Visible = true;
            clearButton.Visible = true;
            backButton.Visible = true;
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            string teacherPassword = teacherPasswordTextbox.Text;
            string adminPassword = adminPasswordTextBox.Text;

            if (teacherPassword == "web")
            {
                // Hide login form
                this.Hide();

                // Display main menu form if correct information is entered
                MainMenuForm2 newMainMenuForm2 = new MainMenuForm2();
                newMainMenuForm2.ShowDialog();

                // Close login form after
                this.Close();
            }
            else if (adminPassword == "webber")
            {
                this.Hide();

                MainMenuForm newMainMenuForm = new MainMenuForm();
                newMainMenuForm.ShowDialog();

                this.Close();
            }
            else
                incorrectLoginLabel.Visible = true;

            //// Username and password user entered
            //string enteredUsername = usernameTextBox.Text;
            //string enteredPassword = passwordTextBox.Text;

            //// Correct username and password for TEACHERS
            //string teacherUsername = "teach";
            //string teacherPassword = "web";

            //// Correct username and password for ADMINS
            //string adminUsername = "admin";
            //string adminPassword = "webber";

            //if (enteredUsername == teacherUsername && enteredPassword == teacherPassword)
            //{
            //    // Hide login form
            //    this.Hide();

            //    // Display main menu form if correct information is entered
            //    MainMenuForm2 newMainMenuForm2 = new MainMenuForm2();
            //    newMainMenuForm2.ShowDialog();

            //    // Close login form after
            //    this.Close();
            //}
            //else if (enteredUsername == adminUsername && enteredPassword == adminPassword)
            //{
            //    this.Hide();

            //    MainMenuForm newMainMenuForm = new MainMenuForm();
            //    newMainMenuForm.ShowDialog();

            //    this.Close();
            //}
            //else
            //{
            //    // Tell user login information is wrong
            //    incorrectLoginLabel.Visible = true;
            //}
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear all fields
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            incorrectLoginLabel.Visible = false;
            teacherPasswordTextbox.Text = "";
            adminPasswordTextBox.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Exit the program
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            webberLabel.ForeColor = Color.FromArgb(100, 0, 0);
            elementaryLabel.ForeColor = Color.FromArgb(100, 0, 0);
            adminPictureBox.Visible = true;
            teacherPictureBox.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            
            passLabel.Visible = false;
            teacherPasswordTextbox.Visible = false;
            adminPasswordTextBox.Visible = false;
            signButton.Visible = false;
            clearButton.Visible = false;
            backButton.Visible = false;
            incorrectLoginLabel.Visible = false;
            teacherButton.Visible = true;
            adminButton.Visible = true;
        }

        private void teacherPasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signButton.PerformClick();
            }
        }

        private void adminPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signButton.PerformClick();
            }
        }
    }
}
