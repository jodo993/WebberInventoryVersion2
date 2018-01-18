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
            // Username and password user entered
            string enteredUsername = usernameTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            // Correct username and password for TEACHERS
            string teacherUsername = "teach";
            string teacherPassword = "web";

            // Correct username and password for ADMINS
            string adminUsername = "admin";
            string adminPassword = "webber";

            if (enteredUsername == teacherUsername && enteredPassword == teacherPassword)
            {
                // Hide login form
                this.Hide();

                // Display main menu form if correct information is entered
                MainMenuForm2 newMainMenuForm2 = new MainMenuForm2();
                newMainMenuForm2.ShowDialog();

                // Close login form after
                this.Close();
            }
            else if (enteredUsername == adminUsername && enteredPassword == adminPassword)
            {
                this.Hide();

                MainMenuForm newMainMenuForm = new MainMenuForm();
                newMainMenuForm.ShowDialog();

                this.Close();
            }
            else
            {
                // Tell user login information is wrong
                incorrectLoginLabel.Visible = true;
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
