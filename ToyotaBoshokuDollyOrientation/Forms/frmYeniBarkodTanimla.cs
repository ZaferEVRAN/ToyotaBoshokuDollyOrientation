using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace ToyotaBoshokuDollyOrientation
{
    public partial class frmYeniBarkodTanimla : Form
    {
        public frmYeniBarkodTanimla()
        {
            InitializeComponent();
        }
        cGenel global = new cGenel();
        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmManual);
        }

        private void frmYeniBarkodTanimla_Load(object sender, EventArgs e)
        {
            // btn1.Click += new EventHandler(islem);
            // btn2.Click += new EventHandler(islem);
            // btn3.Click += new EventHandler(islem);
            // btn4.Click += new EventHandler(islem);
            // btn5.Click += new EventHandler(islem);
            // btn6.Click += new EventHandler(islem);
            // btn7.Click += new EventHandler(islem);
            // btn8.Click += new EventHandler(islem);
            // btn9.Click += new EventHandler(islem);
            // btn0.Click += new EventHandler(islem);
            // 
            // btnB.Click += new EventHandler(islem);
            // btnA.Click += new EventHandler(islem);
            //barkodsList();
            CheckForIllegalCrossThreadCalls = false;
        }
        bool FocedtxtBarkod;
        bool FocedtxtSequence;
        bool FocedtxtPartition;
        private void islem(Object sender, EventArgs e)
        {

          

            if (FocedtxtBarkod)
            {
                klavyeOlustur(sender, e, txtBarkod);
            }
            if (FocedtxtSequence)
            {
               // klavyeOlustur(sender, e, txtSequence);
            }
            if (FocedtxtPartition)
            {
                klavyeOlustur(sender, e, txtSpec);
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

        public void barkodsList()
        {
            SPECK_INFO barkod = new SPECK_INFO();
            if (this.InvokeRequired) //Forma gelen talebin farklı bir iş parçacığından gelip gelmediği kontrol ediliyor.
            {
                //Eğer farklı bir iş parçacığından talep gelmişse aşağıdaki Invoke metoduyla işlem gerçekleştiriliyor.
                this.Invoke((MethodInvoker)delegate ()
                {
                  
                   barkod.barkodsList(dataGridBarkods);
                  // var lst = (from s in list
                  //            select new { BARKOD = s._Barkod, MODEL = s._Model, SPEC = s._Spec, YON = s._Direction }).ToList();

                   // dataGridBarkods.DataSource = list;

                });
            }
           
        }

        private void btnBarkodSearch_Click(object sender, EventArgs e)
        {
            SPECK_INFO barkod = new SPECK_INFO();
            barkod._Barkod = txtBarkod.Text.Trim();


            if (barkod.speckInfoSearch(barkod._Barkod)._Barkod!=null)
            {
                   barkod = barkod.speckInfoSearch(barkod._Barkod);
                    txtModel.Text = barkod._Model;
                    txtSpec.Text = barkod._Spec;
                    cBDireciton.SelectedItem= barkod._Direction;
                    pictureBox1.Image = barkod.bitmap;
                    resim = barkod.speckInfoSearch(barkod._Barkod)._Resim;
            }
            else
            {
                cGenel.genelUyari("Ürün barkod bulunamadı!", false);
            }

            
        }
        SPECK_INFO barkodAdd = new SPECK_INFO();
        private void btnAccept_Click(object sender, EventArgs e)
        {
            
            barkodAdd._Barkod = txtBarkod.Text;
            barkodAdd._Model = txtModel.Text;
            barkodAdd._Spec =txtSpec.Text;
            barkodAdd._Direction = cBDireciton.SelectedItem.ToString();
         
                bool result = barkodAdd.speckInfoAdd(barkodAdd, resim);
                if (result)
                {
                    cGenel.genelUyari("Ürün barkod ekleme başarılı!", false);
                // barkodsList();
                asenkronLoad();
                }
                else
                {
                    cGenel.genelUyari("Ürün barkod ekleme başarısız!", false);
                }
            
        
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (FocedtxtBarkod)
            {
               txtBarkod.Clear();
            }
            if (FocedtxtSequence)
            {

                //txtSequence.ResetText();
            }
            if (FocedtxtPartition)
            {
               
                txtSpec.Clear();
            }
        }

        private void txtBarkod_Click(object sender, EventArgs e)
        {
            FocedtxtBarkod = true;
            FocedtxtSequence = false;
            FocedtxtPartition = false;
        }

        private void txtSequence_Click(object sender, EventArgs e)
        {
            FocedtxtBarkod = false;
            FocedtxtSequence = true;
            FocedtxtPartition = false;
        }

        private void txtPartition_Click(object sender, EventArgs e)
        {
            FocedtxtBarkod = false;
            FocedtxtSequence = false;
            FocedtxtPartition = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SPECK_INFO barkod = new SPECK_INFO();
  

                 barkod._Barkod = barkod.speckInfoSearch(txtBarkod.Text)._Barkod;
       
                bool result = barkod.speckInfoDelete(barkod._Barkod);
                if (result)
                {
                    cGenel.genelUyari("Ürün barkod silme başarılı!", false);
                //barkodsList();
                asenkronLoad();
                }
                else
                {
                    cGenel.genelUyari("Ürün barkod silme başarısız!", false);
                }
           
        }

        public void temizle()
        {
            txtBarkod.Clear();
            txtSpec.Clear();

        }

        private void btntxtBarkodSingleClear_Click(object sender, EventArgs e)
        {
            global.textSingleClear(txtBarkod);
        }
        string resimPath;
        byte[] resim;
        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Aç";

            openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg|Gif Dosyası (*.gif)|*.gif|Png Dosyası (*.png)|*.png|Tif Dosyası (*.tif)|*.tif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {//www.gorselprogramlama.com

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                resimPath = openFileDialog1.FileName.ToString();

                //Resimimizi FileStream metoduyla okuma modunda açıyoruz.

                FileStream fs = new FileStream(resimPath, FileMode.Open, FileAccess.Read);

                //BinaryReader ile byte dizisi ile FileStream arasında veri akışı sağlanıyor.

                BinaryReader br = new BinaryReader(fs);

                /*ReadBytes ile FileStreamde belirtilen resim dosyasındaki byte lar

                byte dizisine aktarılıyor.

                */

                resim = br.ReadBytes((int)fs.Length);//www.gorselprogramlama.com

                br.Close();

                fs.Close();
            }

        }

        private void cBDireciton_SelectedIndexChanged(object sender, EventArgs e)
        {
            barkodAdd._Direction = cBDireciton.SelectedText;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            barkodAdd._Barkod = txtBarkod.Text;
            barkodAdd._Model = txtModel.Text;
            barkodAdd._Spec = txtSpec.Text;
            barkodAdd._Direction = cBDireciton.SelectedItem.ToString();

            bool result = barkodAdd.speckInfoUpdate(barkodAdd, resim);
            if (result)
            {
                cGenel.genelUyari("Ürün barkod güncelleme başarılı!", false);
                //barkodsList();
                asenkronLoad();
            }
            else
            {
                cGenel.genelUyari("Ürün barkod güncelleme başarısız!", false);
            }


        }

        private void dataGridBarkods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtModel.Clear();
            txtSpec.Clear();
             SPECK_INFO barkod = new SPECK_INFO();
            barkod._Barkod = dataGridBarkods.SelectedCells[0].Value.ToString();
            txtBarkod.Text = barkod._Barkod;
            barkod = barkod.speckInfoSearch(barkod._Barkod);
            txtModel.Text = barkod._Model;
            txtSpec.Text = barkod._Spec;
            cBDireciton.SelectedItem = barkod._Direction;
            pictureBox1.Image = barkod.bitmap;
            resim = barkod.speckInfoSearch(barkod._Barkod)._Resim;
        }

        private void btnKlavye_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("osk.exe");
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            //barkodsList();
            asenkronLoad();
        }

        delegate void AsenkronHandler();
        public void asenkronLoad()
        {

            AsenkronHandler asenkron = new AsenkronHandler(barkodsList);
            asenkron.BeginInvoke(new AsyncCallback(Y), this);
            /*BeginInvoke metodu 1. parametresinde, AsyncCallback delegesinden, geriye dönüş
            tipi olmayan ve IAsyncResult tipinden parametre alan bir metod istiyor.
            IAsyncResult tipinden parametre alan Y() metodunu yazıp ben BeginInvoke
            metodunun 1. parametresine gördüğünüz gibi yazıyorum.2. parametresine ise,
            this(yani bu formu) gönderiyorum.Buraya gönderilen object değer,Y metodunun
            IAsyncResult tipinden olan dd adlı parametresine gönderilecektir.
            */

            try
            {



            }
            catch (Exception)
            {



            }
        }
        void Y(IAsyncResult dd)
        {
            progressBar1.Value = 100;
            /*Bu metoddaki IAsyncResult tipinden dd parametresine gelen değer,
            AsyncState özelliğinden elde edilebilir.*/
        }
    }
    
}
