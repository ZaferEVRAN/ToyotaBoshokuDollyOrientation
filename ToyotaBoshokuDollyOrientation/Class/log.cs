using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ToyotaBoshokuDollyOrientation
{
    class log
    {
        public uint     _BARKODSID;
        public string   _LINE;
        public string   _KARKASID;
        public string   _TELEMAIL;
        public string   _SPECKODU;
        public string   _TYPE;
        public string   _MODEL;
        public string   _DOLLY_NO;
        public string   _DOLLY_ADRESS;
        public string   _DOLLY_ADRESS_DIR;
        public string   _SETCOUNT;
        public string   _OK_REWORK;
        public DateTime _DATE;
        public DateTime _TIME;
        public string   _KARKAS_USER;

        cMesajlar mesaj = new cMesajlar();
        public bool logOlustur(uint barkodID,string line, uint karkasID, string telemail, string modelkodu, string speckodu,string type,string model,string dolly_no, string dolly_adress, string dolly_adres_dir,float setcount, string ok_rework,string karkas_user)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("insert into LOG values (@BARKODSID,@LINE,@KARKASID,@TELEMAIL,@MODELKODU,@SPECKODU,@TYPE,@MODEL,@DOLLY_NO,@DOLLY_ADRESS,@DOLLY_ADRES_DIR,@SETCOUNT,@OK_REWORK,null,@TIME,@KARKAS_USER)", con);
            cmd.Parameters.Add("@BARKODSID", SqlDbType.BigInt).Value = barkodID;
            cmd.Parameters.Add("@LINE", SqlDbType.NChar).Value = line;
            cmd.Parameters.Add("@KARKASID", SqlDbType.BigInt).Value = karkasID;
            cmd.Parameters.Add("@TELEMAIL", SqlDbType.NVarChar).Value =telemail;
            cmd.Parameters.Add("@MODELKODU", SqlDbType.NVarChar).Value = modelkodu;
            cmd.Parameters.Add("@SPECKODU", SqlDbType.NVarChar).Value = speckodu;
            cmd.Parameters.Add("@TYPE", SqlDbType.NVarChar).Value = type;
            cmd.Parameters.Add("@MODEL", SqlDbType.NVarChar).Value = model;
            cmd.Parameters.Add("@DOLLY_NO", SqlDbType.NVarChar).Value = dolly_no;
            cmd.Parameters.Add("@DOLLY_ADRESS", SqlDbType.NVarChar).Value = dolly_adress;
            cmd.Parameters.Add("@DOLLY_ADRES_DIR", SqlDbType.NChar).Value = dolly_adres_dir;
            cmd.Parameters.Add("@SETCOUNT", SqlDbType.Float).Value = setcount;
            cmd.Parameters.Add("@OK_REWORK", SqlDbType.NVarChar).Value = ok_rework;
           // cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value =DateTime.Now;
            cmd.Parameters.Add("@TIME", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@KARKAS_USER", SqlDbType.NVarChar).Value =karkas_user;
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                mesaj.hata(ex);
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }


        public void log_Listele(Bunifu.UI.WinForms.BunifuDataGridView dg)
        {
           

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LOG WHERE TIME >= GETDATE() - 3  ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dg.DataSource = ds.Tables[0];

               

            }
            catch (Exception ex)
            {
                mesaj.hata(ex);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

       
        }

        public bool logDollyNoGuncelle_LH(string dolly_no)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("insert into LOG values (@BARKODSID,@LINE,@KARKASID,@TELEMAIL,@MODELKODU,@SPECKODU,@TYPE,@MODEL,@DOLLY_NO,@DOLLY_ADRESS,@DOLLY_ADRES_DIR,@SETCOUNT,@OK_REWORK,null,@TIME,@KARKAS_USER)", con);

            cmd.Parameters.Add("@DOLLY_NO", SqlDbType.NVarChar).Value = dolly_no;
 
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
                mesaj.hata(ex);
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }

        public bool logDollyNoGuncelle_RH(string dolly_no)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("insert into LOG values (@BARKODSID,@LINE,@KARKASID,@TELEMAIL,@MODELKODU,@SPECKODU,@TYPE,@MODEL,@DOLLY_NO,@DOLLY_ADRESS,@DOLLY_ADRES_DIR,@SETCOUNT,@OK_REWORK,null,@TIME,@KARKAS_USER)", con);

            cmd.Parameters.Add("@DOLLY_NO", SqlDbType.NVarChar).Value = dolly_no;

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
                mesaj.hata(ex);
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }

    }
}
