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
    public partial class frmKayitlar : Form
    {
        public frmKayitlar()
        {
            InitializeComponent();
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmAnasayfa);
        }
        public void listele()
        {
            log kayit = new log();

                if (this.InvokeRequired) //Forma gelen talebin farklı bir iş parçacığından gelip gelmediği kontrol ediliyor.
                {
                    //Eğer farklı bir iş parçacığından talep gelmişse aşağıdaki Invoke metoduyla işlem gerçekleştiriliyor.
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        kayit.log_Listele(dataGrid);
                    });
                }

            
        }
        delegate void AsenkronHandler();
        public void asenkronLoad()
        {

            AsenkronHandler asenkron = new AsenkronHandler(listele);
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
