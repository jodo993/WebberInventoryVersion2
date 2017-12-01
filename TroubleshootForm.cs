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
            if (problemTextBox.Text == "")
            {
                MessageBox.Show("Must enter an issue.");
            }
            else
            {
                solutionListBox.Items.Clear();
                string search = problemTextBox.Text.ToUpper();
                
                try
                {
                    connection.Open();

                    //OleDbCommand command = new OleDbCommand();
                    //command.Connection = connection;
                    //string query = "select * from Troubleshoot_Data"; // where Issue='" + search + "'";
                    //command.CommandText = query;

                    //// Create list
                    //List<string> issueList = new List<string>();

                    //OleDbDataReader reader = command.ExecuteReader();
                    //while (reader.Read())
                    //{
                    //    issueList.Add(reader["Issue"].ToString().ToUpper());
                    //}

                    //for (int i = 0; i < issueList.Count; i++)
                    //{
                    //    if (issueList[i].Contains(search) || issueList[i].StartsWith(search) || issueList[i].EndsWith(search))
                    //    {
                    //        solutionListBox.Items.Add(issueList[i]);
                    //    }
                    //}

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select * from Troubleshoot_Data";
                    command.CommandText = query;

                    // Create list
                    List<string> searchList = new List<string>();
                    List<string> issueList = new List<string>();
                    
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        double numberOfWordInSearch = 0.0;
                        double numberOfWordInIssue = 0.0;
                        double totalNumberOfWords = 0.0;
                        double wordMatches = 0.0;
                        double percentMatched = 0.0;

                        string issue = (reader["Issue"].ToString().ToUpper());      

                        foreach (string word in search.Split())
                        {
                            searchList.Add(word);
                            numberOfWordInSearch++;
                        }

                        foreach (string word in issue.Split())
                        {
                            issueList.Add(word);
                            numberOfWordInIssue++;
                        }

                        totalNumberOfWords = numberOfWordInSearch + numberOfWordInIssue;

                        for (int i = 0; i < numberOfWordInSearch; i++)
                        {
                            if (issueList.Contains(searchList[i]))
                            {
                                wordMatches++;
                            }
                            else
                                wordMatches = wordMatches + 0;
                        }
                        wordMatches = wordMatches * 2;
                        percentMatched = Math.Round(((wordMatches / totalNumberOfWords) * 100), 2);
                        if ( percentMatched > 33.32)
                        {
                            solutionListBox.Items.Add(issue);
                        }

                        label3.Text = numberOfWordInSearch.ToString();
                        label4.Text = numberOfWordInIssue.ToString();
                        label5.Text = totalNumberOfWords.ToString();
                        label6.Text = wordMatches.ToString();
                        label7.Text = percentMatched.ToString();
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("this" + ex);
                }
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            // Clear all previous items
            solutionListBox.Items.Clear();

            // Show all issues in list box
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Troubleshoot_Data"; 
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                solutionListBox.Items.Add(reader["Issue"].ToString());
            }

            connection.Close();
        }

        private void solutionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Troubleshoot_Data where Issue='" + solutionListBox.SelectedItem + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                solutionLabel.Text = reader["Resolution"].ToString();
            }
            connection.Close();
        }
    }
}
