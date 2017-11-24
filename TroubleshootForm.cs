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

namespace Webber_Inventory_Search_2017_2018
{
    public partial class TroubleshootForm : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public TroubleshootForm()
        {
            InitializeComponent();

            // Connect to database                                                       
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase_be.accdb;Persist Security Info=False;";
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.ShowDialog();

            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            connection.Open();

            string search = problemTextBox.Text;

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Troubleshoot_Data where Issue like=" + search + "";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                solutionListBox.Text = reader["Issue"].ToString();
            }

            connection.Close();
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            //connection.Open();

            //int search = int.Parse(searchTextBox.Text);

            //OleDbCommand command = new OleDbCommand();
            //command.Connection = connection;
            //string query = "select * from Main_Inventory where Tag=" + search + "";
            //command.CommandText = query;

            //connection.Close();
        }
    }
}
