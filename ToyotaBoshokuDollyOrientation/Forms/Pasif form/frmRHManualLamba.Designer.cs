namespace ToyotaBoshokuDollyOrientation
{
    partial class frmRHManualLamba
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRHManualLamba));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnOncekiSayfa = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnOncekiSayfa)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 0;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btnOncekiSayfa
            // 
            this.btnOncekiSayfa.AccessibleDescription = "";
            this.btnOncekiSayfa.AccessibleName = "";
            this.btnOncekiSayfa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOncekiSayfa.BackColor = System.Drawing.Color.Red;
            this.btnOncekiSayfa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOncekiSayfa.ErrorImage = null;
            this.btnOncekiSayfa.Image = ((System.Drawing.Image)(resources.GetObject("btnOncekiSayfa.Image")));
            this.btnOncekiSayfa.ImageActive = null;
            this.btnOncekiSayfa.Location = new System.Drawing.Point(1252, 689);
            this.btnOncekiSayfa.Name = "btnOncekiSayfa";
            this.btnOncekiSayfa.Size = new System.Drawing.Size(102, 67);
            this.btnOncekiSayfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnOncekiSayfa.TabIndex = 65;
            this.btnOncekiSayfa.TabStop = false;
            this.btnOncekiSayfa.Tag = "";
            this.btnOncekiSayfa.Zoom = 10;
            this.btnOncekiSayfa.Click += new System.EventHandler(this.btnOncekiSayfa_Click);
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuCustomLabel10.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel10.Font = new System.Drawing.Font("Century Gothic", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.bunifuCustomLabel10.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(400, 47);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(486, 32);
            this.bunifuCustomLabel10.TabIndex = 86;
            this.bunifuCustomLabel10.Text = "RH - Line / Manual  / Manual Lamba";
            // 
            // frmRHManualLamba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.bunifuCustomLabel10);
            this.Controls.Add(this.btnOncekiSayfa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRHManualLamba";
            this.Text = "frmRHManualLamba";
            ((System.ComponentModel.ISupportInitialize)(this.btnOncekiSayfa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton btnOncekiSayfa;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
    }
}