using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ToyotaBoshokuDollyOrientation
{
    class cDollys
    {
        public enum dollyDurumlari
        {

        }

        private uint ıD;
        private uint dollyNo;
        private string dollyBarkod;

        public uint      _DollyID { get => ıD; set => ıD = value; }
        public uint      _DollyNo { get => dollyNo; set => dollyNo = value; }
        public string   _DollyBarkod
        {
            get
            {
                return dollyBarkod;
            }

            set
            {




                dollyBarkod =value;
               
            }


        }

        cMesajlar mesajlar = new cMesajlar();

        public bool barkodsNewAddDolly(cDollys barkodsInfoDolly)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("insert into TBL_DOLLYS(DOLLYNO, DOLLYBARKOD)" +
                "VALUES(@DOLLYNO,@DOLLYBARKOD)", con);


            cmd.Parameters.Add("@DOLLYNO", SqlDbType.Int).Value = barkodsInfoDolly._DollyNo;
            cmd.Parameters.Add("@DOLLYBARKOD", SqlDbType.NVarChar).Value = barkodsInfoDolly._DollyBarkod;

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

                mesajlar.hata(ex, "barkodsNewAddDolly");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public bool barkodsUpdateDolly(cDollys barkodsInfoDolly)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_DOLLYS set " +
                "DOLLYNO='" + barkodsInfoDolly._DollyNo + "'," +
                "DOLLYBARKOD='" + barkodsInfoDolly._DollyBarkod + "'" +              
                " where ID='" + barkodsInfoDolly._DollyID + "' ", con);

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

                mesajlar.hata(ex, "barkodsUpdateDolly");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public bool barkodsDeleteDolly(cDollys barkodsInfoDolly)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("delete from TBL_DOLLYS where ID='" + barkodsInfoDolly._DollyID + "'", con);

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

                mesajlar.hata(ex, "barkodsDeleteDolly");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public List<cDollys> barkodsListDolly()
        {
            cDollys barkodsInfoDolly;
            List<cDollys> list = new List<cDollys>();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_DOLLYS ", con);
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
                    barkodsInfoDolly = new cDollys();
                    barkodsInfoDolly._DollyID = Convert.ToUInt32(dr["ID"]);
                    barkodsInfoDolly._DollyNo = Convert.ToUInt32(dr["DOLLYNO"]);
                    barkodsInfoDolly._DollyBarkod = Convert.ToString(dr["DOLLYBARKOD"]);
     
                    list.Add(barkodsInfoDolly);
                }


            }
            catch (Exception ex)
            {

                mesajlar.hata(ex, "barkodsListDolly");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return list;
        }

        public cDollys dollyIDInfo(int DollyID)
        {
            cDollys DollyInfo = new cDollys();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_DOLLYS where ID='" + DollyID + "'", con);
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

                    DollyInfo._DollyID = Convert.ToUInt32(dr["ID"]);
                    DollyInfo._DollyBarkod = Convert.ToString(dr["DOLLYBARKOD"]);
                    DollyInfo._DollyNo = Convert.ToUInt32(dr["DOLLYNO"]);
               

                }


            }
            catch (Exception ex)
            {

                mesajlar.hata(ex, "dollyIDInfo");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return DollyInfo;

        }

        public cDollys dollyBarkodInfo(string dollybarkod)
        {
            cDollys dollyInfo = new cDollys();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_DOLLYS where DOLLYBARKOD='" + dollybarkod + "'", con);
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

                    dollyInfo._DollyID = Convert.ToUInt32(dr["ID"]);
                    dollyInfo._DollyBarkod = Convert.ToString(dr["DOLLYBARKOD"]);
                    dollyInfo._DollyNo = Convert.ToUInt32(dr["DOLLYNO"]);
                 

                }


            }
            catch (Exception ex)
            {

                mesajlar.hata(ex, "dollyBarkodInfo");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return dollyInfo;

        }

    }
}
