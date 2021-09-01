using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LoginDAL
    {
        static SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
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
            return mCifra.CalcularHashMD5(pPwd);
        }
    }
}
