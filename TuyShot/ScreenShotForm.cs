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
    public partial class ScreenShotForm : Form
    {
        Bitmap _image;
        public ScreenShotForm(Bitmap image)
        {
            InitializeComponent();
            _image = image;
        }

        private void ScreenShotForm_Load(object sender, EventArgs e)
        {
            pictureBoxScreen.Image = _image;
        }
    }
}
