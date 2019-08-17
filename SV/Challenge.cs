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

namespace SV
{
    public partial class Challenge : Form
    {
        public Challenge()
        {
            InitializeComponent();
        }
        bool tamammi = false;
        void Oku()
        {
            try
            {
                string[] satirlar = File.ReadAllLines("data.base");
                for (int c = 0; c < satirlar.Length; c++)
                {
                    try
                    {
                        if(textBox1.Text == satirlar[c].Substring(satirlar[c].IndexOf("<Admin>"), satirlar[c].IndexOf("</Admin>")).Replace("<Admin>", string.Empty))
                        {
                            tamammi = true;
                            Close();
                            
                        }
                        else
                        {
                            MessageBox.Show("Hatalı şifre!","Login Error");
                            return;
                        }
                    }
                    catch (Exception) { }

                }
            }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message, "Dosya Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Oku();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { textBox1.PasswordChar = '\0'; } else { textBox1.PasswordChar = '●'; }
        }

        private void Challenge_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(tamammi == false)
            {
                Form1.kapat = "1";
            }
           
        }
    }
}
