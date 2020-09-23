using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToyotaBoshokuDollyOrientation.Forms
{
    public partial class frmUretimKaydi : Form
    {
        public frmUretimKaydi()
        {
            InitializeComponent();
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmManual);
        }

        private void frmUretimKaydi_Load(object sender, EventArgs e)
        {
            raporla();
        }
        public void raporla()
        {
            barkodIslem rapor = new barkodIslem();
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                lblTotalOK.Text = rapor.TotalOKCount_LH().ToString();
                lblTotalRework.Text = rapor.TotalREWORKCount_LH().ToString();
                lblManualIslemAdedi.Text = rapor.TotalMANUALCount_LH().ToString();
                lblTotalUretim.Text = rapor.TotalURETIMCount_LH().ToString();
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                lblTotalOK.Text = rapor.TotalOKCount_RH().ToString();
                lblTotalRework.Text = rapor.TotalREWORKCount_RH().ToString();
                lblManualIslemAdedi.Text = rapor.TotalMANUALCount_RH().ToString();
                lblTotalUretim.Text = rapor.TotalURETIMCount_RH().ToString();
            }
        }
    }
}
