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
            addTypeComboBox.Text = "Desktop";
        }

        private void addLaptopButton_Click(object sender, EventArgs e)
        {
            addTypeComboBox.Text = "Laptop";
        }

        private void addMonitorButton_Click(object sender, EventArgs e)
        {
            addTypeComboBox.Text = "Monitor";
        }

        private void addPrinterButton_Click(object sender, EventArgs e)
        {
            addTypeComboBox.Text = "Printer";
        }

        private void addSmartboardButton_Click(object sender, EventArgs e)
        {
            addTypeComboBox.Text = "Smartboard";
        }

        private void addProjectorButton_Click(object sender, EventArgs e)
        {
            addTypeComboBox.Text = "Projector";
        }

        private void addTabletButton_Click(object sender, EventArgs e)
        {
            addTypeComboBox.Text = "Tablet";
        }

        private void addAccessoriesButton_Click(object sender, EventArgs e)
        {
            addTypeComboBox.Text = "Accessories";
        }

        private void otherButton_Click(object sender, EventArgs e)
        {
            addTypeComboBox.Text = "Other";
        }

        private void addWebberButton_Click(object sender, EventArgs e)
        {
            addTypeComboBox.Text = "Webber";
        }

        private void addActiveButton_Click(object sender, EventArgs e)
        {
            addStatusComboBox.Text = "Active";
        }

        private void addInactiveButton_Click(object sender, EventArgs e)
        {
            addStatusComboBox.Text = "Inactive";
        }

        private void addRepairButton_Click(object sender, EventArgs e)
        {
            addStatusComboBox.Text = "Repair";
        }

        private void addSurplusButton_Click(object sender, EventArgs e)
        {
            addStatusComboBox.Text = "Surplus";
        }

        private void addUnknownButton_Click(object sender, EventArgs e)
        {
            addStatusComboBox.Text = "Unknown";
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
                    addTypeComboBox.Text == "Smartboard" || addTypeComboBox.Text == "Projector" || addTypeComboBox.Text == "Tablet" || addTypeComboBox.Text == "Accessories" ||
                    addTypeComboBox.Text == "Alternative" || addTypeComboBox.Text == "Webber")
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
