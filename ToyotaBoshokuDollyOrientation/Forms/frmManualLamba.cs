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
    public partial class frmManualLamba : Form
    {
        public frmManualLamba()
        {
            InitializeComponent();
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmManual);
        }
        KarkasIslem karkasIslem = new KarkasIslem();
        private void frmManualLamba_Load(object sender, EventArgs e)
        {

        }
        delegate void delDurumIzleme();

        public void DurumIzleme()
        {
            this.Invoke(new delDurumIzleme(durumIzleme), new object[] { });
        }
        List<uint> list;

        private void durumIzleme()
        {
            barkodIslem urunBarkod = new barkodIslem();

            //ddBarkods.DataSource=urunBarkod.barkodsListLH();
            ddBarkods.DisplayMember = "_BarkodsID ";
            ddBarkods.ValueMember = "_Barkod";
            ddBarkods.SelectedIndex = -1;

            //ddSira.Items.Clear();
            int[] sira = new int[20];
            for (int i = 0; i < 20; i++)
            {
                //ddSira.Items.Add( (i + 1).ToString()); 
            }
            //ddBolme.Items.Clear();
            //ddBolme.Items.Add("A");
            //ddBolme.Items.Add("B");

           // ddIsikliBolme.SelectedItem = "LH";

            list = new List<uint>();
            if (cGenel.MAKINE_ADI==cGenel.MAKINE_ADI_LH)
            {
                list = karkasIslem.dollyPickToLightIzleme_LH();
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                list = karkasIslem.dollyPickToLightIzleme_RH();
            }

            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    if ((item.Name.Substring(0, 16) == "btnLHPickToLight")&& list.Count>0)
                    {
                        try
                        {
                            int i = (int.Parse)(item.Name.Substring(16));
                            durumIzlemeButonRenk(item, list[i - 31]);
                            item.Click += new EventHandler(dinamikMetod);
                        }
                        catch (Exception)
                        {
                      
                           
                        }
                    }
                }
            }


        }

        private void durumIzlemeButonRenk(Control btn, uint barkodDurum)
        {
            if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumYok)
            {
                btn.BackColor = Color.White;

            }
            else if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde)
            {
                btn.BackColor = Color.Green;

            }
            else if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework)
            {
                btn.BackColor = Color.Yellow;

            }
 
        }

        private void durumIzlemeRB( byte barkodDurum)
        {
            if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumYok)
            {
                rbIslemYok.Checked = true;
                rbDollyde.Checked = false;
        
            }
            else if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde)
            {
                rbIslemYok.Checked = false;
                rbDollyde.Checked = true;
 

            }
            else if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework)
            {
                rbIslemYok.Checked = false;
                rbDollyde.Checked = false;
            }
  
        }



        protected void dinamikMetod(object sender, EventArgs e)
        {


           /* dinamikButon = (sender as Button);

            if ((dinamikButon.Name.Substring(0, 16) == "btnLHPickToLight"))
            {
                uint i = (uint.Parse)(dinamikButon.Name.Substring(16));

                barkodIslem urunbarkod = new barkodIslem();
                cLambaKontrol lambaKontrol = new cLambaKontrol();
                string rafAdi= lambaKontrol.deviceIDRafBul(i);//PARTITION_1A
                rafAdi = rafAdi.Substring(10, rafAdi.Length - 10);//1A
                uint raf =Convert.ToUInt32(rafAdi.Substring(0, rafAdi.Length - 1));//1
                string bolme = "";
                if (rafAdi.Length==2)
                {
                     bolme = rafAdi.Substring(1,1);//A
                }
                else if (rafAdi.Length == 3)
                {
                     bolme = rafAdi.Substring(2,1);//A
                }
                try
                {
                    ddSira.SelectedItem = Convert.ToString(raf); ;
                    ddBolme.SelectedItem = bolme.ToString();
                   
                     byte sta=Convert.ToByte(urunbarkod.barkodRafBul(raf, bolme,"LH")._Status);
                    durumIzlemeRB(sta);

                    ddBarkods.SelectedValue = urunbarkod.barkodRafBul(raf, bolme,"LH")._Barkod;


                }
                catch (Exception)
                {

                  
                }
            }*/


        }

        private void bunifuCustomLabel42_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton41_Click(object sender, EventArgs e)
        {

        }
    }
}
