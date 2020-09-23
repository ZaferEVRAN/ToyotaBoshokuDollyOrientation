using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToyotaBoshokuDollyOrientation
{
    public partial class frmRHManual : Form
    {
        public frmRHManual()
        {
            InitializeComponent();
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmAnasayfa);
        }

        private void btnRHManualLamba_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmRHManualLamba);
        }

        private void btnRHParametreler_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmRHParametreler);
        }

        private void btnRHYeniBarkodTanimla_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmRHYeniBarkodTanimla);
        }

        private void btnRHYeniDollyTanimla_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmRHYeniDollyTanımla);
        }

        private void btnRHKullaniciSayfasi_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmRHKullaniciSayfasi);
        }
    }
}
