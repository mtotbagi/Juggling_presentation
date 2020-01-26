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
    public partial class SiteSwap : Form
    {
        public SiteSwap()
        {
            InitializeComponent();
        }

        private void done_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
