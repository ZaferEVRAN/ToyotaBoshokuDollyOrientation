using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using EasyModbus;

namespace ToyotaBoshokuDollyOrientation
{

    class cistemciKontrol_StepMotor
    {
        public static PLCDurumlari PLCDurumu { get; private set; }

    
        public static ModbusClient slaveModbusRTUStepMotor;
     

        public PLCDurumlari stepMotorIstemciyiOlustur()
        {
            PLCDurumlari durum = PLCDurumlari.KULLANILAMAZ;
            try
            {
               
                    slaveModbusRTUStepMotor = new ModbusClient(Properties.Settings.Default.comPortStepMotor);
                    slaveModbusRTUStepMotor.UnitIdentifier = 1;
                    slaveModbusRTUStepMotor.Baudrate = 9600;
                    slaveModbusRTUStepMotor.Parity = System.IO.Ports.Parity.None;
                    slaveModbusRTUStepMotor.StopBits = System.IO.Ports.StopBits.One;
                    slaveModbusRTUStepMotor.ConnectionTimeout = 500;
                    slaveModbusRTUStepMotor.Connect();

                
                    durum = PLCDurumlari.UYGUN;

                
            }

            catch (Exception ex)
            {
                durum = PLCDurumlari.KULLANILAMAZ;

            }

            return durum;
        }
        bool yazmaBasarili;
        public void kilitAc()
        {
            try
            {
                //slaveModbusRTUStepMotor.WriteSingleCoil(13, true);//CW
                slaveModbusRTUStepMotor.WriteSingleCoil(2, true);//CW
                slaveModbusRTUStepMotor.WriteSingleCoil(3, true);
                cGenel.haberlesmeMesajModbusRTU = "Komut:Kilit Aç";
                yazmaBasarili = true;
            }
            catch (Exception ex)
            {
                slaveModbusRTUStepMotor.Disconnect();
                slaveModbusRTUStepMotor.Connect();
                cGenel.haberlesmeMesajModbusRTU = ex.Message;
                yazmaBasarili = false;
            }
        }

        public void kilitKapat()
        {

            try
            {
                //slaveModbusRTUStepMotor.WriteSingleCoil(13, false);//CW
                slaveModbusRTUStepMotor.WriteSingleCoil(2, false);//CCW
                slaveModbusRTUStepMotor.WriteSingleCoil(3, true);
                cGenel.haberlesmeMesajModbusRTU = "Komut:Kilit Kapat";
                yazmaBasarili = true;
            }
            catch (Exception ex)
            {
                slaveModbusRTUStepMotor.Disconnect();
                slaveModbusRTUStepMotor.Connect();
                cGenel.haberlesmeMesajModbusRTU = ex.Message;
                yazmaBasarili = false;
            }
        }

        public void dur()
        {

            try
            {

                slaveModbusRTUStepMotor.WriteSingleCoil(3, false);//stop
                cGenel.motorRun = false;
                cGenel.haberlesmeMesajModbusRTU = "Komut:DUR";
                yazmaBasarili = true;
            }
            catch (Exception ex)
            {
               
                slaveModbusRTUStepMotor.Disconnect();
                slaveModbusRTUStepMotor.Connect();
                cGenel.haberlesmeMesajModbusRTU = ex.Message;
                yazmaBasarili = false;
            }
        }
        bool[] sensor = new bool[2];
        bool[] status = new bool[2];
        public void kilitMekanizmaSensorOku()
        {

            try
            {
                sensor = slaveModbusRTUStepMotor.ReadDiscreteInputs(0, 2);
                cGenel.lockOnSensor = sensor[0];
                cGenel.lockOffSensor = sensor[1];

                status = slaveModbusRTUStepMotor.ReadDiscreteInputs(6, 2);
                cGenel.deviceAlarmVar = status[0];
                cGenel.motorRun = status[1];
                cGenel.haberlesmeMesajModbusRTU = "Sensor Read OK";
            }
            catch (Exception ex)
            {
                //stepMotorIstemciyiOlustur();
        
                slaveModbusRTUStepMotor.Disconnect();
                slaveModbusRTUStepMotor.Connect();
                cGenel.haberlesmeMesajModbusRTU = ex.Message;
            }

        }

        static AutoResetEvent _AREvt;
        public void kilitMekanizmaDongusu()
        {
            _AREvt = new AutoResetEvent(false);
            var t = Task.Run(() =>
            {
                while ((cGenel.lockOnClick == true || cGenel.lockOffClick == true) && cGenel.xByPass == false&& cGenel.xKilitMekanizmasiByPass == false && cistemciKontrol_StepMotor.slaveModbusRTUStepMotor.Connected==true)
                {
                    _AREvt.WaitOne(300, true);
                    kilitMekanizmaSensorOku();
                   // _AREvt.WaitOne(300, true);
                    if (cGenel.count == cGenel.kilitKapatmaDenemeSayisi)
                    {
                        dur();

                        if (yazmaBasarili)
                        {
                            cGenel.lockOffClick = false;
                            cGenel.lockOnClick = false;
                            cGenel.count = 0;
                            cGenel.timer = 0;
                        }

                    }

                    if (cGenel.lockOffSensor == true && cGenel.lockOffClick == true&&cGenel.motorRun==false)//
                    {
                        cGenel.timer = 0;
                        kilitKapat();
                    }
                    else if ((cGenel.lockOffSensor == false && cGenel.lockOffClick == true))
                    {
                        _AREvt.WaitOne(800, true);
                        dur();
                        if (yazmaBasarili)
                        {
                            cGenel.lockOffClick = false;

                            cGenel.count = 0;
                            cGenel.stepAlarmVar = false;
                            cGenel.timer = 0;
                        }
                    }
                    else if (cGenel.timer >= cGenel.kilitZamanAsimi && cGenel.lockOffClick == true)
                    {
                        dur();
                        if (yazmaBasarili)
                        {
                            cGenel.lockOffClick = false;
                            cGenel.lockOnClick = true;
                            cGenel.timer = 0;

                            cGenel.count++;
                            cGenel.stepAlarmVar = true;
                            cGenel.lockOnSensor = false;
                        }
                    }

                    if ((cGenel.lockOnSensor == false&&cGenel.lockOnClick == true &&cGenel.motorRun == false))
                    {
                        cGenel.timer = 0;
                        kilitAc();


                    }
                    else if (cGenel.lockOnSensor == true && cGenel.lockOnClick == true)
                    {
                        dur();
                        if (yazmaBasarili)
                        {
                            cGenel.lockOnClick = false;
                            if (cGenel.stepAlarmVar)
                            {
                                cGenel.lockOffClick = true;
                            }
                            cGenel.timer = 0;
                        }

                    }
                    else if (cGenel.timer >= cGenel.kilitZamanAsimi && cGenel.lockOnClick == true)
                    {
                   
                        dur();
                        if (yazmaBasarili)
                        {
                            cGenel.lockOnClick = false;
                            if (cGenel.stepAlarmVar)
                            {
                                cGenel.lockOffClick = false;
                            }
                            cGenel.timer = 0;
                        }


                    }

                }
            });
        }
    }
}
    
    
