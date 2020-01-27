using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JugglingApp
{
    public partial class SiteSwapForm : Form
    {
        public int i;
        public int j;

        public SiteSwapForm()
        {
            InitializeComponent();
        }

        private void done_Click(object sender, EventArgs e)
        {
            try
            {
                i = int.Parse(textBox1.Text);
                j = int.Parse(textBox2.Text);
                Hide();

            }
            catch (FormatException)
            {
                string msg = "One of the numbers is incorrect!";
                DialogResult result;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                result = MessageBox.Show(msg,"Error",buttons);
            }
        }
    }
}
