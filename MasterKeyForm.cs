﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Webber_Inventory_Search_2017_2018
{
    public partial class MasterKeyForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Webber Database\WebberMainDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        public MasterKeyForm(string user)
        {
            InitializeComponent();
            userLabel.Text = user;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (userLabel.Text == "T")
            {
                MainMenuForm2 mainMenu2 = new MainMenuForm2();
                mainMenu2.ShowDialog();
            }
            else
            {
                MainMenuForm mainMenu = new MainMenuForm();
                mainMenu.ShowDialog();
            }

            this.Close();
        }

        private void registerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MasterKeyRegisterWarningForm register = new MasterKeyRegisterWarningForm();
            register.ShowDialog();
        }

        private bool CheckUsername(string name)
        {
            string recordFullName = "";
            string[] firstNameArray = new string[2500];
            string[] lastNameArray = new string[2500];
            int i = 0;

            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string query = "select * from Master_Key_Login";
                command.CommandText = query;

                // Get both names and add them together, return false if same
                SqlDataReader nameReader = command.ExecuteReader();
                while (nameReader.Read())
                {
                    firstNameArray[i] = nameReader["FirstName"].ToString();
                    lastNameArray[i] = nameReader["LastName"].ToString();
                    recordFullName = firstNameArray[i] + " " + lastNameArray[i];
                    if (recordFullName == name)
                    {
                        connection.Close();
                        return true;
                    }
                }
                connection.Close();
                return false;
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "Master Key";
                string button = "CheckUsername";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
            connection.Close();
            return false;
        }

        private bool CheckPrivateKey(string key)
        {
            string[] allKeys = new string[2500];
            int i = 0;

            // Read all data to check for existing key
            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Master_Key_Login";

                SqlDataReader keyReader = command.ExecuteReader();
                while (keyReader.Read())
                {
                    allKeys[i] = keyReader["PrivateKey"].ToString();
                    if (allKeys[i] == key)
                    {
                        connection.Close();
                        return true;
                    }
                }
                connection.Close();
                return false;
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "Master Key";
                string button = "CheckPrivateKey";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
            connection.Close();
            return false;
        }

        private bool ConfirmUser(string name, string key)
        {
            int keyPin = int.Parse(key);
            string[] allKeys = new string[2500];
            string[] firstName = new string[2500];
            string[] lastName = new string[2500];
            string fullName = "";
            int i = 0;

            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select FirstName,LastName from Master_Key_Login where PrivateKey=" + keyPin + "";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    firstName[i] = reader["FirstName"].ToString();
                    lastName[i] = reader["LastName"].ToString();
                    fullName = firstName[i] + " " + lastName[i];
                    if (fullName == name)
                    {
                        connection.Close();
                        return true;
                    }
                }
                connection.Close();
                return false;
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "Master Key";
                string button = "ConfirmUser";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
            connection.Close();
            return false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = nameTextBox.Text.ToUpper().Trim();
            string privateKey = privateKeyTextBox.Text.ToUpper();

            if (userName == "" || privateKey == "")
            {
                MessageBox.Show("You must enter a name and private key.");
            }
            else
            {
                try
                {
                    CheckDigitClass checkKey = new CheckDigitClass();
                    bool privateKeyIsDigit = checkKey.digitOnly(privateKey);
                    if (!privateKeyIsDigit)
                    {
                        MessageBox.Show("Your private key must be a four digit number.");
                        return;
                    }

                    bool correctName = CheckUsername(userName);
                    bool correctKey = CheckPrivateKey(privateKey);

                    if (correctName != true && correctKey != true)
                    {
                        MessageBox.Show("Full name or key does not exist. Please try again.");
                        return;
                    }
                    else
                    {
                        bool registeredUser = ConfirmUser(userName, privateKey);
                        if (registeredUser == false)
                        {
                            MessageBox.Show("Name and key does not match. Please try again.");
                            return;
                        }
                        else
                        {
                            this.Hide();

                            string user = userLabel.Text;
                            MasterKeyPasswordPage passwordPage = new MasterKeyPasswordPage(user, userName, privateKey);
                            passwordPage.ShowDialog();

                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login is disabled due to an unknown error. Please try again later or contact your administrator if the problem persists.");
                    // Send bug report
                    string page = "Master Key";
                    string button = "Login";
                    string exception = ex.ToString();
                    BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                    bugSplat.ShowDialog();

                    //this.Close();
                }
            }
        }

        // Show PIN form
        private void forgotPinLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPINForm forgotPin = new ForgotPINForm();
            forgotPin.ShowDialog();
        }

        private void privateKeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
            }
        }
    }
}
