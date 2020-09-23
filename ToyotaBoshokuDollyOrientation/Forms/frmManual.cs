using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modbus.Device;
using System.Net.Sockets;
using System.IO.Ports;

namespace ToyotaBoshokuDollyOrientation
{
    public partial class frmManual : Form
    {
        public frmManual()
        {
            InitializeComponent();
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmAnasayfa);

        }

        private void btnLHManualLamba_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmManualLamba);
            cGenel.frmManualLamba.DurumIzleme();
        }

        private void btnLHParametreler_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmParametreler);
            cGenel.frmParametreler.formYukleme();
        }

        private void btnLHYeniBarkodTanimla_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmYeniBarkodTanimla);
            //cGenel.frmYeniBarkodTanimla.asenkronLoad();
            //cGenel.frmYeniBarkodTanimla.temizle();


        }

        private void btnLHYeniDollyTanimla_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmYeniDollyTanımla);
            cGenel.frmYeniDollyTanımla.dollyList();
        }

        private void btnLHKullaniciSayfasi_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmKullaniciSayfasi);
            cGenel.frmKullaniciSayfasi.dropdownsUpdate();
        }

        private void btnLHDollyKilitAc_Click(object sender, EventArgs e)
        {
            barkodIslem barkod = new barkodIslem();
            cistemciKontrol_StepMotor step = new cistemciKontrol_StepMotor();
            step.kilitMekanizmaSensorOku();
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                uint barkodDurum = barkod.barkod_FRL_RRL_Count();

                if (barkodDurum == 0 && cGenel.motorRun == false && cGenel.stepAlarmVar == false)
                {
                    cGenel.lockOnClick = true;
                    step.kilitMekanizmaDongusu();
                }
                else if (barkod.barkod_FRL_RRL_Count_0() > 0 && cGenel.motorRun == false && cGenel.stepAlarmVar == false)
                {
                    bool sonuc = cGenel.genelUyari("Üretim barkod listenizde işlem görmemiş ürün(ler) var.! Kilidi açmak istiyor musunuz?", true);
                    if (sonuc)
                    {
                        cGenel.lockOnClick = true;
                        step.kilitMekanizmaDongusu();
                    }
                }
                else if (barkod.barkod_FRL_RRL_Count_1() > 0 && cGenel.motorRun == false && cGenel.stepAlarmVar == false)
                {
                    bool sonuc = cGenel.genelUyari("Üretim barkod listenizde rework ürün(ler) var.! Kilit açmanız durumunda Rework işlem(ler)ini manual takip etmek durumundasınız.!", true);
                    if (sonuc)
                    {
                        cGenel.lockOnClick = true;
                        step.kilitMekanizmaDongusu();
                        KarkasIslem karkasIslem = new KarkasIslem();
                        barkodIslem urunBarkod = new barkodIslem();
                        urunBarkod.urunBarkodStatusUpdate_FR_LH_99();
                        urunBarkod.urunBarkodStatusUpdate_RR_LH_99();
                        karkasIslem.gorevDurumTamamlandi_LH();
                        cLambaKontrol lamba = new cLambaKontrol();
                        lamba.lambaDurumDollyBaslangic();
                    }
                }

            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                uint barkodDurum = barkod.barkod_FRR_RRR_Count();

                if (barkodDurum == 0 && cGenel.motorRun == false && cGenel.stepAlarmVar == false)
                {
                    cGenel.lockOnClick = true;
                    step.kilitMekanizmaDongusu();
                }
                else if (barkod.barkod_FRR_RRR_Count_0() > 0 && cGenel.motorRun == false && cGenel.stepAlarmVar == false)
                {
                    bool sonuc = cGenel.genelUyari("Üretim barkod listenizde işlem görmemiş ürün(ler) var.!\n  Kilidi açmak istiyor musunuz?", true);

                    if (sonuc)
                    {
                        cGenel.lockOnClick = true;
                        step.kilitMekanizmaDongusu();
                    }
                }
                else if (barkod.barkod_FRR_RRR_Count_1() > 0 && cGenel.motorRun == false && cGenel.stepAlarmVar == false)
                {
                    bool sonuc = cGenel.genelUyari("Üretim barkod listenizde rework ürün(ler) var.!\nKilit açmanız durumunda Rework işlemlerini manual takip etmek durumundasınız.!", true);
                    if (sonuc)
                    {
                        cGenel.lockOnClick = true;
                        step.kilitMekanizmaDongusu();
                        KarkasIslem karkasIslem = new KarkasIslem();
                        barkodIslem urunBarkod = new barkodIslem();
                        urunBarkod.urunBarkodStatusUpdate_FR_RH_99();
                        urunBarkod.urunBarkodStatusUpdate_RR_RH_99();
                        karkasIslem.gorevDurumTamamlandi_RH();
                        cLambaKontrol lamba = new cLambaKontrol();
                        lamba.lambaDurumDollyBaslangic();
                    }
                }
            }
        }

        private void btnLHDollyKilitKapat_Click(object sender, EventArgs e)
        {
           cistemciKontrol_StepMotor step = new cistemciKontrol_StepMotor();
            step.kilitMekanizmaSensorOku();
            if (cGenel.motorRun == false && cGenel.stepAlarmVar == false)
            {
                if (cGenel.lockOffSensor==true)
                {
                    cGenel.lockOffClick = true;

                    step.kilitMekanizmaDongusu();
                }
            }
        }

        private void btnLHDollyResetle_Click(object sender, EventArgs e)
        {
            cGenel.nowDeviceID = 0;
            cLambaKontrol lambaKontrol = new cLambaKontrol();
            lambaKontrol.lambaDurumDollyBaslangic();
            cGenel.stepAlarmVar = false;
            cGenel.deviceAlarmVar = false;
            cGenel.motorRun = false;
            KarkasIslem.xLOOP = false;
            frmMain.xKontrol = false;
            lambaKontrol.buzzerRing(0);
            cGenel.alarmVar = false;

            //lambaKontrol.yarimKalanIsıklarGoster();


        }
        public static frmPickToLighParameter _frmPickToLighParameter;
        private void btnPictToLightParametreleri_Click(object sender, EventArgs e)
        {

            cGenel.frmMain.ViewForm(cGenel.frmPickToLighParameter);

        }

        private void btnYeniModel_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmModel);
            // cGenel.frmModel.formYukle();
        }

        private void btnStepMotorParametreleri_Click(object sender, EventArgs e)
        {


            cGenel.frmMain.ViewForm(cGenel.frmStepMotorParametreBakim);

        }

        private void btnPickToLightKontol_Click(object sender, EventArgs e)
        {


            cGenel.frmMain.ViewForm(cGenel.frmManualPickToLightKontrol);

            cGenel.frmManualPickToLightKontrol.sensorKontrolDongu.Enabled = true;
        }

        private void btnIsiklariYak_Click(object sender, EventArgs e)
        {
            cLambaKontrol lamba = new cLambaKontrol();
            lamba.yarimKalanIsıklarGoster();
        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {

        }

        private void frmManual_Load(object sender, EventArgs e)
        {
            if (cGenel._OpenSessionGRUPNAME == "MAVI" || cGenel._OpenSessionGRUPNAME == "KIRMIZI" || cGenel._OpenSessionGRUPNAME == "BEYAZ")
            {
                btnLHParametreler.Enabled = false;
                btnLHYeniBarkodTanimla.Enabled = false;
                btnLHYeniDollyTanimla.Enabled = false;
                btnPictToLightParametreleri.Enabled = false;
                btnLHManualLamba.Enabled = false;
                btnStepMotorParametreleri.Enabled = false;
                btnPickToLightKontol.Enabled = false;
                btnYeniModel.Enabled = false;
                btnAdminPanel.Enabled = false;
            }

        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmAdminPanel);

        }

        private void btnUretimKayitlari_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmUretimKaydi);
        }
    }
}
