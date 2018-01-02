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
    public partial class TechnologyAssistantForm : Form
    {

        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public TechnologyAssistantForm()
        {
            InitializeComponent();

            // Connect to database                  
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase_be.accdb;Persist Security Info=False;";
        }

        // Categories and their issues
        public void StMath()
        {
            issueComboBox.Items.Clear();

            issueComboBox.Items.Add("Add Students");
            issueComboBox.Items.Add("Transfer Students");
            issueComboBox.Items.Add("Retrain Student Password");
            issueComboBox.Items.Add("ST Math not at the right school");
        }

        public void Lexia()
        {
            issueComboBox.Items.Clear();

            issueComboBox.Items.Add("Manage Class");
            issueComboBox.Items.Add("Print Roster/Login Card");
        }

        public void AR()
        {
            issueComboBox.Items.Clear();

            issueComboBox.Items.Add("Can't Login");
            issueComboBox.Items.Add("Create New Account");
            issueComboBox.Items.Add("Clear Locked User");
        }

        public void Notes()
        {
            issueComboBox.Items.Clear();

            issueComboBox.Items.Add("District Limitations");
            issueComboBox.Items.Add("Haiku or PowerSchool Learning");
            issueComboBox.Items.Add("Account to Have");
        }

        public void Chromebook()
        {
            issueComboBox.Items.Clear();

            issueComboBox.Items.Add("Reset Password for Students");
        }

        private void TechnologyAssistantForm_Load(object sender, EventArgs e)
        {
            // Add these selection upon load
            programComboBox.Items.Add("ST Math");
            programComboBox.Items.Add("Lexia");
            programComboBox.Items.Add("Renaissance");
            programComboBox.Items.Add("Notes");
            programComboBox.Items.Add("Chromebook");

            try
            {
                // Populate the list box of open tickets
                connection.Open();

                OleDbCommand commandID = new OleDbCommand();
                commandID.Connection = connection;
                string query = "select * from Help_Ticket";
                commandID.CommandText = query;

                string[] statusCheck = new string[1000];
                int i = 0;

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
                OleDbDataReader reader = commandID.ExecuteReader();
                while(reader.Read())
                {
                    openTicketListBox.Items.Add(reader["ID"].ToString());
                }

                OleDbCommand commandSupplies = new OleDbCommand();
                commandSupplies.Connection = connection;
                string querySupply = "select * from Supply_Information";
                commandSupplies.CommandText = querySupply;

                OleDbDataReader supplyReader = commandSupplies.ExecuteReader();
                while (supplyReader.Read())
                {
                    suppliesListBox.Items.Add(supplyReader["ID"].ToString());
                }

                // Troubleshoot Populate Data
                OleDbCommand commandTroubleshoot = new OleDbCommand();
                commandTroubleshoot.Connection = connection;
                string queryTroubleshoot = "select * from Troubleshoot_Data";
                commandTroubleshoot.CommandText = queryTroubleshoot;

                OleDbDataReader troubleshootReader = commandTroubleshoot.ExecuteReader();
                while (troubleshootReader.Read())
                {
                    currentSolutionListBox.Items.Add(troubleshootReader["Issue"].ToString());
                }

                // Get ID number of bug splat issues
                OleDbCommand commandBugSplat = new OleDbCommand();
                commandBugSplat.Connection = connection;
                string queryBugSplat = "select * from Exception_Error_Report";
                commandBugSplat.CommandText = queryBugSplat;

                OleDbDataReader bugReader = commandBugSplat.ExecuteReader();
                while (bugReader.Read())
                {
                    bugNumberListBox.Items.Add(bugReader["ID"].ToString());
                }
                connection.Close();
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

        private void programComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check which category is selected
            if (programComboBox.SelectedIndex == 0)
            {
                StMath();
            }
            else if (programComboBox.SelectedIndex == 1)
            {
                Lexia();
            }
            else if (programComboBox.SelectedIndex == 2)
            {
                AR();
            }
            else if (programComboBox.SelectedIndex == 3)
            {
                Notes();
            }
            else if (programComboBox.SelectedIndex == 4)
            {
                Chromebook();
            }
            else
            {
                MessageBox.Show("Try again.");
            }
        }

        private void issueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check to see which issue is clicked then show solution
            string instruction = "";
            // ST Math
            if (programComboBox.SelectedIndex == 0)
            {
                if (issueComboBox.SelectedIndex == 0)
                {
                    instruction = "1) Click Green Person w/ Plus sign at lower right. @2) Enter first & last name and select grade and teacher. @3) Sign on to teacher's account to link. @4) Use open enrollment to link students faster. @5) One time only, do not close until done.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 1)
                {
                    instruction = "1) Log in to teacher's account or yours. @2) Find teacher and class. @3) Find student in roster. @4) Click transfer. Select correct transfer path. Click transfer."; ;
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 2)
                {
                    instruction = "1) Double click on bottom right (About an inch from the right). @2) Popup will prompt for login. Enter teacher's login. @3) Find and click student's name on the roster list. Click retrain password. Click ok.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);

                }
                else if (issueComboBox.SelectedIndex == 3)
                {
                    instruction = "1) Make sure URL is https://web.stmath.com/entrance/go/web75g";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
            }
            // Lexia
            else if (programComboBox.SelectedIndex == 1)
            {
                if (issueComboBox.SelectedIndex == 0)
                {
                    instruction = "1) Login and click on tree graph like icon. @2) Click edit class. @3) Modify students or staff as needed then save.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 1)
                {
                    instruction = "1) Login and click tree graph icon. @2) Select class. @3) Click print roster or print login cards.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
            }
            // Renaissance
            else if (programComboBox.SelectedIndex == 2)
            {
                if (issueComboBox.SelectedIndex == 0)
                {
                    instruction = "1) Make sure username and password are correct and students are in students, teachers in teacher. @2) Make sure WSD-78JW is seen as Renaissance Place ID on the middle right. @3) URL is https://hosted101.renlearn.com/273741/default.aspx";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 1)
                {
                    instruction = "1) Click Users. @2) Click add personnel or add students. @3) Fill out information and click save and add.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 2)
                {
                    instruction = "1) Click Users. @2) Click clear lock (personnel or students).";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
            }
            // Notes
            else if (programComboBox.SelectedIndex == 3)
            {
                if (issueComboBox.SelectedIndex == 0)
                {
                    instruction = "1) Installation of projector and lamp changes are done by district tech. @2) RICOH printer in lounge is handled by ricoh guy.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 1)
                {
                    instructionLabel.Text = "Haiku will have instructions on many other things such as how to's, procedures, trainings, surplus, etc.";
                }
                else if (issueComboBox.SelectedIndex == 2)
                {
                    instruction = "1) ST Math - Contact Huy Pham @2) Lexia - Principal can create account @3) Renaissance/AR - VeNae or Principal @4) Haiku - Lauren/Ed Tech Coach @5) Aeries - Sue";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
            }
            // Chromebook
            else if (programComboBox.SelectedIndex == 4)
            {
                if (issueComboBox.SelectedIndex == 0)
                {
                    instruction = "1) Go to the admin console in Google @2) Click users or type in lunch number/name in search @3) Verify student is correct, then click the lock icon on the top right @4) Change password then click reset";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
            }
            else
                instructionLabel.Text = "Pick a valid selection.";
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

                OleDbCommand commandID = new OleDbCommand();
                commandID.Connection = connection;
                string query = "select * from Help_Ticket where ID=" + openTicketListBox.SelectedItem + "";
                commandID.CommandText = query;

                OleDbDataReader reader = commandID.ExecuteReader();
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
                OleDbCommand commandID = new OleDbCommand();
                commandID.Connection = connection;
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

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
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

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Supply_Information where ID=" + suppliesListBox.SelectedItem + "";
                command.CommandText = query;

                if (suppliesListBox.SelectedIndex > -1)
                {
                    OleDbDataReader reader = command.ExecuteReader();
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

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
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

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "insert into Troubleshoot_Data (Issue,Explanation,Resolution) values('" + issue + "','" + explanation + "','" + solution + "')";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Problem and solution was added successfully.");
                    currentSolutionListBox.Items.Add(issue);
                    problemTextBox.Text = "";
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

                try
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "update Troubleshoot_Data set Issue='" + issue + "',Explanation='" + explanation + "',Resolution='" + solution + "' where ID=" + id + "";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Problem and solution was updated successfully.");
                    problemIDLabel.Text = "";
                    problemTextBox.Text = "";
                    explanationTextBox.Text = "";
                    solutionTextBox.Text = "";
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

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "delete from Troubleshoot_Data where ID =" + id + "";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Problem and solution was deleted successfully.");
                    problemIDLabel.Text = "";
                    problemTextBox.Text = "";
                    explanationTextBox.Text = "";
                    solutionTextBox.Text = "";
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

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Troubleshoot_Data where Issue='" + currentSolutionListBox.SelectedItem + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    problemIDLabel.Text = reader["ID"].ToString();
                    problemTextBox.Text = reader["Issue"].ToString();
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

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Exception_Error_Report where ID=" + bugNumberListBox.SelectedItem + "";
                command.CommandText = query;

                OleDbDataReader bugReader = command.ExecuteReader();
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

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
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

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
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
        }
    }
}
