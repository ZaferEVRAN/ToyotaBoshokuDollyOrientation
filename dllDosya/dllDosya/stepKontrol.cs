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
namespace dllDosya
{
   public class stepKontrol
    {
     
        public static PLCDurumlari PLCDurumu { get; private set; }
        public static string haberlesmeMesaj;

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


        public stepKontrol()
        {
            PLCDurumu = PLCDurumlari.KULLANILAMAZ;

        }


        public bool Connect(string istemciIP,TcpClient client, ModbusIpMaster master)
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
                    IAsyncResult asyncResult = client.BeginConnect(istemciIP, 502, null, null);
                    asyncResult.AsyncWaitHandle.WaitOne(3000, true); //wait for 3 sec
                    if (!asyncResult.IsCompleted)
                    {
                        client.Close();
                        haberlesmeMesaj = (DateTime.Now.ToString() + ":Cannot connect to server.");
                        return false;
                    }
                    // create Modbus TCP Master by the tcpclient
                    master = ModbusIpMaster.CreateIp(client);
                    master.Transport.Retries = 3; //don't have to do retries
                    master.Transport.ReadTimeout = 1500;
                    haberlesmeMesaj = (DateTime.Now.ToString() + ":Connect to server.");
                    return true;
                }
                catch (Exception ex)
                {
                    haberlesmeMesaj = (DateTime.Now.ToString() + ":Connect process " + ex.StackTrace +
                    "==>" + ex.Message);
                    return false;
                }
            }
            return false;



        }
        private Task<bool> ConnectTask(string istemciIP, TcpClient client, ModbusIpMaster master)
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
                        IAsyncResult asyncResult = client.BeginConnect(istemciIP, 502, null, null);
                        asyncResult.AsyncWaitHandle.WaitOne(3000, true); //wait for 3 sec
                        if (!asyncResult.IsCompleted)
                        {
                            client.Close();
                            haberlesmeMesaj = (DateTime.Now.ToString() + ":Cannot connect to server.");
                            return false;
                        }
                        // create Modbus TCP Master by the tcpclient
                        master = ModbusIpMaster.CreateIp(client);
                        master.Transport.Retries = 3; //don't have to do retries
                        master.Transport.ReadTimeout = 1500;
                        haberlesmeMesaj = (DateTime.Now.ToString() + ":Connect to server.");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        haberlesmeMesaj = (DateTime.Now.ToString() + ":Connect process " + ex.StackTrace +
                       "==>" + ex.Message);
                        return false;
                    }
                }
                return false;

            });

        }

        private bool CheckInternet()
        {
            InternetConnectionState flag = InternetConnectionState.INTERNET_CONNECTION_LAN;
            return InternetGetConnectedState(ref flag, 0);

        }
       public bool[] sensor = new bool[2];
       public bool    lockOnSensor    ;
       public bool    lockOffSensor   ;

        public bool[] status = new bool[2];

        public bool deviceAlarmVar;
        public bool motorRun;
        public async void sensorOkumaKilitMekanizmasi( string istemciIP, TcpClient client, ModbusIpMaster master )
        {
            //start timer1, timer1.Interval = 1000 ms
            try
            {
                if (NetworkIsOk)
                {
                    #region Master to Slave
                    sensor = master.ReadInputs(0, 2);
                    lockOnSensor = sensor[0];
                    lockOffSensor = sensor[1];

                    status = master.ReadInputs(6, 2);
                    deviceAlarmVar = status[0];
                    motorRun = status[1];
                    #endregion
                }
                else
                {
               
                    //retry connecting
                    dtNow = DateTime.Now;
                    if ((dtNow - dtDisconnect) > TimeSpan.FromSeconds(10))
                    {
                        haberlesmeMesaj = (DateTime.Now.ToString() + ":Start connecting");
                        NetworkIsOk = await ConnectTask( istemciIP,  client,  master);
                        if (!NetworkIsOk)
                        {
                            haberlesmeMesaj = (DateTime.Now.ToString() + ":Connecting fail. Wait for retry");
                            dtDisconnect = DateTime.Now;
                        }
                    }
                    else
                    {
                        haberlesmeMesaj = (DateTime.Now.ToString() + ":Wait for retry connecting");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("System"))
                {
                    //set NetworkIsOk to false and retry connecting
                    NetworkIsOk = false;
                    haberlesmeMesaj = (ex.Message);
                    dtDisconnect = DateTime.Now;
                }
            }
        }

        public async void kilitAc(string istemciIP, TcpClient client, ModbusIpMaster master)
        {
            //start timer1, timer1.Interval = 1000 ms
            try
            {
                if (NetworkIsOk)
                {
                    #region Master to Slave
                   master.WriteSingleCoil(2, true);//CW
                   master.WriteSingleCoil(3, true);
                    #endregion
                }
                else
                {

                    //retry connecting
                    dtNow = DateTime.Now;
                    if ((dtNow - dtDisconnect) > TimeSpan.FromSeconds(10))
                    {
                        haberlesmeMesaj = (DateTime.Now.ToString() + ":Start connecting");
                        NetworkIsOk = await ConnectTask(istemciIP, client, master);
                        if (!NetworkIsOk)
                        {
                            haberlesmeMesaj = (DateTime.Now.ToString() + ":Connecting fail. Wait for retry");
                            dtDisconnect = DateTime.Now;
                        }
                    }
                    else
                    {
                        haberlesmeMesaj = (DateTime.Now.ToString() + ":Wait for retry connecting");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("System"))
                {
                    //set NetworkIsOk to false and retry connecting
                    NetworkIsOk = false;
                    haberlesmeMesaj = (ex.Message);
                    dtDisconnect = DateTime.Now;
                }
            }
        }

        public async void kilitKapat(string istemciIP, TcpClient client, ModbusIpMaster master)
        {
            //start timer1, timer1.Interval = 1000 ms
            try
            {
                if (NetworkIsOk)
                {
                    #region Master to Slave
                    master.WriteSingleCoil(2, false);//CW
                    master.WriteSingleCoil(3, true);
                    #endregion
                }
                else
                {

                    //retry connecting
                    dtNow = DateTime.Now;
                    if ((dtNow - dtDisconnect) > TimeSpan.FromSeconds(10))
                    {
                        haberlesmeMesaj = (DateTime.Now.ToString() + ":Start connecting");
                        NetworkIsOk = await ConnectTask(istemciIP, client, master);
                        if (!NetworkIsOk)
                        {
                            haberlesmeMesaj = (DateTime.Now.ToString() + ":Connecting fail. Wait for retry");
                            dtDisconnect = DateTime.Now;
                        }
                    }
                    else
                    {
                        haberlesmeMesaj = (DateTime.Now.ToString() + ":Wait for retry connecting");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("System"))
                {
                    //set NetworkIsOk to false and retry connecting
                    NetworkIsOk = false;
                    haberlesmeMesaj = (ex.Message);
                    dtDisconnect = DateTime.Now;
                }
            }
        }

        public async void dur(string istemciIP, TcpClient client, ModbusIpMaster master)
        {
            //start timer1, timer1.Interval = 1000 ms
            try
            {
                if (NetworkIsOk)
                {
                    #region Master to Slave
                    master.WriteSingleCoil(3, false);//stop
                    #endregion
                }
                else
                {

                    //retry connecting
                    dtNow = DateTime.Now;
                    if ((dtNow - dtDisconnect) > TimeSpan.FromSeconds(10))
                    {
                        haberlesmeMesaj = (DateTime.Now.ToString() + ":Start connecting");
                        NetworkIsOk = await ConnectTask(istemciIP, client, master);
                        if (!NetworkIsOk)
                        {
                            haberlesmeMesaj = (DateTime.Now.ToString() + ":Connecting fail. Wait for retry");
                            dtDisconnect = DateTime.Now;
                        }
                    }
                    else
                    {
                        haberlesmeMesaj = (DateTime.Now.ToString() + ":Wait for retry connecting");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("System"))
                {
                    //set NetworkIsOk to false and retry connecting
                    NetworkIsOk = false;
                    haberlesmeMesaj = (ex.Message);
                    dtDisconnect = DateTime.Now;
                }
            }
        }

    }
}
