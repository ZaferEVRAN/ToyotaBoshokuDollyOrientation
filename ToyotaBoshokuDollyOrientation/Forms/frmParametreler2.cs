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
    public partial class frmParametreler2 : Form
    {
        public frmParametreler2()
        {
            InitializeComponent();
        }
        cParametreler param = new cParametreler();
        private void rbKilitMekanizmasiByPassAktif_Click(object sender, EventArgs e)
        {
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                bool sonuc = param.parametreGuncelle(cParametreler.parametreLHKilitMekanizmasiAktifPasif, "1");
                if (sonuc)
                {
                    cGenel.genelUyari("LH Kilit Mekanizması Aktif", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                bool sonuc = param.parametreGuncelle(cParametreler.parametreRHKilitMekanizmasiAktifPasif, "1");
                if (sonuc)
                {
                    cGenel.genelUyari("RH Kilit Mekanizması Aktif", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
        }

        private void rbKilitMekanizmasiByPassPasif_Click(object sender, EventArgs e)
        {
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                bool sonuc = param.parametreGuncelle(cParametreler.parametreLHKilitMekanizmasiAktifPasif, "0");
                if (sonuc)
                {
                    cGenel.genelUyari("LH Kilit Mekanizması Pasif", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                bool sonuc = param.parametreGuncelle(cParametreler.parametreRHKilitMekanizmasiAktifPasif, "0");
                if (sonuc)
                {
                    cGenel.genelUyari("RH Kilit Mekanizması Pasif", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
        }

        private void rbBuzzerByPassAktif_Click(object sender, EventArgs e)
        {
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                bool sonuc = param.parametreGuncelle(cParametreler.parametreLHBuzzerAktifPasif, "1");
                if (sonuc)
                {
                    cGenel.genelUyari("LH Buzzer Aktif", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                bool sonuc = param.parametreGuncelle(cParametreler.parametreRHBuzzerAktifPasif, "1");
                if (sonuc)
                {
                    cGenel.genelUyari("RH Buzzer Aktif", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
        }

        private void rbBuzzerByPassPasif_Click(object sender, EventArgs e)
        {
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                bool sonuc = param.parametreGuncelle(cParametreler.parametreLHBuzzerAktifPasif, "0");
                if (sonuc)
                {
                    cGenel.genelUyari("LH Buzzer Pasif", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                bool sonuc = param.parametreGuncelle(cParametreler.parametreRHBuzzerAktifPasif, "0");
                if (sonuc)
                {
                    cGenel.genelUyari("RH Buzzer Pasif", false);
                    param.parametreleriAta();
                }
                else
                {
                    cGenel.genelUyari("İşlem başarısız.!", false);
                }
            }
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmParametreler);
        }

        private void frmParametreler2_Load(object sender, EventArgs e)
        {
            formYukleme();
        }
        public void formYukleme()
        {


            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                string value2 = param.parametreAraValue(cParametreler.parametreLHKilitMekanizmasiAktifPasif);
                string value3 = param.parametreAraValue(cParametreler.parametreLHBuzzerAktifPasif);
                if (value2 == "1")
                {
                    rbKilitMekanizmasiByPassAktif.Checked = true;
                    rbKilitMekanizmasiByPassPasif.Checked = false;


                }
                else
                {
                    rbKilitMekanizmasiByPassAktif.Checked = false;
                    rbKilitMekanizmasiByPassPasif.Checked = true;


                }
                if (value3 == "1")
                {
                    rbBuzzerByPassAktif.Checked = true;
                    rbBuzzerByPassPasif.Checked = false;
                }
                else
                {
                    rbBuzzerByPassAktif.Checked = false;
                    rbBuzzerByPassPasif.Checked = true;
                }
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                string value2 = param.parametreAraValue(cParametreler.parametreRHKilitMekanizmasiAktifPasif);
                string value3 = param.parametreAraValue(cParametreler.parametreRHBuzzerAktifPasif);
                if (value2 == "1")
                {
                    rbKilitMekanizmasiByPassAktif.Checked = true;
                    rbKilitMekanizmasiByPassPasif.Checked = false;
                }
                else
                {
                    rbKilitMekanizmasiByPassAktif.Checked = false;
                    rbKilitMekanizmasiByPassPasif.Checked = true;
                }

                if (value3 == "1")
                {
                    rbBuzzerByPassAktif.Checked = true;
                    rbBuzzerByPassPasif.Checked = false;
                }
                else
                {
                    rbBuzzerByPassAktif.Checked = false;
                    rbBuzzerByPassPasif.Checked = true;
                }
            }
        }
    }
}
