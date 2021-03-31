using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ToyotaBoshokuDollyOrientation
{
    class error_log
    {

        cGenel gnl;
        cMesajlar mesajlar;
        public  void error_log_kayit(string log)
        {
           
            gnl = new cGenel();
            mesajlar = new cMesajlar();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("insert into TBL_USER_LOG(ERROR_LOG, DATETIME) values(@error_log,@datetime)", con);
            cmd.Parameters.Add("@error_log", SqlDbType.NVarChar).Value =cGenel.MAKINE_ADI + " " + log ;
            cmd.Parameters.Add("@datetime", SqlDbType.DateTime).Value = DateTime.Now;

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
                mesajlar.hata(ex, "error_log_kayit");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}
