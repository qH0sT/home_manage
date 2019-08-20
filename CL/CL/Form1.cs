using System;                                       //############## CODED BY 20071999 ##############//
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;

namespace CL
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();
        byte[] buffer = new byte[short.MaxValue];
        public Socket Soketimiz = default(Socket);
        string aypi_Adresimiz = "127.0.0.1";
        int port_numarasi = 7555;
        public string ism = "EXPER PC";
        public string PC_UNIQUE_ID = "";
        public static bool konfugre = false;
        public Form1()
        {

            InitializeComponent();
            
            tm.Tick += new EventHandler(Paylas);
            tm.Interval = 500;
            StartPosition = FormStartPosition.Manual;
            Rectangle res = Screen.PrimaryScreen.Bounds;
            Location = new Point(res.Width - Size.Width, res.Height - Size.Height - 45);
            Size = new Size(235, Screen.PrimaryScreen.Bounds.Height - 20);
           
            
        }
        void Oku()
        {

            string[] satirlar = File.ReadAllLines("conf.base");
            for (int c = 0; c < satirlar.Length; c++)
            {
                try
                {
                    ism = satirlar[c].Substring(satirlar[c].IndexOf("<ISIM>"), satirlar[c].IndexOf("</ISIM>")).Replace("<ISIM>", string.Empty);
                }
                catch (Exception) { }

                try
                {
                    port_numarasi = Convert.ToInt32(satirlar[c].Substring(satirlar[c].IndexOf("<PORT>"), satirlar[c].IndexOf("</PORT>")).Replace("<PORT>", string.Empty));
                }
                catch (Exception) { }

                try
                {
                    aypi_Adresimiz = satirlar[c].Substring(satirlar[c].IndexOf("<IP>"), satirlar[c].IndexOf("</IP>")).Replace("<IP>", string.Empty);
                }
                catch (Exception) { }

            }
        }
        
          
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

        private const uint MouseEventLeftDown = 0x0002;
        private const uint MouseEventLeftUp = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static string UNIQUE_ID()
        {
            return Environment.MachineName;
        }
        public byte[] Resimden_Byte_Array(Image resim)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                resim.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
            
        }

        public async void Paylas(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
               try
                {

                    Bitmap ekrani_izle = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    Size olculerimiz = new Size(ekrani_izle.Width, ekrani_izle.Height);
                    Graphics grafik = Graphics.FromImage(ekrani_izle);
                    grafik.CopyFromScreen(0, 0, 0, 0, olculerimiz);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ekrani_izle.Save(ms, ImageFormat.Bmp);
                        Soketimiz.Send(Encoding.UTF8.GetBytes("EKRANRESMI|" + ms.ToArray().Length.ToString()));
                        Soketimiz.Send(ms.ToArray(), ms.ToArray().Length, SocketFlags.None);

                    }

                }
                catch (Exception) { }
                await Task.Delay(1);
            });
        }
        public string admn = "0";
        public async void Baglanti_Kur()
        {
            
            await Task.Run(() =>
            {
                try
                {
                   
                    IPEndPoint endpoint = new IPEndPoint(Dns.GetHostAddresses(aypi_Adresimiz)[0], port_numarasi);
                    Soketimiz = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Soketimiz.Connect(endpoint);
                    Soketimiz.Send(Encoding.UTF8.GetBytes("IP|" + Environment.MachineName + "|" + ism + "|" + PC_UNIQUE_ID + "|" + admn));
                    Soketimiz.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(Sunucudan_Gelen_Veriler), Soketimiz);
              
                }
                catch (Exception)
                {
  
                    Baglanti_Kur();
                }
               
            }
           
            );
        }
        static readonly string[] SizeSuffixes =
                 { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        static string SizeSuffix(long value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }
            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

        public delegate void dosyalar(string isimler);
        public void filemanager(string isimler)
        {
            
            try
            {
               if(isimler != "My Computer" && isimler != "[Desktop]" && isimler != "[Application Data]" && isimler != "[Documents]")
                {
                   
                    string[] dosyalars = Directory.GetDirectories(@isimler);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dosyalars.Length; i++)
                    {
                        sb.Append(new DirectoryInfo(dosyalars[i]).Name + "="  +string.Empty + "=" + dosyalars[i] + "=" + string.Empty + "=" + "FOLDER" + ">");

                    }
                    DirectoryInfo di = new DirectoryInfo(@isimler);
                    FileInfo[] fi = di.GetFiles("*.*");
                    for (int i = 0; i < fi.Length; i++)
                    {
                        
                        sb.Append(fi[i].Name + "=" + fi[i].Extension + "=" + fi[i].DirectoryName+ "=" + SizeSuffix(new FileInfo(fi[i].FullName).Length).ToString() + "=" + "_FILE" + ">"); //coded by 20071999

                    }
                    Soketimiz.Send(Encoding.UTF8.GetBytes("FILE|" + sb.ToString()));
                }
               else if(isimler == "My Computer")
                {
                    StringBuilder sb = new StringBuilder();
                    DriveInfo[] drv = DriveInfo.GetDrives();
                    foreach(DriveInfo di in drv)
                    {
                        if(di.DriveType == DriveType.Fixed)
                        {
                            sb.Append(di.Name + "=" + string.Empty + "=" + string.Empty + "=" + SizeSuffix(di.TotalSize).ToString() + "=" + "HDD" + ">"); //coded by 20071999
                        }
                        else if(di.DriveType == DriveType.CDRom)
                        {
                            sb.Append(di.Name + "=" + string.Empty + "=" + string.Empty + "=" + string.Empty + "="+ "CDROM"+ ">");
                        }
                        else if (di.DriveType == DriveType.Removable)
                        {
                            sb.Append(di.Name + "=" + string.Empty + "=" + string.Empty + "=" + string.Empty + "=" + "REMOVABLE" + ">");
                        }
                    }
                   
                   
                    Soketimiz.Send(Encoding.UTF8.GetBytes("FILE|" + sb.ToString()));
                }
                else if (isimler == "[Desktop]")
                {
                 
                    string[] dosyalars = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\");
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dosyalars.Length; i++)
                    {
                       
                        sb.Append(new DirectoryInfo(dosyalars[i]).Name + "=" + string.Empty + "=" + dosyalars[i] + "=" + string.Empty + "=" + "FOLDER" + ">");

                    }
                    DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\");
                    FileInfo[] fi = di.GetFiles("*.*");
                    for (int i = 0; i < fi.Length; i++)
                    {

                        sb.Append(fi[i].Name + "=" + fi[i].Extension + "=" + fi[i].DirectoryName + "=" + SizeSuffix(new FileInfo(fi[i].FullName).Length).ToString() + "=" + "_FILE" + ">"); //coded by 20071999

                    }
                    Soketimiz.Send(Encoding.UTF8.GetBytes("FILE|" + sb.ToString()));
                }
                else if (isimler == "[Documents]")
                {
                    string[] dosyalars = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\");
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dosyalars.Length; i++)
                    {
                       
                        sb.Append(new DirectoryInfo(dosyalars[i]).Name + "=" + string.Empty + "=" + dosyalars[i] + "=" + string.Empty + "=" + "FOLDER" + ">");

                    }
                    DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\");
                    FileInfo[] fi = di.GetFiles("*.*");
                    for (int i = 0; i < fi.Length; i++)
                    {

                        sb.Append(fi[i].Name + "=" + fi[i].Extension + "=" + fi[i].DirectoryName + "=" + SizeSuffix(new FileInfo(fi[i].FullName).Length).ToString() + "=" + "_FILE" + ">"); //coded by 20071999

                    }
                    Soketimiz.Send(Encoding.UTF8.GetBytes("FILE|" + sb.ToString()));
                }
                else if (isimler == "[Application Data]")
                {
                    string[] dosyalars = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\");
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dosyalars.Length; i++)
                    {
                        
                        sb.Append(new DirectoryInfo(dosyalars[i]).Name + "=" + string.Empty + "=" + dosyalars[i] + "=" + string.Empty + "=" + "FOLDER" + ">");

                    }
                    DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\");
                    FileInfo[] fi = di.GetFiles("*.*");
                    for (int i = 0; i < fi.Length; i++)
                    {

                        sb.Append(fi[i].Name + "=" + fi[i].Extension + "=" + fi[i].DirectoryName + "=" + SizeSuffix(new FileInfo(fi[i].FullName).Length).ToString() + "=" + "_FILE" + ">"); //coded by 20071999

                    }
                    Soketimiz.Send(Encoding.UTF8.GetBytes("FILE|" + sb.ToString()));
                }
            }
            catch (Exception ex) { Soketimiz.Send(Encoding.UTF8.GetBytes("FILE|" + ex.Message)); }
          
        }

        
        public void mesaj(string icerik, string baslik, string tur)
        {
            switch (tur)
            {
                case "Bilgi":
                    MessageBox.Show(icerik, baslik, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "Hata":
                    MessageBox.Show(icerik, baslik, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "Uyarı":
                    MessageBox.Show(icerik, baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        public delegate void Sure_Timer_Ac();
        public void Sre_Timer_Acc() {
            
            timer1.Enabled = true;
        }

        public delegate void Sure_Kapat();
        public void Sure_kapat() { timer1.Enabled = false; }

        public delegate void Timer_Ac();
        public void Timer_Acc() { tm.Enabled = true; }

        public delegate void Kapat();
        public void kapat() { tm.Enabled = false; }
        Kilit klt;
        int max = 0;
        int suanki = 0;
        public string ADMINISTARTION = "admin1234";
        void Sunucudan_Gelen_Veriler(IAsyncResult ar)
        {
            try
            {
                Socket sunucu = (Socket)ar.AsyncState;
                int deger = sunucu.EndReceive(ar);
                string[] ayirici = Encoding.UTF8.GetString(buffer, 0, deger).Split('|');
                switch (ayirici[0])
                {
                    
                    case "MESAJ":
                        File.WriteAllText(Environment.CurrentDirectory + @"\temp.html",ayirici[1], Encoding.Default);
                        webBrowser1.Url = new Uri(Environment.CurrentDirectory + @"\temp.html");
                        break;

                    case "PCKAPAT":
                        try
                        {
                            Process.Start("shutdown.exe","-s");
                        }
                        catch (Exception) { }
                        break;

                    case "PCRES":
                        try
                        {
                            Process.Start("shutdown.exe", "-r");
                        }
                        catch (Exception) { }
                        break;

                    case "TIMER2":
                        
                        Invoke((MethodInvoker)
                     delegate
                       {
                           
                       timer2.Enabled = true;
                     
                       });
                      break;

                    case "ADMIN":

                        Invoke((MethodInvoker)
                        delegate
                        { 
                       ADMINISTARTION = ayirici[1].Replace("TIMER2","");
                        using (StreamWriter sw = new StreamWriter("admin.base"))
                        {
                            sw.WriteLine("<ADMIN>" + ADMINISTARTION + "</ADMIN>");
                        }
                        });
                break;

                    case "IZLE":
                        switch (ayirici[1])
                        {
                            case "1":
                                Invoke(new Timer_Ac(Timer_Acc));
                                break;
                            case "0":
                                Invoke(new Kapat(kapat));
                                break;
                        }
                        break;

                    case "SURE":
                        Form frm = Application.OpenForms.Cast<Form>().Where(fm => fm.Name == "Admin").FirstOrDefault();
                        if (frm == null || frm.Visible == false)
                        {
                                                                               
                        Invoke((MethodInvoker)
                                     delegate
                                     {                                      
                                         progressBar1.Value = 0;
                                         ne_kaldi = 0;
                                         suanki = 0;
                                         label1.Text = "Süre:";
                                         label2.Text = "Kalan:";
                                         label3.Text = "%0";
                                         label3.BackColor = SystemColors.ControlLight;
                                         label4.Text = "Uzatma:";
                                         max = 0;

                                         try { ((Kilit)(Application.OpenForms["Kilit"])).Close(); } catch (Exception) { }
                                         Opacity = 100;
                                       
                                     });
                           
                            if (ayirici[1].Contains("s") == false)
                        {
                            label1.Text = "Süre: " + ayirici[1] + " dk";
                            max = int.Parse(ayirici[1]);
                            label2.Text = "Kalan: " + ayirici[1] + " dk";
                        }
                        else
                        {
              
                      switch (ayirici[1])
                        {

                       case "1s":
                           max = 60;
                           label1.Text = "Süre: 1 Saat";
                                    label2.Text = "Kalan: 1 Saat";
                           break;
                       case "1.5s":
                           max = 90;
                           label1.Text = "Süre: 1.5 Saat";
                                    label2.Text = "Kalan: 1.5 Saat";
                                    break;
                       case "2s":
                           max = 120;
                           label1.Text = "Süre: 2 Saat";
                                    label2.Text = "Kalan: 2 Saat";
                                    break;
                       case "2.5s":
                           max = 150;
                           label1.Text = "Süre: 2.5 Saat";
                                    label2.Text = "Kalan: 2.5 Saat";
                                    break;
                         }
                            
                        }
                        Soketimiz.Send(Encoding.UTF8.GetBytes("KALAN|" + PC_UNIQUE_ID + "|" + label2.Text + "|" + ism));
                        Invoke(new Sure_Timer_Ac(Sre_Timer_Acc));

                        }
                        else if(frm != null || frm.Visible == true)
                        { Soketimiz.Send(Encoding.UTF8.GetBytes("ADMINACIK|")); }
                        //yönetici açık mesajı gönder
                        break;

                    case "EKLE":

                        if (ayirici[1].Contains("s") == false)
                        {
                            label4.Text = "Uzatma: "+ ayirici[1] + " dk";
                            max += int.Parse(ayirici[1]);
                        }
                        else
                        {

                            switch (ayirici[1])
                            {

                                case "1s":
                                    max += 60;
                                    label4.Text = "Uzatma: 1 Saat";
                                    break;
                                case "1.5s":
                                    max += 90;
                                    label4.Text = "Uzatma: 1.5 Saat";
                                    break;
                                case "2s":
                                    max += 120;
                                    label4.Text = "Uzatma: 2 Saat";
                                    break;
                                case "2.5s":
                                    max += 150;
                                    label4.Text = "Uzatma: 2.5 Saat";
                                    break;
                            }

                        }
                        Invoke((MethodInvoker)
                                    delegate
                                    {
                                        progressBar1.Value = (suanki * 100) / max;
                                        ne_kaldi = max - suanki;
                                        label2.Text = "Kalan: " + string.Format("{0:00}:{1:00}", ne_kaldi / 60, ne_kaldi % 60);
                                        label3.Text = "%" + progressBar1.Value.ToString();
                                        Soketimiz.Send(Encoding.UTF8.GetBytes("KALAN|" + PC_UNIQUE_ID + "|" + label2.Text + "|" + ism));
                                    });
                        break;

                    case "URL":
                        try
                        {
                            Process.Start(ayirici[1]);
                        }
                        catch (Exception) { }
                        break;
                   
                    /////////
                    case "KAPAT":
                        Environment.Exit(0);
                        break;
                    case "LOCK":
                        
                        Invoke((MethodInvoker)
                                   delegate
                                   {
                                       klt = new Kilit(PC_UNIQUE_ID);
                                       klt.Show();
                                       timer1.Enabled = false;
                                       progressBar1.Value = 0;
                                       ne_kaldi = 0;
                                       suanki = 0;
                                       label1.Text = "Süre:";
                                       label2.Text = "Kalan:";
                                       label3.Text = "%0";
                                       label3.BackColor = SystemColors.ControlLight;
                                       max = 0;
                                   });
                        break;
                    case "OPENFILE":
                        try
                        {
                            Process.Start(ayirici[1]);
                        }
                        catch (Exception) { }
                        break;
                    case "OPENFILEHIDDEN":
                        try
                        {
                            ProcessStartInfo p = new ProcessStartInfo();
                            p.FileName = ayirici[1];
                            p.CreateNoWindow = true;
                            p.WindowStyle = ProcessWindowStyle.Hidden;
                            Process.Start(p);
                        }
                        catch (Exception) { }
                        break;
                    case "CLICK":
                        Cursor.Position = new Point(int.Parse(ayirici[1]) * 2, int.Parse(ayirici[2]) * 2);
                        try
                        {
                            int X = Cursor.Position.X;
                            int Y = Cursor.Position.Y;
                            mouse_event(MouseEventLeftDown, 0, 0, 0, new IntPtr());
                            mouse_event(MouseEventLeftUp, 0, 0, 0, new IntPtr());
                        }
                        catch (Exception) { Application.Exit(); }
                        break;
                    case "DELETE":
                        try
                        {
                            File.Delete(ayirici[1]);
                        }
                        catch (Exception) { }
                        
                        break;
                    case "DOSYA":
                        
                        Invoke(new dosyalar(filemanager), @ayirici[1]); 
                        break;
                    case "OLCU":
                       Soketimiz.Send(Encoding.UTF8.GetBytes("OLCULER|"+ Screen.PrimaryScreen.Bounds.Width.ToString() + "|" + Screen.PrimaryScreen.Bounds.Height.ToString()));
                      
                        break;
                    case "DOWNLOAD":
                        try
                        {
                            byte[] dosya_down = File.ReadAllBytes(@ayirici[1]);
                            Soketimiz.Send(Encoding.UTF8.GetBytes("GONDER|" + ayirici[1].Substring(ayirici[1].LastIndexOf(@"\")+1) +"|"+ dosya_down.Length.ToString()));
                            Soketimiz.Send(dosya_down, dosya_down.Length, SocketFlags.None);
                        }
                        catch (Exception ex) { Soketimiz.Send(Encoding.UTF8.GetBytes("YUKLENDI|" + ex.Message)); }

                        break;
                    case "UPLOAD":
                        try
                        {
                            string yol = ayirici[1].Substring(ayirici[1].LastIndexOf(@"\") + 1);
                            if (ayirici[1].Contains("[Desktop]"))
                            {
                                ayirici[1] = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + yol;
                            }
                            if (ayirici[1].Contains("[Application Data]"))
                            {
                                ayirici[1] = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + yol;
                            }
                            if (ayirici[1].Contains("[Documents]"))
                            {
                                ayirici[1] = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + yol;
                            }
                            byte[] dosya = new byte[Convert.ToInt32(ayirici[2])];
                            sunucu.Receive(dosya, dosya.Length, SocketFlags.None);
                            File.WriteAllBytes(ayirici[1], dosya);
                            Soketimiz.Send(Encoding.UTF8.GetBytes("YUKLENDI|Dosya başarıyla karşıya yüklendi."));
                        }
                        catch (Exception ex) { Soketimiz.Send(Encoding.UTF8.GetBytes("YUKLENDI|"+ex.Message)); }
                        break;
                    case "IMHA":
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
                        break;


                }
                sunucu.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(Sunucudan_Gelen_Veriler), sunucu);
            }
            catch (Exception ) { Baglanti_Kur(); }
        }
        int ne_kaldi = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            suanki += 1;
            Invoke((MethodInvoker)
            delegate
            {
            progressBar1.Value = (suanki * 100) / max;
            ne_kaldi = max - suanki;
            label2.Text = "Kalan: " + string.Format("{0:00}:{1:00}", ne_kaldi / 60, ne_kaldi % 60);
            label3.Text = "%" + progressBar1.Value.ToString();
            if (progressBar1.Value > 45) { label3.BackColor = Color.FromArgb(6, 176, 37); }
           try { Soketimiz.Send(Encoding.UTF8.GetBytes("KALAN|" + PC_UNIQUE_ID + "|" + label2.Text + "|" + ism)); } catch (Exception) { }
            

            });
            if(suanki == max)
            {

            Invoke((MethodInvoker)
            delegate
            {
                progressBar1.Value = 0;
                timer1.Enabled = false;
                ne_kaldi =0;
                suanki = 0;
                label1.Text = "Süre:";
                label2.Text = "Kalan:";
                label3.Text = "%0";
                label3.BackColor = SystemColors.ControlLight;
                label4.Text = "Uzatma:";
                max = 0;
                klt = new Kilit(PC_UNIQUE_ID);
                klt.Show();
                
                
            });

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)
            delegate
            {
                progressBar1.Value = 0;
                timer1.Enabled = false;
                ne_kaldi = 0;
                suanki = 0;
                label1.Text = "Süre:";
                label2.Text = "Kalan:";
                label3.Text = "%0";
                label3.BackColor = SystemColors.ControlLight;
                label4.Text = "Uzatma:";
                max = 0;
                klt = new Kilit(PC_UNIQUE_ID);
                klt.Show();
                
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Opacity = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("conf.base")) { new Konfugurasyon().ShowDialog(); }
            else if (File.Exists("conf.base") && File.ReadAllText("conf.base").Length == 0)
            {
                Konfugurasyon conf = new Konfugurasyon();
                conf.ShowDialog();
                
            }
            else { konfugre = true; }

            if (konfugre == false)
            {
            MessageBox.Show("Yapılandırma ayarları yapılmadı.", "config"); Environment.Exit(0); }
            else { Oku(); }

            PC_UNIQUE_ID = UNIQUE_ID().Replace(" ","");
            Kilit klt = new Kilit(PC_UNIQUE_ID);
            klt.Show();
            Baglanti_Kur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Admin(Soketimiz, PC_UNIQUE_ID).Show();
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Hakkında";
            notifyIcon1.BalloonTipText = "Coded & Designed by 20071999";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(2000);
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sifre = Microsoft.VisualBasic.Interaction.InputBox("", "Admin Şifresi", "", -1, -1);
            if(sifre == ADMINISTARTION)
            {
                Konfugurasyon conf = new Konfugurasyon();
                conf.Show();
               
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
            try {

                Soketimiz.Send(new byte[1]);

               } catch (Exception)
               {
  
                Invoke((MethodInvoker)
            delegate
            {
                timer1.Stop();

                Form frm = Application.OpenForms.Cast<Form>().Where(fm => fm.Name == "Kilit").FirstOrDefault();
                if (frm == null)
                {
                    klt = new Kilit(PC_UNIQUE_ID);
                    klt.Show();
                }
                
                timer2.Enabled = false;
            });
            }
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                e.Cancel = true;
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sifre = Microsoft.VisualBasic.Interaction.InputBox("", "Admin Şifresi", "", -1, -1);
            if (sifre == ADMINISTARTION)
            {
                Environment.Exit(0);

            }
        }
    }
}
