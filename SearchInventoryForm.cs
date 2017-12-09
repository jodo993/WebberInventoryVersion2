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
    public partial class SearchInventoryForm : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public SearchInventoryForm()
        {
            InitializeComponent();

            // Connect to database             
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Webber Inventory\V4\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase_be.accdb;Persist Security Info=False;";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text != "")
            {
                CheckDigitClass checkDigit = new CheckDigitClass();
                bool searchDigit = checkDigit.digitOnly(searchTextBox.Text);

                if (searchDigit == true)
                {
                    try
                    {
                        connection.Open();

                        int search = int.Parse(searchTextBox.Text);

                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "select * from Main_Inventory where Tag=" + search + "";
                        command.CommandText = query;

                        // Data Table shows and hold data
                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        string page = "Search";
                        string button = "Search";
                        string exception = ex.ToString();
                        BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                        bugSplat.ShowDialog();

                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Please input numbers only.");
            }
            else
                MessageBox.Show("Please input a tag number.");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string checkedButton = "";
            string tag = updateTagTextBox.Text;
            string date = DateTime.Now.ToString();
            string query = "";

            if (locationRadioButton.Checked)
                checkedButton = "Location";
            else
                checkedButton = "Status";

            if (checkedButton == "Location")
            {
                string location = updateLocationComboBox.Text;
                query = "update Main_Inventory set Location='" + location + "',TimeUpdated='" + date + "' where Tag=" + tag + "";
            }
            else
            {
                string status = updateStatusComboBox.Text;
                query = "update Main_Inventory set Status='" + status + "',TimeUpdated='" + date + "' where Tag=" + tag + "";
            }

            // Open database and change location of item
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = query;
            command.ExecuteNonQuery();

            connection.Close();

            MessageBox.Show(checkedButton + " was updated for item tag #" + tag + ".");

            // Clear boxes
            updateTagTextBox.Text = "";
            updateLocationComboBox.Text = "";
            updateStatusComboBox.Text = "";
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (removeTextBox.Text == "")
                MessageBox.Show("Please input a tag number.");
            else
            {
                CheckDigitClass checkDigit = new CheckDigitClass();
                bool removeDigit = checkDigit.digitOnly(removeTextBox.Text);

                if (removeDigit == true)
                {
                    try
                    {
                        // Open database and delete all data for selected item
                        connection.Open();

                        int removeItem = int.Parse(removeTextBox.Text);

                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        command.CommandText = "delete from Main_Inventory where Tag=" + removeItem + "";
                        command.ExecuteNonQuery();

                        connection.Close();

                        MessageBox.Show("All data was deleted for item tag #" + removeTextBox.Text + ".");
                    }
                    catch (Exception ex)
                    {
                        string page = "Search";
                        string button = "Remove";
                        string exception = ex.ToString();
                        BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                        bugSplat.ShowDialog();

                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Tag number must be numbers only.");
            }
        }

        private void clearRemoveButton_Click(object sender, EventArgs e)
        {
            removeTextBox.Text = "";
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

        private void refreshButton_Click(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;

            if (categorySearchComboBox.Text == "Desktop")
            {
                command.CommandText = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Laptop")
            {
                command.CommandText = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Monitor")
            {
                command.CommandText = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Printer")
            {
                command.CommandText = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Smartboard")
            {
                command.CommandText = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Projector")
            {
                command.CommandText = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Tablet")
            {
                command.CommandText = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Accessories")
            {
                command.CommandText = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Webber")
            {
                command.CommandText = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Active")
            {
                command.CommandText = "select * from Main_Inventory where Status='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Inactive")
            {
                command.CommandText = "select * from Main_Inventory where Status='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Repair")
            {
                command.CommandText = "select * from Main_Inventory where Status='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Surplus")
            {
                command.CommandText = "select * from Main_Inventory where Status='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Unknown")
            {
                command.CommandText = "select * from Main_Inventory where Status='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Office")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "District")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "MPR")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "A1")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "A2")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "A3")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "A4")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "B1")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "B2")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "B3")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "B4")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "C1")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "C2")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "C3")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "C4")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "D1")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "D2")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "D3")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "D4")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "E1")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "E2")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "E3")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "E4")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "F1")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "F2")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "F3")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "F4")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else if (categorySearchComboBox.Text == "Other")
            {
                command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
            }
            else
            {
                MessageBox.Show("Select a category.");
                connection.Close();
                return;
            }

            // Data Table shows and hold data
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.Close();
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            // Get all fields in table and show
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Main_Inventory";

            // Data Table shows and hold data
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.Close();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            int number = categorySearchComboBox.SelectedIndex;

            if (number >= 0 && number <= 44)
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                if (categorySearchComboBox.SelectedIndex >= 0 && categorySearchComboBox.SelectedIndex <= 8)
                {
                    command.CommandText = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
                }
                else if (categorySearchComboBox.SelectedIndex >= 9 && categorySearchComboBox.SelectedIndex <= 13)
                {
                    command.CommandText = "select * from Main_Inventory where Status='" + categorySearchComboBox.Text + "'";
                }
                else if (categorySearchComboBox.SelectedIndex >= 14 && categorySearchComboBox.SelectedIndex <= 44)
                {
                    command.CommandText = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
                }
                else
                {
                    MessageBox.Show("Select an option.");
                    connection.Close();
                    return;
                }

                // Data Table shows and hold data
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                connection.Close();
            }
            else
                MessageBox.Show("Please select a given option.");
        }

        Bitmap bmp;
        private void printDocumentSearch_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        
        private void printButton_Click(object sender, EventArgs e)
        {
            //Graphics graph = this.CreateGraphics();
            //bmp = new Bitmap(this.Size.Width, this.Size.Height, graph);
            //Graphics mg = Graphics.FromImage(bmp);
            //mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            //printPreviewDialogSearch.ShowDialog();

            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialogSearch.ShowDialog();
        }

        private void locationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            update2GroupBox.Text = "Update Location";
            newLabel.Text = "New Location";
            updateStatusComboBox.Visible = false;
            updateLocationComboBox.Visible = true;
            updateButton.Text = "Update Location";
        }

        private void statusRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            update2GroupBox.Text = "Update Status";
            newLabel.Text = "New Status";
            updateLocationComboBox.Visible = false;
            updateStatusComboBox.Visible = true;
            updateButton.Text = "Update Status";
        }
    }
}