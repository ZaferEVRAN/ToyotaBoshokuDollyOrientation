namespace ToyotaBoshokuDollyOrientation
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlBilgi = new System.Windows.Forms.Panel();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.lblBarkod = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnAnaSayfa = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnInfo = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnExit = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnAltSekme = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblSaat = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblUstBilgi = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnlAltBaslik = new System.Windows.Forms.Panel();
            this.btnHata = new System.Windows.Forms.Button();
            this.bunifuCustomLabel12 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnlAltBilgi = new System.Windows.Forms.Panel();
            this.btnKlavye = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblModbusRTUBilgi = new System.Windows.Forms.Label();
            this.lblNowDeviceID = new System.Windows.Forms.Label();
            this.btnKarkasByPassAktif = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnKarkasByPassPasif = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnKilitAcik = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnKilitKapali = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblIsikBaglantiAciklama = new System.Windows.Forms.Label();
            this.btnKilitMekanizmasıHazir = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnIsiklarHazir = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnServerHazir = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnServerHazirDegil = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnIsiklarHazirDegil = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnKilitMekanizmasıHazirDegil = new Bunifu.Framework.UI.BunifuFlatButton();
            this.saat = new System.Windows.Forms.Timer(this.components);
            this.connection = new System.Windows.Forms.Timer(this.components);
            this.stepMotor = new System.Windows.Forms.Timer(this.components);
            this.buzzer = new System.Windows.Forms.Timer(this.components);
            this.pnlNumarator = new System.Windows.Forms.Panel();
            this.btnDollyNoGir = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btnNumaratorKapat = new Bunifu.Framework.UI.BunifuImageButton();
            this.pnlBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAnaSayfa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAltSekme)).BeginInit();
            this.pnlAltBaslik.SuspendLayout();
            this.pnlAltBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnKlavye)).BeginInit();
            this.pnlNumarator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNumaratorKapat)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBilgi
            // 
            this.pnlBilgi.BackColor = System.Drawing.Color.Black;
            this.pnlBilgi.Controls.Add(this.txtBarkod);
            this.pnlBilgi.Controls.Add(this.lblBarkod);
            this.pnlBilgi.Controls.Add(this.btnAnaSayfa);
            this.pnlBilgi.Controls.Add(this.bunifuImageButton1);
            this.pnlBilgi.Controls.Add(this.btnInfo);
            this.pnlBilgi.Controls.Add(this.btnExit);
            this.pnlBilgi.Controls.Add(this.btnAltSekme);
            this.pnlBilgi.Controls.Add(this.lblSaat);
            this.pnlBilgi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBilgi.Location = new System.Drawing.Point(0, 0);
            this.pnlBilgi.Name = "pnlBilgi";
            this.pnlBilgi.Size = new System.Drawing.Size(1293, 95);
            this.pnlBilgi.TabIndex = 2;
            // 
            // txtBarkod
            // 
            this.txtBarkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtBarkod.Location = new System.Drawing.Point(152, 7);
            this.txtBarkod.Multiline = true;
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(164, 37);
            this.txtBarkod.TabIndex = 196;
            this.txtBarkod.Click += new System.EventHandler(this.txtBarkod_Click);
            this.txtBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkodLH_KeyDown);
            // 
            // lblBarkod
            // 
            this.lblBarkod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarkod.ForeColor = System.Drawing.Color.White;
            this.lblBarkod.Location = new System.Drawing.Point(143, 46);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(42, 46);
            this.lblBarkod.TabIndex = 197;
            this.lblBarkod.Text = "?";
            // 
            // btnAnaSayfa
            // 
            this.btnAnaSayfa.BackColor = System.Drawing.Color.Transparent;
            this.btnAnaSayfa.ErrorImage = null;
            this.btnAnaSayfa.Image = ((System.Drawing.Image)(resources.GetObject("btnAnaSayfa.Image")));
            this.btnAnaSayfa.ImageActive = null;
            this.btnAnaSayfa.Location = new System.Drawing.Point(7, 7);
            this.btnAnaSayfa.Name = "btnAnaSayfa";
            this.btnAnaSayfa.Size = new System.Drawing.Size(131, 80);
            this.btnAnaSayfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAnaSayfa.TabIndex = 37;
            this.btnAnaSayfa.TabStop = false;
            this.btnAnaSayfa.Zoom = 10;
            this.btnAnaSayfa.Click += new System.EventHandler(this.btnAnaSayfa_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.AccessibleDescription = "";
            this.bunifuImageButton1.AccessibleName = "";
            this.bunifuImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.ErrorImage = null;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(322, 6);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(609, 81);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 36;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Tag = "";
            this.bunifuImageButton1.Zoom = 0;
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnInfo.ErrorImage = null;
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.ImageActive = null;
            this.btnInfo.Location = new System.Drawing.Point(1083, 12);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(66, 39);
            this.btnInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnInfo.TabIndex = 35;
            this.btnInfo.TabStop = false;
            this.btnInfo.Visible = false;
            this.btnInfo.Zoom = 10;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ErrorImage = null;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageActive = null;
            this.btnExit.Location = new System.Drawing.Point(1215, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 39);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 34;
            this.btnExit.TabStop = false;
            this.btnExit.Zoom = 10;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAltSekme
            // 
            this.btnAltSekme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAltSekme.BackColor = System.Drawing.Color.Transparent;
            this.btnAltSekme.ErrorImage = null;
            this.btnAltSekme.Image = ((System.Drawing.Image)(resources.GetObject("btnAltSekme.Image")));
            this.btnAltSekme.ImageActive = null;
            this.btnAltSekme.Location = new System.Drawing.Point(1155, 12);
            this.btnAltSekme.Name = "btnAltSekme";
            this.btnAltSekme.Size = new System.Drawing.Size(66, 39);
            this.btnAltSekme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAltSekme.TabIndex = 33;
            this.btnAltSekme.TabStop = false;
            this.btnAltSekme.Visible = false;
            this.btnAltSekme.Zoom = 10;
            this.btnAltSekme.Click += new System.EventHandler(this.btnAltSekme_Click);
            // 
            // lblSaat
            // 
            this.lblSaat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaat.AutoSize = true;
            this.lblSaat.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSaat.ForeColor = System.Drawing.Color.White;
            this.lblSaat.Location = new System.Drawing.Point(1060, 59);
            this.lblSaat.Name = "lblSaat";
            this.lblSaat.Size = new System.Drawing.Size(47, 28);
            this.lblSaat.TabIndex = 32;
            this.lblSaat.Text = "saat";
            // 
            // lblUstBilgi
            // 
            this.lblUstBilgi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUstBilgi.AutoSize = true;
            this.lblUstBilgi.Font = new System.Drawing.Font("Segoe UI", 30F);
            this.lblUstBilgi.ForeColor = System.Drawing.Color.White;
            this.lblUstBilgi.Location = new System.Drawing.Point(3, 0);
            this.lblUstBilgi.Name = "lblUstBilgi";
            this.lblUstBilgi.Size = new System.Drawing.Size(629, 54);
            this.lblUstBilgi.TabIndex = 3;
            this.lblUstBilgi.Text = "Doortrim Dolly Traceability System";
            this.lblUstBilgi.Click += new System.EventHandler(this.lblUstBilgi_Click);
            // 
            // pnlAltBaslik
            // 
            this.pnlAltBaslik.BackColor = System.Drawing.Color.Navy;
            this.pnlAltBaslik.Controls.Add(this.btnHata);
            this.pnlAltBaslik.Controls.Add(this.lblUstBilgi);
            this.pnlAltBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAltBaslik.Location = new System.Drawing.Point(0, 95);
            this.pnlAltBaslik.Name = "pnlAltBaslik";
            this.pnlAltBaslik.Size = new System.Drawing.Size(1293, 56);
            this.pnlAltBaslik.TabIndex = 3;
            this.pnlAltBaslik.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAltBaslik_Paint);
            // 
            // btnHata
            // 
            this.btnHata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHata.BackColor = System.Drawing.Color.Red;
            this.btnHata.FlatAppearance.BorderSize = 3;
            this.btnHata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHata.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnHata.Location = new System.Drawing.Point(1127, 2);
            this.btnHata.Name = "btnHata";
            this.btnHata.Size = new System.Drawing.Size(153, 53);
            this.btnHata.TabIndex = 44;
            this.btnHata.Text = "Kilit Arıza!";
            this.btnHata.UseVisualStyleBackColor = false;
            this.btnHata.Visible = false;
            this.btnHata.Click += new System.EventHandler(this.btnHata_Click);
            // 
            // bunifuCustomLabel12
            // 
            this.bunifuCustomLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCustomLabel12.AutoSize = true;
            this.bunifuCustomLabel12.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel12.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel12.Location = new System.Drawing.Point(1243, 8);
            this.bunifuCustomLabel12.Name = "bunifuCustomLabel12";
            this.bunifuCustomLabel12.Size = new System.Drawing.Size(38, 20);
            this.bunifuCustomLabel12.TabIndex = 47;
            this.bunifuCustomLabel12.Text = "v2.8";
            // 
            // pnlAltBilgi
            // 
            this.pnlAltBilgi.Controls.Add(this.btnKlavye);
            this.pnlAltBilgi.Controls.Add(this.lblModbusRTUBilgi);
            this.pnlAltBilgi.Controls.Add(this.lblNowDeviceID);
            this.pnlAltBilgi.Controls.Add(this.btnKarkasByPassAktif);
            this.pnlAltBilgi.Controls.Add(this.btnKarkasByPassPasif);
            this.pnlAltBilgi.Controls.Add(this.btnKilitAcik);
            this.pnlAltBilgi.Controls.Add(this.btnKilitKapali);
            this.pnlAltBilgi.Controls.Add(this.lblIsikBaglantiAciklama);
            this.pnlAltBilgi.Controls.Add(this.btnKilitMekanizmasıHazir);
            this.pnlAltBilgi.Controls.Add(this.btnIsiklarHazir);
            this.pnlAltBilgi.Controls.Add(this.bunifuCustomLabel12);
            this.pnlAltBilgi.Controls.Add(this.btnServerHazir);
            this.pnlAltBilgi.Controls.Add(this.btnServerHazirDegil);
            this.pnlAltBilgi.Controls.Add(this.btnIsiklarHazirDegil);
            this.pnlAltBilgi.Controls.Add(this.btnKilitMekanizmasıHazirDegil);
            this.pnlAltBilgi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAltBilgi.Location = new System.Drawing.Point(0, 677);
            this.pnlAltBilgi.Name = "pnlAltBilgi";
            this.pnlAltBilgi.Size = new System.Drawing.Size(1293, 38);
            this.pnlAltBilgi.TabIndex = 42;
            // 
            // btnKlavye
            // 
            this.btnKlavye.AccessibleDescription = "";
            this.btnKlavye.AccessibleName = "";
            this.btnKlavye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKlavye.BackColor = System.Drawing.Color.Transparent;
            this.btnKlavye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKlavye.ErrorImage = null;
            this.btnKlavye.Image = ((System.Drawing.Image)(resources.GetObject("btnKlavye.Image")));
            this.btnKlavye.ImageActive = null;
            this.btnKlavye.Location = new System.Drawing.Point(1105, 0);
            this.btnKlavye.Name = "btnKlavye";
            this.btnKlavye.Size = new System.Drawing.Size(52, 34);
            this.btnKlavye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnKlavye.TabIndex = 132;
            this.btnKlavye.TabStop = false;
            this.btnKlavye.Tag = "";
            this.btnKlavye.Zoom = 10;
            this.btnKlavye.Click += new System.EventHandler(this.btnKlavye_Click);
            // 
            // lblModbusRTUBilgi
            // 
            this.lblModbusRTUBilgi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblModbusRTUBilgi.AutoSize = true;
            this.lblModbusRTUBilgi.Location = new System.Drawing.Point(682, 5);
            this.lblModbusRTUBilgi.Name = "lblModbusRTUBilgi";
            this.lblModbusRTUBilgi.Size = new System.Drawing.Size(87, 13);
            this.lblModbusRTUBilgi.TabIndex = 140;
            this.lblModbusRTUBilgi.Text = "ModbusRTUBilgi";
            // 
            // lblNowDeviceID
            // 
            this.lblNowDeviceID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNowDeviceID.AutoSize = true;
            this.lblNowDeviceID.Location = new System.Drawing.Point(1163, 14);
            this.lblNowDeviceID.Name = "lblNowDeviceID";
            this.lblNowDeviceID.Size = new System.Drawing.Size(74, 13);
            this.lblNowDeviceID.TabIndex = 138;
            this.lblNowDeviceID.Text = "NowDeviceID";
            this.lblNowDeviceID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnKarkasByPassAktif
            // 
            this.btnKarkasByPassAktif.Activecolor = System.Drawing.Color.Empty;
            this.btnKarkasByPassAktif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnKarkasByPassAktif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKarkasByPassAktif.BorderRadius = 0;
            this.btnKarkasByPassAktif.ButtonText = "Karkas Aktif";
            this.btnKarkasByPassAktif.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKarkasByPassAktif.Iconcolor = System.Drawing.Color.Transparent;
            this.btnKarkasByPassAktif.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnKarkasByPassAktif.Iconimage")));
            this.btnKarkasByPassAktif.Iconimage_right = null;
            this.btnKarkasByPassAktif.Iconimage_right_Selected = null;
            this.btnKarkasByPassAktif.Iconimage_Selected = null;
            this.btnKarkasByPassAktif.IconZoom = 90D;
            this.btnKarkasByPassAktif.IsTab = false;
            this.btnKarkasByPassAktif.Location = new System.Drawing.Point(540, 4);
            this.btnKarkasByPassAktif.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKarkasByPassAktif.Name = "btnKarkasByPassAktif";
            this.btnKarkasByPassAktif.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnKarkasByPassAktif.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnKarkasByPassAktif.OnHoverTextColor = System.Drawing.Color.White;
            this.btnKarkasByPassAktif.selected = false;
            this.btnKarkasByPassAktif.Size = new System.Drawing.Size(127, 31);
            this.btnKarkasByPassAktif.TabIndex = 136;
            this.btnKarkasByPassAktif.Textcolor = System.Drawing.Color.White;
            this.btnKarkasByPassAktif.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnKarkasByPassPasif
            // 
            this.btnKarkasByPassPasif.Activecolor = System.Drawing.Color.Empty;
            this.btnKarkasByPassPasif.BackColor = System.Drawing.Color.Maroon;
            this.btnKarkasByPassPasif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKarkasByPassPasif.BorderRadius = 0;
            this.btnKarkasByPassPasif.ButtonText = "Karkas Pasif";
            this.btnKarkasByPassPasif.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKarkasByPassPasif.Iconcolor = System.Drawing.Color.Transparent;
            this.btnKarkasByPassPasif.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnKarkasByPassPasif.Iconimage")));
            this.btnKarkasByPassPasif.Iconimage_right = null;
            this.btnKarkasByPassPasif.Iconimage_right_Selected = null;
            this.btnKarkasByPassPasif.Iconimage_Selected = null;
            this.btnKarkasByPassPasif.IconZoom = 90D;
            this.btnKarkasByPassPasif.IsTab = false;
            this.btnKarkasByPassPasif.Location = new System.Drawing.Point(540, 5);
            this.btnKarkasByPassPasif.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKarkasByPassPasif.Name = "btnKarkasByPassPasif";
            this.btnKarkasByPassPasif.Normalcolor = System.Drawing.Color.Maroon;
            this.btnKarkasByPassPasif.OnHovercolor = System.Drawing.Color.Maroon;
            this.btnKarkasByPassPasif.OnHoverTextColor = System.Drawing.Color.White;
            this.btnKarkasByPassPasif.selected = false;
            this.btnKarkasByPassPasif.Size = new System.Drawing.Size(127, 31);
            this.btnKarkasByPassPasif.TabIndex = 137;
            this.btnKarkasByPassPasif.Textcolor = System.Drawing.Color.White;
            this.btnKarkasByPassPasif.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnKilitAcik
            // 
            this.btnKilitAcik.Activecolor = System.Drawing.Color.Empty;
            this.btnKilitAcik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnKilitAcik.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKilitAcik.BorderRadius = 0;
            this.btnKilitAcik.ButtonText = "Kilit Açık";
            this.btnKilitAcik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKilitAcik.Iconcolor = System.Drawing.Color.Transparent;
            this.btnKilitAcik.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnKilitAcik.Iconimage")));
            this.btnKilitAcik.Iconimage_right = null;
            this.btnKilitAcik.Iconimage_right_Selected = null;
            this.btnKilitAcik.Iconimage_Selected = null;
            this.btnKilitAcik.IconZoom = 90D;
            this.btnKilitAcik.IsTab = false;
            this.btnKilitAcik.Location = new System.Drawing.Point(407, 4);
            this.btnKilitAcik.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKilitAcik.Name = "btnKilitAcik";
            this.btnKilitAcik.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnKilitAcik.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnKilitAcik.OnHoverTextColor = System.Drawing.Color.White;
            this.btnKilitAcik.selected = false;
            this.btnKilitAcik.Size = new System.Drawing.Size(127, 31);
            this.btnKilitAcik.TabIndex = 134;
            this.btnKilitAcik.Textcolor = System.Drawing.Color.White;
            this.btnKilitAcik.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnKilitKapali
            // 
            this.btnKilitKapali.Activecolor = System.Drawing.Color.Empty;
            this.btnKilitKapali.BackColor = System.Drawing.Color.Maroon;
            this.btnKilitKapali.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKilitKapali.BorderRadius = 0;
            this.btnKilitKapali.ButtonText = "Kilit Kapalı";
            this.btnKilitKapali.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKilitKapali.Iconcolor = System.Drawing.Color.Transparent;
            this.btnKilitKapali.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnKilitKapali.Iconimage")));
            this.btnKilitKapali.Iconimage_right = null;
            this.btnKilitKapali.Iconimage_right_Selected = null;
            this.btnKilitKapali.Iconimage_Selected = null;
            this.btnKilitKapali.IconZoom = 90D;
            this.btnKilitKapali.IsTab = false;
            this.btnKilitKapali.Location = new System.Drawing.Point(407, 4);
            this.btnKilitKapali.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKilitKapali.Name = "btnKilitKapali";
            this.btnKilitKapali.Normalcolor = System.Drawing.Color.Maroon;
            this.btnKilitKapali.OnHovercolor = System.Drawing.Color.Maroon;
            this.btnKilitKapali.OnHoverTextColor = System.Drawing.Color.White;
            this.btnKilitKapali.selected = false;
            this.btnKilitKapali.Size = new System.Drawing.Size(127, 31);
            this.btnKilitKapali.TabIndex = 135;
            this.btnKilitKapali.Textcolor = System.Drawing.Color.White;
            this.btnKilitKapali.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblIsikBaglantiAciklama
            // 
            this.lblIsikBaglantiAciklama.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIsikBaglantiAciklama.AutoSize = true;
            this.lblIsikBaglantiAciklama.Location = new System.Drawing.Point(681, 20);
            this.lblIsikBaglantiAciklama.Name = "lblIsikBaglantiAciklama";
            this.lblIsikBaglantiAciklama.Size = new System.Drawing.Size(61, 13);
            this.lblIsikBaglantiAciklama.TabIndex = 131;
            this.lblIsikBaglantiAciklama.Text = "IsikBaglanti";
            // 
            // btnKilitMekanizmasıHazir
            // 
            this.btnKilitMekanizmasıHazir.Activecolor = System.Drawing.Color.Empty;
            this.btnKilitMekanizmasıHazir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnKilitMekanizmasıHazir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKilitMekanizmasıHazir.BorderRadius = 0;
            this.btnKilitMekanizmasıHazir.ButtonText = "Kilit Hazır";
            this.btnKilitMekanizmasıHazir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKilitMekanizmasıHazir.Iconcolor = System.Drawing.Color.Transparent;
            this.btnKilitMekanizmasıHazir.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnKilitMekanizmasıHazir.Iconimage")));
            this.btnKilitMekanizmasıHazir.Iconimage_right = null;
            this.btnKilitMekanizmasıHazir.Iconimage_right_Selected = null;
            this.btnKilitMekanizmasıHazir.Iconimage_Selected = null;
            this.btnKilitMekanizmasıHazir.IconZoom = 90D;
            this.btnKilitMekanizmasıHazir.IsTab = false;
            this.btnKilitMekanizmasıHazir.Location = new System.Drawing.Point(274, 3);
            this.btnKilitMekanizmasıHazir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKilitMekanizmasıHazir.Name = "btnKilitMekanizmasıHazir";
            this.btnKilitMekanizmasıHazir.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnKilitMekanizmasıHazir.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnKilitMekanizmasıHazir.OnHoverTextColor = System.Drawing.Color.White;
            this.btnKilitMekanizmasıHazir.selected = false;
            this.btnKilitMekanizmasıHazir.Size = new System.Drawing.Size(127, 31);
            this.btnKilitMekanizmasıHazir.TabIndex = 132;
            this.btnKilitMekanizmasıHazir.Textcolor = System.Drawing.Color.White;
            this.btnKilitMekanizmasıHazir.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnIsiklarHazir
            // 
            this.btnIsiklarHazir.Activecolor = System.Drawing.Color.Empty;
            this.btnIsiklarHazir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnIsiklarHazir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIsiklarHazir.BorderRadius = 0;
            this.btnIsiklarHazir.ButtonText = "Işıklar Hazır";
            this.btnIsiklarHazir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIsiklarHazir.Iconcolor = System.Drawing.Color.Transparent;
            this.btnIsiklarHazir.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnIsiklarHazir.Iconimage")));
            this.btnIsiklarHazir.Iconimage_right = null;
            this.btnIsiklarHazir.Iconimage_right_Selected = null;
            this.btnIsiklarHazir.Iconimage_Selected = null;
            this.btnIsiklarHazir.IconZoom = 90D;
            this.btnIsiklarHazir.IsTab = false;
            this.btnIsiklarHazir.Location = new System.Drawing.Point(141, 4);
            this.btnIsiklarHazir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIsiklarHazir.Name = "btnIsiklarHazir";
            this.btnIsiklarHazir.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnIsiklarHazir.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnIsiklarHazir.OnHoverTextColor = System.Drawing.Color.White;
            this.btnIsiklarHazir.selected = false;
            this.btnIsiklarHazir.Size = new System.Drawing.Size(127, 31);
            this.btnIsiklarHazir.TabIndex = 125;
            this.btnIsiklarHazir.Textcolor = System.Drawing.Color.White;
            this.btnIsiklarHazir.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnServerHazir
            // 
            this.btnServerHazir.Activecolor = System.Drawing.Color.Empty;
            this.btnServerHazir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnServerHazir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnServerHazir.BorderRadius = 0;
            this.btnServerHazir.ButtonText = "Server Hazır";
            this.btnServerHazir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServerHazir.Iconcolor = System.Drawing.Color.Transparent;
            this.btnServerHazir.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnServerHazir.Iconimage")));
            this.btnServerHazir.Iconimage_right = null;
            this.btnServerHazir.Iconimage_right_Selected = null;
            this.btnServerHazir.Iconimage_Selected = null;
            this.btnServerHazir.IconZoom = 90D;
            this.btnServerHazir.IsTab = false;
            this.btnServerHazir.Location = new System.Drawing.Point(8, 4);
            this.btnServerHazir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnServerHazir.Name = "btnServerHazir";
            this.btnServerHazir.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnServerHazir.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnServerHazir.OnHoverTextColor = System.Drawing.Color.White;
            this.btnServerHazir.selected = false;
            this.btnServerHazir.Size = new System.Drawing.Size(127, 31);
            this.btnServerHazir.TabIndex = 123;
            this.btnServerHazir.Textcolor = System.Drawing.Color.White;
            this.btnServerHazir.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnServerHazirDegil
            // 
            this.btnServerHazirDegil.Activecolor = System.Drawing.Color.Empty;
            this.btnServerHazirDegil.BackColor = System.Drawing.Color.Maroon;
            this.btnServerHazirDegil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnServerHazirDegil.BorderRadius = 0;
            this.btnServerHazirDegil.ButtonText = "Server Hazır Değil";
            this.btnServerHazirDegil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServerHazirDegil.Iconcolor = System.Drawing.Color.Transparent;
            this.btnServerHazirDegil.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnServerHazirDegil.Iconimage")));
            this.btnServerHazirDegil.Iconimage_right = null;
            this.btnServerHazirDegil.Iconimage_right_Selected = null;
            this.btnServerHazirDegil.Iconimage_Selected = null;
            this.btnServerHazirDegil.IconZoom = 90D;
            this.btnServerHazirDegil.IsTab = false;
            this.btnServerHazirDegil.Location = new System.Drawing.Point(8, 3);
            this.btnServerHazirDegil.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnServerHazirDegil.Name = "btnServerHazirDegil";
            this.btnServerHazirDegil.Normalcolor = System.Drawing.Color.Maroon;
            this.btnServerHazirDegil.OnHovercolor = System.Drawing.Color.Maroon;
            this.btnServerHazirDegil.OnHoverTextColor = System.Drawing.Color.White;
            this.btnServerHazirDegil.selected = false;
            this.btnServerHazirDegil.Size = new System.Drawing.Size(127, 31);
            this.btnServerHazirDegil.TabIndex = 124;
            this.btnServerHazirDegil.Textcolor = System.Drawing.Color.White;
            this.btnServerHazirDegil.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnIsiklarHazirDegil
            // 
            this.btnIsiklarHazirDegil.Activecolor = System.Drawing.Color.Empty;
            this.btnIsiklarHazirDegil.BackColor = System.Drawing.Color.Maroon;
            this.btnIsiklarHazirDegil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIsiklarHazirDegil.BorderRadius = 0;
            this.btnIsiklarHazirDegil.ButtonText = "Işıklar Hazır Değil";
            this.btnIsiklarHazirDegil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIsiklarHazirDegil.Iconcolor = System.Drawing.Color.Transparent;
            this.btnIsiklarHazirDegil.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnIsiklarHazirDegil.Iconimage")));
            this.btnIsiklarHazirDegil.Iconimage_right = null;
            this.btnIsiklarHazirDegil.Iconimage_right_Selected = null;
            this.btnIsiklarHazirDegil.Iconimage_Selected = null;
            this.btnIsiklarHazirDegil.IconZoom = 90D;
            this.btnIsiklarHazirDegil.IsTab = false;
            this.btnIsiklarHazirDegil.Location = new System.Drawing.Point(141, 4);
            this.btnIsiklarHazirDegil.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIsiklarHazirDegil.Name = "btnIsiklarHazirDegil";
            this.btnIsiklarHazirDegil.Normalcolor = System.Drawing.Color.Maroon;
            this.btnIsiklarHazirDegil.OnHovercolor = System.Drawing.Color.Maroon;
            this.btnIsiklarHazirDegil.OnHoverTextColor = System.Drawing.Color.White;
            this.btnIsiklarHazirDegil.selected = false;
            this.btnIsiklarHazirDegil.Size = new System.Drawing.Size(127, 31);
            this.btnIsiklarHazirDegil.TabIndex = 126;
            this.btnIsiklarHazirDegil.Textcolor = System.Drawing.Color.White;
            this.btnIsiklarHazirDegil.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnKilitMekanizmasıHazirDegil
            // 
            this.btnKilitMekanizmasıHazirDegil.Activecolor = System.Drawing.Color.Empty;
            this.btnKilitMekanizmasıHazirDegil.BackColor = System.Drawing.Color.Maroon;
            this.btnKilitMekanizmasıHazirDegil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKilitMekanizmasıHazirDegil.BorderRadius = 0;
            this.btnKilitMekanizmasıHazirDegil.ButtonText = "Kilit Hazır Değil";
            this.btnKilitMekanizmasıHazirDegil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKilitMekanizmasıHazirDegil.Iconcolor = System.Drawing.Color.Transparent;
            this.btnKilitMekanizmasıHazirDegil.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnKilitMekanizmasıHazirDegil.Iconimage")));
            this.btnKilitMekanizmasıHazirDegil.Iconimage_right = null;
            this.btnKilitMekanizmasıHazirDegil.Iconimage_right_Selected = null;
            this.btnKilitMekanizmasıHazirDegil.Iconimage_Selected = null;
            this.btnKilitMekanizmasıHazirDegil.IconZoom = 90D;
            this.btnKilitMekanizmasıHazirDegil.IsTab = false;
            this.btnKilitMekanizmasıHazirDegil.Location = new System.Drawing.Point(274, 4);
            this.btnKilitMekanizmasıHazirDegil.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKilitMekanizmasıHazirDegil.Name = "btnKilitMekanizmasıHazirDegil";
            this.btnKilitMekanizmasıHazirDegil.Normalcolor = System.Drawing.Color.Maroon;
            this.btnKilitMekanizmasıHazirDegil.OnHovercolor = System.Drawing.Color.Maroon;
            this.btnKilitMekanizmasıHazirDegil.OnHoverTextColor = System.Drawing.Color.White;
            this.btnKilitMekanizmasıHazirDegil.selected = false;
            this.btnKilitMekanizmasıHazirDegil.Size = new System.Drawing.Size(127, 31);
            this.btnKilitMekanizmasıHazirDegil.TabIndex = 132;
            this.btnKilitMekanizmasıHazirDegil.Textcolor = System.Drawing.Color.White;
            this.btnKilitMekanizmasıHazirDegil.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // saat
            // 
            this.saat.Enabled = true;
            this.saat.Interval = 1000;
            this.saat.Tick += new System.EventHandler(this.saat_Tick);
            // 
            // connection
            // 
            this.connection.Enabled = true;
            this.connection.Interval = 1000;
            this.connection.Tick += new System.EventHandler(this.modbus_Tick);
            // 
            // stepMotor
            // 
            this.stepMotor.Enabled = true;
            this.stepMotor.Interval = 1000;
            this.stepMotor.Tick += new System.EventHandler(this.stepMotorRead_Tick);
            // 
            // buzzer
            // 
            this.buzzer.Interval = 300;
            this.buzzer.Tick += new System.EventHandler(this.buzzer_Tick);
            // 
            // pnlNumarator
            // 
            this.pnlNumarator.Controls.Add(this.btnDollyNoGir);
            this.pnlNumarator.Controls.Add(this.btn0);
            this.pnlNumarator.Controls.Add(this.btn9);
            this.pnlNumarator.Controls.Add(this.btn8);
            this.pnlNumarator.Controls.Add(this.btn6);
            this.pnlNumarator.Controls.Add(this.btn5);
            this.pnlNumarator.Controls.Add(this.btnTemizle);
            this.pnlNumarator.Controls.Add(this.btn7);
            this.pnlNumarator.Controls.Add(this.btn3);
            this.pnlNumarator.Controls.Add(this.btn4);
            this.pnlNumarator.Controls.Add(this.btn2);
            this.pnlNumarator.Controls.Add(this.btn1);
            this.pnlNumarator.Controls.Add(this.btnNumaratorKapat);
            this.pnlNumarator.Location = new System.Drawing.Point(141, 151);
            this.pnlNumarator.Name = "pnlNumarator";
            this.pnlNumarator.Size = new System.Drawing.Size(261, 307);
            this.pnlNumarator.TabIndex = 209;
            this.pnlNumarator.Visible = false;
            // 
            // btnDollyNoGir
            // 
            this.btnDollyNoGir.BackColor = System.Drawing.Color.Green;
            this.btnDollyNoGir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDollyNoGir.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDollyNoGir.ForeColor = System.Drawing.Color.Transparent;
            this.btnDollyNoGir.Location = new System.Drawing.Point(21, 248);
            this.btnDollyNoGir.Name = "btnDollyNoGir";
            this.btnDollyNoGir.Size = new System.Drawing.Size(210, 39);
            this.btnDollyNoGir.TabIndex = 135;
            this.btnDollyNoGir.Text = "Dolly No Gir.";
            this.btnDollyNoGir.UseVisualStyleBackColor = false;
            this.btnDollyNoGir.Click += new System.EventHandler(this.btnDollyNoGir_Click);
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.Red;
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn0.ForeColor = System.Drawing.Color.White;
            this.btn0.Location = new System.Drawing.Point(21, 201);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(66, 39);
            this.btn0.TabIndex = 124;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.Red;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn9.ForeColor = System.Drawing.Color.White;
            this.btn9.Location = new System.Drawing.Point(165, 157);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(66, 39);
            this.btn9.TabIndex = 125;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.Red;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn8.ForeColor = System.Drawing.Color.White;
            this.btn8.Location = new System.Drawing.Point(93, 157);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(66, 39);
            this.btn8.TabIndex = 126;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.Red;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn6.ForeColor = System.Drawing.Color.White;
            this.btn6.Location = new System.Drawing.Point(165, 112);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(66, 39);
            this.btn6.TabIndex = 127;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.Red;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn5.ForeColor = System.Drawing.Color.White;
            this.btn5.Location = new System.Drawing.Point(93, 112);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(66, 39);
            this.btn5.TabIndex = 128;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.Navy;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Location = new System.Drawing.Point(93, 202);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(138, 39);
            this.btnTemizle.TabIndex = 129;
            this.btnTemizle.Text = "Sil";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.Red;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn7.ForeColor = System.Drawing.Color.White;
            this.btn7.Location = new System.Drawing.Point(21, 157);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(66, 39);
            this.btn7.TabIndex = 130;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.Red;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn3.ForeColor = System.Drawing.Color.White;
            this.btn3.Location = new System.Drawing.Point(165, 67);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(66, 39);
            this.btn3.TabIndex = 131;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.Red;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn4.ForeColor = System.Drawing.Color.White;
            this.btn4.Location = new System.Drawing.Point(21, 112);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(66, 39);
            this.btn4.TabIndex = 132;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.Red;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn2.ForeColor = System.Drawing.Color.White;
            this.btn2.Location = new System.Drawing.Point(93, 67);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(66, 39);
            this.btn2.TabIndex = 133;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.Red;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn1.ForeColor = System.Drawing.Color.White;
            this.btn1.Location = new System.Drawing.Point(21, 67);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(66, 39);
            this.btn1.TabIndex = 134;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            // 
            // btnNumaratorKapat
            // 
            this.btnNumaratorKapat.AccessibleDescription = "";
            this.btnNumaratorKapat.AccessibleName = "";
            this.btnNumaratorKapat.BackColor = System.Drawing.Color.Transparent;
            this.btnNumaratorKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNumaratorKapat.ErrorImage = null;
            this.btnNumaratorKapat.Image = ((System.Drawing.Image)(resources.GetObject("btnNumaratorKapat.Image")));
            this.btnNumaratorKapat.ImageActive = null;
            this.btnNumaratorKapat.Location = new System.Drawing.Point(197, 20);
            this.btnNumaratorKapat.Name = "btnNumaratorKapat";
            this.btnNumaratorKapat.Size = new System.Drawing.Size(41, 38);
            this.btnNumaratorKapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNumaratorKapat.TabIndex = 123;
            this.btnNumaratorKapat.TabStop = false;
            this.btnNumaratorKapat.Tag = "";
            this.btnNumaratorKapat.Zoom = 10;
            this.btnNumaratorKapat.Click += new System.EventHandler(this.btnNumaratorKapat_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1293, 715);
            this.Controls.Add(this.pnlNumarator);
            this.Controls.Add(this.pnlAltBaslik);
            this.Controls.Add(this.pnlBilgi);
            this.Controls.Add(this.pnlAltBilgi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlBilgi.ResumeLayout(false);
            this.pnlBilgi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAnaSayfa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAltSekme)).EndInit();
            this.pnlAltBaslik.ResumeLayout(false);
            this.pnlAltBaslik.PerformLayout();
            this.pnlAltBilgi.ResumeLayout(false);
            this.pnlAltBilgi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnKlavye)).EndInit();
            this.pnlNumarator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnNumaratorKapat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBilgi;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton btnInfo;
        private Bunifu.Framework.UI.BunifuImageButton btnExit;
        private Bunifu.Framework.UI.BunifuImageButton btnAltSekme;
        private Bunifu.Framework.UI.BunifuCustomLabel lblSaat;
        private Bunifu.Framework.UI.BunifuFlatButton btnServerHazir;
        private Bunifu.Framework.UI.BunifuFlatButton btnIsiklarHazir;
        private System.Windows.Forms.Panel pnlAltBaslik;
        private Bunifu.Framework.UI.BunifuCustomLabel lblUstBilgi;
        private System.Windows.Forms.Panel pnlAltBilgi;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel12;
        private Bunifu.Framework.UI.BunifuFlatButton btnServerHazirDegil;
        private System.Windows.Forms.Timer saat;
        public System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Timer connection;
        private System.Windows.Forms.Label lblIsikBaglantiAciklama;
        public Bunifu.Framework.UI.BunifuCustomLabel lblBarkod;
        private Bunifu.Framework.UI.BunifuFlatButton btnKilitMekanizmasıHazir;
        private Bunifu.Framework.UI.BunifuFlatButton btnKilitMekanizmasıHazirDegil;
        private Bunifu.Framework.UI.BunifuFlatButton btnIsiklarHazirDegil;
        private System.Windows.Forms.Timer stepMotor;
        private Bunifu.Framework.UI.BunifuFlatButton btnKilitAcik;
        private Bunifu.Framework.UI.BunifuFlatButton btnKilitKapali;
        private Bunifu.Framework.UI.BunifuFlatButton btnKarkasByPassAktif;
        private Bunifu.Framework.UI.BunifuFlatButton btnKarkasByPassPasif;
        private System.Windows.Forms.Label lblNowDeviceID;
        private System.Windows.Forms.Timer buzzer;
        private System.Windows.Forms.Label lblModbusRTUBilgi;
        private System.Windows.Forms.Button btnHata;
        private Bunifu.Framework.UI.BunifuImageButton btnAnaSayfa;
        private Bunifu.Framework.UI.BunifuImageButton btnKlavye;
        private System.Windows.Forms.Panel pnlNumarator;
        private System.Windows.Forms.Button btnDollyNoGir;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private Bunifu.Framework.UI.BunifuImageButton btnNumaratorKapat;
    }
}

