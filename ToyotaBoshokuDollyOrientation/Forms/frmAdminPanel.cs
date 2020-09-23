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
    public partial class frmAdminPanel : Form
    {
        public frmAdminPanel()
        {
            InitializeComponent();
        }

        private void btnLastTBTNOWrite_Click(object sender, EventArgs e)
        {
            TBTGALC_DOOR tbtdoor = new TBTGALC_DOOR();
            string sTBTNO = txtLastTBTNO.Text;
            if (string.IsNullOrEmpty( sTBTNO) )
            {
                cGenel.genelUyari("Değeri girdiğinizden emin olunuz.!", false);
                return;
            }
            else
            {
                if (cGenel.MAKINE_ADI==cGenel.MAKINE_ADI_LH)
                {
                    tbtdoor.TBTGalcLastTBTNO_Write_LH(Convert.ToInt32(sTBTNO));
                }
                else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
                {
                    tbtdoor.TBTGalcLastTBTNO_Write_RH(Convert.ToInt32(sTBTNO));
                }
            }
        }

        private void btnAtananBarkodlariIPTALET_Click(object sender, EventArgs e)
        {
      
            barkodIslem barkodIPTAL = new barkodIslem();
            dataGrid.DataSource = null;
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                barkodIPTAL.urunBarkodlariDurumIPTAL_LH();
                dataGrid.DataSource = barkodIPTAL.barkodlariListele_LH();
       
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                barkodIPTAL.urunBarkodlariDurumIPTAL_RH();
                dataGrid.DataSource = barkodIPTAL.barkodlariListele_RH();
            }

            if (dataGrid.RowCount>0)
            {
                dataGrid.FirstDisplayedScrollingRowIndex = dataGrid.RowCount - 1;
                dataGrid[0, dataGrid.RowCount - 1].Selected = true;
            }
        }

        private void btnDollyGorevBitir_Click(object sender, EventArgs e)
        {
            KarkasIslem dollyIPTAL = new KarkasIslem();
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                dollyIPTAL.gorevDurumIPTALTamamlandi_LH();
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                dollyIPTAL.gorevDurumIPTALTamamlandi_RH();
            }
        }

        private void rbButunBarkodlar_Click(object sender, EventArgs e)
        {
            barkodIslem islem = new barkodIslem();
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
              dataGrid.DataSource=  islem.barkodlariListele_LH();
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                dataGrid.DataSource = islem.barkodlariListele_RH();
            }
       

            if (dataGrid.RowCount > 0)
            {
                dataGrid.FirstDisplayedScrollingRowIndex = dataGrid.RowCount - 1;
                dataGrid[0, dataGrid.RowCount - 1].Selected = true;
            }
        }

        private void rbIslemYapilanBarkodlar_Click(object sender, EventArgs e)
        {
            barkodIslem islem = new barkodIslem();
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                dataGrid.DataSource = islem.barkodlariListele_LH("FRL_STATUS=2 OR RRL_STATUS=2");
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                dataGrid.DataSource = islem.barkodlariListele_RH("FRR_STATUS=2 OR RRR_STATUS=2");
            }
   

            if (dataGrid.RowCount > 0)
            {
                dataGrid.FirstDisplayedScrollingRowIndex = dataGrid.RowCount - 1;
                dataGrid[0, dataGrid.RowCount - 1].Selected = true;
            }
        }

        private void rbIslemYapilmayanBarkodlar_Click(object sender, EventArgs e)
        {
            barkodIslem islem = new barkodIslem();
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                dataGrid.DataSource = islem.barkodlariListele_LH("FRL_STATUS=0 OR FRL_STATUS=1 OR RRL_STATUS=0 OR RRL_STATUS=1");
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                dataGrid.DataSource = islem.barkodlariListele_RH("FRR_STATUS=0 OR FRR_STATUS=1 OR RRR_STATUS=0 OR RRR_STATUS=1");
            }
            if (dataGrid.RowCount > 0)
            {
                dataGrid.FirstDisplayedScrollingRowIndex = dataGrid.RowCount - 1;
                dataGrid[0, dataGrid.RowCount - 1].Selected = true;
            }
        }

        private void btnSonTBTOku_Click(object sender, EventArgs e)
        {
            TBTGALC_DOOR tbtdoor = new TBTGALC_DOOR();
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
             txtLastTBTNO.Text=   tbtdoor.TBTGalcLastTBTNO_Read_LH().ToString();
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                txtLastTBTNO.Text = tbtdoor.TBTGalcLastTBTNO_Read_RH().ToString();
            }
        }

        private void rbButunBarkodlar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmAnasayfa);
        }

        private void btnBarkodAta_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.setlemeDongusu();
            barkodIslem islem = new barkodIslem();
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                dataGrid.DataSource = islem.barkodlariListele_LH();
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                dataGrid.DataSource = islem.barkodlariListele_RH();
            }


            if (dataGrid.RowCount > 0)
            {
                dataGrid.FirstDisplayedScrollingRowIndex = dataGrid.RowCount - 1;
                dataGrid[0, dataGrid.RowCount - 1].Selected = true;
            }
        }
    }
}
