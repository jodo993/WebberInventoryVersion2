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

        // Return to main menu
        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.ShowDialog();

            this.Close();
        }

        // Close program
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

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select * from Troubleshoot_Data";
                    command.CommandText = query;

                    // Keeps track of word categories
                    double numberOfWordInSearch = 0.0;
                    double numberOfWordInIssue = 0.0;
                    double totalNumberOfWords = 0.0;
                    double wordMatches = 0.0;
                    double percentMatched = 0.0;
                    int solutionFound = 0;

                    // Create list for user search string
                    List<string> searchList = new List<string>();

                    // Split the words in user search string
                    foreach (string word in search.Split())
                    {
                        searchList.Add(word);
                        numberOfWordInSearch++;
                    }

                    // Create list for database issue string
                    List<string> issueList = new List<string>();

                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Reset variables and issue list
                        numberOfWordInIssue = 0.0;
                        totalNumberOfWords = 0.0;
                        wordMatches = 0.0;
                        percentMatched = 0.0;
                        issueList.Clear();
                        
                        // Get issue string from database
                        string issue = (reader["Issue"].ToString().ToUpper());      

                        // Split the words in issue string and count how many total
                        foreach (string word in issue.Split())
                        {
                            issueList.Add(word);
                            numberOfWordInIssue++;
                        }

                        // Get total number of words
                        totalNumberOfWords = numberOfWordInSearch + numberOfWordInIssue;

                        // Find matches that appear in the issue string
                        for (int i = 0; i < numberOfWordInSearch; i++)
                        {
                            if (issueList.Contains(searchList[i]))
                            {
                                wordMatches++;
                            }
                            else
                                wordMatches = wordMatches + 0;
                        }

                        // Get total number of word matches, find percent of the match
                        wordMatches = wordMatches * 2;
                        percentMatched = Math.Round(((wordMatches / totalNumberOfWords) * 100), 2);
                        if ( percentMatched > 33.32)
                        {
                            solutionListBox.Items.Add(issue);
                            solutionFound++;
                        }
                    }

                    // If there are no matches
                    if (solutionFound < 1)
                        MessageBox.Show("No solution found.");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    // Get and send information to bug report
                    string page = "Troubleshoot";
                    string button = "Search";
                    string exception = ex.ToString();
                    BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                    bugSplat.ShowDialog();

                    this.Close();
                }
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            // Clear all previous items
            solutionListBox.Items.Clear();
            try
            {
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
            catch (Exception ex)
            {
                // Get and send information to bug report
                string page = "Troubleshoot";
                string button = "Show All";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
            
        }

        private void solutionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Return data of selected problem
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Troubleshoot_Data where Issue='" + solutionListBox.SelectedItem + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    explanationLabel.Text = reader["Explanation"].ToString();
                    solutionLabel.Text = reader["Resolution"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                // Get and send information to bug report
                string page = "Troubleshoot";
                string button = "Selected Index";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }
    }
}
