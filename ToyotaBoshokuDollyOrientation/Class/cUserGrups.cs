using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ToyotaBoshokuDollyOrientation
{
    public enum user_grup
    {
        superUser = 1,
        admin = 2
    }

    class cUserGrups
    {
        
        private uint grupID;
        private string definition;
        private bool status;

        public uint      _GrupID { get => grupID; set =>
                grupID = value; }
        public string _Definition
        {
            get => definition;
            set
            {
                if (value.Length > 0 && value.Length < 20)
                {
                    definition = value;
                }
                else if (value.Length == 0)
                {
                    cGenel.genelUyari("Grup adı boş bırakılamaz.", false);
                }
                else if (value.Length >= 20)
                {
                    cGenel.genelUyari("Grup adı 20 karakterden fazla olamaz.", false);
                }
            }
        }

        public bool _Status { get => status; set => status = value; }

        cMesajlar mesajlar = new cMesajlar();
        public bool userGrupNewAdd()
        {
            bool result = false;

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("insert into TBL_USERGRUPS(DEFINITION)" +
                "VALUES(@DEFINITION) ", con);


            cmd.Parameters.Add("@DEFINITION", SqlDbType.NVarChar).Value = definition;

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

                mesajlar.hata(ex,"");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public bool userGrupUpdate()
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_USERGRUPS set " +
                "DEFINITION='" + definition + "'" +
                    "STATUS='" + false + "'" +
               " where ID='" + grupID + "' ", con);

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

                mesajlar.hata(ex,"");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public bool userGrupDelete()
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("delete from TBL_USERGRUPS where ID='" + grupID + "'", con);

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

                mesajlar.hata(ex,"");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public List<cUserGrups> userGrupsList()
        {
            cUserGrups userGrupsInfo;
            List<cUserGrups> list = new List<cUserGrups>();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_USERGRUPS where ID != '"+(int)user_grup.superUser + "' ", con);
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
                    userGrupsInfo = new cUserGrups();
                    userGrupsInfo._GrupID = Convert.ToUInt32(dr["ID"]);
                    userGrupsInfo._Definition = Convert.ToString(dr["DEFINITION"]);
           
                    list.Add(userGrupsInfo);
                }


            }
            catch (Exception ex)
            {

                mesajlar.hata(ex,"");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return list;
        }

        public List<cUserGrups> userGrupsListSuperUserandAdmin()
        {
            cUserGrups userGrupsInfo;
            List<cUserGrups> list = new List<cUserGrups>();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_USERGRUPS where ID != '" + (int)user_grup.superUser + "' AND ID != '" + (int)user_grup.admin + "' ", con);
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
                    userGrupsInfo = new cUserGrups();
                    userGrupsInfo._GrupID = Convert.ToUInt32(dr["ID"]);
                    userGrupsInfo._Definition = Convert.ToString(dr["DEFINITION"]);

                    list.Add(userGrupsInfo);
                }


            }
            catch (Exception ex)
            {

                mesajlar.hata(ex,"");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return list;
        }

        public cUserGrups userGrupsIDInfo(uint grupID)
        {
            cUserGrups userGrupsInfo = new cUserGrups(); ;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_USERGRUPS where ID='" + grupID + "' ", con);
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
                    
                    userGrupsInfo._GrupID = Convert.ToUInt32(dr["ID"]);
                    userGrupsInfo._Definition = Convert.ToString(dr["DEFINITION"]);



                }


            }
            catch (Exception ex)
            {

                mesajlar.hata(ex,"");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return userGrupsInfo;

        }

        public cUserGrups userGrupInfo(string definition)
        {
            cUserGrups userGrupInfo = new cUserGrups();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_USERGRUPS where DEFINITION='" + definition + "' ", con);
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
                    userGrupInfo._GrupID = Convert.ToUInt32(dr["ID"]);
                    userGrupInfo._Definition = Convert.ToString(dr["DEFINITION"]);
    

                }


            }
            catch (Exception ex)
            {

                mesajlar.hata(ex,"");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return userGrupInfo;

        }

        public bool userGrupOnline(uint grupID, bool _status)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_USERGRUPS set " +
                "STATUS='" + _status + "'" +

               " where ID='" + grupID + "' ", con);

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

                mesajlar.hata(ex,"");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return result;
        }

        public cUserGrups userGrupStatusValue(uint grupID)
        {
            cUserGrups userGrupsInfo = new cUserGrups(); ;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_USERGRUPS where ID='" + grupID + "' ", con);
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

                    userGrupsInfo._GrupID = Convert.ToUInt32(dr["ID"]);
                    userGrupsInfo._Definition = Convert.ToString(dr["DEFINITION"]);
                    userGrupsInfo._Status = Convert.ToBoolean(dr["STATUS"]);


                }


            }
            catch (Exception ex)
            {

                mesajlar.hata(ex,"");
            }
            finally
            {

                con.Close();
                con.Dispose();
            }

            return userGrupsInfo;

        }


    }
}
