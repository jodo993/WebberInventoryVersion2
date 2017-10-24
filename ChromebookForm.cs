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
    public partial class ChromebookForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\WebberInventory.mdf;Integrated Security=True;Connect Timeout=30");
        public ChromebookForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Verify to see if all fields are entered
            if (studentNameTextBox.Text != "" && studentEditTextBox.Text != "" && teacherNameTextBox.Text != "" && originalAddTextBox.Text != "" && statusComboBox.Text != "")
            {
                String fullName = "";
                int lunchID = 0;
                String teacherName = "";
                int originalTag = 0;
                String status = "";
                int loanTag = 0;
                String status2 = "";
                float billAmount = 0;
                String dateTime = "";


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

                if (billAmountUpDown.Text == "")
                    billAmount = 0;
                else
                    billAmount = float.Parse(billAmountUpDown.Text);

                if (dateTimePicker.Text == "")
                    dateTime = "";
                else
                    dateTime = dateTimePicker.Text;

                // Open connection to database
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into ChromebookTable values('" + fullName + "','" + lunchID + "','" + teacherName + "','" + originalTag + "','" + status + "','" + loanTag + "','" + status2 + "','" + billAmount + "','" + dateTime + "','" + DateTime.Now + "')";
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Chromebook was successfully added!");
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
            billAmountUpDown.Value = 0;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Verify to see if all fields are entered
                if (studentEditTextBox.Text != "" && originalAddTextBox.Text != "" && statusComboBox.Text != "")
                {
                    int loanTag;
                    string status2;
                    float billAmount;
                    string dateTime;

                    if (loanAddTextBox.Text == "")
                        loanTag = 0;
                    else
                        loanTag = int.Parse(loanAddTextBox.Text);

                    if (status2ComboBox.Text == "")
                        status2 = "";
                    else
                        status2 = status2ComboBox.Text;

                    if (billAmountUpDown.Text == "")
                        billAmount = 0;
                    else
                        billAmount = float.Parse(billAmountUpDown.Text);

                    if (dateTimePicker.Text == "")
                        dateTime = "";
                    else
                        dateTime = dateTimePicker.Text;

                    int lunchID = int.Parse(studentEditTextBox.Text);
                    int originalTag = int.Parse(originalAddTextBox.Text);
                    string status = statusComboBox.Text;

                    // Open connection to database
                    connection.Open();

                    SqlCommand command2 = connection.CreateCommand();
                    command2.CommandType = CommandType.Text;
                    command2.CommandText = "update ChromebookTable set \"Original Chromebook\"='" + originalTag + "' where \"Lunch ID\"='" + lunchID + "'";
                    SqlCommand command3 = connection.CreateCommand();
                    command3.CommandType = CommandType.Text;
                    command3.CommandText = "update ChromebookTable set Status='" + status + "' where \"Lunch ID\"='" + lunchID + "'";
                    SqlCommand command4 = connection.CreateCommand();
                    command4.CommandType = CommandType.Text;
                    command4.CommandText = "update ChromebookTable set \"Loan Chromebook\"='" + loanTag + "' where \"Lunch ID\"='" + lunchID + "'";
                    SqlCommand command5 = connection.CreateCommand();
                    command5.CommandType = CommandType.Text;
                    command5.CommandText = "update ChromebookTable set Status2='" + status2 + "' where \"Lunch ID\"='" + lunchID + "'";
                    SqlCommand command6 = connection.CreateCommand();
                    command6.CommandType = CommandType.Text;
                    command6.CommandText = "update ChromebookTable set Bill='" + billAmount + "' where \"Lunch ID\"='" + lunchID + "'";
                    SqlCommand command7 = connection.CreateCommand();
                    command7.CommandType = CommandType.Text;
                    command7.CommandText = "update ChromebookTable set \"Bill Date\"='" + dateTime + "' where \"Lunch ID\"='" + lunchID + "'";
                    SqlCommand command8 = connection.CreateCommand();
                    command8.CommandType = CommandType.Text;
                    command8.CommandText = "update ChromebookTable set \"Last Updated\"='" + DateTime.Now + "' where \"Lunch ID\"='" + lunchID + "'";

                    command2.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                    command4.ExecuteNonQuery();
                    command5.ExecuteNonQuery();
                    command6.ExecuteNonQuery();
                    command7.ExecuteNonQuery();
                    command8.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Chromebook was successfully updated.");
                }
                else
                    MessageBox.Show("Fill out all required fields.");
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill out all required boxes.");
            }
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Open database and delete all data for selected item
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from ChromebookTable where \"Lunch ID\"='" + int.Parse(deleteTextBox.Text) + "'";
            cmd.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("All data was deleted for Chromebook #" + deleteTextBox.Text + ".");
            deleteTextBox.Text = "";
        }

        private void searchChromebookButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (IDradioButton.Checked)
                {
                    command.CommandText = "select * from ChromebookTable where \"Lunch ID\"='" + searchComboBox.Text + "'";
                }
                else if (tagRadioButton.Checked)
                {
                    command.CommandText = "select * from ChromebookTable where \"Original Chromebook\"='" + searchComboBox.Text + "'";
                }
                else if (statusRadioButton.Checked)
                {
                    command.CommandText = "select * from ChromebookTable where Status='" + searchComboBox.Text + "'";
                }
                else if (billRadioButton.Checked)
                {
                    command.CommandText = "select * from ChromebookTable where Bill='" + searchComboBox.Text + "'";
                }
                else
                {
                    MessageBox.Show("Select a choice.");
                    return;
                }

                command.ExecuteNonQuery();

                // Data Table shows and hold data
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                chromebookDataGridView.DataSource = dataTable;

                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Please log out and try again.");
            }
            
        }

        private void showAllChromeButton_Click(object sender, EventArgs e)
        {
            // Get all fields in table and show
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from ChromebookTable";
            cmd.ExecuteNonQuery();

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
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
    }
}
