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
    public partial class TechnologyAssistantForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Webber Database\WebberMainDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        public TechnologyAssistantForm()
        {
            InitializeComponent();              
        }

        // Populate the tech assist form
        private void selectSqlData(string query, string table)
        {
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (table == "Help")
                    openTicketListBox.Items.Add(reader["ID"].ToString());
                else if (table == "Supply")
                    suppliesListBox.Items.Add(reader["ID"].ToString());
                else if (table == "Troubleshoot")
                    currentSolutionListBox.Items.Add(reader["Issue"].ToString());
                else if (table == "Bug")
                    bugNumberListBox.Items.Add(reader["ID"].ToString());
            }
            reader.Close();

            connection.Close();
        }

        private void TechnologyAssistantForm_Load(object sender, EventArgs e)
        {
            try
            {
                string[] query = { "select * from Help_Ticket",
                                   "select * from Supply_Information",
                                   "select * from Troubleshoot_Data",
                                   "select * from Exception_Error_Report" };
                string[] table = { "Help", "Supply", "Troubleshoot", "Bug" };
                
                for (int i = 0; i < query.Length; i++)
                {
                    selectSqlData(query[i], table[i]);
                }
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "TechAssist Load";
                string button = "Load";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open main menu form
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.ShowDialog();

            this.Close();
        }

        // Close program
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // List box 
        private void openTicketListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                SqlCommand commandID = connection.CreateCommand();
                commandID.CommandType = CommandType.Text;
                string query = "select * from Help_Ticket where ID=" + openTicketListBox.SelectedItem + "";
                commandID.CommandText = query;

                SqlDataReader reader = commandID.ExecuteReader();
                while (reader.Read())
                {
                    idLabel.Text = reader["ID"].ToString();
                    dateCreatedLabel.Text = reader["DateCreated"].ToString();
                    staffLabel.Text = reader["Staff"].ToString();
                    roomLabel.Text = reader["Room"].ToString();
                    importanceLabel.Text = reader["Importance"].ToString();
                    categoryLabel.Text = reader["Category"].ToString();
                    timePreferredLabel.Text = reader["TimePreferred"].ToString();
                    descriptionLabel.Text = reader["Description"].ToString();
                    statusComboBox.Text = reader["Status"].ToString();
                    dateClosedLabel.Text = reader["DateClosed"].ToString();
                    fixDateTextBox.Text = reader["PlannedFixDate"].ToString();
                }
                connection.Close();

                if (statusComboBox.Text == "Closed")
                {
                    statusComboBox.Enabled = false;
                    fixDateTextBox.Enabled = false;
                }
                else
                {
                    statusComboBox.Enabled = true;
                    fixDateTextBox.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "TechAssist Ticket";
                string button = "Index Changed";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (idLabel.Text == "")
            {
                MessageBox.Show("There is nothing to update.");
                return;
            }

            string status = statusComboBox.Text;
            string fixDate = fixDateTextBox.Text;

            try
            {
                connection.Open();

                string date = DateTime.Now.ToString();
                SqlCommand commandID = connection.CreateCommand();
                commandID.CommandType = CommandType.Text;
                string query;
                if (statusComboBox.Text == "Closed")
                {
                    query = "update Help_Ticket set Status='" + status + "',DateClosed='" + date + "',PlannedFixDate='" + fixDate + "' where ID=" + openTicketListBox.SelectedItem + "";
                }
                else
                {
                    query = "update Help_Ticket set Status='" + status + "',PlannedFixDate='" + fixDate + "' where ID=" + openTicketListBox.SelectedItem + "";
                }
                commandID.CommandText = query;
                commandID.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Updated.");
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "TechAssist Ticket";
                string button = "Update";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void deleteSupplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (suppliesListBox.SelectedIndex < 0)
                {
                    MessageBox.Show("There is nothing to delete.");
                    return;
                }

                string item = supplyID.Text;
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string query = "delete from Supply_Information where ID=" + suppliesListBox.SelectedItem + "";
                command.CommandText = query;
                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Supply information deleted.");
                suppliesListBox.Items.Remove(item);
                supplyID.Text = "";
                typeLabel.Text = "";
                brandLabel.Text = "";
                modelLabel.Text = "";
                catLabel.Text = "";
                supplyLabel.Text = "";
                linkLabel.Text = "";
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "TechAssist Supply";
                string button = "Delete";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void suppliesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string query = "select * from Supply_Information where ID=" + suppliesListBox.SelectedItem + "";
                command.CommandText = query;

                if (suppliesListBox.SelectedIndex > -1)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        supplyID.Text = reader["ID"].ToString();
                        typeLabel.Text = reader["Type"].ToString();
                        brandLabel.Text = reader["Brand"].ToString();
                        modelLabel.Text = reader["Model"].ToString();
                        catLabel.Text = reader["Category"].ToString();
                        supplyLabel.Text = reader["Supply"].ToString();
                        linkLabel.Text = reader["Link"].ToString();
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "TechAssist Supply";
                string button = "Index Changed";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        // Update fields
        private void updateSupplyButton_Click(object sender, EventArgs e)
        {
            string type = typeLabel.Text;
            string brand = brandLabel.Text;
            string model = modelLabel.Text;
            string category = catLabel.Text;
            string supply = supplyLabel.Text;
            string link = linkLabel.Text;

            // Check link for front requirements of www or https
            bool linkCheck = false;
            if (link.StartsWith("www.") || link.StartsWith("https://"))
                linkCheck = true;

            if (linkCheck)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    string query = "update Supply_Information set Type='" + type + "',Brand='" + brand + "',Model='" + model + "',Category='" + category + "',Supply='" + supply + "',Link='" + link + "' where ID=" + suppliesListBox.SelectedItem + "";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();
                    MessageBox.Show("Item updated.");
                }
                catch (Exception ex)
                {
                    // Send bug report
                    string page = "TechAssist Supply";
                    string button = "Update";
                    string exception = ex.ToString();
                    BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                    bugSplat.ShowDialog();

                    this.Close();
                }
            }
            else
                MessageBox.Show("Please include https:// or www. in your link.");
        }

        // Add a new problem and solution to troubleshoot data
        private void addTroubleButton_Click(object sender, EventArgs e)
        {
            string issue = problemTextBox.Text;
            string solution = solutionTextBox.Text;
            string keyWords = keyWordsTextBox.Text;
            string explanation = "";

            if (explanationTextBox.Text == "")
                explanation = "";
            else
                explanation = explanationTextBox.Text;

            // Check to make sure at least problem and solutin is filled in
            if (issue != "" && solution != "")
            {
                try
                {
                    connection.Open();

                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    string query = "insert into Troubleshoot_Data (Issue,KeyWords,Explanation,Resolution) values('" + issue + "','" + keyWords + "','" + explanation + "','" + solution + "')";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Problem and solution was added successfully.");
                    currentSolutionListBox.Items.Add(issue);
                    problemTextBox.Text = "";
                    keyWordsTextBox.Text = "";
                    explanationTextBox.Text = "";
                    solutionTextBox.Text = "";
                }
                catch (Exception ex)
                {
                    // Send bug report
                    string page = "TechAssist Troubleshoot";
                    string button = "Add";
                    string exception = ex.ToString();
                    BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                    bugSplat.ShowDialog();

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please input both problem and solution.");
            }
        }

        // Make changes to troubleshoot data
        private void editTroubleButton_Click(object sender, EventArgs e)
        {
            if (problemIDLabel.Text == "")
            {
                MessageBox.Show("There is nothing to update.");
            }
            else
            {
                int id = int.Parse(problemIDLabel.Text);
                string issue = problemTextBox.Text;
                string explanation = explanationTextBox.Text;
                string solution = solutionTextBox.Text;
                string keyWords = keyWordsTextBox.Text;

                try
                {
                    connection.Open();

                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    string query = "update Troubleshoot_Data set Issue='" + issue + "',KeyWOrds='" + keyWords + "',Explanation='" + explanation + "',Resolution='" + solution + "' where ID=" + id + "";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Problem and solution was updated successfully.");
                    problemIDLabel.Text = "";
                    problemTextBox.Text = "";
                    explanationTextBox.Text = "";
                    solutionTextBox.Text = "";
                    keyWordsTextBox.Text = "";
                }
                catch (Exception ex)
                {
                    // Send bug report
                    string page = "TechAssist Troubleshoot";
                    string button = "Edit";
                    string exception = ex.ToString();
                    BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                    bugSplat.ShowDialog();

                    this.Close();
                }
            }
        }

        // Delete all data about troubleshoot problem
        private void deleteTroubleButton_Click(object sender, EventArgs e)
        {
            if (problemIDLabel.Text == "")
            {
                MessageBox.Show("There is nothing to delete.");
            }
            else
            {
                int id = int.Parse(problemIDLabel.Text);
                string removedItem = problemTextBox.Text;
                try
                {
                    connection.Open();

                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    string query = "delete from Troubleshoot_Data where ID =" + id + "";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Problem and solution was deleted successfully.");
                    problemIDLabel.Text = "";
                    problemTextBox.Text = "";
                    explanationTextBox.Text = "";
                    solutionTextBox.Text = "";
                    keyWordsTextBox.Text = "";
                    currentSolutionListBox.Items.Remove(removedItem);
                }
                catch (Exception ex)
                {
                    // Send bug report
                    string page = "TechAssist Troubleshoot";
                    string button = "Delete";
                    string exception = ex.ToString();
                    BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                    bugSplat.ShowDialog();

                    this.Close();
                }
            }
        }

        // Select id number of problem and display
        private void currentSolutionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string query = "select * from Troubleshoot_Data where Issue='" + currentSolutionListBox.SelectedItem + "'";
                command.CommandText = query;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    problemIDLabel.Text = reader["ID"].ToString();
                    problemTextBox.Text = reader["Issue"].ToString();
                    keyWordsTextBox.Text = reader["KeyWords"].ToString();
                    explanationTextBox.Text = reader["Explanation"].ToString();
                    solutionTextBox.Text = reader["Resolution"].ToString();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "TechAssist Troubleshoot";
                string button = "List Box";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        // Populate the bug information to be displayed
        private void bugNumberListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string query = "select * from Exception_Error_Report where ID=" + bugNumberListBox.SelectedItem + "";
                command.CommandText = query;

                SqlDataReader bugReader = command.ExecuteReader();
                while (bugReader.Read())
                {
                    bugIDLabel.Text = bugReader["ID"].ToString();
                    bugPageLabel.Text = bugReader["Page"].ToString();
                    bugButtonLabel.Text = bugReader["Button"].ToString();
                    bugErrorLinkLabel.Text = bugReader["Error"].ToString();
                    bugPersonLabel.Text = bugReader["Person"].ToString();
                    bugDescriptionLabel.Text = bugReader["Description"].ToString();
                    bugStatusComboBox.Text = bugReader["Status"].ToString();
                    bugFixTextBox.Text = bugReader["Fix"].ToString();
                }

                connection.Close();

                if (bugStatusComboBox.Text == "Closed")
                {
                    bugStatusComboBox.Enabled = false;
                    bugFixTextBox.Enabled = false;
                }
                else
                {
                    bugStatusComboBox.Enabled = true;
                    bugFixTextBox.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" hi" + ex);
                // Create bug report
                string page = "TechAssistBugReport";
                string button = "Selected Index";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();
                this.Close();
            }
        }

        // Display bug report on a new form to give a better view
        private void bugErrorLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BugErrorDisplayForm newError = new BugErrorDisplayForm(bugErrorLinkLabel.Text);
            newError.ShowDialog();
        }

        // Delete a bug report
        private void deleteBugButton_Click(object sender, EventArgs e)
        {
            if (bugIDLabel.Text == "")
            {
                MessageBox.Show("There is nothing to delete.");
                return;
            }

            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string query = "delete from Exception_Error_Report where ID=" + bugNumberListBox.SelectedItem + "";
                command.CommandText = query;
                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Bug Report " + bugNumberListBox.SelectedItem + " was deleted.");
                bugIDLabel.Text = "";
                bugPageLabel.Text = "";
                bugButtonLabel.Text = "";
                bugErrorLinkLabel.Text = "";
                bugPersonLabel.Text = "";
                bugDescriptionLabel.Text = "";
                bugStatusComboBox.Text = "";
                bugFixTextBox.Text = "";
            }
            catch (Exception ex)
            {
                // Create bug report
                string page = "TechAssistBugReport";
                string button = "Delete";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();
                this.Close();
            }
        }

        private void updateBugButton_Click(object sender, EventArgs e)
        {
            if (bugIDLabel.Text == "")
            {
                MessageBox.Show("There is nothing to update.");
                return;
            }
            try
            {
                string status = bugStatusComboBox.Text;
                string fix = bugFixTextBox.Text;
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string query = "update Exception_Error_Report set Status='" + status + "',Fix='" + fix + "' where ID=" + bugNumberListBox.SelectedItem + "";
                command.CommandText = query;
                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Report updated.");
            }
            catch (Exception ex)
            {
                // Create bug report
                string page = "TechAssistBugReport";
                string button = "Update";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();
                this.Close();
            }
        }

        // Clear all fields in troubleshoot tab
        private void troubleClearButton_Click(object sender, EventArgs e)
        {
            currentSolutionListBox.SelectedIndex = -1;
            problemIDLabel.Text = "";
            explanationTextBox.Text = "";
            problemTextBox.Text = "";
            solutionTextBox.Text = "";
            keyWordsTextBox.Text = "";
        }

        private void sortTSListBoxButton_Click(object sender, EventArgs e)
        {
            currentSolutionListBox.Sorted = true;
        }
    }
}

//// Add only open tickets to listbox
//OleDbDataReader reader = commandID.ExecuteReader();
//while (reader.Read())
//{
//    statusCheck[i] = reader["Status"].ToString();
//    if (statusCheck[i] == "Open")
//        openTicketListBox.Items.Add(reader["ID"].ToString());
//    i++;
//}

// Add all tickets to listbox