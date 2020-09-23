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
    public partial class frmKullaniciSayfasi : Form
    {
        public frmKullaniciSayfasi()
        {
            InitializeComponent();
        }
        cGenel global = new cGenel();
        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmManual);
        }
        cUsers usersNewAdd = new cUsers();
        cMesajlar mesajlar = new cMesajlar();
        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            

            usersNewAdd._Name = txtKullaniciOlusturAd.Text;
            usersNewAdd._Surname = txtKullaniciOlusturSoyad.Text;
            usersNewAdd._GrupID = usersNewAdd._GrupID;
            usersNewAdd._Username = txtKullaniciOlusturKullaniciAdi.Text;     
            // // Hash
            var parola = SecurePasswordHasher.Hash(txtKullaniciOlusturSifre.Text);
            usersNewAdd._Password = parola.ToString();
            if (usersNewAdd.userInfo(usersNewAdd._Username)._UserID==0)
            {
                bool result = usersNewAdd.userNewAdd();
                if (result)
                {
                    cGenel.genelUyari("Kullanıcı ekleme başarılı!", false);
                    txtKullaniciOlusturAd.Clear();
                    txtKullaniciOlusturKullaniciAdi.Clear();
                    txtKullaniciOlusturSoyad.Clear();
                    txtKullaniciOlusturSifre.Clear();
                    dropdownsUpdate();
                }
                else
                {
                    cGenel.genelUyari("Kullanıcı ekleme başarısız!", false);
                }
            }
            else
            {
                cGenel.genelUyari("Kullanıcı adı kullanımıştır!", false);
            } 
        }

        private void btnEkranKlavyesi_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void frmKullaniciSayfasi_Load(object sender, EventArgs e)
        {
            dropdownsUpdate();
            if (cGenel._OpenSessionGRUPNAME=="MAVI"|| cGenel._OpenSessionGRUPNAME == "KIRMIZI" || cGenel._OpenSessionGRUPNAME == "BEYAZ")
            {

                grpKullaniciDuzenle.Visible = false;
                grpKullaniciOlustur.Visible = false;
                grGrupIslemleri.Visible = false;
            }
        }

        public void dropdownsUpdate()
        {
            cUserGrups p = new cUserGrups();

            dBKullaniciOlusturKullaniciGrup.DataSource = p.userGrupsList();
            dBKullaniciOlusturKullaniciGrup.DisplayMember = "_GrupID ";
            dBKullaniciOlusturKullaniciGrup.ValueMember = "_Definition";
            dBKullaniciOlusturKullaniciGrup.SelectedIndex = -1;

            dbGrupIslemKullanicilar.DataSource = p.userGrupsListSuperUserandAdmin();
            dbGrupIslemKullanicilar.DisplayMember = "_GrupID ";
            dbGrupIslemKullanicilar.ValueMember = "_Definition";
            dbGrupIslemKullanicilar.SelectedIndex = -1;

            ddUserEditUserGrup.DataSource = p.userGrupsList();
            ddUserEditUserGrup.DisplayMember = "_GrupID ";
            ddUserEditUserGrup.ValueMember = "_Definition";
            ddUserEditUserGrup.SelectedIndex = -1;

            cUsers u = new cUsers();
            ddUserEditKullanicilar.DataSource = u.usersList();
            ddUserEditKullanicilar.DisplayMember = "_UserID ";
            ddUserEditKullanicilar.ValueMember = "_Username";
            ddUserEditKullanicilar.SelectedIndex = -1;   
        }

        private void dBKullanıcıGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUserGrups p = (cUserGrups)dBKullaniciOlusturKullaniciGrup.SelectedItem;

            try
            {
                usersNewAdd._GrupID = p._GrupID;
            }
            catch (Exception)
            {

              
            }
        }

        private void dbGrupIslemKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUserGrups p = (cUserGrups)dbGrupIslemKullanicilar.SelectedItem;

            try
            {
                txtGrupIslemlerGrup.Text = p._Definition;
            }
            catch (Exception)
            {

                
            }
        }

        private void btnGrupAdd_Click(object sender, EventArgs e)
        {
            cUserGrups cUserGrups = new cUserGrups();
            cUserGrups._Definition = txtGrupIslemlerGrup.Text;
            if (cUserGrups.userGrupInfo(cUserGrups._Definition)._GrupID==0)
            {
               bool result= cUserGrups.userGrupNewAdd();
                if (result)
                {
                    cGenel.genelUyari("Grup ekleme başarılı!", false);
                    txtGrupIslemlerGrup.Clear();
                    dropdownsUpdate();
                }
                else
                {
                    cGenel.genelUyari("Grup ekleme başarısız!", false);
                }
            }
            else
            {
                cGenel.genelUyari("Girilen grup tanımından bulunmaktadır.",false);
            }


        }

        private void btnGrupIslemlerGrupDelete_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtGrupIslemlerGrup);
        }

        private void btnGrupUpdate_Click(object sender, EventArgs e)
        {
            cUserGrups UserGrups = new cUserGrups();
            UserGrups._Definition = txtGrupIslemlerGrup.Text;
       
            cUserGrups p = (cUserGrups)dbGrupIslemKullanicilar.SelectedItem;
            try
            {
                UserGrups._GrupID = p._GrupID;
            }
            catch (Exception)
            {


            }
            if (UserGrups._GrupID > 0)
            {

                if (UserGrups.userGrupInfo(UserGrups._Definition)._GrupID == 0)
                {
                    bool result = UserGrups.userGrupUpdate();
                    if (result)
                    {
                        cGenel.genelUyari("Grup güncelleme başarılı!", false);
                        dropdownsUpdate();
                        txtGrupIslemlerGrup.Clear();
                    }
                    else
                    {
                        cGenel.genelUyari("Grup güncelleme başarısız!", false);
                    }
                    dropdownsUpdate();
                }
                else
                {
                    cGenel.genelUyari("Girilen grup tanımından bulunmaktadır.", false);
                }
            }
            else
            {
                cGenel.genelUyari("Girilen grup tanımından bulunmaktadır.", false);
            }
        }

        private void btnGrupDelete_Click(object sender, EventArgs e)
        {
            cUserGrups UserGrups = new cUserGrups();
            cUserGrups p = (cUserGrups)dbGrupIslemKullanicilar.SelectedItem;
            try
            {
                UserGrups._GrupID = p._GrupID;
            }
            catch (Exception)
            {


            }
            if (UserGrups._GrupID > 0)
            {

              bool result=  UserGrups.userGrupDelete();
                if (result)
                {
                    cGenel.genelUyari("Grup silme başarılı!", false);
                    dropdownsUpdate();
                    txtGrupIslemlerGrup.Clear();
                    dbGrupIslemKullanicilar.SelectedValue = "";
                }
                else
                {
                    cGenel.genelUyari("Grup silme başarısız!", false);
                }
                dropdownsUpdate();
            }
            else
            {
                cGenel.genelUyari("Girilen grup tanımından bulunmaktadır.", false);
            }
        }

        private void btnKullaniciOlusturAdSil_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtKullaniciOlusturAd);
        }

        private void btnKullaniciOlusturSoyadSil_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtKullaniciOlusturSoyad);
        }

        private void btnKullaniciOlusturKullaniciAdiSil_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtKullaniciOlusturKullaniciAdi);
        }

        private void btnKullaniciOlusturParolaSil_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtKullaniciOlusturSifre);
        }

        private void btnKullaniciOluturSifreGoster_Click(object sender, EventArgs e)
        {
            txtKullaniciOlusturSifre.PasswordChar = '\0';
            btnKullaniciOluturSifreGoster.Visible = false;
        }

        private void btnKullaniciOlusturSifreGizle_Click(object sender, EventArgs e)
        {
            txtKullaniciOlusturSifre.PasswordChar = '*';
            btnKullaniciOluturSifreGoster.Visible = true;
        }

        private void btnSifreIslemleritxtSifreSil_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtSifreIslemleriEskiSifre);
        }

        private void btnSifreIslemleritxtYeniSifreSil_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtSifreIslemleriYeniSifre);
        }

        private void btnSifreIslemleritxtYeniSifreTekrarSil_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtSifreIslemleriYeniSifreTekrar);
        }

        private void btnSifreIslemleriEskiSifreGoster_Click(object sender, EventArgs e)
        {
            txtSifreIslemleriEskiSifre.PasswordChar = '\0';
            btnSifreIslemleriEskiSifreGoster.Visible = false;
        }

        private void btnSifreIslemleriEskiSifreGizle_Click(object sender, EventArgs e)
        {
            txtSifreIslemleriEskiSifre.PasswordChar = '*';
            btnSifreIslemleriEskiSifreGoster.Visible = true;

        }

        private void btnSifreIslemleriYeniSifreGoster_Click(object sender, EventArgs e)
        {
            txtSifreIslemleriYeniSifre.PasswordChar = '\0';
            btnSifreIslemleriYeniSifreGoster.Visible = false;
        }

        private void btnSifreIslemleriYeniSifreGizle_Click(object sender, EventArgs e)
        {
            txtSifreIslemleriYeniSifre.PasswordChar = '*';
            btnSifreIslemleriYeniSifreGoster.Visible = true;
        }

        private void btnSifreIslemleriTekrarYeniSifreGoster_Click(object sender, EventArgs e)
        {
            txtSifreIslemleriYeniSifreTekrar.PasswordChar = '\0';
            btnSifreIslemleriTekrarYeniSifreGoster.Visible = false;
        }

        private void btnSifreIslemleriYeniSifreTekrarGizle_Click(object sender, EventArgs e)
        {
            txtSifreIslemleriYeniSifreTekrar.PasswordChar = '*';
            btnSifreIslemleriTekrarYeniSifreGoster.Visible = true;
        }

        private void btnSifreIslemleriSifreDegistir_Click(object sender, EventArgs e)
        {
            cUsers user = new cUsers();

            try
            {
                string oldPasswordHash = user.usersIDInfo(cGenel._OpenSessionID)._Password;

                var hash = SecurePasswordHasher.Verify(txtSifreIslemleriEskiSifre.Text.Trim(), oldPasswordHash);
                if (hash)
                {
                    if (txtSifreIslemleriYeniSifre.Text.Trim() == txtSifreIslemleriYeniSifreTekrar.Text.Trim())
                    {
                        string newPassword = SecurePasswordHasher.Hash(txtSifreIslemleriYeniSifre.Text.Trim());
                        bool result = user.passwordChange(cGenel._OpenSessionID, newPassword);

                        if (result)
                        {

                            cGenel.genelUyari("Parola değiştirme başarılı!", false);
                            txtSifreIslemleriEskiSifre.Clear();
                            txtSifreIslemleriYeniSifre.Clear();
                            txtSifreIslemleriYeniSifreTekrar.Clear();
                        }
                        else
                        {
                            cGenel.genelUyari("Parola değiştirme başarısız!", false);
                        }
                    }
                    else
                    {
                        cGenel.genelUyari("Yeni parola ve tekrar parola eşleşmiyor!", false);
                    }

                }
                else
                {
                    cGenel.genelUyari("Eski parolaınız yanlış girdiniz!", false);
                }
            }
            catch (Exception)
            {

              
            }
           
        }

        private void btnKullaniciDuzenlemeAdSil_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtlKullaniciDuzenlemeAd);
        }

        private void btnKullaniciDuzenlemeSoyadSil_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtlKullaniciDuzenlemeSoyad);
        }

        private void btnKullaniciDuzenlemeKullaniciAdiSil_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtlKullaniciDuzenlemeKullaniciAdi);
        }
        cUsers usersEdit = new cUsers();
        private void dPGuncelKullaniciGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUserGrups p = (cUserGrups)dBKullaniciOlusturKullaniciGrup.SelectedItem;

            try
            {
                usersEdit._GrupID = p._GrupID;
            }
            catch (Exception)
            {


            }
        }

        private void dbKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUsers p = (cUsers)ddUserEditKullanicilar.SelectedItem;

            try
            {
                txtlKullaniciDuzenlemeAd.Text = p._Name;
                txtlKullaniciDuzenlemeSoyad.Text = p._Surname;
                txtlKullaniciDuzenlemeKullaniciAdi.Text = p._Username;

                cUserGrups grup = new cUserGrups();
                
                ddUserEditUserGrup.SelectedValue = grup.userGrupsIDInfo(p._GrupID)._Definition;


            }
            catch (Exception)
            {


            }
        }
        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
          

            cUsers p = (cUsers)ddUserEditKullanicilar.SelectedItem;
            try
            {
                usersEdit._UserID = p._UserID;

                usersEdit._Name = txtlKullaniciDuzenlemeAd.Text;
                usersEdit._Surname = txtlKullaniciDuzenlemeSoyad.Text;
                usersEdit._Username = txtlKullaniciDuzenlemeKullaniciAdi.Text;

                cUserGrups u = (cUserGrups)ddUserEditUserGrup.SelectedItem;
                usersEdit._GrupID = u._GrupID;
               
                if (p.userInfo(usersEdit._Username)._UserID == 0||(p.userInfo(usersEdit._Username)._UserID == usersEdit._UserID))
                {
                 
                        bool result = usersEdit.userUpdate();
                        if (result)
                        {
                            cGenel.genelUyari("Kullanıcı güncelleme başarılı!", false);
                             txtlKullaniciDuzenlemeKullaniciAdi.Clear();
                            txtlKullaniciDuzenlemeSoyad.Clear();
                            txtlKullaniciDuzenlemeAd.Clear();
                            dropdownsUpdate();
                        }
                        else
                        {
                            cGenel.genelUyari("Kullanıcı güncelleme başarısız!", false);
                        }
                        dropdownsUpdate();
                    
                }
                else
                {
                    cGenel.genelUyari("Girilen Kullanıcı adı tanımından bulunmaktadır.", false);
                }
            }
            catch (Exception)
            {


            }
           

               
            
            
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {

            try
            {
                cUsers p = (cUsers)ddUserEditKullanicilar.SelectedItem;
                bool result = p.userDelete();
                if (result)
                {
                    cGenel.genelUyari("Kullanıcı silme başarılı!", false);
                    txtlKullaniciDuzenlemeKullaniciAdi.Clear();
                    txtlKullaniciDuzenlemeSoyad.Clear();
                    txtlKullaniciDuzenlemeAd.Clear();
                    dropdownsUpdate();
                    ddUserEditKullanicilar.SelectedValue="";
                }
                else
                {
                    cGenel.genelUyari("Kullanıcı silme başarısız!", false);
                }
                dropdownsUpdate();
            }
            catch (Exception)
            {

                
            }
        }
    }
}
