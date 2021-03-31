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
    public partial class frmPickToLight : Form
    {
        public frmPickToLight()
        {
            InitializeComponent();
        }
        KarkasIslem karkasIslem = new KarkasIslem();
        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmAnasayfa);
        }

        delegate void delDurumIzleme();

        public void DurumIzleme()
        {
            this.BeginInvoke(new delDurumIzleme(durumIzleme), new object[] { });
        }
        List<uint> list;

        private void durumIzleme()
        {

            list = new List<uint>();
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                list = karkasIslem.dollyPickToLightIzleme_LH();
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                list = karkasIslem.dollyPickToLightIzleme_RH();
            }

            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    if ((item.Name.Substring(0, 16) == "btnLHPickToLight") && list.Count > 0)
                    {
                        int i = (int.Parse)(item.Name.Substring(16));
                        durumIzlemeButonRenk(item, list[i - 31]);

                    }
                    else if ((item.Name.Substring(0, 16) == "btnLHPickToLight"))
                    {
                        item.BackColor = Color.White;
                    }
                }
            }


        }

        private void durumIzlemeButonRenk(Control btn, uint barkodDurum)
        {
            if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumYok)
            {
                btn.BackColor = Color.White;

            }
            else if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde)
            {
                btn.BackColor = Color.Green;

            }
            else if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework)
            {
                btn.BackColor = Color.Yellow;

            }

        }

        private void bunifuCustomLabel39_Click(object sender, EventArgs e)
        {

        }

        private void frmPickToLight_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton43_Click(object sender, EventArgs e)
        {

        }

        private void btnDollyIslemBitir_Click(object sender, EventArgs e)
        {
            log logOlustur = new log();
            // cGenel.lockOnClick = true;
            // step.kilitMekanizmaDongusu();
            KarkasIslem karkasIslem = new KarkasIslem();
            barkodIslem urunBarkod = new barkodIslem();
            if (karkasIslem.gorevDurumIslemYokveyaYapiliyorDollyLH()._ID > 0)
            {
                if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
                {
                    urunBarkod.urunBarkodStatusUpdate_FR_LH_98();
                    urunBarkod.urunBarkodStatusUpdate_RR_LH_98();
                    karkasIslem = karkasIslem.karkasDollyNoGetir_LH();
                    logOlustur.logDollyNoGuncelle(karkasIslem._DOLLYNO, karkasIslem._ID);
                    karkasIslem.gorevDurumTamamlandi_LH();
                    cGenel.frmMain.setlemeDongusu();
                    cLambaKontrol lamba = new cLambaKontrol();
                    lamba.lambaDurumDollyBaslangic();
                    cGenel.genelUyari("Dolly işlem bitirildi yeni dolly setlendi.!", false);
                }
            }
            else
            {
                cGenel.genelUyari("Dolly'de işlem bulunmamaktadır. Operatör ", false);
            }
            if (karkasIslem.gorevDurumIslemYokveyaYapiliyorDollyLH()._ID > 0)
            {
                if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
                {
                    urunBarkod.urunBarkodStatusUpdate_FR_RH_98();
                    urunBarkod.urunBarkodStatusUpdate_RR_RH_98();
                    karkasIslem = karkasIslem.karkasDollyNoGetir_RH();
                    logOlustur.logDollyNoGuncelle(karkasIslem._DOLLYNO, karkasIslem._ID);
                    karkasIslem.gorevDurumTamamlandi_RH();
                    cGenel.frmMain.setlemeDongusu();
                    cLambaKontrol lamba = new cLambaKontrol();
                    lamba.lambaDurumDollyBaslangic();
                    cGenel.genelUyari("Dolly işlem bitirildi yeni dolly setlendi.!", false);
                }
            }
            else
            {
                cGenel.genelUyari("Dolly'de işlem bulunmamaktadır. Operatör ", false);
            }
            cGenel.frmPickToLight.DurumIzleme();

        }
    }
}

