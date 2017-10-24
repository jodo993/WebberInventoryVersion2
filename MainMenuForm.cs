using System;
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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void chromebookButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open chromebook form
            ChromebookForm newChromebookForm = new ChromebookForm();
            newChromebookForm.ShowDialog();

            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open add form
            AddInventoryForm newAddInventoryForm = new AddInventoryForm();
            newAddInventoryForm.ShowDialog();

            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open search form
            SearchInventoryForm newSearchInventoryForm = new SearchInventoryForm();
            newSearchInventoryForm.ShowDialog();

            this.Close();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            // Close program
            this.Close();
        }

        private void techAideButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Opens the password form
            TechAidePasswordForm techAide = new TechAidePasswordForm();
            techAide.ShowDialog();

            this.Close();
        }

        private void troubleshootingButton_Click(object sender, EventArgs e)
        {
            //
        }

        private void suppliesButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            SuppliesInformationForm supplyForm = new SuppliesInformationForm();
            supplyForm.ShowDialog();

            this.Close();
        }
    }
}
