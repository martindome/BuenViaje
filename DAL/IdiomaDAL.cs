using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data;

namespace DAL
{
    public class IdiomaDAL
    {
        public static List<IdiomaBE> Listar()
        {
            List<IdiomaBE> mListaIdiomas = new List<IdiomaBE>();
            string mCommand = "SELECT ID_Idioma, Descripcion FROM Idioma";
            DataSet mDataset = new DataSet();
            mDataset = DAL.DAO.Instancia().ExecuteDataSet(mCommand);

            foreach (DataRow mDataRow in mDataset.Tables[0].Rows)
            {
                IdiomaBE mIdioma = new IdiomaBE();
                ValorizarEntidad(mIdioma, mDataRow);
                mListaIdiomas.Add(mIdioma);
            }
            return mListaIdiomas;
        }

        public static IdiomaBE Obtener(int pId)
        {
            string mCommand = "SELECT ID_Idioma, Descripcion FROM Idioma WHERE ID_Idioma = " + pId;
            DataSet mDataSet = new DataSet();
            mDataSet = DAL.DAO.Instancia().ExecuteDataSet(mCommand);

            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                IdiomaBE mIdioma = new IdiomaBE();
                ValorizarEntidad(mIdioma, mDataSet.Tables[0].Rows[0]);
                return mIdioma;
            }
            else
            {
                return null;
            }
        }

        public static List<ControlBE> ObtenerMensajesControladores(string pIdioma)
        {
            List<ControlBE> Lista = new List<ControlBE>();
            string mCommand = "SELECT c.ID_Idioma, c.Mensaje, c.ID_Control FROM Controles as c INNER JOIN Idioma as i on c.ID_Idioma = i.ID_Idioma where i.Descripcion = '" + pIdioma + "'";
            DataSet mDataset = new DataSet();
            mDataset = DAL.DAO.Instancia().ExecuteDataSet(mCommand);

            foreach (DataRow mDataRow in mDataset.Tables[0].Rows)
            {
                ControlBE mTexto = new ControlBE();
                ValorizarEntidadControl(mTexto, mDataRow);
                Lista.Add(mTexto);
            }
            return Lista;

        }

        public static string ObtenerMensajesTextos(string Texto, string Idioma)
        {
            string resultado = "";
            string mCommand = "Select t.ID_Idioma, t.Mensaje, t.ID_Texto FROM Texto AS t INNER JOIN Idioma AS i on t.ID_Idioma = i.ID_Idioma WHERE t.ID_Texto = '" + Texto + "' and i.Descripcion ='" + Idioma + "'";
            DataSet mDataset = new DataSet();
            mDataset = DAL.DAO.Instancia().ExecuteDataSet(mCommand);

            foreach (DataRow mDataRow in mDataset.Tables[0].Rows){
                resultado = mDataRow["Mensaje"].ToString();
            }
            return resultado;
        }

        #region private functions

        private static void ValorizarEntidad(IdiomaBE pIdioma, DataRow pDataRow)
        {
            pIdioma.ID_Idioma = int.Parse(pDataRow["ID_Idioma"].ToString());
            pIdioma.Descripcion = pDataRow["Descripcion"].ToString();
        }

        private static void ValorizarEntidadControl(ControlBE pControl, DataRow pDataRow)
        {
            pControl.ID_Idioma = int.Parse(pDataRow["ID_Idioma"].ToString());
            pControl.ID_Control = pDataRow["ID_Control"].ToString();
            pControl.Mensaje = pDataRow["Mensaje"].ToString();
        }
        #endregion

    }
}
