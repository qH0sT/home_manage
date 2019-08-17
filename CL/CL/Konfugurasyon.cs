using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CL
{
    public partial class Konfugurasyon : Form
    {
        public Konfugurasyon()
        {
            InitializeComponent();
            if (File.Exists("conf.base"))
            {
                Oku();
            }
        }
        void Oku()
        {

            string[] satirlar = File.ReadAllLines("conf.base");
            for (int c = 0; c < satirlar.Length; c++)
            {
                try
                {
                    textBox2.Text = satirlar[c].Substring(satirlar[c].IndexOf("<ISIM>"), satirlar[c].IndexOf("</ISIM>")).Replace("<ISIM>", string.Empty);
                }
                catch (Exception) { }

                try
                {
                    numericUpDown1.Value = Convert.ToInt32(satirlar[c].Substring(satirlar[c].IndexOf("<PORT>"), satirlar[c].IndexOf("</PORT>")).Replace("<PORT>", string.Empty));
                }
                catch (Exception) { }

                try
                {
                    textBox1.Text = satirlar[c].Substring(satirlar[c].IndexOf("<IP>"), satirlar[c].IndexOf("</IP>")).Replace("<IP>", string.Empty);
                }
                catch (Exception) { }

                try
                {
                    textBox3.Text = satirlar[c].Substring(satirlar[c].IndexOf("<DKAGIDI>"), satirlar[c].IndexOf("</DKAGIDI>")).Replace("<DKAGIDI>", string.Empty);
                }
                catch (Exception) { }
            }
        }
        void Yaz()
        {
            try
            {
                if (File.Exists("conf.base")) { File.Delete("conf.base"); }

                using (StreamWriter sw = File.AppendText("conf.base"))
                {
                    sw.WriteLine("<IP>" + textBox1.Text + "</IP>");
                    sw.WriteLine("<PORT>" + numericUpDown1.Value.ToString() + "</PORT>");
                    sw.WriteLine("<ISIM>" + textBox2.Text + "</ISIM>");
                    sw.WriteLine("<DKAGIDI>" + textBox3.Text + "</DKAGIDI>");
                }
                Form1.konfugre = true;
            }
            catch (Exception) { Form1.konfugre = false; }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Yaz();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog op = new OpenFileDialog())
            {
                op.Title = "Duvar kağıdı seçin";
                op.Filter = "Resim Dosyaları (*.jpg, *.png, *.jpeg)|*.jpg; *.png; *.jpeg";
                if(op.ShowDialog() == DialogResult.OK)
                {
                    textBox3.Text = op.FileName;
                }
            }
        }
    }
}
