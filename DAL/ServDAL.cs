using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class ServDAL
    {
        static SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static SERV.Integridad mIntegridad = new SERV.Integridad();

        static public void GuardarDigitoVerificador(List<string> pRegistros, string pTabla)
        {
            string DigitoVerificador = "";
            if (pRegistros.Count > 0)
                DigitoVerificador = mIntegridad.CalcularDVV(pRegistros);
            else
            {
                BorrarDigitoVerificador(pTabla);
                return;
            }
            if (ObtenerCantidadRegistrosDigitos(pTabla) == 0)
                GuardarNuevoDigitoVerificador(pTabla, DigitoVerificador);
            else
            {
                ModificarDigitoVerificador(pTabla, DigitoVerificador);
            }
            
        }

        static public List<string> ObtenerDVHs(string pTabla)
        {
            List<string> mLista = new List<string>();
            string mQuery = "SELECT DVH FROM " + pTabla;
            DataSet mDataset = new DataSet();
            mDataset = DAO.GetInstance().ExecuteDataSet(mQuery);
            foreach (DataRow mROW in mDataset.Tables[0].Rows)
            {
                mLista.Add(mROW["DVH"].ToString());
            }
            return mLista;
        }

        static public string CalcularDVV (string pTabla)
        {
            return mIntegridad.CalcularDVV(ObtenerDVHs(pTabla));
        }

        #region private functions
        static private int ObtenerCantidadRegistrosDigitos(string pTabla)
        {
            string mQuery = "SELECT COUNT(*) FROM Digito_Verificador WHERE Tabla='" + pTabla + "'";
            return int.Parse(DAO.GetInstance().ExecuteScalar(mQuery).ToString());
        }

        static private void GuardarNuevoDigitoVerificador(string pTabla, string DigitoVerificador)
        {
            int Id = DAO.GetInstance().ObtenerUltimoId("Digito_Verificador") + 1;
            string mQuery = "INSERT INTO Digito_Verificador (ID_Digito_Verificador, Tabla, DVV) VALUES (" + Id + ", '" + pTabla + "', '" + DigitoVerificador + "')";
            DAO.GetInstance().ExecuteNonQuery(mQuery);
        }

        static private void ModificarDigitoVerificador(string pTabla, string DigitoVerificador)
        {
            string mQuery = "UPDATE Digito_Verificador SET DVV = " + DigitoVerificador + "WHERE Tabla='" + pTabla + "'";
            DAO.GetInstance().ExecuteNonQuery(mQuery);
        }

        static private void BorrarDigitoVerificador (string pTabla)
        {
            string mQuery = "DELETE Digito_Verificador WHERE Tabla='" + pTabla + "'";
            DAO.GetInstance().ExecuteNonQuery(mQuery);
        }
        #endregion


    }
}
