﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.IO.Ports;
namespace ToyotaBoshokuDollyOrientation
{
    public partial class frmPopupIslem : Form
    {
        public frmPopupIslem()
        {
            InitializeComponent();
        }
        error_log errorLog = new error_log();
        models model = new models();
        public void sayfaYukle()
        {
            lblTelemail.Text = cGenel.TeleMailSirasi.ToString();

            lblModel.Text = model.speckInfoSearch(cGenel.ModelKodu)._MODELNO;

            lblSpec.Text = cGenel.SpecKodu;


            string barkod = string.Format("XXX{0}{1}", cGenel.ModelKodu, cGenel.TBTDOORSpecKodu);

            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (cGenel.xByPass == true)
            {
                btnOK.Visible = true;
                lblOK.Visible = true;
            }
            else
            {
                btnOK.Visible = false;
                lblOK.Visible = false;
            }
            errorLog.error_log_kayit("Sayfa yükleme yapıldı.");
            pictureBox1.Image = spec.speckInfoSearch(barkod).bitmap;
            errorLog.error_log_kayit("Resim yükleme yapıldı.");

        }
        SPECK_INFO spec = new SPECK_INFO();
        cLambaKontrol lambaKontrol = new cLambaKontrol();
        barkodIslem urunBarkod = new barkodIslem();
        log logOlustur = new log();
        KarkasIslem karkasIslem = new KarkasIslem();
        private void btnOK_Click(object sender, EventArgs e)
        {
            //errorLog.error_log_kayit("OK buton basıldı.");
            globalOK();
            //this.Hide();
            errorLog.error_log_kayit("Dolly ışık blink setlendi.");
            cGenel.frmMain.ViewForm(cGenel.frmPickToLight);
            errorLog.error_log_kayit("Picktolight ekran aktif");
            cGenel.frmPickToLight.DurumIzleme();
            errorLog.error_log_kayit("Picktolight durum izleme fonksiyon çalıştı.");

        }

        public void globalOK()
        {


            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                uint dollyRafSirasi;
                karkasIslem.listBARKOD = karkasIslem.dollyKarkasBarkodSearch_LH();
                // cGenel.urunBarkodKarkasDurum = karkasIslem.listBARKOD.Contains(cGenel.DoorBarcode);
                if (cGenel.urunBarkodKarkasDurum == true)
                {
                    int index = karkasIslem.listBARKOD.FindIndex(s => s == cGenel.DoorBarcode);
                    dollyRafSirasi = karkasIslem.dollyRafSirasiSearch_LH(index);
                    ushort deviceID = lambaKontrol.deviceIDBul_LH(dollyRafSirasi, cGenel.YonBilgisi);

                    cGenel.nowDeviceID = deviceID;//sensör kontrol
                }
                else
                {
                    dollyRafSirasi = urunBarkod.barkodInfoSequence_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi);
                    ushort deviceID = lambaKontrol.deviceIDBul_LH(dollyRafSirasi, cGenel.YonBilgisi);

                    cGenel.nowDeviceID = deviceID;//sensör kontrol
                }


                cGenel.gorevID = karkasIslem.gorevSorgula_LH((byte)gorevDurumlari.gorevIslemYok)._ID;
                if (cGenel.gorevID > 0)
                {
                    karkasIslem.gorevDurumGuncelle_LH(cGenel.gorevID, (byte)gorevDurumlari.gorevYapiliyor);
                }
                if (cGenel.xByPass == false)
                {
                    
                      bool sonuc = lambaKontrol.lambaJobIlgiliIsikFlashYak(cGenel.nowDeviceID);

                      if (sonuc)
                      {
                          errorLog.error_log_kayit("lambaJobIlgiliIsikFlashYak başarılı.");
                        _AREvt.WaitOne(300, true);
                        cLambaKontrol.master.WriteSingleRegister(1, 713, 0);
                        KarkasIslem.xLOOP = true;
                          frmMain.xKontrol = true;
                        
                      }
                      else
                      {
                          cGenel.nowDeviceID = 0;
                          errorLog.error_log_kayit("lambaJobIlgiliIsikFlashYak başarısız.");
                      }
                      

                }
                else if (cGenel.xByPass == true)
                {
                    KarkasIslem karkasIslem = new KarkasIslem();

                    cGenel.gorevID = karkasIslem.gorevSorgula_LH((byte)gorevDurumlari.gorevYapiliyor)._ID;

                    karkasIslem.urunBarkodDurumGuncelle_LH(cGenel.gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);

                    if (cGenel.urunBarkodKarkasDurum == true)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde, cGenel.BarkodID);
                    }
                    else if (cGenel.urunBarkodKarkasDurum == false)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde);
                    }
                    logOlustur.logOlustur(cGenel.BarkodID, cGenel.MAKINE_ADI_LH, cGenel.gorevID, cGenel.DoorBarcode, cGenel.ModelKodu, cGenel.SpecKodu, cGenel.Type, cGenel.Model, KarkasIslem.LHDollyBarkod, dollyRafSirasi.ToString(), cGenel.YonBilgisi, cGenel.SetCount, "OK", cGenel._OpenSessionUSERNAME);

                    uint barkodDurum = urunBarkod.barkod_FRL_RRL_Count();
                    if (barkodDurum == 0)
                    {
                        karkasIslem = karkasIslem.karkasDollyNoGetir_LH();
                        logOlustur.logDollyNoGuncelle(karkasIslem._DOLLYNO, karkasIslem._ID);
                        karkasIslem.gorevDurumTamamlandi_LH();
                        cGenel.frmMain.setlemeDongusu();
                    }
                    cGenel.nowDeviceID = 0;
                }


            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                uint dollyRafSirasi;
                karkasIslem.listBARKOD = karkasIslem.dollyKarkasBarkodSearch_RH();
                //cGenel.urunBarkodKarkasDurum = karkasIslem.listBARKOD.Contains(cGenel.DoorBarcode);
                if (cGenel.urunBarkodKarkasDurum == true)
                {
                    int index = karkasIslem.listBARKOD.FindIndex(s => s == cGenel.DoorBarcode);
                    dollyRafSirasi = karkasIslem.dollyRafSirasiSearch_RH(index);
                    ushort deviceID = lambaKontrol.deviceIDBul_RH(dollyRafSirasi, cGenel.YonBilgisi);

                    cGenel.nowDeviceID = deviceID;//sensör kontrol
                }
                else
                {
                    dollyRafSirasi = urunBarkod.barkodInfoSequence_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi);
                    ushort deviceID = lambaKontrol.deviceIDBul_RH(dollyRafSirasi, cGenel.YonBilgisi);

                    cGenel.nowDeviceID = deviceID;//sensör kontrol
                }


                cGenel.gorevID = karkasIslem.gorevSorgula_RH((byte)gorevDurumlari.gorevIslemYok)._ID;
                if (cGenel.gorevID > 0)
                {
                    karkasIslem.gorevDurumGuncelle_RH(cGenel.gorevID, (byte)gorevDurumlari.gorevYapiliyor);
                }

                if (cGenel.xByPass == false)
                {
                   
                    bool sonuc = lambaKontrol.lambaJobIlgiliIsikFlashYak(cGenel.nowDeviceID);

                    if (sonuc)
                    {
                        errorLog.error_log_kayit("lambaJobIlgiliIsikFlashYak başarılı.");
                        _AREvt.WaitOne(300, true);
                        cLambaKontrol.master.WriteSingleRegister(1, 713, 0);
                        KarkasIslem.xLOOP = true;
                        frmMain.xKontrol = true;

                    }
                    else
                    {
                        cGenel.nowDeviceID = 0;
                        errorLog.error_log_kayit("lambaJobIlgiliIsikFlashYak başarısız.");
                    }

                }
                else if (cGenel.xByPass == true)
                {

                    cGenel.gorevID = karkasIslem.gorevSorgula_RH((byte)gorevDurumlari.gorevYapiliyor)._ID;

                    if (cGenel.urunBarkodKarkasDurum == true)
                    {

                        urunBarkod.urunBarkodIslemTamamlandi_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde, cGenel.BarkodID);
                    }
                    else if (cGenel.urunBarkodKarkasDurum == false)
                    {

                        urunBarkod.urunBarkodIslemTamamlandi_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde);
                    }

                    karkasIslem.urunBarkodDurumGuncelle_RH(cGenel.gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);

                    logOlustur.logOlustur(cGenel.BarkodID, cGenel.MAKINE_ADI_RH, cGenel.gorevID, cGenel.DoorBarcode, cGenel.ModelKodu, cGenel.SpecKodu, cGenel.Type, cGenel.Model, KarkasIslem.RHDollyBarkod, dollyRafSirasi.ToString(), cGenel.YonBilgisi, cGenel.SetCount, "OK", cGenel._OpenSessionUSERNAME);

                    uint barkodDurum = urunBarkod.barkod_FRR_RRR_Count();
                    if (barkodDurum == 0)
                    {
                        karkasIslem = karkasIslem.karkasDollyNoGetir_RH();
                        logOlustur.logDollyNoGuncelle(karkasIslem._DOLLYNO, karkasIslem._ID);
                        karkasIslem.gorevDurumTamamlandi_RH();
                        cGenel.frmMain.setlemeDongusu();
                    }
                    cGenel.nowDeviceID = 0;
                }

            }


        }
        static AutoResetEvent _AREvt;
        private void btnRework_Click(object sender, EventArgs e)
        {
            errorLog.error_log_kayit("rework buton aktif");

            _AREvt = new AutoResetEvent(false);
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                KarkasIslem.xLOOP = false;
                uint dollyRafSirasi;
                karkasIslem.listBARKOD = karkasIslem.dollyKarkasBarkodSearch_LH();
                // cGenel.urunBarkodKarkasDurum = karkasIslem.listBARKOD.Contains(cGenel.DoorBarcode);
                if (cGenel.urunBarkodKarkasDurum == true)
                {
                    int index = karkasIslem.listBARKOD.FindIndex(s => s == cGenel.DoorBarcode);
                    dollyRafSirasi = karkasIslem.dollyRafSirasiSearch_LH(index);
                    ushort deviceID = lambaKontrol.deviceIDBul_LH(dollyRafSirasi, cGenel.YonBilgisi);

                    cGenel.nowDeviceID = deviceID;//sensör kontrol
                }
                else
                {
                    dollyRafSirasi = urunBarkod.barkodInfoSequence_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi);
                    ushort deviceID = lambaKontrol.deviceIDBul_LH(dollyRafSirasi, cGenel.YonBilgisi);

                    cGenel.nowDeviceID = deviceID;//sensör kontrol
                }
                cGenel.gorevID = karkasIslem.gorevSorgula_LH((byte)gorevDurumlari.gorevIslemYok)._ID;

                if (cGenel.gorevID > 0)
                {
                    karkasIslem.gorevDurumGuncelle_LH(cGenel.gorevID, (byte)gorevDurumlari.gorevYapiliyor);

                    karkasIslem.urunBarkodDurumGuncelle_LH(cGenel.gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);

                    if (cGenel.urunBarkodKarkasDurum == true)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.BarkodID);
                    }
                    else if (cGenel.urunBarkodKarkasDurum == false)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework);
                    }

                }
                else
                {
                    cGenel.gorevID = karkasIslem.gorevSorgula_LH((byte)gorevDurumlari.gorevYapiliyor)._ID;
                    karkasIslem.urunBarkodDurumGuncelle_LH(cGenel.gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);
                    if (cGenel.urunBarkodKarkasDurum == true)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.BarkodID);
                    }
                    else if (cGenel.urunBarkodKarkasDurum == false)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework);
                    }

                }
                KarkasIslem.LHDollyBarkod = "999";
                logOlustur.logOlustur(cGenel.BarkodID, cGenel.MAKINE_ADI_LH, cGenel.gorevID, cGenel.DoorBarcode, cGenel.ModelKodu, cGenel.SpecKodu, cGenel.Type, cGenel.Model, KarkasIslem.LHDollyBarkod, dollyRafSirasi.ToString(), cGenel.YonBilgisi, cGenel.SetCount, "REWORK", cGenel._OpenSessionUSERNAME);

            

                if (cGenel.xByPass == false)
                {
                    _AREvt.WaitOne(300, true);
                    bool sonuc2 = lambaKontrol.lambaJobIlgiliIsikSteadyYakSariRework(cGenel.nowDeviceID);
                    if (sonuc2)
                    {
                        errorLog.error_log_kayit("lambaJobIlgiliIsikSteadyYakSariRework başarılı.");

                    }
                    else
                    {
                        errorLog.error_log_kayit("lambaJobIlgiliIsikSteadyYakSariRework başarısız.");

                    }
                }



                cGenel.nowDeviceID = 0;

            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                KarkasIslem.xLOOP = false;
                uint dollyRafSirasi;
                // uint _dollyRafSirasi = urunBarkod.barkodInfoSequence_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi);
                // ushort _deviceID = lambaKontrol.deviceIDBul_RH(_dollyRafSirasi, cGenel.YonBilgisi);
                //ürünün durumu bakılır 
                karkasIslem.listBARKOD = karkasIslem.dollyKarkasBarkodSearch_RH();
                bool urunBarkodDurum = karkasIslem.listBARKOD.Contains(cGenel.DoorBarcode);
                if (urunBarkodDurum == true)
                {
                    int index = karkasIslem.listBARKOD.FindIndex(s => s == cGenel.DoorBarcode);
                    dollyRafSirasi = karkasIslem.dollyRafSirasiSearch_RH(index);
                    ushort deviceID = lambaKontrol.deviceIDBul_RH(dollyRafSirasi, cGenel.YonBilgisi);

                    cGenel.nowDeviceID = deviceID;//sensör kontrol
                }
                else
                {
                    dollyRafSirasi = urunBarkod.barkodInfoSequence_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi);
                    ushort deviceID = lambaKontrol.deviceIDBul_RH(dollyRafSirasi, cGenel.YonBilgisi);

                    cGenel.nowDeviceID = deviceID;//sensör kontrol
                }

                cGenel.gorevID = karkasIslem.gorevSorgula_RH((byte)gorevDurumlari.gorevIslemYok)._ID;

                if (cGenel.gorevID > 0)
                {
                    karkasIslem.gorevDurumGuncelle_RH(cGenel.gorevID, (byte)gorevDurumlari.gorevYapiliyor);

                    karkasIslem.urunBarkodDurumGuncelle_RH(cGenel.gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);

                    if (urunBarkodDurum == true)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.BarkodID);
                    }
                    else if (urunBarkodDurum == false)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework);
                    }
                }
                else
                {
                    cGenel.gorevID = karkasIslem.gorevSorgula_RH((byte)gorevDurumlari.gorevYapiliyor)._ID;
                    karkasIslem.urunBarkodDurumGuncelle_RH(cGenel.gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);
                    if (urunBarkodDurum == true)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.BarkodID);
                    }
                    else if (urunBarkodDurum == false)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework);
                    }

                }
                KarkasIslem.RHDollyBarkod = "999";
                logOlustur.logOlustur(cGenel.BarkodID, cGenel.MAKINE_ADI_RH, cGenel.gorevID, cGenel.DoorBarcode, cGenel.ModelKodu, cGenel.SpecKodu, cGenel.Type, cGenel.Model, KarkasIslem.RHDollyBarkod, dollyRafSirasi.ToString(), cGenel.YonBilgisi, cGenel.SetCount, "REWORK", cGenel._OpenSessionUSERNAME);
         
                if (cGenel.xByPass == false)
                {
                    _AREvt.WaitOne(300, true);
                    bool sonuc2 = lambaKontrol.lambaJobIlgiliIsikSteadyYakSariRework(cGenel.nowDeviceID);
                    if (sonuc2)
                    {
                        errorLog.error_log_kayit("lambaJobIlgiliIsikSteadyYakSariRework başarılı.");
                    }
                    else
                    {
                        errorLog.error_log_kayit("lambaJobIlgiliIsikSteadyYakSariRework başarısız.");
                    }
                }
                cGenel.nowDeviceID = 0;
            }
            errorLog.error_log_kayit("rework adım form gizle");
            this.Hide();
            errorLog.error_log_kayit("rework adım frmPicktolight form aç");
            cGenel.frmMain.ViewForm(cGenel.frmPickToLight);
            errorLog.error_log_kayit("rework adım durum izleme foksiyon başlangıç");
            cGenel.frmPickToLight.DurumIzleme();
            errorLog.error_log_kayit("rework adım durum izleme fonsiyon bitiş");

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            cGenel.frmMain.ViewForm(cGenel.frmPickToLight);
            cGenel.frmPickToLight.DurumIzleme();
        }

        private void frmPopupIslem_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timerGeriSayim_Tick(object sender, EventArgs e)
        {

            try
            {
                lblGeriSayimSayaci.Text = cGenel.geriSayimDegeri.ToString();
                if (cGenel.geriSayimKapi == "front")
                {
                    pBGeriSayim.MaxValue = 45;
                    pBGeriSayim.ProgressColor = Color.PowderBlue;
                    if (cGenel.geriSayimDegeri <= 45 && cGenel.geriSayimDegeri >= 30)
                    {
                        pBGeriSayim.ProgressBackColor = Color.Green;
                    }
                    else if (cGenel.geriSayimDegeri <= 30 && cGenel.geriSayimDegeri >= 15)
                    {
                        pBGeriSayim.ProgressBackColor = Color.Yellow;
                    }
                    else
                    {
                        pBGeriSayim.ProgressBackColor = Color.Red;
                    }
                }
                else if (cGenel.geriSayimKapi == "rear")
                {
                    pBGeriSayim.MaxValue = 30;
                    pBGeriSayim.ProgressColor = Color.PowderBlue;
                    if (cGenel.geriSayimDegeri <= 30 && cGenel.geriSayimDegeri >= 20)
                    {
                        pBGeriSayim.ProgressBackColor = Color.Green;
                    }
                    else if (cGenel.geriSayimDegeri <= 20 && cGenel.geriSayimDegeri >= 10)
                    {
                        pBGeriSayim.ProgressBackColor = Color.Yellow;
                    }
                    else
                    {
                        pBGeriSayim.ProgressBackColor = Color.Red;
                    }
                }
                pBGeriSayim.Value = cGenel.geriSayimDegeri;
                cGenel.geriSayimDegeri = cGenel.geriSayimDegeri - 1;
            }
            catch (Exception)
            {

            }



        }
    }
}
