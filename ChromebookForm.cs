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
    public partial class ChromebookForm : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public ChromebookForm()
        {
            InitializeComponent();

            // Connect to database       
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase_be.accdb;Persist Security Info=False;";
        }

        // Function to clear all textboxes in the chromebook section
        private void clearAll()
        {
            studentNameTextBox.Text = "";
            studentEditTextBox.Text = "";
            teacherNameTextBox.Text = "";
            originalAddTextBox.Text = "";
            statusComboBox.Text = "";
            loanAddTextBox.Text = "";
            status2ComboBox.Text = "";
            billAmountTextBox.Text = "";
            billDateTextBox.Text = "";
            textBox1.Text = "";
            idTextBox.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Verify to see if all fields are entered
                if (studentNameTextBox.Text != "" && studentEditTextBox.Text != "" && teacherNameTextBox.Text != "" && originalAddTextBox.Text != "" && statusComboBox.Text != "")
                {
                    CheckDigitClass checkDigit = new CheckDigitClass();

                    // Check loan tag for digits only
                    if (loanAddTextBox.Text != "")
                    {
                        bool loanDigit = checkDigit.digitOnly(loanAddTextBox.Text);
                        if (loanDigit != true)
                        {
                            MessageBox.Show("Please enter numbers only for loan tag.");
                            return;
                        }
                    }

                    // Check original tag for digits only
                    bool originalDigit = checkDigit.digitOnly(originalAddTextBox.Text);
                    bool lunchDigit = checkDigit.digitOnly(studentEditTextBox.Text);

                    if (originalDigit == true && lunchDigit == true)
                    {
                        string fullName = "";
                        int lunchID = 0;
                        string teacherName = "";
                        int originalTag = 0;
                        string status = "";
                        int loanTag = 0;
                        string status2 = "";
                        string billAmount = "";
                        string billDate = "";
                        string notes = "";

                        fullName = studentNameTextBox.Text;
                        lunchID = int.Parse(studentEditTextBox.Text);
                        teacherName = teacherNameTextBox.Text;
                        originalTag = int.Parse(originalAddTextBox.Text);
                        status = statusComboBox.Text;

                        if (loanAddTextBox.Text == "")
                            loanTag = 0;
                        else
                            loanTag = int.Parse(loanAddTextBox.Text);

                        if (status2ComboBox.Text == "")
                            status2 = "";
                        else
                            status2 = status2ComboBox.Text;

                        if (billAmountTextBox.Text == "")
                            billAmount = "";
                        else
                            billAmount = billAmountTextBox.Text;

                        if (billDateTextBox.Text == "")
                            billDate = "";
                        else
                            billDate = billDateTextBox.Text;

                        // Note textbox
                        if (textBox1.Text == "")
                            notes = "";
                        else
                            notes = textBox1.Text;

                        // Get current date and time of add
                        string date = DateTime.Now.ToString();

                        // Open connection to database
                        connection.Open();

                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        command.CommandText = "insert into Chromebook_Information (FullName,LunchID,TeacherName,OriginalTag,Status,LoanTag,LoanStatus,BillAmount,BillDate,Notes,LastUpdated) values('" + fullName + "'," + lunchID + ",'" + teacherName + "'," + originalTag + ",'" + status + "'," + loanTag + ",'" + status2 + "','" + billAmount + "','" + billDate + "','" + notes + "','" + date + "')";
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Chromebook was successfully added!");

                        clearAll();
                    }
                    else
                        MessageBox.Show("Please enter numbers only for lunch ID and/or original tag.");
                }    
                else
                    MessageBox.Show("Please fill out all required fields."); 
            }
            catch (Exception ex)
            {
                // Gather and send information to the bug report
                string page = "Chromebook";
                string button = "Add";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear all add fields
            clearAll();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            // Make sure the id field is filled with numbers only
            CheckDigitClass checkDigit = new CheckDigitClass();
            if (idTextBox.Text == "")
            {
                MessageBox.Show("Must have an ID.");
                return;
            }
            else
            {
                bool idNum = checkDigit.digitOnly(idTextBox.Text);
                if (idNum == false)
                {
                    MessageBox.Show("ID must be a number.");
                    return;
                }
            }

            int id = int.Parse(idTextBox.Text);

            try
            {
                // Verify to see if all fields are entered
                if (studentEditTextBox.Text != "" && originalAddTextBox.Text != "" && statusComboBox.Text != "")
                {
                    // Check loan tag for digits only
                    if (loanAddTextBox.Text != "")
                    {
                        bool loanDigit = checkDigit.digitOnly(loanAddTextBox.Text);
                        if (loanDigit != true)
                        {
                            MessageBox.Show("Please enter numbers only for loan tag.");
                            return;
                        }
                    }

                    // Check lunch ID and original tag for digits only
                    bool originalDigit = checkDigit.digitOnly(originalAddTextBox.Text);
                    bool lunchDigit = checkDigit.digitOnly(studentEditTextBox.Text);

                    if (originalDigit == true && lunchDigit == true)
                    {
                        int lunchID = int.Parse(studentEditTextBox.Text);
                        int originalTag = int.Parse(originalAddTextBox.Text);
                        string status = statusComboBox.Text;
                        int loanTag;
                        string status2;
                        float billAmount;
                        string billDate;
                        string notes;

                        if (loanAddTextBox.Text == "")
                            loanTag = 0;
                        else
                            loanTag = int.Parse(loanAddTextBox.Text);

                        if (status2ComboBox.Text == "")
                            status2 = "";
                        else
                            status2 = status2ComboBox.Text;

                        if (billAmountTextBox.Text == "")
                            billAmount = 0;
                        else
                            billAmount = float.Parse(billAmountTextBox.Text);

                        if (billDateTextBox.Text == "")
                            billDate = "";
                        else
                            billDate = billDateTextBox.Text;

                        // Note textbox
                        if (textBox1.Text == "")
                            notes = "";
                        else
                            notes = textBox1.Text;

                        string date = DateTime.Now.ToString();

                        // Open connection to database
                        connection.Open();

                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        command.CommandText = "update Chromebook_Information set OriginalTag=" + originalTag + ",Status='" + status + "',LoanTag=" + loanTag + ",LoanStatus='" + status2 + "',BillAmount=" + billAmount + ",BillDate='" + billDate + "',Notes='" + notes + "',LastUpdated='" + date + "' where ID= " + id + "";
                        command.ExecuteNonQuery();

                        connection.Close();

                        MessageBox.Show("Chromebook was successfully updated.");
                    }
                    else
                        MessageBox.Show("Original tag and/or lunch ID must be digits only.");
                }
                else
                    MessageBox.Show("Fill out all required fields.");
            }
            catch (Exception ex)
            {
                // Gather information to send to bug report
                string page = "Chromebook";
                string button = "Update";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Check for entry
            if (deleteTextBox.Text == "")
            {
                MessageBox.Show("Please enter a number.");
            }
            else
            {
                CheckDigitClass checkDigit = new CheckDigitClass();
                bool digit = checkDigit.digitOnly(deleteTextBox.Text);
                if (digit == true)
                {
                    try
                    {
                        // Open database and delete all data for selected item
                        connection.Open();

                        int deleteItem = int.Parse(deleteTextBox.Text);

                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        command.CommandText = "delete from Chromebook_Information where ID=" + deleteItem + "";
                        command.ExecuteNonQuery();

                        connection.Close();

                        MessageBox.Show("All data was deleted for Chromebook #" + deleteTextBox.Text + ".");
                        deleteTextBox.Text = "";
                    }
                    catch (Exception ex)
                    {
                        // Gather information to send to bug report
                        string page = "Chromebook";
                        string button = "Delete";
                        string exception = ex.ToString();
                        BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                        bugSplat.ShowDialog();

                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Please input numbers only.");
            }     
        }

        private void searchChromebookButton_Click(object sender, EventArgs e)
        {
            // Check to make sure something is entered
            if (searchComboBox.Text == "")
                MessageBox.Show("Please fill out the box.");
            else
            {
                // Check for radio button selection
                int i = 0;
                if (IDradioButton.Checked || tagRadioButton.Checked || statusRadioButton.Checked || billRadioButton.Checked)
                {
                    i = 1;
                    if (i == 1)
                    {
                        CheckDigitClass checkDigit = new CheckDigitClass();
                        // String user enter
                        string searchString = searchComboBox.Text;
                        bool yesDigit = false;

                        // Check input if id radio button is checked
                        if (IDradioButton.Checked)
                        {
                            yesDigit = checkDigit.digitOnly(searchString);
                            if (yesDigit == false)
                            {
                                MessageBox.Show("Must input numbers only.");
                            }
                            else
                                i = 2;
                        }
                        // Check input if tag radio button is checked
                        else if (tagRadioButton.Checked)
                        {
                            yesDigit = checkDigit.digitOnly(searchString);
                            if (yesDigit == false)
                            {
                                MessageBox.Show("Must input numbers only.");
                            }
                            else
                                i = 2;
                        }
                        else if (statusRadioButton.Checked || billRadioButton.Checked)
                            i = 2;
                        else
                            MessageBox.Show("Please start over.");

                        if (i == 2)
                        {
                            try
                            {
                                OleDbCommand command = new OleDbCommand();
                                command.Connection = connection;
                                if (IDradioButton.Checked)
                                {
                                    int lunchID = int.Parse(searchString);
                                    command.CommandText = "select * from Chromebook_Information where LunchID=" + lunchID + "";
                                }
                                else if (tagRadioButton.Checked)
                                {
                                    int originalTag = int.Parse(searchString);
                                    command.CommandText = "select * from Chromebook_Information where OriginalTag=" + originalTag + "";
                                }
                                else if (statusRadioButton.Checked)
                                {
                                    string status = searchString;
                                    command.CommandText = "select * from Chromebook_Information where Status='" + status + "'";
                                }
                                else
                                {
                                    string bill = searchString;
                                    command.CommandText = "select * from Chromebook_Information where BillAmount='" + bill + "'";
                                }

                                // Data Table shows and hold data
                                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                                DataTable dataTable = new DataTable();
                                dataAdapter.Fill(dataTable);
                                chromebookDataGridView.DataSource = dataTable;

                                connection.Close();
                            }
                            catch (Exception ex)
                            {
                                // Get and set information to bug report
                                string page = "Chromebook";
                                string button = "Search";
                                string exception = ex.ToString();
                                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                                bugSplat.ShowDialog();

                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an option to search.");
                }   
            }
        }

        // Display all chromebook data
        private void showAllChromeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get all fields in table and show
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Chromebook_Information";

                // Data Table shows and hold data
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                chromebookDataGridView.DataSource = dataTable;

                connection.Close();
            }
            catch (Exception ex)
            {
                // Get information for bug report
                string page = "Chromebook";
                string button = "Show All";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        // Open main menu form
        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm newMainMenuForm = new MainMenuForm();
            newMainMenuForm.ShowDialog();

            this.Close();
        }

        // Close the program
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Quick fill button
        private void getInfoButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("Please enter a number.");
            }
            else
            {
                CheckDigitClass checkDigit = new CheckDigitClass();
                bool idDigit = checkDigit.digitOnly(idTextBox.Text);
                if (idDigit == true)
                {
                    // Convert string to int
                    int id = int.Parse(idTextBox.Text);

                    try
                    {
                        connection.Open();

                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "select * from Chromebook_Information where ID=" + id + "";
                        command.CommandText = query;

                        OleDbDataReader reader = command.ExecuteReader();

                        // Fill textboxes with corresponding information
                        while (reader.Read())
                        {
                            studentNameTextBox.Text = reader["FullName"].ToString();
                            studentEditTextBox.Text = reader["LunchID"].ToString();
                            teacherNameTextBox.Text = reader["TeacherName"].ToString();
                            originalAddTextBox.Text = reader["OriginalTag"].ToString();
                            statusComboBox.Text = reader["Status"].ToString();
                            loanAddTextBox.Text = reader["LoanTag"].ToString();
                            status2ComboBox.Text = reader["LoanStatus"].ToString();
                            billAmountTextBox.Text = reader["BillAmount"].ToString();
                            billDateTextBox.Text = reader["BillDate"].ToString();
                            textBox1.Text = reader["Notes"].ToString();
                        }

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        // Get information for bug report
                        string page = "Chromebook";
                        string button = "Quick Fill";
                        string exception = ex.ToString();
                        BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                        bugSplat.ShowDialog();

                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Please enter numbers only.");
            }
        }
    }
}
