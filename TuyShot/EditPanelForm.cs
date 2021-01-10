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
        Bitmap _screenShoot;
        int _penWidth = 3;
        Color _color = Color.Red;
        ObjectTypes _objectTypes = ObjectTypes.Rectangle;
        PenOptions _penOptions = new PenOptions();
        Rectangle _rectangle = new Rectangle();
        Point _lastPoint;
        public EditPanelForm(Bitmap screenShoot)
        {
            InitializeComponent();
            _screenShoot = screenShoot;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

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
            pictureBoxEdit.Image = _screenShoot;
        }

        private void EditPanelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
            _penOptions.IsDrawingActive = true;
            _penOptions.StartCoordinat = e.Location;
        }

        private void pictureBoxEdit_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _penOptions.IsDrawingActive == true && _objectTypes == ObjectTypes.Rectangle)
            {

                CreateRectangele(e.Location);
                pictureBoxEdit.Image = _screenShoot;
            }
            if (e.Button == MouseButtons.Left && _penOptions.IsDrawingActive == true && _objectTypes == ObjectTypes.Line)
                _lastPoint = Location;

        }


        private void pictureBoxEdit_MouseUp(object sender, MouseEventArgs e)
        {
            _penOptions.IsDrawingActive = false;
        }

        private void pictureBoxEdit_Paint(object sender, PaintEventArgs e)
        {
            if (_penOptions.IsDrawingActive == true && _rectangle != null && _rectangle.Width > 0 && _rectangle.Height > 0)
            {
                //e.Graphics.FillRectangle(_selectionBrush, _rectangle);
                Pen pen = new Pen(_color, _penWidth);
                e.Graphics.DrawRectangle(pen, _rectangle);
                //_pictureBoxOption.IsSelectedScreenActive = false;
            }
            if (_objectTypes == ObjectTypes.Line)
            {
                Pen pen = new Pen(_color, _penWidth);
                e.Graphics.DrawLine(pen, _penOptions.StartCoordinat, _lastPoint);
            }
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            _objectTypes = ObjectTypes.Line;
        }
    }
}
