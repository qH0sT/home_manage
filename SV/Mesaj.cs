using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV
{
    public partial class Mesaj : Form
    {
        Socket soketimiz;
        public Mesaj(Socket s)
        {
            soketimiz = s;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string duyuru_bilgi = File.ReadAllText(
            Environment.CurrentDirectory + @"\Duyurular\duyuru_bilgi.html",
            Encoding.Default).Replace("BAŞLIK",textBox1.Text).Replace("DUYURU", 
            textBox2.Text);

            string duyuru_kritik = File.ReadAllText(
            Environment.CurrentDirectory + @"\Duyurular\duyuru_kritik.html", 
            Encoding.Default).Replace("BAŞLIK", textBox1.Text).Replace("DUYURU", 
            textBox2.Text);

            string duyuru_uyari = File.ReadAllText(
            Environment.CurrentDirectory + @"\Duyurular\duyuru_uyari.html", 
            Encoding.Default).Replace("BAŞLIK", textBox1.Text).Replace("DUYURU",
            textBox2.Text);

            if (radioButton1.Checked)
            {
                soketimiz.Send(Encoding.UTF8.GetBytes("MESAJ|" + duyuru_bilgi));
            }
            else if (radioButton2.Checked)
            {
                soketimiz.Send(Encoding.UTF8.GetBytes("MESAJ|" + duyuru_kritik));
            }
            else if (radioButton3.Checked)
            {
                soketimiz.Send(Encoding.UTF8.GetBytes("MESAJ|" + duyuru_uyari));
            } 
        }
    }
}
