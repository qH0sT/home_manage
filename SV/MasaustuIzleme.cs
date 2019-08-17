using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SV
{
    public partial class MasaustuIzleme : Form
    {
        Socket soketimiz;
        public MasaustuIzleme(Socket s ,string height, string widht, string isim)
        {
            soketimiz = s;
            InitializeComponent();
            Text += isim;
            pictureBox1.Height = int.Parse(height) / 2;
            pictureBox1.Width = int.Parse(widht) / 2;
        }

        private void MasaustuIzleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                soketimiz.Send(Encoding.UTF8.GetBytes("IZLE|0"));
            }
            catch (Exception) { MessageBox.Show("Client ile Server arasındaki bağlantı kesildi.", "Client Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{ 
            soketimiz.Send(Encoding.UTF8.GetBytes("IZLE|1"));
                button1.Enabled = false;
                button2.Enabled = true;
              }
            catch (Exception) { MessageBox.Show("Client ile Server arasındaki bağlantı kesildi.","Client Hatası",MessageBoxButtons.OK,MessageBoxIcon.Error); }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            soketimiz.Send(Encoding.UTF8.GetBytes("IZLE|0"));
                button1.Enabled = true;
                button2.Enabled = false;
            }
            catch (Exception) { MessageBox.Show("Client ile Server arasındaki bağlantı kesildi.", "Client Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    soketimiz.Send(Encoding.UTF8.GetBytes("CLICK|" + e.X.ToString() + "|" + e.Y.ToString()));
                }
                catch (Exception) { MessageBox.Show("Client ile Server arasındaki bağlantı kesildi.", "Client Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
           
        }
    }
}
