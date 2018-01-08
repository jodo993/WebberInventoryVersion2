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
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public AddInventoryForm()
        {
            InitializeComponent();

            // Connect to database                                                       
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase_be.accdb;Persist Security Info=False;";
        }

        // Send user back to admin main menu
        private void addMainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm newMainMenuForm = new MainMenuForm();
            newMainMenuForm.ShowDialog();

            this.Close();
        }

        // Terminate the program
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
                        // Hide type wrong label
                        typeWrongLabel.Visible = false;
                        warningLabel.Visible = false;

                        if (addStatusComboBox.Text == "Active" || addStatusComboBox.Text == "Inactive" || addStatusComboBox.Text == "Repair" || addStatusComboBox.Text == "Surplus" ||
                            addStatusComboBox.Text == "Unknown")
                        {
                            // Hide status wrong label
                            statusWrongLabel.Visible = false;
                            warning2Label.Visible = false;

                            // Check tag for all digits
                            CheckDigitClass checkDigit = new CheckDigitClass();
                            bool digit = checkDigit.digitOnly(addTagTextBox.Text);
                            if (digit == true)
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
                                command.CommandText = "insert into Main_Inventory (Type,Make,Model,Tag,Location,Status) values('" + type + "','" + make + "','" + model + "'," + tag + ",'" + location + "','" + status + "')";
                                command.ExecuteNonQuery();     

                                connection.Close();
                                MessageBox.Show("Item was successfully added!");

                                // Clear some fields
                                addMakeTextBox.Text = "";
                                addModelTextBox.Text = "";
                                addTagTextBox.Text = "";
                                typeWrongLabel.Visible = false;
                                statusWrongLabel.Visible = false;
                                warningLabel.Visible = false;
                                warning2Label.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("WSD tag needs to be digits only.");
                            }
                        }
                        else
                        {
                            statusWrongLabel.Visible = true;
                            warning2Label.Visible = true;
                        }       
                    }
                    else
                    {
                        typeWrongLabel.Visible = true;
                        warningLabel.Visible = true;
                    }
                }
                else
                    MessageBox.Show("All fields are required.");
            }
            catch (Exception ex)
            {
                // Send information to be recorded in bug report
                string page = "Add";
                string button = "Add";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page,button,exception);
                bugSplat.ShowDialog();

                this.Close();
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
            statusWrongLabel.Visible = false;
            warningLabel.Visible = false;
            warning2Label.Visible = false;
        }
    }
}
