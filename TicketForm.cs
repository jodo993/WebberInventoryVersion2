using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;

namespace Webber_Inventory_Search_2017_2018
{
    public partial class TicketForm : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public TicketForm(string user)
        {
            InitializeComponent();
            userLabel.Text = user;
            // Connect to database    
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase.accdb;Jet OLEDB:Database Password=p4aB63mCK7;";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (staffTextBox.Text != "" && staffTextBox.Text.All(Char.IsLetter))
                if (roomTextBox.Text != "")
                    if (importanceComboBox.Text != "" && importanceComboBox.Text == "Low - Inconvenient" || importanceComboBox.Text == "Medium - Moderate impairment"
                        || importanceComboBox.Text == "High - Urgent fix(es) required")
                        if (categoryComboBox.Text != "" && categoryComboBox.Text == "Instructional Assistance" || categoryComboBox.Text == "Hardware Issue" ||
                            categoryComboBox.Text == "Software Issue" || categoryComboBox.Text == "Chromebook" || categoryComboBox.Text == "Network" ||
                            categoryComboBox.Text == "Other")
                            if (timeComboBox.Text != "" && timeComboBox.Text == "Before School" || timeComboBox.Text == "8-9AM" || timeComboBox.Text == "9-10AM" ||
                                timeComboBox.Text == "10-11AM" || timeComboBox.Text == "11-12PM" || timeComboBox.Text == "1-2PM" || timeComboBox.Text == "After School")
                                if (descriptionTextBox.Text != "")
                                {
                                    try
                                    {
                                        // Date is automatically added
                                        string staff = staffTextBox.Text;
                                        string room = roomTextBox.Text;
                                        string importance = importanceComboBox.Text;
                                        string category = categoryComboBox.Text;
                                        string time = timeComboBox.Text;
                                        string description = descriptionTextBox.Text;
                                        string status = "Open";

                                        connection.Open();

                                        OleDbCommand command = new OleDbCommand();
                                        command.Connection = connection;
                                        command.CommandText = "insert into Help_Ticket (Staff,Room,Importance,Category,TimePreferred,Description,Status) values('" + staff + "','" + room + "','" + importance + "','" + category + "','" + time + "','" + description + "','" + status + "')";
                                        command.ExecuteNonQuery();

                                        // Create array
                                        string[] idList = new string[2000];
                                        int i = 0;

                                        // Which table to search for data
                                        string query = "select * from Help_Ticket";
                                        command.CommandText = query;

                                        // Read the data
                                        OleDbDataReader reader = command.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            idList[i] = reader["ID"].ToString();
                                            i++;
                                        }

                                        connection.Close();

                                        MessageBox.Show("Ticket was successfully submitted. Ticket number is #" + i + ". Ticket number will allow you to check on the ticket current status.");
                                    }
                                    catch (Exception ex)
                                    {
                                        // Get and send information to bug report
                                        string page = "Ticket";
                                        string button = "Submit";
                                        string exception = ex.ToString();
                                        BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                                        bugSplat.ShowDialog();

                                        this.Close();
                                    }
                                }
                                else
                                    MessageBox.Show("Please enter a brief description of the problem.");
                            else
                                MessageBox.Show("Please select a valid time.");
                        else
                            MessageBox.Show("Please select one of the given issue choices.");
                    else
                        MessageBox.Show("Please select a valid urgency status.");
                else
                    MessageBox.Show("Please enter the location of the problem.");
            else
                MessageBox.Show("Please enter a valid name.");
        }

        // Clear all fields
        private void clearButton_Click(object sender, EventArgs e)
        {
            staffTextBox.Text = "";
            roomTextBox.Text = "";
            importanceComboBox.Text = "";
            categoryComboBox.Text = "";
            timeComboBox.Text = "";
            descriptionTextBox.Text = "";
        }

        // Get ticket number and find the information of the ticket
        private void checkButton_Click(object sender, EventArgs e)
        {
            string ticketNumber = ticketNumberTextBox.Text;

            if (ticketNumber == "")
            {
                MessageBox.Show("Please enter your ticket number.");
            }
            else
            {
                ticketNumber = ticketNumber.Trim();
                CheckDigitClass checkDigit = new CheckDigitClass();
                bool digit = checkDigit.digitOnly(ticketNumber);

                if (digit == true)
                {
                    try
                    {
                        connection.Open();

                        // Which table to search for data
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "select * from Help_Ticket";
                        command.CommandText = query;

                        //List<string> idCheck = new List<string>();
                        string[] idCheck = new string[2000];
                        int i = 0;
                        bool found = false;

                        // Read the data
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            idCheck[i] = reader["ID"].ToString();
                            if (idCheck[i] == ticketNumber)
                            {
                                string status = reader["Status"].ToString();
                                string plannedFix = reader["PlannedFixDate"].ToString();
                                found = true;
                                if (plannedFix != "")
                                    statusLabel.Text = "Ticket #" + ticketNumber + " is currently " + status + ". Estimated day for ticket appointment is " + plannedFix + ".";
                                else
                                    statusLabel.Text = "Ticket #" + ticketNumber + " is currently " + status + ". Estimated day for ticket appointment is not yet known.";
                            }
                            i++;
                        }

                        connection.Close();

                        if (found == false)
                            MessageBox.Show("Ticket number was not found.");
                    }
                    catch (Exception ex)
                    {
                        // Get info for bug report
                        string page = "Ticket";
                        string button = "Check";
                        string exception = ex.ToString();
                        BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                        bugSplat.ShowDialog();

                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Ticket number must be digits only.");
            }
        }

        // Close the program
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Go back to main menu page depending on whether user was signed in as teacher or admin
        private void mainMenuButton_Click(object sender, EventArgs e)
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
    }
}
