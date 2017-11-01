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
    public partial class AddInventoryForm : Form
    {
        // Open connection to database
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\WebberInventory.mdf;Integrated Security=True;Connect Timeout=30");

        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public AddInventoryForm()
        {
            InitializeComponent();

            // Connect to database                                                       
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\WebberMainDatabase.accdb;Persist Security Info=False;";
        }

        private void addMainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm newMainMenuForm = new MainMenuForm();
            newMainMenuForm.ShowDialog();

            this.Close();
        }

        private void addExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check to see if any slots are blank
                if (addTypeComboBox.Text != "" && addMakeTextBox.Text != "" && addModelTextBox.Text != "" && addTagTextBox.Text != "" && addLocationComboBox.Text != "" &&
                    addStatusComboBox.Text != "")
                {
                    // Check to see if type matches with one that is required
                    if (addTypeComboBox.Text == "Desktop" || addTypeComboBox.Text == "Laptop" || addTypeComboBox.Text == "Monitor" || addTypeComboBox.Text == "Printer" ||
                    addTypeComboBox.Text == "Smartboard" || addTypeComboBox.Text == "Projector" || addTypeComboBox.Text == "Tablet" || addTypeComboBox.Text == "Accessories"
                    || addTypeComboBox.Text == "Webber")
                    {
                        // Hide wrong label
                        typeWrongLabel.Visible = false;

                        if (addStatusComboBox.Text == "Active" || addStatusComboBox.Text == "Inactive" || addStatusComboBox.Text == "Repair" || addStatusComboBox.Text == "Surplus" ||
                            addStatusComboBox.Text == "Unknown")
                        {
                            // Write the information into the database
                            connection.Open();

                            string type = addTypeComboBox.Text;
                            string make = addMakeTextBox.Text;
                            string model = addModelTextBox.Text;
                            int tag = int.Parse(addTagTextBox.Text);
                            string location = addLocationComboBox.Text;
                            string status = addStatusComboBox.Text;
                            string date = DateTime.Today.ToString();

                            OleDbCommand command = new OleDbCommand();
                            command.Connection = connection;
                            command.CommandText = "insert into MainInventory (Type,Make,Model,Tag,Location,Status) values('" + type + "','" + make + "','" + model + "','" + tag + "','" + location + "','" + status + "')";
                            command.ExecuteNonQuery();
                            MessageBox.Show("Item was successfully added!");

                            connection.Close();

                            // Clear some fields
                            addMakeTextBox.Text = "";
                            addModelTextBox.Text = "";
                            addTagTextBox.Text = "";
                        }
                        else
                            statusWrongLabel.Visible = true;
                    }
                    else
                        typeWrongLabel.Visible = true;
                }
                else
                    MessageBox.Show("Please fill in slots first.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check for duplicates or errors." + ex);
            }
        }

        private void addClearButton_Click(object sender, EventArgs e)
        {
            // Clear all fields
            addTypeComboBox.Text = "";
            addMakeTextBox.Text = "";
            addModelTextBox.Text = "";
            addTagTextBox.Text = "";
            addLocationComboBox.Text = "";
            addStatusComboBox.Text = "";

            // Wrong input labels
            typeWrongLabel.Visible = false;
        }
    }
}
