﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webber_Inventory_Search_2017_2018
{
    public partial class TechAidePasswordForm : Form
    {
        public TechAidePasswordForm()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            // Check for password match
            if (passwordTextBox.Text == "webtech")
            {
                this.Hide();

                TechnologyAssistantForm techAssist = new TechnologyAssistantForm();
                techAssist.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Try again.");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open main menu form
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.ShowDialog();

            this.Close();
        }
    }
}
