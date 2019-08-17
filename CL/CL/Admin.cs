using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CL
{
    public partial class Admin : Form
    {
        Socket s;
        string id;
        public Admin(Socket sock , string uid)
        {
            InitializeComponent();
            s = sock;
            id = uid;
            ((Form1)(Application.OpenForms["Form1"])).button1.Enabled = false;
            ((Form1)(Application.OpenForms["Form1"])).button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == ((Form1)(Application.OpenForms["Form1"])).ADMINISTARTION)
            {
                button2.Enabled = true;
                button1.Enabled = false;
                TopMost = false;
                ((Form1)(Application.OpenForms["Form1"])).admn = "1";
                ((Form1)(Application.OpenForms["Form1"])).label5.Text = "Oturum: Yönetici";
                ((Form1)(Application.OpenForms["Form1"])).timer1.Stop();
                ((Form1)(Application.OpenForms["Form1"])).timer2.Enabled = false;
                Size = new Size(368, 321);
                try { ((Form1)(Application.OpenForms["Form1"])).Soketimiz.Send(Encoding.UTF8.GetBytes("KALAN|" + ((Form1)(Application.OpenForms["Form1"])).PC_UNIQUE_ID + "|Yönetici Oturumu" + "|" + ((Form1)(Application.OpenForms["Form1"])).ism)); }
                catch (Exception) { }
                try { ((Kilit)(Application.OpenForms["Kilit"])).Close(); } catch (Exception) { }
               
            }
            else
            {
                MessageBox.Show("Hatalı Şifre!","Login Error");
                textBox1.Text = ((Form1)(Application.OpenForms["Form1"])).ADMINISTARTION;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { textBox1.PasswordChar = '\0'; }
            else
            { textBox1.PasswordChar = '●'; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)
            delegate
            {
            ((Form1)(Application.OpenForms["Form1"])).label5.Text = "Oturum: Normal";
            if (((Form1)(Application.OpenForms["Form1"])).label1.Text != "Süre:")
            {
                    
             ((Form1)(Application.OpenForms["Form1"])).button1.Enabled = true;
             ((Form1)(Application.OpenForms["Form1"])).button3.Enabled = true;
             ((Form1)(Application.OpenForms["Form1"])).timer1.Start();

             try {
               ((Form1)(Application.OpenForms["Form1"])).Soketimiz.Send(Encoding.UTF8.GetBytes("KALAN|" + id + "|" + ((Form1)(Application.OpenForms["Form1"])).label2.Text + "|" +((Form1)(Application.OpenForms["Form1"])).ism));
              
               } catch (Exception) { }
            
             }
            else if (((Form1)(Application.OpenForms["Form1"])).label1.Text == "Süre:")
            {
               Kilit klt = new Kilit(id);
               klt.Show();
            }
            ((Form1)(Application.OpenForms["Form1"])).button1.Enabled = true;
            ((Form1)(Application.OpenForms["Form1"])).button3.Enabled = true;
            ((Form1)(Application.OpenForms["Form1"])).timer2.Enabled = true;
            Size = new Size(367, 165);
                ((Form1)(Application.OpenForms["Form1"])).admn = "0";
                Hide();

          });
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((Form1)(Application.OpenForms["Form1"])).button1.Enabled = true;
            ((Form1)(Application.OpenForms["Form1"])).button3.Enabled = true;
            if (button2.Enabled)
            {
                button2.PerformClick();
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bunu yapmak istediğinizden emin misiniz ?","Bağlantıyı kapat",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                Environment.Exit(0);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bunu yapmak istediğinizden emin misiniz ?", "İstemciyi kopmple sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Process.Start(new ProcessStartInfo()
                    {
                        Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        FileName = "cmd.exe"
                    });
                    Environment.Exit(0);
                }
                catch (Exception) { }
            }
        }
    }
}
