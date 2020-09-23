using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace ToyotaBoshokuDollyOrientation
{
    class barkodOkuyucu
    {
        //private delegate void SetTextDeleg(string text);
        cMesajlar mesajlar = new cMesajlar();
        //SerialPort Okuyucu;
        KarkasIslem karkasIslem = new KarkasIslem();
        barkodIslem urunBarkod = new barkodIslem();
        cDollys dolly = new cDollys();
        cGenel global = new cGenel();
        cLambaKontrol alarm = new cLambaKontrol();
        models model = new models();
        // static string data;

        /*  public bool barkodBaglanti()
          {
              bool result = false;

              try
              {
                  cParametreler param = new cParametreler();
                  string port="";
                  if (cGenel.MAKINE_ADI==cGenel.MAKINE_ADI_LH)
                  {
                      port = param.LH_ComportSorgula();

                  }
                  else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
                  {
                      port = param.RH_ComportSorgula();
                  }

                  Okuyucu = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);
                  Okuyucu.Handshake = Handshake.None;
                  Okuyucu.DataReceived += new SerialDataReceivedEventHandler(Barkod);
                  Okuyucu.ReadTimeout = 500;
                  Okuyucu.WriteTimeout = 500;
                  Okuyucu.Open();
                  result = true;

              }
              catch (Exception ex)
              {
                  mesajlar.hata(ex);
                  result = false;
              }
              return result;
          }

          public void Barkod(object sender, SerialDataReceivedEventArgs e)
          {


              Thread.Sleep(100);
              data = Okuyucu.ReadExisting();

              cGenel.frmMain.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });


          }*/

        public void si_DataReceived(string data)
        {
            ///100AX417
            if (data.Trim() != null && cGenel.nowDeviceID == 0)
            {
                data = data.Trim();
                // data = data.Substring(0, data.Length - 1);
                //if (barkodOkuyucu==true)
                //{
                //    data = data.Substring(0, data.Length-1);
                //}
                cGenel.frmMain.lblBarkod.Text = data;
                float TeleMail = 0;
                string DoorSpec = "";//X467
                try
                {
                    if (data.Length >= 7)
                    {
                        cGenel.TeleMailSirasi = Convert.ToInt16(data.Substring(0, 3));//100
                        cGenel.ModelKodu = data.Substring(3, 1);//A
                        cGenel.SpecKodu = data.Substring(4, 2);//X4
                        cGenel.YonBilgisi = global.yonBilgisiBul(byte.Parse(data.Substring(data.Length - 1)));//7
                        cGenel.TBTDOORSpecKodu = data.Substring(4, 4);//X417
                        cGenel.DoorBarcode = data;
                    }
                    else
                    {
                        cGenel.TeleMailSirasi = 0;
                        cGenel.SpecKodu = "";
                        cGenel.TBTDOORSpecKodu = "";
                        cGenel.YonBilgisi = "";
                        cGenel.DoorBarcode = "";
                    }

                }
                catch (Exception)
                {
                    cGenel.TeleMailSirasi = 0;
                    cGenel.SpecKodu = "";
                    cGenel.TBTDOORSpecKodu = "";
                    cGenel.YonBilgisi = "";
                    cGenel.DoorBarcode = "";

                }
                if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
                {
                    karkasIslem.listBARKOD = karkasIslem.dollyKarkasBarkodSearch_LH();
                    cGenel.urunBarkodKarkasDurum = karkasIslem.listBARKOD.Contains(cGenel.DoorBarcode);

                    if (cGenel.urunBarkodKarkasDurum == false && data.Length >= 7)
                    {
                        if (cGenel.YonBilgisi == cGenel.FR_LH && data.Length >= 7)
                        {
                            urunBarkod = urunBarkod.barkodeSearch_FRL(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, 0);
                            DoorSpec = urunBarkod._FRL_BARCODE;
                            TeleMail = urunBarkod._TRIMNO;
                            cGenel.BarkodID = urunBarkod._ID;
                            cGenel.dollyRafBilgisi = urunBarkod._SEQUENCE;
                            cGenel.Type = urunBarkod._TYPE;
                            cGenel.Model = model.speckInfoSearch(cGenel.ModelKodu)._MODELADI;
                        }
                        else if (cGenel.YonBilgisi == cGenel.RR_LH && data.Length >= 7)
                        {
                            urunBarkod = urunBarkod.barkodeSearch_RRL(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, 0);
                            DoorSpec = urunBarkod._RRL_BARCODE;
                            TeleMail = urunBarkod._TRIMNO;
                            cGenel.BarkodID = urunBarkod._ID;
                            cGenel.dollyRafBilgisi = urunBarkod._SEQUENCE;
                            cGenel.Type = urunBarkod._TYPE;
                            cGenel.Model = model.speckInfoSearch(cGenel.ModelKodu)._MODELADI;
                        }

                    }
                    else if (cGenel.urunBarkodKarkasDurum == true && data.Length >= 7)
                    {

                        if (cGenel.YonBilgisi == cGenel.FR_LH && data.Length >= 7)
                        {
                            int index = karkasIslem.listBARKOD.FindIndex(s => s == cGenel.DoorBarcode);
                            cGenel.dollyRafBilgisi = karkasIslem.dollyRafSirasiSearch_LH(index);
                            cGenel.BarkodID = karkasIslem.urunBarkodIDSearch_LH(cGenel.dollyRafBilgisi, cGenel.YonBilgisi);
                            urunBarkod = urunBarkod.barcodInfoID_LH(cGenel.BarkodID);
                            DoorSpec = urunBarkod._FRL_BARCODE;
                            TeleMail = urunBarkod._TRIMNO;
                            cGenel.Type = urunBarkod._TYPE;
                            cGenel.Model = model.speckInfoSearch(cGenel.ModelKodu)._MODELADI;
                        }
                        else if (cGenel.YonBilgisi == cGenel.RR_LH && data.Length >= 7)
                        {
                            int index = karkasIslem.listBARKOD.FindIndex(s => s == cGenel.DoorBarcode);
                            cGenel.dollyRafBilgisi = karkasIslem.dollyRafSirasiSearch_LH(index);
                            cGenel.BarkodID = karkasIslem.urunBarkodIDSearch_LH(cGenel.dollyRafBilgisi, cGenel.YonBilgisi);
                            urunBarkod = urunBarkod.barcodInfoID_LH(cGenel.BarkodID);
                            DoorSpec = urunBarkod._RRL_BARCODE;
                            TeleMail = urunBarkod._TRIMNO;
                            cGenel.Type = urunBarkod._TYPE;
                            cGenel.Model = model.speckInfoSearch(cGenel.ModelKodu)._MODELADI;
                        }
                    }
                    if (karkasIslem.gorevDurumIslemYokveyaYapiliyorDollyLH()._ID == 0 )//(v1.0 -->urunBarkod.barkod_FRL_RRL_Count() > 0)
                    {

                        if (data == dolly.dollyBarkodInfo(data)._DollyBarkod)
                        {
                            KarkasIslem.LHDollyBarkod = data;
                            uint dollyNo = dolly.dollyBarkodInfo(KarkasIslem.LHDollyBarkod)._DollyNo;
                            bool result1 = karkasIslem.gorevOlustur_LH(dollyNo);//Dolly_LH tablo yazıldı.

                            if (result1)
                            {

                                if (urunBarkod.barkod_FRL_RRL_Count() == 0)
                                {
                                    cGenel.frmMain.setlemeDongusu();//(v2.0'da eklendi.)
                                }
                                cGenel.genelUyariAlarm("Dolly tanıtma başarılı\n Kapı barkodlarını okutmaya başlayabilirsiniz!", false, true);
                                cGenel.kilitKapatTetik = true;
                            }
                        }
                        else if (cGenel.TBTDOORSpecKodu == DoorSpec && cGenel.TeleMailSirasi == TeleMail)
                        {

                            cGenel.genelUyariAlarm("Ürün barkod okutmadan önce dolly tanıtınız!", false, true);

                        }
                        else
                        {
                            cGenel.genelUyariAlarm("Dolly tanıtınız!", false, true);

                        }

                    }
                    else if (cGenel.nowDeviceID == 0 && data.Length >= 7)
                    {

                        if (cGenel.TBTDOORSpecKodu == DoorSpec && cGenel.TeleMailSirasi == TeleMail)
                        {
                            if (karkasIslem.dollyYuklemeSirasiKontrol(cGenel.dollyRafBilgisi, cGenel.YonBilgisi) == true)
                            {

                                if (cGenel.YonBilgisi == cGenel.FR_LH)
                                {
                                    barkodPopupIslem_LH(DoorSpec);
                                }
                                else if (cGenel.YonBilgisi == cGenel.RR_LH)
                                {
                                    barkodPopupIslem_LH(DoorSpec);
                                }
                                else
                                {
                                    cGenel.genelUyariAlarm("Yön veya hat bilgisi tanımlama hatası!", false, true);
                                }

                            }
                            else
                            {
                                cGenel.genelUyariAlarm("Telemail numaraları ve yön sırasında atlama yapılamaz!", false, true);
                            }
                        }
                        else
                        {
                            cGenel.genelUyariAlarm("Okutulan barkod ataması yapılmamıştır!", false, true);
                        }


                    }

                }
                else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
                {

                    karkasIslem.listBARKOD = karkasIslem.dollyKarkasBarkodSearch_RH();
                    cGenel.urunBarkodKarkasDurum = karkasIslem.listBARKOD.Contains(cGenel.DoorBarcode);

                    if (cGenel.urunBarkodKarkasDurum == false && data.Length >= 7)
                    {
                        if (cGenel.YonBilgisi == cGenel.FR_RH)
                        {
                            urunBarkod = urunBarkod.barkodeSearch_FRR(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, 0);
                            DoorSpec = urunBarkod._FRR_BARCODE;
                            TeleMail = urunBarkod._TRIMNO;
                            cGenel.BarkodID = urunBarkod._ID;
                            cGenel.dollyRafBilgisi = urunBarkod._SEQUENCE;
                            cGenel.Type = urunBarkod._TYPE;
                            cGenel.Model = model.speckInfoSearch(cGenel.ModelKodu)._MODELADI;
                        }
                        else if (cGenel.YonBilgisi == cGenel.RR_RH)
                        {
                            urunBarkod = urunBarkod.barkodeSearch_RRR(cGenel.TeleMailSirasi, cGenel.TBTDOORSpecKodu, 0);
                            DoorSpec = urunBarkod._RRR_BARCODE;
                            TeleMail = urunBarkod._TRIMNO;
                            cGenel.BarkodID = urunBarkod._ID;
                            cGenel.dollyRafBilgisi = urunBarkod._SEQUENCE;
                            cGenel.Type = urunBarkod._TYPE;
                            cGenel.Model = model.speckInfoSearch(cGenel.ModelKodu)._MODELADI;
                        }
                    }
                    else if (cGenel.urunBarkodKarkasDurum == true && data.Length >= 7)
                    {


                        if (cGenel.YonBilgisi == cGenel.FR_RH)
                        {
                            int index = karkasIslem.listBARKOD.FindIndex(s => s == cGenel.DoorBarcode);
                            cGenel.dollyRafBilgisi = karkasIslem.dollyRafSirasiSearch_RH(index);
                            cGenel.BarkodID = karkasIslem.urunBarkodIDSearch_RH(cGenel.dollyRafBilgisi, cGenel.YonBilgisi);
                            urunBarkod = urunBarkod.barcodInfoID_RH(cGenel.BarkodID);
                            DoorSpec = urunBarkod._FRR_BARCODE;
                            TeleMail = urunBarkod._TRIMNO;
                            cGenel.Type = urunBarkod._TYPE;
                            cGenel.Model = model.speckInfoSearch(cGenel.ModelKodu)._MODELADI;
                        }
                        else if (cGenel.YonBilgisi == cGenel.RR_RH)
                        {
                            int index = karkasIslem.listBARKOD.FindIndex(s => s == cGenel.DoorBarcode);
                            cGenel.dollyRafBilgisi = karkasIslem.dollyRafSirasiSearch_RH(index);
                            cGenel.BarkodID = karkasIslem.urunBarkodIDSearch_RH(cGenel.dollyRafBilgisi, cGenel.YonBilgisi);
                            urunBarkod = urunBarkod.barcodInfoID_RH(cGenel.BarkodID);
                            DoorSpec = urunBarkod._RRR_BARCODE;
                            TeleMail = urunBarkod._TRIMNO;

                            cGenel.Type = urunBarkod._TYPE;
                            cGenel.Model = model.speckInfoSearch(cGenel.ModelKodu)._MODELADI;
                        }
                    }

                    if (karkasIslem.gorevDurumIslemYokveyaYapiliyorDollyRH()._ID == 0)//(v1.0 -->urunBarkod.barkod_FRR_RRR_Count() > 0)
                    {

                        if (data == dolly.dollyBarkodInfo(data)._DollyBarkod)
                        {
                            KarkasIslem.RHDollyBarkod = data;
                            uint dollyNo = dolly.dollyBarkodInfo(KarkasIslem.RHDollyBarkod)._DollyNo;
                            bool result1 = karkasIslem.gorevOlustur_RH(dollyNo);//Dolly_RH tablo yazıldı.

                            if (result1)
                            {
                             
                                if (urunBarkod.barkod_FRR_RRR_Count() == 0)
                                {
                                    cGenel.frmMain.setlemeDongusu();//(v2.0'da eklendi.)
                                }
                                cGenel.genelUyariAlarm("Dolly tanıtma başarılı\n Kapı barkodlarını okutmaya başlayabilirsiniz!", false, true);
                                cGenel.kilitKapatTetik = true;
                            }
                        }
                        else if (cGenel.TBTDOORSpecKodu == DoorSpec && cGenel.TeleMailSirasi == TeleMail)
                        {

                            cGenel.genelUyariAlarm("Ürün barkod okutmadan önce dolly tanıtınız!", false, true);

                        }
                        else
                        {
                            cGenel.genelUyariAlarm("Geçersiz barkod!", false, true);

                        }

                    }
                    else if (cGenel.nowDeviceID == 0 && data.Length >= 7)
                    {
                        if (cGenel.TBTDOORSpecKodu == DoorSpec && cGenel.TeleMailSirasi == TeleMail)
                        {
                            if (karkasIslem.dollyYuklemeSirasiKontrol(cGenel.dollyRafBilgisi, cGenel.YonBilgisi) == true)
                            {

                                if (cGenel.YonBilgisi == cGenel.FR_RH)
                                {

                                    barkodPopupIslem_RH(DoorSpec);
                                }
                                else if (cGenel.YonBilgisi == cGenel.RR_RH)
                                {

                                    barkodPopupIslem_RH(DoorSpec);
                                }
                                else
                                {
                                    cGenel.genelUyariAlarm("Yön veya hat bilgisi tanımlama hatası!", false, true);
                                }

                            }
                            else
                            {
                                cGenel.genelUyariAlarm("Telemail numaraları ve yön sırasında atlama yapılamaz!", false, true);
                            }
                        }
                        else
                        {
                            cGenel.genelUyariAlarm("Okutulan barkod ataması yapılmamıştır!", false, true);
                        }
                    }
                }

            }


        }

        private void barkodPopupIslem_LH(string DoorSpec)
        {
            if (cGenel.xDublicateBarkodCalismaDurumu == true && (cGenel.YonBilgisi == cGenel.FR_LH || cGenel.YonBilgisi == cGenel.RR_LH))
            {

                cGenel.frmPopupIslem.sayfaYukle();


                cGenel.frmMain.ViewForm(cGenel.frmPopupIslem);

            }
            else if (cGenel.xDublicateBarkodCalismaDurumu == false && urunBarkod.barkodInfoIDStatus_LH(cGenel.BarkodID, cGenel.YonBilgisi) != (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde)
            {


                cGenel.frmPopupIslem.sayfaYukle();

                cGenel.frmMain.ViewForm(cGenel.frmPopupIslem);


            }
            else if (cGenel.xDublicateBarkodCalismaDurumu == false && urunBarkod.barkodInfoIDStatus_LH(cGenel.BarkodID, cGenel.YonBilgisi) == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde)
            {
                cGenel.genelUyariAlarm("Dublicate barkod işlemi yapılamaz.!", false, true);
                cGenel.frmMain.formKapat();
            }

        }

        private void barkodPopupIslem_RH(string DoorSpec)
        {
            if (cGenel.xDublicateBarkodCalismaDurumu == true && (cGenel.YonBilgisi == cGenel.FR_RH || cGenel.YonBilgisi == cGenel.RR_RH))
            {
                if (cGenel.frmPopupIslem == null)
                {

                    cGenel.frmPopupIslem.sayfaYukle();


                    cGenel.frmMain.ViewForm(cGenel.frmPopupIslem);
                }
                else
                {
                    cGenel.frmPopupIslem.sayfaYukle();

                    cGenel.frmMain.ViewForm(cGenel.frmPopupIslem);

                }
            }
            else if (cGenel.xDublicateBarkodCalismaDurumu == false && urunBarkod.barkodInfoIDStatus_RH(cGenel.BarkodID, cGenel.YonBilgisi) != (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde)
            {
                if (cGenel.frmPopupIslem == null)
                {

                    cGenel.frmPopupIslem.sayfaYukle();

                    cGenel.frmMain.ViewForm(cGenel.frmPopupIslem);
                }
                else
                {

                    cGenel.frmPopupIslem.sayfaYukle();

                    cGenel.frmMain.ViewForm(cGenel.frmPopupIslem);

                }
            }
            else if (cGenel.xDublicateBarkodCalismaDurumu == false && urunBarkod.barkodInfoIDStatus_RH(cGenel.BarkodID, cGenel.YonBilgisi) == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde)
            {
                cGenel.genelUyariAlarm("Dublicate barkod işlemi yapılamaz.!", false, true);
                cGenel.frmMain.formKapat();
            }

        }




    }
}
