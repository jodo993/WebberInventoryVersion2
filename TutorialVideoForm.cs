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
    public partial class TutorialVideoForm : Form
    {
        public TutorialVideoForm(string link)
        {
            InitializeComponent();
            linkLabel.Text = link;
        }

        private void TutorialVideoForm_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(linkLabel.Text);
        }

        private void TutorialVideoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            webBrowser1.Dispose();
        }
    }
}
