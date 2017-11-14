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
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase_be.accdb;Persist Security Info=False;";
        }

        private void searchButton_Click(object sender, EventArgs e)
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
            catch (Exception)
            {
                MessageBox.Show("Unable to find, please try again.");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        private void updateLocationButton_Click(object sender, EventArgs e)
        {
            if (verificationCheckBox.Checked)
            {
                // Open database and change location of item
                connection.Open();

                string location = updateLocationComboBox.Text;
                string tag = updateTagTextBox.Text;
                string date = DateTime.Now.ToString();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "update Main_Inventory set Location='" + location + "',TimeUpdated='" + date + "' where Tag=" + tag + ""; // might need to get rid of one quote '
                command.CommandText = query;
                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Location was updated for item tag #" + tag + ".");

                // Clear boxes
                updateTagTextBox.Text = "";
                updateLocationComboBox.Text = "";
            }
            else
            {
                // Activates location verification questions
                locationCheckLabel.Visible = true;
                yesLocationButton.Visible = true;
                noLocationButton.Visible = true;
            }  
        }

        private void yesLocationButton_Click(object sender, EventArgs e)
        {
            // Open database and change location of item
            connection.Open();

            int tag = int.Parse(updateTagTextBox.Text);
            string location = updateLocationComboBox.Text;
            string date = DateTime.Now.ToString();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "update Main_Inventory set Location='" + location + "',TimeUpdated='" + date + "' where Tag=" + tag + "";
            command.ExecuteNonQuery();

            connection.Close();

            MessageBox.Show("Location was updated for item tag #" + updateTagTextBox.Text + ".");

            // Clear boxes
            updateTagTextBox.Text = "";
            updateLocationComboBox.Text = "";

            // Deactivates location verification questions
            locationCheckLabel.Visible = false;
            yesLocationButton.Visible = false;
            noLocationButton.Visible = false;
        }

        private void noLocationButton_Click(object sender, EventArgs e)
        {
            // Deactivates location verification questions
            locationCheckLabel.Visible = false;
            yesLocationButton.Visible = false;
            noLocationButton.Visible = false;
        }

        private void updateStatusButton_Click(object sender, EventArgs e)
        {
            if (verificationCheckBox.Checked)
            {
                // Update the status of the item
                connection.Open();

                int tag2 = int.Parse(updateTag2TextBox.Text);
                string status = updateStatusComboBox.Text;
                string date = DateTime.Now.ToString();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "update Main_Inventory set Status='" + status + "',TimeUpdated='" + date + "' where Tag=" + tag2 + "";
                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Status was updated for item tag #" + updateTag2TextBox.Text + ".");

                // Clear boxes
                updateTag2TextBox.Text = "";
                updateStatusComboBox.Text = "";
            }
            else
            {
                // Activates status verification questions
                statusCheckLabel.Visible = true;
                yesStatusButton.Visible = true;
                noStatusButton.Visible = true;
            }
        }

        private void yesStatusButton_Click(object sender, EventArgs e)
        {
            // Update the status of the item
            connection.Open();

            int tag2 = int.Parse(updateTag2TextBox.Text);
            string status = updateStatusComboBox.Text;
            string date = DateTime.Now.ToString();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "update Main_Inventory set Status='" + status + "',TimeUpdated='" + date + "' where Tag=" + tag2 + "";
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Status was updated for item tag #" + updateTag2TextBox.Text + ".");

            updateTag2TextBox.Text = "";
            updateStatusComboBox.Text = "";

            // Deactivates status verification questions
            statusCheckLabel.Visible = false;
            yesStatusButton.Visible = false;
            noStatusButton.Visible = false;
        }

        private void noStatusButton_Click(object sender, EventArgs e)
        {
            // Deactivates status verification questions
            statusCheckLabel.Visible = false;
            yesStatusButton.Visible = false;
            noStatusButton.Visible = false;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (verificationCheckBox.Checked)
            {
                // Open database and delete all data for selected item
                connection.Open();

                int removeItem = int.Parse(removeTextBox.Text);

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "delete from Main_Inventory where Tag='" + removeItem + "'";
                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("All data was deleted for item tag #" + removeTextBox.Text + ".");
            }
            else
            {
                // Hides all remove group box items
                removeGroupBox.Visible = false;
                removeTagLabel.Visible = false;
                removeTextBox.Visible = false;
                removeButton.Visible = false;
                clearRemoveButton.Visible = false;

                // Show all verify remove group box items
                verifyRemoveGroupBox.Visible = true;
                removeCheckLabel.Visible = true;
                yesRemoveButton.Visible = true;
                noRemoveButton.Visible = true;
            }
        }

        private void clearRemoveButton_Click(object sender, EventArgs e)
        {
            removeTextBox.Text = "";
        }

        private void yesRemoveButton_Click(object sender, EventArgs e)
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

            // Hide all verify remove group box items
            verifyRemoveGroupBox.Visible = false;
            removeCheckLabel.Visible = false;
            yesRemoveButton.Visible = false;
            noRemoveButton.Visible = false;

            // Show all remove group box items
            removeGroupBox.Visible = true;
            removeTagLabel.Visible = true;
            removeTextBox.Visible = true;
            removeButton.Visible = true;
            clearRemoveButton.Visible = true;
        }

        private void noRemoveButton_Click(object sender, EventArgs e)
        {
            // Hide all verify remove group box items
            verifyRemoveGroupBox.Visible = false;
            removeCheckLabel.Visible = false;
            yesRemoveButton.Visible = false;
            noRemoveButton.Visible = false;

            // Show all remove group box items
            removeGroupBox.Visible = true;
            removeTagLabel.Visible = true;
            removeTextBox.Visible = true;
            removeButton.Visible = true;
            clearRemoveButton.Visible = true;
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            //
        }
    }
}