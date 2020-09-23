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
    public partial class frmYeniDollyTanımla : Form
    {
        public frmYeniDollyTanımla()
        {
            InitializeComponent();
        }
        cGenel global = new cGenel();
        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmManual);
        }

        private void frmYeniDollyTanımla_Load(object sender, EventArgs e)
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

            btnB.Click += new EventHandler(islem);
            btnA.Click += new EventHandler(islem);
        }

        bool FocedtxtDoolyBarkod;
        bool FocedtxtDollyNo;
        private void islem(Object sender, EventArgs e)
        {

        
            if (FocedtxtDoolyBarkod)
            {
                 klavyeOlustur(sender, e, txtDollyBarkod);
            }
            if (FocedtxtDollyNo)
            {
                klavyeOlustur(sender, e, txtDollyNo);
            }
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

                case "btnA":
                    txt.Text += ("A");
                    break;
                case "btnB":
                    txt.Text += ("B");
                    break;
                default:
                    break;
            }
        }

        private void btntxtBarkodSingleClear_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtDollyBarkod);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (FocedtxtDoolyBarkod)
            {

                txtDollyBarkod.ResetText();
            }
            if (FocedtxtDollyNo)
            {

                txtDollyNo.Clear();
            }
        }

        public void temizle()
        {
            txtDollyBarkod.Clear();
            txtDollyNo.Clear();
        }

        private void txtDollyBarkod_Click(object sender, EventArgs e)
        {
            FocedtxtDollyNo = false;
            FocedtxtDoolyBarkod = true;
        }

        private void txtDollyNo_Click(object sender, EventArgs e)
        {
            FocedtxtDollyNo = true;
            FocedtxtDoolyBarkod = false;
        }

        private void btnBarkodAra_Click(object sender, EventArgs e)
        {
            cDollys dolly = new cDollys();
            dolly._DollyBarkod = txtDollyBarkod.Text.Trim();

            if (dolly.dollyBarkodInfo(dolly._DollyBarkod)._DollyID>0)
            {
                
                txtDollyNo.Text = Convert.ToString(dolly.dollyBarkodInfo(dolly._DollyBarkod)._DollyNo);
            }
            else
            {
                cGenel.genelUyari("Dolly bulunamadı!", false);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cDollys dolly = new cDollys();
            dolly._DollyBarkod = txtDollyBarkod.Text;
            dolly._DollyNo = uint.Parse(txtDollyNo.Text);


            dolly._DollyID = dolly.dollyBarkodInfo(txtDollyBarkod.Text)._DollyID;
            if (dolly._DollyID == 0)
            {
                bool result = dolly.barkodsNewAddDolly(dolly);
                if (result)
                {
                    cGenel.genelUyari("Dolly ekleme başarılı!", false);
                    dollyList();
                }
                else
                {
                    cGenel.genelUyari("Dolly ekleme başarısız!", false);
                }
            }
            else
            {
                bool result = dolly.barkodsUpdateDolly(dolly);
                if (result)
                {
                    cGenel.genelUyari("Dolly güncelleme başarılı!", false);
                    dollyList();
                }
                else
                {
                    cGenel.genelUyari("Dolly güncelleme başarısız!", false);
                }
            }
        }

        public void dollyList()
        {

            cDollys dolly = new cDollys();
            var list = dolly.barkodsListDolly();
            var lst = (from s in list
                       select new { BARKOD = s._DollyBarkod, NO = s._DollyNo}).ToList();

            dataGridDollys.DataSource = lst;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cDollys dolly = new cDollys();


            dolly._DollyID = dolly.dollyBarkodInfo(txtDollyBarkod.Text)._DollyID;
            if (dolly._DollyID != 0)
            {
                bool result =dolly.barkodsDeleteDolly(dolly);
                if (result)
                {
                    cGenel.genelUyari("Dolly silme başarılı!", false);
                    dollyList();
                }
                else
                {
                    cGenel.genelUyari("Dolly silme başarısız!", false);
                }
            }
            else
            {
                cGenel.genelUyari("Dolly bulunamadı!", false);
            }
        }
    }
}
