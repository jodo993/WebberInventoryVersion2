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
using System.Diagnostics;

namespace Webber_Inventory_Search_2017_2018
{
    public partial class SuppliesInformationForm : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        // Link of item
        string link = "";

        public SuppliesInformationForm(string user)
        {
            InitializeComponent();
            // Signify which mode user is
            userLabel.Text = user;
            // Connect to database                                                       
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=T:\Webber Database\WebberMainDatabase_be.accdb;Persist Security Info=False;";
        }

        private void SuppliesInformationForm_Load(object sender, EventArgs e)
        {
            // Check for which type is selected
            try
            {
                connection.Open();

                OleDbCommand commandType = new OleDbCommand();
                commandType.Connection = connection;
                string query = "select Type from Supply_Information";
                commandType.CommandText = query;

                List<string> typeList = new List<string>();
                int i = 0;

                // Add type to list
                OleDbDataReader readerType = commandType.ExecuteReader();
                while (readerType.Read())
                {
                    typeList[i] = readerType["Type"].ToString();
                    i++;
                }

                // Checks for copy of same type and only display one
                // Brute force algorithm, will slow as list gets bigger
                int listLength = i;
                for (int a = 0; a < listLength; a++)
                {
                    typeComboBox.Items.Add(typeList[a]);
                    for (int b = a + 1; b < listLength; b++)
                    {
                        if (typeList[b] == typeList[a])
                            typeComboBox.Items.Remove(typeList[a]);
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                // Get bug info and send report
                string page = "Supply";
                string button = "Page Load";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        // See which type is selected and show brand relating to it
        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear all comboboxes
            brandComboBox.Items.Clear();
            modelComboBox.Items.Clear();
            string item = typeComboBox.Text;

            // Check for which brand is selected
            try
            {
                connection.Open();

                OleDbCommand commandBrand = new OleDbCommand();
                commandBrand.Connection = connection;
                string query = "select * from Supply_Information where Type='" + item + "'";
                commandBrand.CommandText = query;

                List<string> brandList = new List<string>();
                int i = 0;

                OleDbDataReader readerBrand = commandBrand.ExecuteReader();
                while (readerBrand.Read())
                {
                    brandList[i] = readerBrand["Brand"].ToString();
                    i++;
                }

                int listLength = i;
                for (int a = 0; a < listLength; a++)
                {
                    brandComboBox.Items.Add(brandList[a]);
                    for (int b = a + 1; b < listLength; b++)
                    {
                        if (brandList[b] == brandList[a])
                            brandComboBox.Items.Remove(brandList[a]);
                    }
                }
                
                connection.Close();
            }
            catch (Exception ex)
            {
                // Get bug info and send report
                string page = "Supply";
                string button = "Type";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void brandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            modelComboBox.Items.Clear();
            catComboBox.Items.Clear();
            string item = brandComboBox.Text;
            // Check for which brand is selected
            try
            {
                connection.Open();

                OleDbCommand commandModel = new OleDbCommand();
                commandModel.Connection = connection;
                string query = "select * from Supply_Information where Brand='" + item + "'";
                commandModel.CommandText = query;

                List<string> modelList = new List<string>();
                int i = 0;

                // Add to list
                OleDbDataReader readermodel = commandModel.ExecuteReader();
                while (readermodel.Read())
                {
                    modelList[i] = readermodel["Model"].ToString();
                    i++;
                }

                // Checks for copy of same type and only display one
                // Brute force algorithm, will slow as list gets bigger
                int listLength = i;
                for (int a = 0; a < listLength; a++)
                {
                    modelComboBox.Items.Add(modelList[a]);
                    for (int b = a + 1; b < listLength; b++)
                    {
                        if (modelList[b] == modelList[a])
                            modelComboBox.Items.Remove(modelList[a]);
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                // Get bug info and send report
                string page = "Supply";
                string button = "Brand";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void modelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            catComboBox.Items.Clear();
            string item = modelComboBox.Text;

            // Check for which brand is selected
            try
            {
                connection.Open();

                OleDbCommand commandCat = new OleDbCommand();
                commandCat.Connection = connection;
                string query = "select * from Supply_Information where Model='" + item + "'";
                commandCat.CommandText = query;

                OleDbDataReader readerCat = commandCat.ExecuteReader();
                while (readerCat.Read())
                {
                    catComboBox.Items.Add(readerCat["Category"].ToString());
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "Supply";
                string button = "Model";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        private void catComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = catComboBox.Text;
            // Check for which brand is selected
            try
            {
                connection.Open();

                OleDbCommand commandName = new OleDbCommand();
                commandName.Connection = connection;
                string query = "select * from Supply_Information where Category='" + item + "'";
                commandName.CommandText = query;

                OleDbDataReader readerName = commandName.ExecuteReader();
                while (readerName.Read())
                {
                    nameRTextBox.Text = readerName["Supply"].ToString();
                    linkLabel1.Text = readerName["Link"].ToString();
                }

                connection.Close();

                link = linkLabel1.Text;
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "Supply";
                string button = "Category";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }

        // Bring user back to main menu
        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (userLabel.Text == "T")
            {
                MainMenuForm2 mainMenu2 = new MainMenuForm2();
                mainMenu2.ShowDialog();
            }
            else
            {
                MainMenuForm mainMenu = new MainMenuForm();
                mainMenu.ShowDialog();
            }

            this.Close();
        }

        // Exit program
        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // ------------------------------------------------------------------------------------------------------------------------------------------------V
        // Add tab of supply form
        private void addButton_Click(object sender, EventArgs e)
        {
            if (typeTextBox.Text != "" && brandTextBox.Text != "" && modelTextBox.Text != "" && catTextBox.Text != "" && nameTextBox.Text != "" && linkTextBox.Text != "")
            {
                try
                {
                    string type = typeTextBox.Text;
                    string brand = brandTextBox.Text;
                    string model = modelTextBox.Text;
                    string cat = catTextBox.Text;
                    string name = nameTextBox.Text;
                    string link = linkTextBox.Text;

                    // Uppercase all items
                    type = type.ToUpper();
                    brand = brand.ToUpper();
                    model = model.ToUpper();

                    bool linkCheck = false;
                    if (link.StartsWith("www.") || link.StartsWith("https://"))
                        linkCheck = true;

                    if (linkCheck)
                    {
                        connection.Open();

                        OleDbCommand commandAdd = new OleDbCommand();
                        commandAdd.Connection = connection;
                        string query = "insert into Supply_Information (Type,Brand,Model,Category,Supply,Link) values('" + type + "','" + brand + "','" + model + "','" + cat + "','" + name + "','" + link + "')";
                        commandAdd.CommandText = query;
                        commandAdd.ExecuteNonQuery();

                        connection.Close();

                        MessageBox.Show("Information was successfully added.");

                        // Clear text boxes after successful add
                        typeTextBox.Text = "";
                        brandTextBox.Text = "";
                        modelTextBox.Text = "";
                        catTextBox.Text = "";
                        nameTextBox.Text = "";
                        linkTextBox.Text = "";
                    }
                    else
                        MessageBox.Show("Please include https:// or www. in your link.");
                }
                catch (Exception ex)
                {
                    // Send bug report
                    string page = "Supply";
                    string button = "Add";
                    string exception = ex.ToString();
                    BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                    bugSplat.ShowDialog();

                    this.Close();
                }
            }
            else
                MessageBox.Show("Please fill out all fields.");   
        }

        // Open link in a new tab
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(link);
            }
            catch (Exception ex)
            {
                string page = "Supply";
                string button = "Link";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
        }
    }
}
