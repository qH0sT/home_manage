using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV
{
    public partial class Ayrinti : Form
    {
        public Ayrinti(string isim, string id, string dk, string uniq_id, string ip, string makine_ismi)
        {
            InitializeComponent();   
            string degisecek = "";
            try { degisecek = isim.Substring(isim.IndexOf("Kalan")); } catch (Exception) { degisecek = "NULL"; }
            label1.Text += isim.Replace(degisecek,"");
            label2.Text += id;
            label3.Text += dk;
            label4.Text += uniq_id;
            label5.Text = ip;
            label6.Text += makine_ismi;
        }
    }
}
