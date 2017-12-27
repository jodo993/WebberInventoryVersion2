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
    public partial class BugSplatForm : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public BugSplatForm(string pg,string btn,string ex)
        {
            InitializeComponent();
            nameLabel.Text = pg;
            buttonLabel.Text = btn;
            descLabel.Text = ex;

            // Connect to database              
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase_be.accdb;Persist Security Info=False;";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = "";
                string description = "";
                string page = nameLabel.Text;
                string button = buttonLabel.Text;
                string bugInformation = descLabel.Text;
                string status = "Open";

                // If user entered input transfer here
                if (nameTextBox.Text != "")
                    name = nameTextBox.Text;
                if (descriptionTextBox.Text != "")
                    description = descriptionTextBox.Text;

                // Check to see if connection is open, close if it is
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into Exception_Error_Report (Page,Button,Error,Person,PersonDescription,Status,Fix,FixDate) values('" + page + "','" + button + "','" + bugInformation + "','" + name + "','" + description + "','" + status + "', '" + "" + "', '" + "" + "')";
                command.ExecuteNonQuery();

                connection.Close();

                this.Close();
            }
            catch (Exception)
            {
                // Close the connection and program
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                this.Close();
            }
        }
    }
}
