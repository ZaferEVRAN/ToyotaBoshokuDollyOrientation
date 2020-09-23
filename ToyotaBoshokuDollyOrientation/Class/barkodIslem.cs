using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ToyotaBoshokuDollyOrientation
{
  
    class barkodIslem
    {
        public uint _ID;
        public uint _SEQUENCE        ;
        public float _TBTNO           ;
        public float _TRIMNO          ;
        public string   _DOORSPEC        ;
        public string   _FRL_BARCODE     ;
        public byte     _FRL_STATUS      ;
        public string   _RRL_BARCODE     ;
        public byte     _RRL_STATUS      ;
        public string   _FRR_BARCODE;
        public byte     _FRR_STATUS;
        public string   _RRR_BARCODE;
        public byte     _RRR_STATUS;
        public string _BACKNO          ;
        public string _TYPE;

        public const int barkodIslemDurumYok = 0;
        public const int barkodIslemDurumUrunRework = 1;
        public const int barkodIslemDurumUrunDollyde = 2;

        public const string barkodIslemTanimYok ="İşlem yok";
        public const string barkodIslemTanimUrunRework = "Ürün Rework";
        public const string barkodIslemTanimUrunDollyde = "Ürün Dollyde";


        cMesajlar mesajlar = new cMesajlar();

        public bool barcodsNewAdd_LH(List<TBTGALC_DOOR> Info)
        {
            bool sonuc = false;
            for (int i = 0; i < Info.Count; i++)
            {

                cGenel gnl = new cGenel();
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("insert into LH_BARKODS(SEQUENCE,TBTNO,TRIMNO,DOORSPEC,FRL_BARCODE,RRL_BARCODE,BACKNO,TYPE,TIME) VALUES (@SEQUENCE,@TBTNO,@TRIMNO,@DOORSPEC,@FRL_BARCODE,@RRL_BARCODE,@BACKNO,@TYPE,@TIME) ", con);


                cmd.Parameters.Add("@SEQUENCE", SqlDbType.Int).Value = i + 1;
                cmd.Parameters.Add("@TBTNO", SqlDbType.Float).Value = Info[i]._TBTNO;
                cmd.Parameters.Add("@TRIMNO", SqlDbType.Float).Value = Info[i]._TRIMNO;
                cmd.Parameters.Add("@DOORSPEC", SqlDbType.NVarChar).Value = Info[i]._DOORSPEC;
                cmd.Parameters.Add("@FRL_BARCODE", SqlDbType.NVarChar).Value = Info[i]._FRL_BARCODE;
                cmd.Parameters.Add("@RRL_BARCODE", SqlDbType.NVarChar).Value = Info[i]._RRL_BARCODE;
                cmd.Parameters.Add("@BACKNO", SqlDbType.NChar).Value = Info[i]._BACKNO;
                cmd.Parameters.Add("@TYPE", SqlDbType.NVarChar).Value = Info[i]._TYPE;
                //cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@TIME", SqlDbType.DateTime).Value = DateTime.Now;
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                  sonuc=Convert.ToBoolean(  cmd.ExecuteNonQuery());
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
            return sonuc;
        }

        public bool barcodsNewAdd_RH(List<TBTGALC_DOOR> Info)
        {
            bool sonuc = false;
            for (int i = 0; i < Info.Count; i++)
            {

                cGenel gnl = new cGenel();
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("insert into RH_BARKODS(SEQUENCE,TBTNO,TRIMNO,DOORSPEC,FRR_BARCODE,RRR_BARCODE,BACKNO,TYPE,TIME) VALUES (@SEQUENCE,@TBTNO,@TRIMNO,@DOORSPEC,@FRR_BARCODE,@RRR_BARCODE,@BACKNO,@TYPE,@TIME) ", con);


                cmd.Parameters.Add("@SEQUENCE", SqlDbType.Int).Value = i + 1;
                cmd.Parameters.Add("@TBTNO", SqlDbType.Float).Value = Info[i]._TBTNO;
                cmd.Parameters.Add("@TRIMNO", SqlDbType.Float).Value = Info[i]._TRIMNO;
                cmd.Parameters.Add("@DOORSPEC", SqlDbType.NVarChar).Value = Info[i]._DOORSPEC;
                cmd.Parameters.Add("@FRR_BARCODE", SqlDbType.NVarChar).Value = Info[i]._FRR_BARCODE;
                cmd.Parameters.Add("@RRR_BARCODE", SqlDbType.NVarChar).Value = Info[i]._RRR_BARCODE;
                cmd.Parameters.Add("@BACKNO", SqlDbType.NChar).Value = Info[i]._BACKNO;
                cmd.Parameters.Add("@TYPE", SqlDbType.NVarChar).Value = Info[i]._TYPE;
               // cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@TIME", SqlDbType.DateTime).Value = DateTime.Now;
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                 sonuc=Convert.ToBoolean(   cmd.ExecuteNonQuery());
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
            return sonuc;
        }

        private void LH_Read(barkodIslem barkodInfo, SqlDataReader dr)
        {
            barkodInfo._ID = Convert.ToUInt32(dr["ID"]);
            barkodInfo._SEQUENCE = Convert.ToUInt32(dr["SEQUENCE"]);
            barkodInfo._TBTNO = Convert.ToUInt32(dr["TBTNO"]);
            barkodInfo._TRIMNO = Convert.ToUInt32(dr["TRIMNO"]);
            barkodInfo._DOORSPEC = Convert.ToString(dr["DOORSPEC"]);
            barkodInfo._FRL_BARCODE = Convert.ToString(dr["FRL_BARCODE"]).Trim();
            barkodInfo._FRL_STATUS = Convert.ToByte(dr["FRL_STATUS"]);
            barkodInfo._RRL_BARCODE = Convert.ToString(dr["RRL_BARCODE"]).Trim();
            barkodInfo._RRL_STATUS = Convert.ToByte(dr["RRL_STATUS"]);
            barkodInfo._BACKNO = Convert.ToString(dr["BACKNO"]);
            barkodInfo._TYPE = Convert.ToString(dr["TYPE"]);
        }

        public barkodIslem barcodInfo_TRIMNO_FRL_STATUS(float telemail,string FRL)
        {
            barkodIslem barkodInfo = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from LH_BARKODS where TRIMNO=@trimNo AND FRL_BARCODE=@FRL ", con);
            cmd.Parameters.Add("@trimNo", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@FRL", SqlDbType.NVarChar).Value = FRL;
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
                    LH_Read(barkodInfo,dr);



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

            return barkodInfo;

        }

        public barkodIslem barcodInfo_TRIMNO_RRL_STATUS(string telemail, string RRL)
        {
            barkodIslem barkodInfo = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from LH_BARKODS where ID=@trimNo AND RRL_STATUS=0 ", con);
            cmd.Parameters.Add("@trimNo", SqlDbType.Float).Value = telemail;
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
                    LH_Read(barkodInfo, dr);
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

            return barkodInfo;

        }

        public uint barkod_FRL_RRL_Count()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from LH_BARKODS where FRL_STATUS=0 OR FRL_STATUS=1", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                dr=cmd.ExecuteReader();
                while (dr.Read())
                {
                    sonuc = Convert.ToUInt16(dr[""]);
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
            SqlConnection con2 = new SqlConnection(gnl.conString);
            SqlCommand cmd2 = new SqlCommand("select COUNT(*) from LH_BARKODS where RRL_STATUS=0 OR RRL_STATUS=1", con2);
            SqlDataReader dr2 = null;
            try
            {
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    sonuc2 = Convert.ToUInt16(dr2[""]);
                }
                sonuc = sonuc + sonuc2;
            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);

            }
            finally
            {
                con2.Close();
                con2.Dispose();
            }
            return sonuc;
        }

        public uint barkod_FRR_RRR_Count()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from RH_BARKODS where FRR_STATUS=0 OR FRR_STATUS=1", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
            SqlConnection con2 = new SqlConnection(gnl.conString);
            SqlCommand cmd2 = new SqlCommand("select COUNT(*) from RH_BARKODS where RRR_STATUS=0 OR RRR_STATUS=1", con2);
            SqlDataReader dr2 = null;
            try
            {
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    sonuc2 = Convert.ToUInt16(dr2[""]);
                }
                sonuc = sonuc + sonuc2;
            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);

            }
            finally
            {
                con2.Close();
                con2.Dispose();
            }
            return sonuc;
        }

        public uint barkod_FRL_RRL_Count_0()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from LH_BARKODS where FRL_STATUS=0 ", con);///*******************
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
            SqlConnection con2 = new SqlConnection(gnl.conString);
            SqlCommand cmd2 = new SqlCommand("select COUNT(*) from LH_BARKODS where RRL_STATUS=0 ", con2);
            SqlDataReader dr2 = null;
            try
            {
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    sonuc2 = Convert.ToUInt16(dr2[""]);
                }
                sonuc = sonuc + sonuc2;
            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);

            }
            finally
            {
                con2.Close();
                con2.Dispose();
            }
            return sonuc;
        }

        public uint barkod_FRL_RRL_Count_1()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from LH_BARKODS where FRL_STATUS=1 ", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
            SqlConnection con2 = new SqlConnection(gnl.conString);
            SqlCommand cmd2 = new SqlCommand("select COUNT(*) from LH_BARKODS where RRL_STATUS=1 ", con2);
            SqlDataReader dr2 = null;
            try
            {
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    sonuc2 = Convert.ToUInt16(dr2[""]);
                }
                sonuc = sonuc + sonuc2;
            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);

            }
            finally
            {
                con2.Close();
                con2.Dispose();
            }
            return sonuc;
        }

        public uint barkod_FRR_RRR_Count_0()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from RH_BARKODS where FRR_STATUS=0", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
            SqlConnection con2 = new SqlConnection(gnl.conString);
            SqlCommand cmd2 = new SqlCommand("select COUNT(*) from RH_BARKODS where RRR_STATUS=0 ", con2);
            SqlDataReader dr2 = null;
            try
            {
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    sonuc2 = Convert.ToUInt16(dr2[""]);
                }
                sonuc = sonuc + sonuc2;
            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);

            }
            finally
            {
                con2.Close();
                con2.Dispose();
            }
            return sonuc;
        }

        public uint barkod_FRR_RRR_Count_1()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from RH_BARKODS where FRR_STATUS=1", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
            SqlConnection con2 = new SqlConnection(gnl.conString);
            SqlCommand cmd2 = new SqlCommand("select COUNT(*) from RH_BARKODS where RRR_STATUS=1 ", con2);
            SqlDataReader dr2 = null;
            try
            {
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    sonuc2 = Convert.ToUInt16(dr2[""]);
                }
                sonuc = sonuc + sonuc2;
            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);

            }
            finally
            {
                con2.Close();
                con2.Dispose();
            }
            return sonuc;

        }

        public barkodIslem barkodeSearch_FRL(float telemail , string FRL, byte status)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from LH_BARKODS where TRIMNO=@telemail AND FRL_BARCODE=@FRL AND FRL_STATUS=@status  ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@FRL", SqlDbType.NVarChar).Value = FRL;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                dr=cmd.ExecuteReader();
                while (dr.Read())
                {
                    LH_Read(info, dr);
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

        public barkodIslem barkodeSearch_RRL(float telemail, string RRL, byte status)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from LH_BARKODS where TRIMNO=@telemail AND RRL_BARCODE=@RRL AND RRL_STATUS=@status  ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@RRL", SqlDbType.NVarChar).Value = RRL;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LH_Read(info, dr);
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

        public barkodIslem barkodeSearch_FRL(float telemail, string FRL)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from LH_BARKODS where TRIMNO=@telemail AND FRL_BARCODE=@FRL AND  (FRL_STATUS=0 OR  FRL_STATUS=1)  ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@FRL", SqlDbType.NVarChar).Value = FRL;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LH_Read(info, dr);
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

        public barkodIslem barkodeSearch_RRL(float telemail, string RRL)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from LH_BARKODS where TRIMNO=@telemail AND RRL_BARCODE=@RRL  AND  (RRL_STATUS=0 OR  RRL_STATUS=1)  ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@RRL", SqlDbType.NVarChar).Value = RRL;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LH_Read(info, dr);
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

        private void RH_Read(barkodIslem barkodInfo, SqlDataReader dr)
        {
            barkodInfo._ID = Convert.ToUInt32(dr["ID"]);
            barkodInfo._SEQUENCE = Convert.ToUInt32(dr["SEQUENCE"]);
            barkodInfo._TBTNO = Convert.ToUInt32(dr["TBTNO"]);
            barkodInfo._TRIMNO = Convert.ToUInt32(dr["TRIMNO"]);
            barkodInfo._DOORSPEC = Convert.ToString(dr["DOORSPEC"]);
            barkodInfo._FRR_BARCODE = Convert.ToString(dr["FRR_BARCODE"]).Trim();
            barkodInfo._FRR_STATUS = Convert.ToByte(dr["FRR_STATUS"]);
            barkodInfo._RRR_BARCODE = Convert.ToString(dr["RRR_BARCODE"]).Trim();
            barkodInfo._RRR_STATUS = Convert.ToByte(dr["RRR_STATUS"]);
            barkodInfo._BACKNO = Convert.ToString(dr["BACKNO"]);
            barkodInfo._TYPE = Convert.ToString(dr["TYPE"]);
        }

        public barkodIslem barkodeSearch_FRR(float telemail, string FRR, byte status)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from RH_BARKODS where TRIMNO=@telemail AND FRR_BARCODE=@FRR AND FRR_STATUS=@status  ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@FRR", SqlDbType.NVarChar).Value = FRR;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RH_Read(info, dr);
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

        public barkodIslem barkodeSearchID_FRR(uint ID)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from RH_BARKODS where ID=@ID   ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RH_Read(info, dr);
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

        public barkodIslem barkodeSearchID_RRR(uint ID)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from RH_BARKODS where ID=@ID   ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RH_Read(info, dr);
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

        public barkodIslem barkodeSearchID_FRL(uint ID)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from LH_BARKODS where ID=@ID   ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LH_Read(info, dr);
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

        public barkodIslem barkodeSearchID_RRL(uint ID)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from LH_BARKODS where ID=@ID   ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LH_Read(info, dr);
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

        public barkodIslem barkodeSearch_RRR(float telemail, string RRR, byte status)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from RH_BARKODS where TRIMNO=@telemail AND RRR_BARCODE=@RRR AND RRR_STATUS=@status  ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@RRR", SqlDbType.NVarChar).Value = RRR;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    info._ID = Convert.ToUInt32(dr["ID"]);
                    info._SEQUENCE = Convert.ToUInt32(dr["SEQUENCE"]);
                    info._TBTNO = Convert.ToUInt32(dr["TBTNO"]);
                    info._TRIMNO = Convert.ToUInt32(dr["TRIMNO"]);
                    info._DOORSPEC = Convert.ToString(dr["DOORSPEC"]);
                    info._FRR_BARCODE = Convert.ToString(dr["FRR_BARCODE"]);
                    info._FRR_STATUS = Convert.ToByte(dr["FRR_STATUS"]);
                    info._RRR_BARCODE = Convert.ToString(dr["RRR_BARCODE"]);
                    info._RRR_STATUS = Convert.ToByte(dr["RRR_STATUS"]);
                    info._BACKNO = Convert.ToString(dr["BACKNO"]);
                    info._TYPE = Convert.ToString(dr["TYPE"]);
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

        public barkodIslem barkodeSearch_FRR(float telemail, string FRR)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from RH_BARKODS where TRIMNO=@telemail AND FRR_BARCODE=@FRR AND  (FRR_STATUS=0 OR  FRR_STATUS=1)  ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@FRR", SqlDbType.NVarChar).Value = FRR;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RH_Read(info, dr);
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

        public barkodIslem barkodeSearch_RRR(float telemail, string RRR)
        {
            barkodIslem info = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from RH_BARKODS where TRIMNO=@telemail AND RRR_BARCODE=@RRR  AND  (RRR_STATUS=0 OR  RRR_STATUS=1)  ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@RRR", SqlDbType.NVarChar).Value = RRR;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RH_Read(info, dr);
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

        public byte barkodInfoStatus_LH(float telemail,string barkod, string yonBilgisi)
        {
            byte sonuc = 0;
            if (yonBilgisi==cGenel.FR_LH)
            {
                sonuc= barkodeSearch_FRL(telemail, barkod)._FRL_STATUS;
            }
            else if(yonBilgisi == cGenel.RR_LH)
            {
                sonuc = barkodeSearch_RRL(telemail, barkod)._RRL_STATUS;

            }
            return sonuc;
        }

        public byte barkodInfoStatus_LH(float telemail, string barkod, string yonBilgisi, byte status)
        {
            byte sonuc = 0;
            if (yonBilgisi == cGenel.FR_LH)
            {
                sonuc = barkodeSearch_FRL(telemail, barkod, status)._FRL_STATUS;
            }
            else if (yonBilgisi == cGenel.RR_LH)
            {
                sonuc = barkodeSearch_RRL(telemail, barkod, status)._RRL_STATUS;

            }
            return sonuc;
        }

        public uint barkodInfoSequence_LH(float telemail, string barkod, string yonBilgisi)
        {
            uint sonuc = 0;
            if (yonBilgisi == cGenel.FR_LH)
            {
                sonuc = barkodeSearch_FRL(telemail, barkod)._SEQUENCE;
            }
            else if (yonBilgisi == cGenel.RR_LH)
            {
                sonuc = barkodeSearch_RRL(telemail, barkod)._SEQUENCE;

            }
            return sonuc;
        }
        
        public bool urunBarkodIslemTamamlandi_LH(float telemail, string barkod, string yonBilgisi, byte status)
        {
            bool sonuc = false;
            if (yonBilgisi == cGenel.FR_LH)
            {
                sonuc= urunBarkodStatusUpdate_FR_LH(telemail,barkod,status);
            }
            else if (yonBilgisi == cGenel.RR_LH)
            {
                sonuc= urunBarkodStatusUpdate_RR_LH(telemail, barkod, status);
           
            }

            return sonuc;
        }

        public bool urunBarkodIslemTamamlandi_LH(float telemail, string barkod, string yonBilgisi, byte status,uint barkodID)
        {
            bool sonuc = false;
            if (yonBilgisi == cGenel.FR_LH)
            {
              sonuc=  urunBarkodStatusUpdate_FR_LH(barkodID, status);
            }
            else if (yonBilgisi == cGenel.RR_LH)
            {
              sonuc=  urunBarkodStatusUpdate_RR_LH(barkodID, status);

            }

            return sonuc;
        }

        public bool urunBarkodStatusUpdate_FR_LH(float telemail, string barkod, byte status)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LH_BARKODS set FRL_STATUS=@status where TRIMNO=@telemail AND FRL_BARCODE=@barkod AND (FRL_STATUS=0 OR FRL_STATUS=1) ", con);
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@barkod", SqlDbType.NVarChar).Value = barkod;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc=Convert.ToBoolean( cmd.ExecuteNonQuery());
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

        public bool urunBarkodStatusUpdate_FR_LH(uint barkodID, byte status)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LH_BARKODS set FRL_STATUS=@status where ID=@barkodID ", con);
            cmd.Parameters.Add("@barkodID", SqlDbType.BigInt).Value = barkodID;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
               sonuc=Convert.ToBoolean( cmd.ExecuteNonQuery());
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

        public bool urunBarkodStatusUpdate_RR_LH(float telemail, string barkod, byte status)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LH_BARKODS set RRL_STATUS=@status where TRIMNO=@telemail AND RRL_BARCODE=@barkod AND (RRL_STATUS=0 OR RRL_STATUS=1) ", con);
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@barkod", SqlDbType.NVarChar).Value = barkod;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
              sonuc=Convert.ToBoolean(  cmd.ExecuteNonQuery());
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

        public bool urunBarkodStatusUpdate_RR_LH(uint barkodID, byte status)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LH_BARKODS set RRL_STATUS=@status where ID=@barkodID ", con);

            cmd.Parameters.Add("@barkodID", SqlDbType.BigInt).Value = barkodID;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
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

        public byte barkodInfoStatus_RH(float telemail, string barkod, string yonBilgisi)
        {
            byte sonuc = 0;
            if (yonBilgisi == cGenel.FR_RH)
            {
                sonuc = barkodeSearch_FRR(telemail, barkod)._FRR_STATUS;
            }
            else if (yonBilgisi == cGenel.RR_RH)
            {
                sonuc = barkodeSearch_RRR(telemail, barkod)._RRR_STATUS;

            }
            return sonuc;
        }

        public uint barkodInfoSequence_RH(float telemail, string barkod, string yonBilgisi)
        {
            uint sonuc = 0;
            if (yonBilgisi == cGenel.FR_RH)
            {
                sonuc = barkodeSearch_FRR(telemail, barkod)._SEQUENCE;
            }
            else if (yonBilgisi == cGenel.RR_RH)
            {
                sonuc = barkodeSearch_RRR(telemail, barkod)._SEQUENCE;

            }
            return sonuc;
        }

        public uint barkodInfoIDStatus_RH(uint ID, string yonBilgisi)
        {
            uint sonuc = 0;
            if (yonBilgisi == cGenel.FR_RH)
            {
                sonuc = barkodeSearchID_FRR(ID)._FRR_STATUS;
            }
            else if (yonBilgisi == cGenel.RR_RH)
            {
                sonuc = barkodeSearchID_RRR(ID)._RRR_STATUS;

            }
            return sonuc;
        }

        public uint barkodInfoIDStatus_LH(uint ID, string yonBilgisi)
        {
            byte sonuc = 0;
            if (yonBilgisi == cGenel.FR_LH)
            {
                sonuc = barkodeSearchID_FRL(ID)._FRL_STATUS;
            }
            else if (yonBilgisi == cGenel.RR_LH)
            {
                sonuc = barkodeSearchID_RRL(ID)._RRL_STATUS;

            }
            return sonuc;
        }

        public bool urunBarkodIslemTamamlandi_RH(float telemail, string barkod, string yonBilgisi, byte status)
        {
            bool sonuc = false;

            if (yonBilgisi == cGenel.FR_RH)
            {
              sonuc=  urunBarkodStatusUpdate_FR_RH(telemail, barkod, status);
            }
            else if (yonBilgisi == cGenel.RR_RH)
            {
              sonuc=  urunBarkodStatusUpdate_RR_RH(telemail, barkod, status);

            }
            return sonuc;

        }

        public bool urunBarkodIslemTamamlandi_RH(float telemail, string barkod, string yonBilgisi, byte status, uint barkodID)
        {
            bool sonuc = false;
            if (yonBilgisi == cGenel.FR_RH)
            {
              sonuc=  urunBarkodStatusUpdate_FR_RH( barkodID , status);
            }
            else if (yonBilgisi == cGenel.RR_RH)
            {
               sonuc= urunBarkodStatusUpdate_RR_RH(barkodID, status);

            }

            return sonuc;
        }

        public bool urunBarkodStatusUpdate_FR_RH(float telemail, string barkod, byte status)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update RH_BARKODS set FRR_STATUS=@status where TRIMNO=@telemail AND FRR_BARCODE=@barkod AND (FRR_STATUS=0 OR FRR_STATUS=1) ", con);
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@barkod", SqlDbType.NVarChar).Value = barkod;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
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

        public bool urunBarkodStatusUpdate_FR_RH(uint barkodID, byte status)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update RH_BARKODS set FRR_STATUS=@status where ID=@barkodID ", con);
            cmd.Parameters.Add("@barkodID", SqlDbType.BigInt).Value = barkodID;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
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

        public bool urunBarkodStatusUpdate_RR_RH(float telemail, string barkod, byte status)
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update RH_BARKODS set RRR_STATUS=@status where TRIMNO=@telemail AND RRR_BARCODE=@barkod AND (RRR_STATUS=0 OR RRR_STATUS=1) ", con);
            cmd.Parameters.Add("@telemail", SqlDbType.Float).Value = telemail;
            cmd.Parameters.Add("@barkod", SqlDbType.NVarChar).Value = barkod;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
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
            return sonuc;        }

        public bool urunBarkodStatusUpdate_RR_RH(uint barkodID, byte status)
        {
            bool sonuc=false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update RH_BARKODS set RRR_STATUS=@status where ID=@barkodID ", con);
            cmd.Parameters.Add("@barkodID", SqlDbType.BigInt).Value = barkodID;
            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;
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

        public barkodIslem barcodInfoID_LH(uint _ID)
        {
            barkodIslem barkodInfo = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from LH_BARKODS where ID=@ID", con);
            cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = _ID;
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
                    LH_Read(barkodInfo, dr);



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

            return barkodInfo;

        }

        public barkodIslem barcodInfoID_RH(uint _ID)
        {
            barkodIslem barkodInfo = new barkodIslem();
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from RH_BARKODS where ID=@ID", con);
            cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = _ID;
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
                    RH_Read(barkodInfo, dr);



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

            return barkodInfo;

        }

        public bool urunBarkodStatusUpdate_FR_LH_99()
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LH_BARKODS set FRL_STATUS=99 where FRL_STATUS=1 ", con);
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

        public bool urunBarkodStatusUpdate_RR_LH_99()
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LH_BARKODS set RRL_STATUS=99 where  RRL_STATUS=1 ", con);

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

        public bool urunBarkodStatusUpdate_FR_RH_99()
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update RH_BARKODS set FRR_STATUS=99 where FRR_STATUS=1 ", con);
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

        public bool urunBarkodStatusUpdate_RR_RH_99()
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update RH_BARKODS set RRR_STATUS=99 where  RRR_STATUS=1 ", con);

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

        public bool urunBarkodlariDurumIPTAL_RH()
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update RH_BARKODS set RRR_STATUS=99,FRR_STATUS=99  where RRR_STATUS=0 OR RRR_STATUS=1 OR FRR_STATUS=0 OR FRR_STATUS=1  ", con);

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


        public bool urunBarkodlariDurumIPTAL_LH()
        {
            bool sonuc = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update LH_BARKODS set RRL_STATUS=99,FRL_STATUS=99  where RRL_STATUS=0 OR RRL_STATUS=1 OR FRL_STATUS=0 OR FRL_STATUS=1  ", con);

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

        public DataTable barkodlariListele_LH(string kriter="1=1")
        { 
            cGenel gnl = new cGenel();
            DataTable dt = new DataTable();

            using (var con = new SqlConnection(gnl.conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from LH_BARKODS where "+ kriter, con);
                var dr = cmd.ExecuteReader();
                dt.Load(dr);
            }

            return dt;
        }

        public DataTable barkodlariListele_RH(string kriter = "1=1")
        {
            cGenel gnl = new cGenel();
            DataTable dt = new DataTable();

            using (var con = new SqlConnection(gnl.conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from RH_BARKODS where " + kriter, con);
                var dr = cmd.ExecuteReader();
                dt.Load(dr);
            }

            return dt;
        }

        public uint TotalOKCount_LH()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from LH_BARKODS where FRL_STATUS=2 AND DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE());", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
            SqlConnection con2 = new SqlConnection(gnl.conString);
            SqlCommand cmd2 = new SqlCommand("select COUNT(*) from LH_BARKODS where  RRL_STATUS=2 AND DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE());", con2);
            SqlDataReader dr2 = null;
            try
            {
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    sonuc2 = Convert.ToUInt16(dr2[""]);
                }
                sonuc = sonuc + sonuc2;
            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);

            }
            finally
            {
                con2.Close();
                con2.Dispose();
            }
            return sonuc;
        }

        public uint TotalOKCount_RH()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from RH_BARKODS where FRR_STATUS=2 AND DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE()); ", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
            SqlConnection con2 = new SqlConnection(gnl.conString);
            SqlCommand cmd2 = new SqlCommand("select COUNT(*) from RH_BARKODS where  RRR_STATUS=2 AND DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE());", con2);
            SqlDataReader dr2 = null;
            try
            {
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    sonuc2 = Convert.ToUInt16(dr2[""]);
                }
                sonuc = sonuc + sonuc2;
            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);

            }
            finally
            {
                con2.Close();
                con2.Dispose();
            }
            return sonuc;
        }

        public uint TotalREWORKCount_LH()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from LOG where LINE='LH' AND OK_REWORK='REWORK' AND DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE());", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
         
            return sonuc;
        }

        public uint TotalREWORKCount_RH()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from LOG where LINE='RH' AND OK_REWORK='REWORK' AND DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE());", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
        
            return sonuc;
        }

        public uint TotalMANUALCount_LH()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from LH_BARKODS where FRL_STATUS=99 AND DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE()); ", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
            SqlConnection con2 = new SqlConnection(gnl.conString);
            SqlCommand cmd2 = new SqlCommand("select COUNT(*) from LH_BARKODS where  RRL_STATUS=99 AND DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE());", con2);
            SqlDataReader dr2 = null;
            try
            {
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    sonuc2 = Convert.ToUInt16(dr2[""]);
                }
                sonuc = sonuc + sonuc2;
            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);

            }
            finally
            {
                con2.Close();
                con2.Dispose();
            }
            return sonuc;
        }

        public uint TotalMANUALCount_RH()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from RH_BARKODS where FRR_STATUS=99 AND DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE()); ", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
            SqlConnection con2 = new SqlConnection(gnl.conString);
            SqlCommand cmd2 = new SqlCommand("select COUNT(*) from RH_BARKODS where  RRR_STATUS=99 AND DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE());", con2);
            SqlDataReader dr2 = null;
            try
            {
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    sonuc2 = Convert.ToUInt16(dr2[""]);
                }
                sonuc = sonuc + sonuc2;
            }
            catch (Exception ex)
            {
                mesajlar.hata(ex);

            }
            finally
            {
                con2.Close();
                con2.Dispose();
            }
            return sonuc;
        }

        public uint TotalURETIMCount_LH()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from LH_BARKODS where DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE());  ", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
            
            return sonuc;
        }

        public uint TotalURETIMCount_RH()
        {
            uint sonuc = 0;
            uint sonuc2 = 0;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select COUNT(*) from RH_BARKODS where DAY(TIME) = DAY(GETDATE()) AND MONTH(TIME) = MONTH(GETDATE()) AND YEAR(TIME) = YEAR(GETDATE()) ", con);
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
                    sonuc = Convert.ToUInt16(dr[""]);
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
          
            return sonuc;
        }
    }
}
