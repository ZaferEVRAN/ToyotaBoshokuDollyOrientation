using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ToyotaBoshokuDollyOrientation
{
    public enum lock_Status:byte
    {
        lock_on=0,
        lock_off=1
    }
    class cStatus
    {
        private string lock_Status;
        private byte lock_Value;
        cMesajlar mesaj = new cMesajlar();
        public string   _Lock_Status { get => lock_Status; set => lock_Status = value; }
        public byte     _Lock_Value { get => lock_Value; set => lock_Value = value; }

        public bool lockOnStatusUpdate()
        {
            bool result = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand("update TBL_STATUS set VALUE=0 where STATUS ='LOCK_STATUS'",con);
            try
            {
                if (con.State ==ConnectionState.Closed)
                {
                    con.Open();
                }
               result=Convert.ToBoolean( cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }



            return result;

        }

        public bool lockOffStatusUpdate()
        {
            bool result = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand("update TBL_STATUS set  VALUE=1 where STATUS ='LOCK_STATUS'", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }



            return result;

        }

        public byte lockStatusQuery()
        {
            byte result = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand("select * from TBL_STATUS where STATUS='LOCK_STATUS'", con);
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
                    result = Convert.ToByte(dr["VALUE"]);
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }



            return result;

        }

        public bool StatusUpdate(string name,ushort value)
        {
            bool result = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_STATUS set VALUE=@value where STATUS =@name", con);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@value", SqlDbType.BigInt).Value = value;
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
                mesaj.hata(ex,"");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }



            return result;

        }
                    
        public ushort StatusQuery(string name)
        {
            ushort result = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_STATUS where STATUS=@name", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = Convert.ToUInt16(dr["VALUE"]);
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



            return result;

        }

        public void statusColorAta()
        {
            //cGenel.lockStateValue= Convert.ToUInt32(StatusQuery(cGenel.LOCK_STATE));
            cGenel.waitStateAnimationID = Convert.ToUInt16(StatusQuery(cGenel.WAIT_STATE_ANIMATION_ID));
            cGenel.waitStateColorID = Convert.ToUInt16(StatusQuery(cGenel.WAIT_STATE_COLOR_ID));
            cGenel.mispickStateAnimationID = Convert.ToUInt16(StatusQuery(cGenel.MISPICK_STATE_ANIMATION_ID));
            cGenel.mispickStateColorID = Convert.ToUInt16(StatusQuery(cGenel.MISPICK_STATE_COLOR_ID));
            cGenel.jobState1StatusAnimationID = Convert.ToUInt16(StatusQuery(cGenel.JOB_STATE_1_STATUS_ANIMATION_ID));
            cGenel.jobState1StatusColorID = Convert.ToUInt16(StatusQuery(cGenel.JOB_STATE_1_STATUS_COLOR_ID));
            cGenel.jobState2StatusAnimationID = Convert.ToUInt16(StatusQuery(cGenel.JOB_STATE_2_STATUS_ANIMATION_ID));
            cGenel.jobState2StatusColorID = Convert.ToUInt16(StatusQuery(cGenel.JOB_STATE_2_STATUS_COLOR_ID));
            cGenel.jobStateReworkAnimationID = Convert.ToUInt16(StatusQuery(cGenel.JOB_STATE_REWORK_STATUS_ANIMATION_ID));
            cGenel.jobStateReworkColorID = Convert.ToUInt16(StatusQuery(cGenel.JOB_STATE_REWORK_STATUS_COLOR_ID));

        }


    }
}
