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

        public TroubleshootForm(string user)
        {
            InitializeComponent();
            userLabel.Text = user;
            // Connect to database  
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase.accdb;Jet OLEDB:Database Password=p4aB63mCK7;";
        }

        // Return to main menu
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

                    connection.Close();

                    // If there are no matches
                    if (solutionFound < 1)
                        MessageBox.Show("No solution found.");
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
            // Reset rating options
            radioRateOne.Enabled = true;
            radioRateTwo.Enabled = true;
            radioRateThree.Enabled = true;
            radioRateFour.Enabled = true;
            radioRateFive.Enabled = true;
            rateButton.Enabled = true;

            try
            {
                // Rating variables for solutions
                double totalRatingPoints = 0.0;
                double totalRatingVotes = 0.0;
                double averageRating = 0.0;

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
                    totalRatingPoints = double.Parse(reader["TotalRatingPoints"].ToString());
                    totalRatingVotes = double.Parse(reader["TotalRatingVotes"].ToString());
                }
                connection.Close();

                // Get rating and show to user
                averageRating = totalRatingPoints / totalRatingVotes;
                averageRating = Math.Round(averageRating, 1);

                if (averageRating >= 4)
                    averageRatingLabel.BackColor = System.Drawing.Color.Green;
                else if (averageRating >= 3)
                    averageRatingLabel.BackColor = System.Drawing.Color.YellowGreen;
                else if (averageRating >= 2)
                    averageRatingLabel.BackColor = System.Drawing.Color.Gold;
                else if (averageRating >= 1)
                    averageRatingLabel.BackColor = System.Drawing.Color.DarkOrange;
                else if (averageRating >= 0)
                    averageRatingLabel.BackColor = System.Drawing.Color.Red;
                else
                    averageRatingLabel.BackColor = System.Drawing.Color.Transparent;

                totalRatingVotesLabel.Text = totalRatingVotes.ToString();
                averageRatingLabel.Text = averageRating.ToString();
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

        // Update the database with the ratings
        private void rateButton_Click(object sender, EventArgs e)
        {
            double ratingNumber = 0.0;
            double totalRatingPoints = 0.0;
            double totalRatingVotes = 0.0;

            if (radioRateOne.Checked)
                ratingNumber = 1.0;
            else if (radioRateTwo.Checked)
                ratingNumber = 2.0;
            else if (radioRateThree.Checked)
                ratingNumber = 3.0;
            else if (radioRateFour.Checked)
                ratingNumber = 4.0;
            else if (radioRateFive.Checked)
                ratingNumber = 5.0;
            else
                MessageBox.Show("Please select a rating.");

            try
            {
                connection.Open();

                // Get points and votes
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Troubleshoot_Data where Issue='" + solutionListBox.SelectedItem + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    totalRatingPoints = double.Parse(reader["TotalRatingPoints"].ToString());
                    totalRatingVotes = double.Parse(reader["TotalRatingVotes"].ToString());
                }

                totalRatingPoints = totalRatingPoints + ratingNumber;
                totalRatingVotes++;

                // Update the new points and votes

                OleDbCommand commandUpdate = new OleDbCommand();
                commandUpdate.Connection = connection;
                commandUpdate.CommandText = "update Troubleshoot_Data set TotalRatingPoints=" + totalRatingPoints + ",TotalRatingVotes=" + totalRatingVotes + " where Issue='" + solutionListBox.SelectedItem + "'";
                commandUpdate.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Thank you for rating.");

                radioRateOne.Enabled = false;
                radioRateTwo.Enabled = false;
                radioRateThree.Enabled = false;
                radioRateFour.Enabled = false;
                radioRateFive.Enabled = false;
                rateButton.Enabled = false;
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
