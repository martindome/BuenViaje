using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BE;

namespace DAL
{
    public class ViajeDAL
    {
        static int mId;
        static SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static SERV.Integridad mIntegridad = new SERV.Integridad();

        public static List<ViajeBE> Listar()
        {
            List<ViajeBE> Lista = new List<ViajeBE>();
            string mCommand = "SELECT b.ID_Viaje, b.ID_Ruta, b.ID_Bus, b.Fecha, b.Cancelado FROM Viaje";
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    ViajeBE mViaje = new ViajeBE();
                    ValorizarEntidad(mViaje, mRow);
                    Lista.Add(mViaje);

                }
            }
            return Lista;
        }

        public static ViajeBE Obtener(int pId)
        {
            throw new NotImplementedException();
        }
        public static void Guardar(ViajeBE pViaje)
        {
            throw new NotImplementedException();
        }

        public static void Borrar(ViajeBE pViaje)
        {
            throw new NotImplementedException();
        }


        private static void ValorizarEntidad(ViajeBE pViaje, DataRow pDataRow)
        {
            pViaje.ID_Viaje = int.Parse(pDataRow["ID_Viaje"].ToString());
            pViaje.ID_Ruta = int.Parse(pDataRow["ID_Ruta"].ToString());
            pViaje.ID_Bus = int.Parse(pDataRow["ID_Bus"].ToString());
            pViaje.Fecha = DateTime.Parse(pDataRow["Fecha"].ToString());
            pViaje.Cancelado = (bool)pDataRow["Cancelado"];
        }

        private static int ProximoId()
        {
            if (mId == 0)
                mId = (DAO.Instancia()).ObtenerUltimoId("Viaje");
            mId += 1;
            return mId;
        }
    }
}
