using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV
{
    public partial class Sure : Form
    {
        Socket sock;
        string aydi;
        bool sonra;
        public Sure(Socket soket, string id , bool yeah)
        {
            InitializeComponent();
            sock = soket;
            aydi = id;
            sonra = yeah;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<SureBilgileri> sb = ((Form1)(Application.OpenForms["Form1"])).sureler.Cast<SureBilgileri>();
            var sur = from a in sb
                      where a.UNI_ID == ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text
                      select a;
            if (sur.Count() > 0)
            {
                ((Form1)(Application.OpenForms["Form1"])).sureler.Remove(sur.FirstOrDefault());
         
            }

            try
                {
                sock.Send(Encoding.UTF8.GetBytes("SURE|30"));
                    ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                    new SureBilgileri("30",
                   ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
                }
                catch (Exception)
                {

               
                  ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                  new SureBilgileri("30",
                   ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
                 }
         
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IEnumerable<SureBilgileri> sb = ((Form1)(Application.OpenForms["Form1"])).sureler.Cast<SureBilgileri>();
            var sur = from a in sb
                      where a.UNI_ID == ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text
                      select a;
            if (sur.Count() > 0)
            {
                ((Form1)(Application.OpenForms["Form1"])).sureler.Remove(sur.FirstOrDefault());
            }
            try
            { sock.Send(Encoding.UTF8.GetBytes("SURE|45"));
                ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                     new SureBilgileri("45",
                     ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
            }
             catch (Exception)
                {
                    ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                     new SureBilgileri("45",
                     ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
                }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IEnumerable<SureBilgileri> sb = ((Form1)(Application.OpenForms["Form1"])).sureler.Cast<SureBilgileri>();
            var sur = from a in sb
                      where a.UNI_ID == ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text
                      select a;
            if (sur.Count() > 0)
            {
                ((Form1)(Application.OpenForms["Form1"])).sureler.Remove(sur.FirstOrDefault());
            }
            try
            { sock.Send(Encoding.UTF8.GetBytes("SURE|1s")); ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                new SureBilgileri("1s",
               ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
                }
            catch (Exception) {
                    ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
               new SureBilgileri("1s",
                 ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
                }
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IEnumerable<SureBilgileri> sb = ((Form1)(Application.OpenForms["Form1"])).sureler.Cast<SureBilgileri>();
            var sur = from a in sb
                      where a.UNI_ID == ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text
                      select a;
            if (sur.Count() > 0)
            {
                ((Form1)(Application.OpenForms["Form1"])).sureler.Remove(sur.FirstOrDefault());
            }
            try
            {
                     sock.Send(Encoding.UTF8.GetBytes("SURE|1.5s"));
                     ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                     new SureBilgileri("1.5s",
                     ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
                 }
            catch (Exception) {

                    ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                      new SureBilgileri("1.5s",
                      ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
                }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IEnumerable<SureBilgileri> sb = ((Form1)(Application.OpenForms["Form1"])).sureler.Cast<SureBilgileri>();
            var sur = from a in sb
                      where a.UNI_ID == ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text
                      select a;
            if (sur.Count() > 0)
            {
                ((Form1)(Application.OpenForms["Form1"])).sureler.Remove(sur.FirstOrDefault());
            }
            try
            {
                sock.Send(Encoding.UTF8.GetBytes("SURE|2s"));
                    ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                    new SureBilgileri("2s",
                   ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
                }
               catch (Exception) {

                    ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                    new SureBilgileri("2s",
                    ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));

                }
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IEnumerable<SureBilgileri> sb = ((Form1)(Application.OpenForms["Form1"])).sureler.Cast<SureBilgileri>();
            var sur = from a in sb
                      where a.UNI_ID == ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text
                      select a;
            if (sur.Count() > 0)
            {
                ((Form1)(Application.OpenForms["Form1"])).sureler.Remove(sur.FirstOrDefault());
            }
            try
            {
                sock.Send(Encoding.UTF8.GetBytes("SURE|2.5s"));
                    ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                     new SureBilgileri("2.5s",
                   ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
                }
            catch (Exception) {

                    ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                     new SureBilgileri("2.5s",
                     ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
                }
         
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(sonra == false) { 
            try
            { sock.Send(Encoding.UTF8.GetBytes("SURE|"+ numericUpDown1.Value.ToString())); }
            catch (Exception) { }
            }
            else
            {
                ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                new SureBilgileri(numericUpDown1.Value.ToString(),
               ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            { sock.Send(Encoding.UTF8.GetBytes("EKLE|" + numericUpDown2.Value.ToString())); }
            catch (Exception) { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            { sock.Send(Encoding.UTF8.GetBytes("EKLE|30")); }
            catch (Exception) { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            { sock.Send(Encoding.UTF8.GetBytes("EKLE|45")); }
            catch (Exception) { }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            { sock.Send(Encoding.UTF8.GetBytes("EKLE|1s")); }
            catch (Exception) { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            { sock.Send(Encoding.UTF8.GetBytes("EKLE|1.5s")); }
            catch (Exception) { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            { sock.Send(Encoding.UTF8.GetBytes("EKLE|2.s")); }
            catch (Exception) { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            { sock.Send(Encoding.UTF8.GetBytes("EKLE|2.5s")); }
            catch (Exception) { }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            { sock.Send(Encoding.UTF8.GetBytes("EKLE|15")); }
            catch (Exception) { }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(sonra == false) { 
            try
            { sock.Send(Encoding.UTF8.GetBytes("SURE|15")); }
            catch (Exception) { }
            }
            else
            {
                ((Form1)(Application.OpenForms["Form1"])).sureler.Add(
                new SureBilgileri("15",
               ((Form1)(Application.OpenForms["Form1"])).listView1.SelectedItems[0].SubItems[5].Text));
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
           
                try
                { sock.Send(Encoding.UTF8.GetBytes("LOCK|")); }
                catch (Exception) { }
            
        }
    }
}
