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
    public partial class frmDollyIzleme : Form
    {
        public frmDollyIzleme()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmAnasayfa);
        }

        private void frmDollyIzleme_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dollyListele()
        {
            KarkasIslem karkas = new KarkasIslem();
           // List<KarkasIslem> list = new List<KarkasIslem>();
            if (cGenel.MAKINE_ADI==cGenel.MAKINE_ADI_LH)
            {
                if (this.InvokeRequired) //Forma gelen talebin farklı bir iş parçacığından gelip gelmediği kontrol ediliyor.
                {
                    //Eğer farklı bir iş parçacığından talep gelmişse aşağıdaki Invoke metoduyla işlem gerçekleştiriliyor.
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        karkas.karkasTakip_LH(dataGrid);
                    });
                }
  
                    /*       var lst= (from s in list
                            select new { DOLLYNO = s._DOLLYNO, STARTDATE = s._STARTDATE, STARTTIME = s._STARTTIME,
                           FR1 = s._FR_LH_1_BARKOD,
                           RR1 = s._RR_LH_1_BARKOD,
                           FR2 = s._FR_LH_2_BARKOD,
                           RR2 = s._RR_LH_2_BARKOD,
                           FR3 = s._FR_LH_3_BARKOD,
                           RR3 = s._RR_LH_3_BARKOD,
                           FR4 = s._FR_LH_4_BARKOD,
                           RR4 = s._RR_LH_4_BARKOD,
                           FR5 = s._FR_LH_5_BARKOD,
                           RR5 = s._RR_LH_5_BARKOD,
                           FR6 = s._FR_LH_6_BARKOD,
                           RR6 = s._RR_LH_6_BARKOD,
                           FR7 = s._FR_LH_7_BARKOD,
                           RR7 = s._RR_LH_7_BARKOD,
                           FR8 = s._FR_LH_8_BARKOD,
                           RR8 = s._RR_LH_8_BARKOD,
                           FR9 = s._FR_LH_9_BARKOD,
                           RR9 = s._RR_LH_9_BARKOD,
                           FR10 = s._FR_LH_10_BARKOD,
                           RR10 = s._RR_LH_10_BARKOD,
                           FINISHDATE = s._FINISHDATE,
                           FINISHTIME = s._FINISHTIME

                       }).ToList();
             


               dataGrid.DataSource = lst;*/
            }
            else if (cGenel.MAKINE_ADI==cGenel.MAKINE_ADI_RH)
            {
                if (this.InvokeRequired) //Forma gelen talebin farklı bir iş parçacığından gelip gelmediği kontrol ediliyor.
                {
                    //Eğer farklı bir iş parçacığından talep gelmişse aşağıdaki Invoke metoduyla işlem gerçekleştiriliyor.
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        karkas.karkasTakip_RH(dataGrid);
                    });
                }
            

                /* var lst = (from s in list
                       select new
                       {
                           DOLLYNO = s._DOLLYNO,
                           STARTDATE = s._STARTDATE,
                           STARTTIME = s._STARTTIME,
                           FR1 = s._FR_RH_1_BARKOD,
                           RR1 = s._RR_RH_1_BARKOD,
                           FR2 = s._FR_RH_2_BARKOD,
                           RR2 = s._RR_RH_2_BARKOD,
                           FR3 = s._FR_RH_3_BARKOD,
                           RR3 = s._RR_RH_3_BARKOD,
                           FR4 = s._FR_RH_4_BARKOD,
                           RR4 = s._RR_RH_4_BARKOD,
                           FR5 = s._FR_RH_5_BARKOD,
                           RR5 = s._RR_RH_5_BARKOD,
                           FR6 = s._FR_RH_6_BARKOD,
                           RR6 = s._RR_RH_6_BARKOD,
                           FR7 = s._FR_RH_7_BARKOD,
                           RR7 = s._RR_RH_7_BARKOD,
                           FR8 = s._FR_RH_8_BARKOD,
                           RR8 = s._RR_RH_8_BARKOD,
                           FR9 = s._FR_RH_9_BARKOD,
                           RR9 = s._RR_RH_9_BARKOD,
                           FR10 = s._FR_RH_10_BARKOD,
                           RR10 = s._RR_RH_10_BARKOD,
                           FINISHDATE = s._FINISHDATE,
                           FINISHTIME = s._FINISHTIME

                       }).ToList();



            dataGrid.DataSource = lst;*/
             

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        delegate void AsenkronHandler();
        public void asenkronLoad()
        {

            AsenkronHandler asenkron = new AsenkronHandler(dollyListele);
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
            progressBar1.Value=100;
            /*Bu metoddaki IAsyncResult tipinden dd parametresine gelen değer,
            AsyncState özelliğinden elde edilebilir.*/
        }
    }
}
