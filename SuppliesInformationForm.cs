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
    public partial class SuppliesInformationForm : Form
    {
        public SuppliesInformationForm()
        {
            InitializeComponent();
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check for which type is selected
            if (typeComboBox.Text == "Projector")
            {
                brandComboBox.Items.Clear();

                brandComboBox.Items.Add("NEC");
                brandComboBox.Items.Add("Epson");
            }
            else if (typeComboBox.Text == "Printer")
            {
                brandComboBox.Items.Clear();

                brandComboBox.Items.Add("HP");
                brandComboBox.Items.Add("Dell");
                brandComboBox.Items.Add("Brother");
            }
        }

        private void brandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check for which model is selected
            if (brandComboBox.Text == "NEC")
            {

            }
            else if (brandComboBox.Text == "Epson")
            {

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
    }
}
