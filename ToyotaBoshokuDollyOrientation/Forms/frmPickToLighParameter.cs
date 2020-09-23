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
  
    public partial class frmPickToLighParameter : Form
    {
        public frmPickToLighParameter()
        {
            InitializeComponent();
        }
        private string animationBul(ushort animationID)
        {
            string sonuc = "";
            if (animationID == 0)
            {
                sonuc = "Off";
            }
            else if (animationID == 1)
            {
                sonuc = "Steady";
            }
            else if (animationID == 2)
            {
                sonuc = "Flash";
            }
            return sonuc;
        }

        private string colorBul(ushort colorID)
        {
            string sonuc = "";
            if (colorID==0)
            {
                sonuc="Red";
            }
            else if (colorID == 1)
            {
                sonuc = "Green";
            }
            if (colorID == 2)
            {
                sonuc = "Yellow";
            }
            if (colorID == 3)
            {
                sonuc = "Blue";
            }
            if (colorID == 4)
            {
                sonuc = "Magenta";
            }
            if (colorID == 5)
            {
                sonuc = "Cyan";
            }
            if (colorID == 6)
            {
                sonuc = "White";
            }
            if (colorID == 7)
            {
                sonuc = "Amber";
            }
            if (colorID == 8)
            {
                sonuc = "Rose";
            }
            if (colorID == 9)
            {
                sonuc = "Lime Green";
            }
            if (colorID == 10)
            {
                sonuc = "Orange";
            }
            if (colorID == 11)
            {
                sonuc = "Sky Blue";
            }
            if (colorID == 12)
            {
                sonuc = "Violet";
            }
            if (colorID == 13)
            {
                sonuc = "Spring Green";
            }

            return sonuc;
        }

        cLambaKontrol lamba = new cLambaKontrol();
        cStatus status = new cStatus();
        private void btnWaitStateRead_Click(object sender, EventArgs e)
        {
            ushort[] value = new ushort[2];
              value=  lamba.lambaDefualtWaitStateRead();

            cbWaitStateAnimation.SelectedItem = animationBul(value[0]);

            cbWaitStateColor.SelectedItem = colorBul(value[1]);
        }

        private void btnWaitStateWrite_Click(object sender, EventArgs e)
        {
            if (cbWaitStateAnimation.SelectedIndex>-1&& cbWaitStateColor.SelectedIndex>-1)
            {
                ushort[] value = new ushort[2];
                value[0] = Convert.ToUInt16(cbWaitStateAnimation.SelectedIndex);
                value[1] = Convert.ToUInt16(cbWaitStateColor.SelectedIndex);

                lamba.lambaDefualtWaitStateWrite(value[0], value[1]);

                status.StatusUpdate(cGenel.WAIT_STATE_ANIMATION_ID, value[0]);
                status.StatusUpdate(cGenel.WAIT_STATE_COLOR_ID, value[1]);

                status.statusColorAta();
            }
            
        }

        private void btnWaitStateDefaultWrite_Click(object sender, EventArgs e)
        {
            lamba.lambaDefualtWaitDefaultStateWrite();


            status.StatusUpdate(cGenel.WAIT_STATE_ANIMATION_ID, 0);
            status.StatusUpdate(cGenel.WAIT_STATE_COLOR_ID, 0);

            status.statusColorAta();

        }

        private void frmPickToLighParameter_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmManual._frmPickToLighParameter = null;
        }
        private void rbWaitState_Click(object sender, EventArgs e)
        {

            lamba.waitJobStateChange(0);
        }
        private void rbWaitState_CheckedChanged(object sender, EventArgs e)
        {
            //lamba.waitJobStateChange(0);
        }
        private void rbJobState_Click(object sender, EventArgs e)
        {
            lamba.waitJobStateChange(1);
        }
        private void rbJobState_CheckedChanged(object sender, EventArgs e)
        {
           // lamba.waitJobStateChange(1);
        }

        private void btnMispickStateRead_Click(object sender, EventArgs e)
        {
            ushort[] value = new ushort[2];
            value = lamba.lambaDefualtMispickStateRead();

            cbMispickStateAnimation.SelectedItem = animationBul(value[0]);

            cbMispickStateColor.SelectedItem = colorBul(value[1]);
        }

        private void btnWaitMispickWrite_Click(object sender, EventArgs e)
        {
            if (cbMispickStateAnimation.SelectedIndex > -1 && cbMispickStateColor.SelectedIndex > -1)
            {
                ushort[] value = new ushort[2];
                value[0] = Convert.ToUInt16(cbMispickStateAnimation.SelectedIndex);
                value[1] = Convert.ToUInt16(cbMispickStateColor.SelectedIndex);

                lamba.lambaDefualtMispickStateWrite(value[0], value[1]);

                status.StatusUpdate(cGenel.MISPICK_STATE_ANIMATION_ID, value[0]);
                status.StatusUpdate(cGenel.MISPICK_STATE_COLOR_ID, value[1]);

                status.statusColorAta();
            }
        }

        private void btnMispickStateDefaultWrite_Click(object sender, EventArgs e)
        {
            lamba.lambaDefualtMispickStateDefaultStateWrite();


            status.StatusUpdate(cGenel.WAIT_STATE_ANIMATION_ID, 2);
            status.StatusUpdate(cGenel.WAIT_STATE_COLOR_ID, 0);

            status.statusColorAta();
        }

        private void cbJobState1StatusRead_Click(object sender, EventArgs e)
        {
            ushort[] value = new ushort[2];
            value = lamba.lambaDefualtJobState1StatusRead();

            cbJobState1StatusAnimation.SelectedItem = animationBul(value[0]);

            cbJobState1StatusColor.SelectedItem = colorBul(value[1]);
        }
        private void btnJobState1StatusWrite_Click(object sender, EventArgs e)
        {
            if (cbJobState1StatusAnimation.SelectedIndex > -1 && cbJobState1StatusColor.SelectedIndex > -1)
            {
                ushort[] value = new ushort[2];
                value[0] = Convert.ToUInt16(cbJobState1StatusAnimation.SelectedIndex);
                value[1] = Convert.ToUInt16(cbJobState1StatusColor.SelectedIndex);

                lamba.lambaDefualtJobState1StatusWrite(value[0], value[1]);

                status.StatusUpdate(cGenel.JOB_STATE_1_STATUS_ANIMATION_ID, value[0]);
                status.StatusUpdate(cGenel.JOB_STATE_1_STATUS_COLOR_ID, value[1]);

                status.statusColorAta();
            }
        }

        private void btnJobState1StatusDefaultWrite_Click(object sender, EventArgs e)
        {
            lamba.lambaDefualtJobState1StatusDefaultStateWrite();


            status.StatusUpdate(cGenel.JOB_STATE_1_STATUS_ANIMATION_ID, 2);
            status.StatusUpdate(cGenel.JOB_STATE_1_STATUS_COLOR_ID, 1);

            status.statusColorAta();

        }
        private void cbJobState2StatusRead_Click(object sender, EventArgs e)
        {
            ushort[] value = new ushort[2];
            value = lamba.lambaDefualtJobState2StatusRead();

            cbJobState2StatusAnimation.SelectedItem = animationBul(value[0]);
            cbJobState2StatusColor.SelectedItem = colorBul(value[1]);
        }

        private void cbJobState2StatusWrite_Click(object sender, EventArgs e)
        {
            ushort[] value = new ushort[2];


            value[0]= Convert.ToUInt16(cbJobState2StatusAnimation.SelectedIndex);
            value[1] = Convert.ToUInt16(cbJobState2StatusColor.SelectedIndex);

            lamba.lambaDefualtJobState2StatusWrite(value[0], value[1]);
            status.statusColorAta();
        }

        private void cbJobState2StatusDefaultWrite_Click(object sender, EventArgs e)
        {
            lamba.lambaDefualtJobState2StatusWrite(1, 1);
            status.statusColorAta();
        }

        private void cbJobStateReworkStatusRead_Click(object sender, EventArgs e)
        {
            ushort[] value = new ushort[2];
            value = lamba.lambaDefualtJobStateReworkRead();
            cbJobStateReworkStatusAnimation.SelectedItem = animationBul( value[0]);
            cbJobStateReworkStatusColor.SelectedItem = colorBul(value[1]);
        }

        private void cbJobStateReworkStatusWrite_Click(object sender, EventArgs e)
        {
            ushort[] value = new ushort[2];


            value[0] = Convert.ToUInt16(cbJobStateReworkStatusAnimation.SelectedIndex);
            value[1] = Convert.ToUInt16(cbJobStateReworkStatusColor.SelectedIndex);

            lamba.lambaDefualtJobStateReworkWrite(value[0], value[1]);
            status.statusColorAta();
        }

        private void cbJobStateReworkStatusDefaultWrite_Click(object sender, EventArgs e)
        {

            lamba.lambaDefualtJobStateReworkWrite(1,2);
            status.statusColorAta();
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmManual);
        }
    }
}
