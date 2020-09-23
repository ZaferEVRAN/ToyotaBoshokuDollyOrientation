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
    public partial class frmModels : Form
    {
        public frmModels()
        {
            InitializeComponent();
        }
        cGenel global = new cGenel();
        
        public void formYukle()
        {
            models model = new models();
            dataGridModels.AutoGenerateColumns = true;
            var list= model.modelList();
            var lst = (from s in list
                       select new { MODELADI = s._MODELADI, KODU = s._MODELKODU, NO = s._MODELNO}).ToList();

            dataGridModels.DataSource = lst;

        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmManual);
        }

        private void btnKlavye_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void btntxtBarkodSingleClear_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtModelNo);
        }

        private void btnBarkodSearch_Click(object sender, EventArgs e)
        {
            models model = new models();
            model._MODELNO = txtModelNo.Text.Trim();


            if (model.speckInfoSearch(model._MODELNO)._MODELNO != null)
            {
                txtModelNo.Text = model.speckInfoSearch(model._MODELNO)._MODELNO;
                txtModelKodu.Text = model.speckInfoSearch(model._MODELNO)._MODELKODU;
                txtModelAdi.Text = model.speckInfoSearch(model._MODELNO)._MODELADI;

            }
            else
            {
                cGenel.genelUyari("Model bulunamadı!", false);
            }

        }

        private void dataGridModels_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            models model = new models();
            model._MODELNO = dataGridModels.SelectedCells[0].Value.ToString();
            txtModelNo.Text = model._MODELNO;
            txtModelKodu.Text = model.speckInfoSearch(model._MODELNO)._MODELKODU;
            txtModelAdi.Text = model.speckInfoSearch(model._MODELNO)._MODELADI;
        
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            models model = new models();
            model._MODELADI = txtModelAdi.Text;
            model._MODELKODU = txtModelKodu.Text;
            model._MODELNO = txtModelNo.Text;


            bool result = model.modelInfoAdd(model);
            if (result)
            {
                cGenel.genelUyari("Model ekleme başarılı!", false);
                formYukle();
            }
            else
            {
                cGenel.genelUyari("Model ekleme başarısız!", false);
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            models model = new models();
            model._MODELADI = txtModelAdi.Text;
            model._MODELKODU = txtModelKodu.Text;
            model._MODELNO = txtModelNo.Text;


            bool result = model.modelInfoUpdate(model);
            if (result)
            {
                cGenel.genelUyari("Model güncelleme başarılı!", false);
                formYukle();
            }
            else
            {
                cGenel.genelUyari("Model güncelleme başarısız!", false);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            models model = new models();


            model._MODELNO = model.speckInfoSearch(txtModelNo.Text)._MODELNO;

            bool result = model.modelInfoDelete(model._MODELNO);
            if (result)
            {
                cGenel.genelUyari("Model silme başarılı!", false);
                formYukle();
            }
            else
            {
                cGenel.genelUyari("Model silme başarısız!", false);
            }
        }

        private void frmModels_Load(object sender, EventArgs e)
        {
            formYukle();
        }
    }
}
