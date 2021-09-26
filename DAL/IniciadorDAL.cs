using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data;

namespace DAL
{
    public class IniciadorDAL
    {
        static string mQuery;
        static private SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static private SERV.Integridad mIntegridad = new SERV.Integridad();
        static public void ProbarConexionDB()
        {
            try
            {
                DAO.Instancia().ProbarConexion();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        static public List<DigitoVerificadorVerticalBE> ChequearIntegridad()
        {
            List<DigitoVerificadorVerticalBE> Tablas = new List<DigitoVerificadorVerticalBE>();
            string mHashCalculado;
            String[] mRegistroSplit;
            foreach (DigitoVerificadorVerticalBE mDigitoVerificador in ObtenerTablasDigitoVerificador())
            {
                foreach (string mReg in ObtenerDatosRegistros(mDigitoVerificador.Tabla))
                {
                    mRegistroSplit = mReg.Split(char.Parse(";"));
                    mHashCalculado = mIntegridad.CalcularDVH(mRegistroSplit[0]);
                    if (mHashCalculado != mRegistroSplit[1]) 
                    {
                        Tablas.Add(mDigitoVerificador);
                    }
                }
            }
            return Tablas;
        }
        static public List<DigitoVerificadorVerticalBE> ChequearDigitoVerificadorVertical()
        {
            List<DigitoVerificadorVerticalBE> Tablas = new List<DigitoVerificadorVerticalBE>();
            foreach (DigitoVerificadorVerticalBE mDigitoVerificador in ObtenerTablasDigitoVerificador())
            {
                string DigitoVerificador = ServDAL.CalcularDVV(mDigitoVerificador.Tabla);
                if (DigitoVerificador != mDigitoVerificador.DVV)
                    Tablas.Add(mDigitoVerificador);
            }
            return Tablas;
        }

        #region private functions
        private static void ValorizarEntidad(DigitoVerificadorVerticalBE pDigito, DataRow pDataRow)
        {
            pDigito.Tabla = pDataRow["Tabla"].ToString();
            pDigito.DVV = pDataRow["DVV"].ToString();
        }
        static private List<DigitoVerificadorVerticalBE> ObtenerTablasDigitoVerificador()
        {
            List<DigitoVerificadorVerticalBE> mTablas = new List<DigitoVerificadorVerticalBE>();
            mQuery = "SELECT * FROM Digito_Verificador";
            DataSet mDataset = new DataSet();
            mDataset = DAL.DAO.Instancia().ExecuteDataSet(mQuery);

            foreach (DataRow mDataRow in mDataset.Tables[0].Rows)
            {
                DigitoVerificadorVerticalBE mDigitoVerificador = new DigitoVerificadorVerticalBE(int.Parse(mDataRow["ID_Digito_Verificador"].ToString()));
                ValorizarEntidad(mDigitoVerificador, mDataRow);
                mTablas.Add(mDigitoVerificador);
            }
            return mTablas;
        }
        static private List<string> ObtenerDatosRegistros(string Tabla)
        {

            List<string> Registros = new List<string>();
            string Registro = "";
            string DVH = "";

            mQuery = "SELECT * FROM " + Tabla;
            DataSet mDataset = new DataSet();
            mDataset = DAL.DAO.Instancia().ExecuteDataSet(mQuery);
            if (mDataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mROW in mDataset.Tables[0].Rows)
                {
                    for (int i = 0; i < mDataset.Tables[0].Columns.Count; i++)
                    {
                        string mCol = mDataset.Tables[0].Columns[i].ColumnName.ToString();
                        if (mCol != "DVH") 
                            Registro += mROW[mCol].ToString();
                        if (mCol == "DVH") 
                            DVH = mROW[mCol].ToString();
                        
                    }
                    Registro += ";" + DVH;
                    Registros.Add(Registro);
                    Registro = "";
                }
            }
            return Registros;
        }
        #endregion
    }


}
