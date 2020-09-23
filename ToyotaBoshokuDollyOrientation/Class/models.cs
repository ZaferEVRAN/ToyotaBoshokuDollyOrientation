using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ToyotaBoshokuDollyOrientation
{
    class models
    {
        public string _MODELNO;
        public string _MODELKODU;
        public string _MODELADI;

        cMesajlar mesajlar = new cMesajlar();
        public bool modelInfoAdd(models modelİnfo)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("insert into models values(@MODELNO,@MODELKODU,@MODELADI)", con);
            cmd.Parameters.Add("@MODELNO", SqlDbType.NVarChar).Value = modelİnfo._MODELNO;
            cmd.Parameters.Add("@MODELKODU", SqlDbType.NVarChar).Value = modelİnfo._MODELKODU;
            cmd.Parameters.Add("@MODELADI", SqlDbType.NVarChar).Value = modelİnfo._MODELADI;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
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


            return sonuc;
        }

        public bool modelInfoUpdate(models modelInfo)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update MODELS set  MODELKODU=@MODELKODU, MODELADI=@MODELADI where MODELNO=@MODELNO", con);
            cmd.Parameters.Add("@MODELKODU", SqlDbType.NVarChar).Value = modelInfo._MODELKODU;
            cmd.Parameters.Add("@MODELADI", SqlDbType.NVarChar).Value = modelInfo._MODELADI;
            cmd.Parameters.Add("@MODELNO", SqlDbType.NVarChar).Value = modelInfo._MODELNO;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
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


            return sonuc;
        }

        public bool modelInfoDelete(string MODELNO)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("delete from MODELS where MODELNO=@MODELNO", con);
            cmd.Parameters.Add("@MODELNO", SqlDbType.NVarChar).Value = MODELNO;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
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


            return sonuc;
        }

        public models speckInfoSearch(string modelNo)
        {
         
            models info = new models();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from MODELS where MODELNO=@MODELNO", con);
            cmd.Parameters.Add("@MODELNO", SqlDbType.NVarChar).Value = modelNo;
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
                    info._MODELNO = Convert.ToString(dr["MODELNO"]);
                    info._MODELKODU = Convert.ToString(dr["MODELKODU"]);
                    info._MODELADI = Convert.ToString(dr["MODELADI"]);


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


            return info;
        }

        public List<models> modelList()
        {
            List<models> list = new List<models>();
            models info;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from MODELS ", con);
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
                    info = new models();
                    info._MODELNO = Convert.ToString(dr["MODELNO"]);
                    info._MODELKODU = Convert.ToString(dr["MODELKODU"]);
                    info._MODELADI = Convert.ToString(dr["MODELADI"]);
                    list.Add(info);
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

    }
}
