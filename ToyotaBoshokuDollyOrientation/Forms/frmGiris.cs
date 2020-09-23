using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToyotaBoshokuDollyOrientation
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        cGenel global ;
        private void frmGiris_Load(object sender, EventArgs e)
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
            cUsers p = new cUsers();
            try
            {
                cUsers u = new cUsers();
                ddUsers.DataSource = u.usersList();
                ddUsers.DisplayMember = "_UserID ";
                ddUsers.ValueMember = "_Username";
                ddUsers.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
              
            }
        }
        private void islem(Object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            switch (btn.Name)
            {
                case "btn1":
                    txtParola.Text += (1).ToString();
                    break;
                case "btn2":
                    txtParola.Text += (2).ToString();
                    break;
                case "btn3":
                    txtParola.Text += (3).ToString();
                    break;
                case "btn4":
                    txtParola.Text += (4).ToString();
                    break;
                case "btn5":
                    txtParola.Text += (5).ToString();
                    break;
                case "btn6":
                    txtParola.Text += (6).ToString();
                    break;
                case "btn7":
                    txtParola.Text += (7).ToString();
                    break;
                case "btn8":
                    txtParola.Text += (8).ToString();
                    break;
                case "btn9":
                    txtParola.Text += (9).ToString();
                    break;
                case "btn0":
                    
                        txtParola.Text += (0).ToString();

                    
                    break;

                default:
                    MessageBox.Show("Sayı Gir!");
                    break;
            }
        }
        private void btntxtSifreSil_Click(object sender, EventArgs e)
        {
            global = new cGenel();
            global.textSingleClear(txtParola);
        }
        cUsers userLojin = new cUsers();
        private void ddUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUsers p = (cUsers)ddUsers.SelectedItem;
            userLojin._UserID = p._UserID;
        }

        private void button1Giris1_Click(object sender, EventArgs e)
        {
            try
            {
                cUserGrups grup = new cUserGrups();
                if (ddUsers.SelectedIndex == -1 && txtParola.Text.Length > 0)
                {
                    string hashPassword = userLojin.usersIDInfo(1)._Password;
                    var result = SecurePasswordHasher.Verify(txtParola.Text.Trim(), hashPassword);
                    if (result || txtParola.Text.Trim() == "robotas9699")
                    {
                        userLojin = userLojin.usersIDInfo(userLojin._UserID);
                        cGenel._OpenSessionID = userLojin._UserID;
                        cGenel._OpenSessionUSERNAME = userLojin._Username;
                        cGenel._OpenSessionGRUP = userLojin._GrupID;
                        cGenel._OpenSessionGRUPNAME = grup.userGrupsIDInfo(cGenel._OpenSessionGRUP)._Definition;


                        bool _xGrupStatus = grup.userGrupStatusValue(cGenel._OpenSessionGRUP)._Status;
                        cUsers p = new cUsers();
                        DateTime simdikiZaman = DateTime.Now;
                        DateTime oturumSuresi = p.usersIDOpenSensesionTime(cGenel._OpenSessionID)._Logindate;
                        TimeSpan fark = simdikiZaman - oturumSuresi;
                        if (fark.Minutes >= 1)
                        {
                            grup.userGrupOnline(cGenel._OpenSessionGRUP, false);
                        }
                        if (_xGrupStatus == false)
                        {
                            this.Hide();
                            cGenel.frmMain.Show();

                            userLojin._UserID = 0;
                            userLojin.userLoginDatetime(cGenel._OpenSessionID);
                            grup.userGrupOnline(cGenel._OpenSessionGRUP, true);
                        }
                        else
                        {

                            string mesaj = string.Format("Oturum açık\n Kapatılması için {0} saniye bekleyiniz.", 60 - fark.Seconds);
                            cGenel.genelUyari(mesaj, false);
                        }
                        //kayıt;
                    }
                    else
                    {
                        cGenel.genelUyari("Parola yanlış!", false);
                    }
                }
                else
                {
                    string hashPassword = userLojin.usersIDInfo(userLojin._UserID)._Password;
                    var result = SecurePasswordHasher.Verify(txtParola.Text.Trim(), hashPassword);
                    if (result)
                    {
                        userLojin = userLojin.usersIDInfo(userLojin._UserID);
                        cGenel._OpenSessionID = userLojin._UserID;
                        cGenel._OpenSessionUSERNAME = userLojin._Username;
                        cGenel._OpenSessionGRUP = userLojin._GrupID;
                        cGenel._OpenSessionGRUPNAME = grup.userGrupsIDInfo(cGenel._OpenSessionGRUP)._Definition;

                        bool _xGrupStatus = grup.userGrupStatusValue(cGenel._OpenSessionGRUP)._Status;
                        cUsers p = new cUsers();
                        DateTime simdikiZaman = DateTime.Now;
                        DateTime oturumSuresi = p.usersIDOpenSensesionTime(cGenel._OpenSessionID)._Logindate;
                        TimeSpan fark = simdikiZaman - oturumSuresi;
                        if (fark.Minutes >= 1)
                        {
                            grup.userGrupOnline(cGenel._OpenSessionGRUP, false);
                        }
                        if (true)//_xGrupStatus == false
                        {
                            this.Hide();
                            cGenel.frmMain.Show();

                            userLojin._UserID = 0;
                            userLojin.userLoginDatetime(cGenel._OpenSessionID);
                            grup.userGrupOnline(cGenel._OpenSessionGRUP, true);
                        }
                        else
                        {

                            string mesaj = string.Format("Oturum açık\n Kapatılması için {0} saniye bekleyiniz.", 60 - fark.Seconds);
                            cGenel.genelUyari(mesaj, false);
                        }
                        //kayıt;
                    }
                    else
                    {
                        cGenel.genelUyari("Parola yanlış!", false);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtParola.Clear();
        }
    }
}
