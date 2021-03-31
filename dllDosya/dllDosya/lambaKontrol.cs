using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Modbus.Device;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;

namespace DXMKontrol
{

    public class lambaKontrol
    {

        ///////////////////////////////////////////////////////////////////
    
        public bool lambaDurumDollyBaslangic(AutoResetEvent _AREvt, ushort jobState1StatusAnimationID, ushort jobState1StatusColorID, ModbusIpMaster master)
        {

            bool sonuc = false;
            ushort[] sonucRegisterAdim0 = new ushort[7];
            ushort[] sonucRegisterAdim1 = new ushort[5];
       


            _AREvt = new AutoResetEvent(false);




            try
            {
                ushort[] value = new ushort[6];
                value[0] = 1;//yazma 
                value[1] = 8701;//reg. start
                value[2] = 3;//adet 
                value[3] = 0;//adet 
                value[4] = jobState1StatusAnimationID;//adet 
                value[5] = jobState1StatusColorID;//adet 
                master.WriteMultipleRegisters(1, 700, value);

                master.WriteSingleRegister(1, 699, 4096);


                /* ushort[] value2 = new ushort[3];
                 value2[0] = 0;//wait state 
                 value2[1] = jobState1StatusAnimationID;//job state flash 
                 value2[2] = jobState1StatusColorID;////job state color 1 green
                 master.WriteMultipleRegisters(1, 703, value2);*/

                _AREvt.WaitOne(300);


                ushort[] value3 = new ushort[4];
                value3[0] = 4096;//device ID
                value3[1] = 1;//yazma 
                value3[2] = 6336;//reg. start
                value3[3] = 1;//adet 
                master.WriteMultipleRegisters(1, 699, value3);

                ushort[] value4 = new ushort[1];
                value4[0] = 1;//green          
                master.WriteMultipleRegisters(1, 703, value4);
                sonuc = true;
            }
            catch (Exception ex)
            {
                sonuc = false;
           
            }






            return sonuc;

        }

        //wait - job flash default
        public bool lambaDefualt(AutoResetEvent _AREvt, ushort DeviceID, ushort jobState1StatusAnimationID, ushort jobState1StatusColorID, ModbusIpMaster master)
        {
            bool sonuc = false;
            ushort[] sonucRegisterAdim0 = new ushort[7];
            ushort[] sonucRegisterAdim1 = new ushort[5];
            uint adim = 0;


            _AREvt = new AutoResetEvent(false);


            try
            {

                ushort[] value = new ushort[6];

                value[0] = 1;//yazma 
                value[1] = 8701;//reg. start
                value[2] = 3;//adet 
                value[3] = 0;
                value[4] = jobState1StatusAnimationID;//adet 
                value[5] = jobState1StatusColorID;//adet 
                master.WriteMultipleRegisters(1, 700, value);
                master.WriteSingleRegister(1, 699, DeviceID);

                /* ushort[] value2 = new ushort[3];
                 value2[0] = 0;//wait state 
                 value2[1] = jobState1StatusAnimationID;//job state flash 
                 value2[2] = jobState1StatusColorID;////job state color 1 green
                 master.WriteMultipleRegisters(1, 703, value2);*/





                _AREvt.WaitOne(300);

                ushort[] value3 = new ushort[4];
                value3[0] = DeviceID;//device ID
                value3[1] = 1;//yazma 
                value3[2] = 6336;//reg. start
                value3[3] = 1;//adet 
                master.WriteMultipleRegisters(1, 699, value3);

                ushort[] value4 = new ushort[1];
                value4[0] = 1;//green          
                master.WriteMultipleRegisters(1, 703, value4);
                sonuc = true;
            }
            catch
            {
                sonuc = false;


            }

            return sonuc;
        }

        // job flash
        public bool lambaJobIlgiliIsikFlashYak(AutoResetEvent _AREvt, ushort DeviceID, ushort jobState1StatusAnimationID, ushort jobState1StatusColorID, ModbusIpMaster master)
        {
            bool sonuc = false;
            ushort[] sonucRegisterAdim0 = new ushort[7];
            ushort[] sonucRegisterAdim1 = new ushort[5];

            _AREvt = new AutoResetEvent(false);

            //start timer1, timer1.Interval = 1000 ms
            try
            {



                /*  ushort[] value = new ushort[4];
                  value[0] = DeviceID;//device ID
                  value[1] = 1;//yazma 
                  value[2] = 8701;//reg. start
                  value[3] = 3;//adet 
                  master.WriteMultipleRegisters(1, 699, value);

                  ushort[] value2 = new ushort[3];
                  value2[0] = 1;//Job modu
                  value2[1] = jobState1StatusAnimationID;//FLASH
                  value2[2] = jobState1StatusColorID;//green
                  master.WriteMultipleRegisters(1, 703, value2);*/

                ushort[] value = new ushort[6];

                value[0] = 1;//yazma 
                value[1] = 8701;//reg. start
                value[2] = 3;//adet 
                value[3] = 1;
                value[4] = jobState1StatusAnimationID;//adet 
                value[5] = jobState1StatusColorID;//adet 
                master.WriteMultipleRegisters(1, 700, value);
                master.WriteSingleRegister(1, 699, DeviceID);
                _AREvt.WaitOne(300);


                ushort[] value3 = new ushort[4];
                value3[0] = DeviceID;//device ID
                value3[1] = 1;//yazma 
                value3[2] = 6336;//reg. start
                value3[3] = 1;//adet 
                master.WriteMultipleRegisters(1, 699, value3);

                ushort[] value4 = new ushort[1];
                value4[0] = 1;//yellow         
                master.WriteMultipleRegisters(1, 703, value4);

                sonuc = true;


            }
            catch
            {
                sonuc = false;
            }





            return sonuc;
        }

        // job stayed
        public bool lambaJobIlgiliIsikSteadyYak(AutoResetEvent _AREvt, ushort DeviceID, ushort jobState2StatusAnimationID, ushort jobState2StatusColorID, ModbusIpMaster master)
        {
            bool sonuc = false;
            _AREvt = new AutoResetEvent(false);


            ushort[] sonucRegisterAdim0 = new ushort[7];
            ushort[] sonucRegisterAdim1 = new ushort[5];

            try
            {
                /*  ushort[] value = new ushort[4];
                  value[0] = DeviceID;//device ID
                  value[1] = 1;//yazma 
                  value[2] = 8701;//reg. start
                  value[3] = 3;//adet 
                  master.WriteMultipleRegisters(1, 699, value);

                  ushort[] value2 = new ushort[3];
                  value2[0] = 1;//job state
                  value2[1] = jobState2StatusAnimationID;//job steady
                  value2[2] = jobState2StatusColorID;//job state -green

                  master.WriteMultipleRegisters(1, 703, value2);*/


                ushort[] value = new ushort[6];

                value[0] = 1;//yazma 
                value[1] = 8701;//reg. start
                value[2] = 3;//adet 
                value[3] = 1;
                value[4] = jobState2StatusAnimationID;//adet 
                value[5] = jobState2StatusColorID;//adet 
                master.WriteMultipleRegisters(1, 700, value);
                master.WriteSingleRegister(1, 699, DeviceID);


                _AREvt.WaitOne(300, true);

                ushort[] value3 = new ushort[4];
                value3[0] = DeviceID;//device ID
                value3[1] = 1;//yazma 
                value3[2] = 6336;//reg. start
                value3[3] = 1;//adet 
                master.WriteMultipleRegisters(1, 699, value3);

                ushort[] value4 = new ushort[1];
                value4[0] = 1;//yellow         
                master.WriteMultipleRegisters(1, 703, value4);
                sonuc = true;
            }

            catch
            {
                sonuc = false;
            }

            return sonuc;
        }


        // job steady - yellow
        public bool lambaJobIlgiliIsikSteadyYakSariRework(AutoResetEvent _AREvt, ushort DeviceID, ushort jobStateReworkAnimationID, ushort jobStateReworkColorID, ModbusIpMaster master)
        {
            bool sonuc = false;
            _AREvt = new AutoResetEvent(false);
            try
            {

               

                ushort[] value = new ushort[6];

                value[0] = 1;//yazma 
                value[1] = 8701;//reg. start
                value[2] = 3;//adet 
                value[3] = 1;
                value[4] = jobStateReworkAnimationID;//adet 
                value[5] = jobStateReworkColorID;//adet 
                master.WriteMultipleRegisters(1, 700, value);
                master.WriteSingleRegister(1, 699, DeviceID);




                _AREvt.WaitOne(300, true);

                ushort[] value3 = new ushort[4];
                value3[0] = DeviceID;//device ID
                value3[1] = 1;//yazma 
                value3[2] = 6336;//reg. start
                value3[3] = 1;//adet 
                master.WriteMultipleRegisters(1, 699, value3);

                ushort[] value4 = new ushort[1];
                value4[0] = 2;//yellow         
                master.WriteMultipleRegisters(1, 703, value4);
                sonuc = true;


            }
            catch
            {

            }

            return sonuc;
        }

        // job flash kotrol
        public bool lambaJobIlgiliIsikFlashYakKontrol( ushort DeviceID, ushort jobState1StatusAnimationID, ushort jobState1StatusColorID, ModbusIpMaster master)
        {
            bool sonuc = false;


        
            try
            {
                ushort[] value = new ushort[4];
                value[0] = DeviceID;//device ID
                value[1] = 0;//okuma
                value[2] = 8701;//
                value[3] = 3;// adet

                master.WriteMultipleRegisters(1, 699, value);

                ushort[] value2 = new ushort[3];
                value2 = master.ReadHoldingRegisters(1, 713, 3);

                if (value2[0]==1 && value2[1]== jobState1StatusAnimationID && value2[2]== jobState1StatusColorID)
                {
                    sonuc = true;
                }
                else
                {
                    sonuc = false;
                }
           

            }
            catch
            {
                sonuc = false;
            }





            return sonuc;
        }

        // job stayed kontrol
        public bool lambaJobIlgiliIsikSteadyYakKontrol( ushort DeviceID, ushort jobState2StatusAnimationID, ushort jobState2StatusColorID, ModbusIpMaster master)
        {
            bool sonuc = false;
   
            try
            {
                    ushort[] value = new ushort[4];
                    value[0] = DeviceID;//device ID
                    value[1] = 0;//okuma
                    value[2] = 8701;//
                    value[3] = 3;// adet

                    master.WriteMultipleRegisters(1, 699, value);

                    ushort[] value2 = new ushort[3];
                    value2 = master.ReadHoldingRegisters(1, 713, 3);

                    if (value2[0] == 1 && value2[1] == jobState2StatusAnimationID && value2[2] == jobState2StatusColorID)
                    {
                        sonuc = true;
                    }
                    else
                    {
                        sonuc = false;
                    }

            }

            catch
            {
                sonuc = false;
            }

            return sonuc;
        }


        // job steady - yellow kontrol
        public bool lambaJobIlgiliIsikSteadyYakSariReworkKontrol(ushort DeviceID, ushort jobStateReworkAnimationID, ushort jobStateReworkColorID, ModbusIpMaster master)
        {
            bool sonuc = false;
      
            try
            {

                ushort[] value = new ushort[4];
                value[0] = DeviceID;//device ID
                value[1] = 0;//okuma
                value[2] = 8701;//
                value[3] = 3;// adet

                master.WriteMultipleRegisters(1, 699, value);

                ushort[] value2 = new ushort[3];
                value2 = master.ReadHoldingRegisters(1, 713, 3);

                if (value2[0] == 1 && value2[1] == jobStateReworkAnimationID && value2[2] == jobStateReworkColorID)
                {
                    sonuc = true;
                }
                else
                {
                    sonuc = false;
                }

            }
            catch
            {

            }

            return sonuc;
        }




        //wait-job
        public bool waitJobStateChange(ushort state, ModbusIpMaster master)
        {
            bool sonuc = false;
            try
            {

                ushort[] value = new ushort[4];
                value[0] = 4096;//device ID
                value[1] = 1;//yazma 
                value[2] = 8701;//reg. start
                value[3] = 1;//adet 
                master.WriteMultipleRegisters(1, 699, value);

                ushort[] value2 = new ushort[1];
                value2[0] = state;//wait state 
                master.WriteMultipleRegisters(1, 703, value2);


            }
            catch (Exception)
            {

             
            }

            return sonuc;
        }
        //wait - default wait
        public ushort[] lambaDefualtWaitStateRead(ModbusIpMaster master)
        {

            ushort[] value2 = new ushort[2];
            try
            {


                ushort[] value = new ushort[4];
                value[0] = 31;//device ID
                value[1] = 0;//okuma 
                value[2] = 6302;//reg. start
                value[3] = 2;//adet 
                master.WriteMultipleRegisters(1, 699, value);



                value2 = master.ReadHoldingRegisters(1, 713, 2);

            }
            catch (Exception ex)
            {
              
            }

            return value2;
        }

        public bool lambaDefualtWaitStateWrite(ushort animationID, ushort colorID, ModbusIpMaster master)
        {

            bool sonuc = false;

            try
            {
                ushort[] value = new ushort[4];
                value[0] = 4096;//device ID
                value[1] = 1;//yazma 
                value[2] = 6302;//reg. start
                value[3] = 2;//adet 
                master.WriteMultipleRegisters(1, 699, value);

                ushort[] value2 = new ushort[2];
                value2[0] = animationID;//wait animationID 
                value2[1] = colorID;//wait color 
                master.WriteMultipleRegisters(1, 703, value2);

            }
            catch (Exception)
            {

          
            }



            return sonuc;
        }

        public bool lambaDefualtWaitDefaultStateWrite(ModbusIpMaster master)
        {
            bool sonuc = false;

            try
            {
                ushort[] value = new ushort[4];
                value[0] = 4096;//device ID
                value[1] = 1;//yazma 
                value[2] = 6302;//reg. start
                value[3] = 2;//adet 
                master.WriteMultipleRegisters(1, 699, value);

                ushort[] value2 = new ushort[2];
                value2[0] = 0;//wait animationID 
                value2[1] = 0;//wait color 
                master.WriteMultipleRegisters(1, 703, value2);

            }
            catch (Exception)
            {

            }


            return sonuc;

        }

        //mispick state
        public ushort[] lambaDefualtMispickStateRead(ModbusIpMaster master)
        {

            ushort[] value2 = new ushort[2];
            try
            {


                ushort[] value = new ushort[4];
                value[0] = 31;//device ID
                value[1] = 0;//okuma 
                value[2] = 6313;//reg. start
                value[3] = 2;//adet 
                master.WriteMultipleRegisters(1, 699, value);



                value2 = master.ReadHoldingRegisters(1, 713, 2);

            }
            catch (Exception ex)
            {
               
            }

            return value2;
        }

        public bool lambaDefualtMispickStateWrite(ushort animationID, ushort colorID, ModbusIpMaster master)
        {
            bool sonuc = false;

            try
            {
                ushort[] value = new ushort[4];
                value[0] = 4096;//device ID
                value[1] = 1;//yazma 
                value[2] = 6313;//reg. start
                value[3] = 2;//adet 
                master.WriteMultipleRegisters(1, 699, value);

                ushort[] value2 = new ushort[2];
                value2[0] = animationID;//wait animationID 
                value2[1] = colorID;//wait color 
                master.WriteMultipleRegisters(1, 703, value2);

            }
            catch (Exception)
            {

               
            }

            return sonuc;

        }

        public bool lambaDefualtMispickStateDefaultStateWrite(ModbusIpMaster master)
        {

            bool sonuc = false;

            try
            {
                ushort[] value = new ushort[4];
                value[0] = 4096;//device ID
                value[1] = 1;//yazma 
                value[2] = 6313;//reg. start
                value[3] = 2;//adet 
                master.WriteMultipleRegisters(1, 699, value);

                ushort[] value2 = new ushort[2];
                value2[0] = 2;//wait animationID 
                value2[1] = 0;//wait color 
                master.WriteMultipleRegisters(1, 703, value2);

            }
            catch (Exception)
            {

               
            }

            return sonuc;
        }


        //job state 1. status
        public ushort[] lambaDefualtJobState1StatusRead(ModbusIpMaster master)
        {

            ushort[] value2 = new ushort[2];
            try
            {


                ushort[] value = new ushort[4];
                value[0] = 31;//device ID
                value[1] = 0;//okuma 
                value[2] = 6324;//reg. start
                value[3] = 2;//adet 
                master.WriteMultipleRegisters(1, 699, value);



                value2 = master.ReadHoldingRegisters(1, 713, 2);

            }
            catch (Exception ex)
            {
           
            }

            return value2;
        }

        public bool lambaDefualtJobState1StatusWrite(ushort animationID, ushort colorID, ModbusIpMaster master)
        {

            bool sonuc = false;

            try
            {
                ushort[] value = new ushort[4];
                value[0] = 4096;//device ID
                value[1] = 1;//yazma 
                value[2] = 6324;//reg. start
                value[3] = 2;//adet 
                master.WriteMultipleRegisters(1, 699, value);

                ushort[] value2 = new ushort[2];
                value2[0] = animationID;//wait animationID 
                value2[1] = colorID;//wait color 
                master.WriteMultipleRegisters(1, 703, value2);

            }
            catch (Exception)
            {

            
            }

            return sonuc;

        }

        public bool lambaDefualtJobState1StatusDefaultStateWrite(ModbusIpMaster master)
        {


            bool sonuc = false;

            try
            {
                ushort[] value = new ushort[4];
                value[0] = 4096;//device ID
                value[1] = 1;//yazma 
                value[2] = 6324;//reg. start
                value[3] = 2;//adet 
                master.WriteMultipleRegisters(1, 699, value);

                ushort[] value2 = new ushort[2];
                value2[0] = 2;//wait animationID 
                value2[1] = 1;//wait color 
                master.WriteMultipleRegisters(1, 703, value2);

            }
            catch (Exception)
            {

              
            }


            return sonuc;


        }

    }

}

