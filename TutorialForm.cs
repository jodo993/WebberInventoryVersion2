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
    public partial class TutorialForm : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public TutorialForm()
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

            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TutorialForm_Load(object sender, EventArgs e)
        {
            connection.Open();

            // Create command for each tab
            OleDbCommand commandWord = new OleDbCommand();
            commandWord.Connection = connection;

            OleDbCommand commandExcel = new OleDbCommand();
            commandExcel.Connection = connection;

            OleDbCommand commandPP = new OleDbCommand();
            commandPP.Connection = connection;

            OleDbCommand commandOutlook = new OleDbCommand();
            commandOutlook.Connection = connection;

            OleDbCommand commandGoogle = new OleDbCommand();
            commandGoogle.Connection = connection;

            // What does command do
            string wordQuery = "select Topic from Tutorial_Word";
            string excelQuery = "select Topic from Tutorial_Excel";
            string powerpointQuery = "select Topic from Tutorial_Powerpoint";
            string outlookQuery = "select Topic from Tutorial_Outlook";
            string googleQuery = "select Topic from Tutorial_Google";

            commandWord.CommandText = wordQuery;
            commandExcel.CommandText = excelQuery;
            commandPP.CommandText = powerpointQuery;
            commandOutlook.CommandText = outlookQuery;
            commandGoogle.CommandText = googleQuery;

            // Read the topic column of each table and put them in corresponding list boxes
            OleDbDataReader readerWord = commandWord.ExecuteReader();
            OleDbDataReader readerExcel = commandExcel.ExecuteReader();
            OleDbDataReader readerPP = commandPP.ExecuteReader();
            OleDbDataReader readerOutlook = commandOutlook.ExecuteReader();
            OleDbDataReader readerGoogle = commandGoogle.ExecuteReader();

            while (readerWord.Read())
            {
                wordListBox.Items.Add(readerWord["Topic"].ToString());
            }

            while (readerExcel.Read())
            {
                excelListBox.Items.Add(readerExcel["Topic"].ToString());
            }

            while (readerPP.Read())
            {
                powerpointListBox.Items.Add(readerPP["Topic"].ToString());
            }

            while (readerOutlook.Read())
            {
                outlookListBox.Items.Add(readerOutlook["Topic"].ToString());
            }

            while (readerGoogle.Read())
            {
                googleListBox.Items.Add(readerGoogle["Topic"].ToString());
            }

            connection.Close();
        }

        // Show the instruction that corresponds to the selected topic
        private void wordListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Tutorial_Word where Topic='" + wordListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stepByStepLabel.Text = reader["Instructions"].ToString();
            }

            connection.Close();
        }

        private void wordAddButton_Click(object sender, EventArgs e)
        {
            string topic = wordTopicTextBox.Text;
            string instructions = wordInstructionTextBox.Text;

            if (topic == "" && instructions == "")
                MessageBox.Show("Please enter a topic and instructions.");
            else
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "insert into Tutorial_Word (Topic,Instructions) values('" + topic + "','" + instructions + "')";
                command.CommandText = query;
                command.ExecuteNonQuery();

                MessageBox.Show("Tutorial Part was successfully added.");

                connection.Close();

                // Clear boxes
                wordTopicTextBox.Text = "";
                wordInstructionTextBox.Text = "";
            }
        }
    }
}
