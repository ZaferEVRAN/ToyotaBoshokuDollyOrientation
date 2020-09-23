using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Modbus.Device;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using DXMKontrol;
namespace ToyotaBoshokuDollyOrientation
{
    public enum LambColor : ushort
    {
        Red = 0,
        Green = 1,
        Yellow = 2,
        Blue = 3,

    }

    public enum LambStatus : ushort
    {
        constant = 0,
        blink = 1,
     
    }

    class  bolmeAdi
    {
     public const  uint   PARTITION_1= 1;
     public const  uint   PARTITION_2= 2;
     public const  uint   PARTITION_3= 3;
     public const  uint   PARTITION_4= 4;
     public const  uint   PARTITION_5= 5;
     public const  uint   PARTITION_6= 6;
     public const  uint   PARTITION_7= 7;
     public const  uint   PARTITION_8= 8;
     public const  uint   PARTITION_9= 9;
     public const  uint   PARTITION_10 =10;

    }
    class cLambaKontrol
    {
        public lambaKontrol lamba = new lambaKontrol();
        public static TcpClient client;
        public static ModbusIpMaster master;
        public static PLCDurumlari PLCDurumu { get; private set; }


        DateTime dtDisconnect = new DateTime();
        DateTime dtNow = new DateTime();
        bool NetworkIsOk = false;

        [DllImport("WININET", CharSet = CharSet.Auto)]
        static extern bool InternetGetConnectedState(ref InternetConnectionState lpdwFlags, int dwReserved);
        enum InternetConnectionState : int
        {
            INTERNET_CONNECTION_MODEM = 0x1,
            INTERNET_CONNECTION_LAN = 0x2,
            INTERNET_CONNECTION_PROXY = 0x4,
            INTERNET_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }
        private bool CheckInternet()
        {
            InternetConnectionState flag = InternetConnectionState.INTERNET_CONNECTION_LAN;
            return InternetGetConnectedState(ref flag, 0);

        }

        public cLambaKontrol()
        {
         PLCDurumu = PLCDurumlari.KULLANILAMAZ;
        
         if (Connect())
         {
             PLCDurumu = PLCDurumlari.UYGUN;
         }

        }

        public bool Connect()
        {

            if (master != null)
                master.Dispose();
            if (client != null)
                client.Close();
            if (CheckInternet())
            {
                try
                {
                    client = new TcpClient();
                    IAsyncResult asyncResult = client.BeginConnect(cGenel.conDXM_IP, 502, null, null);
                    asyncResult.AsyncWaitHandle.WaitOne(3000, true); //wait for 3 sec
                    if (!asyncResult.IsCompleted)
                    {
                        client.Close();
                        cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Cannot connect to server.");
                        return false;
                    }
                    // create Modbus TCP Master by the tcpclient
                    master = ModbusIpMaster.CreateIp(client);
                    master.Transport.Retries = 3; //don't have to do retries
                    master.Transport.WaitToRetryMilliseconds = 50;
                    master.Transport.ReadTimeout = 1500;
                    cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Connect to server.");
                    return true;
                }
                catch (Exception ex)
                {
                    cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Connect process " + ex.StackTrace +
                   "==>" + ex.Message);
                    return false;
                }
            }
            return false;


        }

        private Task<bool> ConnectTask()
        {
            return Task.Run(() =>
           {
               if (master != null)
                   master.Dispose();
               if (client != null)
                   client.Close();
               if (CheckInternet())
               {
                   try
                   {
                       client = new TcpClient();
                       IAsyncResult asyncResult = client.BeginConnect(cGenel.conDXM_IP, 502, null, null);
                       asyncResult.AsyncWaitHandle.WaitOne(3000, true); //wait for 3 sec
                       if (!asyncResult.IsCompleted)
                       {
                           client.Close();
                           cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Cannot connect to server.");
                           return false;
                       }
                       // create Modbus TCP Master by the tcpclient
                       master = ModbusIpMaster.CreateIp(client);
                       master.Transport.Retries = 3; //don't have to do retries
                       master.Transport.ReadTimeout = 1500;
                       master.Transport.WaitToRetryMilliseconds = 50;
                 
                       cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Connect to server.");
                       return true;
                   }
                   catch (Exception ex)
                   {
                       cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Connect process " + ex.StackTrace +
                      "==>" + ex.Message);
                       return false;
                   }
               }
               return false;

           });



        }

        ushort[] sensor = new ushort[1];
        public async void sensorOkuma(ushort deviceID)
        {
            //start timer1, timer1.Interval = 1000 ms
            try
            {
                if (NetworkIsOk)
                {
                    #region Master to Slave
                    //read AI, AO, DI, DO
                    ushort[] value = new ushort[4];
                    value[0] = deviceID;//device ID
                    value[1] = 0;//okuma
                    value[2] = 7942;//başlangıç register
                    value[3] = 1;// adet

                    master.WriteMultipleRegisters(1, 699, value);

                    sensor = master.ReadHoldingRegisters(1, 713, 1);
                    if (sensor[0]>0)
                    {
                        cGenel.sensorSonucu = sensor[0];
                    }
           
                    //cGenel.CommonDeviceID = sensor[0];
                    #endregion
                }
                else
                {
                   // cGenel.sensorSonucu = 0;
                    //retry connecting
                    dtNow = DateTime.Now;
                    if ((dtNow - dtDisconnect) > TimeSpan.FromSeconds(10))
                    {
                        cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Start connecting");
                        NetworkIsOk = await ConnectTask();
                        if (!NetworkIsOk)
                        {
                            cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Connecting fail. Wait for retry");
                            dtDisconnect = DateTime.Now;
                        }
                    }
                    else
                    {
                        cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Wait for retry connecting");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("DXM System"))
                {
                    //set NetworkIsOk to false and retry connecting
                    NetworkIsOk = false;
                    cGenel.haberlesmeMesaj = (ex.Message);
                    dtDisconnect = DateTime.Now;
                }
            }
        }

        public async void buzzerDeviceIDRead()
        {

            //start timer1, timer1.Interval = 1000 ms

            try
            {

                if (NetworkIsOk)
                {
                    #region Master to Slave
                    //read AI, AO, DI, DO
                    cGenel.deviceIDSensor = master.ReadHoldingRegisters(1, 499, 1);
                    #endregion                
                }
                else
                {
                    //retry connecting
                    dtNow = DateTime.Now;
                    if ((dtNow - dtDisconnect) > TimeSpan.FromSeconds(10))
                    {
                        cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Start connecting");
                        NetworkIsOk = await ConnectTask();
                        if (!NetworkIsOk)
                        {
                            cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Connecting fail. Wait for retry");
                            dtDisconnect = DateTime.Now;
                        }
                    }
                    else
                    {
                        cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Wait for retry connecting");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("DXM System "))
                {
                    //set NetworkIsOk to false and retry connecting
                    NetworkIsOk = false;
                    cGenel.haberlesmeMesaj = (ex.Message);
                    dtDisconnect = DateTime.Now;
                }
            }

            // return deviceID;
        }

        public  void buzzerRing(ushort status)
        {
            try
            {
                master.WriteSingleRegister(1, 503, status);
            }
            catch (Exception ex)
            {

                Connect();
            }

        }
        public static ushort ringKontol;
        public async void buzzerRingKontrol()
        {

            //start timer1, timer1.Interval = 1000 ms
       
            try
            {

                if (NetworkIsOk)
                {
                    #region Master to Slave
                    //read AI, AO, DI, DO
                    ushort[] value;
                     value=   master.ReadHoldingRegisters(1, 503, 1);
                    ringKontol = value[0];
                    #endregion                
                }
                else
                {
                    //retry connecting
                    dtNow = DateTime.Now;
                    if ((dtNow - dtDisconnect) > TimeSpan.FromSeconds(10))
                    {
                        cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Start connecting");
                        NetworkIsOk = await ConnectTask();
                        if (!NetworkIsOk)
                        {
                            cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Connecting fail. Wait for retry");
                            dtDisconnect = DateTime.Now;
                        }
                    }
                    else
                    {
                        cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":DXM Wait for retry connecting");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("DXM System"))
                {
                    //set NetworkIsOk to false and retry connecting
                    NetworkIsOk = false;
                    cGenel.haberlesmeMesaj = (ex.Message);
                    dtDisconnect = DateTime.Now;
                }
            }
            
        }

        //lamba bul
        public ushort deviceIDBul_LH(uint dollyRafi, string yonu)
        {
            ushort sonuc = 0;

            if (dollyRafi == bolmeAdi.PARTITION_1 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 40;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_1 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 39;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_2 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 38;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_2 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 37;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_3 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 36;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_3 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 35;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_4 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 34;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_4 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 33;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_5 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 32;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_5 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 31;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_6 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 50;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_6 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 49;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_7 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 48;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_7 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 47;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_8 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 46;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_8 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 45;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_9 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 44;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_9 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 43;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_10 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 42;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_10 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 41;
            }



            return sonuc;
        }

        //lamba bul
        public ushort deviceIDBul_RH(uint dollyRafi, string yonu)
        {
            ushort sonuc = 0;

            if (dollyRafi == bolmeAdi.PARTITION_1 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 31;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_1 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 32;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_2 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 33;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_2 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 34;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_3 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 35;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_3 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 36;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_4 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 37;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_4 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 38;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_5 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 39;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_5 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 40;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_6 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 41;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_6 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 42;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_7 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 43;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_7 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 44;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_8 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 45;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_8 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 46;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_9 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 47;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_9 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 48;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_10 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 49;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_10 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 50;
            }



            return sonuc;
        }

        static AutoResetEvent _AREvt;
        public bool lambaDurumDollyBaslangic()
        {
            bool sonuc = false;

            sonuc = lamba.lambaDurumDollyBaslangic(_AREvt, cGenel.jobState1StatusAnimationID, cGenel.jobState1StatusColorID, master);

            return sonuc;
        }

        //wait - job flash default
        public bool lambaDefualt(ushort DeviceID)
        {
            ///DXM'e gömülebilir mi???
            bool result = false;


            result = lamba.lambaDefualt(_AREvt, DeviceID, cGenel.jobState1StatusAnimationID, cGenel.jobState1StatusColorID, master);


            return result;
        }

        // job flash
        public bool lambaJobIlgiliIsikFlashYak(ushort DeviceID)
        {

            ///DXM'e gömülebilir mi???
            bool result = false;

            //start timer1, timer1.Interval = 1000 ms
            result = lamba.lambaJobIlgiliIsikFlashYak(_AREvt, DeviceID, cGenel.jobState1StatusAnimationID, cGenel.jobState1StatusColorID, master);


            return result;
        }

        // job stayed
        public bool lambaJobIlgiliIsikSteadyYak(ushort DeviceID)
        {

            ///DXM'e gömülebilir mi???
            bool result = false;




            result = lamba.lambaJobIlgiliIsikSteadyYak(_AREvt, DeviceID, cGenel.jobState2StatusAnimationID, cGenel.jobState2StatusColorID, master);


            return result;
        }

        // job steady - yellow
        public bool lambaJobIlgiliIsikSteadyYakSariRework(ushort DeviceID)
        {

            ///DXM'e gömülebilir mi???
            bool result = false;


            result = lamba.lambaJobIlgiliIsikSteadyYakSariRework(_AREvt, DeviceID, cGenel.jobStateReworkAnimationID, cGenel.jobStateReworkColorID, master);

            return result;
        }

        public async void activeDeviceID()
        {
            //start timer1, timer1.Interval = 1000 ms

            try
            {

                if (NetworkIsOk)
                {
                    #region Master to Slave
                    //read AI, AO, DI, DO
                    cGenel.deviceIDSensor = master.ReadHoldingRegisters(1, 499, 1);
                    #endregion                
                }
                else
                {
                    //retry connecting
                    dtNow = DateTime.Now;
                    if ((dtNow - dtDisconnect) > TimeSpan.FromSeconds(10))
                    {
                        cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":Start connecting");
                        NetworkIsOk = await ConnectTask();
                        if (!NetworkIsOk)
                        {
                            cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":Connecting fail. Wait for retry");
                            dtDisconnect = DateTime.Now;
                        }
                    }
                    else
                    {
                        cGenel.haberlesmeMesaj = (DateTime.Now.ToString() + ":Wait for retry connecting");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("System"))
                {
                    //set NetworkIsOk to false and retry connecting
                    NetworkIsOk = false;
                    cGenel.haberlesmeMesaj = (ex.Message);
                    dtDisconnect = DateTime.Now;
                }
            }

        }

        public bool waitJobStateChange(ushort state)
        {
            ///DXM'e gömülebilir mi???
            bool result = false;

        
                    result = lamba.waitJobStateChange( state, master);



            return result;
        }
        //wait - default wait
        public ushort[] lambaDefualtWaitStateRead()
        {

            ushort[] value2 = new ushort[2];

            value2= lamba.lambaDefualtWaitStateRead(master);

             
            return value2;
        }

        public bool lambaDefualtWaitStateWrite(ushort animationID, ushort colorID)
        {

            bool sonuc = false;

      
                    sonuc = lamba.lambaDefualtWaitStateWrite( animationID, colorID, master);

            

            return sonuc;
        }

        public void lambaDefualtWaitDefaultStateWrite()
        {
            lamba.lambaDefualtWaitDefaultStateWrite( master);
        }

        //mispick state
        public ushort[] lambaDefualtMispickStateRead()
        {

            ushort[] value2 = new ushort[2];
            try
            {

                value2 = lamba.lambaDefualtMispickStateRead(master);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return value2;

        }

        public void lambaDefualtMispickStateWrite(ushort animationID, ushort colorID)
        {


            lamba.lambaDefualtMispickStateWrite( animationID, colorID, master);


        }

        public void lambaDefualtMispickStateDefaultStateWrite()
        {

            lamba.lambaDefualtMispickStateDefaultStateWrite( master);

        }


        //job state 1. status
        public ushort[] lambaDefualtJobState1StatusRead()
        {

            ushort[] value2 = new ushort[2];
            try
            {
                value2 = lamba.lambaDefualtJobState1StatusRead(master);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return value2;
        }

        public void lambaDefualtJobState1StatusWrite(ushort animationID, ushort colorID)
        {
            lamba.lambaDefualtJobState1StatusWrite( animationID, colorID, master);


        }

        public void lambaDefualtJobState1StatusDefaultStateWrite()
        {



            lamba.lambaDefualtJobState1StatusDefaultStateWrite( master);

        }


        //job state 2. status
        public ushort[] lambaDefualtJobState2StatusRead()
        {

            ushort[] value2 = new ushort[2];
            try
            {

                cStatus status = new cStatus();
                value2[0] = status.StatusQuery(cGenel.JOB_STATE_2_STATUS_ANIMATION_ID);
                value2[1] = status.StatusQuery(cGenel.JOB_STATE_2_STATUS_COLOR_ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return value2;
        }

        public void lambaDefualtJobState2StatusWrite(ushort animationID, ushort colorID)
        {


            try
            {

                cStatus status = new cStatus();
                status.StatusUpdate(cGenel.JOB_STATE_2_STATUS_ANIMATION_ID, animationID);
                status.StatusUpdate(cGenel.JOB_STATE_2_STATUS_COLOR_ID, colorID);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        public void lambaDefualtJobState2StatusDefaultStateWrite()
        {


            try
            {

                cStatus status = new cStatus();
                status.StatusUpdate(cGenel.JOB_STATE_2_STATUS_ANIMATION_ID, 1);
                status.StatusUpdate(cGenel.JOB_STATE_2_STATUS_COLOR_ID, 1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //job state Rework
        public ushort[] lambaDefualtJobStateReworkRead()
        {

            ushort[] value2 = new ushort[2];
            try
            {


                cStatus status = new cStatus();
                value2[0] = status.StatusQuery(cGenel.JOB_STATE_REWORK_STATUS_ANIMATION_ID);
                value2[1] = status.StatusQuery(cGenel.JOB_STATE_REWORK_STATUS_COLOR_ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return value2;
        }

        public void lambaDefualtJobStateReworkWrite(ushort animationID, ushort colorID)
        {
            try
            {

                cStatus status = new cStatus();
                status.StatusUpdate(cGenel.JOB_STATE_REWORK_STATUS_ANIMATION_ID, animationID);
                status.StatusUpdate(cGenel.JOB_STATE_REWORK_STATUS_COLOR_ID, colorID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        public void lambaDefualtJobStateReworkDefaultStateWrite()
        {


            try
            {

                cStatus status = new cStatus();
                status.StatusUpdate(cGenel.JOB_STATE_REWORK_STATUS_ANIMATION_ID, 1);
                status.StatusUpdate(cGenel.JOB_STATE_REWORK_STATUS_COLOR_ID, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        List<uint> list;
        public void yarimKalanIsıklarGoster()
        {
            _AREvt = new AutoResetEvent(false);
            var t = Task.Run(() =>
            {
                KarkasIslem dollyKarkas = new KarkasIslem();
                list = new List<uint>();
                if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_LH)
                {
                    list = dollyKarkas.dollyPickToLightIzleme_LH();

               
                    for (ushort i = 0; i < list.Count; i++)
                    {
                        ushort device = deviceIDBul_LH(i);
                        uint barkodDurum = list[i];

                        if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumYok)
                        {
                            lambaDefualt(device);

                        }
                        else if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde)
                        {
                            lambaJobIlgiliIsikSteadyYak(device);

                        }
                        else if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework)
                        {
                            lambaJobIlgiliIsikSteadyYakSariRework(device);

                        }
                        _AREvt.WaitOne(300);
                        device++;
                    }

                }
                else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
                {
                    list = dollyKarkas.dollyPickToLightIzleme_RH();

                    ushort device = 31;
                    for (int i = 0; i < list.Count; i++)
                    {

                        uint barkodDurum = list[i];

                        if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumYok)
                        {
                            lambaDefualt(device);

                        }
                        else if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde)
                        {
                            lambaJobIlgiliIsikSteadyYak(device);

                        }
                        else if (barkodDurum == (byte)urunBarkodDurumlari.barkodIslemDurumUrunRework)
                        {
                            lambaJobIlgiliIsikSteadyYakSariRework(device);

                        }
                        _AREvt.WaitOne(300);
                        device++;
                    }

                }



            });

        }

        //lamba bul
        public ushort deviceIDBul_LH(int index)
        {
            ushort sonuc = 0;

            if (index==0)
            {
                sonuc = 40;
            }
            else if (index == 1)
            {
                sonuc = 39;
            }
            else if (index == 2)
            {
                sonuc = 38;
            }
            else if (index == 3)
            {
                sonuc = 37;
            }
            else if (index == 4)
            {
                sonuc = 36;
            }
            else if (index == 5)
            {
                sonuc = 35;
            }
            else if (index == 6)
            {
                sonuc = 34;
            }
            else if (index == 7)
            {
                sonuc = 33;
            }
            else if (index == 8)
            {
                sonuc = 32;
            }
            else if (index == 9)
            {
                sonuc = 31;
            }
            else if (index == 10)
            {
                sonuc = 50;
            }
            else if (index == 11)
            {
                sonuc = 49;
            }
            else if (index == 12)
            {
                sonuc = 48;
            }
            else if (index == 13)
            {
                sonuc = 47;
            }
            else if (index == 14)
            {
                sonuc = 46;
            }
            else if (index == 15)
            {
                sonuc = 45;
            }
            else if (index == 16)
            {
                sonuc = 44;
            }
            else if (index == 17)
            {
                sonuc = 43;
            }
            else if (index == 18)
            {
                sonuc = 42;
            }
            else if (index == 19)
            {
                sonuc = 41;
            }



            return sonuc;
        }

 




    }
}
