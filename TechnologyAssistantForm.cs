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
    public partial class TechnologyAssistantForm : Form
    {
        public TechnologyAssistantForm()
        {
            InitializeComponent();
        }

        private void TechnologyAssistantForm_Load(object sender, EventArgs e)
        {
            programComboBox.Items.Add("ST Math");
            programComboBox.Items.Add("Lexia");
            programComboBox.Items.Add("Renaissance");
            programComboBox.Items.Add("Notes");
        }

        private void programComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (programComboBox.SelectedIndex == 0)
            {
                issueComboBox.Items.Add("Add Students");
                issueComboBox.Items.Add("Transfer Students");
                issueComboBox.Items.Add("Retrain Student Password");
                issueComboBox.Items.Add("ST Math not at the right school");
            }
            else if (programComboBox.SelectedIndex == 1)
            {
                issueComboBox.Items.Add("hi");
            }
            else if (programComboBox.SelectedIndex == 2)
            {
                issueComboBox.Items.Add("Can't Login");
            }
            else if (programComboBox.SelectedIndex == 3)
            {
                issueComboBox.Items.Add("Finding Chromebook Serial Number");
                issueComboBox.Items.Add("Projector Lamp");
            }
            else
            {
                MessageBox.Show("Try again.");
            }
        }

        private void issueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (issueComboBox.SelectedItem.ToString() == "Add Students")
            {
                instructionLabel.Text = "Click Green Person w/ Plus sign at lower right. Enter first & last name and select grade and teacher. Sign on to teacher's account to link. Use open enrollment to link students faster. One time only, do not close until done.";
            }
            else if(issueComboBox.SelectedItem.ToString() == "Transfer Students")
            {
                instructionLabel.Text = "Log in to teacher's account or yours. Find teacher and class. Find student in roster. Click transfer. Select correct transfer path. Click transfer.";
            }
            else if (issueComboBox.SelectedItem.ToString() == "Retrain Student Password")
            {
                instructionLabel.Text = "Double click on bottom right (About an inch from the right). Popup will prompt for login. Enter teacher's login. Find and click student's name on the roster list. Click retrain password. Click ok.";
            }
            else if (issueComboBox.SelectedItem.ToString() == "ST Math not at the right school")
            {
                instructionLabel.Text = "Make sure URL is https://web.stmath.com/entrance/go/web75g";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }
            else if (issueComboBox.SelectedItem.ToString() == "Can't Login")
            {
                instructionLabel.Text = "Check to see if";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }
            else if (issueComboBox.SelectedItem.ToString() == "")
            {
                instructionLabel.Text = "";
            }

        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open main menu form
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.ShowDialog();

            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
