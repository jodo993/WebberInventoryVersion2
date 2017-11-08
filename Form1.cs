using System;
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

        private void signButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Correct username and password needed to login
                String correctUsername = "web";
                String correctPassword = "paw";

                // Username and password user entered
                String enteredUsername = usernameTextBox.Text;
                String enteredPassword = passwordTextBox.Text;

                if (correctUsername == enteredUsername && correctPassword == enteredPassword)
                {
                    // Hide login form
                    this.Hide();

                    // Display main menu form if correct information is entered
                    MainMenuForm newMainMenuForm = new MainMenuForm();
                    newMainMenuForm.ShowDialog();

                    // Close login form after
                    this.Close();
                }
                else
                {
                    // Tell user login information is wrong
                    incorrectLoginLabel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please exit and try again.");
            }
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear all fields
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            incorrectLoginLabel.Visible = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Exit the program
            this.Close();
        }
    }
}
