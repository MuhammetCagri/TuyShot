using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuyShot.Options;
using TuyShot.Options.PictureBoxOptions;

namespace TuyShot
{
    public partial class Form1 : Form
    {

        private PenOptions _penOptions = new PenOptions();
        private PictureBoxOption _pictureBoxOption = new PictureBoxOption();
        private PictureBox _pictureBox = new PictureBox();
        private DialogResult _dialogResult = new DialogResult();
        private Rectangle _rectangle = new Rectangle();
        private Brush _selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));
        Bitmap _image;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Image image = new Bitmap(@"C:\Users\muham\Desktop\deneme.png");

            this.BackgroundImage = image;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            _image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(_image);
            graphics.CopyFromScreen(0, 0, 0, 0, new Size(_image.Width, _image.Height));
            pictureBox1.Image = _image;
            graphics.Dispose();
            this.Show();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxOption.IsSelectedScreenActive = true;
            _pictureBoxOption.StartCoordinat = e.Location;


        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _pictureBoxOption.IsSelectedScreenActive == true)
            {
                _rectangle.Location = new Point
                (
                    Math.Min(_pictureBoxOption.StartCoordinat.X, e.Location.X),
                    Math.Min(_pictureBoxOption.StartCoordinat.Y, e.Location.Y)
                );
                _rectangle.Size = new Size
                (
                    Math.Abs(_pictureBoxOption.StartCoordinat.X - e.Location.X),
                    Math.Abs(_pictureBoxOption.StartCoordinat.Y - e.Location.Y)
                );
                _pictureBoxOption.Coordinat = _rectangle.Location;
                _pictureBoxOption.Size = _rectangle.Size;
                //_pictureBox.SetBounds(_pictureBoxOption.Coordinat.X, _pictureBoxOption.Coordinat.Y, _pictureBoxOption.Size.Width, _pictureBoxOption.Size.Height);
                //this.Controls.Add(_pictureBox);
                pictureBox1.Invalidate();

            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_pictureBoxOption.IsSelectedScreenActive == true && _rectangle != null && _rectangle.Width > 0 && _rectangle.Height > 0)
            {
                e.Graphics.FillRectangle(_selectionBrush, _rectangle);
                //_pictureBoxOption.IsSelectedScreenActive = false;
            }
        }

        private Bitmap ResizeImage()
        {
            if (_pictureBoxOption.Size.Width <= 0 || _pictureBoxOption.Size.Height <= 0)
                return _image;
            Bitmap matbmp = new Bitmap(_pictureBoxOption.Size.Width, _pictureBoxOption.Size.Height);
            //Graphics sınıfıylada koordinatları verien resmimizi X= 0 ,Y= 0 koordinat eksenınden baslatarak ciziyoruz.
            Graphics grafikmat = Graphics.FromImage(matbmp);
            grafikmat.DrawImage(_image, 0, 0, _rectangle, GraphicsUnit.Pixel);
            grafikmat.Dispose();
            return matbmp;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ScreenShotForm frm = new ScreenShotForm(ResizeImage());
            _pictureBoxOption.IsSelectedScreenActive = false;
            frm.Show();
        }
    }
}
