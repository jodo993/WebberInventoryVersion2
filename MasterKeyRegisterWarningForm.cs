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
    public partial class MasterKeyRegisterWarningForm : Form
    {
        public MasterKeyRegisterWarningForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string firstName;
            string lastName;
            string gradeLevel;

            if (firstNameTextBox.Text == "" || lastNameTextBox.Text == "" || gradeLevelComboBox.Text == "")
            {
                MessageBox.Show("You must fill out all three fields.");
            }
            else
            {
                if (firstNameTextBox.Text.All(Char.IsLetter) || lastNameTextBox.Text.All(Char.IsLetter) || gradeLevelComboBox.Text.All(Char.IsLetter))
                {
                    MessageBox.Show("hi");
                }
                else
                {
                    MessageBox.Show("Entries must contain only letters.");
                }
            }
        }
    }
}
