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
    public partial class SearchInventoryForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Webber Technology Support SQL Database Version\WebberMainDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        public SearchInventoryForm()
        {
            InitializeComponent();
        }

        private void ModifySQLData(string query1)
        {
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = query1;
            command.ExecuteNonQuery();

            connection.Close();
        }

        private void SelectSQLData(string query1)
        {
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = query1;

            // Data Table shows and hold data
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.Close();
        }

        // Search for tag information
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text != "")
            {
                // Check to see if digit then search for tag information
                CheckDigitClass checkDigit = new CheckDigitClass();
                bool searchDigit = checkDigit.digitOnly(searchTextBox.Text);

                if (searchDigit == true)
                {
                    try
                    {
                        int search = int.Parse(searchTextBox.Text);
                        string query = "select * from Main_Inventory where Tag=" + search + "";
                        SelectSQLData(query);
                    }
                    catch (Exception ex)
                    {
                        // Get and send information to bug report
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

        // Clear tag search textbox
        private void clearButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        // Update location or status of item
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (locationRadioButton.Checked && updateLocationComboBox.Text == "")
            {
                MessageBox.Show("Please enter location.");
                return;
            }
            else if (statusRadioButton.Checked && updateStatusComboBox.Text == "")
            {
                MessageBox.Show("Please enter status.");
                return;
            }

            if (updateTagTextBox.Text == "")
            {
                MessageBox.Show("Please enter a tag number.");
            }
            else
            {
                CheckDigitClass checkDigit = new CheckDigitClass();
                bool tagDigit = checkDigit.digitOnly(updateTagTextBox.Text);

                if (tagDigit == true)
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

                    try
                    {
                        ModifySQLData(query);

                        MessageBox.Show(checkedButton + " was updated for item tag #" + tag + ".");

                        // Clear boxes
                        updateTagTextBox.Text = "";
                        updateLocationComboBox.Text = "";
                        updateStatusComboBox.Text = "";
                    }
                    catch (Exception ex)
                    {
                        // Get and send information to bug report
                        string page = "Search";
                        string button = "Update";
                        string exception = ex.ToString();
                        BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                        bugSplat.ShowDialog();

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Tag must be all digits.");
                }
            }
        }

        // Delete all data of an item with entered tag number
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
                        int removeItem = int.Parse(removeTextBox.Text);
                        string query = "delete from Main_Inventory where Tag=" + removeItem + "";
                        ModifySQLData(query);

                        MessageBox.Show("All data was deleted for item tag #" + removeTextBox.Text + ".");
                    }
                    catch (Exception ex)
                    {
                        // Get and send information to bug report
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

        // Clear tag number for remove section
        private void clearRemoveButton_Click(object sender, EventArgs e)
        {
            removeTextBox.Text = "";
        }

        // Go to main menu form
        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm newMainMenuForm = new MainMenuForm();
            newMainMenuForm.ShowDialog();

            this.Close();
        }

        // Terminate the program
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Refresh information on selected category
        private void refreshButton_Click(object sender, EventArgs e)
        {
            string category = categorySearchComboBox.Text;
            string query = "";
            try
            {
                if (categorySearchComboBox.Text == "Desktop" || categorySearchComboBox.Text == "Laptop" ||
                    categorySearchComboBox.Text == "Monitor" || categorySearchComboBox.Text == "Printer" ||
                    categorySearchComboBox.Text == "Smartboard" || categorySearchComboBox.Text == "Projector" ||
                    categorySearchComboBox.Text == "Tablet" || categorySearchComboBox.Text == "Accessories" ||
                    categorySearchComboBox.Text == "Webber")
                {
                    query = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
                }
                else if (categorySearchComboBox.Text == "Active" || categorySearchComboBox.Text == "Inactive" || categorySearchComboBox.Text == "Repair" ||
                         categorySearchComboBox.Text == "Surplus" || categorySearchComboBox.Text == "Unknown")
                {
                    query = "select * from Main_Inventory where Status='" + categorySearchComboBox.Text + "'";
                }
                else if (categorySearchComboBox.Text == "Office" || categorySearchComboBox.Text == "District" || categorySearchComboBox.Text == "MPR" ||
                         categorySearchComboBox.Text == "A1" || categorySearchComboBox.Text == "A2" || categorySearchComboBox.Text == "A3" ||
                         categorySearchComboBox.Text == "A4" || categorySearchComboBox.Text == "B1" || categorySearchComboBox.Text == "B2" ||
                         categorySearchComboBox.Text == "B3" || categorySearchComboBox.Text == "B4" || categorySearchComboBox.Text == "C1" ||
                         categorySearchComboBox.Text == "C2" || categorySearchComboBox.Text == "C3" || categorySearchComboBox.Text == "C4" ||
                         categorySearchComboBox.Text == "D1" || categorySearchComboBox.Text == "D2" || categorySearchComboBox.Text == "D3" ||
                         categorySearchComboBox.Text == "D4" || categorySearchComboBox.Text == "E1" || categorySearchComboBox.Text == "E2" ||
                         categorySearchComboBox.Text == "E3" || categorySearchComboBox.Text == "E4" || categorySearchComboBox.Text == "F1" ||
                         categorySearchComboBox.Text == "F2" || categorySearchComboBox.Text == "F3" || categorySearchComboBox.Text == "F4" ||
                         categorySearchComboBox.Text == "Other")
                {
                    query = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
                }
                else
                {
                    MessageBox.Show("Select a category.");
                    return;
                }

                SelectSQLData(query);
            }
            catch (Exception ex)
            {
                // Get and send information to bug report
                string page = "Search";
                string button = "Refresh";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }    
        }

        // Show all data of all items in main inventory
        private void showAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from Main_Inventory";
                SelectSQLData(query);
            }
            catch (Exception ex)
            {
                // Get and send information to bug report
                string page = "Search";
                string button = "Show All";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        // Search for items 
        private void findButton_Click(object sender, EventArgs e)
        {
            int number = categorySearchComboBox.SelectedIndex;
            string query = "";
            try
            {
                if (number >= 0 && number <= 44)
                {
                    if (categorySearchComboBox.SelectedIndex >= 0 && categorySearchComboBox.SelectedIndex <= 8)
                    {
                        query = "select * from Main_Inventory where Type='" + categorySearchComboBox.Text + "'";
                    }
                    else if (categorySearchComboBox.SelectedIndex >= 9 && categorySearchComboBox.SelectedIndex <= 13)
                    {
                        query = "select * from Main_Inventory where Status='" + categorySearchComboBox.Text + "'";
                    }
                    else if (categorySearchComboBox.SelectedIndex >= 14 && categorySearchComboBox.SelectedIndex <= 44)
                    {
                        query = "select * from Main_Inventory where Location='" + categorySearchComboBox.Text + "'";
                    }
                    else
                    {
                        MessageBox.Show("Select an option.");
                        return;
                    }

                    SelectSQLData(query);
                }
                else
                    MessageBox.Show("Please select a given option.");
            }
            catch (Exception ex)
            {
                // Get and send information to bug report
                string page = "Search";
                string button = "Find";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
            
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

        // Display correct word based on radio button checked
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

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
            }
        }

        private void removeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                removeButton.PerformClick();
            }
        }

        private void categorySearchComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                findButton.PerformClick();
            }
        }
    }
}