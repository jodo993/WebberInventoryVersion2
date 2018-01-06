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
    public partial class MasterKeyPasswordPage : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public MasterKeyPasswordPage(string user, string name, string key)
        {
            InitializeComponent();
            userLabel.Text = user;
            nameLabel.Text = name;
            keyLabel.Text = key;

            // Connect to database                         
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
        }

        // Return to login page
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            string user = userLabel.Text;
            MasterKeyForm masterForm = new MasterKeyForm(user);
            masterForm.ShowDialog();

            this.Close();
        }

        // Load up the data for the list boxes to display
        private void MasterKeyPasswordPage_Load(object sender, EventArgs e)
        {
            int key = int.Parse(keyLabel.Text);
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select Programs from Master_Key_Passwords where PrivateKey=" + key + "";

                OleDbDataReader programReader = command.ExecuteReader();
                while (programReader.Read())
                {
                    passwordListBox.Items.Add(programReader["Programs"].ToString());
                    updateProgramListBox.Items.Add(programReader["Programs"].ToString());
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("hi" + ex);
            }
        }

        // Provide username and password for selected program
        private void passwordListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Master_Key_Passwords where Programs='" + passwordListBox.SelectedItem + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usernameTextBox.Text = reader["Username"].ToString();
                    passwordTextBox.Text = reader["Passwords"].ToString();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("hi" + ex);
            }
        }

        // Provide a list of available programs to choose from
        private void updateProgramListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Master_Key_Passwords where Programs='" + updateProgramListBox.SelectedItem + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    idLabel.Text = reader["ID"].ToString();
                    programTextBox.Text = reader["Programs"].ToString();
                    newUsernameTextBox.Text = reader["Username"].ToString();
                    newPasswordTextBox.Text = reader["Passwords"].ToString();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("hi" + ex);
            }
        }
        
        // Add new program data set to the database
        private void addButton_Click(object sender, EventArgs e)
        {
            int key = int.Parse(keyLabel.Text);
            string program = programTextBox.Text;
            string username = newUsernameTextBox.Text;
            string password = newPasswordTextBox.Text;

            if (program == "" || username == "" || password == "")
            {
                MessageBox.Show("All 3 fields must be filled out to add.");
                return;
            }
            else
            {
                try
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "insert into Master_Key_Passwords (PrivateKey,Programs,Username,Passwords) values(" + key + ",'" + program + "','" + username + "','" + password + "')";
                    command.ExecuteNonQuery();

                    connection.Close();

                    // Confirm add and display in listbox
                    MessageBox.Show("Username and password for \"" + program + "\" was successfully added to your records.");
                    passwordListBox.Items.Add(program);
                    updateProgramListBox.Items.Add(program);

                    // Clear textboxes
                    programTextBox.Text = "";
                    newUsernameTextBox.Text = "";
                    newPasswordTextBox.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("hi" + ex);
                }
            }
        }

        // Update data for current programs
        private void updateButton_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(idLabel.Text);
            int key = int.Parse(keyLabel.Text);
            string program = programTextBox.Text;
            string username = newUsernameTextBox.Text;
            string password = newPasswordTextBox.Text;

            if (program == "" || username == "" || password == "")
            {
                MessageBox.Show("All 3 fields must be filled out to update.");
                return;
            }
            else
            {
                try
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "update Master_Key_Passwords set Username='" + username + "',Passwords='" + password + "' where Programs='" + program + "' AND PrivateKey=" + key + " AND ID=" + ID + "";
                    command.ExecuteNonQuery();

                    connection.Close();

                    // Confirm add and display in listbox
                    MessageBox.Show("Update for \"" + program + "\" was successful.");

                    // Clear textboxes
                    programTextBox.Text = "";
                    newUsernameTextBox.Text = "";
                    newPasswordTextBox.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("hi" + ex);
                }
            }
        }

        // Delete information for program for user
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Variables to hold required information
            int ID = int.Parse(idLabel.Text);
            int key = int.Parse(keyLabel.Text);
            string program = programTextBox.Text;
            string username = newUsernameTextBox.Text;
            string password = newPasswordTextBox.Text;

            // Check to see if boxes are blank
            if (program == "" || username == "" || password == "")
            {
                MessageBox.Show("All 3 fields must be filled out to delete.");
                return;
            }
            else
            {
                // Open and remove information from database
                try
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "delete from Master_Key_Passwords where Programs='" + program + "' AND PrivateKey=" + key + " AND ID=" + ID + "";
                    command.ExecuteNonQuery();

                    connection.Close();

                    // Confirm add and display in listbox
                    MessageBox.Show("Information for \"" + program + "\" was deleted.");
                    updateProgramListBox.Items.Remove(program);

                    // Clear textboxes
                    programTextBox.Text = "";
                    newUsernameTextBox.Text = "";
                    newPasswordTextBox.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("hi" + ex);
                }
            }
        }
    }
}
