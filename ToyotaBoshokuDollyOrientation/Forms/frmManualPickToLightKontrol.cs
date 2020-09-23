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
    public partial class frmManualPickToLightKontrol : Form
    {
        public frmManualPickToLightKontrol()
        {
            InitializeComponent();
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmManual);
            sensorKontrolDongu.Enabled = false;
        }
        cLambaKontrol lamb = new cLambaKontrol();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cGenel.frmManualPickToLightKontrol.Visible==true)
            {
                lamb.activeDeviceID();

                cistemciKontrol_StepMotor step = new cistemciKontrol_StepMotor();
                step.kilitMekanizmaSensorOku();
                 if (cGenel.MAKINE_ADI==cGenel.MAKINE_ADI_LH)
                 {
                     btnRenk(cGenel.deviceIDSensor[0]);

                 }
                 else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
                 {
                     btnRenk(cGenel.deviceIDSensor[0]);
                 }

                if (cGenel.lockOffSensor==true)
                {
                    btnKilitKapaliSensor.BackColor = Color.Green;
                }
                else
                {
                    btnKilitKapaliSensor.BackColor = Color.Transparent;
                }

                if (cGenel.lockOnSensor == true)
                {
                    btnKilitAcikSensor.BackColor = Color.Green;
                }
                else
                {
                    btnKilitAcikSensor.BackColor = Color.Transparent;
                }
            }
        }

        private void btnRenk(ushort deviceID)
        {
            if (cGenel.deviceIDSensor[0]==0)
            {
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                            try
                            {
                                item.BackColor = Color.White;
                            }
                            catch (Exception)
                            {


                            }
                        
                    }

                }
            }
            else
            {
                string sbtn = string.Format("btnLHPickToLight{0}", deviceID);

                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if ((item.Name == sbtn))
                        {
                            try
                            {
                                item.BackColor = Color.Green;
                            }
                            catch (Exception)
                            {


                            }
                        }
                        else
                        {
                            try
                            {
                                item.BackColor = Color.White;
                            }
                            catch (Exception)
                            {


                            }
                        }
                    }

                }

            }
        }

        private void bunifuCustomLabel39_Click(object sender, EventArgs e)
        {

        }

        private void btnKilitAcik_Click(object sender, EventArgs e)
        {

        }
    }
}
