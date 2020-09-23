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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            baslamaZamani.Enabled = true; //timer nesnesini başlatıyoruz.
            progressBar1.Visible = true; //progressBar nesnesinin gözükmesini istiyorsanız bu değeri true yapabilirsiniz.

           // this.BackColor = Color.LimeGreen; //Bekletme ekranının saydam olması için BackColor ile TransparencyKey rengini aynı belirliyoruz.
           // this.TransparencyKey = Color.LimeGreen;
        }

        private void baslamaZamani_Tick(object sender, EventArgs e)
        {

            progressBar1.Value += 1;
            //lblLoad.Text = progressBar1.Value.ToString();
            if (progressBar1.Value == 100)
            {
                baslamaZamani.Stop();
                this.Close();
            }
        }
    }
}
