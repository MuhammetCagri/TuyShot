using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuyShot
{
    public partial class ControlPanelForm : Form
    {
        public ControlPanelForm()
        {
            InitializeComponent();
        }

        private void ScreenShotForm_Load(object sender, EventArgs e)
        {

        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectScreenForm frm = new SelectScreenForm();
            frm.Show();
        }
    }
}
