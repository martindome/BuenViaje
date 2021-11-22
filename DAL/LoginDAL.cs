using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DAL
{
    public class LoginDAL
    {
        static SERV.Seguridad.Cifrado mCifrado = new SERV.Seguridad.Cifrado();
        static public void ResetBadPWD(int pUsuarioId)
        {
            //mquery
            //DAO.Instance.ExecuteNonQuery();

        }
        static private void IncrementBadPwd(int pUsuarioId)
        {
            //mquery
            //DAO.Instance.ExecuteNonQuery();
        }
        static public string CalcularHashMD5(string pPwd)
        {
            return mCifrado.CalcularHashMD5(pPwd);
        }
        static public void CambiarConnectionString(string newConnString)
        {
            try
            {
                string FinalConnectionString = SERV.Seguridad.Cifrado.Cifrar(newConnString);
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["BuenViaje"].ConnectionString = FinalConnectionString;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
                DAO.RefrescarConexion();
                DAO.Instancia().ProbarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
