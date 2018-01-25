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
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase.accdb;Jet OLEDB:Database Password=p4aB63mCK7;";
        }

        // Go back to main menu depending on whether user logged in as teacher or admin
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

        // -------------------------------------------------------------------------------------------------------------------

        // WORD TAB IS NOW THE ENTIRE MICROSOFT OFFICE SUITE, SAME GOES FOR THE DATABASE
        // EXCEL TAB IS NOW FOR CHROMEBOOK, SAME GOES FOR THE DATABASE
        // POWERPOINT TAB IS NOW EDUCATIONAL SOFTWARE, SAME GOES FOR THE DATABASE

        // -------------------------------------------------------------------------------------------------------------------

        // Close the program
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckAddCheckState()
        {
            if (hideAddCheckBox.Checked == true)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                groupBox5.Visible = false;
                groupBox6.Visible = false;
                wordAddButton.Visible = false;
                excelAddButton.Visible = false;
                powerpointAddButton.Visible = false;
                outlookAddButton.Visible = false;
                googleAddButton.Visible = false;
                miscAddButton.Visible = false;
            }
            else
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;
                groupBox5.Visible = true;
                groupBox6.Visible = true;
                wordAddButton.Visible = true;
                excelAddButton.Visible = true;
                powerpointAddButton.Visible = true;
                outlookAddButton.Visible = true;
                googleAddButton.Visible = true;
                miscAddButton.Visible = true;
            }
        }
        // Populate the how to textbox for each tab
        private void TutorialForm_Load(object sender, EventArgs e)
        {
            try
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

                OleDbCommand commandMisc = new OleDbCommand();
                commandMisc.Connection = connection;

                // What does command do
                string wordQuery = "select Topic from Tutorial_Word";
                string excelQuery = "select Topic from Tutorial_Excel";
                string powerpointQuery = "select Topic from Tutorial_Powerpoint";
                string outlookQuery = "select Topic from Tutorial_Outlook";
                string googleQuery = "select Topic from Tutorial_Google";
                string miscQuery = "select Topic from Tutorial_Misc";

                commandWord.CommandText = wordQuery;
                commandExcel.CommandText = excelQuery;
                commandPP.CommandText = powerpointQuery;
                commandOutlook.CommandText = outlookQuery;
                commandGoogle.CommandText = googleQuery;
                commandMisc.CommandText = miscQuery;

                // Read the topic column of each table and put them in corresponding list boxes
                OleDbDataReader readerWord = commandWord.ExecuteReader();
                OleDbDataReader readerExcel = commandExcel.ExecuteReader();
                OleDbDataReader readerPP = commandPP.ExecuteReader();
                OleDbDataReader readerOutlook = commandOutlook.ExecuteReader();
                OleDbDataReader readerGoogle = commandGoogle.ExecuteReader();
                OleDbDataReader readerMisc = commandMisc.ExecuteReader();

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

                while (readerMisc.Read())
                {
                    miscListBox.Items.Add(readerMisc["Topic"].ToString());
                }

                connection.Close();

                // Sort listbox
                wordListBox.Sorted = true;
                excelListBox.Sorted = true;
                powerpointListBox.Sorted = true;
                outlookListBox.Sorted = true;
                googleListBox.Sorted = true;
                miscListBox.Sorted = true;

                // If user is admin show delete button
                if (userLabel.Text == "A")
                {
                    wordDeleteButton.Visible = true;
                    excelDeleteButton.Visible = true;
                    powerpointDeleteButton.Visible = true;
                    outlookDeleteButton.Visible = true;
                    googleDeleteButton.Visible = true;
                    miscDeleteButton.Visible = true;
                }

                CheckAddCheckState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The connection with the database could not be established. Some features may not be working correctly. Please try again later or contact your administrator if the problem persists.");
                string page = "Tutorial";
                string button = "Page Load";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                //this.Close();
            }
        }

        // Show the instruction that corresponds to the selected topic

        // WORD TAB
        private void wordListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hasVideo = "";

            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Tutorial_Word where Topic='" + wordListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stepByStepLabel.Text = reader["Instructions"].ToString();
                hasVideo = reader["HasVideo"].ToString();
                videoLinkLabel.Text = reader["VideoLink"].ToString();
                if (hasVideo == "Yes")
                {
                    videoUnavailableLabel.Visible = false;
                    videoAvailableLinkLabel.Visible = true;
                }
                else
                {
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = true;  
                }    
            }

            connection.Close();
        }

        private void WordAdd(string topic, string instructions, string hasVideo, string link)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "insert into Tutorial_Word (Topic,Instructions,HasVideo,VideoLink) values('" + topic + "','" + instructions + "','" + hasVideo + "','" + link + "')";
            command.CommandText = query;
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Tutorial " + topic + " was successfully added.");
            wordListBox.Items.Add(topic);

            // Clear boxes
            wordTopicTextBox.Text = "";
            wordInstructionTextBox.Text = "";
            wordVideoComboBox.Text = "";
            wordLinkTextBox.Text = "";
        }

        // WORD IS NOW THE COMPLETE MICROSOFT OFFICE SUITE. SAME GOES FOR THE DATABASE!!!!!
        private void wordAddButton_Click(object sender, EventArgs e)
        {
            string topic = wordTopicTextBox.Text;
            string instructions = wordInstructionTextBox.Text;
            string hasVideo = wordVideoComboBox.Text.Trim();
            string link = wordLinkTextBox.Text;

            if (topic == "" || instructions == "" || hasVideo == "")
                MessageBox.Show("Please enter a topic, instructions, and video available.");
            else
            {
                if (hasVideo == "Yes")
                {
                    if (link.StartsWith("www.") || link.StartsWith("https://"))
                    {
                        WordAdd(topic, instructions, hasVideo, link);
                    }
                    else
                    {
                        MessageBox.Show("Link must start with www or https.");
                    }
                }
                else if (hasVideo == "No")
                {
                    WordAdd(topic, instructions, hasVideo, link);
                }
                else
                    MessageBox.Show("Video Available can only be Yes or No.");
            }
        }

        // EXCEL TAB
        private void excelListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hasVideo = "";

            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Tutorial_Excel where Topic='" + excelListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stepByStepLabel.Text = reader["Instructions"].ToString();
                hasVideo = reader["HasVideo"].ToString();
                videoLinkLabel.Text = reader["VideoLink"].ToString();
                if (hasVideo == "Yes")
                {
                    videoUnavailableLabel.Visible = false;
                    videoAvailableLinkLabel.Visible = true;
                }
                else
                {
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = true;
                }
            }

            connection.Close();
        }

        private void ExcelAdd(string topic, string instructions, string hasVideo, string link)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "insert into Tutorial_Excel (Topic,Instructions,HasVideo,VideoLink) values('" + topic + "','" + instructions + "','" + hasVideo + "','" + link + "')";
            command.CommandText = query;
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Tutorial " + topic + " was successfully added.");
            excelListBox.Items.Add(topic);

            // Clear boxes
            excelTopicTextBox.Text = "";
            excelInstructionTextBox.Text = "";
            excelVideoComboBox.Text = "";
            excelLinkTextBox.Text = "";
        }

        private void excelAddButton_Click(object sender, EventArgs e)
        {
            string topic = excelTopicTextBox.Text;
            string instructions = excelInstructionTextBox.Text;
            string hasVideo = excelVideoComboBox.Text.Trim();
            string link = excelLinkTextBox.Text;

            if (topic == "" || instructions == "" || hasVideo == "")
                MessageBox.Show("Please enter a topic, instructions, and video available.");
            else
            {
                if (hasVideo == "Yes")
                {
                    if (link.StartsWith("www.") || link.StartsWith("https://"))
                    {
                        ExcelAdd(topic, instructions, hasVideo, link);
                    }
                    else
                        MessageBox.Show("Link must start with www. or https.");
                }
                else if (hasVideo == "No")
                {
                    ExcelAdd(topic, instructions, hasVideo, link);
                }
                else
                    MessageBox.Show("Video Available can only be Yes or No.");
            }
        }

        // POWERPOINT TAB
        private void powerpointListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hasVideo = "";

            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Tutorial_Powerpoint where Topic='" + powerpointListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stepByStepLabel.Text = reader["Instructions"].ToString();
                hasVideo = reader["HasVideo"].ToString();
                videoLinkLabel.Text = reader["VideoLink"].ToString();
                if (hasVideo == "Yes")
                {
                    videoUnavailableLabel.Visible = false;
                    videoAvailableLinkLabel.Visible = true;
                }
                else
                {
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = true;
                }
            }

            connection.Close();
        }

        private void PowerpointAdd(string topic, string instructions, string hasVideo, string link)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "insert into Tutorial_Powerpoint (Topic,Instructions,HasVideo,VideoLink) values('" + topic + "','" + instructions + "','" + hasVideo + "','" + link + "')";
            command.CommandText = query;
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Tutorial " + topic + " was successfully added.");
            powerpointListBox.Items.Add(topic);

            // Clear boxes
            powerpointTopicTextBox.Text = "";
            powerpointInstructionTextBox.Text = "";
            powerpointVideoComboBox.Text = "";
            powerpointLinkTextBox.Text = "";
        }

        private void powerpointAddButton_Click(object sender, EventArgs e)
        {
            string topic = powerpointTopicTextBox.Text;
            string instructions = powerpointInstructionTextBox.Text;
            string hasVideo = powerpointVideoComboBox.Text.Trim();
            string link = powerpointLinkTextBox.Text;

            if (topic == "" || instructions == "" || hasVideo == "")
                MessageBox.Show("Please enter a topic, instructions, and video available.");
            else
            {
                if (hasVideo == "Yes")
                {
                    if (link.StartsWith("www.") || link.StartsWith("https://"))
                    {
                        PowerpointAdd(topic, instructions, hasVideo, link);
                    }
                    else
                        MessageBox.Show("Link must start with www. or https.");
                }
                else if (hasVideo == "No")
                {
                    PowerpointAdd(topic, instructions, hasVideo, link);
                }
                else
                    MessageBox.Show("Video Available can only be Yes or No.");
            }
        }

        // OUTLOOK TAB
        private void outlookListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hasVideo = "";

            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Tutorial_Outlook where Topic='" + outlookListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stepByStepLabel.Text = reader["Instructions"].ToString();
                hasVideo = reader["HasVideo"].ToString();
                videoLinkLabel.Text = reader["VideoLink"].ToString();
                if (hasVideo == "Yes")
                {
                    videoUnavailableLabel.Visible = false;
                    videoAvailableLinkLabel.Visible = true;
                }
                else
                {
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = true;
                }
            }

            connection.Close();
        }

        private void OutlookAdd(string topic, string instructions, string hasVideo, string link)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "insert into Tutorial_Outlook (Topic,Instructions,HasVideo,VideoLink) values('" + topic + "','" + instructions + "','" + hasVideo + "','" + link + "')";
            command.CommandText = query;
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Tutorial " + topic + " was successfully added.");
            outlookListBox.Items.Add(topic);

            // Clear boxes
            outlookTopicTextBox.Text = "";
            outlookInstructionTextBox.Text = "";
            outlookVideoComboBox.Text = "";
            outlookLinkTextBox.Text = "";
        }

        private void outlookAddButton_Click(object sender, EventArgs e)
        {
            string topic = outlookTopicTextBox.Text;
            string instructions = outlookInstructionTextBox.Text;
            string hasVideo = outlookVideoComboBox.Text.Trim();
            string link = outlookLinkTextBox.Text;

            if (topic == "" || instructions == "" || hasVideo == "")
                MessageBox.Show("Please enter a topic, instructions, and video available.");
            else
            {
                if (hasVideo == "Yes")
                {
                    if (link.StartsWith("www.") || link.StartsWith("https://"))
                    {
                        OutlookAdd(topic, instructions, hasVideo, link);
                    }
                    else
                    {
                        MessageBox.Show("Link must start with www. or https.");
                    }
                }
                else if (hasVideo == "No")
                {
                    OutlookAdd(topic, instructions, hasVideo, link);
                }
                else
                    MessageBox.Show("Video Available can only be Yes or No.");
            }
        }

        // GOOGLE TAB
        private void googleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hasVideo = "";

            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Tutorial_Google where Topic='" + googleListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stepByStepLabel.Text = reader["Instructions"].ToString();
                hasVideo = reader["HasVideo"].ToString();
                videoLinkLabel.Text = reader["VideoLink"].ToString();
                if (hasVideo == "Yes")
                {
                    videoUnavailableLabel.Visible = false;
                    videoAvailableLinkLabel.Visible = true;
                }
                else
                {
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = true;
                }
            }

            connection.Close();
        }

        private void GoogleAdd(string topic, string instructions, string hasVideo, string link)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "insert into Tutorial_Google (Topic,Instructions,HasVideo,VideoLink) values('" + topic + "','" + instructions + "','" + hasVideo + "','" + link + "')";
            command.CommandText = query;
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Tutorial " + topic + " was successfully added.");
            googleListBox.Items.Add(topic);

            // Clear boxes
            googleTopicTextBox.Text = "";
            googleInstructionTextBox.Text = "";
            googleVideoComboBox.Text = "";
            googleLinkTextBox.Text = "";
        }
        
        private void googleAddButton_Click(object sender, EventArgs e)
        {
            string topic = googleTopicTextBox.Text;
            string instructions = googleInstructionTextBox.Text;
            string hasVideo = googleVideoComboBox.Text.Trim();
            string link = googleLinkTextBox.Text;

            if (topic == "" || instructions == "" || hasVideo == "")
                MessageBox.Show("Please enter a topic, instructions, and video available.");
            else
            {
                if (hasVideo == "Yes")
                {
                    if (link.StartsWith("www.") || link.StartsWith("https://"))
                    {
                        GoogleAdd(topic, instructions, hasVideo, link);
                    }
                    else
                    {
                        MessageBox.Show("Link must start with www. or https.");
                    }
                }
                else if (hasVideo == "No")
                {
                    GoogleAdd(topic, instructions, hasVideo, link);
                }
                else
                    MessageBox.Show("Video Available can only be Yes or No.");
            }
        }

        // MISC TAB
        private void miscListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hasVideo = "";

            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Tutorial_Misc where Topic='" + miscListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stepByStepLabel.Text = reader["Instructions"].ToString();
                hasVideo = reader["HasVideo"].ToString();
                videoLinkLabel.Text = reader["VideoLink"].ToString();
                if (hasVideo == "Yes")
                {
                    videoUnavailableLabel.Visible = false;
                    videoAvailableLinkLabel.Visible = true;
                }
                else
                {
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = true;
                }
            }

            connection.Close();
        }

        private void MiscAdd(string topic, string instructions, string hasVideo, string link)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "insert into Tutorial_Misc (Topic,Instructions,HasVideo,VideoLink) values('" + topic + "','" + instructions + "','" + hasVideo + "','" + link + "')";
            command.CommandText = query;
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Tutorial " + topic + " successfully added.");
            miscListBox.Items.Add(topic);

            // Clear boxes
            miscTopicTextBox.Text = "";
            miscInstructionTextBox.Text = "";
            miscVideoComboBox.Text = "";
            miscLinkTextBox.Text = "";
        }

        private void miscAddButton_Click(object sender, EventArgs e)
        {
            string topic = miscTopicTextBox.Text;
            string instructions = miscInstructionTextBox.Text;
            string hasVideo = miscVideoComboBox.Text.Trim();
            string link = miscLinkTextBox.Text;

            if (topic == "" || instructions == "" || hasVideo == "")
                MessageBox.Show("Please enter a topic, instructions, and video available.");
            else
            {
                if (hasVideo == "Yes")
                {
                    if (link.StartsWith("www.") || link.StartsWith("https://"))
                    {
                        MiscAdd(topic, instructions, hasVideo, link);
                    }
                    else
                    {
                        MessageBox.Show("Link must start with www. or https.");
                    }
                }
                else if (hasVideo == "No")
                {
                    MiscAdd(topic, instructions, hasVideo, link);
                }
                else
                    MessageBox.Show("Video Available can only be Yes or No.");
            }
        }

        // DELETE ENTRIES
        private void wordDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (wordListBox.SelectedIndex > -1)
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "delete from Tutorial_Word where Topic='" + wordListBox.SelectedItem + "'";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Topic and instruction deleted.");
                    wordListBox.Items.Remove(wordListBox.SelectedItem);
                    stepByStepLabel.Text = "";
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = false;
                }
                else
                    MessageBox.Show("Please select an option to delete.");
                
            }
            catch(Exception ex)
            {
                string page = "Tutorial";
                string button = "Delete - Word";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void excelDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (excelListBox.SelectedIndex > -1)
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "delete from Tutorial_Excel where Topic='" + excelListBox.SelectedItem + "'";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Topic and instruction deleted.");
                    excelListBox.Items.Remove(excelListBox.SelectedItem);
                    stepByStepLabel.Text = "";
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = false;
                }
                else
                    MessageBox.Show("Please select an option to delete.");
            }
            catch (Exception ex)
            {
                string page = "Tutorial";
                string button = "Delete - Excel";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void powerpointDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (powerpointListBox.SelectedIndex > -1)
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "delete from Tutorial_Powerpoint where Topic='" + powerpointListBox.SelectedItem + "'";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Topic and instruction deleted.");
                    powerpointListBox.Items.Remove(powerpointListBox.SelectedItem);
                    stepByStepLabel.Text = "";
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = false;
                }
                else
                    MessageBox.Show("Please select an option to delete.");
            }
            catch (Exception ex)
            {
                string page = "Tutorial";
                string button = "Delete - PowerPoint";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void outlookDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (outlookListBox.SelectedIndex > -1)
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "delete from Tutorial_Outlook where Topic='" + outlookListBox.SelectedItem + "'";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Topic and instruction deleted.");
                    outlookListBox.Items.Remove(outlookListBox.SelectedItem);
                    stepByStepLabel.Text = "";
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = false;
                }
                else
                    MessageBox.Show("Please select an option to delete.");
            }
            catch (Exception ex)
            {
                string page = "Tutorial";
                string button = "Delete - Outlook";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void googleDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (googleListBox.SelectedIndex > -1)
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "delete from Tutorial_Google where Topic='" + googleListBox.SelectedItem + "'";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Topic and instruction deleted.");
                    googleListBox.Items.Remove(googleListBox.SelectedItem);
                    stepByStepLabel.Text = "";
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = false;
                }
                else
                    MessageBox.Show("Please select an option to delete.");
            }
            catch (Exception ex)
            {
                string page = "Tutorial";
                string button = "Delete - Google";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void miscDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (miscListBox.SelectedIndex > -1)
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "delete from Tutorial_Misc where Topic='" + miscListBox.SelectedItem + "'";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Topic and instruction deleted.");
                    miscListBox.Items.Remove(miscListBox.SelectedItem);
                    stepByStepLabel.Text = "";
                    videoAvailableLinkLabel.Visible = false;
                    videoUnavailableLabel.Visible = false;
                }
                else
                    MessageBox.Show("Please select an option to delete.");
            }
            catch (Exception ex)
            {
                string page = "Tutorial";
                string button = "Delete - Misc";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void hideAddCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckAddCheckState();
        }

        private void wordVideoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wordVideoComboBox.SelectedItem.ToString() == "No")
            {
                wordLinkTextBox.Text = "";
                wordLinkTextBox.Enabled = false;
            }
            else
                wordLinkTextBox.Enabled = true;
        }

        private void excelVideoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (excelVideoComboBox.SelectedItem.ToString() == "No")
            {
                excelLinkTextBox.Text = "";
                excelLinkTextBox.Enabled = false;
            }
            else
                excelLinkTextBox.Enabled = true;
        }

        private void powerpointVideoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (powerpointVideoComboBox.SelectedItem.ToString() == "No")
            {
                powerpointLinkTextBox.Text = "";
                powerpointLinkTextBox.Enabled = false;
            }
            else
                powerpointLinkTextBox.Enabled = true;
        }

        private void outlookVideoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outlookVideoComboBox.SelectedItem.ToString() == "No")
            {
                outlookLinkTextBox.Text = "";
                outlookLinkTextBox.Enabled = false;
            }
            else
                outlookLinkTextBox.Enabled = true;
        }

        private void googleVideoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (googleVideoComboBox.SelectedItem.ToString() == "No")
            {
                googleLinkTextBox.Text = "";
                googleLinkTextBox.Enabled = false;
            }
            else
                googleLinkTextBox.Enabled = true;
        }

        private void miscVideoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (miscVideoComboBox.SelectedItem.ToString() == "No")
            {
                miscLinkTextBox.Text = "";
                miscLinkTextBox.Enabled = false;
            }
            else
                miscLinkTextBox.Enabled = true;
        }

        private void videoAvailableLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = videoLinkLabel.Text;
            TutorialVideoForm tutorialVideo = new TutorialVideoForm(link);
            tutorialVideo.ShowDialog();
        }
    }
}
