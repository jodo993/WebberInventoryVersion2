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
    public partial class ForgotPINForm : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public ForgotPINForm()
        {
            InitializeComponent();
            // Connection to database
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase.accdb;Jet OLEDB:Database Password=p4aB63mCK7;";
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.ToUpper();
            if (name != "")
            {
                try
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "select LastName from Master_Key_Login where FirstName='" + name + "'";

                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        nameListBox.Items.Add(reader["LastName"].ToString());
                    }

                    int listBoxItemsNumber = nameListBox.Items.Count;
                    if (listBoxItemsNumber == 0)
                        MessageBox.Show("No record found for that name.");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred and this function cannot be performed. Please try again later.");
                }
            }
            else
                MessageBox.Show("Must input a name.");
        }

        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select SecurityQuestion from Master_Key_Login where LastName='" + nameListBox.SelectedItem + "'";

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    securityQuestionLabel.Text = reader["SecurityQuestion"].ToString();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred and this function cannot be performed. Please try again later.");
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            string answer = answerTextBox.Text.ToUpper();

            if (answer == "")
            {
                MessageBox.Show("Please input an answer.");
            }
            else
            {
                try
                {
                    string questionAnswer = "";
                    int privateKey = 0;
                    bool matched = false;

                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "select PrivateKey,SecurityAnswer from Master_Key_Login where LastName='" + nameListBox.SelectedItem + "' AND SecurityQuestion='" + securityQuestionLabel.Text + "'";

                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        questionAnswer = reader["SecurityAnswer"].ToString();
                        privateKey = int.Parse(reader["PrivateKey"].ToString());
                        if (questionAnswer == answer)
                        {
                            MessageBox.Show("Correct. Press Ok to see your private key.");
                            MessageBox.Show("Private Key: " + privateKey);
                            matched = true;
                        }

                        if (matched == false)
                            MessageBox.Show("Question and answer does not match.");
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred and this function cannot be performed. Please try again later.");
                }
            }
        }
    }
}
