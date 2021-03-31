using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ToyotaBoshokuDollyOrientation
{
    class TBTGALC_DOOR
    {
        public float  _TBTNO;
        public float  _BODYNO;
        public string _MODEL;
        public float _TRIMNO;
        public string _SEATSPEC;
        public string _DOORSPEC;
        public string _FRL_BARCODE;
        public string _RRL_BARCODE;
        public string _FRR_BARCODE;
        public string _RRR_BARCODE;
        public string _BACKNO;
        public string _TYPE;
        cMesajlar mesaj = new cMesajlar();

        //LAST tablosu son: TBTGALC tablosundaki son TBTNO değerini verir.
        //
        public void TBTGalcLastTBTNO_Write_RH(float TBTNO)
        {
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LAST set LAST_TBTNO_RH=@TBTNO where ID=1", con);
            cmd.Parameters.Add("@TBTNO", SqlDbType.Float).Value = TBTNO;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                mesaj.hata(ex, "");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public void TBTGalcLastTBTNO_Write_LH(float TBTNO)
        {
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LAST set LAST_TBTNO_LH=@TBTNO where ID=1", con);
            cmd.Parameters.Add("@TBTNO", SqlDbType.Float).Value = TBTNO;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                mesaj.hata(ex, "");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int TBTGalcLastTBTNO_Read_RH()
        {
            int sonuc = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select LAST_TBTNO_RH from LAST where ID=1", con);
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
                    sonuc = Convert.ToInt32(dr["LAST_TBTNO_RH"]);
                }

            }
            catch (Exception ex)
            {
                mesaj.hata(ex, "");

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return sonuc;
        }

        public int TBTGalcLastTBTNO_Read_LH()
        {
            int sonuc = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select LAST_TBTNO_LH from LAST where ID=1", con);
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
                    sonuc = Convert.ToInt32(dr["LAST_TBTNO_LH"]);
                }

            }
            catch (Exception ex)
            {
                mesaj.hata(ex, "");

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return sonuc;
        }

        public List<TBTGALC_DOOR> TBTGalcDoorSpecRead_LH(float lastTBTNO)
        {
            List<TBTGALC_DOOR> list = new List<TBTGALC_DOOR>();
            TBTGALC_DOOR info ;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conStringTBT);
            SqlCommand cmd = new SqlCommand("select TOP 10 T.TBTNO, T.BODYNO,T.MODEL,T.TRIMNO,T.SEATSPEC,T.DOORSPEC,S.FRL_BARCODE,S.RRL_BARCODE,S.BACKNO,S.TYPE  from TBTGALC AS T inner join   dbo.DOOR AS S  ON T.DOORSPEC=S.SPEC where T.TBTNO>=@lastTBTNO ORDER BY T.TBTNO", con);
            cmd.Parameters.Add("@lastTBTNO", SqlDbType.Float).Value = lastTBTNO;
            SqlDataReader dr = null;
            try
            {
                if (con.State ==ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    info = new TBTGALC_DOOR();
                    info._TBTNO = Convert.ToInt32(dr["TBTNO"]);
                    info._BODYNO = Convert.ToInt32(dr["BODYNO"]);
                    info._MODEL = Convert.ToString(dr["MODEL"]);
                    info._TRIMNO = Convert.ToInt32(dr["TRIMNO"]);
                    info._SEATSPEC = Convert.ToString(dr["SEATSPEC"]);
                    info._DOORSPEC = Convert.ToString(dr["DOORSPEC"]);
                    info._FRL_BARCODE = Convert.ToString(dr["FRL_BARCODE"]);
                    info._RRL_BARCODE = Convert.ToString(dr["RRL_BARCODE"]);
                    info._BACKNO = Convert.ToString(dr["BACKNO"]);
                    info._TYPE = Convert.ToString(dr["TYPE"]);
                    list.Add(info);
                }

            }
            catch (Exception ex)
            {
                mesaj.hata(ex,"");
              
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return list;
        }

        public List<TBTGALC_DOOR> TBTGalcDoorSpecRead_RH(float lastTBTNO)
        {
            List<TBTGALC_DOOR> list = new List<TBTGALC_DOOR>();
            TBTGALC_DOOR info;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conStringTBT);
            SqlCommand cmd = new SqlCommand("select TOP 10 T.TBTNO, T.BODYNO,T.MODEL,T.TRIMNO,T.SEATSPEC,T.DOORSPEC,S.FRR_BARCODE,S.RRR_BARCODE,S.BACKNO, S.TYPE from TBTGALC AS T inner join   dbo.DOOR AS S  ON T.DOORSPEC=S.SPEC where T.TBTNO>=@lastTBTNO ORDER BY T.TBTNO", con);
            cmd.Parameters.Add("@lastTBTNO", SqlDbType.Float).Value = lastTBTNO;
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
                    info = new TBTGALC_DOOR();
                    info._TBTNO = Convert.ToInt32(dr["TBTNO"]);
                    info._BODYNO = Convert.ToInt32(dr["BODYNO"]);
                    info._MODEL = Convert.ToString(dr["MODEL"]);
                    info._TRIMNO = Convert.ToInt32(dr["TRIMNO"]);
                    info._SEATSPEC = Convert.ToString(dr["SEATSPEC"]);
                    info._DOORSPEC = Convert.ToString(dr["DOORSPEC"]);
                    info._FRR_BARCODE = Convert.ToString(dr["FRR_BARCODE"]);
                    info._RRR_BARCODE = Convert.ToString(dr["RRR_BARCODE"]);
                    info._BACKNO = Convert.ToString(dr["BACKNO"]);
                    info._TYPE = Convert.ToString(dr["TYPE"]);
                    list.Add(info);
                }

            }
            catch (Exception ex)
            {
                mesaj.hata(ex, "");

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return list;
        }

        public float TelemailIleTBTNOBul(float telemail)
        {
            float sonuc = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conStringTBT);
            SqlCommand cmd = new SqlCommand("SELECT TOP (1) TBTNO FROM TBTGALC where TRIMNO=@telemail order by TBTNO desc ", con);
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
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

                    sonuc = Convert.ToInt32(dr["TBTNO"]);
                  
                }

            }
            catch (Exception ex)
            {
                mesaj.hata(ex, "");

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return sonuc;
        }
    }
}
