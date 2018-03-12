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
    public partial class ForgotPINForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Webber Database\WebberMainDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        public ForgotPINForm()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            nameListBox.Items.Clear();
            string name = nameTextBox.Text.ToUpper();
            if (name != "")
            {
                try
                {
                    connection.Open();

                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    string query = "select LastName from Master_Key_Login where FirstName='" + name + "'";
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        nameListBox.Items.Add(reader["LastName"].ToString());
                    }

                    int listBoxItemsNumber = nameListBox.Items.Count;
                    if (listBoxItemsNumber == 0)
                        MessageBox.Show("No record found for that name.");

                    connection.Close();
                }
                catch (Exception)
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

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string query = "select SecurityQuestion from Master_Key_Login where LastName='" + nameListBox.SelectedItem + "' AND FirstName='" + nameTextBox.Text + "'";
                command.CommandText = query;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    securityQuestionLabel.Text = reader["SecurityQuestion"].ToString();
                }

                connection.Close();
            }
            catch (Exception)
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

                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    string query = "select PrivateKey,SecurityAnswer from Master_Key_Login where LastName='" + nameListBox.SelectedItem + "' AND SecurityQuestion='" + securityQuestionLabel.Text + "'";
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();
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
                catch (Exception)
                {
                    MessageBox.Show("An error has occurred and this function cannot be performed. Please try again later.");
                }
            }
        }

        private void answerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                checkButton.PerformClick();
        }

        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                goButton.PerformClick();
        }
    }
}
