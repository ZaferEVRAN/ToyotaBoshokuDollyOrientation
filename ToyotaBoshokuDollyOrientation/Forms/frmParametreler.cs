using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ToyotaBoshokuDollyOrientation
{
    public partial class frmParametreler : Form
    {
        public frmParametreler()
        {
            InitializeComponent();
        }
        cGenel global = new cGenel();
        cParametreler param = new cParametreler();
        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmManual);
        }
       
        private void btnKlavye_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void frmParametreler_Load(object sender, EventArgs e)
        {
           
        }
        public void formYukleme()
        {
            string value= param.parametreAraValue(cParametreler.parametreDublicate);
            if (value=="1")
            {
                rbDublicateIslemAcik.Checked=true;
                rbDublicateIslemKapali.Checked = false;
            }
            else
            {
                rbDublicateIslemAcik.Checked = false;
                rbDublicateIslemKapali.Checked = true;
            }

            if (cGenel.MAKINE_ADI==cGenel.MAKINE_ADI_LH)
            {
                string value2 = param.parametreAraValue(cParametreler.parametreLHKarkasAktifPasif);
                if (value2 == "1")
                {
                    rbKarkasBypassAktif.Checked = true;
                    rbKarkasBypassPasif.Checked = false;
                }
                else
                {
                    rbKarkasBypassAktif.Checked = false;
                    rbKarkasBypassPasif.Checked = true;
                }
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                string value2 = param.parametreAraValue(cParametreler.parametreRHKarkasAktifPasif);
                if (value2 == "1")
                {
                    rbKarkasBypassAktif.Checked = true;
                    rbKarkasBypassPasif.Checked = false;
                }
                else
                {
                    rbKarkasBypassAktif.Checked = false;
                    rbKarkasBypassPasif.Checked = true;
                }
            }

           cbDollyKilitletemeZamanSuresi.SelectedItem= param.parametreAraValue(cParametreler.parametreKilitlemeSuresi);
            cbDollyKilitletemeDenemeSayisi.SelectedItem = param.parametreAraValue(cParametreler.parametreKilitKapatmaDenemeSaiyisi);
            cbDollyKilitletemeZamanAsimi.SelectedItem = param.parametreAraValue(cParametreler.parametreKilitZamanAsimi);
            cbMispickBuzzerSuresi.SelectedItem = param.parametreAraValue(cParametreler.parametreBuzzerSuresi);
        }


        private void rbDublicateIslemAcik_Click(object sender, EventArgs e)
        {
            bool sonuc = param.parametreGuncelle(cParametreler.parametreDublicate, "1");
            if (sonuc)
            {
                cGenel.genelUyari("Dublicate işlem Açık", false);
                param.parametreleriAta();
            }
            else
            {
                cGenel.genelUyari("İşlem başarısız.!", false);
            }
        }

        private void rbDublicateIslemKapali_Click(object sender, EventArgs e)
        {
            bool sonuc = param.parametreGuncelle(cParametreler.parametreDublicate, "0");
            if (sonuc)
            {
                cGenel.genelUyari("Dublicate işlem Kapalı", false);
                param.parametreleriAta();
            }
            else
            {
                cGenel.genelUyari("İşlem başarısız.!", false);
            }
        }
        error_log log = new error_log();
        private void rbKarkasBypassAktif_Click(object sender, EventArgs e)
        {
            bool sonuc=false;
            if (cGenel.MAKINE_ADI==cGenel.MAKINE_ADI_LH)
            {
                sonuc = param.parametreGuncelle(cParametreler.parametreLHKarkasAktifPasif, "1");
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                sonuc = param.parametreGuncelle(cParametreler.parametreRHKarkasAktifPasif, "1");
            }
            if (sonuc)
            {
                cGenel.genelUyari("Karkas By-Pass Aktif", false);
                log.error_log_kayit("Karkas By-Pass Aktif");
                param.parametreleriAta();
            }
            else
            {
                cGenel.genelUyari("İşlem başarısız.!", false);
            }
        }

        private void rbKarkasBypassPasif_Click(object sender, EventArgs e)
        {
            bool sonuc = false;
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                sonuc = param.parametreGuncelle(cParametreler.parametreLHKarkasAktifPasif, "0");
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                sonuc = param.parametreGuncelle(cParametreler.parametreRHKarkasAktifPasif, "0");
            }
            if (sonuc)
            {
                cGenel.genelUyari("Karkas By-Pass Pasif", false);
                log.error_log_kayit("Karkas By-Pass Pasif");
                param.parametreleriAta();
            }
            else
            {
                cGenel.genelUyari("İşlem başarısız.!", false);
            }
        }

        private void btnDollyKilitlemeZamanSuresiGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                bool sonuc = false;
                string value = cbDollyKilitletemeZamanSuresi.SelectedItem.ToString();
                sonuc = param.parametreGuncelle(cParametreler.parametreKilitlemeSuresi, value);

                if (sonuc)
                {
                    cGenel.genelUyari("Dolly kilitleme zaman süresi güncellendi.", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
            catch
            {
                cGenel.genelUyari("Süre seçimi yapınız.!", false);
            }
            
        }

        private void btnDollyKilitlemeDenemeSayisiGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                bool sonuc = false;
                string value = cbDollyKilitletemeDenemeSayisi.SelectedItem.ToString();
                sonuc = param.parametreGuncelle(cParametreler.parametreKilitKapatmaDenemeSaiyisi, value);

                if (sonuc)
                {
                    cGenel.genelUyari("Dolly kilitleme deneme sayısı güncellendi.", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
            catch
            {
                cGenel.genelUyari("Seçim yapınız.!", false);
            }

        }

        private void btnDollyKilitlemeZamanAsimiGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                bool sonuc = false;
                string value = cbDollyKilitletemeZamanAsimi.SelectedItem.ToString();
                sonuc = param.parametreGuncelle(cParametreler.parametreKilitZamanAsimi, value);

                if (sonuc)
                {
                    cGenel.genelUyari("Dolly kilitleme zaman aşımı güncellendi.", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
            catch
            {
                cGenel.genelUyari("Süre seçimi yapınız.!", false);
            }
        }

        private void btnBuzzerMispickSuresiGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                bool sonuc = false;
                string value = cbMispickBuzzerSuresi.SelectedItem.ToString();
                sonuc = param.parametreGuncelle(cParametreler.parametreBuzzerSuresi, value);

                if (sonuc)
                {
                    cGenel.genelUyari("Buzzer zaman süresi güncellendi.", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
            catch
            {
                cGenel.genelUyari("Süre seçimi yapınız.!", false);
            }
        }

        private void btnDollyKilitlemeZamanSuresiDefault_Click(object sender, EventArgs e)
        {

           bool sonuc = param.parametreDefaultGuncelle(cParametreler.parametreKilitlemeSuresi);

            if (sonuc)
            {
                cGenel.genelUyari("Dolly kilitleme zaman süresi default güncellendi.", false);
                param.parametreleriAta();
            }
            else
            {
                cGenel.genelUyari("İşlem başarısız.!", false);
            }
        }

        private void btnDollyKilitlemeDenemeSayisiDefaault_Click(object sender, EventArgs e)
        {
            bool sonuc = false;

            sonuc = param.parametreDefaultGuncelle(cParametreler.parametreKilitKapatmaDenemeSaiyisi);

            if (sonuc)
            {
                cGenel.genelUyari("Dolly kilitleme deneme sayısı default güncellendi.", false);
                param.parametreleriAta();
            }
            else
            {
                cGenel.genelUyari("İşlem başarısız.!", false);
            }
        }

        private void btnDollyKilitlemeZamanAsimiDefault_Click(object sender, EventArgs e)
        {
            bool sonuc = false;

            sonuc = param.parametreDefaultGuncelle(cParametreler.parametreKilitZamanAsimi);

            if (sonuc)
            {
                cGenel.genelUyari("Dolly kilitleme zaman aşımı default güncellendi.", false);
                param.parametreleriAta();
            }
            else
            {
                cGenel.genelUyari("İşlem başarısız.!", false);
            }
        }

        private void btnBuzzerMispickSuresiDefault_Click(object sender, EventArgs e)
        {
            bool sonuc = false;

            sonuc = param.parametreDefaultGuncelle(cParametreler.parametreBuzzerSuresi);

            if (sonuc)
            {
                cGenel.genelUyari("Buzzer zaman süresi güncellendi.", false);
                param.parametreleriAta();
            }
            else
            {
                cGenel.genelUyari("İşlem başarısız.!", false);
            }
        }

        private void btnDollyKilitlemeZamanSuresiInfo_Click(object sender, EventArgs e)
        {
            cGenel.genelUyari("Dolly barkod okutulduktan sonra kilit mekanizmasının çalışmaya başlama süresi", false);
        }

        private void btnDollyKilitlemeDenemeSayisiInfo_Click(object sender, EventArgs e)
        {
            cGenel.genelUyari("Dolly barkod okutulduktan sonra kilit mekanizmasının kapanamaması durumunda girilen değer kadar mekanizmayı kapatmaya denemesi", false);
        }

        private void btnDollyKilitlemeZamanAsimiInfo_Click(object sender, EventArgs e)
        {
            cGenel.genelUyari("Dolly barkod okutulduktan sonra kilit mekanizmasının sensörleri görmez ise alarma geçme süresi", false);

        }

        private void btnBuzzerMispickSuresiInfo_Click(object sender, EventArgs e)
        {
            cGenel.genelUyari("Barkod okutulduğunda Dolly'nin yanlış gözüne bırakılması sonucu buzzerın alarm verme süresi", false);

        }

        private void rbDublicateIslemAcik_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSonrakiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmParametreler2);
        }

        private void rbDublicateIslemKapali_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbKarkasBypassPasif_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
