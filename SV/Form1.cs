using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace SV
{
    public partial class Form1 : Form
    {
        MasaustuIzleme msust;
        FileManager fm;
        List<Socket> krbn_listesi = new List<Socket>();
        public List<SureBilgileri> sureler = new List<SureBilgileri>();
        Socket msasustu_skt;
        Socket soketimiz = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private byte[] bafirimiz = new byte[short.MaxValue];
        public string ADMIN_SIFRESI = "";
        public Form1()
        {
            InitializeComponent();
            new Challenge().ShowDialog();
            
        }
        public static string Oku()
        {
            string siff = "";
            try
            {
                string[] satirlar = File.ReadAllLines("data.base");
                for (int c = 0; c < satirlar.Length; c++)
                {
                    try
                    {
                    siff = satirlar[c].Substring(satirlar[c].IndexOf("<Admin>"), satirlar[c].IndexOf("</Admin>")).Replace("<Admin>", string.Empty); 
                    }
                    catch (Exception) { }

                }
            }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message, "Dosya Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            return siff;
        }

        public static string kapat = "0";
        void Dinle()
        {
            try
            {
                soketimiz = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                soketimiz.Bind(new IPEndPoint(IPAddress.Any, Convert.ToInt32(numericUpDown1.Value)));
                soketimiz.Listen(int.MaxValue);
                soketimiz.BeginAccept(new AsyncCallback(Client_Kabul), null);
                button1.Enabled = false;
                numericUpDown1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Port Dinleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void Client_Kabul(IAsyncResult ar)
        {
            try
            {
                Socket sock = soketimiz.EndAccept(ar);
                sock.BeginReceive(bafirimiz, 0, bafirimiz.Length, SocketFlags.None, new AsyncCallback(Client_Bilgi_Al), sock);
                soketimiz.BeginAccept(new AsyncCallback(Client_Kabul), null);
            }
            catch (Exception)
            {
            }
        }
         public  void Admin_Gonder(Socket admin_sock)
         {
            Invoke((MethodInvoker)
                                 delegate
                                 {
                                     try
                                     {
                                         admin_sock.Send(Encoding.UTF8.GetBytes("ADMIN|" + ADMIN_SIFRESI));
                                     }
                                     catch (Exception) { }

                                 });
            
         }

        public  void Timer2_Aktif_Ettir(Socket timer_sock)
        {
            Invoke((MethodInvoker)
                                delegate
                                {
                                    try
                {
                    timer_sock.Send(Encoding.UTF8.GetBytes("TIMER2|"));
                }
                catch (Exception) { }
              
            });

        }

        public delegate void _client_ekle(Socket socettt, string idddd, string machine_name, string krbn_ismi, string UNIQUE_ID, string adm);
        public void ekleeee(Socket socettte, string idimiz, string makine_ismi, string krbn_ismi, string UNIQUE_ID, string adm)
        {
            //linq

            IEnumerable<ListViewItem> lvii = listView1.Items.Cast<ListViewItem>();
            var item = from x in lvii
            where x.SubItems[5].Text == UNIQUE_ID
            select x;
            if (item.Count() > 0)
            {
                listView1.Items.Remove(item.FirstOrDefault());
            }

            IEnumerable<SureBilgileri> sb = sureler.Cast<SureBilgileri>();
            var sur = from a in sb
                       where a.UNI_ID == UNIQUE_ID
                       select a;
            if (sur.Count() > 0)
            {
                socettte.Send(Encoding.UTF8.GetBytes("SURE|" + sur.FirstOrDefault().zaman));
            }

            
            krbn_listesi.Add(socettte); 
            ListViewItem lvi = new ListViewItem(krbn_ismi);
            lvi.SubItems.Add(idimiz);
            lvi.SubItems.Add(makine_ismi);
            lvi.SubItems.Add(socettte.RemoteEndPoint.ToString());
            lvi.SubItems.Add("N/A");
            lvi.SubItems.Add(UNIQUE_ID);
            if(adm == "0") { lvi.ImageIndex = 3; } else { lvi.ImageIndex = 5; lvi.Text += "\n" + "Yönetici Oturumu"; }           
            listView1.Items.Add(lvi);
            Admin_Gonder(socettte);
            Timer2_Aktif_Ettir(socettte);
        }
        public void Oku_PC()
        {
            try
            {
                string[] satirlar = File.ReadAllLines(Environment.CurrentDirectory + "\\machines.base");
                foreach (string satir in satirlar)
                {
                    string[] aytimlar = satir.Split('|');
                    ListViewItem lv = new ListViewItem(aytimlar[0]);
                    lv.SubItems.Add(aytimlar[1]);
                    lv.SubItems.Add(aytimlar[2]);
                    lv.SubItems.Add(aytimlar[3]);
                    lv.SubItems.Add(aytimlar[4]);
                    lv.SubItems.Add(aytimlar[5]);
                    lv.ImageIndex = 0;
                    listView1.Items.Add(lv);
                }
            }
            catch (Exception) { }
        }
        public void Kaydet()
        {
            if (listView1.Items.Count > 0)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\machines.base"))
                    {
                        foreach (ListViewItem item in listView1.Items)
                        {
                            try { item.Text = item.Text.Replace(item.Text.Substring(item.Text.IndexOf("\n")), ""); } catch (Exception) { }
                            sw.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",
                            item.Text, "|",
                            item.SubItems[1].Text, "|",
                            item.SubItems[2].Text, "|",
                            item.SubItems[3].Text, "|",
                            item.SubItems[4].Text,"|",
                            item.SubItems[5].Text);
                        }
                    }
                }
                catch (Exception) { }
            }

        }
        public delegate void ekle(string isim);
        public void eklee(string isim)
        {
            string[] ayirt = isim.Split('>');
            string[] ayirt2;
            for (int i = 0; i < ayirt.Length - 1; i++)
            {
               
                ListViewItem lvi = new ListViewItem(ayirt[i]);
               
                ayirt2 = ayirt[i].Split('=');
                try
                {
                   
                    lvi.Text = ayirt2[0];
                    lvi.SubItems.Add(ayirt2[1]);
                    lvi.SubItems.Add(ayirt2[2]);
                    lvi.SubItems.Add(ayirt2[3]);
                    lvi.SubItems.Add(ayirt2[4]);
                    
                    if (ayirt2[1] == string.Empty && ayirt2[2] == string.Empty && ayirt2[3] == string.Empty && ayirt2[4] == "CDROM")
                    {
                        lvi.ImageIndex = 4; //CDROM

                    }
                   else if (ayirt2[1] == string.Empty && ayirt2[2] != string.Empty && ayirt2[3] == string.Empty && ayirt2[4] == "FOLDER")
                    {
                        lvi.ImageIndex = 0; //Folder
                    }
                    else if (ayirt2[1] == string.Empty && ayirt2[2] == string.Empty && ayirt2[4] == "HDD") {
                        lvi.ImageIndex = 1; //HDD
                    }
                   else if (ayirt2[1] == string.Empty && ayirt2[2] == string.Empty && ayirt2[3] == string.Empty && ayirt2[4] == "REMOVABLE")
                    {
                        lvi.ImageIndex = 5; //USB_STICK

                    }
                    else {
                        switch(ayirt2[1])
                        {
                            case ".rar":
                            lvi.ImageIndex = 3;
                            break;
                            case ".zip":
                                lvi.ImageIndex = 3;
                                break;
                            case ".mp4":
                                lvi.ImageIndex = 6;
                                break;
                            case ".mp3":
                                lvi.ImageIndex = 6;
                                break;
                            case ".wav":
                                lvi.ImageIndex = 6;
                                break;
                            case ".avi":
                                lvi.ImageIndex = 6;
                                break;
                            case ".jpg":
                                lvi.ImageIndex = 7;
                                break;
                            case ".png":
                                lvi.ImageIndex = 7;
                                break;
                            case ".jpeg":
                                lvi.ImageIndex = 7;
                                break;
                            case ".gif":
                                lvi.ImageIndex = 7;
                                break;
                            case ".txt":
                                lvi.ImageIndex = 8;
                                break;
                            case ".dll":
                                lvi.ImageIndex = 10;
                                break;
                            case ".exe":
                                lvi.ImageIndex = 11;
                                break;
                            case ".xlsx":
                                lvi.ImageIndex = 12;
                                break;
                            case ".pptx":
                                lvi.ImageIndex = 13;
                                break;
                            case ".docx":
                                lvi.ImageIndex = 14;
                                break;
                            default:
                                lvi.ImageIndex = 9;
                                break;
                        }
                    }
                     

                }
                catch (Exception) { }

                fm.listView1.Items.Add(lvi);
                //((FileManager)(Application.OpenForms["FileManager"])).listView1.Items.Add(lvi);


            }
           
        }

        string masaustuisim = string.Empty;
       
        public delegate void _Masaustu(string height, string widht, string name);
        public void Masaustu(string yukseklik, string genislik, string isimmm)
        {
            
            msust = new MasaustuIzleme(msasustu_skt, yukseklik, genislik, isimmm);
            msust.Show();
        }

        public Image Byte_Arraydan_Resim(byte[] ByteArray)
        {
            using (MemoryStream ms = new MemoryStream(ByteArray))
            {
                Image rsm = Image.FromStream(ms);
                return rsm;
            }
            
        }
        void Client_Bilgi_Al(IAsyncResult ar)
        {

            try {
                Socket soket2 = (Socket)ar.AsyncState;
                int uzunluk = soket2.EndReceive(ar);
                string veri = Encoding.UTF8.GetString(bafirimiz, 0, uzunluk);
                string[] s = veri.Split('|');
                switch (s[0])
                {
                    case "IP":
                        Invoke(new _client_ekle(ekleeee), soket2, soket2.Handle.ToString(), s[1], s[2], s[3], s[4]);                      
                        break;

                    case "ADMINACIK":

                     Invoke((MethodInvoker)
                     delegate
                     {
                         notifyIcon1.ShowBalloonTip(3000);
                     });

                        break;

                    case "STATUS":

                        switch (s[2].Replace("STATUS",""))
                        {

                            case "0":

                                Invoke((MethodInvoker)
                                delegate
                                {
                                    IEnumerable<ListViewItem> sb = listView1.Items.Cast<ListViewItem>();
                                    var sur = from a in sb
                                              where a.SubItems[5].Text == s[1]
                                              select a;
                                    if (sur.Count() > 0)
                                    {
                                        sur.FirstOrDefault().ImageIndex = 4;
                                    }   

                                });
                                break;

                            case "1":

                                Invoke((MethodInvoker)
                                delegate
                                {
                                    IEnumerable<ListViewItem> sb = listView1.Items.Cast<ListViewItem>();
                                    var sur = from a in sb
                                              where a.SubItems[5].Text == s[1]
                                              select a;
                                    if (sur.Count() > 0)
                                    {
                                        sur.FirstOrDefault().ImageIndex = 3;
                                        try { sur.FirstOrDefault().Text = sur.FirstOrDefault().Text.Replace(sur.FirstOrDefault().Text.Substring(sur.FirstOrDefault().Text.IndexOf("\n")), ""); } catch (Exception) { }
                                    }
                                   
                                });
                                break;

                        }

                        break;

                    case "KALAN":
                        Invoke((MethodInvoker)
                        delegate
                        {
                            IEnumerable<ListViewItem> sb = listView1.Items.Cast<ListViewItem>();
                            var sur = from a in sb
                                      where a.SubItems[5].Text == s[1]
                                      select a;
                            if (sur.Count() > 0)
                            {
                                sur.FirstOrDefault().SubItems[4].Text = s[2];
                                sur.FirstOrDefault().Text = s[3] + "\n" + s[2];
                                if (s[2].Contains("Yönetici")) { sur.FirstOrDefault().ImageIndex = 5; }
                                else
                                {
                                    sur.FirstOrDefault().ImageIndex = 4;
                                }
                            }                          

                        });
                        break;

                    case "FILE":

                        Invoke(new ekle(eklee), s[1]);
                        break;

                    case "YUKLENDI":
                        MessageBox.Show(s[1], "Dosya Yöneticisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "OLCULER":
                        Invoke(new _Masaustu(Masaustu), s[2], s[1], masaustuisim);
                        break;
                    case "GONDER":
                        byte[] bit = new byte[Convert.ToInt32(s[2])];
                        soket2.Receive(bit, bit.Length, SocketFlags.None);
                        
                        File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + s[1], bit);
                        ((FileManager)(Application.OpenForms["FileManager"])).mesaj(s[1]);
                        break;
                    case "EKRANRESMI":
                        byte[] b = new byte[int.Parse(s[1])];
                        soket2.Receive(b, b.Length, SocketFlags.None);
                        msust.pictureBox1.Image = Byte_Arraydan_Resim(b);
                        break;

                }

                soket2.BeginReceive(bafirimiz, 0, bafirimiz.Length, SocketFlags.None, new AsyncCallback(Client_Bilgi_Al), soket2);

            }
            catch (Exception) { }
                
        } 
        private void mesajYollaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Socket krbn in krbn_listesi)
            {
                if (krbn.Handle.ToString() == listView1.SelectedItems[0].SubItems[1].Text)
                {
                    Mesaj msj = new Mesaj(krbn);
                    msj.Show();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Socket krbn in krbn_listesi.ToList())
            {
                try
                {
                    krbn.Send(new byte[1]);
                }
                catch (Exception)
                {
                    IEnumerable<ListViewItem> sb = listView1.Items.Cast<ListViewItem>();
                    var sur = from a in sb
                              where a.SubItems[1].Text == krbn.Handle.ToString()
                              select a;
                    if (sur.Count() > 0)
                    {
                        krbn_listesi.Remove(krbn);
                        sur.FirstOrDefault().ImageIndex = 0;

                        try {

                         sur.FirstOrDefault().Text = sur.FirstOrDefault().Text.Replace(sur.FirstOrDefault().Text.Substring(sur.FirstOrDefault().Text.IndexOf("\n")), "");
                          } catch (Exception) { }
                        
                        IEnumerable<SureBilgileri> sb1 = sureler.Cast<SureBilgileri>();
                        var sure = from ac in sb1
                                  where ac.UNI_ID == sur.FirstOrDefault().SubItems[5].Text
                                   select ac;
                        if(sure.Count() > 0)
                        {
                            sureler.Remove(sure.FirstOrDefault());
                        }
                        
                    }
                }
            }
        }

        private void bağlantıyıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool buyuk = listView1.SelectedItems.Count > 0;
            if (buyuk)
            {
                bool evet_hayir = MessageBox.Show("Bunu yapmak istediğinizden emin misiniz?", "Bağlantıyı Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                if (evet_hayir)
                {
                    foreach (Socket krbn in krbn_listesi)
                    {
                        if (krbn.Handle.ToString() == listView1.SelectedItems[0].SubItems[1].Text)
                        {
                            krbn.Send(Encoding.UTF8.GetBytes("KAPAT|"));
                        }
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dinle();
        }

        private void masaustuİzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Socket krbn in krbn_listesi)
            {
                if (krbn.Handle.ToString() == listView1.SelectedItems[0].SubItems[1].Text)
                {
                    krbn.Send(Encoding.UTF8.GetBytes("OLCU|"));
                    msasustu_skt = krbn;
                    masaustuisim = listView1.SelectedItems[0].SubItems[2].Text + " @ " + krbn.RemoteEndPoint.ToString();
               
                }
            }
        }



        private void uRLZiyaretEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Socket krbn in krbn_listesi)
            {
                if (krbn.Handle.ToString() == listView1.SelectedItems[0].SubItems[1].Text)
                {
                    krbn.Send(Encoding.UTF8.GetBytes("URL|" + Microsoft.VisualBasic.Interaction.InputBox("URL Girin", "URL Ziyareti", "https:\\www.google.com.tr", -1, -1)));

                }
            }
        }

     
      
        private void imhaEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool buyuk = listView1.SelectedItems.Count > 0;
            if (buyuk)
            {
                bool evet_hayir = MessageBox.Show("Bunu yapmak istediğinizden emin misiniz?", "Bağlantıyı Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && listView1.SelectedItems.Count > 0;
                if (evet_hayir)
                {
                    foreach (Socket krbn in krbn_listesi)
                    {
                        if (krbn.Handle.ToString() == listView1.SelectedItems[0].SubItems[1].Text)
                        {
                            krbn.Send(Encoding.UTF8.GetBytes("IMHA|"));
                        }
                    }
                }
            }

        }

       
        private void dosyaYöneticisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Socket krbn in krbn_listesi)
            {
                if (krbn.Handle.ToString() == listView1.SelectedItems[0].SubItems[1].Text)
                {
                    fm = new FileManager(krbn, listView1.SelectedItems[0].SubItems[2].Text + " @ " + krbn.RemoteEndPoint.ToString());
                    fm.Show();
                    //new FileManager(krbn, listView1.SelectedItems[0].SubItems[2].Text).Show();
                }
            }
        }

        private void süreAyarlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].ImageIndex != 0)
            {
                if (listView1.SelectedItems[0].Text.Contains("Yönetici"))
                {
                    MessageBox.Show("Hedef bilgisayarda yönetici oturumu açık, kapatıp tekrar deneyiniz.","Süre");
                }
                else
                {
                    foreach (Socket krbn in krbn_listesi)
                    {
                        if (krbn.Handle.ToString() == listView1.SelectedItems[0].SubItems[1].Text)
                        {
                            Sure sre = new Sure(krbn, listView1.SelectedItems[0].SubItems[5].Text, false);
                            sre.Show();
                        }
                    }
                }
               
            }
            else
            {
                Sure sre = new Sure(null, listView1.SelectedItems[0].SubItems[5].Text, true);
                sre.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Admin().ShowDialog();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (kapat == "1") { Environment.Exit(0); }
            ADMIN_SIFRESI = Oku();
            Oku_PC();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Kaydet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string duyuru_bilgi = File.ReadAllText(
            Environment.CurrentDirectory + @"\Duyurular\duyuru_bilgi.html",
            Encoding.Default).Replace("BAŞLIK", textBox1.Text).Replace("DUYURU",
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
                foreach (Socket krbn in krbn_listesi.ToList())
                {
                    try
                    {
                        krbn.Send(Encoding.UTF8.GetBytes("MESAJ|" + duyuru_bilgi));
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                foreach (Socket krbn in krbn_listesi.ToList())
                {
                    try
                    {
                        krbn.Send(Encoding.UTF8.GetBytes("MESAJ|" + duyuru_kritik));
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            else if (radioButton3.Checked)
            {
                foreach (Socket krbn in krbn_listesi.ToList())
                {
                    try
                    {
                        krbn.Send(Encoding.UTF8.GetBytes("MESAJ|" + duyuru_uyari));
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                new Ayrinti(listView1.SelectedItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text,
                    listView1.SelectedItems[0].SubItems[2].Text, listView1.SelectedItems[0].SubItems[3].Text,
                    listView1.SelectedItems[0].SubItems[4].Text, listView1.SelectedItems[0].SubItems[5].Text).Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Hakkinda().Show();
           
        }

        private void bilgisayarıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Socket krbn in krbn_listesi)
            {
                if (krbn.Handle.ToString() == listView1.SelectedItems[0].SubItems[1].Text)
                {
                    krbn.Send(Encoding.UTF8.GetBytes("PCKAPAT|"));
                }
            }
        }

        private void yenidenBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Socket krbn in krbn_listesi)
            {
                if (krbn.Handle.ToString() == listView1.SelectedItems[0].SubItems[1].Text)
                {
                    krbn.Send(Encoding.UTF8.GetBytes("PCRES|"));
                }
            }
        }
    }
}