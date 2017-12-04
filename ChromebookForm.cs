﻿using System;
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

        // Clear all fields
        private void clearAll()
        {
            studentNameTextBox.Text = "";
            studentEditTextBox.Text = "";
            teacherNameTextBox.Text = "";
            originalAddTextBox1.Text = "";
            statusComboBox.Text = "";
            loanAddTextBox1.Text = "";
            status2ComboBox.Text = "";
            billAmountTextBox.Text = "";
            billDateTextBox.Text = "";
            textBox1.Text = "";
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                CheckDigitClass checkDigit = new CheckDigitClass();

                if (loanAddTextBox.Text != "")
                {
                    bool loanDigit = checkDigit.digitOnly(loanAddTextBox.Text);
                    if (loanDigit != true)
                    {
                        MessageBox.Show("Please enter numbers only for loan tag.");
                        return;
                    }
                        
                }
                    

                // Verify to see if all fields are entered
                if (studentNameTextBox.Text != "" && studentEditTextBox.Text != "" && teacherNameTextBox.Text != "" && originalAddTextBox.Text != "" && statusComboBox.Text != "")
                {
                    bool originalDigit = checkDigit.digitOnly(originalAddTextBox.Text);

                    if (originalDigit == true)
                    {
                        if (loanAddTextBox.Text != "")
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
                                string notes = "";

                                fullName = studentNameTextBox.Text;
                                lunchID = int.Parse(studentEditTextBox.Text);
                                teacherName = teacherNameTextBox.Text;
                                originalTag = int.Parse(originalAddTextBox1.Text);
                                status = statusComboBox.Text;

                                if (loanAddTextBox1.Text == "")
                                    loanTag = 0;
                                else
                                    loanTag = int.Parse(loanAddTextBox1.Text);

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

                                if (textBox1.Text == "")
                                    notes = "";
                                else
                                    notes = textBox1.Text;

                                // Open connection to database
                                connection.Open();

                                OleDbCommand command = new OleDbCommand();
                                command.Connection = connection;
                                command.CommandText = "insert into Chromebook_Information (FullName,LunchID,TeacherName,OriginalTag,Status,LoanTag,LoanStatus,BillAmount,BillDate,Notes) values('" + fullName + "'," + lunchID + ",'" + teacherName + "'," + originalTag + ",'" + status + "'," + loanTag + ",'" + status2 + "'," + billAmount + ",'" + billDate + "','" + notes + "')"; //,'" + note + "'
                                command.ExecuteNonQuery();
                                connection.Close();

                                MessageBox.Show("Chromebook was successfully added!");

                                clearAll();
                            }
                    }
                    else
                        MessageBox.Show("Please enter numbers only for original tag.");
                }    
                else
                    MessageBox.Show("Please fill out all required fields."); 
            }
            catch (Exception)
            {
                MessageBox.Show("Oops, something went wrong. Please exit and try again.");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear all add fields
            clearAll();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Verify to see if all fields are entered
                if (studentEditTextBox.Text != "" && originalAddTextBox1.Text != "" && statusComboBox.Text != "")
                {
                    int lunchID = int.Parse(studentEditTextBox.Text);
                    int originalTag = int.Parse(originalAddTextBox1.Text);
                    string status = statusComboBox.Text;
                    int loanTag;
                    string status2;
                    float billAmount;
                    string billDate;
                    string notes;

                    if (loanAddTextBox1.Text == "")
                        loanTag = 0;
                    else
                        loanTag = int.Parse(loanAddTextBox1.Text);

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

                    if (textBox1.Text == "")
                        notes = "";
                    else
                        notes = textBox1.Text;

                    string date = DateTime.Now.ToString();
                    // Open connection to database
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "update Chromebook_Information set OriginalTag=" + originalTag + ",Status='" + status + "',LoanTag=" + loanTag + ",LoanStatus='" + status2 + "',BillAmount=" + billAmount + ",BillDate='" + billDate + "',Notes='" + notes + "',LastUpdated='" + date + "' where LunchID= " + lunchID + ""; //,Note='" + note + "'

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
                    catch (Exception)
                    {
                        MessageBox.Show("Oops, something went wrong. Please exit and try again.");
                    }
                }
                else
                    MessageBox.Show("Please input numbers only.");
            }     
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
            catch (Exception)
            {
                MessageBox.Show("Oops, something went wrong. Please log out and try again.");
            }
            
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
                        while (reader.Read())
                        {
                            studentNameTextBox.Text = reader["FullName"].ToString();
                            studentEditTextBox.Text = reader["LunchID"].ToString();
                            teacherNameTextBox.Text = reader["TeacherName"].ToString();
                            originalAddTextBox1.Text = reader["OriginalTag"].ToString();
                            statusComboBox.Text = reader["Status"].ToString();
                            loanAddTextBox1.Text = reader["LoanTag"].ToString();
                            status2ComboBox.Text = reader["LoanStatus"].ToString();
                            billAmountTextBox.Text = reader["BillAmount"].ToString();
                            billDateTextBox.Text = reader["BillDate"].ToString();
                            textBox1.Text = reader["Notes"].ToString();
                        }

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
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
