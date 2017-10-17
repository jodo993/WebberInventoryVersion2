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
            // Verify to see if all fields are entered
            if (studentNameTextBox.Text != "" && studentEditTextBox.Text != "" && teacherNameTextBox.Text != "" && originalAddTextBox.Text != "" && statusComboBox.Text != "")
            {
                //String fullName = studentNameTextBox.Text;
                //int lunchID = int.Parse(studentEditTextBox.Text);
                //String teacherName = teacherNameTextBox.Text;
                //int originalTag = int.Parse(originalAddTextBox.Text);
                //String status = statusComboBox.Text;
                //int loanTag = int.Parse(loanAddTextBox.Text);
                //String status2 = status2ComboBox.Text;
                //float billAmount = float.Parse(billAmountUpDown.Text);
                //String dateTime = dateTimePicker.Text;

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
                command.CommandText = "update ChromebookTable set \"Lunch ID\"='" + int.Parse(studentEditTextBox.Text) + "' where \"Lunch ID\"='" + int.Parse(studentEditTextBox.Text) + "'";
                command.CommandText = "update ChromebookTable set \"Original Chromebook\"='" + int.Parse(originalAddTextBox.Text) + "' where \"Lunch ID\"='" + int.Parse(studentEditTextBox.Text) + "'";
                command.CommandText = "update ChromebookTable set Status='" + statusComboBox.Text + "' where \"Lunch ID\"='" + int.Parse(studentEditTextBox.Text) + "'";
                command.CommandText = "update ChromebookTable set \"Loan Chromebook\"='" + int.Parse(loanAddTextBox.Text) + "' where \"Lunch ID\"='" + int.Parse(studentEditTextBox.Text) + "'";
                command.CommandText = "update ChromebookTable set Status2='" + status2ComboBox.Text + "' where \"Lunch ID\"='" + int.Parse(studentEditTextBox.Text) + "'";
                command.CommandText = "update ChromebookTable set Bill='" + float.Parse(billAmountUpDown.Text) + "' where \"Lunch ID\"='" + int.Parse(studentEditTextBox.Text) + "'";
                command.CommandText = "update ChromebookTable set \"Bill Date\"='" + dateTimePicker.Text + "' where \"Lunch ID\"='" + int.Parse(studentEditTextBox.Text) + "'";
                command.CommandText = "update ChromebookTable set \"Last Updated\"'" + DateTime.Now  + "' where \"Lunch ID\"='" + int.Parse(studentEditTextBox.Text) + "'";
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Chromebook was successfully updated.");
            }
            else
                MessageBox.Show("Fill out all required fields.");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Open database and delete all data for selected item
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from ChromebookTable where Tag='" + deleteTextBox.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("All data was deleted for Chromebook #" + deleteTextBox.Text + ".");
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
