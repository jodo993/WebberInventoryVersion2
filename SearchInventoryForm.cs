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
        // Open connection to database
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\josep\Documents\WebberInventory.mdf;Integrated Security=True;Connect Timeout=30");
        public SearchInventoryForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from InventoryTable where tag='" + searchTextBox.Text + "'";
            command.ExecuteNonQuery();

            // Data Table shows and hold data
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        private void updateLocationButton_Click(object sender, EventArgs e)
        {
            // Activates location verification questions
            locationCheckLabel.Visible = true;
            yesLocationButton.Visible = true;
            noLocationButton.Visible = true;
        }

        private void yesLocationButton_Click(object sender, EventArgs e)
        {
            // Open database and change location of item
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update InventoryTable set Location='" + updateLocationComboBox.Text + "' where Tag='" + updateTagTextBox.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();

            // Update time location was updated
            connection.Open();
            SqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "update InventoryTable set Time='" + DateTime.Now + "' where Tag='" + updateTagTextBox.Text + "'";
            cmd2.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Location was updated for item tag #" + updateTagTextBox.Text + ".");

            // Deactivates location verification questions
            locationCheckLabel.Visible = false;
            yesLocationButton.Visible = false;
            noLocationButton.Visible = false;
        }

        private void noLocationButton_Click(object sender, EventArgs e)
        {
            // Deactivates location verification questions
            locationCheckLabel.Visible = true;
            yesLocationButton.Visible = true;
            noLocationButton.Visible = true;
        }

        private void updateStatusButton_Click(object sender, EventArgs e)
        {
            // Activates status verification questions
            statusCheckLabel.Visible = true;
            yesStatusButton.Visible = true;
            noStatusButton.Visible = true;
        }

        private void yesStatusButton_Click(object sender, EventArgs e)
        {
            // Update the status of the item
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update InventoryTable set Status='" + updateStatusComboBox.Text + "' where Tag='" + updateTag2TextBox.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();

            // Update the time status was updated
            connection.Open();
            SqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "update InventoryTable set Time='" + DateTime.Now + "' where Tag='" + updateTag2TextBox.Text + "'";
            cmd2.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Status was updated for item tag #" + updateTag2TextBox.Text + ".");

            // Deactivates status verification questions
            statusCheckLabel.Visible = false;
            yesStatusButton.Visible = false;
            noStatusButton.Visible = false;
        }

        private void noStatusButton_Click(object sender, EventArgs e)
        {
            // Deactivates status verification questions
            statusCheckLabel.Visible = true;
            yesStatusButton.Visible = true;
            noStatusButton.Visible = true;
        }

        private void removeButton_Click(object sender, EventArgs e)
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

        private void clearRemoveButton_Click(object sender, EventArgs e)
        {
            removeTextBox.Text = "";
        }

        private void yesRemoveButton_Click(object sender, EventArgs e)
        {
            // Open database and delete all data for selected item
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from InventoryTable where Tag='" + removeTextBox.Text + "'";
            cmd.ExecuteNonQuery();
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
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from InventoryTable where tag='" + searchTextBox.Text + "'";
            command.ExecuteNonQuery();

            // Data Table shows and hold data
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.Close();
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            // Get all fields in table and show
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from InventoryTable";
            cmd.ExecuteNonQuery();

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.Close();
        }
    }
}
