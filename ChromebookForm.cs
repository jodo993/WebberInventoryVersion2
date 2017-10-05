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
            if (studentNameTextBox.Text != "" && lunchIDTextBox.Text != "" && teacherNameTextBox.Text != "" && originalAddTextBox.Text != "" && loanAddTextBox.Text != ""
                && statusComboBox.Text != "")
            {
                String fullName = studentNameTextBox.Text;
                int lunchID = int.Parse(lunchIDTextBox.Text);
                String teacherName = teacherNameTextBox.Text;
                int originalTag = int.Parse(originalAddTextBox.Text);
                int loanTag = int.Parse(loanAddTextBox.Text);
                String status = statusComboBox.Text;
                //String blank = "";

                // Open connection to database
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into ChromebookTable values('" + fullName + "','" + lunchID + "','" + teacherName + "','" + originalTag + "','" + loanTag + "','" + status + "','" + "" + "','" + "" + "')";
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Chromebook was successfully added!");
            }
            else
                MessageBox.Show("Fill out all fields.");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear all add fields
            studentNameTextBox.Text = "";
            lunchIDTextBox.Text = "";
            teacherNameTextBox.Text = "";
            originalAddTextBox.Text = "";
            loanAddTextBox.Text = "";
            statusComboBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //SqlCommand findCommand;
            //SqlDataReader dataReader;
            //// open database and change location of item
            //connection.Open();
            //String selectQuery = "select \"Original Chromebook\" from ChromebookTable where \"Lunch ID\"='" + int.Parse(studentEditTextBox.Text) + "'";
            //findCommand = new SqlCommand(selectQuery, connection);

            //int originalWSDTag;
            //int loanWSDTag;

            //dataReader = findCommand.ExecuteReader();
            //if(dataReader.Read())
            //{
            //    originalWSDTag = dataReader.GetInt32();
            //}
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Open database and delete all data for selected item
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from InventoryTable where Tag='" + deleteTextBox.Text + "'";
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
