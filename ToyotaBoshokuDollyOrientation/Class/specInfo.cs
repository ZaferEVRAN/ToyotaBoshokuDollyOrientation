
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace ToyotaBoshokuDollyOrientation
{
    class SPECK_INFO
    {
        public string _Barkod;
        public string _Model;
        public string _Spec;
        public string _Direction;
        public  byte[] _Resim;
        public Bitmap bitmap;
        cMesajlar mesajlar = new cMesajlar();
        public bool speckInfoAdd(SPECK_INFO SPECK_INFO,byte[] resim)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("insert into SPECK_INFO values(@Barkod,@Model,@Spec,@Direction,@Resim)", con);
            cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar).Value = SPECK_INFO._Barkod;
            cmd.Parameters.Add("@Model", SqlDbType.NVarChar).Value = SPECK_INFO._Model;
            cmd.Parameters.Add("@Spec", SqlDbType.NVarChar).Value = SPECK_INFO._Spec;
            cmd.Parameters.Add("@Direction", SqlDbType.NVarChar).Value = SPECK_INFO._Direction;
            cmd.Parameters.Add("@Resim", SqlDbType.Image,resim.Length).Value = resim;
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc=Convert.ToBoolean(cmd.ExecuteNonQuery());
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

        public bool speckInfoUpdate(SPECK_INFO SPECK_INFO, byte[] resim)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update SPECK_INFO set  Model=@Model, Spec=@Spec, Direction=@Direction,Resim=@Resim where Barkod=@Barkod", con);
            cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar).Value = SPECK_INFO._Barkod;
            cmd.Parameters.Add("@Model", SqlDbType.NVarChar).Value = SPECK_INFO._Model;
            cmd.Parameters.Add("@Spec", SqlDbType.NVarChar).Value = SPECK_INFO._Spec;
            cmd.Parameters.Add("@Direction", SqlDbType.NVarChar).Value = SPECK_INFO._Direction;
            cmd.Parameters.Add("@Resim", SqlDbType.Image,resim.Length).Value = resim;

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

        public bool speckInfoDelete(string _barkod)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("delete from SPECK_INFO where Barkod=@Barkod", con);
            cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar).Value = _barkod;

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

        public SPECK_INFO speckInfoSearch(string _barkod)
        {
            MemoryStream ms = new MemoryStream();
            SPECK_INFO info = new SPECK_INFO();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from SPECK_INFO where Barkod=@Barkod", con);
            cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar).Value = _barkod;
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr =cmd.ExecuteReader();
                while (dr.Read())
                {
                    info._Barkod = Convert.ToString(dr["Barkod"]);
                    info._Model = Convert.ToString(dr["Model"]);
                    info._Spec = Convert.ToString(dr["Spec"]);
                    info._Direction = Convert.ToString(dr["Direction"]);
                    info._Resim = (byte[])(dr["Resim"]);

                }
                if (info._Resim!=null)
                {
                    ms.Write(info._Resim, 0, info._Resim.Length);              
                    info.bitmap = new Bitmap(ms);
                    colorConvert resim = new colorConvert();
                    info.bitmap = resim.resimCevir(info.bitmap, info._Model);
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

        public void barkodsList(Bunifu.UI.WinForms.BunifuDataGridView dg)
        {
        
         
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT Barkod, Model, Spec, Direction FROM SPECK_INFO", con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dg.DataSource = ds;
              
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


         
        }
    }
}
