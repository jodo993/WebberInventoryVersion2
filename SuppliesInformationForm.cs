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

namespace Webber_Inventory_Search_2017_2018
{
    public partial class SuppliesInformationForm : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public SuppliesInformationForm()
        {
            InitializeComponent();

            // Connect to database                                                       
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = typeComboBox.Text;
            // Check for which brand is selected
            try
            {
                connection.Open();

                OleDbCommand commandBrand = new OleDbCommand();
                commandBrand.Connection = connection;
                string query = "select * from Supply_Information where Type='" + item + "'";
                commandBrand.CommandText = query;

                OleDbDataReader readerBrand = commandBrand.ExecuteReader();
                while (readerBrand.Read())
                {
                    brandComboBox.Items.Add(readerBrand["Brand"].ToString());
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
            string item = brandComboBox.Text;
            // Check for which brand is selected
            try
            {
                connection.Open();

                OleDbCommand commandModel = new OleDbCommand();
                commandModel.Connection = connection;
                string query = "select * from Supply_Information where Brand='" + item + "'";
                commandModel.CommandText = query;

                OleDbDataReader readerModel = commandModel.ExecuteReader();
                while (readerModel.Read())
                {
                    modelComboBox.Items.Add(readerModel["Model"].ToString());
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please go back and try again." + ex);
            }
        }

        private void modelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.ShowDialog();

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
                string name = "";
                string link = "";

                // Checking and giving a value to the variables for data table
                if (typeTextBox.Text == "")
                    type = "";
                else
                    type = typeTextBox.Text;

                if (typeTextBox.Text == "")
                    brand = "";
                else
                    brand = brandTextBox.Text;

                if (typeTextBox.Text == "")
                    model = "";
                else
                    model = modelTextBox.Text;

                if (typeTextBox.Text == "")
                    name = "";
                else
                    name = nameTextBox.Text;

                if (typeTextBox.Text == "")
                    link = "";
                else
                    link = linkTextBox.Text;

                connection.Open();

                OleDbCommand commandAdd = new OleDbCommand();
                commandAdd.Connection = connection;
                string query = "insert into Supply_Information (Type,Brand,Model,Supply,Link) values('" + type + "','" + brand + "','" + model + "','" + name + "','" + link + "')";
                commandAdd.CommandText = query;
                commandAdd.ExecuteNonQuery();

                MessageBox.Show("Information was successfully added.");

                connection.Close();

                // Clear text boxes after successful add
                typeTextBox.Text = "";
                brandTextBox.Text = "";
                modelTextBox.Text = "";
                nameTextBox.Text = "";
                linkTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uh Oh. Something went wrong, please try again." + ex);
            }
        }

        private void mainButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.ShowDialog();

            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

                OleDbDataReader readerType = commandType.ExecuteReader();
                while (readerType.Read())
                {
                    typeComboBox.Items.Add(readerType["Type"].ToString());
                }

                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please go back and try again.dfadfas");
            }
        }
    }
}
