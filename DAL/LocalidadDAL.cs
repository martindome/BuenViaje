using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data;

namespace DAL
{
    public class LocalidadDAL
    {
        static int mId;
        static SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static SERV.Integridad mIntegridad = new SERV.Integridad();

        public static List<LocalidadBE> Listar()
        {
            List<LocalidadBE> Lista = new List<LocalidadBE>();
            string mCommand = "SELECT l.ID_Localidad, l.Nombre, l.Provincia, l.Pais from Localidad as l";
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    LocalidadBE mLocalidad = new LocalidadBE();
                    ValorizarEntidad(mLocalidad, mRow);
                    Lista.Add(mLocalidad);

                }
            }
            return Lista;
        }

        public static LocalidadBE Obtener(int pId)
        {
            string mCommand = "SELECT ID_Localidad, Nombre, Provincia, Pais FROM Localidad WHERE ID_Localidad = " + pId;
            DataSet mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                LocalidadBE mLocalidad = new LocalidadBE();
                ValorizarEntidad(mLocalidad, mDataSet.Tables[0].Rows[0]);
                return mLocalidad;
            }
            else
            {
                return null;
            }
        }

        public static void Guardar(LocalidadBE pLocalidad)
        {
            string mCommand = "";
            pLocalidad.Nombre = SERV.Seguridad.Cifrado.Cifrar(pLocalidad.Nombre);
            pLocalidad.Provincia = SERV.Seguridad.Cifrado.Cifrar(pLocalidad.Provincia);
            pLocalidad.Pais = SERV.Seguridad.Cifrado.Cifrar(pLocalidad.Pais);

            if (pLocalidad.ID_Localidad == 0)
            {
                pLocalidad.ID_Localidad = ProximoId();
                mCommand = "INSERT INTO Localidad (ID_Localidad, Nombre, Provincia, Pais) VALUES (" + pLocalidad.ID_Localidad + ", '" + pLocalidad.Nombre + "', '" + pLocalidad.Provincia + "', '" + pLocalidad.Pais + "')";
            }
            else
            {
                mCommand = "UPDATE Localidad SET Nombre = '" + pLocalidad.Nombre + "', Provincia = '" + pLocalidad.Provincia + "', Pais = '" + pLocalidad.Pais + "' WHERE ID_Localidad = " + pLocalidad.ID_Localidad;
            }
            DAO.Instancia().ExecuteNonQuery(mCommand);
        }

        public static void Eliminar (LocalidadBE pLocalidad)
        {
            string mCommand = "DELETE Localidad WHERE ID_Localidad = " + pLocalidad.ID_Localidad;
           
            DAO.Instancia().ExecuteNonQuery(mCommand);
        }

        #region private functions
        private static void ValorizarEntidad(LocalidadBE pLocalidad, DataRow pDataRow)
        {
            pLocalidad.ID_Localidad = int.Parse(pDataRow["ID_Localidad"].ToString());
            pLocalidad.Nombre = SERV.Seguridad.Cifrado.Descifrar((pDataRow["Nombre"].ToString()));
            pLocalidad.Provincia = SERV.Seguridad.Cifrado.Descifrar(pDataRow["Provincia"].ToString());
            pLocalidad.Pais = SERV.Seguridad.Cifrado.Descifrar(pDataRow["Pais"].ToString());

        }

        private static int ProximoId()
        {
            if (mId == 0)
                mId = (DAO.Instancia()).ObtenerUltimoId("Localidad");
            mId += 1;
            return mId;
        }
        #endregion

    }
}
