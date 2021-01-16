using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            notifyIcon1.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectScreenForm frm = new SelectScreenForm();
            frm.Show();
            NotifyIcon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NotifyIcon();
        }
        void notify_Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }
        void NotifyIcon()
        {
            this.Hide();
            notifyIcon1.Visible = true;
            notifyIcon1.Text = "TüyShot Uygulaması";
            notifyIcon1.BalloonTipTitle = "TüyShot uygulaması arka planda çalışıyor";
            notifyIcon1.BalloonTipText = "Program sağ alt köşede konumlandı.Çift tıklayarak ulaşabilirsin";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(2000);
            // notifyIcon için event ataması yaptık
            notifyIcon1.MouseDoubleClick += new MouseEventHandler(notify_Icon_MouseDoubleClick);
        }
    }
}
