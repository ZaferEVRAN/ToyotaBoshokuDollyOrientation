namespace ToyotaBoshokuDollyOrientation
{
    partial class frmStepMotorParametreBakim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStepMotorParametreBakim));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTutmaTork = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIvme = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTork = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHiz = new System.Windows.Forms.NumericUpDown();
            this.btnDefaultWrite = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOncekiSayfa = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnKlavye = new Bunifu.Framework.UI.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutmaTork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIvme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOncekiSayfa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKlavye)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 0;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label8.Location = new System.Drawing.Point(372, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(536, 182);
            this.label8.TabIndex = 32;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label7.Location = new System.Drawing.Point(372, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(643, 78);
            this.label7.TabIndex = 31;
            this.label7.Text = "Hareket ivmelenme katsayısı. Hızlanma ve yavaşlama için aynı\r\n değer kullanılır. " +
    "Saniyedeki devir/dakika cinsinden hız değişimdir.\r\n(dev/dak)/saniye.\r\n";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label6.Location = new System.Drawing.Point(363, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(507, 52);
            this.label6.TabIndex = 30;
            this.label6.Text = "Motor faz akımı. 0 ile 1000 arasında oransal sayıdır.\r\n0 : 0 Amper, 1000 = 7.5 Am" +
    "per(peak)";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label5.Location = new System.Drawing.Point(363, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(450, 52);
            this.label5.TabIndex = 29;
            this.label5.Text = "motor hızı. (devir/dakika)*10  \r\nÖrnek: 155.6 devir/dakika 1556 olarak okunur\r\n";
            // 
            // txtTutmaTork
            // 
            this.txtTutmaTork.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTutmaTork.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtTutmaTork.Location = new System.Drawing.Point(246, 312);
            this.txtTutmaTork.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtTutmaTork.Name = "txtTutmaTork";
            this.txtTutmaTork.Size = new System.Drawing.Size(120, 38);
            this.txtTutmaTork.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label4.Location = new System.Drawing.Point(48, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 37);
            this.label4.TabIndex = 27;
            this.label4.Text = "Tutma Tork:";
            // 
            // txtIvme
            // 
            this.txtIvme.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIvme.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtIvme.Location = new System.Drawing.Point(246, 215);
            this.txtIvme.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtIvme.Name = "txtIvme";
            this.txtIvme.Size = new System.Drawing.Size(120, 38);
            this.txtIvme.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label3.Location = new System.Drawing.Point(147, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 37);
            this.label3.TabIndex = 25;
            this.label3.Text = "İvme:";
            // 
            // txtTork
            // 
            this.txtTork.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTork.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtTork.Location = new System.Drawing.Point(246, 141);
            this.txtTork.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtTork.Name = "txtTork";
            this.txtTork.Size = new System.Drawing.Size(120, 38);
            this.txtTork.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label2.Location = new System.Drawing.Point(140, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 37);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tork:";
            // 
            // txtHiz
            // 
            this.txtHiz.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtHiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtHiz.Location = new System.Drawing.Point(246, 62);
            this.txtHiz.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtHiz.Name = "txtHiz";
            this.txtHiz.Size = new System.Drawing.Size(120, 38);
            this.txtHiz.TabIndex = 22;
            // 
            // btnDefaultWrite
            // 
            this.btnDefaultWrite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDefaultWrite.FlatAppearance.BorderSize = 3;
            this.btnDefaultWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefaultWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefaultWrite.Location = new System.Drawing.Point(230, 365);
            this.btnDefaultWrite.Name = "btnDefaultWrite";
            this.btnDefaultWrite.Size = new System.Drawing.Size(130, 140);
            this.btnDefaultWrite.TabIndex = 21;
            this.btnDefaultWrite.Text = "Değerleri Default Yaz";
            this.btnDefaultWrite.UseVisualStyleBackColor = true;
            this.btnDefaultWrite.Click += new System.EventHandler(this.btnDefaultWrite_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWrite.FlatAppearance.BorderSize = 3;
            this.btnWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWrite.Location = new System.Drawing.Point(55, 437);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(164, 68);
            this.btnWrite.TabIndex = 20;
            this.btnWrite.Text = "Değerleri Yaz";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnRead
            // 
            this.btnRead.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRead.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRead.FlatAppearance.BorderSize = 3;
            this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Location = new System.Drawing.Point(55, 365);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(164, 69);
            this.btnRead.TabIndex = 19;
            this.btnRead.Text = "Değerleri Oku";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label1.Location = new System.Drawing.Point(155, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 37);
            this.label1.TabIndex = 18;
            this.label1.Text = "Hız:";
            // 
            // btnOncekiSayfa
            // 
            this.btnOncekiSayfa.AccessibleDescription = "";
            this.btnOncekiSayfa.AccessibleName = "";
            this.btnOncekiSayfa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOncekiSayfa.BackColor = System.Drawing.Color.Transparent;
            this.btnOncekiSayfa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOncekiSayfa.ErrorImage = null;
            this.btnOncekiSayfa.Image = ((System.Drawing.Image)(resources.GetObject("btnOncekiSayfa.Image")));
            this.btnOncekiSayfa.ImageActive = null;
            this.btnOncekiSayfa.Location = new System.Drawing.Point(926, 472);
            this.btnOncekiSayfa.Name = "btnOncekiSayfa";
            this.btnOncekiSayfa.Size = new System.Drawing.Size(102, 67);
            this.btnOncekiSayfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnOncekiSayfa.TabIndex = 66;
            this.btnOncekiSayfa.TabStop = false;
            this.btnOncekiSayfa.Tag = "";
            this.btnOncekiSayfa.Zoom = 10;
            this.btnOncekiSayfa.Click += new System.EventHandler(this.btnOncekiSayfa_Click);
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuCustomLabel10.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.bunifuCustomLabel10.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(41, 9);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(932, 46);
            this.bunifuCustomLabel10.TabIndex = 86;
            this.bunifuCustomLabel10.Text = "Manual  / Step motor parametre(Kilit Mekanizma)";
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
            this.btnKlavye.Location = new System.Drawing.Point(926, 399);
            this.btnKlavye.Name = "btnKlavye";
            this.btnKlavye.Size = new System.Drawing.Size(102, 67);
            this.btnKlavye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnKlavye.TabIndex = 132;
            this.btnKlavye.TabStop = false;
            this.btnKlavye.Tag = "";
            this.btnKlavye.Zoom = 10;
            this.btnKlavye.Click += new System.EventHandler(this.btnKlavye_Click);
            // 
            // frmStepMotorParametreBakim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1040, 551);
            this.Controls.Add(this.btnKlavye);
            this.Controls.Add(this.bunifuCustomLabel10);
            this.Controls.Add(this.btnOncekiSayfa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTutmaTork);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIvme);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTork);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHiz);
            this.Controls.Add(this.btnDefaultWrite);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStepMotorParametreBakim";
            this.Text = "Step Motor Parametre";
            ((System.ComponentModel.ISupportInitialize)(this.txtTutmaTork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIvme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOncekiSayfa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKlavye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtTutmaTork;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtIvme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtTork;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtHiz;
        private System.Windows.Forms.Button btnDefaultWrite;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuImageButton btnOncekiSayfa;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
        private Bunifu.Framework.UI.BunifuImageButton btnKlavye;
    }
}