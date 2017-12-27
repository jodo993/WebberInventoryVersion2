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
    public partial class BugErrorDisplayForm : Form
    {
        public BugErrorDisplayForm(string error)
        {
            InitializeComponent();
            // Show error
            bugErrorLabel.Text = error;
        }

        // Close the form
        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
