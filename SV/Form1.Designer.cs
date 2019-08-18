namespace SV
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mesajYollaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bağlantıyıKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masaustuİzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uRLZiyaretEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imhaEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dosyaYöneticisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.süreAyarlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.güçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilgisayarıKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yenidenBaşlatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.LargeImageList = this.ımageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(831, 275);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Kullanıcı ID";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Kullanıcı İsmi";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Kullanıcı Makine İsmi";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "IP Adres/Port";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Kalan";
            this.columnHeader5.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mesajYollaToolStripMenuItem,
            this.bağlantıyıKapatToolStripMenuItem,
            this.masaustuİzleToolStripMenuItem,
            this.uRLZiyaretEtToolStripMenuItem,
            this.imhaEtToolStripMenuItem,
            this.dosyaYöneticisiToolStripMenuItem,
            this.süreAyarlaToolStripMenuItem,
            this.ayarlarToolStripMenuItem,
            this.güçToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 224);
            this.contextMenuStrip1.Text = "Mesaj Yolla";
            // 
            // mesajYollaToolStripMenuItem
            // 
            this.mesajYollaToolStripMenuItem.Name = "mesajYollaToolStripMenuItem";
            this.mesajYollaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.mesajYollaToolStripMenuItem.Text = "Özel Duyuru Yap";
            this.mesajYollaToolStripMenuItem.Click += new System.EventHandler(this.mesajYollaToolStripMenuItem_Click);
            // 
            // bağlantıyıKapatToolStripMenuItem
            // 
            this.bağlantıyıKapatToolStripMenuItem.Name = "bağlantıyıKapatToolStripMenuItem";
            this.bağlantıyıKapatToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.bağlantıyıKapatToolStripMenuItem.Text = "Bağlantıyı Kapat";
            this.bağlantıyıKapatToolStripMenuItem.Click += new System.EventHandler(this.bağlantıyıKapatToolStripMenuItem_Click);
            // 
            // masaustuİzleToolStripMenuItem
            // 
            this.masaustuİzleToolStripMenuItem.Name = "masaustuİzleToolStripMenuItem";
            this.masaustuİzleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.masaustuİzleToolStripMenuItem.Text = "Masaustu İzle";
            this.masaustuİzleToolStripMenuItem.Click += new System.EventHandler(this.masaustuİzleToolStripMenuItem_Click);
            // 
            // uRLZiyaretEtToolStripMenuItem
            // 
            this.uRLZiyaretEtToolStripMenuItem.Name = "uRLZiyaretEtToolStripMenuItem";
            this.uRLZiyaretEtToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.uRLZiyaretEtToolStripMenuItem.Text = "URL Aç (Normal)";
            this.uRLZiyaretEtToolStripMenuItem.Click += new System.EventHandler(this.uRLZiyaretEtToolStripMenuItem_Click);
            // 
            // imhaEtToolStripMenuItem
            // 
            this.imhaEtToolStripMenuItem.Name = "imhaEtToolStripMenuItem";
            this.imhaEtToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.imhaEtToolStripMenuItem.Text = "İmha Et";
            this.imhaEtToolStripMenuItem.Click += new System.EventHandler(this.imhaEtToolStripMenuItem_Click);
            // 
            // dosyaYöneticisiToolStripMenuItem
            // 
            this.dosyaYöneticisiToolStripMenuItem.Name = "dosyaYöneticisiToolStripMenuItem";
            this.dosyaYöneticisiToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.dosyaYöneticisiToolStripMenuItem.Text = "Dosya Yöneticisi";
            this.dosyaYöneticisiToolStripMenuItem.Click += new System.EventHandler(this.dosyaYöneticisiToolStripMenuItem_Click);
            // 
            // süreAyarlaToolStripMenuItem
            // 
            this.süreAyarlaToolStripMenuItem.Name = "süreAyarlaToolStripMenuItem";
            this.süreAyarlaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.süreAyarlaToolStripMenuItem.Text = "Süre Yönetimi";
            this.süreAyarlaToolStripMenuItem.Click += new System.EventHandler(this.süreAyarlaToolStripMenuItem_Click);
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.ayarlarToolStripMenuItem.Text = "Ayrıntılar";
            this.ayarlarToolStripMenuItem.Click += new System.EventHandler(this.ayarlarToolStripMenuItem_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "no_responding.png");
            this.ımageList1.Images.SetKeyName(1, "away.png");
            this.ımageList1.Images.SetKeyName(2, "online.png");
            this.ımageList1.Images.SetKeyName(3, "away_lock.jpg");
            this.ımageList1.Images.SetKeyName(4, "online_timer.jpg");
            this.ımageList1.Images.SetKeyName(5, "admin.jpg");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Başlat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(639, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 92);
            this.button3.TabIndex = 4;
            this.button3.Text = "Yönetim Paneli";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(44, 32);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            7555,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 281);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 119);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yönetim";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(728, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(73, 92);
            this.button4.TabIndex = 15;
            this.button4.Text = "Hakkında";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(467, 94);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(49, 17);
            this.radioButton3.TabIndex = 14;
            this.radioButton3.Text = "Uyarı";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(467, 57);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(48, 17);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.Text = "Kritik";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(467, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(44, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Bilgi";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(546, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 92);
            this.button2.TabIndex = 11;
            this.button2.Text = "Duyuruyu Yap";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(210, 45);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(251, 66);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "içerik";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(210, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Başlık";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(189, 92);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bağlantı Ayarları";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Port";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon1.BalloonTipText = "Hedef bilgisayarda yönetici oturumu açık, kapatıp tekrar deneyiniz.";
            this.notifyIcon1.BalloonTipTitle = "Uyarı";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Home Manage V2.5 - Server";
            this.notifyIcon1.Visible = true;
            // 
            // güçToolStripMenuItem
            // 
            this.güçToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bilgisayarıKapatToolStripMenuItem,
            this.yenidenBaşlatToolStripMenuItem});
            this.güçToolStripMenuItem.Name = "güçToolStripMenuItem";
            this.güçToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.güçToolStripMenuItem.Text = "Güç";
            // 
            // bilgisayarıKapatToolStripMenuItem
            // 
            this.bilgisayarıKapatToolStripMenuItem.Name = "bilgisayarıKapatToolStripMenuItem";
            this.bilgisayarıKapatToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.bilgisayarıKapatToolStripMenuItem.Text = "Bilgisayarı Kapat";
            this.bilgisayarıKapatToolStripMenuItem.Click += new System.EventHandler(this.bilgisayarıKapatToolStripMenuItem_Click);
            // 
            // yenidenBaşlatToolStripMenuItem
            // 
            this.yenidenBaşlatToolStripMenuItem.Name = "yenidenBaşlatToolStripMenuItem";
            this.yenidenBaşlatToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.yenidenBaşlatToolStripMenuItem.Text = "Yeniden Başlat";
            this.yenidenBaşlatToolStripMenuItem.Click += new System.EventHandler(this.yenidenBaşlatToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 412);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Manage V3.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mesajYollaToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem bağlantıyıKapatToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem masaustuİzleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uRLZiyaretEtToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripMenuItem imhaEtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dosyaYöneticisiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem süreAyarlaToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ImageList ımageList1;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem güçToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilgisayarıKapatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yenidenBaşlatToolStripMenuItem;
    }
}

