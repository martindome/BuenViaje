using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BE;
using BE.Composite;

namespace DAL
{
    public class BusDAL
    {

        static int mId;
        static SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static SERV.Integridad mIntegridad = new SERV.Integridad();

        public static List<BusBE> Listar()
        {
            List<BusBE> Lista = new List<BusBE>();
            string mCommand = "SELECT b.ID_Bus, b.Patente, b.Marca, b.Asientos, b.DVH from Bus as b";
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    BusBE mBus = new BusBE();
                    ValorizarEntidad(mBus, mRow);
                    Lista.Add(mBus);

                }
            }
            return Lista;
        }

        public static BusBE Obtener(int pId)
        {
            string mCommand = "SELECT b.ID_Bus, b.Patente, b.Marca, b.Asientos, b.DVH from Bus as b WHERE ID_Bus = " + pId;
            DataSet mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                BusBE mBus = new BusBE();
                ValorizarEntidad(mBus, mDataSet.Tables[0].Rows[0]);
                return mBus;
            }
            else
            {
                return null;
            }
        }

        public static void Guardar(BusBE pBus)
        {
            string mCommand = "";
            pBus.Patente = SERV.Seguridad.Cifrado.Cifrar(pBus.Patente);
            pBus.Marca = SERV.Seguridad.Cifrado.Cifrar(pBus.Marca);
            //pBus.Asientos = SERV.Seguridad.Cifrado.Cifrar(pBus.Asientos);
            string DVH = mIntegridad.CalcularDVH(pBus.ID_Bus.ToString() + pBus.Patente + pBus.Marca + pBus.Asientos);
            if (pBus.ID_Bus == 0)
            {
                pBus.ID_Bus = ProximoId();
                mCommand = "INSERT INTO Bus (ID_Bus, Patente, Marca, Asientos, DVH) VALUES (" + pBus.ID_Bus + ", '" + pBus.Patente + "', '" + pBus.Marca + "', " + pBus.Asientos + ", '" + DVH + "')";
            }
            else
            {
                mCommand = "UPDATE Bus SET Patente = '" + pBus.Patente + "', Marca = '" + pBus.Marca + "', Asientos = " + pBus.Asientos + ", DVH = '" + DVH + "' WHERE ID_Bus = " + pBus.ID_Bus;
            }
            DAO.Instancia().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Bus"), "Bus");
        }

        public static void Eliminar(BusBE pbus)
        {
            string mCommand = "DELETE Bus WHERE ID_Bus = " + pbus.ID_Bus;
            DAO.Instancia().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Bus"), "Bus");
        }

        #region private functions
        private static void ValorizarEntidad(BusBE pBus, DataRow pDataRow)
        {
            pBus.ID_Bus = int.Parse(pDataRow["ID_Bus"].ToString());
            pBus.Patente = SERV.Seguridad.Cifrado.Descifrar((pDataRow["Patente"].ToString()));
            pBus.Marca = SERV.Seguridad.Cifrado.Descifrar(pDataRow["Marca"].ToString());
            pBus.Asientos = int.Parse(pDataRow["Asientos"].ToString());
            pBus.DVH = pDataRow["DVH"].ToString();
        }

        private static int ProximoId()
        {
            
                mId = (DAO.Instancia()).ObtenerUltimoId("Bus");
            mId += 1;
            return mId;
        }
        #endregion
    }
}
