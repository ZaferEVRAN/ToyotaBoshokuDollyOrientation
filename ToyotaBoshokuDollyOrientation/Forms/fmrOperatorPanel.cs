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
    public partial class fmrOperatorPanel : Form
    {
        public fmrOperatorPanel()
        {
            InitializeComponent();
        }
        barkodIslem barkod = new barkodIslem();
        TBTGALC_DOOR baslat = new TBTGALC_DOOR();
        KarkasIslem dollyIPTAL = new KarkasIslem();
        private void btnBaslat_Click(object sender, EventArgs e)
        {


            try
            {
                float telemail = Convert.ToInt16(txtTelemailNo.Text);
                float TBTNO = baslat.TelemailIleTBTNOBul(telemail);

                if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
                {
                    baslat.TBTGalcLastTBTNO_Write_LH(TBTNO);
                    barkod.urunBarkodlariDurumIPTAL_LH();
                    dollyIPTAL.gorevDurumIPTALTamamlandi_LH();

                }
                else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
                {
                    baslat.TBTGalcLastTBTNO_Write_RH(TBTNO);
                    barkod.urunBarkodlariDurumIPTAL_RH();
                    dollyIPTAL.gorevDurumIPTALTamamlandi_RH();
                }
                cGenel.frmMain.setlemeDongusu();

                islemYapilamayanBarkodlar();


                cGenel.genelUyari("Dolly setlemeye başlayabilirsiniz!", false);
            }
            catch (Exception)
            {
                cGenel.genelUyari("Telemail numarasını 0 ile 999 arasında sayı giriniz.", false);
            }
            txtTelemailNo.Clear();
        }

        private void btnAtananBarkodlariIPTALET_Click(object sender, EventArgs e)
        {

        }

        private void btnNumaratorKapat_Click(object sender, EventArgs e)
        {
            pnlNumarator.Visible = false;
        }

        private void txtTelemailNo_Click(object sender, EventArgs e)
        {
            //pnlNumarator.Visible = true;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtTelemailNo.Clear();
        }

        private void fmrOperatorPanel_Load(object sender, EventArgs e)
        {
            btn1.Click += new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);
        }
        private void islem(Object sender, EventArgs e)
        {

            klavyeOlustur(sender, e, txtTelemailNo);

        }

        private void klavyeOlustur(Object sender, EventArgs e, TextBox txt)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            switch (btn.Name)
            {
                case "btn1":
                    txt.Text += (1).ToString();
                    break;
                case "btn2":
                    txt.Text += (2).ToString();
                    break;
                case "btn3":
                    txt.Text += (3).ToString();
                    break;
                case "btn4":
                    txt.Text += (4).ToString();
                    break;
                case "btn5":
                    txt.Text += (5).ToString();
                    break;
                case "btn6":
                    txt.Text += (6).ToString();
                    break;
                case "btn7":
                    txt.Text += (7).ToString();
                    break;
                case "btn8":
                    txt.Text += (8).ToString();
                    break;
                case "btn9":
                    txt.Text += (9).ToString();
                    break;
                case "btn0":
                    txt.Text += (0).ToString();
                    break;


                default:
                    break;
            }
        }

        private void rbButunBarkodlar_Click(object sender, EventArgs e)
        {
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
            islemYapilamayanBarkodlar();
        }
        private void islemYapilamayanBarkodlar()
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
        private void rbIslemYapilmayanBarkodlar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmAnasayfa);
        }

        private void btnBarkodKlavye_Click(object sender, EventArgs e)
        {
            pnlNumarator.Visible = true;
        }

       
        private void focus_Tick(object sender, EventArgs e)
        {
            


         }
    }
}
