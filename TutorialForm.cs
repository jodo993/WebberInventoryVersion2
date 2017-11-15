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

        public TutorialForm(string user)
        {
            InitializeComponent();
            userLabel.Text = user;
            // Connect to database                                                       
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase_be.accdb;Persist Security Info=False;";
        }

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

        // WORD TAB
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

                wordListBox.Items.Add(topic);

                // Clear boxes
                wordTopicTextBox.Text = "";
                wordInstructionTextBox.Text = "";
            }
        }

        // EXCEL TAB
        private void excelListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Tutorial_Excel where Topic='" + excelListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stepByStepLabel.Text = reader["Instructions"].ToString();
            }

            connection.Close();
        }

        private void excelAddButton_Click(object sender, EventArgs e)
        {
            string topic = excelTopicTextBox.Text;
            string instructions = excelInstructionTextBox.Text;

            if (topic == "" && instructions == "")
                MessageBox.Show("Please enter a topic and instructions.");
            else
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "insert into Tutorial_Excel (Topic,Instructions) values('" + topic + "','" + instructions + "')";
                command.CommandText = query;
                command.ExecuteNonQuery();

                MessageBox.Show("Tutorial Part was successfully added.");

                connection.Close();

                excelListBox.Items.Add(topic);

                // Clear boxes
                excelTopicTextBox.Text = "";
                excelInstructionTextBox.Text = "";
            }
        }

        // POWERPOINT TAB
        private void powerpointListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Tutorial_Powerpoint where Topic='" + powerpointListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stepByStepLabel.Text = reader["Instructions"].ToString();
            }

            connection.Close();
        }

        private void powerpointAddButton_Click(object sender, EventArgs e)
        {
            string topic = powerpointTopicTextBox.Text;
            string instructions = powerpointInstructionTextBox.Text;

            if (topic == "" && instructions == "")
                MessageBox.Show("Please enter a topic and instructions.");
            else
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "insert into Tutorial_Powerpoint (Topic,Instructions) values('" + topic + "','" + instructions + "')";
                command.CommandText = query;
                command.ExecuteNonQuery();

                MessageBox.Show("Tutorial Part was successfully added.");

                connection.Close();

                powerpointListBox.Items.Add(topic);

                // Clear boxes
                powerpointTopicTextBox.Text = "";
                powerpointInstructionTextBox.Text = "";
            }
        }

        // OUTLOOK TAB
        private void outlookListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Tutorial_Outlook where Topic='" + outlookListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stepByStepLabel.Text = reader["Instructions"].ToString();
            }

            connection.Close();
        }

        private void outlookAddButton_Click(object sender, EventArgs e)
        {
            string topic = outlookTopicTextBox.Text;
            string instructions = outlookInstructionTextBox.Text;

            if (topic == "" && instructions == "")
                MessageBox.Show("Please enter a topic and instructions.");
            else
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "insert into Tutorial_Outlook (Topic,Instructions) values('" + topic + "','" + instructions + "')";
                command.CommandText = query;
                command.ExecuteNonQuery();

                MessageBox.Show("Tutorial part was successfully added.");

                connection.Close();

                outlookListBox.Items.Add(topic);

                // Clear boxes
                outlookTopicTextBox.Text = "";
                outlookInstructionTextBox.Text = "";
            }
        }

        // GOOGLE TAB
        private void googleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Tutorial_Google where Topic='" + googleListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stepByStepLabel.Text = reader["Instructions"].ToString();
            }

            connection.Close();
        }

        private void googleAddButton_Click(object sender, EventArgs e)
        {
            string topic = googleTopicTextBox.Text;
            string instructions = googleInstructionTextBox.Text;

            if (topic == "" && instructions == "")
                MessageBox.Show("Please enter a topic and instructions.");
            else
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "insert into Tutorial_Google (Topic,Instructions) values('" + topic + "','" + instructions + "')";
                command.CommandText = query;
                command.ExecuteNonQuery();

                MessageBox.Show("Tutorial part was successfully added.");

                connection.Close();

                googleListBox.Items.Add(topic);

                // Clear boxes
                googleTopicTextBox.Text = "";
                googleInstructionTextBox.Text = "";
            }
        }

        // DELETE ENTRIES
        private void wordDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "delete from Tutorial_Word where Topic='" + wordListBox.SelectedItem + "'";
                command.CommandText = query;
                command.ExecuteNonQuery();

                MessageBox.Show("This topic and its instruction was deleted.");

                connection.Close();

                wordListBox.Items.Remove(wordListBox.SelectedItem);
                stepByStepLabel.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show("NO" + ex);
            }
            
        }

        private void excelDeleteButton_Click(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "delete from Tutorial_Excel where Topic='" + excelListBox.SelectedItem + "'";
            command.CommandText = query;
            command.ExecuteNonQuery();

            MessageBox.Show("This topic and its instruction was deleted.");

            connection.Close();

            excelListBox.Items.Remove(excelListBox.SelectedItem);
            stepByStepLabel.Text = "";
        }

        private void powerpointDeleteButton_Click(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "delete from Tutorial_Powerpoint where Topic='" + powerpointListBox.SelectedItem + "'";
            command.CommandText = query;
            command.ExecuteNonQuery();

            MessageBox.Show("This topic and its instruction was deleted.");

            connection.Close();

            powerpointListBox.Items.Remove(powerpointListBox.SelectedItem);
            stepByStepLabel.Text = "";
        }

        private void outlookDeleteButton_Click(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "delete from Tutorial_Outlook where Topic='" + outlookListBox.SelectedItem + "'";
            command.CommandText = query;
            command.ExecuteNonQuery();

            MessageBox.Show("This topic and its instruction was deleted.");

            connection.Close();

            outlookListBox.Items.Remove(outlookListBox.SelectedItem);
            stepByStepLabel.Text = "";
        }

        private void googleDeleteButton_Click(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "delete from Tutorial_Google where Topic='" + googleListBox.SelectedItem + "'";
            command.CommandText = query;
            command.ExecuteNonQuery();

            MessageBox.Show("This topic and its instruction was deleted.");

            connection.Close();

            googleListBox.Items.Remove(googleListBox.SelectedItem);
            stepByStepLabel.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string checkTime = maskedTextBox1.Text;
            if (checkBox1.Checked)
                if (checkTime == "24:24")
                {
                    wordDeleteButton.Visible = true;
                    excelDeleteButton.Visible = true;
                    powerpointDeleteButton.Visible = true;
                    outlookDeleteButton.Visible = true;
                    googleDeleteButton.Visible = true;
                }

            if (checkBox1.Checked == false)
            {
                wordDeleteButton.Visible = false;
                excelDeleteButton.Visible = false;
                powerpointDeleteButton.Visible = false;
                outlookDeleteButton.Visible = false;
                googleDeleteButton.Visible = false;
                maskedTextBox1.Text = "";
            }
        }
    }
}
