using System;
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
    public partial class BugSplatForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Webber Database\WebberMainDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        public BugSplatForm(string pg,string btn,string ex)
        {
            InitializeComponent();
            nameLabel.Text = pg;
            buttonLabel.Text = btn;
            descLabel.Text = ex;
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
                string fix = "";

                // If user entered input transfer here
                if (nameTextBox.Text != "")
                    name = nameTextBox.Text;
                if (descriptionTextBox.Text != "")
                    description = descriptionTextBox.Text;

                // Check to see if connection is open, close if it is
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into Exception_Error_Report (Page,Button,Error,Person,Description,Status,Fix) values('" + page + "','" + button + "','" + bugInformation + "','" + name + "','" + description + "','" + status + "','" + fix + "')";
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
