using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuyShot.Enums;
using TuyShot.Options;

namespace TuyShot
{
    public partial class EditPanelForm : Form
    {
        Image _screenShoot;
        int _penWidth = 3;
        Color _color = Color.Red;
        ObjectTypes _objectTypes = ObjectTypes.Rectangle;
        PenOptions _penOptions = new PenOptions();
        Rectangle _rectangle = new Rectangle();
        Point _lastPoint;
        Graphics _graphics;
        public EditPanelForm(Bitmap screenShoot)
        {
            InitializeComponent();
            _screenShoot = screenShoot;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = true;
            save.CreatePrompt = true;
            save.Filter = " png | *.png | jpeg | *.jpeg | bmp | *.bmp | Tüm Dosyalar(*.*) | *.* ";
            save.FileName = $"Resim " +DateTime.Now.ToString("D");

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap bm =new Bitmap(pictureBoxEdit.Size.Width,pictureBoxEdit.Size.Height))
                {
                    pictureBoxEdit.DrawToBitmap(bm, pictureBoxEdit.ClientRectangle);
                    bm.Save(save.FileName);
                }            
            }
            
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            _objectTypes = ObjectTypes.Rectangle;

        }

        private void inceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void EditPanelForm_Load(object sender, EventArgs e)
        {
            //this.TransparencyKey = Color.Turquoise;
            //this.BackColor = Color.Turquoise;
            if (_screenShoot.Size.Width >= Screen.PrimaryScreen.Bounds.Size.Width || _screenShoot.Size.Width >= Screen.PrimaryScreen.Bounds.Size.Height)
                pictureBoxEdit.SizeMode = PictureBoxSizeMode.AutoSize;
            else
            {
                pictureBoxEdit.Size = _screenShoot.Size;

                this.Size = new Size(_screenShoot.Width + 130, _screenShoot.Height + 130);
                float x = (Convert.ToInt32(this.Width) - Convert.ToInt32(pictureBoxEdit.Width)) / 2;
                float y = (Convert.ToInt32(this.Height) - Convert.ToInt32(pictureBoxEdit.Height)) / 2;
                pictureBoxEdit.Location = new Point(x: Convert.ToInt32(x), y: Convert.ToInt32(y));

            }
            pictureBoxEdit.Image = _screenShoot;
            pictureBoxEdit.BackColor = Color.White;
            _graphics = Graphics.FromImage(_screenShoot);
        }

        private void EditPanelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            _graphics.Dispose();
            _screenShoot.Dispose();
        }
        private Rectangle CreateRectangele(Point point)
        {
            _rectangle.Location = new Point
               (
                   Math.Min(_penOptions.StartCoordinat.X, point.X),
                   Math.Min(_penOptions.StartCoordinat.Y, point.Y)
               );
            _rectangle.Size = new Size
            (
                Math.Abs(_penOptions.StartCoordinat.X - point.X),
                Math.Abs(_penOptions.StartCoordinat.Y - point.Y)
            );
            return _rectangle;
        }
        private void pictureBoxEdit_MouseDown(object sender, MouseEventArgs e)
        {
            _penOptions.StartCoordinat = e.Location;
            _penOptions.IsDrawingActive = true;
          
        }

        private void pictureBoxEdit_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _penOptions.IsDrawingActive == true && _objectTypes == ObjectTypes.Rectangle)
            {
                CreateRectangele(e.Location);
                pictureBoxEdit.Invalidate();
            }
        }
        private void pictureBoxEdit_MouseUp(object sender, MouseEventArgs e)
        {
            _penOptions.IsDrawingActive = false;
            Pen pen = new Pen(_color, _penWidth);
            if (_objectTypes == ObjectTypes.Rectangle)
                _graphics.DrawRectangle(pen, _rectangle);
            if (_objectTypes == ObjectTypes.Line)
                _graphics.DrawLine(pen, _penOptions.StartCoordinat, e.Location);
            pictureBoxEdit.Image = _screenShoot;
        }

        private void pictureBoxEdit_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Pen pen = new Pen(_color, _penWidth);
            if (_penOptions.IsDrawingActive == true && _rectangle != null && _rectangle.Width > 0 && _rectangle.Height > 0)
                g.DrawRectangle(pen, _rectangle);
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            _objectTypes = ObjectTypes.Line;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new SelectScreenForm();
            frm.Show();
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
