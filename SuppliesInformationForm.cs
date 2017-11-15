﻿using System;
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
        string link = "";

        public SuppliesInformationForm(string user)
        {
            InitializeComponent();
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

                string[] type = new string[1000];
                int i = 0;

                OleDbDataReader readerType = commandType.ExecuteReader();
                while (readerType.Read())
                {
                    type[i] = readerType["Type"].ToString();
                    i++;
                }

                // Checks for copy of same type and only display one
                // Brute force algorithm, will slow as array gets bigger
                int arrayLength = i;
                for (int a = 0; a < arrayLength; a++)
                {
                    typeComboBox.Items.Add(type[a]);
                    for (int b = a + 1; b < arrayLength; b++)
                    {
                        if (type[b] == type[a])
                            typeComboBox.Items.Remove(type[a]);
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please go back and try again." + ex);
            }
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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

                string[] brand = new string[1000];
                int i = 0;

                OleDbDataReader readerBrand = commandBrand.ExecuteReader();
                while (readerBrand.Read())
                {
                    brand[i] = readerBrand["Brand"].ToString();
                    i++;
                }

                int arrayLength = i;
                for (int a = 0; a < arrayLength; a++)
                {
                    brandComboBox.Items.Add(brand[a]);
                    for (int b = a + 1; b < arrayLength; b++)
                    {
                        if (brand[b] == brand[a])
                            brandComboBox.Items.Remove(brand[a]);
                    }
                }
                
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please go back and try again." + ex);
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

                string[] model = new string[1000];
                int i = 0;

                OleDbDataReader readermodel = commandModel.ExecuteReader();
                while (readermodel.Read())
                {
                    model[i] = readermodel["Model"].ToString();
                    i++;
                }

                // Checks for copy of same type and only display one
                // Brute force algorithm, will slow as array gets bigger
                int arrayLength = i;
                for (int a = 0; a < arrayLength; a++)
                {
                    modelComboBox.Items.Add(model[a]);
                    for (int b = a + 1; b < arrayLength; b++)
                    {
                        if (model[b] == model[a])
                            modelComboBox.Items.Remove(model[a]);
                    }
                }

                //OleDbDataReader readerModel = commandModel.ExecuteReader();
                //while (readerModel.Read())
                //{
                //    modelComboBox.Items.Add(readerModel["Model"].ToString());
                //}

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please go back and try again." + ex);
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
                MessageBox.Show("Please go back and try again." + ex);
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
                MessageBox.Show("Please go back and try again." + ex);
            }
        }

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

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // ------------------------------------------------------------------------------------------------------------------------------------------------V
        // Add tab of supply form
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string type = "";
                string brand = "";
                string model = "";
                string cat = "";
                string name = "";
                string link = "";

                // Checking and giving a value to the variables for data table
                if (typeTextBox.Text == "")
                    type = "";
                else
                    type = typeTextBox.Text;

                if (brandTextBox.Text == "")
                    brand = "";
                else
                    brand = brandTextBox.Text;

                if (modelTextBox.Text == "")
                    model = "";
                else
                    model = modelTextBox.Text;

                if (catTextBox.Text == "")
                    cat = "";
                else
                    cat = catTextBox.Text;

                if (nameTextBox.Text == "")
                    name = "";
                else
                    name = nameTextBox.Text;

                if (linkTextBox.Text == "")
                    link = "";
                else
                    link = linkTextBox.Text;

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

                    MessageBox.Show("Information was successfully added.");

                    connection.Close();

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
                //MessageBox.Show("Uh Oh. Something went wrong, please try again." + ex);
                MessageBox.Show("Uh Oh. Something went wrong, please try again.");
            }
        }

        private void mainButton_Click(object sender, EventArgs e)
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
                MessageBox.Show("hi" + ex);
            }
            
        }
    }
}
