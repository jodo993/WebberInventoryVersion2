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
            // connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\WebberMainDatabase.accdb;Persist Security Info=False;";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Verify to see if all fields are entered
            if (studentNameTextBox.Text != "" && studentEditTextBox.Text != "" && teacherNameTextBox.Text != "" && originalAddTextBox.Text != "" && statusComboBox.Text != "")
            {
                string fullName = "";
                int lunchID = 0;
                string teacherName = "";
                int originalTag = 0;
                string status = "";
                int loanTag = 0;
                string status2 = "";
                float billAmount = 0;
                string billDate = "";

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
                    billAmount = 0;
                else
                    billAmount = float.Parse(billAmountTextBox.Text);

                // Open connection to database
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into Chromebook_Information (FullName,LunchID,TeacherName,OriginalTag,Status,LoanTag,LoanStatus,BillAmount,BillDate) values('" + fullName + "'," + lunchID + ",'" + teacherName + "'," + originalTag + ",'" + status + "'," + loanTag + ",'" + status2 + "'," + billAmount + ",'" + billDate + "')";
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Chromebook was successfully added!");

                studentNameTextBox.Text = "";
                studentEditTextBox.Text = "";
                teacherNameTextBox.Text = "";
                originalAddTextBox.Text = "";
                statusComboBox.Text = "";
                loanAddTextBox.Text = "";
                status2ComboBox.Text = "";
                billAmountTextBox.Text = "";
                billDateTextBox.Text = "";
            }
            else
                MessageBox.Show("Fill out all required fields.");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear all add fields
            studentNameTextBox.Text = "";
            studentEditTextBox.Text = "";
            teacherNameTextBox.Text = "";
            originalAddTextBox.Text = "";
            statusComboBox.Text = "";
            loanAddTextBox.Text = "";
            status2ComboBox.Text = "";
            billAmountTextBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Verify to see if all fields are entered
                if (studentEditTextBox.Text != "" && originalAddTextBox.Text != "" && statusComboBox.Text != "")
                {
                    int lunchID = int.Parse(studentEditTextBox.Text);
                    int originalTag = int.Parse(originalAddTextBox.Text);
                    string status = statusComboBox.Text;
                    int loanTag;
                    string status2;
                    float billAmount;
                    string billDate;

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

                    // Open connection to database
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "update Chromebook_Information set OriginalTag=" + originalTag + ",Status='" + status + "',LoanTag=" + loanTag + ",LoanStatus='" + status2 + "',BillAmount=" + billAmount + ",BillDate='" + billDate + "' where LunchID= " + lunchID + "";

                    command.ExecuteNonQuery();
                    
                    connection.Close();

                    MessageBox.Show("Chromebook was successfully updated.");
                }
                else
                    MessageBox.Show("Fill out all required fields.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please fill out all required boxes." + ex);
            }
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
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

        private void searchChromebookButton_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                if (IDradioButton.Checked)
                {
                    int lunchID = int.Parse(searchComboBox.Text);
                    command.CommandText = "select * from Chromebook_Information where LunchID=" + lunchID + "";
                }
                else if (tagRadioButton.Checked)
                {
                    int originalTag = int.Parse(searchComboBox.Text);
                    command.CommandText = "select * from Chromebook_Information where OriginalTag=" + originalTag + "";
                }
                else if (statusRadioButton.Checked)
                {
                    string status = searchComboBox.Text;
                    command.CommandText = "select * from Chromebook_Information where Status='" + status + "'";
                }
                else if (billRadioButton.Checked)
                {
                    int bill = int.Parse(searchComboBox.Text);
                    command.CommandText = "select * from Chromebook_Information where BillAmount=" + bill + "";
                }
                else
                {
                    MessageBox.Show("Select a choice.");
                    return;
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
                MessageBox.Show("Error. Please log out and try again." + ex);
            }
            
        }

        private void showAllChromeButton_Click(object sender, EventArgs e)
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

        // Main menu
        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm newMainMenuForm = new MainMenuForm();
            newMainMenuForm.ShowDialog();

            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getInfoButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idTextBox.Text);
            // Check for which brand is selected
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Chromebook_Information where ID=" + id + "";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
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
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please go back and try again." + ex);
            }
        }
    }
}
