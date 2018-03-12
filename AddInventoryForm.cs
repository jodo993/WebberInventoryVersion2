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
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Webber Database\WebberMainDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        public AddInventoryForm()
        {
            InitializeComponent();
        }

        private void ClearLabels()
        {
            addTagTextBox.Text = "";
            typeWrongLabel.Visible = false;
            statusWrongLabel.Visible = false;
            warningLabel.Visible = false;
            warning2Label.Visible = false;
        }

        private void ClearTextBoxes()
        {
            addTypeComboBox.Text = "";
            addMakeTextBox.Text = "";
            addModelTextBox.Text = "";
            addLocationComboBox.Text = "";
            addStatusComboBox.Text = "";
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
                    if (addTypeComboBox.Text == "DESKTOP" || addTypeComboBox.Text == "LAPTOP" || addTypeComboBox.Text == "MONITOR" || addTypeComboBox.Text == "PRINTER" ||
                    addTypeComboBox.Text == "SMARTBOARD" || addTypeComboBox.Text == "PROJECTOR" || addTypeComboBox.Text == "TABLET" || addTypeComboBox.Text == "ACCESSORIES"
                    || addTypeComboBox.Text == "WEBBER")
                    {
                        // Hide type wrong label
                        typeWrongLabel.Visible = false;
                        warningLabel.Visible = false;

                        if (addStatusComboBox.Text == "ACTIVE" || addStatusComboBox.Text == "INACTIVE" || addStatusComboBox.Text == "REPAIR" || addStatusComboBox.Text == "SURPLUS" ||
                            addStatusComboBox.Text == "UNKNOWN")
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

                                string type = addTypeComboBox.Text.ToUpper();
                                string make = addMakeTextBox.Text.ToUpper();
                                string model = addModelTextBox.Text.ToUpper();
                                int tag = int.Parse(addTagTextBox.Text);
                                string location = addLocationComboBox.Text.ToUpper();
                                string status = addStatusComboBox.Text.ToUpper();
                                string date = DateTime.Now.ToString();

                                SqlCommand command = connection.CreateCommand();
                                command.CommandType = CommandType.Text;
                                command.CommandText = "insert into Main_Inventory (Type,Make,Model,Tag,Location,Status,TimeUpdated) values('" + type + "','" + make + "','" + model + "'," + tag + ",'" + location + "','" + status + "','" + date + "')";
                                command.ExecuteNonQuery();     

                                connection.Close();
                                MessageBox.Show("Item was successfully added!");

                                // Clear some fields
                                if (saveCheckBox.Checked)
                                {
                                    ClearLabels();
                                }
                                else
                                {
                                    ClearLabels();
                                    ClearTextBoxes();
                                }   
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
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void addClearButton_Click(object sender, EventArgs e)
        {
            // Clear all fields
            ClearLabels();
            ClearTextBoxes();
        }

        private void addStatusComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addButton.PerformClick();
            }
        }
    }
}
