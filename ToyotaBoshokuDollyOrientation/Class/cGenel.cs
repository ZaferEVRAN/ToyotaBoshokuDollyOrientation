using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using ToyotaBoshokuDollyOrientation.Forms;

namespace ToyotaBoshokuDollyOrientation
{
    public enum urunBarkodDurumlari
    {
        barkodIslemDurumYok = 0,
        barkodIslemDurumUrunRework = 1,
        barkodIslemDurumUrunDollyde = 2,

    }
    public enum PLCDurumlari
    {
        KULLANILAMAZ = 0,
        UYGUN = 1
    }

    public enum dollyGenelDurum
    {
        islemyok = 0,
        islemyapiliyor = 1
    }
    public enum dollyRafDurum
    {
        islemyok = 0,
        dollyde = 1,
        tamirde = 2,
        dollyrafBypass = 3
    }
    public enum LambaDurumlari : byte { on, off };

    class cGenel
    {
        public static string MAKINE_ADI = Properties.Settings.Default.Makina_Adi;
        public static string MAKINE_ADI_LH = "LH";
        public static string MAKINE_ADI_RH = "RH";
        public const int DollyBaslangicDeviceID = 31;
        public const int DollyBitisDeviceID = 50;
        public const string conDXM_IP = "192.168.1.200";
        public const string conServer_IP = "192.168.110.52";

    public string conString = "Data Source=sqlsrv1;Initial Catalog = ToyotaDDTS; User ID =rbtsuser ; Password=rbts$!1?";
    public string conStringTBT = "Data Source=tbtprdsql;Initial Catalog = TBTGALC; User ID = sempasqlro; Password=Dof4sYu";

       //  public string conString = @"Data Source=.\SQLEXPRESS;Initial Catalog = ToyotaDDTS; Integrated security=true ";
       //  public string conStringTBT = @"Data Source=.\SQLEXPRESS;Initial Catalog = ToyotaDDTS; Integrated security=true ";


        public static bool genelUyari(string str, bool cancelStatus)
        {

            bool sonuc = false;
            Form Popup = new Form
            {
                Width = 1039, // genişlik parametresini yaz
                Height = 257, // yükseklik parametresini yaz
                ShowInTaskbar = false, // Başlat çubuğunda görülmesin
                FormBorderStyle = FormBorderStyle.None, // Form kenarlıkları yok
                BackColor = Color.Silver, // Arkaplan "Turuncu" rengi olsun
                StartPosition = FormStartPosition.CenterScreen, // Formu ekrana ortasında göster
                TopMost = true, // Her zaman üstte dursun
                Cursor = Cursors.Hand, // Mouse şekli el şeklinde olsun
                ForeColor = Color.Red,


            };


            Label lbl = new Label();
            lbl.Text = "Uyarı!!";
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font(lbl.Font.FontFamily.Name, 30, FontStyle.Bold);
            lbl.Width = 135;
            lbl.Height = 48;
            lbl.Top = 12;
            lbl.Left = 461;
            Popup.Controls.Add(lbl);

            Label lbl2 = new Label();
            lbl2.Text = str;
            lbl2.ForeColor = Color.Red;
            lbl2.Font = new Font(lbl2.Font.FontFamily.Name, 20, FontStyle.Bold);
            lbl2.Width = 1015;
            lbl2.Height = 94;
            lbl2.Top = 66;
            lbl2.Left = 12;
            lbl2.TextAlign = ContentAlignment.TopCenter;
            Popup.Controls.Add(lbl2);

            Button btn = new Button();
            btn.AutoSize = false;
            btn.Size = new Size(102, 67);
            btn.FlatStyle = FlatStyle.Flat;
            btn.Name = "btnIptal";
            btn.Text = "İPTAL";
            btn.Font = new Font(btn.Font.FontFamily.Name, 12, FontStyle.Bold);
            btn.ForeColor = Color.Black;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.BackColor = Color.Red;
            btn.Visible = cancelStatus;
            btn.Location = new Point(418, 166);
            Popup.Controls.Add(btn);
            btn.Click += delegate
            {

                sonuc = false;
                Popup.Close();

            };

            Button btn2 = new Button();
            btn2.AutoSize = false;
            btn2.Size = new Size(102, 67);
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.Name = "btnTamam";
            btn2.Text = "TAMAM";
            btn2.Font = new Font(btn.Font.FontFamily.Name, 12, FontStyle.Bold);
            btn2.ForeColor = Color.Black;
            btn2.TextAlign = ContentAlignment.MiddleCenter;
            btn2.BackColor = Color.Green;

            btn2.Location = new Point(526, 166);
            Popup.Controls.Add(btn2);
            btn2.Click += delegate
            {

                Popup.Close();
                sonuc = true;

            };
            Popup.ShowDialog();
            return sonuc;
        }

        public static bool genelUyariAlarm(string str, bool cancelStatus, bool alarm)
        {
            //cLambaKontrol lamba = new cLambaKontrol();
            //lamba.buzzerRing(1);
            bool sonuc = false;
            Form Popup = new Form
            {
                Width = 1039, // genişlik parametresini yaz
                Height = 257, // yükseklik parametresini yaz
                ShowInTaskbar = false, // Başlat çubuğunda görülmesin
                FormBorderStyle = FormBorderStyle.None, // Form kenarlıkları yok
                BackColor = Color.Silver, // Arkaplan "Turuncu" rengi olsun
                StartPosition = FormStartPosition.CenterScreen, // Formu ekrana ortasında göster
                TopMost = true, // Her zaman üstte dursun
                Cursor = Cursors.Hand, // Mouse şekli el şeklinde olsun
                ForeColor = Color.Red,


            };


            Label lbl = new Label();
            lbl.Text = "Uyarı!!";
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font(lbl.Font.FontFamily.Name, 30, FontStyle.Bold);
            lbl.Width = 135;
            lbl.Height = 48;
            lbl.Top = 12;
            lbl.Left = 461;
            Popup.Controls.Add(lbl);

            Label lbl2 = new Label();
            lbl2.Text = str;
            lbl2.ForeColor = Color.Red;
            lbl2.Font = new Font(lbl2.Font.FontFamily.Name, 20, FontStyle.Bold);
            lbl2.Width = 1015;
            lbl2.Height = 94;
            lbl2.Top = 66;
            lbl2.Left = 12;
            lbl2.TextAlign = ContentAlignment.TopCenter;
            Popup.Controls.Add(lbl2);

            Button btn = new Button();
            btn.AutoSize = false;
            btn.Size = new Size(102, 67);
            btn.FlatStyle = FlatStyle.Flat;
            btn.Name = "btnIptal";
            btn.Text = "İPTAL";
            btn.Font = new Font(btn.Font.FontFamily.Name, 12, FontStyle.Bold);
            btn.ForeColor = Color.Black;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.BackColor = Color.Red;
            btn.Visible = cancelStatus;
            btn.Location = new Point(418, 166);
            Popup.Controls.Add(btn);
            btn.Click += delegate
            {
                // lamba.buzzerRing(0);
                sonuc = false;
                Popup.Close();


            };

            Button btn2 = new Button();
            btn2.AutoSize = false;
            btn2.Size = new Size(102, 67);
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.Name = "btnTamam";
            btn2.Text = "TAMAM";
            btn2.Font = new Font(btn.Font.FontFamily.Name, 12, FontStyle.Bold);
            btn2.ForeColor = Color.Black;
            btn2.TextAlign = ContentAlignment.MiddleCenter;
            btn2.BackColor = Color.Green;

            btn2.Location = new Point(526, 166);
            Popup.Controls.Add(btn2);
            btn2.Click += delegate
            {
                //lamba.buzzerRing(0);
                Popup.Close();
                sonuc = true;

            };
            Popup.ShowDialog();
            return sonuc;
        }

        public static bool alarmVar;
        public static bool stepAlarmVar;
        public static frmMain frmMain = new frmMain();
        public static frmAnaSayfa frmAnasayfa = new frmAnaSayfa();
        public static frmPickToLight frmPickToLight = new frmPickToLight();
        public static frmDollyIzleme frmDollyIzleme = new frmDollyIzleme();
        public static frmManual frmManual = new frmManual();
        public static frmKayitlar frmKayitlar = new frmKayitlar();
        public static frmManualLamba frmManualLamba = new frmManualLamba();
        public static frmParametreler frmParametreler = new frmParametreler();
        public static frmYeniBarkodTanimla frmYeniBarkodTanimla = new frmYeniBarkodTanimla();
        public static frmYeniDollyTanımla frmYeniDollyTanımla = new frmYeniDollyTanımla();
        public static frmKullaniciSayfasi frmKullaniciSayfasi = new frmKullaniciSayfasi();
        public static frmModels frmModel = new frmModels();
        public static frmStepMotorParametreBakim frmStepMotorParametreBakim = new frmStepMotorParametreBakim();
        public static frmManualPickToLightKontrol frmManualPickToLightKontrol = new frmManualPickToLightKontrol();
        public static frmPopupIslem frmPopupIslem = new frmPopupIslem();
        public static frmPickToLighParameter frmPickToLighParameter = new frmPickToLighParameter();
        public static frmAdminPanel frmAdminPanel = new frmAdminPanel();
        public static frmParametreler2 frmParametreler2 = new frmParametreler2();
        public static frmUretimKaydi frmUretimKaydi = new frmUretimKaydi();
        public static fmrOperatorPanel frmOperatorPanel = new fmrOperatorPanel();
        public void textSingleClear(TextBox txt)
        {
            try
            {
                txt.Text = txt.Text.Substring(0, txt.Text.Length - 1);
                txt.Focus();
                txt.SelectionStart = txt.TextLength;
            }
            catch (Exception)
            {

            }
        }

        public static uint _OpenSessionID;
        public static string _OpenSessionUSERNAME;
        public static uint _OpenSessionGRUP;
        public static string _OpenSessionGRUPNAME;

        public static ushort nowDeviceID;


        public static uint sensorSonucu;

        public static string haberlesmeMesaj;

        public static ushort[] deviceIDSensor = new ushort[1];


        public static bool xDublicateBarkodCalismaDurumu;

        public const string WAIT_STATE_ANIMATION_ID = "WAIT_STATE_ANIMATION_ID";
        public const string WAIT_STATE_COLOR_ID = "WAIT_STATE_COLOR_ID";
        public const string MISPICK_STATE_ANIMATION_ID = "MISPICK_STATE_ANIMATION_ID";
        public const string MISPICK_STATE_COLOR_ID = "MISPICK_STATE_COLOR_ID";
        public const string JOB_STATE_1_STATUS_ANIMATION_ID = "JOB_STATE_1_STATUS_ANIMATION_ID";
        public const string JOB_STATE_1_STATUS_COLOR_ID = "JOB_STATE_1_STATUS_COLOR_ID";
        public const string JOB_STATE_2_STATUS_ANIMATION_ID = "JOB_STATE_2_STATUS_ANIMATION_ID";
        public const string JOB_STATE_2_STATUS_COLOR_ID = "JOB_STATE_2_STATUS_COLOR_ID";
        public const string JOB_STATE_REWORK_STATUS_ANIMATION_ID = "JOB_STATE_REWORK_STATUS_ANIMATION_ID";
        public const string JOB_STATE_REWORK_STATUS_COLOR_ID = "JOB_STATE_REWORK_STATUS_COLOR_ID";

        public const ushort waitStateAnimationIDAdres = 6302;
        public const ushort waitStateColorIDAdres = 6303;
        public static ushort waitStateAnimationID;
        public static ushort waitStateColorID;

        public const ushort mispickStateAnimationIDAdres = 6313;
        public const ushort mispickStateColorIDAdres = 6314;
        public static ushort mispickStateAnimationID;
        public static ushort mispickStateColorID;

        public const ushort jobState1StatusAnimationIDAdres = 6324;
        public const ushort jobState1StatusColorIDAdres = 6325;
        public static ushort jobState1StatusAnimationID;
        public static ushort jobState1StatusColorID;

        public const ushort jobState2StatusAnimationIDAdres = 8702;
        public const ushort jobState2StatusColorIDAdres = 8703;
        public static ushort jobState2StatusAnimationID;
        public static ushort jobState2StatusColorID;

        public const ushort jobStateReworkAnimationIDAdres = 8702;
        public const ushort jobStateReworkColorIDAdres = 8703;
        public static ushort jobStateReworkAnimationID;
        public static ushort jobStateReworkColorID;

        public const string LOCK_STATE = "LOCK_STATE";


        public static float TeleMailSirasi;
        public static string ModelKodu;
        public static string SpecKodu;
        public static string YonBilgisi;
        public static string TBTDOORSpecKodu;
        public static string TBTDOORSpecNo;
        public static string DoorBarcode;
        public static uint BarkodID;
        public static string Type;
        public static string Model;
        public static ushort SetCount;
        public static uint dollyRafBilgisi;

        public const string FR_LH = "FR_LH";
        public const string RR_LH = "RR_LH";
        public const string FR_RH = "FR_RH";
        public const string RR_RH = "RR_RH";

        public string yonBilgisiBul(byte kod)
        {
            string sonuc = "";
            if (kod == 6)
            {
                sonuc = FR_LH;
            }
            else if (kod == 7)
            {
                sonuc = FR_RH;
            }
            else if (kod == 8)
            {
                sonuc = RR_LH;
            }
            else if (kod == 9)
            {
                sonuc = RR_RH;
            }
            return sonuc;
        }

        public static bool kilitKapatTetik;
        public static uint kilitKapatmaSuresi;
        public static uint kilitZamanAsimi;
        public static uint kilitKapatmaDenemeSayisi;
        public static uint buzzerMispickSuresi;

        public static bool deviceAlarmVar;
        public static bool motorRun;
        public static bool lockOnSensor;
        public static bool lockOffSensor;
        public static bool lockOnClick;
        public static bool lockOffClick;
        public static int timer;
        public static int count;

        public static bool xByPass;
        public static bool xKilitMekanizmasiByPass;
        public static bool xBuzzerByPass;
        public static bool urunBarkodKarkasDurum;

        public static string haberlesmeMesajModbusRTU;

        public static string loopInfoMain;

        public static uint gorevID;


        public static int geriSayimDegeri;

        public static string geriSayimKapi;

    }
}
