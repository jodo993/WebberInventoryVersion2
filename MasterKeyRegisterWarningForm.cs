using System;
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
    public partial class MasterKeyRegisterWarningForm : Form
    {
        // Use by this form only, global
        private OleDbConnection connection = new OleDbConnection();

        public MasterKeyRegisterWarningForm()
        {
            InitializeComponent();
            // Connection to database
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\josep\Desktop\WebberMainDatabase.accdb;Persist Security Info=False;";
        }

        // Check to see if applicant is already registered
        private bool CheckApplicantRecord(string full)
        {
            //bool newApplicant = true;

            // Applicant full name
            string recordFullName = "";

            // Hold first and last name
            string[] firstNameArray = new string[2500];
            string[] lastNameArray = new string[2500];
            int i = 0;

            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Master_Key_Login";

                // Get both names and add them together, return false if same
                OleDbDataReader nameReader = command.ExecuteReader();
                while (nameReader.Read())
                {
                    firstNameArray[i] = nameReader["FirstName"].ToString();
                    lastNameArray[i] = nameReader["LastName"].ToString();
                    recordFullName = firstNameArray[i] + lastNameArray[i];
                    if (recordFullName == full)
                    {
                        connection.Close();
                        return false;
                    }
                }
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                // Send bug report
                string page = "Master Key Register";
                string button = "CheckApplicantRecord";
                string exception = ex.ToString();
                BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                bugSplat.ShowDialog();

                this.Close();
            }
            connection.Close();
            return true;
        }

        // Create a key and check to see if it exist or not
        private int CreateKey()
        {
            int privateKey;
            bool newKey = false;

            // Create random private key number
            Random randomKey = new Random();
            privateKey = randomKey.Next(1000,9999);

            // Convert key to string
            string privateKeyString = privateKey.ToString();

            while (newKey == false)
            {
                // Array to hold all private key to check if existing key is there
                string[] allKeys = new string[2500];
                int i = 0;

                // Read all data to check for existing key
                try
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "select * from Master_Key_Login";

                    OleDbDataReader keyReader = command.ExecuteReader();
                    while (keyReader.Read())
                    {
                        allKeys[i] = keyReader["PrivateKey"].ToString();
                        if (allKeys[i] == privateKeyString)
                        {
                            connection.Close();
                            return 100;
                        }  
                    }
                    connection.Close();
                    return int.Parse(privateKeyString);
                }
                catch (Exception ex)
                {
                    // Send bug report
                    string page = "Master Key Register";
                    string button = "CreateKey";
                    string exception = ex.ToString();
                    BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                    bugSplat.ShowDialog();

                    this.Close();
                }
            }
            connection.Close();
            return int.Parse(privateKeyString);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string firstName;
            string lastName;
            string gradeLevel;

            if (firstNameTextBox.Text != "" || lastNameTextBox.Text != "" || gradeLevelComboBox.Text != "")
                if (firstNameTextBox.Text.All(Char.IsLetter) && lastNameTextBox.Text.All(Char.IsLetter))
                    if (gradeLevelComboBox.Text == "Pre-School" || gradeLevelComboBox.Text == "Kindergarten" || gradeLevelComboBox.Text == "First" ||
                        gradeLevelComboBox.Text == "Second" || gradeLevelComboBox.Text == "Third" || gradeLevelComboBox.Text == "Fourth" ||
                        gradeLevelComboBox.Text == "Fifth" || gradeLevelComboBox.Text == "Sixth" || gradeLevelComboBox.Text == "Administration")
                    {
                        // Pass user info into variables
                        firstName = firstNameTextBox.Text.ToUpper();
                        lastName = lastNameTextBox.Text.ToUpper();
                        gradeLevel = gradeLevelComboBox.Text.ToUpper();

                        string fullName = firstName + lastName;

                        // Check for duplicate names
                        bool newAccount = CheckApplicantRecord(fullName);
                        if (newAccount == false)
                        {
                            MessageBox.Show("This name is already registered. Please check with the admininstrator for help or enter a new name.");
                            return;
                        }

                        // Create and check private key
                        int privateKeyNum = CreateKey();
                        while (privateKeyNum == 100)
                            privateKeyNum = CreateKey();
                        
                        // Add new record in database
                        try
                        {
                            connection.Open();

                            OleDbCommand command = new OleDbCommand();
                            command.Connection = connection;
                            command.CommandText = "insert into Master_Key_Login (FirstName,LastName,Grade,PrivateKey) values ('" + firstName + "','" + lastName + "','" + gradeLevel + "'," + privateKeyNum + ")";
                            command.ExecuteNonQuery();

                            connection.Close();

                            MessageBox.Show("Registration Complete! Click OK to see your key.");
                            MessageBox.Show("Private Key: " + privateKeyNum);
                        }
                        catch (Exception ex)
                        {
                            // Send bug report
                            string page = "Master Key Register";
                            string button = "Create";
                            string exception = ex.ToString();
                            BugSplatForm bugSplat = new BugSplatForm(page, button, exception);
                            bugSplat.ShowDialog();

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a given grade level.");
                    }
                else
                {
                    MessageBox.Show("Entries must contain only letters.");
                }
            else
            {
                MessageBox.Show("Please fill in all the fields.");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
