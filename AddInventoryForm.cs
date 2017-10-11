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

        private void addDesktopButton_Click(object sender, EventArgs e)
        {
            addTypeTextBox.Text = "Desktop";
        }

        private void addLaptopButton_Click(object sender, EventArgs e)
        {
            addTypeTextBox.Text = "Laptop";
        }

        private void addMonitorButton_Click(object sender, EventArgs e)
        {
            addTypeTextBox.Text = "Monitor";
        }

        private void addPrinterButton_Click(object sender, EventArgs e)
        {
            addTypeTextBox.Text = "Printer";
        }

        private void addSmartboardButton_Click(object sender, EventArgs e)
        {
            addTypeTextBox.Text = "Smartboard";
        }

        private void addProjectorButton_Click(object sender, EventArgs e)
        {
            addTypeTextBox.Text = "Projector";
        }

        private void addTabletButton_Click(object sender, EventArgs e)
        {
            addTypeTextBox.Text = "Tablet";
        }

        private void addAccessoriesButton_Click(object sender, EventArgs e)
        {
            addTypeTextBox.Text = "Accessories";
        }

        private void otherButton_Click(object sender, EventArgs e)
        {
            addTypeTextBox.Text = "Other";
        }

        private void addWebberButton_Click(object sender, EventArgs e)
        {
            addTypeTextBox.Text = "Webber";
        }

        private void addActiveButton_Click(object sender, EventArgs e)
        {
            addStatusTextBox.Text = "Active";
        }

        private void addInactiveButton_Click(object sender, EventArgs e)
        {
            addStatusTextBox.Text = "Inactive";
        }

        private void addRepairButton_Click(object sender, EventArgs e)
        {
            addStatusTextBox.Text = "Repair";
        }

        private void addSurplusButton_Click(object sender, EventArgs e)
        {
            addStatusTextBox.Text = "Surplus";
        }

        private void addUnknownButton_Click(object sender, EventArgs e)
        {
            addStatusTextBox.Text = "Unknown";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check to see if any slots are blank
                if (addTypeTextBox.Text != "" && addMakeTextBox.Text != "" && addModelTextBox.Text != "" && addTagTextBox.Text != "" && addLocationComboBox.Text != "" &&
                    addStatusTextBox.Text != "")
                {
                    // Check to see if type matches with one that is required
                    if (addTypeTextBox.Text == "Desktop" || addTypeTextBox.Text == "Laptop" || addTypeTextBox.Text == "Monitor" || addTypeTextBox.Text == "Printer" ||
                    addTypeTextBox.Text == "Smartboard" || addTypeTextBox.Text == "Projector" || addTypeTextBox.Text == "Tablet" || addTypeTextBox.Text == "Accessories" || 
                    addTypeTextBox.Text == "Alternative" || addTypeTextBox.Text == "Webber")
                    {
                        // Hide wrong label
                        typeWrongLabel.Visible = false;

                        if (addStatusTextBox.Text == "Active" || addStatusTextBox.Text == "Inactive" || addStatusTextBox.Text == "Repair" || addStatusTextBox.Text == "Surplus" ||
                            addStatusTextBox.Text == "Unknown")
                        {
                            if (verificationCheckBox.Checked)
                            {
                                // Write the information into the database
                                connection.Open();
                                SqlCommand command = connection.CreateCommand();
                                command.CommandType = CommandType.Text;
                                command.CommandText = "insert into InventoryTable values('" + addTypeTextBox.Text + "','" + addMakeTextBox.Text + "','" + addModelTextBox.Text + "','" + addTagTextBox.Text + "','" + addLocationComboBox.Text + "','" + addStatusTextBox.Text + "', '" + DateTime.Now + "')";
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
            command.CommandText = "insert into InventoryTable values('" + addTypeTextBox.Text + "','" + addMakeTextBox.Text + "','" + addModelTextBox.Text + "','" + addTagTextBox.Text + "','" + addLocationComboBox.Text + "','" + addStatusTextBox.Text + "', '" + DateTime.Now + "')";
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
            addTypeTextBox.Text = "";
            addMakeTextBox.Text = "";
            addModelTextBox.Text = "";
            addTagTextBox.Text = "";
            addLocationComboBox.Text = "";
            addStatusTextBox.Text = "";

            // Wrong input labels
            typeWrongLabel.Visible = false;

            // Verification Labels
            addVerifyLabel.Visible = false;
            yesButton.Visible = false;
            noButton.Visible = false;
        }
    }
}
