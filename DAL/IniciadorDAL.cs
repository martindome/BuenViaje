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
        static public void ProbarConexionDB()
        {
            try
            {
                DAO.GetInstance().ProbarConexion();
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
            foreach (DigitoVerificadorVerticalBE mDigitoVerificador in ObtenerTablasDigitoVerificador())//Por cada tabla protegida
            {
                foreach (string mReg in ObtenerDatosRegistros(mDigitoVerificador.Tabla))//Traer los registros
                {
                    mRegistroSplit = mReg.Split(char.Parse(";"));//split DVH almacenado
                    mHashCalculado = mCifra.CalcularHashMD5(mRegistroSplit[0]);//Calculamos hash con la primer parte
                    if (mHashCalculado != mRegistroSplit[1]) //Si el hash calculado no coincide con el obtenido...
                    {
                        //DigitoVerificadorVerticalBE mDigitoVerificadorVerticalBE = new DigitoVerificadorVerticalBE(mDigitoVerificador.ID_DVV);
                        //mDigitoVerificadorVerticalBE.Tabla = mRegistroSplit[0];
                        //mDigitoVerificadorVerticalBE.DVV = mDigitoVerificador.Tabla;
                        Tablas.Add(mDigitoVerificador);
                    }
                }
            }
            return Tablas;
        }
        static public List<DigitoVerificadorVerticalBE> ChequearDigitoVerificadorVertical()
        {
            List<DigitoVerificadorVerticalBE> Tablas = new List<DigitoVerificadorVerticalBE>();
            foreach (DigitoVerificadorVerticalBE mDigitoVerificador in ObtenerTablasDigitoVerificador())//Por cada tabla protegida
            {
                string DigitoVerificador = ServDAL.CalcularDVV(mDigitoVerificador.Tabla); // Calcular el digito vertical
                if (DigitoVerificador != mDigitoVerificador.DVV) // y compararlo con el almacenado en la DB.
                    Tablas.Add(mDigitoVerificador);
            }
            return Tablas;
        }

        #region private functions
        private static void ValorizarEntidad(DigitoVerificadorVerticalBE pDigito, DataRow pDataRow)
        {
            pDigito.Tabla = pDataRow["Tabla"].ToString();
            pDigito.DVV = pDataRow["Apellido"].ToString();
        }
        static private List<DigitoVerificadorVerticalBE> ObtenerTablasDigitoVerificador()
        {
            List<DigitoVerificadorVerticalBE> mTablas = new List<DigitoVerificadorVerticalBE>();
            mQuery = "SELECT * FROM Digito_Verificador";
            DataSet mDataset = new DataSet();
            mDataset = DAL.DAO.GetInstance().ExecuteDataSet(mQuery);

            foreach (DataRow mDataRow in mDataset.Tables[0].Rows)
            {
                DigitoVerificadorVerticalBE mDigitoVerificador = new DigitoVerificadorVerticalBE(int.Parse(mDataRow["ID_DVV"].ToString()));
                ValorizarEntidad(mDigitoVerificador, mDataRow);
                mTablas.Add(mDigitoVerificador);
            }
            return mTablas;
        }
        static private List<string> ObtenerDatosRegistros(string Tabla)
        {

            List<string> Registros = new List<string>();
            string Registro = "";

            mQuery = "SELECT * FROM " + Tabla;
            DataSet mDataset = new DataSet();
            mDataset = DAL.DAO.GetInstance().ExecuteDataSet(mQuery);
            if (mDataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mROW in mDataset.Tables[0].Rows)
                {
                    for (int i = 0; i < mDataset.Tables[0].Columns.Count; i++)
                    {
                        string mCol = mDataset.Tables[0].Columns[i].ColumnName.ToString();
                        if (mCol != "DVH") //Primero cargamos el registro concatenado
                            Registro += mROW[mCol].ToString();
                        if (mCol == "DVH") //Agregamos el DVH con ; para parsear a posterior
                            Registro += ";" + mROW[mCol].ToString();
                    }
                    Registros.Add(Registro);
                    Registro = "";
                }
            }
            return Registros;
        }
        #endregion
    }


}
