using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BE;

namespace DAL
{
    public class RutaDAL
    {
        static int mId;
        static SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static SERV.Integridad mIntegridad = new SERV.Integridad();

        public static List<RutaBE> Listar()
        {
            List<RutaBE> Lista = new List<RutaBE>();
            List<LocalidadBE> Localidades = LocalidadDAL.Listar();
            string mCommand = "SELECT b.ID_Ruta, b.Nombre, b.Origen, b.Destino, b.Duracion from Ruta as b";
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    RutaBE mRuta = new RutaBE();
                    ValorizarEntidad(mRuta, mRow);
                    Lista.Add(mRuta);

                }
            }
            return Lista;
        }

        public static RutaBE Obtener(int pId)
        {
            string mCommand = "SELECT b.ID_Ruta, b.Nombre, b.Origen, b.Destino, b.Duracion from Ruta as b WHERE ID_Ruta = " + pId;
            DataSet mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                RutaBE mRuta = new RutaBE();
                ValorizarEntidad(mRuta, mDataSet.Tables[0].Rows[0]);
                return mRuta;
            }
            else
            {
                return null;
            }
        }

        public static void Guardar(RutaBE pRuta)
        {
            string mCommand = "";
            if (pRuta.ID_Ruta == 0)
            {
                pRuta.ID_Ruta = ProximoId();
                mCommand = "INSERT INTO Ruta (ID_Ruta, Nombre, Origen, Destino, Duracion) VALUES (" + pRuta.ID_Ruta + ", '" + pRuta.Nombre + "', " + pRuta.Origen.ID_Localidad + ", " + pRuta.Destino.ID_Localidad + ", " + pRuta.Duracion + ")";
            }
            else
            {
                mCommand = "UPDATE Ruta SET Nombre = '" + pRuta.Nombre + "', Origen = " + pRuta.Origen.ID_Localidad + ", Destino = " + pRuta.Destino.ID_Localidad + ", Duracion = " + pRuta.Duracion + " WHERE ID_Ruta = " + pRuta.ID_Ruta;
            }
            DAO.Instancia().ExecuteNonQuery(mCommand);
        }

        public static void Eliminar(RutaBE pRuta)
        {
            string mCommand = "DELETE Ruta WHERE ID_Ruta = " + pRuta.ID_Ruta;
            DAO.Instancia().ExecuteNonQuery(mCommand);
        }

        #region private functions
        private static void ValorizarEntidad(RutaBE pRuta, DataRow pDataRow)
        {
            pRuta.ID_Ruta = int.Parse(pDataRow["ID_Ruta"].ToString());
            pRuta.Nombre = SERV.Seguridad.Cifrado.Descifrar((pDataRow["Nombre"].ToString()));
            pRuta.Origen = LocalidadDAL.Obtener(int.Parse(SERV.Seguridad.Cifrado.Descifrar(pDataRow["Origen"].ToString())));
            pRuta.Destino = LocalidadDAL.Obtener(int.Parse(SERV.Seguridad.Cifrado.Descifrar(pDataRow["Destino"].ToString())));
            pRuta.Duracion = int.Parse(SERV.Seguridad.Cifrado.Descifrar(pDataRow["Duracion"].ToString()));
        }

        private static int ProximoId()
        {
            if (mId == 0)
                mId = (DAO.Instancia()).ObtenerUltimoId("Ruta");
            mId += 1;
            return mId;
        }
        #endregion
    }


}
}
