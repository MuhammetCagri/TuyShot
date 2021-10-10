using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
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
            VersionControl();
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            TakeScreenShot();
        }
        void TakeScreenShot()
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

        void VersionControl()
        {
            if (!File.Exists("appUpdate.json"))
                return;
            JObject o1 = JObject.Parse(File.ReadAllText("appUpdate.json"));
            var jsontext = JsonConvert.SerializeObject(o1);
            var versionValues = JsonConvert.DeserializeObject<VersionProperties>(jsontext);
            if (versionValues.Version != Properties.Settings.Default.Version)
            {
                DialogResult dialogResult = MessageBox.Show("Yeni Güncelleme Mevcut Güncellensin mi?", "Güncelle", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("UpdateService//TuyShotUpdateService.exe");
                    Application.Exit();
                }
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merhabalar öncelikle TuyShot kullandığın için teşekkür ederim.\nHiç bir veri depolanmamaktadır.\nRahatça kullanabilirsin.\n Email:muhammetcagri.aydin@yaani.com");
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Teşekkür Ederim:)\nBağış için 1-2 ₺ bile olur ama olmazsa bir Fatiha bile okusan yeter :)\nAkbank IBAN: TR89 0004 6008 6688 8000 1440 00\nGaranti IBAN:TR72 0006 2000 4220 0006 6044 70 ");
        }

        void FirstUsageMessage()
        {
            MessageBox.Show("Küçült butonuna tıklandığında simge olarak açık kalmaktadır.\n CTRL+ \" ile ekran fotoğrafı alabilirsiniz.");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FirstUsageMessage();
        }


        private void ControlPanelForm_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyValue == 192)
            {
                TakeScreenShot();
            }
        }

    }

    public class VersionProperties
    {
        public string Version { get; set; }
        public string VersionNote { get; set; }
    }
}
