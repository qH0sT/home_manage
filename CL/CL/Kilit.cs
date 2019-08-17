using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace CL
{
    public partial class Kilit : Form
    {
        string uid;
        public Kilit(string UID)
        {
            InitializeComponent();
            Oku();
            if(path != "...") { pictureBox1.Image = Image.FromFile(path); }
            uid = UID;
            label1.Text = ((Form1)(Application.OpenForms["Form1"])).ism;
            
           
            
        }
        string path = "";
        void Oku()
        {

            string[] satirlar = File.ReadAllLines("conf.base");
            for (int c = 0; c < satirlar.Length; c++)
            {
               
                try
                {
                   path = satirlar[c].Substring(satirlar[c].IndexOf("<DKAGIDI>"), satirlar[c].IndexOf("</DKAGIDI>")).Replace("<DKAGIDI>", string.Empty);
                }
                catch (Exception) { }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("HH:mm");
            label3.Text = DateTime.Now.ToString("d/M/yyyy");
        }

        private void Kilit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                e.Cancel = true;
            }
            //((Form1)(Application.OpenForms["Form1"])).Soketimiz.Send(Encoding.UTF8.GetBytes("STATUS|" + uid + "|" + "0"));
            Process[] pc = Process.GetProcessesByName("explorer.exe");
            if(pc.Length == 0) { Process.Start(@"C:\Windows\explorer.exe"); }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Admin adm = new Admin(((Form1)(Application.OpenForms["Form1"])).Soketimiz, uid);
            adm.TopMost = true;
            adm.Show();
        }

        private void Kilit_Load(object sender, EventArgs e)
        {
            try { ((Form1)(Application.OpenForms["Form1"])).Soketimiz.Send(Encoding.UTF8.GetBytes("STATUS|" + uid + "|" + "1")); } catch (Exception) { }
            ProcessStartInfo pinf = new ProcessStartInfo();
            pinf.WindowStyle = ProcessWindowStyle.Hidden;
            pinf.FileName = "taskkill.exe";
            pinf.Arguments = "/IM explorer.exe /F";
            Process.Start(pinf);
        }
    }
}
