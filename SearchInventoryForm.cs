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

        }

        private void yesLocationButton_Click(object sender, EventArgs e)
        {

        }

        private void noLocationButton_Click(object sender, EventArgs e)
        {

        }

        private void updateStatusButton_Click(object sender, EventArgs e)
        {

        }

        private void yesStatusButton_Click(object sender, EventArgs e)
        {

        }

        private void noStatusButton_Click(object sender, EventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }

        private void clearRemoveButton_Click(object sender, EventArgs e)
        {
            removeTextBox.Text = "";
        }

        private void yesRemoveButton_Click(object sender, EventArgs e)
        {

        }

        private void noRemoveButton_Click(object sender, EventArgs e)
        {

        }

        
    }
}
