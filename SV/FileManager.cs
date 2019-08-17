using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SV
{
    public partial class FileManager : Form
    {

        Socket s;
        int i = 1;
        public FileManager(Socket soket, string isim)
        {
            s = soket;
            InitializeComponent();
            Text = "Dosya Yöneticisi: "+isim;
            s.Send(Encoding.UTF8.GetBytes(@"DOSYA|My Computer"));
            i = comboBox1.Items.Count - 1;
            comboBox1.SelectedIndex = i;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems[0].SubItems[1].Text == string.Empty)
            {
                if (textBox1.Text != "My Computer")
            {
                   
                 s.Send(Encoding.UTF8.GetBytes(@"DOSYA|" + listView1.SelectedItems[0].SubItems[2].Text));
                 textBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
                 comboBox1.Items.Add(listView1.SelectedItems[0].SubItems[2].Text);
                    i = comboBox1.Items.Count - 1;
                    comboBox1.SelectedIndex = i;
                }
            else
            {
                
                    s.Send(Encoding.UTF8.GetBytes(@"DOSYA|" + listView1.SelectedItems[0].Text));
                    textBox1.Text = listView1.SelectedItems[0].Text;
                    comboBox1.Items.Add(listView1.SelectedItems[0].Text);
                    i = comboBox1.Items.Count - 1;
                    comboBox1.SelectedIndex = i;

                }

            listView1.Items.Clear();
            }
        }
        public void mesaj(string icerik)
        {
            
            MessageBox.Show("Dosya başarıyla indi.\n" + icerik, "Dosya Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Text = Text.Replace(" İndiriliyor...", string.Empty);
            yenile();
        }
       
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("My Computer"))
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "All Files (*.*)|*.*";
                op.Title = "Select a File";
                if (op.ShowDialog() == DialogResult.OK)
                {

                    byte[] oku = File.ReadAllBytes(op.FileName);
                    s.Send(Encoding.UTF8.GetBytes(@"UPLOAD|" + textBox1.Text + op.FileName.Substring(op.FileName.LastIndexOf(@"\")) + "|" + oku.Length));
                    s.Send(oku, oku.Length, SocketFlags.None);
                    yenile();

                }
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(listView1.SelectedItems[0].SubItems[1].Text))
            {
               
                s.Send(Encoding.UTF8.GetBytes(@"DOWNLOAD|" + listView1.SelectedItems[0].SubItems[2].Text +"\\"+ listView1.SelectedItems[0].Text));
               
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(listView1.SelectedItems[0].SubItems[1].Text))
           {
                s.Send(Encoding.UTF8.GetBytes(@"DELETE|" + listView1.SelectedItems[0].SubItems[2].Text +"\\"+ listView1.SelectedItems[0].Text));
                yenile();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yenile();
        }
        public void yenile()
        {
            s.Send(Encoding.UTF8.GetBytes(@"DOSYA|" + textBox1.Text));
          
            listView1.Items.Clear();
        }

        private void myComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Send(Encoding.UTF8.GetBytes(@"DOSYA|My Computer"));
            textBox1.Text = "My Computer";
            listView1.Items.Clear();
            i = comboBox1.Items.Count - 1;
            comboBox1.SelectedIndex = i;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != comboBox1.Items.Count - 1)
            {
                try
                {
                    i = i + 1;
                    comboBox1.SelectedIndex = i;
                    s.Send(Encoding.UTF8.GetBytes(@"DOSYA|" + comboBox1.SelectedItem.ToString()));
                    textBox1.Text = comboBox1.SelectedItem.ToString();
                    listView1.Items.Clear();
                }
                catch (Exception) {  }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
            if (i > 0)
            {
                try
                {
                    i = i - 1;
                    comboBox1.SelectedIndex = i;
                    s.Send(Encoding.UTF8.GetBytes(@"DOSYA|" + comboBox1.SelectedItem.ToString()));
                    textBox1.Text = comboBox1.SelectedItem.ToString();
                    listView1.Items.Clear();
                }
                catch (Exception) {}

            }

        }

        private void desktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Send(Encoding.UTF8.GetBytes(@"DOSYA|[Desktop]"));
            textBox1.Text = "[Desktop]";
            comboBox1.Items.Add("[Desktop]");
            listView1.Items.Clear();
            i = comboBox1.Items.Count - 1;
            comboBox1.SelectedIndex = i;
        }

        private void applicationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Send(Encoding.UTF8.GetBytes(@"DOSYA|[Application Data]"));
            textBox1.Text = "[Application Data]";
            comboBox1.Items.Add("[Application Data]");
            listView1.Items.Clear();
            i = comboBox1.Items.Count - 1;
            comboBox1.SelectedIndex = i;
        }

        private void documentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Send(Encoding.UTF8.GetBytes(@"DOSYA|[Documents]"));
            textBox1.Text = "[Documents]";
            comboBox1.Items.Add("[Documents]");
            listView1.Items.Clear();
            i = comboBox1.Items.Count - 1;
            comboBox1.SelectedIndex = i;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].SubItems[4].Text == "_FILE")
            {
                s.Send(Encoding.UTF8.GetBytes(@"OPENFILE|" + listView1.SelectedItems[0].SubItems[2].Text + "\\" + listView1.SelectedItems[0].Text));

            }
            else if (listView1.SelectedItems[0].SubItems[4].Text == "FOLDER")
            {
                s.Send(Encoding.UTF8.GetBytes(@"OPENFILE|" + listView1.SelectedItems[0].SubItems[2].Text));
            }
            else if (listView1.SelectedItems[0].SubItems[4].Text == "HDD" || listView1.SelectedItems[0].SubItems[4].Text == "REMOVABLE")
            {
                s.Send(Encoding.UTF8.GetBytes(@"OPENFILE|" + listView1.SelectedItems[0].Text));
            }
        }

        private void hiddenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].SubItems[4].Text == "_FILE")
            {
                s.Send(Encoding.UTF8.GetBytes(@"OPENFILEHIDDEN|" + listView1.SelectedItems[0].SubItems[2].Text + "\\" + listView1.SelectedItems[0].Text));
              
            }
            else if (listView1.SelectedItems[0].SubItems[4].Text == "FOLDER")
            {
                s.Send(Encoding.UTF8.GetBytes(@"OPENFILEHIDDEN|" + listView1.SelectedItems[0].SubItems[2].Text));
            }
            else if (listView1.SelectedItems[0].SubItems[4].Text == "HDD" || listView1.SelectedItems[0].SubItems[4].Text == "REMOVABLE")
            {
                s.Send(Encoding.UTF8.GetBytes(@"OPENFILEHIDDEN|" + listView1.SelectedItems[0].Text));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yenile();
        }
    }
}