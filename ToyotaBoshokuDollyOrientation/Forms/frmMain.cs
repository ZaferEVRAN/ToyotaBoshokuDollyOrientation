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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sayfalar arası geçişte formdaki donmaları engeller.
        /// </summary>
        ///         
        /// 
        static AutoResetEvent _AREvt;
        cParametreler parametre = new cParametreler();
        barkodOkuyucu okuyucu = new barkodOkuyucu();
        cLambaKontrol lambaKontrol = new cLambaKontrol();
        KarkasIslem karkasIslem = new KarkasIslem();
        barkodIslem urunBarkod = new barkodIslem();
        cDollys dolly = new cDollys();
        cistemciKontrol_StepMotor stepMotorIslemci = new cistemciKontrol_StepMotor();
        cStatus status = new cStatus();
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bool sonuc = cGenel.genelUyari("Çıkmak istediğinizden emin misiniz?", true);

            // stepMotorIslemci.kilitMekanizmaSensorOku();

            if (sonuc && cGenel.motorRun == false)
            {

                cUsers userlogin = new cUsers();
                userlogin.userLogoutDatetime(cGenel._OpenSessionID);
                cGenel._OpenSessionID = 0;
                cGenel._OpenSessionUSERNAME = "";
                cUserGrups grup = new cUserGrups();
                grup.userGrupOnline(cGenel._OpenSessionGRUP, false);
                Application.Exit();
            }

        }

        private void btnAltSekme_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        uint openSensesionTimeCount;
        cUsers user = new cUsers();
        cUserGrups grup = new cUserGrups();
        uint kilitTetikTimer;
        uint OKAlarmTimer;
        private void saat_Tick(object sender, EventArgs e)
        {
            if (!(cGenel.frmKullaniciSayfasi.Visible || cGenel.frmModel.Visible
                || cGenel.frmParametreler.Visible || cGenel.frmParametreler2.Visible
                || cGenel.frmPickToLighParameter.Visible || cGenel.frmStepMotorParametreBakim.Visible ||
                cGenel.frmYeniBarkodTanimla.Visible || cGenel.frmYeniDollyTanımla.Visible
                || cGenel.frmUretimKaydi.Visible ))
            {
                txtBarkod.Focus();
            }
            lblSaat.Text = DateTime.Now.ToString();

            openSensesionTimeCount++;
            if (openSensesionTimeCount == 10 && cGenel.frmMain.Visible == true)
            {
                user.userLoginDatetime(cGenel._OpenSessionID);
                grup.userGrupOnline(cGenel._OpenSessionGRUP, true);
                openSensesionTimeCount = 0;
            }




            //karkas aktif pasif
            if (cGenel.xByPass == true)
            {
                btnKarkasByPassAktif.Visible = false;
                btnKarkasByPassPasif.Visible = true;

            }
            else
            {
                btnKarkasByPassAktif.Visible = true;
                btnKarkasByPassPasif.Visible = false;
            }


            NGbuzzerAlarmTimer++;

        }
        bool alarmTetik;
        private void btnInfo_Click(object sender, EventArgs e)
        {
         
        }

        private void btnKlavye_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }


        private void txtBarkodLH_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case Keys.Enter:

                    string _sTxtBarkod = txtBarkod.Text.ToUpper();
                    _sTxtBarkod = _sTxtBarkod.Trim();
                    okuyucu.si_DataReceived(_sTxtBarkod);

                    lblBarkod.Text = _sTxtBarkod;
                    txtBarkod.Clear();
                    e.SuppressKeyPress = true;
                    break;
                default:
                    break;
            }
        }

        public void ViewForm(Form _form)
        {
            formKapat();
            _form.MdiParent = this;
            _form.StartPosition = FormStartPosition.Manual;
            _form.Dock = DockStyle.Fill;
            _form.Left = 0;
            _form.Top = 0;
            _form.BringToFront();
            _form.Show();

            txtBarkod.Focus();
        }



        public void formKapat()
        {

            foreach (Form item in this.MdiChildren)
            {
                item.Visible = false;

            }

        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            ViewForm(cGenel.frmAnasayfa);
        }

        public void frmPickToLight()
        {
            ViewForm(cGenel.frmPickToLight);
        }

        public Task<bool> pingTest(string nameOrAddress)
        {
            return Task.Run<bool>(() =>
            {
                _AREvt = new AutoResetEvent(false);
                while (true)
                {
                    try
                    {
                        _AREvt.WaitOne(100, true);
                        Ping ping = new Ping();
                        PingReply pingStatus = ping.Send(nameOrAddress, 1000);
                        if (pingStatus.Status == IPStatus.Success)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }

                }

            });

        }

        public bool pingTestBool(string nameOrAddress)
        {


            try
            {
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send(nameOrAddress, 1000);
                if (pingStatus.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }



        }


        uint NGbuzzerAlarmTimer;
        public static bool X;
        public static bool Y;
        private async void modbus_Tick(object sender, EventArgs e)
        {

            try
            {
                lblNowDeviceID.Text = cGenel.nowDeviceID.ToString();
                //lblModbusDeviceID.Text = cGenel.CommonDeviceID.ToString();

                lblIsikBaglantiAciklama.Text = cLambaKontrol.PLCDurumu.ToString();
                //lblLoop.Text = cGenel.loopInfoMain;

                lblIsikBaglantiAciklama.Text = cGenel.haberlesmeMesaj;
              /*  if (cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.Connected)
                {
                    btnKilitMekanizmasıHazir.Visible = true;
                    btnKilitMekanizmasıHazirDegil.Visible = false;
                }
                else
                {
                    btnKilitMekanizmasıHazir.Visible = false;
                    btnKilitMekanizmasıHazirDegil.Visible = true;

                }*/
                //Işıkların cihazı
                bool X = await pingTest(cGenel.conDXM_IP);

                if (X == false)////bağlantı yok
                {
                    btnIsiklarHazirDegil.Visible = true;
                    btnIsiklarHazir.Visible = false;

                    try
                    {
                        // if (cLambaKontrol.client.Connected == false)
                        // {
                        //      btnIsiklarHazirDegil.Visible = false;
                        //      btnIsiklarHazir.Visible = true;
                        // }
                    }
                    catch (Exception)
                    {
                        btnIsiklarHazirDegil.Visible = true;
                        btnIsiklarHazir.Visible = false;
                    }

                }

                else/////bağlantı var.
                {

                    btnIsiklarHazirDegil.Visible = false;
                    btnIsiklarHazir.Visible = true;

                    try
                    {
                        if (cLambaKontrol.client.Connected == false)
                        {
                            //istemci_LH.IstemciyiYenidenBaslat();
                            btnIsiklarHazirDegil.Visible = false;
                            btnIsiklarHazir.Visible = true;
                        }

                    }
                    catch (Exception)
                    {

                        // istemci_LH.IstemciyiYenidenBaslat();
                        btnIsiklarHazirDegil.Visible = true;
                        btnIsiklarHazir.Visible = false;

                    }

                }


                //Server
                bool Y = await pingTest(cGenel.conServer_IP);

                if (Y == false)////bağlantı yok
                {

                    btnServerHazirDegil.Visible = true;
                    btnServerHazir.Visible = false;


                }

                else/////bağlantı var.
                {


                    btnServerHazirDegil.Visible = false;
                    btnServerHazir.Visible = true;


                }


            }
            catch (Exception)
            {

            }









        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUstBilgi.Text = string.Format("{0}-Line Doortrim Dolly Traceability System-{1}", cGenel.MAKINE_ADI, cGenel._OpenSessionGRUPNAME);
            CheckForIllegalCrossThreadCalls = false;
            _AREvt = new AutoResetEvent(false);
            var t = Task.Run(() =>
            {
                while (true)
                {
                    _AREvt.WaitOne(100, true);
                    Loop();
                }

            });


            parametre.parametreleriAta();

            status.statusColorAta();



            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                KarkasIslem.LHDollyBarkod = karkasIslem.gorevDurumIslemYokveyaYapiliyorDollyLH()._DOLLYNO.ToString();
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                KarkasIslem.RHDollyBarkod = karkasIslem.gorevDurumIslemYokveyaYapiliyorDollyRH()._DOLLYNO.ToString();
            }

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

            if (cGenel.xByPass == false )
            {
                lambaKontrol.lambaKontrolConnect();
            }

            if (cGenel.xByPass == false && cLambaKontrol.PLCDurumu == PLCDurumlari.UYGUN)
            {
                lambaKontrol.yarimKalanIsıklarGoster();
            }

         //   stepMotorIslemci.stepMotorIstemciyiOlustur();

         //   stepMotorIslemci.kilitMekanizmaSensorOku();
        }
        private void islem(Object sender, EventArgs e)
        {

            klavyeOlustur(sender, e, txtBarkod);

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
        error_log errorLog = new error_log();
        log logOlustur = new log();
        public static bool xKontrol;
        public static bool xKontrolRing;
  
        bool sensorOkumaYapiliyorLog;
        private void Loop()
        {


            while (KarkasIslem.xLOOP && cGenel.xByPass == false)
            {
                _AREvt.WaitOne(100, true);

                try
                {
                    if (xKontrol == false)
                    {
                        lambaKontrol.lambaJobIlgiliIsikFlashYak(cGenel.nowDeviceID);
                        _AREvt.WaitOne(300, true);
                        bool sonuc = lambaKontrol.lamba.lambaJobIlgiliIsikFlashYakKontrol(cGenel.nowDeviceID, cGenel.jobState1StatusAnimationID, cGenel.jobState1StatusColorID, cLambaKontrol.master);
                        if (sonuc == true)
                        {
                            _AREvt.WaitOne(300, true);
                            cLambaKontrol.master.WriteSingleRegister(1, 713, 0);
                            xKontrol = true;
                            errorLog.error_log_kayit("Flash yak kontrol adım başarılı");
                        }
                        else
                        {
                         
                            errorLog.error_log_kayit("Flash yak kontrol adım başarısız.");
                        }
                    }
                    if (cGenel.sensorSonucu == 0 && xKontrol == true)
                    {

                        lambaKontrol.sensorOkuma(cGenel.nowDeviceID);

                        if (sensorOkumaYapiliyorLog==false)
                        {
                            errorLog.error_log_kayit("sensör okuma yapılıyor...");
                            sensorOkumaYapiliyorLog = true;
                        }

                    }
                    if (cGenel.sensorSonucu == 1 && xKontrol == true)
                    {
                        errorLog.error_log_kayit("sensör okuma yapıldı.");
                          _AREvt.WaitOne(300, true);

                        lambaKontrol.lambaJobIlgiliIsikSteadyYak(cGenel.nowDeviceID);
                        errorLog.error_log_kayit("lambaJobIlgiliIsikSteadyYak çalıştı.");
                        _AREvt.WaitOne(300, true);
                        bool steadySonuc = lambaKontrol.lamba.lambaJobIlgiliIsikSteadyYakKontrol(cGenel.nowDeviceID, cGenel.jobState2StatusAnimationID, cGenel.jobState2StatusColorID, cLambaKontrol.master);
                    
                        if (steadySonuc)//deviceID
                        {
                            errorLog.error_log_kayit("lambaJobIlgiliIsikSteadyYakKontrol çalıştı.");

                            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
                            {



                                cGenel.gorevID = karkasIslem.gorevSorgula_LH((byte)gorevDurumlari.gorevYapiliyor)._ID;

                                if (cGenel.urunBarkodKarkasDurum == true)
                                {
                                    urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde, cGenel.BarkodID);
                                }
                                else if (cGenel.urunBarkodKarkasDurum == false)
                                {
                                    urunBarkod.urunBarkodIslemTamamlandi_LH(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, cGenel.YonBilgisi, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde);

                                }

                                karkasIslem.urunBarkodDurumGuncelle_LH(cGenel.gorevID, (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde, cGenel.DoorBarcode, cGenel.BarkodID, cGenel.nowDeviceID, cGenel.YonBilgisi);

                                KarkasIslem.LHDollyBarkod = "999";
                                logOlustur.logOlustur(cGenel.BarkodID, cGenel.MAKINE_ADI_LH, cGenel.gorevID, cGenel.DoorBarcode, cGenel.ModelKodu, cGenel.SpecKodu, cGenel.Type, cGenel.Model, KarkasIslem.LHDollyBarkod, cGenel.dollyRafBilgisi.ToString(), cGenel.YonBilgisi, cGenel.SetCount, "OK", cGenel._OpenSessionUSERNAME);








                                uint barkodDurum = barkodIslem.barkod_FRL_RRL_Count();
                                if (barkodDurum == 0)//durum||
                                {
                                    errorLog.error_log_kayit("barkod set bitti.");
                                    //pnlNumarator.Visible = true;

                                    karkasIslem = karkasIslem.karkasDollyNoGetir_LH();
                                    logOlustur.logDollyNoGuncelle(karkasIslem._DOLLYNO, karkasIslem._ID);
                                    karkasIslem.gorevDurumTamamlandi_LH();

                                    setlemeDongusu();

                                    _AREvt.WaitOne(300, true);
                                    lambaKontrol.lambaDurumDollyBaslangic();
                                    errorLog.error_log_kayit("lambaDurumDollyBaslangic çalıştı.");
                                    // cGenel.lockOnClick = true;
                                    //stepMotorIslemci.kilitMekanizmaDongusu();

                                }
                            }
                            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
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

                                KarkasIslem.RHDollyBarkod = "999";
                                logOlustur.logOlustur(cGenel.BarkodID, cGenel.MAKINE_ADI_RH, cGenel.gorevID, cGenel.DoorBarcode, cGenel.ModelKodu, cGenel.SpecKodu, cGenel.Type, cGenel.Model, KarkasIslem.RHDollyBarkod, cGenel.dollyRafBilgisi.ToString(), cGenel.YonBilgisi, cGenel.SetCount, "OK", cGenel._OpenSessionUSERNAME);




                                uint barkodDurum = barkodIslem.barkod_FRR_RRR_Count();
                                if (barkodDurum == 0)
                                {
                                    errorLog.error_log_kayit("barkod set bitti.");
                                    karkasIslem = karkasIslem.karkasDollyNoGetir_RH();
                                    logOlustur.logDollyNoGuncelle(karkasIslem._DOLLYNO, karkasIslem._ID);

                                    karkasIslem.gorevDurumTamamlandi_RH();
                                    //pnlNumarator.Visible = true;
                                    setlemeDongusu();

                                    _AREvt.WaitOne(300, true);
                                    lambaKontrol.lambaDurumDollyBaslangic();
                                    //cGenel.lockOnClick = true;
                                    errorLog.error_log_kayit("lambaDurumDollyBaslangic çalıştı.");
                                    //stepMotorIslemci.kilitMekanizmaDongusu();


                                }


                            }


                            xKontrol = false;

                            // if (Properties.Settings.Default.OKBuzzer==true)
                            // {
                            //     alarmTetik = true;
                            //     OKAlarmTimer = 0;
                            // }

                            KarkasIslem.xLOOP = false;

                            cGenel.sensorSonucu = 0;
                            cGenel.nowDeviceID = 0;

                    

                            errorLog.error_log_kayit("loop bitti.");
                            sensorOkumaYapiliyorLog = false;

                            cGenel.frmPopupIslem.Hide();
                     

                            cLambaKontrol.master.WriteSingleRegister(1, 713, 0);


                        }

                    }

                }
                catch (Exception ex)
                {
                    cGenel.loopInfoMain = ex.Message;
                    errorLog.error_log_kayit("LOOP-OK buton basıldı. exception");
                }





            }



        }
        barkodIslem barkodIslem = new barkodIslem();
        TBTGALC_DOOR tbtgalcDoor = new TBTGALC_DOOR();
        List<TBTGALC_DOOR> listTBTGalc_LH = new List<TBTGALC_DOOR>();
        List<TBTGALC_DOOR> listTBTGalc_RH = new List<TBTGALC_DOOR>();



        public void setlemeDongusu()
        {
            if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
            {
                float lastTBTNO = tbtgalcDoor.TBTGalcLastTBTNO_Read_LH();

                if (barkodIslem.barkod_FRL_RRL_Count_0() == 0)
                {
                    listTBTGalc_LH.Clear();
                    listTBTGalc_LH = tbtgalcDoor.TBTGalcDoorSpecRead_LH(lastTBTNO);
                    if (listTBTGalc_LH.Count > 0)
                    {
                        lastTBTNO = listTBTGalc_LH[(listTBTGalc_LH.Count - 1)]._TBTNO;
                        barkodIslem.barcodsNewAdd_LH(listTBTGalc_LH);
                    }
                    tbtgalcDoor.TBTGalcLastTBTNO_Write_LH(lastTBTNO + 1);

                    if (karkasIslem.gorevDurumIslemYokveyaYapiliyorDollyLH()._ID == 0)//(v1.0 -->urunBarkod.barkod_FRR_RRR_Count() > 0)
                    {
                        karkasIslem.gorevOlustur_LH(999);//v2.0 
                    }

                }
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                float lastTBTNO = tbtgalcDoor.TBTGalcLastTBTNO_Read_RH();
                if (barkodIslem.barkod_FRR_RRR_Count_0() == 0)
                {
                    listTBTGalc_RH.Clear();
                    listTBTGalc_RH = tbtgalcDoor.TBTGalcDoorSpecRead_RH(lastTBTNO);
                    if (listTBTGalc_RH.Count > 0)
                    {
                        lastTBTNO = listTBTGalc_RH[(listTBTGalc_RH.Count - 1)]._TBTNO;
                        barkodIslem.barcodsNewAdd_RH(listTBTGalc_RH);
                    }
                    tbtgalcDoor.TBTGalcLastTBTNO_Write_RH(lastTBTNO + 1);

                    if (karkasIslem.gorevDurumIslemYokveyaYapiliyorDollyRH()._ID == 0)//(v1.0 -->urunBarkod.barkod_FRR_RRR_Count() > 0)
                    {
                        karkasIslem.gorevOlustur_RH(999);//v2.0
                    }
                }
            }
        }

        private void stepMotorRead_Tick(object sender, EventArgs e)
        {


            lblModbusRTUBilgi.Text = cGenel.haberlesmeMesajModbusRTU;

            if (cGenel.lockOffSensor == true && cGenel.lockOnSensor == true)
            {
                btnKilitAcik.Visible = true;
            }
            else
            {
                btnKilitAcik.Visible = false;
            }

            if (cGenel.lockOffSensor == false && cGenel.lockOnSensor == false)
            {
                btnKilitKapali.Visible = true;
            }
            else
            {
                btnKilitKapali.Visible = false;
            }

            if ((cGenel.deviceAlarmVar || cGenel.stepAlarmVar) && cGenel.motorRun == false)
            {
                btnHata.Visible = true;
            }
            else if (cGenel.deviceAlarmVar == false && cGenel.stepAlarmVar == false)
            {
                btnHata.Visible = false;
            }


            //Kilitleme
            if (cGenel.kilitKapatTetik == true)
            {
                kilitTetikTimer++;
                if (kilitTetikTimer >= cGenel.kilitKapatmaSuresi)
                {
                    cGenel.lockOffClick = true;
                  //  stepMotorIslemci.kilitMekanizmaDongusu();
                    cGenel.kilitKapatTetik = false;
                    kilitTetikTimer = 0;
                }
            }

            //Kilitleme
            if (cGenel.motorRun)
            {
                cGenel.timer++;
            }

        }

        private void buzzer_Tick(object sender, EventArgs e)
        {
             if (cGenel.xByPass==false&& cGenel.xBuzzerByPass == false && cGenel.nowDeviceID > 0)
             {
                 lambaKontrol.buzzerDeviceIDRead();
             }
            
             if (cGenel.xByPass == false && cGenel.xBuzzerByPass == false && cGenel.deviceIDSensor[0] != cGenel.nowDeviceID && cGenel.deviceIDSensor[0] > 0 && cGenel.nowDeviceID > 0 && cGenel.alarmVar == false)
             {
                 lambaKontrol.buzzerRing(1);
                 NGbuzzerAlarmTimer = 0;
                 cGenel.alarmVar = true;
             }
            
             if (cGenel.xByPass == false && cGenel.xBuzzerByPass == false && cGenel.deviceIDSensor[0] == 0 && NGbuzzerAlarmTimer >= cGenel.buzzerMispickSuresi && cGenel.alarmVar == true)///PARAMETREYE bağlanacak
             {
                 lambaKontrol.buzzerRing(0);
                 cGenel.alarmVar = false;
             }
            
            

            //  if (cGenel.xBuzzerByPass == false && alarmTetik == true)
            //  {
            //      lambaKontrol.buzzerRing(1);
            //
            //      OKAlarmTimer++;
            //      _AREvt.WaitOne(300, true);
            //      lambaKontrol.buzzerRingKontrol();
            //
            //  }


            //  if (cGenel.xBuzzerByPass == false && OKAlarmTimer >= 4 && alarmTetik == true && cLambaKontrol.ringKontol == 1)
            //  {
            //
            //      lambaKontrol.buzzerRing(0);
            //      alarmTetik = false;
            //
            //  }

        }

        private void lblUstBilgi_Click(object sender, EventArgs e)
        {

        }

        private void pnlAltBaslik_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHata_Click(object sender, EventArgs e)
        {
            cGenel.genelUyari("Dollyi düzelterek tekrar kilit aç kapat yapınız.!", false);
        }

        private void txtBarkod_Click(object sender, EventArgs e)
        {
           // pnlNumarator.Visible = true;
        }

        private void btnNumaratorKapat_Click(object sender, EventArgs e)
        {
            pnlNumarator.Visible = false;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtBarkod.Clear();
        }

        private void btnDollyNoGir_Click(object sender, EventArgs e)
        {
            string data = txtBarkod.Text;

            if (data == dolly.dollyBarkodInfo(data)._DollyBarkod)
            {

                bool result1 = false;
                KarkasIslem.LHDollyBarkod = data;
                uint dollyNo = dolly.dollyBarkodInfo(KarkasIslem.LHDollyBarkod)._DollyNo;
                if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
                {
                    result1 = karkasIslem.gorevGuncelle_LH(dollyNo);
                    if (result1)
                    {
                        // karkasIslem.gorevDurumTamamlandi_LH();
                        // setlemeDongusu();
                        cGenel.genelUyariAlarm("Dolly tanıtma başarılı!", false, true);
                        // logOlustur.logDollyNoGuncelle_LH(dollyNO);
                    }
                }
                else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
                {
                    result1 = karkasIslem.gorevGuncelle_RH(dollyNo);
                    if (result1)
                    {
                        //  karkasIslem.gorevDurumTamamlandi_RH();
                        //  setlemeDongusu();
                        cGenel.genelUyariAlarm("Dolly tanıtma başarılı!", false, true);
                        // logOlustur.logDollyNoGuncelle_RH( dollyNO);
                    }
                }
                // lambaKontrol.lambaDurumDollyBaslangic();
                //  cGenel.lockOnClick = true;
                cGenel.lockOffClick = true;
                //stepMotorIslemci.kilitMekanizmaDongusu();
                txtBarkod.Clear();
            }
            else
            {
                cGenel.genelUyariAlarm("Tanımlı Dolly no giriniz!", false, true);

            }
        }

        private void btnDollyKilitKapat_Click(object sender, EventArgs e)
        {
           // cistemciKontrol_StepMotor step = new cistemciKontrol_StepMotor();
           // step.kilitMekanizmaSensorOku();
            if (cGenel.motorRun == false && cGenel.stepAlarmVar == false)
            {
                if (cGenel.lockOffSensor == true)
                {
                    cGenel.lockOffClick = true;

                   // step.kilitMekanizmaDongusu();
                }
            }
        }

        private void bunifuCustomLabel12_Click(object sender, EventArgs e)
        {

        }

        private void btnBarkodKlavye_Click(object sender, EventArgs e)
        {
            pnlNumarator.Visible = true;
        }
    }
}

