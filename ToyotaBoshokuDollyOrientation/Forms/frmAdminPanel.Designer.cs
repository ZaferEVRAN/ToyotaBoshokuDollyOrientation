namespace ToyotaBoshokuDollyOrientation.Forms
{
    partial class frmAdminPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminPanel));
            this.dataGrid = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSonTBTOku = new System.Windows.Forms.Button();
            this.btnAtananBarkodlariIPTALET = new System.Windows.Forms.Button();
            this.btnDollyGorevBitir = new System.Windows.Forms.Button();
            this.btnLastTBTNOWrite = new System.Windows.Forms.Button();
            this.txtLastTBTNO = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rbIslemYapilmayanBarkodlar = new System.Windows.Forms.RadioButton();
            this.rbButunBarkodlar = new System.Windows.Forms.RadioButton();
            this.btnGeri = new Bunifu.Framework.UI.BunifuImageButton();
            this.rbIslemYapilanBarkodlar = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBarkodAta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGeri)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowCustomTheming = false;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGrid.ColumnHeadersHeight = 40;
            this.dataGrid.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.dataGrid.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataGrid.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGrid.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.dataGrid.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGrid.CurrentTheme.BackColor = System.Drawing.Color.DarkSlateGray;
            this.dataGrid.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.dataGrid.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.dataGrid.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dataGrid.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGrid.CurrentTheme.Name = null;
            this.dataGrid.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dataGrid.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataGrid.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGrid.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.dataGrid.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.EnableHeadersVisualStyles = false;
            this.dataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.dataGrid.HeaderBackColor = System.Drawing.Color.DarkSlateGray;
            this.dataGrid.HeaderBgColor = System.Drawing.Color.Empty;
            this.dataGrid.HeaderForeColor = System.Drawing.Color.White;
            this.dataGrid.Location = new System.Drawing.Point(32, 165);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGrid.RowTemplate.Height = 40;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.ShowCellErrors = false;
            this.dataGrid.ShowCellToolTips = false;
            this.dataGrid.ShowEditingIcon = false;
            this.dataGrid.ShowRowErrors = false;
            this.dataGrid.Size = new System.Drawing.Size(1638, 566);
            this.dataGrid.StandardTab = true;
            this.dataGrid.TabIndex = 228;
            this.dataGrid.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.DarkSlateGray;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox1.Controls.Add(this.btnBarkodAta);
            this.groupBox1.Controls.Add(this.btnSonTBTOku);
            this.groupBox1.Controls.Add(this.btnAtananBarkodlariIPTALET);
            this.groupBox1.Controls.Add(this.btnDollyGorevBitir);
            this.groupBox1.Controls.Add(this.btnLastTBTNOWrite);
            this.groupBox1.Controls.Add(this.txtLastTBTNO);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel10);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(32, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1638, 165);
            this.groupBox1.TabIndex = 224;
            this.groupBox1.TabStop = false;
            // 
            // btnSonTBTOku
            // 
            this.btnSonTBTOku.Location = new System.Drawing.Point(282, 75);
            this.btnSonTBTOku.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSonTBTOku.Name = "btnSonTBTOku";
            this.btnSonTBTOku.Size = new System.Drawing.Size(140, 65);
            this.btnSonTBTOku.TabIndex = 92;
            this.btnSonTBTOku.Text = "SON TBTNO OKU";
            this.btnSonTBTOku.UseVisualStyleBackColor = true;
            this.btnSonTBTOku.Click += new System.EventHandler(this.btnSonTBTOku_Click);
            // 
            // btnAtananBarkodlariIPTALET
            // 
            this.btnAtananBarkodlariIPTALET.Location = new System.Drawing.Point(579, 75);
            this.btnAtananBarkodlariIPTALET.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAtananBarkodlariIPTALET.Name = "btnAtananBarkodlariIPTALET";
            this.btnAtananBarkodlariIPTALET.Size = new System.Drawing.Size(206, 65);
            this.btnAtananBarkodlariIPTALET.TabIndex = 91;
            this.btnAtananBarkodlariIPTALET.Text = "ATANAN BARKODLARI IPTAL ET";
            this.btnAtananBarkodlariIPTALET.UseVisualStyleBackColor = true;
            this.btnAtananBarkodlariIPTALET.Click += new System.EventHandler(this.btnAtananBarkodlariIPTALET_Click);
            // 
            // btnDollyGorevBitir
            // 
            this.btnDollyGorevBitir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDollyGorevBitir.Location = new System.Drawing.Point(1480, 88);
            this.btnDollyGorevBitir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDollyGorevBitir.Name = "btnDollyGorevBitir";
            this.btnDollyGorevBitir.Size = new System.Drawing.Size(148, 65);
            this.btnDollyGorevBitir.TabIndex = 87;
            this.btnDollyGorevBitir.Text = "DOLLY GÖREV BİTİR";
            this.btnDollyGorevBitir.UseVisualStyleBackColor = true;
            this.btnDollyGorevBitir.Click += new System.EventHandler(this.btnDollyGorevBitir_Click);
            // 
            // btnLastTBTNOWrite
            // 
            this.btnLastTBTNOWrite.Location = new System.Drawing.Point(430, 75);
            this.btnLastTBTNOWrite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLastTBTNOWrite.Name = "btnLastTBTNOWrite";
            this.btnLastTBTNOWrite.Size = new System.Drawing.Size(140, 65);
            this.btnLastTBTNOWrite.TabIndex = 86;
            this.btnLastTBTNOWrite.Text = "SON TBTNO YAZ";
            this.btnLastTBTNOWrite.UseVisualStyleBackColor = true;
            this.btnLastTBTNOWrite.Click += new System.EventHandler(this.btnLastTBTNOWrite_Click);
            // 
            // txtLastTBTNO
            // 
            this.txtLastTBTNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastTBTNO.Location = new System.Drawing.Point(9, 75);
            this.txtLastTBTNO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLastTBTNO.Multiline = true;
            this.txtLastTBTNO.Name = "txtLastTBTNO";
            this.txtLastTBTNO.Size = new System.Drawing.Size(260, 62);
            this.txtLastTBTNO.TabIndex = 85;
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuCustomLabel10.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.bunifuCustomLabel10.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(643, 0);
            this.bunifuCustomLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(378, 69);
            this.bunifuCustomLabel10.TabIndex = 84;
            this.bunifuCustomLabel10.Text = "Admin Panel";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 0;
            this.bunifuElipse1.TargetControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(32, 731);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1638, 129);
            this.groupBox2.TabIndex = 225;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.rbIslemYapilmayanBarkodlar);
            this.groupBox3.Controls.Add(this.rbButunBarkodlar);
            this.groupBox3.Controls.Add(this.btnGeri);
            this.groupBox3.Controls.Add(this.rbIslemYapilanBarkodlar);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(4, -5);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(1630, 129);
            this.groupBox3.TabIndex = 216;
            this.groupBox3.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(4, 80);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1460, 35);
            this.progressBar1.TabIndex = 108;
            // 
            // rbIslemYapilmayanBarkodlar
            // 
            this.rbIslemYapilmayanBarkodlar.AutoSize = true;
            this.rbIslemYapilmayanBarkodlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIslemYapilmayanBarkodlar.Location = new System.Drawing.Point(764, 26);
            this.rbIslemYapilmayanBarkodlar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbIslemYapilmayanBarkodlar.Name = "rbIslemYapilmayanBarkodlar";
            this.rbIslemYapilmayanBarkodlar.Size = new System.Drawing.Size(431, 41);
            this.rbIslemYapilmayanBarkodlar.TabIndex = 89;
            this.rbIslemYapilmayanBarkodlar.TabStop = true;
            this.rbIslemYapilmayanBarkodlar.Text = "İşlem yapılmayan barkodlar";
            this.rbIslemYapilmayanBarkodlar.UseVisualStyleBackColor = true;
            this.rbIslemYapilmayanBarkodlar.Click += new System.EventHandler(this.rbIslemYapilmayanBarkodlar_Click);
            // 
            // rbButunBarkodlar
            // 
            this.rbButunBarkodlar.AutoSize = true;
            this.rbButunBarkodlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbButunBarkodlar.Location = new System.Drawing.Point(9, 26);
            this.rbButunBarkodlar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbButunBarkodlar.Name = "rbButunBarkodlar";
            this.rbButunBarkodlar.Size = new System.Drawing.Size(267, 41);
            this.rbButunBarkodlar.TabIndex = 90;
            this.rbButunBarkodlar.TabStop = true;
            this.rbButunBarkodlar.Text = "bütün barkodlar";
            this.rbButunBarkodlar.UseVisualStyleBackColor = true;
            this.rbButunBarkodlar.CheckedChanged += new System.EventHandler(this.rbButunBarkodlar_CheckedChanged);
            this.rbButunBarkodlar.Click += new System.EventHandler(this.rbButunBarkodlar_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.AccessibleDescription = "";
            this.btnGeri.AccessibleName = "";
            this.btnGeri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeri.BackColor = System.Drawing.Color.Transparent;
            this.btnGeri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeri.ErrorImage = null;
            this.btnGeri.Image = ((System.Drawing.Image)(resources.GetObject("btnGeri.Image")));
            this.btnGeri.ImageActive = null;
            this.btnGeri.Location = new System.Drawing.Point(1473, 17);
            this.btnGeri.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(153, 103);
            this.btnGeri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnGeri.TabIndex = 106;
            this.btnGeri.TabStop = false;
            this.btnGeri.Tag = "";
            this.btnGeri.Zoom = 10;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // rbIslemYapilanBarkodlar
            // 
            this.rbIslemYapilanBarkodlar.AutoSize = true;
            this.rbIslemYapilanBarkodlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIslemYapilanBarkodlar.Location = new System.Drawing.Point(330, 29);
            this.rbIslemYapilanBarkodlar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbIslemYapilanBarkodlar.Name = "rbIslemYapilanBarkodlar";
            this.rbIslemYapilanBarkodlar.Size = new System.Drawing.Size(371, 41);
            this.rbIslemYapilanBarkodlar.TabIndex = 88;
            this.rbIslemYapilanBarkodlar.TabStop = true;
            this.rbIslemYapilanBarkodlar.Text = "İşlem yapılan barkodlar";
            this.rbIslemYapilanBarkodlar.UseVisualStyleBackColor = true;
            this.rbIslemYapilanBarkodlar.Click += new System.EventHandler(this.rbIslemYapilanBarkodlar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(1670, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(32, 860);
            this.groupBox5.TabIndex = 227;
            this.groupBox5.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(32, 860);
            this.groupBox4.TabIndex = 226;
            this.groupBox4.TabStop = false;
            // 
            // btnBarkodAta
            // 
            this.btnBarkodAta.Location = new System.Drawing.Point(793, 75);
            this.btnBarkodAta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBarkodAta.Name = "btnBarkodAta";
            this.btnBarkodAta.Size = new System.Drawing.Size(206, 65);
            this.btnBarkodAta.TabIndex = 93;
            this.btnBarkodAta.Text = "BARKOD ATA";
            this.btnBarkodAta.UseVisualStyleBackColor = true;
            this.btnBarkodAta.Click += new System.EventHandler(this.btnBarkodAta_Click);
            // 
            // frmAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1702, 860);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAdminPanel";
            this.Text = "frmAdminPanel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGeri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuDataGridView dataGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Bunifu.Framework.UI.BunifuImageButton btnGeri;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLastTBTNOWrite;
        private System.Windows.Forms.TextBox txtLastTBTNO;
        private System.Windows.Forms.RadioButton rbIslemYapilanBarkodlar;
        private System.Windows.Forms.RadioButton rbButunBarkodlar;
        private System.Windows.Forms.RadioButton rbIslemYapilmayanBarkodlar;
        private System.Windows.Forms.Button btnAtananBarkodlariIPTALET;
        private System.Windows.Forms.Button btnDollyGorevBitir;
        private System.Windows.Forms.Button btnSonTBTOku;
        private System.Windows.Forms.Button btnBarkodAta;
    }
}