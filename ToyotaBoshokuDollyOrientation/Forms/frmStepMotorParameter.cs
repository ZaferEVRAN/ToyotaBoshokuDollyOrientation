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
    public partial class frmStepMotorParametreBakim : Form
    {
        public frmStepMotorParametreBakim()
        {
            InitializeComponent();
        }
     
        private void btnRead_Click(object sender, EventArgs e)
        {


            try
            {

                if (cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.Connected)
                {
                    txtHiz.Value = (cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.ReadHoldingRegisters(0, 1))[0];
                    txtTork.Value = (cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.ReadHoldingRegisters(2, 1))[0];
                    txtIvme.Value = (cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.ReadHoldingRegisters(3, 1))[0];
                    txtTutmaTork.Value = (cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.ReadHoldingRegisters(7, 1))[0];

                }
                else
                {
                    cGenel.genelUyari("Step motor bağlantı hatası", false);
                }
            }
            catch (Exception ex)
            {

                cGenel.haberlesmeMesajModbusRTU = ex.Message;
            }

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                if (cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.Connected)
                {
                    cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.WriteSingleRegister(0, Convert.ToUInt16(txtHiz.Value));
                    cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.WriteSingleRegister(2, Convert.ToUInt16(txtTork.Value));
                    cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.WriteSingleRegister(3, Convert.ToUInt16(txtIvme.Value));
                    cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.WriteSingleRegister(7, Convert.ToUInt16(txtTutmaTork.Value));

                }
                else
                {
                    cGenel.genelUyari("Step motor bağlantı hatası", false);
                }
            }
            catch (Exception ex)
            {
                cGenel.haberlesmeMesajModbusRTU = ex.Message;
            }


        }

        private void btnDefaultWrite_Click(object sender, EventArgs e)
        {

            try
            {
                if (cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.Connected)
                {
                    cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.WriteSingleRegister(0, 1500);
                    cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.WriteSingleRegister(2, 400);
                    cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.WriteSingleRegister(3, 300);
                    cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.WriteSingleRegister(7, 100);
                }
                else
                {
                    cGenel.genelUyari("Step motor bağlantı hatası", false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmManual);
        }

        private void btnKlavye_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }
    }
}
