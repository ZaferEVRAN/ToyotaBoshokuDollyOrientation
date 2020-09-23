namespace ToyotaBoshokuDollyOrientation.Forms
{
    partial class fmrOperatorPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmrOperatorPanel));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rbIslemYapilmayanBarkodlar = new System.Windows.Forms.RadioButton();
            this.rbButunBarkodlar = new System.Windows.Forms.RadioButton();
            this.rbIslemYapilanBarkodlar = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnBarkodAta = new System.Windows.Forms.Button();
            this.btnSonTBTOku = new System.Windows.Forms.Button();
            this.btnAtananBarkodlariIPTALET = new System.Windows.Forms.Button();
            this.btnDollyGorevBitir = new System.Windows.Forms.Button();
            this.btnLastTBTNOWrite = new System.Windows.Forms.Button();
            this.txtLastTBTNO = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dataGrid = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.btnGeri = new Bunifu.Framework.UI.BunifuImageButton();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGeri)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(0, 165);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(32, 510);
            this.groupBox4.TabIndex = 231;
            this.groupBox4.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(4, 80);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1470, 35);
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
            this.groupBox3.Size = new System.Drawing.Size(1640, 129);
            this.groupBox3.TabIndex = 216;
            this.groupBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 675);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1648, 129);
            this.groupBox2.TabIndex = 230;
            this.groupBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(1648, 165);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(32, 639);
            this.groupBox5.TabIndex = 232;
            this.groupBox5.TabStop = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 0;
            this.bunifuElipse1.TargetControl = this;
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
            // 
            // btnDollyGorevBitir
            // 
            this.btnDollyGorevBitir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDollyGorevBitir.Location = new System.Drawing.Point(1522, 88);
            this.btnDollyGorevBitir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDollyGorevBitir.Name = "btnDollyGorevBitir";
            this.btnDollyGorevBitir.Size = new System.Drawing.Size(148, 65);
            this.btnDollyGorevBitir.TabIndex = 87;
            this.btnDollyGorevBitir.Text = "DOLLY GÖREV BİTİR";
            this.btnDollyGorevBitir.UseVisualStyleBackColor = true;
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
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1680, 165);
            this.groupBox1.TabIndex = 229;
            this.groupBox1.TabStop = false;
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuCustomLabel10.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.bunifuCustomLabel10.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(601, 0);
            this.bunifuCustomLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(448, 69);
            this.bunifuCustomLabel10.TabIndex = 84;
            this.bunifuCustomLabel10.Text = "Operatör Panel";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowCustomTheming = false;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.EnableHeadersVisualStyles = false;
            this.dataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.dataGrid.HeaderBackColor = System.Drawing.Color.DarkSlateGray;
            this.dataGrid.HeaderBgColor = System.Drawing.Color.Empty;
            this.dataGrid.HeaderForeColor = System.Drawing.Color.White;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGrid.RowTemplate.Height = 40;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.ShowCellErrors = false;
            this.dataGrid.ShowCellToolTips = false;
            this.dataGrid.ShowEditingIcon = false;
            this.dataGrid.ShowRowErrors = false;
            this.dataGrid.Size = new System.Drawing.Size(1680, 804);
            this.dataGrid.StandardTab = true;
            this.dataGrid.TabIndex = 233;
            this.dataGrid.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.DarkSlateGray;
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
            this.btnGeri.Location = new System.Drawing.Point(1483, 17);
            this.btnGeri.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(153, 103);
            this.btnGeri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnGeri.TabIndex = 106;
            this.btnGeri.TabStop = false;
            this.btnGeri.Tag = "";
            this.btnGeri.Zoom = 10;
            // 
            // fmrOperatorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1680, 804);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmrOperatorPanel";
            this.Text = "fmrOperatorPanel";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGeri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton rbIslemYapilmayanBarkodlar;
        private System.Windows.Forms.RadioButton rbButunBarkodlar;
        private Bunifu.Framework.UI.BunifuImageButton btnGeri;
        private System.Windows.Forms.RadioButton rbIslemYapilanBarkodlar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBarkodAta;
        private System.Windows.Forms.Button btnSonTBTOku;
        private System.Windows.Forms.Button btnAtananBarkodlariIPTALET;
        private System.Windows.Forms.Button btnDollyGorevBitir;
        private System.Windows.Forms.Button btnLastTBTNOWrite;
        private System.Windows.Forms.TextBox txtLastTBTNO;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
        private Bunifu.UI.WinForms.BunifuDataGridView dataGrid;
    }
}