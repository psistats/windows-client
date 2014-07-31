using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Psistats.App
{
    public partial class DoerBox : Form
    {
        public DoerBox()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
