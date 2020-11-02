using System;
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
        models model = new models();
        public void sayfaYukle()
        {
            lblTelemail.Text = cGenel.TeleMailSirasi.ToString();
       
            lblModel.Text = model.speckInfoSearch(cGenel.ModelKodu)._MODELNO;
           
            lblSpec.Text = cGenel.SpecKodu;

          
            string barkod = string.Format("XXX{0}{1}", cGenel.ModelKodu, cGenel.TBTDOORSpecKodu);

            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = spec.speckInfoSearch(barkod).bitmap;
        }
          SPECK_INFO spec = new SPECK_INFO();
        cLambaKontrol lambaKontrol = new cLambaKontrol();
        barkodIslem urunBarkod = new barkodIslem();
        log logOlustur = new log();
        KarkasIslem karkasIslem = new KarkasIslem();
        private void btnOK_Click(object sender, EventArgs e)
        {
            globalOK();
        }

        public void globalOK()
        {
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                uint dollyRafSirasi;
                karkasIslem.listBARKOD = karkasIslem.dollyKarkasBarkodSearch_LH();
                cGenel.urunBarkodKarkasDurum = karkasIslem.listBARKOD.Contains(cGenel.DoorBarcode);
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


                uint gorevID = karkasIslem.gorevSorgula_LH((byte)gorevDurumlari.gorevIslemYok)._ID;
                if (gorevID > 0)
                {
                    karkasIslem.gorevDurumGuncelle_LH(gorevID, (byte)gorevDurumlari.gorevYapiliyor);
                }
                if (cGenel.xByPass == false)
                {
                    bool sonuc = lambaKontrol.lambaJobIlgiliIsikFlashYak(cGenel.nowDeviceID);

                    if (sonuc)
                    {
                        KarkasIslem.xLOOP = true;

                        if (cGenel.nowDeviceID==40)
                        {
                            //cGenel.kilitKapatTetik = true;
                        }
                    }

                }
                else if (cGenel.xByPass == true)
                {
                    KarkasIslem karkasIslem = new KarkasIslem();

                    gorevID = karkasIslem.gorevSorgula_LH((byte)gorevDurumlari.gorevYapiliyor)._ID;

                    karkasIslem.urunBarkodDurumGuncelle_LH(gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);

                    if (cGenel.urunBarkodKarkasDurum == true)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde, cGenel.BarkodID);
                    }
                    else if (cGenel.urunBarkodKarkasDurum == false)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde);
                    }
                   // logOlustur.logOlustur(cGenel.BarkodID, cGenel.MAKINE_ADI_LH, gorevID, cGenel.DoorBarcode, cGenel.ModelKodu, cGenel.SpecKodu, cGenel.Type, cGenel.Model, KarkasIslem.LHDollyBarkod, dollyRafSirasi.ToString(), cGenel.YonBilgisi, cGenel.SetCount, "OK", cGenel._OpenSessionUSERNAME);

                    uint barkodDurum = urunBarkod.barkod_FRL_RRL_Count();
                    if (barkodDurum == 0)
                    {

                        karkasIslem.gorevDurumTamamlandi_LH();

                    }
                    cGenel.nowDeviceID = 0;
                }


            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                uint dollyRafSirasi;
                karkasIslem.listBARKOD = karkasIslem.dollyKarkasBarkodSearch_RH();
                cGenel.urunBarkodKarkasDurum = karkasIslem.listBARKOD.Contains(cGenel.DoorBarcode);
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


                uint gorevID = karkasIslem.gorevSorgula_RH((byte)gorevDurumlari.gorevIslemYok)._ID;
                if (gorevID > 0)
                {
                    karkasIslem.gorevDurumGuncelle_RH(gorevID, (byte)gorevDurumlari.gorevYapiliyor);
                }

                if (cGenel.xByPass == false)
                {
                    bool sonuc = lambaKontrol.lambaJobIlgiliIsikFlashYak(cGenel.nowDeviceID);

                    if (sonuc)
                    {
                        KarkasIslem.xLOOP = true;
                        if (cGenel.nowDeviceID==31)
                        {
                          //  cGenel.kilitKapatTetik = true;
                        }
                    }
                }
                else if (cGenel.xByPass == true)
                {

                    gorevID = karkasIslem.gorevSorgula_RH((byte)gorevDurumlari.gorevYapiliyor)._ID;

                    if (cGenel.urunBarkodKarkasDurum == true)
                    {

                        urunBarkod.urunBarkodIslemTamamlandi_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde, cGenel.BarkodID);
                    }
                    else if (cGenel.urunBarkodKarkasDurum == false)
                    {

                        urunBarkod.urunBarkodIslemTamamlandi_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde);
                    }

                    karkasIslem.urunBarkodDurumGuncelle_RH(gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);

                   // logOlustur.logOlustur(cGenel.BarkodID, cGenel.MAKINE_ADI_RH, gorevID, cGenel.DoorBarcode, cGenel.ModelKodu, cGenel.SpecKodu, cGenel.Type, cGenel.Model, KarkasIslem.RHDollyBarkod, dollyRafSirasi.ToString(), cGenel.YonBilgisi, cGenel.SetCount, "OK", cGenel._OpenSessionUSERNAME);

                    uint barkodDurum = urunBarkod.barkod_FRR_RRR_Count();
                    if (barkodDurum == 0)
                    {

                        karkasIslem.gorevDurumTamamlandi_RH();

                    }
                    cGenel.nowDeviceID = 0;
                }

            }
           //this.Hide();
           //cGenel.frmMain.ViewForm(cGenel.frmPickToLight);
           //cGenel.frmPickToLight.DurumIzleme();
           
        }
        static AutoResetEvent _AREvt;
        private void btnRework_Click(object sender, EventArgs e)
        {
            _AREvt = new AutoResetEvent(false);
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
        
                uint dollyRafSirasi;
                karkasIslem.listBARKOD = karkasIslem.dollyKarkasBarkodSearch_LH();
                 cGenel.urunBarkodKarkasDurum = karkasIslem.listBARKOD.Contains(cGenel.DoorBarcode);
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
                uint gorevID = karkasIslem.gorevSorgula_LH((byte)gorevDurumlari.gorevIslemYok)._ID;
           
                if (gorevID > 0)
                {
                    karkasIslem.gorevDurumGuncelle_LH(gorevID, (byte)gorevDurumlari.gorevYapiliyor);

                    karkasIslem.urunBarkodDurumGuncelle_LH(gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.DoorBarcode,cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);

                    if (cGenel.urunBarkodKarkasDurum == true)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework,cGenel.BarkodID);
                    }
                    else if (cGenel.urunBarkodKarkasDurum == false)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework);
                    }
        
                }
                else
                {
                    gorevID = karkasIslem.gorevSorgula_LH((byte)gorevDurumlari.gorevYapiliyor)._ID;
                    karkasIslem.urunBarkodDurumGuncelle_LH(gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);
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
                logOlustur.logOlustur(cGenel.BarkodID, cGenel.MAKINE_ADI_LH, gorevID, cGenel.DoorBarcode, cGenel.ModelKodu, cGenel.SpecKodu, cGenel.Type, cGenel.Model, KarkasIslem.LHDollyBarkod, dollyRafSirasi.ToString(), cGenel.YonBilgisi, cGenel.SetCount, "REWORK", cGenel._OpenSessionUSERNAME);

                KarkasIslem.xLOOP = false;
                _AREvt.WaitOne(300, true);
                bool sonuc2=lambaKontrol.lambaJobIlgiliIsikSteadyYakSariRework(cGenel.nowDeviceID);

        

                cGenel.nowDeviceID = 0;

            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                uint dollyRafSirasi;
                // uint _dollyRafSirasi = urunBarkod.barkodInfoSequence_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi);
                // ushort _deviceID = lambaKontrol.deviceIDBul_RH(_dollyRafSirasi, cGenel.YonBilgisi);
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
 
                uint gorevID = karkasIslem.gorevSorgula_RH((byte)gorevDurumlari.gorevIslemYok)._ID;
             
                if (gorevID > 0)
                {
                     karkasIslem.gorevDurumGuncelle_RH(gorevID, (byte)gorevDurumlari.gorevYapiliyor);
                    
                    karkasIslem.urunBarkodDurumGuncelle_RH(gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);
  
                    if (urunBarkodDurum == true)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework,cGenel.BarkodID);
                    }
                    else if (urunBarkodDurum == false)
                    {
                        urunBarkod.urunBarkodIslemTamamlandi_RH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework);
                    }
                }
                else
                {
                    gorevID = karkasIslem.gorevSorgula_RH((byte)gorevDurumlari.gorevYapiliyor)._ID;
                    karkasIslem.urunBarkodDurumGuncelle_RH(gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);
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
                logOlustur.logOlustur(cGenel.BarkodID, cGenel.MAKINE_ADI_RH, gorevID, cGenel.DoorBarcode, cGenel.ModelKodu, cGenel.SpecKodu, cGenel.Type, cGenel.Model, KarkasIslem.RHDollyBarkod, dollyRafSirasi.ToString(), cGenel.YonBilgisi, cGenel.SetCount, "REWORK", cGenel._OpenSessionUSERNAME);
                KarkasIslem.xLOOP = false;
                _AREvt.WaitOne(300, true);
                bool sonuc2 = lambaKontrol.lambaJobIlgiliIsikSteadyYakSariRework(cGenel.nowDeviceID);
                
                cGenel.nowDeviceID = 0;
            }
            this.Hide();
            cGenel.frmMain.ViewForm(cGenel.frmPickToLight);
            cGenel.frmPickToLight.DurumIzleme();
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
    }
}
