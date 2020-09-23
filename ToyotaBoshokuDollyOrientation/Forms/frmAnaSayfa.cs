using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
namespace ToyotaBoshokuDollyOrientation
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {         
            cGenel.frmMain.ViewForm(cGenel.frmPickToLight);
            cGenel.frmPickToLight.DurumIzleme();
        }

        private void btnLHPickToLight_Click(object sender, EventArgs e)
        {
            
      
    
            cGenel.frmMain.ViewForm(cGenel.frmPickToLight);

           cGenel.frmPickToLight.DurumIzleme();
        }

        private void btnLHDollyIzleme_Click(object sender, EventArgs e)
        {
           
                cGenel.frmMain.ViewForm(cGenel.frmDollyIzleme);

               cGenel.frmDollyIzleme.asenkronLoad();
        }

        private void btnLHManual_Click(object sender, EventArgs e)
        {        
            cGenel.frmMain.ViewForm(cGenel.frmManual);
        }

        private void btnLHKayitlar_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmKayitlar);
            cGenel.frmKayitlar.asenkronLoad();
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
         
        }
  

    }
}
