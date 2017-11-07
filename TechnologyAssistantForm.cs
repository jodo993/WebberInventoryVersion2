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
    public partial class TechnologyAssistantForm : Form
    {
        public TechnologyAssistantForm()
        {
            InitializeComponent();
        }

        // Categories and their issues
        public void StMath()
        {
            issueComboBox.Items.Clear();

            issueComboBox.Items.Add("Add Students");
            issueComboBox.Items.Add("Transfer Students");
            issueComboBox.Items.Add("Retrain Student Password");
            issueComboBox.Items.Add("ST Math not at the right school");
        }

        public void Lexia()
        {
            issueComboBox.Items.Clear();

            issueComboBox.Items.Add("Manage Class");
            issueComboBox.Items.Add("Print Roster/Login Card");
        }

        public void AR()
        {
            issueComboBox.Items.Clear();

            issueComboBox.Items.Add("Can't Login");
            issueComboBox.Items.Add("Create New Account");
            issueComboBox.Items.Add("Clear Locked User");
        }

        public void Notes()
        {
            issueComboBox.Items.Clear();

            issueComboBox.Items.Add("District Limitations");
            issueComboBox.Items.Add("Haiku or PowerSchool Learning");
            issueComboBox.Items.Add("Account to Have");
        }

        public void Chromebook()
        {
            issueComboBox.Items.Clear();

            issueComboBox.Items.Add("Reset Password for Students");
        }

        private void TechnologyAssistantForm_Load(object sender, EventArgs e)
        {
            // Add these selection upon load
            programComboBox.Items.Add("ST Math");
            programComboBox.Items.Add("Lexia");
            programComboBox.Items.Add("Renaissance");
            programComboBox.Items.Add("Notes");
            programComboBox.Items.Add("Chromebook");
        }

        private void programComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check which category is selected
            if (programComboBox.SelectedIndex == 0)
            {
                StMath();
            }
            else if (programComboBox.SelectedIndex == 1)
            {
                Lexia();
            }
            else if (programComboBox.SelectedIndex == 2)
            {
                AR();
            }
            else if (programComboBox.SelectedIndex == 3)
            {
                Notes();
            }
            else if (programComboBox.SelectedIndex == 4)
            {
                Chromebook();
            }
            else
            {
                MessageBox.Show("Try again.");
            }
        }

        private void issueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check to see which issue is clicked then show solution
            string instruction = "";
            // ST Math
            if (programComboBox.SelectedIndex == 0)
            {
                if (issueComboBox.SelectedIndex == 0)
                {
                    instruction = "1) Click Green Person w/ Plus sign at lower right. @2) Enter first & last name and select grade and teacher. @3) Sign on to teacher's account to link. @4) Use open enrollment to link students faster. @5) One time only, do not close until done.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 1)
                {
                    instruction = "1) Log in to teacher's account or yours. @2) Find teacher and class. @3) Find student in roster. @4) Click transfer. Select correct transfer path. Click transfer."; ;
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 2)
                {
                    instruction = "1) Double click on bottom right (About an inch from the right). @2) Popup will prompt for login. Enter teacher's login. @3) Find and click student's name on the roster list. Click retrain password. Click ok.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);

                }
                else if (issueComboBox.SelectedIndex == 3)
                {
                    instruction = "1) Make sure URL is https://web.stmath.com/entrance/go/web75g";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
            }
            // Lexia
            else if (programComboBox.SelectedIndex == 1)
            {
                if (issueComboBox.SelectedIndex == 0)
                {
                    instruction = "1) Login and click on tree graph like icon. @2) Click edit class. @3) Modify students or staff as needed then save.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 1)
                {
                    instruction = "1) Login and click tree graph icon. @2) Select class. @3) Click print roster or print login cards.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
            }
            // Renaissance
            else if (programComboBox.SelectedIndex == 2)
            {
                if (issueComboBox.SelectedIndex == 0)
                {
                    instruction = "1) Make sure username and password are correct and students are in students, teachers in teacher. @2) Make sure WSD-78JW is seen as Renaissance Place ID on the middle right. @3) URL is https://hosted101.renlearn.com/273741/default.aspx";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 1)
                {
                    instruction = "1) Click Users. @2) Click add personnel or add students. @3) Fill out information and click save and add.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 2)
                {
                    instruction = "1) Click Users. @2) Click clear lock (personnel or students).";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
            }
            // Notes
            else if (programComboBox.SelectedIndex == 3)
            {
                if (issueComboBox.SelectedIndex == 0)
                {
                    instruction = "1) Installation of projector and lamp changes are done by district tech. @2) RICOH printer in lounge is handled by ricoh guy.";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
                else if (issueComboBox.SelectedIndex == 1)
                {
                    instructionLabel.Text = "Haiku will have instructions on many other things such as how to's, procedures, trainings, surplus, etc.";
                }
                else if (issueComboBox.SelectedIndex == 2)
                {
                    instruction = "1) ST Math - Contact Huy Pham @2) Lexia - Principal can create account @3) Renaissance/AR - VeNae or Principal @4) Haiku - Lauren/Ed Tech Coach @5) Aeries - Sue";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
            }
            // Chromebook
            else if (programComboBox.SelectedIndex == 4)
            {
                if (issueComboBox.SelectedIndex == 0)
                {
                    instruction = "1) Go to the admin console in Google @2) Click users or type in lunch number/name in search @3) Verify student is correct, then click the lock icon on the top right @4) Change password then click reset";
                    instructionLabel.Text = instruction.Replace("@", "" + System.Environment.NewLine);
                }
            }
            else
                instructionLabel.Text = "Pick a valid selection.";
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open main menu form
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.ShowDialog();

            this.Close();
        }

        // Close program
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
