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
    public partial class AddInventoryForm : Form
    {
        // Open connection to database
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\WebberInventory.mdf;Integrated Security=True;Connect Timeout=30");
        public AddInventoryForm()
        {
            InitializeComponent();
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
                            if (verificationCheckBox.Checked)
                            {
                                // Write the information into the database
                                connection.Open();
                                SqlCommand command = connection.CreateCommand();
                                command.CommandType = CommandType.Text;
                                command.CommandText = "insert into InventoryTable values('" + addTypeComboBox.Text + "','" + addMakeTextBox.Text + "','" + addModelTextBox.Text + "','" + addTagTextBox.Text + "','" + addLocationComboBox.Text + "','" + addStatusComboBox.Text + "', '" + DateTime.Now + "')";
                                command.ExecuteNonQuery();
                                connection.Close();

                                MessageBox.Show("Item was successfully added!");

                                // Clear some fields
                                addMakeTextBox.Text = "";
                                addModelTextBox.Text = "";
                                addTagTextBox.Text = "";
                            }
                            else
                            {
                                // Verify user choice
                                addVerifyLabel.Visible = true;
                                yesButton.Visible = true;
                                noButton.Visible = true;

                                // Hide label and buttons and notify user add was successful
                                addVerifyLabel.Visible = false;
                                yesButton.Visible = false;
                                noButton.Visible = false;
                            }   
                        }
                        else
                        {
                            statusWrongLabel.Visible = true;
                        }
                    }
                    else
                    {
                        typeWrongLabel.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in slots first.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check for duplicates or errors.");
            }
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            // Hide label and buttons and notify user add was successful
            addVerifyLabel.Visible = false;
            yesButton.Visible = false;
            noButton.Visible = false;

            // Write the information into the database
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "insert into InventoryTable values('" + addTypeComboBox.Text + "','" + addMakeTextBox.Text + "','" + addModelTextBox.Text + "','" + addTagTextBox.Text + "','" + addLocationComboBox.Text + "','" + addStatusComboBox.Text + "', '" + DateTime.Now + "')";
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Item was successfully added!");
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            //// Hide label and buttons and notify user add failed
            //addVerifyLabel.Visible = false;
            //yesButton.Visible = false;
            //noButton.Visible = false;
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

            // Verification Labels
            addVerifyLabel.Visible = false;
            yesButton.Visible = false;
            noButton.Visible = false;
        }
    }
}
