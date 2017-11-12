﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Webber_Inventory_Search_2017_2018
{
    public partial class TicketForm : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public TicketForm()
        {
            InitializeComponent();

            // Connect to database                                                       
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase_be.accdb;Persist Security Info=False;";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
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

                                        connection.Close();
                                        MessageBox.Show("Ticket was successfully submitted. Ticket number is ");
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
            catch (Exception ex)
            {
                MessageBox.Show("Bug Splat! Please exit and try again." + ex);
            }
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.ShowDialog();

            this.Close();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {

        }
    }
}
