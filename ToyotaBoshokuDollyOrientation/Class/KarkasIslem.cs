using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
namespace ToyotaBoshokuDollyOrientation
{
    public enum gorevDurumlari :byte
    {
        gorevIslemYok=0,
        gorevYapiliyor=1,
        gorevYapildi=2
    }
  

    class KarkasIslem
    {
        public uint  _ID;// [bigint] IDENTITY(1,1) NOT NULL,
        public float _SETCOUNT;// [float] NULL,
        public uint  _DOLLYNO;// [int] NULL,
        public DateTime  _STARTDATE;//[date] NULL,
        public DateTime _STARTTIME;// [time](0) NULL,
        public uint      _FR_LH_1;// [tinyint] NULL,
        public uint      _FR_LH_1_BARKODID ;//[bigint] NULL,
        public uint      _RR_LH_1;// [tinyint] NULL,
        public uint      _RR_LH_1_BARKODID ;//[bigint] NULL,
        public uint      _FR_LH_2 ;//[tinyint] NULL,
        public uint      _FR_LH_2_BARKODID;// [bigint] NULL,
        public uint      _RR_LH_2 ;//[tinyint] NULL,
        public uint      _RR_LH_2_BARKODID;// [bigint] NULL,
        public uint      _FR_LH_3;// [tinyint] NULL,
        public uint      _FR_LH_3_BARKODID;// [bigint] NULL,
        public uint      _RR_LH_3 ;//[tinyint] NULL,
        public uint      _RR_LH_3_BARKODID ;//[bigint] NULL,
        public uint      _FR_LH_4;// [tinyint] NULL,
        public uint      _FR_LH_4_BARKODID;// [bigint] NULL,
        public uint      _RR_LH_4 ;//[tinyint] NULL,
        public uint      _RR_LH_4_BARKODID;// [bigint] NULL,
        public uint      _FR_LH_5 ;//[tinyint] NULL,
        public uint      _FR_LH_5_BARKODID;// [bigint] NULL,
        public uint      _RR_LH_5;// [tinyint] NULL,
        public uint      _RR_LH_5_BARKODID;// [bigint] NULL,
        public uint      _FR_LH_6;// [tinyint] NULL,
        public uint      _FR_LH_6_BARKODID;// [bigint] NULL,
        public uint      _RR_LH_6;// [tinyint] NULL,
        public uint      _RR_LH_6_BARKODID;// [bigint] NULL,
        public uint      _FR_LH_7;// [tinyint] NULL,
        public uint      _FR_LH_7_BARKODID;// [bigint] NULL,
        public uint      _RR_LH_7 ;//[tinyint] NULL,
        public uint      _RR_LH_7_BARKODID ;//[bigint] NULL,
        public uint      _FR_LH_8;// [tinyint] NULL,
        public uint      _FR_LH_8_BARKODID;// [bigint] NULL,
        public uint      _RR_LH_8;// [tinyint] NULL,
        public uint      _RR_LH_8_BARKODID;// [bigint] NULL,
        public uint      _FR_LH_9;// [tinyint] NULL,
        public uint      _FR_LH_9_BARKODID;// [bigint] NULL,
        public uint      _RR_LH_9 ;//[tinyint] NULL,
        public uint      _RR_LH_9_BARKODID;// [bigint] NULL,
        public uint      _FR_LH_10 ;//[tinyint] NULL,
        public uint      _FR_LH_10_BARKODID ;//[bigint] NULL,
        public uint      _RR_LH_10;// [tinyint] NULL,
        public uint      _RR_LH_10_BARKODID;// [bigint] NULL,
        public uint      _FR_RH_1;// [tinyint] NULL,
        public uint      _FR_RH_1_BARKODID;//[bigint] NULL,
        public uint      _RR_RH_1;// [tinyint] NULL,
        public uint      _RR_RH_1_BARKODID;//[bigint] NULL,
        public uint      _FR_RH_2;//[tinyint] NULL,
        public uint      _FR_RH_2_BARKODID;// [bigint] NULL,
        public uint      _RR_RH_2;//[tinyint] NULL,
        public uint      _RR_RH_2_BARKODID;// [bigint] NULL,
        public uint      _FR_RH_3;// [tinyint] NULL,
        public uint      _FR_RH_3_BARKODID;// [bigint] NULL,
        public uint      _RR_RH_3;//[tinyint] NULL,
        public uint      _RR_RH_3_BARKODID;//[bigint] NULL,
        public uint      _FR_RH_4;// [tinyint] NULL,
        public uint      _FR_RH_4_BARKODID;// [bigint] NULL,
        public uint      _RR_RH_4;//[tinyint] NULL,
        public uint      _RR_RH_4_BARKODID;// [bigint] NULL,
        public uint      _FR_RH_5;//[tinyint] NULL,
        public uint      _FR_RH_5_BARKODID;// [bigint] NULL,
        public uint      _RR_RH_5;// [tinyint] NULL,
        public uint      _RR_RH_5_BARKODID;// [bigint] NULL,
        public uint      _FR_RH_6;// [tinyint] NULL,
        public uint      _FR_RH_6_BARKODID;// [bigint] NULL,
        public uint      _RR_RH_6;// [tinyint] NULL,
        public uint      _RR_RH_6_BARKODID;// [bigint] NULL,
        public uint      _FR_RH_7;// [tinyint] NULL,
        public uint      _FR_RH_7_BARKODID;// [bigint] NULL,
        public uint      _RR_RH_7;//[tinyint] NULL,
        public uint      _RR_RH_7_BARKODID;//[bigint] NULL,
        public uint      _FR_RH_8;// [tinyint] NULL,
        public uint      _FR_RH_8_BARKODID;// [bigint] NULL,
        public uint      _RR_RH_8;// [tinyint] NULL,
        public uint      _RR_RH_8_BARKODID;// [bigint] NULL,
        public uint      _FR_RH_9;// [tinyint] NULL,
        public uint      _FR_RH_9_BARKODID;// [bigint] NULL,
        public uint      _RR_RH_9;//[tinyint] NULL,
        public uint      _RR_RH_9_BARKODID;// [bigint] NULL,
        public uint      _FR_RH_10;//[tinyint] NULL,
        public uint      _FR_RH_10_BARKODID;//[bigint] NULL,
        public uint      _RR_RH_10;// [tinyint] NULL,
        public uint      _RR_RH_10_BARKODID;// [bigint] NULL,

        public string  _FR_LH_1_BARKOD     ;  
        public string  _RR_LH_1_BARKOD     ;
        public string  _FR_LH_2_BARKOD     ;
        public string  _RR_LH_2_BARKOD     ;
        public string  _FR_LH_3_BARKOD     ;
        public string  _RR_LH_3_BARKOD     ;
        public string  _FR_LH_4_BARKOD     ;
        public string  _RR_LH_4_BARKOD     ;
        public string  _FR_LH_5_BARKOD     ;
        public string  _RR_LH_5_BARKOD     ;
        public string  _FR_LH_6_BARKOD     ;
        public string  _RR_LH_6_BARKOD     ;
        public string  _FR_LH_7_BARKOD     ;
        public string  _RR_LH_7_BARKOD     ;
        public string  _FR_LH_8_BARKOD     ;
        public string  _RR_LH_8_BARKOD     ;
        public string  _FR_LH_9_BARKOD     ;
        public string  _RR_LH_9_BARKOD     ;
        public string  _FR_LH_10_BARKOD    ;
        public string  _RR_LH_10_BARKOD;
        public string  _FR_RH_1_BARKOD;
        public string  _RR_RH_1_BARKOD;
        public string  _FR_RH_2_BARKOD;
        public string  _RR_RH_2_BARKOD;
        public string  _FR_RH_3_BARKOD;
        public string  _RR_RH_3_BARKOD;
        public string  _FR_RH_4_BARKOD;
        public string  _RR_RH_4_BARKOD;
        public string  _FR_RH_5_BARKOD;
        public string  _RR_RH_5_BARKOD;
        public string  _FR_RH_6_BARKOD;
        public string  _RR_RH_6_BARKOD;
        public string  _FR_RH_7_BARKOD;
        public string  _RR_RH_7_BARKOD;
        public string  _FR_RH_8_BARKOD;
        public string  _RR_RH_8_BARKOD;
        public string  _FR_RH_9_BARKOD;
        public string  _RR_RH_9_BARKOD;
        public string  _FR_RH_10_BARKOD;
        public string  _RR_RH_10_BARKOD;
        public DateTime _FINISHDATE;// [date] NULL,
        public DateTime _FINISHTIME;//[time](0) NULL,
        public uint _STATUS;//[tinyint] NULL,
        public List<string> listBARKODID = new List<string>();
        public List<string> listBARKOD = new List<string>();
        public List<string> listSTATUS = new List<string>();
        cMesajlar mesajlar = new cMesajlar();
        public bool gorevOlustur_LH(uint dollyNo)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("insert into LH_KARKAS(DOLLYNO,STARTDATE,STARTTIME,STATUS)" +
                "VALUES(@DOLLYNO," +
                "@STARTDATE," +
                "@STARTTIME," +
                "@STATUS) ", con);


            cmd.Parameters.Add("@DOLLYNO", SqlDbType.Int).Value = dollyNo;
            cmd.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@STARTTIME", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@STATUS", SqlDbType.TinyInt).Value = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public bool gorevOlustur_RH(uint dollyNo)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("insert into RH_KARKAS(DOLLYNO,STARTDATE,STARTTIME,STATUS)" +
                "VALUES(@DOLLYNO," +
                "@STARTDATE," +
                "@STARTTIME," +
                "@STATUS) ", con);


            cmd.Parameters.Add("@DOLLYNO", SqlDbType.Int).Value = dollyNo;
            cmd.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@STARTTIME", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@STATUS", SqlDbType.TinyInt).Value = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public KarkasIslem gorevSorgula_LH(byte gorevDurum)
        {
            KarkasIslem gorevInfo = new KarkasIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from LH_KARKAS where STATUS='"+gorevDurum+"'", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();

                while(dr.Read())
                {

                        gorevInfo._ID                = Convert.ToUInt32(dr["ID"]);
                        gorevInfo._DOLLYNO           = Convert.ToUInt32(dr["DOLLYNO"]);
                        gorevInfo._STATUS            = Convert.ToByte(dr["STATUS"]);
                        gorevInfo._FR_LH_1           = Convert.ToUInt32(dr["FR_LH_1"]);
                        gorevInfo._FR_LH_1_BARKODID  = Convert.ToUInt32(dr["FR_LH_1_BARKODID"]);
                        gorevInfo._RR_LH_1           = Convert.ToUInt32(dr["RR_LH_1"]);
                        gorevInfo._RR_LH_1_BARKODID  = Convert.ToUInt32(dr["RR_LH_1_BARKODID"]);
                        gorevInfo._FR_LH_2           = Convert.ToUInt32(dr["FR_LH_2"]);
                        gorevInfo._FR_LH_2_BARKODID  = Convert.ToUInt32(dr["FR_LH_2_BARKODID"]);
                        gorevInfo._RR_LH_2           = Convert.ToUInt32(dr["RR_LH_2"]);
                        gorevInfo._RR_LH_2_BARKODID  = Convert.ToUInt32(dr["RR_LH_2_BARKODID"]);
                        gorevInfo._FR_LH_3           = Convert.ToUInt32(dr["FR_LH_3"]);
                        gorevInfo._FR_LH_3_BARKODID  = Convert.ToUInt32(dr["FR_LH_3_BARKODID"]);
                        gorevInfo._RR_LH_3           = Convert.ToUInt32(dr["RR_LH_3"]);
                        gorevInfo._RR_LH_3_BARKODID  = Convert.ToUInt32(dr["RR_LH_3_BARKODID"]);
                        gorevInfo._FR_LH_4           = Convert.ToUInt32(dr["FR_LH_4"]);
                        gorevInfo._FR_LH_4_BARKODID  = Convert.ToUInt32(dr["FR_LH_4_BARKODID"]);
                        gorevInfo._RR_LH_4           = Convert.ToUInt32(dr["RR_LH_4"]);
                        gorevInfo._RR_LH_4_BARKODID  = Convert.ToUInt32(dr["RR_LH_4_BARKODID"]);
                        gorevInfo._FR_LH_5           = Convert.ToUInt32(dr["FR_LH_5"]);
                        gorevInfo._FR_LH_5_BARKODID  = Convert.ToUInt32(dr["FR_LH_5_BARKODID"]);
                        gorevInfo._RR_LH_5           = Convert.ToUInt32(dr["RR_LH_5"]);
                        gorevInfo._RR_LH_5_BARKODID  = Convert.ToUInt32(dr["RR_LH_5_BARKODID"]);
                        gorevInfo._FR_LH_6           = Convert.ToUInt32(dr["FR_LH_6"]);
                        gorevInfo._FR_LH_6_BARKODID  = Convert.ToUInt32(dr["FR_LH_6_BARKODID"]);
                        gorevInfo._RR_LH_6           = Convert.ToUInt32(dr["RR_LH_6"]);
                        gorevInfo._RR_LH_6_BARKODID  = Convert.ToUInt32(dr["RR_LH_6_BARKODID"]);
                        gorevInfo._FR_LH_7           = Convert.ToUInt32(dr["FR_LH_7"]);
                        gorevInfo._FR_LH_7_BARKODID  = Convert.ToUInt32(dr["FR_LH_7_BARKODID"]);
                        gorevInfo._RR_LH_7           = Convert.ToUInt32(dr["RR_LH_7"]);
                        gorevInfo._RR_LH_7_BARKODID  = Convert.ToUInt32(dr["RR_LH_7_BARKODID"]);
                        gorevInfo._FR_LH_8           = Convert.ToUInt32(dr["FR_LH_8"]);
                        gorevInfo._FR_LH_8_BARKODID  = Convert.ToUInt32(dr["FR_LH_8_BARKODID"]);
                        gorevInfo._RR_LH_8           = Convert.ToUInt32(dr["RR_LH_8"]);
                        gorevInfo._RR_LH_8_BARKODID  = Convert.ToUInt32(dr["RR_LH_8_BARKODID"]);
                        gorevInfo._FR_LH_9           = Convert.ToUInt32(dr["FR_LH_9"]);
                        gorevInfo._FR_LH_9_BARKODID  = Convert.ToUInt32(dr["FR_LH_9_BARKODID"]);
                        gorevInfo._RR_LH_9           = Convert.ToUInt32(dr["RR_LH_9"]);
                        gorevInfo._RR_LH_9_BARKODID  = Convert.ToUInt32(dr["RR_LH_9_BARKODID"]);
                        gorevInfo._FR_LH_10          = Convert.ToUInt32(dr["FR_LH_10"]);
                        gorevInfo._FR_LH_10_BARKODID = Convert.ToUInt32(dr["FR_LH_10_BARKODID"]);
                        gorevInfo._RR_LH_10          = Convert.ToUInt32(dr["RR_LH_10"]);
                        gorevInfo._RR_LH_10_BARKODID = Convert.ToUInt32(dr["RR_LH_10_BARKODID"]);
                        gorevInfo._FR_LH_1_BARKOD    = Convert.ToString(dr["FR_LH_1_BARKOD"]);
                        gorevInfo._RR_LH_1_BARKOD    = Convert.ToString(dr["RR_LH_1_BARKOD"]);
                        gorevInfo._FR_LH_2_BARKOD    = Convert.ToString(dr["FR_LH_2_BARKOD"]);
                        gorevInfo._RR_LH_2_BARKOD    = Convert.ToString(dr["RR_LH_2_BARKOD"]);
                        gorevInfo._FR_LH_3_BARKOD    = Convert.ToString(dr["FR_LH_3_BARKOD"]);
                        gorevInfo._RR_LH_3_BARKOD    = Convert.ToString(dr["RR_LH_3_BARKOD"]);
                        gorevInfo._FR_LH_4_BARKOD    = Convert.ToString(dr["FR_LH_4_BARKOD"]);
                        gorevInfo._RR_LH_4_BARKOD    = Convert.ToString(dr["RR_LH_4_BARKOD"]);
                        gorevInfo._FR_LH_5_BARKOD    = Convert.ToString(dr["FR_LH_5_BARKOD"]);
                        gorevInfo._RR_LH_5_BARKOD    = Convert.ToString(dr["RR_LH_5_BARKOD"]);
                        gorevInfo._FR_LH_6_BARKOD    = Convert.ToString(dr["FR_LH_6_BARKOD"]);
                        gorevInfo._RR_LH_6_BARKOD    = Convert.ToString(dr["RR_LH_6_BARKOD"]);
                        gorevInfo._FR_LH_7_BARKOD    = Convert.ToString(dr["FR_LH_7_BARKOD"]);
                        gorevInfo._RR_LH_7_BARKOD    = Convert.ToString(dr["RR_LH_7_BARKOD"]);
                        gorevInfo._FR_LH_8_BARKOD    = Convert.ToString(dr["FR_LH_8_BARKOD"]);
                        gorevInfo._RR_LH_8_BARKOD    = Convert.ToString(dr["RR_LH_8_BARKOD"]);
                        gorevInfo._FR_LH_9_BARKOD    = Convert.ToString(dr["FR_LH_9_BARKOD"]);
                        gorevInfo._RR_LH_9_BARKOD    = Convert.ToString(dr["RR_LH_9_BARKOD"]);
                        gorevInfo._FR_LH_10_BARKOD   = Convert.ToString(dr["FR_LH_10_BARKOD"]);
                        gorevInfo._RR_LH_10_BARKOD   = Convert.ToString(dr["RR_LH_10_BARKOD"]);
                }


            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return gorevInfo;

        }

        public KarkasIslem gorevSorgula_RH(byte gorevDurum)
        {
            KarkasIslem gorevInfo = new KarkasIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from RH_KARKAS where STATUS='" + gorevDurum + "'", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    gorevInfo._ID = Convert.ToUInt32(dr["ID"]);
                    gorevInfo._DOLLYNO = Convert.ToUInt32(dr["DOLLYNO"]);
                    gorevInfo._STATUS = Convert.ToByte(dr["STATUS"]);
                    gorevInfo._FR_RH_1                  = Convert.ToUInt32(dr["FR_RH_1"]);
                    gorevInfo._FR_RH_1_BARKODID         = Convert.ToUInt32(dr["FR_RH_1_BARKODID"]);
                    gorevInfo._RR_RH_1                  = Convert.ToUInt32(dr["RR_RH_1"]);
                    gorevInfo._RR_RH_1_BARKODID         = Convert.ToUInt32(dr["RR_RH_1_BARKODID"]);
                    gorevInfo._FR_RH_2                  = Convert.ToUInt32(dr["FR_RH_2"]);
                    gorevInfo._FR_RH_2_BARKODID         = Convert.ToUInt32(dr["FR_RH_2_BARKODID"]);
                    gorevInfo._RR_RH_2                  = Convert.ToUInt32(dr["RR_RH_2"]);
                    gorevInfo._RR_RH_2_BARKODID         = Convert.ToUInt32(dr["RR_RH_2_BARKODID"]);
                    gorevInfo._FR_RH_3                  = Convert.ToUInt32(dr["FR_RH_3"]);
                    gorevInfo._FR_RH_3_BARKODID         = Convert.ToUInt32(dr["FR_RH_3_BARKODID"]);
                    gorevInfo._RR_RH_3                  = Convert.ToUInt32(dr["RR_RH_3"]);
                    gorevInfo._RR_RH_3_BARKODID         = Convert.ToUInt32(dr["RR_RH_3_BARKODID"]);
                    gorevInfo._FR_RH_4                  = Convert.ToUInt32(dr["FR_RH_4"]);
                    gorevInfo._FR_RH_4_BARKODID         = Convert.ToUInt32(dr["FR_RH_4_BARKODID"]);
                    gorevInfo._RR_RH_4                  = Convert.ToUInt32(dr["RR_RH_4"]);
                    gorevInfo._RR_RH_4_BARKODID         = Convert.ToUInt32(dr["RR_RH_4_BARKODID"]);
                    gorevInfo._FR_RH_5                  = Convert.ToUInt32(dr["FR_RH_5"]);
                    gorevInfo._FR_RH_5_BARKODID         = Convert.ToUInt32(dr["FR_RH_5_BARKODID"]);
                    gorevInfo._RR_RH_5                  = Convert.ToUInt32(dr["RR_RH_5"]);
                    gorevInfo._RR_RH_5_BARKODID         = Convert.ToUInt32(dr["RR_RH_5_BARKODID"]);
                    gorevInfo._FR_RH_6                  = Convert.ToUInt32(dr["FR_RH_6"]);
                    gorevInfo._FR_RH_6_BARKODID         = Convert.ToUInt32(dr["FR_RH_6_BARKODID"]);
                    gorevInfo._RR_RH_6                  = Convert.ToUInt32(dr["RR_RH_6"]);
                    gorevInfo._RR_RH_6_BARKODID         = Convert.ToUInt32(dr["RR_RH_6_BARKODID"]);
                    gorevInfo._FR_RH_7                  = Convert.ToUInt32(dr["FR_RH_7"]);
                    gorevInfo._FR_RH_7_BARKODID         = Convert.ToUInt32(dr["FR_RH_7_BARKODID"]);
                    gorevInfo._RR_RH_7                  = Convert.ToUInt32(dr["RR_RH_7"]);
                    gorevInfo._RR_RH_7_BARKODID         = Convert.ToUInt32(dr["RR_RH_7_BARKODID"]);
                    gorevInfo._FR_RH_8                  = Convert.ToUInt32(dr["FR_RH_8"]);
                    gorevInfo._FR_RH_8_BARKODID         = Convert.ToUInt32(dr["FR_RH_8_BARKODID"]);
                    gorevInfo._RR_RH_8                  = Convert.ToUInt32(dr["RR_RH_8"]);
                    gorevInfo._RR_RH_8_BARKODID         = Convert.ToUInt32(dr["RR_RH_8_BARKODID"]);
                    gorevInfo._FR_RH_9                  = Convert.ToUInt32(dr["FR_RH_9"]);
                    gorevInfo._FR_RH_9_BARKODID         = Convert.ToUInt32(dr["FR_RH_9_BARKODID"]);
                    gorevInfo._RR_RH_9                  = Convert.ToUInt32(dr["RR_RH_9"]);
                    gorevInfo._RR_RH_9_BARKODID         = Convert.ToUInt32(dr["RR_RH_9_BARKODID"]);
                    gorevInfo._FR_RH_10                 = Convert.ToUInt32(dr["FR_RH_10"]);
                    gorevInfo._FR_RH_10_BARKODID        = Convert.ToUInt32(dr["FR_RH_10_BARKODID"]);
                    gorevInfo._RR_RH_10                 = Convert.ToUInt32(dr["RR_RH_10"]);
                    gorevInfo._RR_RH_10_BARKODID        = Convert.ToUInt32(dr["RR_RH_10_BARKODID"]);
                    gorevInfo._FR_RH_1_BARKOD           = Convert.ToString(dr["FR_RH_1_BARKOD"]);
                    gorevInfo._RR_RH_1_BARKOD           = Convert.ToString(dr["RR_RH_1_BARKOD"]);
                    gorevInfo._FR_RH_2_BARKOD           = Convert.ToString(dr["FR_RH_2_BARKOD"]);
                    gorevInfo._RR_RH_2_BARKOD           = Convert.ToString(dr["RR_RH_2_BARKOD"]);
                    gorevInfo._FR_RH_3_BARKOD           = Convert.ToString(dr["FR_RH_3_BARKOD"]);
                    gorevInfo._RR_RH_3_BARKOD           = Convert.ToString(dr["RR_RH_3_BARKOD"]);
                    gorevInfo._FR_RH_4_BARKOD           = Convert.ToString(dr["FR_RH_4_BARKOD"]);
                    gorevInfo._RR_RH_4_BARKOD           = Convert.ToString(dr["RR_RH_4_BARKOD"]);
                    gorevInfo._FR_RH_5_BARKOD           = Convert.ToString(dr["FR_RH_5_BARKOD"]);
                    gorevInfo._RR_RH_5_BARKOD           = Convert.ToString(dr["RR_RH_5_BARKOD"]);
                    gorevInfo._FR_RH_6_BARKOD           = Convert.ToString(dr["FR_RH_6_BARKOD"]);
                    gorevInfo._RR_RH_6_BARKOD           = Convert.ToString(dr["RR_RH_6_BARKOD"]);
                    gorevInfo._FR_RH_7_BARKOD           = Convert.ToString(dr["FR_RH_7_BARKOD"]);
                    gorevInfo._RR_RH_7_BARKOD           = Convert.ToString(dr["RR_RH_7_BARKOD"]);
                    gorevInfo._FR_RH_8_BARKOD           = Convert.ToString(dr["FR_RH_8_BARKOD"]);
                    gorevInfo._RR_RH_8_BARKOD           = Convert.ToString(dr["RR_RH_8_BARKOD"]);
                    gorevInfo._FR_RH_9_BARKOD           = Convert.ToString(dr["FR_RH_9_BARKOD"]);
                    gorevInfo._RR_RH_9_BARKOD           = Convert.ToString(dr["RR_RH_9_BARKOD"]);
                    gorevInfo._FR_RH_10_BARKOD          = Convert.ToString(dr["FR_RH_10_BARKOD"]);
                    gorevInfo._RR_RH_10_BARKOD          = Convert.ToString(dr["RR_RH_10_BARKOD"]);

                }


            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return gorevInfo;

        }

        public bool gorevDurumGuncelle_LH(uint gorevID, byte gorevDurum)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LH_KARKAS set " +
                "STATUS='" + gorevDurum + "' where ID='" + gorevID + "' ", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public bool gorevDurumGuncelle_RH(uint gorevID, byte gorevDurum)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update RH_KARKAS set " +
                "STATUS='" + gorevDurum + "' where ID='" + gorevID + "' ", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public KarkasIslem gorevDurumIslemYokveyaYapiliyorDollyLH()
        {
            KarkasIslem gorevInfo = new KarkasIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from LH_KARKAS where (STATUS=0 OR STATUS=1)", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    gorevInfo._ID = Convert.ToUInt32(dr["ID"]);
                    gorevInfo._DOLLYNO = Convert.ToUInt32(dr["DOLLYNO"]);
                    gorevInfo._STATUS = Convert.ToByte(dr["STATUS"]);

                }
               

            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return gorevInfo;

        }

        public KarkasIslem gorevDurumIslemYokveyaYapiliyorDollyRH()
        {
            KarkasIslem gorevInfo = new KarkasIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from RH_KARKAS where (STATUS=0 OR STATUS=1)", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    gorevInfo._ID = Convert.ToUInt32(dr["ID"]);
                    gorevInfo._DOLLYNO = Convert.ToUInt32(dr["DOLLYNO"]);
                    gorevInfo._STATUS = Convert.ToByte(dr["STATUS"]);

                }


            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return gorevInfo;

        }

        public bool karkasUrunBarkodDurumlariSorgula_LH(uint gorevID)
        {
            bool sonuc = false;
            KarkasIslem gorevInfo = new KarkasIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select *from LH_KARKAS where ID =" + gorevID + " ", con);

            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    
                     gorevInfo._FR_LH_1                     =Convert.ToUInt16(dr["FR_LH_1"]);
                     gorevInfo._RR_LH_1                     =Convert.ToUInt16(dr["RR_LH_1"]);
                     gorevInfo._FR_LH_2                     =Convert.ToUInt16(dr["FR_LH_2"]);
                     gorevInfo._RR_LH_2                     =Convert.ToUInt16(dr["RR_LH_2"]);
                     gorevInfo._FR_LH_3                     =Convert.ToUInt16(dr["FR_LH_3"]);
                     gorevInfo._RR_LH_3                     =Convert.ToUInt16(dr["RR_LH_3"]);
                     gorevInfo._FR_LH_4                     =Convert.ToUInt16(dr["FR_LH_4"]);
                     gorevInfo._RR_LH_4                     =Convert.ToUInt16(dr["RR_LH_4"]);
                     gorevInfo._FR_LH_5                     =Convert.ToUInt16(dr["FR_LH_5"]);
                     gorevInfo._RR_LH_5                     =Convert.ToUInt16(dr["RR_LH_5"]);
                     gorevInfo._FR_LH_6                     =Convert.ToUInt16(dr["FR_LH_6"]);
                     gorevInfo._RR_LH_6                     =Convert.ToUInt16(dr["RR_LH_6"]);        
                     gorevInfo._FR_LH_7                     =Convert.ToUInt16(dr["FR_LH_7"]);       
                     gorevInfo._RR_LH_7                     =Convert.ToUInt16(dr["RR_LH_7"]);         
                     gorevInfo._FR_LH_8                     =Convert.ToUInt16(dr["FR_LH_8"]);  
                     gorevInfo._RR_LH_8                     =Convert.ToUInt16(dr["RR_LH_8"]);        
                     gorevInfo._FR_LH_9                     =Convert.ToUInt16(dr["FR_LH_9"]);   
                     gorevInfo._RR_LH_9                     =Convert.ToUInt16(dr["RR_LH_9"]);
                     gorevInfo._FR_LH_10                    =Convert.ToUInt16(dr["FR_LH_10"]);
                     gorevInfo._RR_LH_10                    =Convert.ToUInt16(dr["RR_LH_10"]);



                }
                if (gorevInfo._FR_LH_1   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde&&
                    gorevInfo._RR_LH_1   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_2   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_2   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_3   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_3   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_4   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_4   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_5   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_5   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_6   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_6   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_7   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_7   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_8   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_8   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_9   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_9   == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_10  == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_10  == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde )
                {
                    sonuc = true;
                }
                else
                {
                    sonuc = false;
                }

            }
            catch (Exception ex)
            {

                sonuc = false;
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return sonuc;


        }

        public bool karkasUrunBarkodDurumlariSorgula_RH(uint gorevID)
        {
            bool sonuc = false;
            KarkasIslem gorevInfo = new KarkasIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select *from RH_KARKAS where ID =" + gorevID + " ", con);

            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    gorevInfo._FR_LH_1 = Convert.ToUInt16(dr["FR_RH_1"]);
                    gorevInfo._RR_LH_1 = Convert.ToUInt16(dr["RR_RH_1"]);
                    gorevInfo._FR_LH_2 = Convert.ToUInt16(dr["FR_RH_2"]);
                    gorevInfo._RR_LH_2 = Convert.ToUInt16(dr["RR_RH_2"]);
                    gorevInfo._FR_LH_3 = Convert.ToUInt16(dr["FR_RH_3"]);
                    gorevInfo._RR_LH_3 = Convert.ToUInt16(dr["RR_RH_3"]);
                    gorevInfo._FR_LH_4 = Convert.ToUInt16(dr["FR_RH_4"]);
                    gorevInfo._RR_LH_4 = Convert.ToUInt16(dr["RR_RH_4"]);
                    gorevInfo._FR_LH_5 = Convert.ToUInt16(dr["FR_RH_5"]);
                    gorevInfo._RR_LH_5 = Convert.ToUInt16(dr["RR_RH_5"]);
                    gorevInfo._FR_LH_6 = Convert.ToUInt16(dr["FR_RH_6"]);
                    gorevInfo._RR_LH_6 = Convert.ToUInt16(dr["RR_RH_6"]);
                    gorevInfo._FR_LH_7 = Convert.ToUInt16(dr["FR_RH_7"]);
                    gorevInfo._RR_LH_7 = Convert.ToUInt16(dr["RR_RH_7"]);
                    gorevInfo._FR_LH_8 = Convert.ToUInt16(dr["FR_RH_8"]);
                    gorevInfo._RR_LH_8 = Convert.ToUInt16(dr["RR_RH_8"]);
                    gorevInfo._FR_LH_9 = Convert.ToUInt16(dr["FR_RH_9"]);
                    gorevInfo._RR_LH_9 = Convert.ToUInt16(dr["RR_RH_9"]);
                    gorevInfo._FR_LH_10 = Convert.ToUInt16(dr["FR_RH_10"]);
                    gorevInfo._RR_LH_10 = Convert.ToUInt16(dr["RR_RH_10"]);



                }
                if (gorevInfo._FR_LH_1 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_1 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_2 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_2 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_3 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_3 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_4 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_4 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_5 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_5 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_6 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_6 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_7 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_7 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_8 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_8 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_9 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_9 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._FR_LH_10 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde &&
                    gorevInfo._RR_LH_10 == (byte)urunBarkodDurumlari.barkodIslemDurumUrunDollyde)
                {
                    sonuc = true;
                }
                else
                {
                    sonuc = false;
                }

            }
            catch (Exception ex)
            {

                sonuc = false;
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return sonuc;


        }


        public static string LHDollyBarkod;
        public static string RHDollyBarkod;

        public static bool xLOOP;

        cLambaKontrol lambaKontrol = new cLambaKontrol();
        cDollys dolly = new cDollys();
        barkodIslem urunBarkod = new barkodIslem();
        static AutoResetEvent _AREvt =  new AutoResetEvent(false);


        public bool urunBarkodDurumGuncelle_LH(uint gorevID, byte urunBarkodDurum, string urunBarkod,uint urunBarkodID, uint deviceID, string yon)
        {
            //index bul****
            bool result = false;
            uint index= indexBul_LH(deviceID);
            string RafAdi = string.Format("{0}_{1}", yon, index);
            string RafAdi_UrunBarkod = string.Format("{0}_{1}_BARKOD", yon, index);
            string RafAdi_UrunBarkodID = string.Format("{0}_{1}_BARKODID", yon, index);

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LH_KARKAS set " +
                ""+RafAdi+"='"+urunBarkodDurum+"', " +
                ""+RafAdi_UrunBarkod+"='"+urunBarkod+"' ," +
                    ""+RafAdi_UrunBarkodID+"="+urunBarkodID+" " +
                "where ID=" + gorevID + " ", con);
            cmd.Parameters.Add("@rafAdi", SqlDbType.NVarChar).Value = RafAdi;
            cmd.Parameters.Add("@rafAdi_UrunBarkod", SqlDbType.NVarChar).Value = RafAdi_UrunBarkod;
            cmd.Parameters.Add("@rafAdi_UrunBarkodID", SqlDbType.NVarChar).Value = RafAdi_UrunBarkodID;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public uint indexBul_LH(uint device)
        {
            uint index = 0;

            if (device == 40)
            {
                index = 1;
            }
            else if (device == 39)
            {
                index = 1;
            }
            else if (device == 38)
            {
                index = 2;
            }
            else if (device == 37)
            {
                index = 2;
            }
            else if (device == 36)
            {
                index = 3;
            }
            else if (device == 35)
            {
                index = 3;
            }
            else if (device == 34)
            {
                index = 4;
            }
            else if (device == 33)
            {
                index = 4;
            }
            else if (device == 32)
            {
                index = 5;
            }
            else if (device == 31)
            {
                index = 5;
            }
            else if (device == 50)
            {
                index = 6;
            }
            else if (device == 49)
            {
                index = 6;
            }
            else if (device == 48)
            {
                index = 7;
            }
            else if (device == 47)
            {
                index = 7;
            }
            else if (device == 46)
            {
                index = 8;
            }
            else if (device == 45)
            {
                index = 8;
            }
            else if (device == 44)
            {
                index = 9;
            }
            else if (device == 43)
            {
                index = 9;
            }
            else if (device == 42)
            {
                index = 10;
            }
            else if (device == 41)
            {
                index = 10;
            }

            return index; ;
        }//değiştir

        public uint indexBul_RH(uint device)
        {
            uint index = 0;

            if (device == 31)
            {
                index = 1;
            }
            else if (device == 32)
            {
                index = 1;
            }
            else if (device == 33)
            {
                index = 2;
            }
            else if (device == 34)
            {
                index = 2;
            }
            else if (device == 35)
            {
                index = 3;
            }
            else if (device == 36)
            {
                index = 3;
            }
            else if (device == 37)
            {
                index = 4;
            }
            else if (device == 38)
            {
                index = 4;
            }
            else if (device == 39)
            {
                index = 5;
            }
            else if (device == 40)
            {
                index = 5;
            }
            else if (device == 41)
            {
                index = 6;
            }
            else if (device == 42)
            {
                index = 6;
            }
            else if (device == 43)
            {
                index = 7;
            }
            else if (device == 44)
            {
                index = 7;
            }
            else if (device == 45)
            {
                index = 8;
            }
            else if (device == 46)
            {
                index = 8;
            }
            else if (device == 47)
            {
                index = 9;
            }
            else if (device == 48)
            {
                index = 9;
            }
            else if (device == 49)
            {
                index = 10;
            }
            else if (device == 50)
            {
                index = 10;
            }

            return index; ;
        }

        public bool gorevDurumTamamlandi_LH()
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LH_KARKAS set STATUS=2, FINISHDATE =@FINISHDATE, FINISHTIME =@FINISHTIME where STATUS=1 ", con);
            cmd.Parameters.Add("@FINISHDATE", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@FINISHTIME", SqlDbType.DateTime).Value = DateTime.Now;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public bool urunBarkodDurumGuncelle_RH(uint gorevID, byte urunBarkodDurum, string urunBarkod, uint urunBarkodID, uint deviceID, string yon)
        {
            uint index = indexBul_RH(deviceID);
            bool result = false;
            string RafAdi = string.Format("{0}_{1}", yon, index).Trim();
            string RafAdi_UrunBarkod = string.Format("{0}_{1}_BARKOD", yon, index);
            string RafAdi_UrunBarkodID = string.Format("{0}_{1}_BARKODID", yon, index);

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update RH_KARKAS set " +
                ""+ RafAdi +"='"+ urunBarkodDurum +"', " +
                ""+ RafAdi_UrunBarkod +"='"+ urunBarkod +"' ," +
                    ""+ RafAdi_UrunBarkodID +"="+ urunBarkodID +" " +
                "where ID=" + gorevID + " ", con);
            cmd.Parameters.Add("@rafAdi", SqlDbType.NVarChar).Value = RafAdi;
            cmd.Parameters.Add("@rafAdi_UrunBarkod", SqlDbType.NVarChar).Value = RafAdi_UrunBarkod;
            cmd.Parameters.Add("@rafAdi_UrunBarkodID", SqlDbType.NVarChar).Value = RafAdi_UrunBarkodID;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public bool gorevDurumTamamlandi_RH()
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update RH_KARKAS set STATUS=2, FINISHDATE =@FINISHDATE, FINISHTIME =@FINISHTIME where STATUS=1 ", con);
            cmd.Parameters.Add("@FINISHDATE", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@FINISHTIME", SqlDbType.DateTime).Value = DateTime.Now;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public List<uint> dollyPickToLightIzleme_LH()
        {
     
            List<uint> list = new List<uint>();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select *from LH_KARKAS where (STATUS=1 OR STATUS=0) ", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {



                    list.Add(Convert.ToUInt16(dr["FR_LH_1"]));
                    list.Add(Convert.ToUInt16(dr["RR_LH_1"]));
                    list.Add(Convert.ToUInt16(dr["FR_LH_2"]));
                    list.Add(Convert.ToUInt16(dr["RR_LH_2"]));
                    list.Add(Convert.ToUInt16(dr["FR_LH_3"]));
                    list.Add(Convert.ToUInt16(dr["RR_LH_3"]));
                    list.Add(Convert.ToUInt16(dr["FR_LH_4"]));
                    list.Add(Convert.ToUInt16(dr["RR_LH_4"]));
                    list.Add(Convert.ToUInt16(dr["FR_LH_5"]));
                    list.Add(Convert.ToUInt16(dr["RR_LH_5"]));
                    list.Add(Convert.ToUInt16(dr["FR_LH_6"]));
                    list.Add(Convert.ToUInt16(dr["RR_LH_6"]));
                    list.Add(Convert.ToUInt16(dr["FR_LH_7"]));
                    list.Add(Convert.ToUInt16(dr["RR_LH_7"]));
                    list.Add(Convert.ToUInt16(dr["FR_LH_8"]));
                    list.Add(Convert.ToUInt16(dr["RR_LH_8"]));
                    list.Add(Convert.ToUInt16(dr["FR_LH_9"]));
                    list.Add(Convert.ToUInt16(dr["RR_LH_9"]));
                    list.Add(Convert.ToUInt16(dr["FR_LH_10"]));
                    list.Add(Convert.ToUInt16(dr["RR_LH_10"]));



                }

            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return list;
        }

        public List<uint> dollyPickToLightIzleme_RH()
        {
      
            List<uint> list = new List<uint>();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from RH_KARKAS where (STATUS=1 OR STATUS=0) ", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    list.Add(Convert.ToUInt16(dr["FR_RH_1"]));
                    list.Add(Convert.ToUInt16(dr["RR_RH_1"]));
                    list.Add(Convert.ToUInt16(dr["FR_RH_2"]));
                    list.Add(Convert.ToUInt16(dr["RR_RH_2"]));
                    list.Add(Convert.ToUInt16(dr["FR_RH_3"]));
                    list.Add(Convert.ToUInt16(dr["RR_RH_3"]));
                    list.Add(Convert.ToUInt16(dr["FR_RH_4"]));
                    list.Add(Convert.ToUInt16(dr["RR_RH_4"]));
                    list.Add(Convert.ToUInt16(dr["FR_RH_5"]));
                    list.Add(Convert.ToUInt16(dr["RR_RH_5"]));
                    list.Add(Convert.ToUInt16(dr["FR_RH_6"]));
                    list.Add(Convert.ToUInt16(dr["RR_RH_6"]));  
                    list.Add(Convert.ToUInt16(dr["FR_RH_7"]));  
                    list.Add(Convert.ToUInt16(dr["RR_RH_7"]));  
                    list.Add(Convert.ToUInt16(dr["FR_RH_8"]));  
                    list.Add(Convert.ToUInt16(dr["RR_RH_8"]));  
                    list.Add(Convert.ToUInt16(dr["FR_RH_9"]));  
                    list.Add(Convert.ToUInt16(dr["RR_RH_9"]));
                    list.Add(Convert.ToUInt16(dr["FR_RH_10"]));
                    list.Add(Convert.ToUInt16(dr["RR_RH_10"]));



                }

            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return list;
        }

        public List<string> dollyKarkasBarkodSearch_LH()
        {
            KarkasIslem info =new KarkasIslem();
            List<string> list = new List<string>();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select *from LH_KARKAS where STATUS=1 ", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                                                                                    
                                     //list.Add(         Convert.ToString(dr["FR_LH_1_BARKODID"]));   // info._FR_LH_1_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["RR_LH_1_BARKODID"]));   // info._RR_LH_1_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["FR_LH_2_BARKODID"]));   // info._FR_LH_2_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["RR_LH_2_BARKODID"]));   // info._RR_LH_2_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["FR_LH_3_BARKODID"]));   // info._FR_LH_3_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["RR_LH_3_BARKODID"]));   // info._RR_LH_3_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["FR_LH_4_BARKODID"]));   // info._FR_LH_4_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["RR_LH_4_BARKODID"]));   // info._RR_LH_4_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["FR_LH_5_BARKODID"]));   // info._FR_LH_5_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["RR_LH_5_BARKODID"]));   // info._RR_LH_5_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["FR_LH_6_BARKODID"]));   // info._FR_LH_6_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["RR_LH_6_BARKODID"]));   // info._RR_LH_6_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["FR_LH_7_BARKODID"]));   // info._FR_LH_7_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["RR_LH_7_BARKODID"]));   // info._RR_LH_7_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["FR_LH_8_BARKODID"]));   // info._FR_LH_8_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["RR_LH_8_BARKODID"]));   // info._RR_LH_8_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["FR_LH_9_BARKODID"]));   // info._FR_LH_9_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["RR_LH_9_BARKODID"]));   // info._RR_LH_9_BARKODID= 
                                     //list.Add(         Convert.ToString(dr["RR_LH_10_BARKODID"]));   // info._RR_LH_10_BARKODID=
                                     //list.Add(         Convert.ToString(dr["FR_LH_10_BARKODID"]));   // info._FR_LH_10_BARKODID=
                                     list.Add(         Convert.ToString(dr["FR_LH_1_BARKOD"]).Trim());     // info._FR_LH_1_BARKOD=   
                                     list.Add(         Convert.ToString(dr["RR_LH_1_BARKOD"]).Trim());     // info._RR_LH_1_BARKOD=   
                                     list.Add(         Convert.ToString(dr["FR_LH_2_BARKOD"]).Trim());     // info._FR_LH_2_BARKOD=   
                                     list.Add(         Convert.ToString(dr["RR_LH_2_BARKOD"]).Trim());     // info._RR_LH_2_BARKOD=   
                                     list.Add(         Convert.ToString(dr["FR_LH_3_BARKOD"]).Trim());     // info._FR_LH_3_BARKOD=   
                                     list.Add(         Convert.ToString(dr["RR_LH_3_BARKOD"]).Trim());     // info._RR_LH_3_BARKOD=   
                                     list.Add(         Convert.ToString(dr["FR_LH_4_BARKOD"]).Trim());     // info._FR_LH_4_BARKOD=   
                                     list.Add(         Convert.ToString(dr["RR_LH_4_BARKOD"]).Trim());     // info._RR_LH_4_BARKOD=   
                                     list.Add(         Convert.ToString(dr["FR_LH_5_BARKOD"]).Trim());     // info._FR_LH_5_BARKOD=   
                                     list.Add(         Convert.ToString(dr["RR_LH_5_BARKOD"]).Trim());     // info._RR_LH_5_BARKOD=   
                                     list.Add(         Convert.ToString(dr["FR_LH_6_BARKOD"]).Trim());     // info._FR_LH_6_BARKOD=   
                                     list.Add(         Convert.ToString(dr["RR_LH_6_BARKOD"]).Trim());     // info._RR_LH_6_BARKOD=   
                                     list.Add(         Convert.ToString(dr["FR_LH_7_BARKOD"]).Trim());     // info._FR_LH_7_BARKOD=   
                                     list.Add(         Convert.ToString(dr["RR_LH_7_BARKOD"]).Trim());     // info._RR_LH_7_BARKOD=   
                                     list.Add(         Convert.ToString(dr["FR_LH_8_BARKOD"]).Trim());     // info._FR_LH_8_BARKOD=   
                                     list.Add(         Convert.ToString(dr["RR_LH_8_BARKOD"]).Trim());     // info._RR_LH_8_BARKOD=   
                                     list.Add(         Convert.ToString(dr["FR_LH_9_BARKOD"]).Trim());     // info._FR_LH_9_BARKOD=   
                                     list.Add(         Convert.ToString(dr["RR_LH_9_BARKOD"]).Trim());     // info._RR_LH_9_BARKOD=   
                                     list.Add(         Convert.ToString(dr["FR_LH_10_BARKOD"]).Trim());    // info._FR_LH_10_BARKOD=  
                                     list.Add(         Convert.ToString(dr["RR_LH_10_BARKOD"]).Trim());    //info._RR_LH_10_BARKOD =

               
                }

            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return list;
        }

        public List<string> dollyKarkasBarkodSearch_RH()
        {
            KarkasIslem info = new KarkasIslem();
            List<string> list = new List<string>();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select *from RH_KARKAS where STATUS=1 ", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {



                    //list.Add(Convert.ToString(dr["FR_RH_1_BARKODID"]));   // info._FR_LH_1_BARKODID= 
                    //list.Add(Convert.ToString(dr["RR_RH_1_BARKODID"]));   // info._RR_LH_1_BARKODID= 
                    //list.Add(Convert.ToString(dr["FR_RH_2_BARKODID"]));   // info._FR_LH_2_BARKODID= 
                    //list.Add(Convert.ToString(dr["RR_RH_2_BARKODID"]));   // info._RR_LH_2_BARKODID= 
                    //list.Add(Convert.ToString(dr["FR_RH_3_BARKODID"]));   // info._FR_LH_3_BARKODID= 
                    //list.Add(Convert.ToString(dr["RR_RH_3_BARKODID"]));   // info._RR_LH_3_BARKODID= 
                    //list.Add(Convert.ToString(dr["FR_RH_4_BARKODID"]));   // info._FR_LH_4_BARKODID= 
                    //list.Add(Convert.ToString(dr["RR_RH_4_BARKODID"]));   // info._RR_LH_4_BARKODID= 
                    //list.Add(Convert.ToString(dr["FR_RH_5_BARKODID"]));   // info._FR_LH_5_BARKODID= 
                    //list.Add(Convert.ToString(dr["RR_RH_5_BARKODID"]));   // info._RR_LH_5_BARKODID= 
                    //list.Add(Convert.ToString(dr["FR_RH_6_BARKODID"]));   // info._FR_LH_6_BARKODID= 
                    //list.Add(Convert.ToString(dr["RR_RH_6_BARKODID"]));   // info._RR_LH_6_BARKODID= 
                    //list.Add(Convert.ToString(dr["FR_RH_7_BARKODID"]));   // info._FR_LH_7_BARKODID= 
                    //list.Add(Convert.ToString(dr["RR_RH_7_BARKODID"]));   // info._RR_LH_7_BARKODID= 
                    //list.Add(Convert.ToString(dr["FR_RH_8_BARKODID"]));   // info._FR_LH_8_BARKODID= 
                    //list.Add(Convert.ToString(dr["RR_RH_8_BARKODID"]));   // info._RR_LH_8_BARKODID= 
                    //list.Add(Convert.ToString(dr["FR_RH_9_BARKODID"]));   // info._FR_LH_9_BARKODID= 
                    //list.Add(Convert.ToString(dr["RR_RH_9_BARKODID"]));   // info._RR_LH_9_BARKODID= 
                    //list.Add(Convert.ToString(dr["RR_RH_10_BARKODID"]));   // info._RR_LH_10_BARKODID=
                    //list.Add(Convert.ToString(dr["FR_RH_10_BARKODID"]));   // info._FR_LH_10_BARKODID=
                    list.Add(Convert.ToString(dr["FR_RH_1_BARKOD"]).Trim());     // info._FR_LH_1_BARKOD=   
                    list.Add(Convert.ToString(dr["RR_RH_1_BARKOD"]).Trim());     // info._RR_LH_1_BARKOD=   
                    list.Add(Convert.ToString(dr["FR_RH_2_BARKOD"]).Trim());     // info._FR_LH_2_BARKOD=   
                    list.Add(Convert.ToString(dr["RR_RH_2_BARKOD"]).Trim());     // info._RR_LH_2_BARKOD=   
                    list.Add(Convert.ToString(dr["FR_RH_3_BARKOD"]).Trim());     // info._FR_LH_3_BARKOD=   
                    list.Add(Convert.ToString(dr["RR_RH_3_BARKOD"]).Trim());     // info._RR_LH_3_BARKOD=   
                    list.Add(Convert.ToString(dr["FR_RH_4_BARKOD"]).Trim());     // info._FR_LH_4_BARKOD=   
                    list.Add(Convert.ToString(dr["RR_RH_4_BARKOD"]).Trim());     // info._RR_LH_4_BARKOD=   
                    list.Add(Convert.ToString(dr["FR_RH_5_BARKOD"]).Trim());     // info._FR_LH_5_BARKOD=   
                    list.Add(Convert.ToString(dr["RR_RH_5_BARKOD"]).Trim());     // info._RR_LH_5_BARKOD=   
                    list.Add(Convert.ToString(dr["FR_RH_6_BARKOD"]).Trim());     // info._FR_LH_6_BARKOD=   
                    list.Add(Convert.ToString(dr["RR_RH_6_BARKOD"]).Trim());     // info._RR_LH_6_BARKOD=   
                    list.Add(Convert.ToString(dr["FR_RH_7_BARKOD"]).Trim());     // info._FR_LH_7_BARKOD=   
                    list.Add(Convert.ToString(dr["RR_RH_7_BARKOD"]).Trim());     // info._RR_LH_7_BARKOD=   
                    list.Add(Convert.ToString(dr["FR_RH_8_BARKOD"]).Trim());     // info._FR_LH_8_BARKOD=   
                    list.Add(Convert.ToString(dr["RR_RH_8_BARKOD"]).Trim());     // info._RR_LH_8_BARKOD=   
                    list.Add(Convert.ToString(dr["FR_RH_9_BARKOD"]).Trim());     // info._FR_LH_9_BARKOD=   
                    list.Add(Convert.ToString(dr["RR_RH_9_BARKOD"]).Trim());     // info._RR_LH_9_BARKOD=   
                    list.Add(Convert.ToString(dr["FR_RH_10_BARKOD"]).Trim());    // info._FR_LH_10_BARKOD=  
                    list.Add(Convert.ToString(dr["RR_RH_10_BARKOD"]).Trim());    //info._RR_LH_10_BARKOD =


                }

            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return list;
        }

        public uint dollyRafSirasiSearch_RH(int index)
        {
            uint sonuc = 0;
            if (index == 0)
            {
                sonuc = 1;
            }
            else if (index == 1)
            {
                sonuc = 1;
            }
            else if (index == 2)
            {
                sonuc = 2;
            }
            else if (index == 3)
            {
                sonuc = 2;
            }
            else if (index == 4)
            {
                sonuc = 3;
            }
            else if (index == 5)
            {
                sonuc = 3;
            }
            else if (index == 6)
            {
                sonuc = 4;
            }
            else if (index == 7)
            {
                sonuc = 4;
            }
            else if (index == 8)
            {
                sonuc = 5;
            }
            else if (index == 9)
            {
                sonuc = 5;
            }
            else if (index == 10)
            {
                sonuc = 6;
            }
            else if (index == 11)
            {
                sonuc = 6;
            }
            else if (index == 12)
            {
                sonuc = 7;
            }
            else if (index == 13)
            {
                sonuc = 7;
            }
            else if (index == 14)
            {
                sonuc = 8;
            }
            else if (index == 15)
            {
                sonuc = 8;
            }
            else if (index == 16)
            {
                sonuc = 9;
            }
            else if (index == 17)
            {
                sonuc = 9;
            }
            else if (index == 18)
            {
                sonuc = 10;
            }
            else if (index == 19)
            {
                sonuc = 10;
            }
            else
                sonuc = 0;

            return sonuc;
        }

        public uint dollyRafSirasiSearch_LH(int index)
        {
            uint sonuc = 0;
            if (index == 0)
            {
                sonuc = 1;
            }
            else if (index == 1)
            {
                sonuc = 1;
            }
            else if (index == 2)
            {
                sonuc = 2;
            }
            else if (index == 3)
            {
                sonuc = 2;
            }
            else if (index == 4)
            {
                sonuc = 3;
            }
            else if (index == 5)
            {
                sonuc = 3;
            }
            else if (index == 6)
            {
                sonuc = 4;
            }
            else if (index == 7)
            {
                sonuc = 4;
            }
            else if (index == 8)
            {
                sonuc = 5;
            }
            else if (index == 9)
            {
                sonuc = 5;
            }
            else if (index == 10)
            {
                sonuc = 6;
            }
            else if (index == 11)
            {
                sonuc = 6;
            }
            else if (index == 12)
            {
                sonuc = 7;
            }
            else if (index == 13)
            {
                sonuc = 7;
            }
            else if (index == 14)
            {
                sonuc = 8;
            }
            else if (index == 15)
            {
                sonuc = 8;
            }
            else if (index == 16)
            {
                sonuc = 9;
            }
            else if (index == 17)
            {
                sonuc = 9;
            }
            else if (index == 18)
            {
                sonuc = 10;
            }
            else if (index == 19)
            {
                sonuc = 10;
            }
            else
                sonuc = 0;

            return sonuc;
        }

        public uint urunBarkodIDSearch_LH( uint dollyRafSirasi, string yon)
        {
            uint result = 0;
            string colomnID         =(string.Format("{0}_{1}_BARKODID", yon, dollyRafSirasi));

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from  LH_KARKAS  where STATUS=1   ", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result =Convert.ToUInt16(dr[colomnID]);
                }
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public uint urunBarkodSearch_LH(uint dollyRafSirasi, string yon)
        {
            uint result = 0;

            string colomnBARKOD = (string.Format("{0}_{1}_BARKOD", yon, dollyRafSirasi));

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from  LH_KARKAS  where STATUS=1   ", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = Convert.ToUInt16(dr[colomnBARKOD]);
                }
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public uint urunBarkodStatusSearch_LH(uint dollyRafSirasi, string yon)
        {
            uint result = 0;

            string colomnSTATUS = (string.Format("{0}_{1}", yon, dollyRafSirasi));

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from  LH_KARKAS  where STATUS=1   ", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = Convert.ToUInt16(dr[colomnSTATUS]);
                }
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public uint urunBarkodIDSearch_RH(uint dollyRafSirasi, string yon)
        {
            uint result = 0;
            string colomnID = (string.Format("{0}_{1}_BARKODID", yon, dollyRafSirasi));

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from  RH_KARKAS  where STATUS=1   ", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = Convert.ToUInt16(dr[colomnID]);
                }
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public uint urunBarkodSearch_RH(uint dollyRafSirasi, string yon)
        {
            uint result = 0;

            string colomnBARKOD = (string.Format("{0}_{1}_BARKOD", yon, dollyRafSirasi));

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from  RH_KARKAS  where STATUS=1   ", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = Convert.ToUInt16(dr[colomnBARKOD]);
                }
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public uint urunBarkodStatusSearch_RH(uint dollyRafSirasi, string yon)
        {
            uint result = 0;

            string colomnSTATUS = (string.Format("{0}_{1}", yon, dollyRafSirasi));

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from  RH_KARKAS  where STATUS=1   ", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = Convert.ToUInt16(dr[colomnSTATUS]);
                }
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public bool dollyYuklemeSirasiKontrol(uint dollyRafSirasi, string yon)
        {
          
            bool sonuc = false;
            if (dollyRafSirasi==1&&(yon ==cGenel.FR_LH|| yon == cGenel.FR_RH))
            {
                sonuc = true;
            }
            else
            {
                List<uint> list= new List<uint>();
                if (cGenel.MAKINE_ADI==cGenel.MAKINE_ADI_LH)
                {
                   list = dollyPickToLightIzleme_LH();

                }
                else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
                {
                    list = dollyPickToLightIzleme_RH();

                }
                int index=  dollyKarkasIndexBul(dollyRafSirasi, yon);

                if (index>0)
                {
                    for (int i = index; i > 0; i--)
                    {
                        ushort sta = Convert.ToUInt16(list[index - 1]);
                        if (sta == 1 || sta == 2)
                        {
                            sonuc = true;
                        }
                        else
                        {
                            sonuc = false;
                            break;
                        }
                    }

                }
            }
           



            return sonuc;

        }

        //indexBul bul
        public int dollyKarkasIndexBul(uint dollyRafi, string yonu)
        {
            int sonuc = -1;

            if (dollyRafi == bolmeAdi.PARTITION_1 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 0;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_1 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 1;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_2 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 2;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_2 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc =3;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_3 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 4;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_3 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 5;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_4 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 6;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_4 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 7;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_5 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 8;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_5 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 9;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_6 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 10;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_6 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 11;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_7 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 12;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_7 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 13;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_8 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 14;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_8 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 15;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_9 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 16;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_9 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 17;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_10 && (yonu == cGenel.FR_LH || yonu == cGenel.FR_RH))
            {
                sonuc = 18;
            }
            else if (dollyRafi == bolmeAdi.PARTITION_10 && (yonu == cGenel.RR_LH || yonu == cGenel.RR_RH))
            {
                sonuc = 19;
            }



            return sonuc;
        }

        public  void karkasTakip_RH(Bunifu.UI.WinForms.BunifuDataGridView dg)
        {
            // KarkasIslem info;

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
           // SqlCommand cmd = new SqlCommand("SELECT * FROM RH_KARKAS WHERE FINISHDATE >= GETDATE() - 3 ", con);
            SqlDataAdapter da = new SqlDataAdapter("SELECT DOLLYNO,STARTDATE,STARTTIME,FR_RH_1_BARKOD, RR_RH_1_BARKOD,FR_RH_2_BARKOD,RR_RH_2_BARKOD," +
                "FR_RH_3_BARKOD,RR_RH_3_BARKOD, FR_RH_4_BARKOD,RR_RH_4_BARKOD,FR_RH_5_BARKOD,RR_RH_5_BARKOD," +
                "FR_RH_6_BARKOD ,RR_RH_6_BARKOD,FR_RH_7_BARKOD,RR_RH_7_BARKOD,FR_RH_8_BARKOD,RR_RH_8_BARKOD," +
                " FR_RH_9_BARKOD,RR_RH_9_BARKOD,FR_RH_10_BARKOD,RR_RH_10_BARKOD,FINISHDATE,FINISHTIME FROM RH_KARKAS WHERE STARTDATE >= GETDATE() - 3 ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dg.DataSource = ds.Tables[0];
                /*  dr = cmd.ExecuteReader();
                  while (dr.Read())
                  {

                      info = new KarkasIslem();
                      info._DOLLYNO = Convert.ToUInt16(dr["DOLLYNO"]);
                      info._STARTDATE = Convert.ToDateTime(dr["STARTDATE"]);
                      info._STARTTIME = (TimeSpan)(dr["STARTTIME"]);
                      info._FR_RH_1_BARKOD = Convert.ToString(dr["FR_RH_1_BARKOD"]);
                      info._FR_RH_2_BARKOD = Convert.ToString(dr["FR_RH_2_BARKOD"]);
                      info._FR_RH_3_BARKOD = Convert.ToString(dr["FR_RH_3_BARKOD"]);
                      info._FR_RH_4_BARKOD = Convert.ToString(dr["FR_RH_4_BARKOD"]);
                      info._FR_RH_5_BARKOD = Convert.ToString(dr["FR_RH_5_BARKOD"]);
                      info._FR_RH_6_BARKOD = Convert.ToString(dr["FR_RH_6_BARKOD"]);
                      info._FR_RH_7_BARKOD = Convert.ToString(dr["FR_RH_7_BARKOD"]);
                      info._FR_RH_8_BARKOD = Convert.ToString(dr["FR_RH_8_BARKOD"]);
                      info._FR_RH_9_BARKOD = Convert.ToString(dr["FR_RH_9_BARKOD"]);
                      info._FR_RH_10_BARKOD = Convert.ToString(dr["FR_RH_10_BARKOD"]);
                      info._RR_RH_1_BARKOD  = Convert.ToString(dr["RR_RH_1_BARKOD"]);
                      info._RR_RH_2_BARKOD  = Convert.ToString(dr["RR_RH_2_BARKOD"]);
                      info._RR_RH_3_BARKOD  = Convert.ToString(dr["RR_RH_3_BARKOD"]);
                      info._RR_RH_4_BARKOD  = Convert.ToString(dr["RR_RH_4_BARKOD"]);
                      info._RR_RH_5_BARKOD  = Convert.ToString(dr["RR_RH_5_BARKOD"]);
                      info._RR_RH_6_BARKOD  = Convert.ToString(dr["RR_RH_6_BARKOD"]);
                      info._RR_RH_7_BARKOD  = Convert.ToString(dr["RR_RH_7_BARKOD"]);
                      info._RR_RH_8_BARKOD  = Convert.ToString(dr["RR_RH_8_BARKOD"]);
                      info._RR_RH_9_BARKOD  = Convert.ToString(dr["RR_RH_9_BARKOD"]);
                      info._RR_RH_10_BARKOD = Convert.ToString(dr["RR_RH_10_BARKOD"]);
                      info._FINISHDATE = Convert.ToDateTime(dr["FINISHDATE"]);
                      info._FINISHTIME = (TimeSpan)(dr["FINISHTIME"]);


                  }*/
              

            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

           // return karkasList;
        }


        /*  public void karkasTakip_LH(Bunifu.UI.WinForms.BunifuDataGridView dg)
          {
              KarkasIslem info;

              cGenel gnl = new cGenel();
              SqlConnection con = new SqlConnection(gnl.conString);
              SqlCommand cmd = new SqlCommand("SELECT * FROM LH_KARKAS WHERE FINISHDATE >= GETDATE() - 3 ", con);
              SqlDataReader dr = null;
              try
              {
                  if (con.State == ConnectionState.Closed)
                  {
                      con.Open();
                  }
                  dr = cmd.ExecuteReader();
                  while (dr.Read())
                  {

                      info = new KarkasIslem();
                      info._DOLLYNO = Convert.ToUInt16(dr["DOLLYNO"]);
                      info._STARTDATE = Convert.ToDateTime(dr["STARTDATE"]);
                      info._STARTTIME = (TimeSpan)(dr["STARTTIME"]);
                      info._FR_LH_1_BARKOD = Convert.ToString(dr["FR_LH_1_BARKOD"]);
                      info._FR_LH_2_BARKOD = Convert.ToString(dr["FR_LH_2_BARKOD"]);
                      info._FR_LH_3_BARKOD = Convert.ToString(dr["FR_LH_3_BARKOD"]);
                      info._FR_LH_4_BARKOD = Convert.ToString(dr["FR_LH_4_BARKOD"]);
                      info._FR_LH_5_BARKOD = Convert.ToString(dr["FR_LH_5_BARKOD"]);
                      info._FR_LH_6_BARKOD = Convert.ToString(dr["FR_LH_6_BARKOD"]);
                      info._FR_LH_7_BARKOD = Convert.ToString(dr["FR_LH_7_BARKOD"]);
                      info._FR_LH_8_BARKOD = Convert.ToString(dr["FR_LH_8_BARKOD"]);
                      info._FR_LH_9_BARKOD = Convert.ToString(dr["FR_LH_9_BARKOD"]);
                      info._FR_LH_10_BARKOD = Convert.ToString(dr["RR_LH_10_BARKOD"]);
                      info._RR_LH_1_BARKOD = Convert.ToString(dr["RR_LH_1_BARKOD"]);
                      info._RR_LH_2_BARKOD = Convert.ToString(dr["RR_LH_2_BARKOD"]);
                      info._RR_LH_3_BARKOD = Convert.ToString(dr["RR_LH_3_BARKOD"]);
                      info._RR_LH_4_BARKOD = Convert.ToString(dr["RR_LH_4_BARKOD"]);
                      info._RR_LH_5_BARKOD = Convert.ToString(dr["RR_LH_5_BARKOD"]);
                      info._RR_LH_6_BARKOD = Convert.ToString(dr["RR_LH_6_BARKOD"]);
                      info._RR_LH_7_BARKOD = Convert.ToString(dr["RR_LH_7_BARKOD"]);
                      info._RR_LH_8_BARKOD = Convert.ToString(dr["RR_LH_8_BARKOD"]);
                      info._RR_LH_9_BARKOD = Convert.ToString(dr["RR_LH_9_BARKOD"]);
                      info._RR_LH_10_BARKOD = Convert.ToString(dr["RR_LH_10_BARKOD"]);
                      info._FINISHDATE = Convert.ToDateTime(dr["FINISHDATE"]);
                      info._FINISHTIME = (TimeSpan)(dr["FINISHTIME"]);


                  }

              }
              catch (Exception ex)
              {
                  mesajlar.hata(ex);
              }
              finally
              {

                  con.Close();
                  con.Dispose();
              }

              //return karkasList;
          }*/
        public void karkasTakip_LH(Bunifu.UI.WinForms.BunifuDataGridView dg)
        {
            // KarkasIslem info;

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            // SqlCommand cmd = new SqlCommand("SELECT * FROM RH_KARKAS WHERE FINISHDATE >= GETDATE() - 3 ", con);
            SqlDataAdapter da = new SqlDataAdapter("SELECT DOLLYNO,STARTDATE,STARTTIME,FR_LH_1_BARKOD, RR_LH_1_BARKOD,FR_LH_2_BARKOD,RR_LH_2_BARKOD," +
                "FR_LH_3_BARKOD,RR_LH_3_BARKOD, FR_LH_4_BARKOD,RR_LH_4_BARKOD,FR_LH_5_BARKOD,RR_LH_5_BARKOD," +
                "FR_LH_6_BARKOD ,RR_LH_6_BARKOD,FR_LH_7_BARKOD,RR_LH_7_BARKOD,FR_LH_8_BARKOD,RR_LH_8_BARKOD," +
                " FR_LH_9_BARKOD,RR_LH_9_BARKOD,FR_LH_10_BARKOD,RR_LH_10_BARKOD,FINISHDATE,FINISHTIME FROM LH_KARKAS WHERE STARTDATE >= GETDATE() - 3 ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dg.DataSource = ds.Tables[0];
                /*  dr = cmd.ExecuteReader();
                  while (dr.Read())
                  {

                      info = new KarkasIslem();
                      info._DOLLYNO = Convert.ToUInt16(dr["DOLLYNO"]);
                      info._STARTDATE = Convert.ToDateTime(dr["STARTDATE"]);
                      info._STARTTIME = (TimeSpan)(dr["STARTTIME"]);
                      info._FR_RH_1_BARKOD = Convert.ToString(dr["FR_RH_1_BARKOD"]);
                      info._FR_RH_2_BARKOD = Convert.ToString(dr["FR_RH_2_BARKOD"]);
                      info._FR_RH_3_BARKOD = Convert.ToString(dr["FR_RH_3_BARKOD"]);
                      info._FR_RH_4_BARKOD = Convert.ToString(dr["FR_RH_4_BARKOD"]);
                      info._FR_RH_5_BARKOD = Convert.ToString(dr["FR_RH_5_BARKOD"]);
                      info._FR_RH_6_BARKOD = Convert.ToString(dr["FR_RH_6_BARKOD"]);
                      info._FR_RH_7_BARKOD = Convert.ToString(dr["FR_RH_7_BARKOD"]);
                      info._FR_RH_8_BARKOD = Convert.ToString(dr["FR_RH_8_BARKOD"]);
                      info._FR_RH_9_BARKOD = Convert.ToString(dr["FR_RH_9_BARKOD"]);
                      info._FR_RH_10_BARKOD = Convert.ToString(dr["FR_RH_10_BARKOD"]);
                      info._RR_RH_1_BARKOD  = Convert.ToString(dr["RR_RH_1_BARKOD"]);
                      info._RR_RH_2_BARKOD  = Convert.ToString(dr["RR_RH_2_BARKOD"]);
                      info._RR_RH_3_BARKOD  = Convert.ToString(dr["RR_RH_3_BARKOD"]);
                      info._RR_RH_4_BARKOD  = Convert.ToString(dr["RR_RH_4_BARKOD"]);
                      info._RR_RH_5_BARKOD  = Convert.ToString(dr["RR_RH_5_BARKOD"]);
                      info._RR_RH_6_BARKOD  = Convert.ToString(dr["RR_RH_6_BARKOD"]);
                      info._RR_RH_7_BARKOD  = Convert.ToString(dr["RR_RH_7_BARKOD"]);
                      info._RR_RH_8_BARKOD  = Convert.ToString(dr["RR_RH_8_BARKOD"]);
                      info._RR_RH_9_BARKOD  = Convert.ToString(dr["RR_RH_9_BARKOD"]);
                      info._RR_RH_10_BARKOD = Convert.ToString(dr["RR_RH_10_BARKOD"]);
                      info._FINISHDATE = Convert.ToDateTime(dr["FINISHDATE"]);
                      info._FINISHTIME = (TimeSpan)(dr["FINISHTIME"]);


                  }*/


            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            // return karkasList;
        }


        public bool gorevDurumIPTALTamamlandi_RH()
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update RH_KARKAS set STATUS=99, FINISHDATE =@FINISHDATE, FINISHTIME =@FINISHTIME where STATUS=1 OR STATUS=0  ", con);
            cmd.Parameters.Add("@FINISHDATE", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@FINISHTIME", SqlDbType.DateTime).Value = DateTime.Now;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }


        public bool gorevDurumIPTALTamamlandi_LH()
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LH_KARKAS set STATUS=99, FINISHDATE =@FINISHDATE, FINISHTIME =@FINISHTIME where STATUS=1 OR STATUS=0  ", con);
            cmd.Parameters.Add("@FINISHDATE", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@FINISHTIME", SqlDbType.DateTime).Value = DateTime.Now;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }
    }
}
