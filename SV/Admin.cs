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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        void Yaz()
        {
            try
            {   
                    using (StreamWriter sw = new StreamWriter("data.base"))
                    {
                        sw.WriteLine("<Admin>" + textBox1.Text + "</Admin>");
                    }
                
            }
            catch (Exception) {  }

        }
        private void button1_Click(object sender, EventArgs e)
        {
          if(textBox1.Text != textBox2.Text) { MessageBox.Show("Şifreler aynı değil."); return;
          } else { Yaz(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Form1)(Application.OpenForms["Form1"])).sureler.Clear();
        }
    }
}
