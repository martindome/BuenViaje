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
            string mCommand = "SELECT b.ID_Viaje, b.ID_Ruta, b.ID_Bus, b.Fecha, b.Cancelado FROM Viaje as b";
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
            string mCommand = "SELECT b.ID_Viaje, b.ID_Ruta, b.ID_Bus, b.Fecha, b.Cancelado from Viaje as b WHERE ID_Viaje = " + pId;
            DataSet mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                ViajeBE mViaje = new ViajeBE();
                ValorizarEntidad(mViaje, mDataSet.Tables[0].Rows[0]);
                return mViaje;
            }
            else
            {
                return null;
            }
        }
        public static void Guardar(ViajeBE pViaje)
        {
            string mCommand = "";
            if (pViaje.ID_Viaje == 0)
            {
                pViaje.ID_Viaje = ProximoId();
                string DVH = mIntegridad.CalcularDVH(pViaje.ID_Viaje.ToString() + pViaje.ID_Ruta.ToString() + pViaje.ID_Bus.ToString() + pViaje.Fecha.ToString() + pViaje.Cancelado.ToString());
                mCommand = "INSERT INTO Viaje(ID_Viaje, ID_Ruta, ID_Bus, Fecha, Cancelado, DVH) VALUES (" + pViaje.ID_Viaje + ", " + pViaje.ID_Ruta + ", " + pViaje.ID_Bus + ", '" + pViaje.Fecha.ToString() + "', " + pViaje.Cancelado + ", '" + DVH + "')";

            }
            else
            {
                string DVH = mIntegridad.CalcularDVH(pViaje.ID_Viaje.ToString() + pViaje.ID_Ruta.ToString() + pViaje.ID_Bus.ToString() + pViaje.Fecha.ToString() + pViaje.Cancelado.ToString());
                mCommand = "Update Usuario SET ID_Ruta = " + pViaje.ID_Ruta
                    + ", ID_Bus = " + pViaje.ID_Bus
                    + ", Fecha = '" + pViaje.Fecha.ToString()
                    + "', Cancelado = " + pViaje.Cancelado
                    + ", DVH = '" + DVH + "' WHERE ID_Viaje =" + pViaje.ID_Viaje;
                
            }
            DAO.Instancia().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario"), "Usuario");
        }

        public static void Borrar(ViajeBE pViaje)
        {
            string mCommandText = "DELETE Viaje WHERE ID_Viaje = " + pViaje.ID_Viaje;
            DAO.Instancia().ExecuteNonQuery(mCommandText);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario"), "Usuario");
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
