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
    public partial class MainMenuForm2 : Form
    {
        public MainMenuForm2()
        {
            InitializeComponent();

            // Start the time
            mainMenuTimer.Start();
        }

        // Signify that main menu form is in teacher mode
        string user = "T";

        private void ticketButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Open ticket form and close main menu
            TicketForm ticketForm = new TicketForm(user);
            ticketForm.ShowDialog();

            this.Close();
        }

        private void suppliesButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Opens supplies form and close main menu
            SuppliesInformationForm supplyForm = new SuppliesInformationForm(user);
            supplyForm.ShowDialog();

            this.Close();
        }

        private void troubleshootingButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Opentroubleshooting form and close main menu
            TroubleshootForm troubleshoot = new TroubleshootForm();
            troubleshoot.ShowDialog();

            this.Close();
        }

        private void tutorialsButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Opens tutorials form and close main menu
            TutorialForm tutorialForm = new TutorialForm(user);
            tutorialForm.ShowDialog();

            this.Close();
        }

        private void mainMenuTimer_Tick(object sender, EventArgs e)
        {
            // Get current time
            DateTime currentTime = DateTime.Now;
            timeLabel.Text = currentTime.ToString();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            // Close the program
            this.Close();
        }
    }
}
