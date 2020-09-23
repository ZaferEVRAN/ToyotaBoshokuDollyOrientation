using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ToyotaBoshokuDollyOrientation
{
    class cUsers
    {
        cGenel gnl = new cGenel();
        cMesajlar mesajlar = new cMesajlar();

        private uint userID;
        private string name;
        private string surname;
        private string username;
        private string password;
        private uint grupID;
        private DateTime logindate;
        private DateTime logoutdate;
        private bool userstatus;

        public uint      _UserID { get => userID; set => userID = value; }
        public string   _Name
        {
            get => name;
            set {
                   if (value.Length>0&&value.Length<20)
                   {
                       name = value;
                   }
                   else if(value.Length == 0)
                   {
                    cGenel.genelUyari("İsim boş bırakılamaz.",false);
                   }
                   else if (value.Length >= 20)
                   {
                       cGenel.genelUyari("İsim 20 karakterden fazla olamaz.", false);
                   }
            }
        }
        public string   _Surname
        {
            get => surname;
            set
            {
                if (value.Length > 0 && value.Length < 20)
                {
                    surname = value;
                }
                else if (value.Length == 0)
                {
                    cGenel.genelUyari("Soyisim boş bırakılamaz.", false);
                }
                else if (value.Length >= 20)
                {
                    cGenel.genelUyari("Soyisim 20 karakterden fazla olamaz.", false);
                }
            }
        }
        public string   _Password
        {
            get => password;
            set
            {
              
                    password = value;
               
            }
        }
        public uint      _GrupID { get => grupID; set => grupID = value; }
        public DateTime _Logindate { get => logindate; set => logindate = value; }
        public DateTime _Logoutdate { get => logoutdate; set => logoutdate = value; }
        public bool     _Userstatus { get => userstatus; set => userstatus = value; }
        public string _Username
        {
            get => username;
            set
            {
                if (value.Length > 0 && value.Length < 20)
                {
                    username = value;
                }
                else if (value.Length == 0)
                {
                    cGenel.genelUyari("Kullanıcı adı boş bırakılamaz.", false);
                }
                else if (value.Length >= 20)
                {
                    cGenel.genelUyari("Kullanıcı adı 20 karakterden fazla olamaz.", false);
                }
            }
        }

       
  
        public bool userNewAdd()
        {
            bool result = false;

            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("insert into TBL_USERS(NAME, SURNAME , USERNAME , PASSWORD, GRUPID,LOGINDATE,LOGOUTDATE,STATUS)" +//
                "VALUES(@NAME," +
                "@SURNAME," +
                "@USERNAME," +
                "@PASSWORD," +
                "@GRUPID," +
                "@LOGINDATE," +
                "@LOGOUTDATE," +
                "@STATUS) ", con);


            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@SURNAME", SqlDbType.NVarChar).Value = surname;
            cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = username;
            cmd.Parameters.Add("@PASSWORD", SqlDbType.NVarChar).Value = password;
            cmd.Parameters.Add("@GRUPID", SqlDbType.TinyInt).Value = grupID;
            cmd.Parameters.Add("@LOGINDATE", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@LOGOUTDATE", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@STATUS", SqlDbType.Bit).Value = userstatus;
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

        public bool userUpdate()
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_USERS set " +
                "NAME='" + name+ "'," +
                "SURNAME='" + surname + "'," +
                "USERNAME='" + username + "'," +
                            "GRUPID='" + grupID + "'" +
               " where ID='" + userID + "' ", con);

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

        public bool userDelete()
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("delete from TBL_USERS where ID='" + userID + "'", con);

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

        public List<cUsers> usersList()
        {
            cUsers usersInfo;
            List<cUsers> list = new List<cUsers>();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_USERS where GRUPID != '"+(int)user_grup.superUser+"' ", con);
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
                    usersInfo = new cUsers();
                    usersInfo._UserID = Convert.ToUInt32(dr["ID"]);
                    usersInfo._Name = Convert.ToString(dr["NAME"]);
                    usersInfo._Surname = Convert.ToString(dr["SURNAME"]);
                    usersInfo._Username = Convert.ToString(dr["USERNAME"]);
                    usersInfo._Password = Convert.ToString(dr["PASSWORD"]);
                    usersInfo._GrupID = Convert.ToUInt32(dr["GRUPID"]);
                    list.Add(usersInfo);
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

        public cUsers usersIDInfo(uint userID)
        {
            cUsers userInfo = new cUsers();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_USERS where ID='" + userID + "'", con);
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

                    userInfo._UserID = Convert.ToUInt32(dr["ID"]);
                    userInfo._Name = Convert.ToString(dr["NAME"]);
                    userInfo._Surname = Convert.ToString(dr["SURNAME"]);
                    userInfo._Username = Convert.ToString(dr["USERNAME"]);
                    userInfo._Password = Convert.ToString(dr["PASSWORD"]);
                    userInfo._GrupID = Convert.ToUInt32(dr["GRUPID"]);

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

            return userInfo;

        }

        public cUsers userInfo(string username)
        {
            cUsers userInfo = new cUsers();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_USERS where USERNAME='" + username + "'", con);
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
                    userInfo._UserID = Convert.ToUInt32(dr["ID"]);
                    userInfo._Name = Convert.ToString(dr["NAME"]);
                    userInfo._Surname = Convert.ToString(dr["SURNAME"]);
                    userInfo._Username = Convert.ToString(dr["USERNAME"]);
                    userInfo._Password = Convert.ToString(dr["PASSWORD"]);
                    userInfo._GrupID = Convert.ToUInt32(dr["GRUPID"]);

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

            return userInfo;

        }

        public bool passwordChange(uint userID , string password)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_USERS set " +
                      "PASSWORD='" + password + "'" +
               " where ID='" + userID + "' ", con);

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

        public bool userLoginDatetime(uint userID)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_USERS set " +
                "LOGINDATE=@date" +            
               " where ID='" + userID + "' ", con);
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
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

        public bool userLogoutDatetime(uint userID)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_USERS set " +
                "LOGOUTDATE=@date" +
               " where ID='" + userID + "' ", con);
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
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

        public cUsers usersIDOpenSensesionTime(uint userID)
        {
           
            cUsers userInfo = new cUsers();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_USERS where ID='" + userID + "'", con);
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

                    userInfo._UserID = Convert.ToUInt32(dr["ID"]);
                    userInfo._Logindate = Convert.ToDateTime(dr["LOGINDATE"]);
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

            return userInfo;

        }

    }
}
