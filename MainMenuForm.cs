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

            // Show current time and start the timer
            mainMenuTimer.Start();
        }

        // Signify that the main menu page is in admin mode
        string user = "A";

        private void chromebookButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open chromebook form and close main menu
            ChromebookForm newChromebookForm = new ChromebookForm();
            newChromebookForm.ShowDialog();

            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open add form and close main menu
            AddInventoryForm newAddInventoryForm = new AddInventoryForm();
            newAddInventoryForm.ShowDialog();

            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open search form and close main menu
            SearchInventoryForm newSearchInventoryForm = new SearchInventoryForm();
            newSearchInventoryForm.ShowDialog();

            this.Close();
        }

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

            // Open troubleshooting form and close main menu
            TroubleshootForm troubleshoot = new TroubleshootForm(user);
            troubleshoot.ShowDialog();

            this.Close();
        }

        private void tutorialsButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Opens tutorials form
            TutorialForm tutorialForm = new TutorialForm(user);
            tutorialForm.ShowDialog();

            this.Close();
        }

        private void techAideButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Open the technology assistance form and close the main menu
            TechnologyAssistantForm techAssist = new TechnologyAssistantForm();
            techAssist.ShowDialog();

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
            // Back to login screen
            this.Hide();

            Form1 formOne = new Form1();
            formOne.ShowDialog();

            this.Close();
        }

        private void masterKeyButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Opens master key form
            MasterKeyForm masterKeyForm = new MasterKeyForm(user);
            masterKeyForm.ShowDialog();

            this.Close();
        }

        private void chromebookButton_MouseHover(object sender, EventArgs e)
        {
            chromebookLabel.ForeColor = Color.Red;
        }

        private void chromebookButton_MouseLeave(object sender, EventArgs e)
        {
            chromebookLabel.ForeColor = Color.Black;
        }

        private void addButton_MouseHover(object sender, EventArgs e)
        {
            addLabel.ForeColor = Color.PaleVioletRed;
        }

        private void addButton_MouseLeave(object sender, EventArgs e)
        {
            addLabel.ForeColor = Color.Black;
        }

        private void searchButton_MouseHover(object sender, EventArgs e)
        {
            searchLabel.ForeColor = Color.ForestGreen;
        }

        private void searchButton_MouseLeave(object sender, EventArgs e)
        {
            searchLabel.ForeColor = Color.Black;
        }

        private void suppliesButton_MouseHover(object sender, EventArgs e)
        {
            supplyLabel.ForeColor = Color.MediumPurple;
        }

        private void suppliesButton_MouseLeave(object sender, EventArgs e)
        {
            supplyLabel.ForeColor = Color.Black;
        }

        private void masterKeyButton_MouseHover(object sender, EventArgs e)
        {
            masterLabel.ForeColor = Color.DimGray;
        }

        private void masterKeyButton_MouseLeave(object sender, EventArgs e)
        {
            masterLabel.ForeColor = Color.Black;
        }

        private void ticketButton_MouseHover(object sender, EventArgs e)
        {
            ticketLabel.ForeColor = Color.FromArgb(128,64,0);
        }

        private void ticketButton_MouseLeave(object sender, EventArgs e)
        {
            ticketLabel.ForeColor = Color.Black;
        }

        private void troubleshootingButton_MouseHover(object sender, EventArgs e)
        {
            troubleshootLabel.ForeColor = Color.Chocolate;
        }

        private void troubleshootingButton_MouseLeave(object sender, EventArgs e)
        {
            troubleshootLabel.ForeColor = Color.Black;
        }

        private void tutorialsButton_MouseHover(object sender, EventArgs e)
        {
            tutorialLabel.ForeColor = Color.DarkGoldenrod;
        }

        private void tutorialsButton_MouseLeave(object sender, EventArgs e)
        {
            tutorialLabel.ForeColor = Color.Black;
        }

        private void techAideButton_MouseHover(object sender, EventArgs e)
        {
            techLabel.ForeColor = Color.SteelBlue;
        }

        private void techAideButton_MouseLeave(object sender, EventArgs e)
        {
            techLabel.ForeColor = Color.Black;
        }

        private void quitButton_MouseHover(object sender, EventArgs e)
        {
            exitLabel.ForeColor = Color.DarkGray;
        }

        private void quitButton_MouseLeave(object sender, EventArgs e)
        {
            exitLabel.ForeColor = Color.Black;
        }
    }
}
