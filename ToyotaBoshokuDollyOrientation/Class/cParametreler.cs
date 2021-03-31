using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ToyotaBoshokuDollyOrientation
{
   

    class cParametreler
    {
        cMesajlar mesajlar = new cMesajlar();

        public const string parametrePopupCalisma= "Popup çalışma";
        public const string parametreBuzzerSuresi = "Buzzer alarm süresi";
        public const string parametreKilitZamanAsimi = "Kilit zaman aşımı";
        public const string parametreDublicate = "Dublicate barkod işlemi";
        public const string parametreKilitlemeSuresi = "Kilitleme zaman süresi";
        public const string parametreKilitKapatmaDenemeSaiyisi = "Kilit kapatma deneme sayısı";
        public const string parametreRHKarkasAktifPasif = "RH Karkas Aktif Pasif";
        public const string parametreLHKarkasAktifPasif = "LH Karkas Aktif Pasif";
        public const string parametreLHKilitMekanizmasiAktifPasif = "LH Kilit Mekananizması Aktif Pasif";
        public const string parametreLHBuzzerAktifPasif = "LH Buzzer Aktif Pasif";
        public const string parametreRHKilitMekanizmasiAktifPasif = "RH Kilit Mekananizması Aktif Pasif";
        public const string parametreRHBuzzerAktifPasif = "RH Buzzer Aktif Pasif";
        public bool LH_ComportGuncelle(string comPortValue)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_PARAMETERS set " +
                "VALUE='" + comPortValue + "'" +
               " where ID= 'LH_COMPORT' ", con);

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

        public string LH_ComportSorgula()
        {
            string sonuc = null;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select VALUE from TBL_PARAMETERS where ID='LH_COMPORT'", con);
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
                    sonuc = Convert.ToString(dr["VALUE"]);

                }
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex,"");
                sonuc = null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }



            return sonuc;
        }

        public bool RH_ComportGuncelle(string comPortValue)
        {
            bool result = false;


            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_PARAMETERS set " +
                "VALUE='" + comPortValue + "'" +
               " where ID= 'RH_COMPORT' ", con);

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

        public string RH_ComportSorgula()
        {
            string sonuc = null;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select VALUE from TBL_PARAMETERS where ID='RH_COMPORT'", con);
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
                    sonuc = Convert.ToString(dr["VALUE"]);

                }
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex,"");
                sonuc = null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }



            return sonuc;
        }

        public List<string> parametreAra(string ID)
        {
            string sonuc = null;
            cGenel gnl = new cGenel();
            List<string> liste = new List<string>();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_PARAMETERS where ID like '%'+'" + ID + "'+'%'", con);
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
                    sonuc = Convert.ToString(dr["ID"]);
                    liste.Add(sonuc);
                }
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex,"");
                sonuc = null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }



            return liste;

        }

        public string parametreAraValue(string ID)
        {
            string sonuc = null;
            cGenel gnl = new cGenel();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_PARAMETERS where ID='" + ID + "'", con);
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
                    sonuc = Convert.ToString(dr["VALUE"]);

                }
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex,"");
                sonuc = null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }



            return sonuc;

        }

        public bool parametreGuncelle(string ID, string value)
        {
            bool result = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_PARAMETERS set " +
                "VALUE='" + value + "'" +
               " where ID='" + ID + "' ", con);

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

        public bool parametreDefaultGuncelle(string ID)
        {
            bool result = false;
            cGenel gnl = new cGenel();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update TBL_PARAMETERS set " +
                "VALUE=DEFAULTVALUE" +
               " where ID= '"+ID+"' ", con);

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

        public string parametreAraAciklama(string ID)
        {
            string sonuc = null;
            cGenel gnl = new cGenel();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from TBL_PARAMETERS where ID='" + ID + "'", con);
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
                    sonuc = Convert.ToString(dr["DEFINITION"]);

                }
            }
            catch (Exception ex)
            {

                mesajlar.hata(ex,"");
                sonuc = null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }



            return sonuc;

        }

        public void parametreleriAta()
        {
          
            cGenel.xDublicateBarkodCalismaDurumu = Convert.ToBoolean(int.Parse(parametreAraValue(parametreDublicate)));
            cGenel.kilitKapatmaSuresi = Convert.ToUInt32(parametreAraValue(parametreKilitlemeSuresi));
            cGenel.kilitZamanAsimi = Convert.ToUInt32(parametreAraValue(parametreKilitZamanAsimi));
            cGenel.kilitKapatmaDenemeSayisi = Convert.ToUInt32(parametreAraValue(parametreKilitKapatmaDenemeSaiyisi));
            cGenel.buzzerMispickSuresi = Convert.ToUInt32(parametreAraValue(parametreBuzzerSuresi));

            if (cGenel.MAKINE_ADI==cGenel.MAKINE_ADI_LH)
            {
                cGenel.xByPass = Convert.ToBoolean(int.Parse(parametreAraValue(parametreLHKarkasAktifPasif)));
                cGenel.xBuzzerByPass = Convert.ToBoolean(int.Parse(parametreAraValue(parametreLHBuzzerAktifPasif)));
                cGenel.xKilitMekanizmasiByPass = Convert.ToBoolean(int.Parse(parametreAraValue(parametreLHKilitMekanizmasiAktifPasif)));
            }
            else if (cGenel.MAKINE_ADI == cGenel.MAKINE_ADI_RH)
            {
                cGenel.xByPass = Convert.ToBoolean(int.Parse(parametreAraValue(parametreRHKarkasAktifPasif)));
                cGenel.xBuzzerByPass = Convert.ToBoolean(int.Parse(parametreAraValue(parametreRHBuzzerAktifPasif)));
                cGenel.xKilitMekanizmasiByPass = Convert.ToBoolean(int.Parse(parametreAraValue(parametreRHKilitMekanizmasiAktifPasif)));
            }
        }

    }
}
