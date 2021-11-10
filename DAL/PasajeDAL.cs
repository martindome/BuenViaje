using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BE;

namespace DAL
{
    public class PasajeDAL
    {
        static int mId;
        static SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static SERV.Integridad mIntegridad = new SERV.Integridad();

        public static List<PasajeBE> Listar()
        {
            List<PasajeBE> Lista = new List<PasajeBE>();
            string mCommand = "SELECT b.ID_Pasaje, b.ID_Viaje, b.ID_Cliente, b.Fecha, b.Devuelto FROM Pasaje as b";
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    PasajeBE mPasaje = new PasajeBE();
                    ValorizarEntidad(mPasaje, mRow);
                    Lista.Add(mPasaje);

                }
            }
            return Lista;
        }
        public static List<PasajeBE> ListarCliente(int pId)
        {
            List<PasajeBE> Lista = new List<PasajeBE>();
            string mCommand = "SELECT b.ID_Pasaje, b.ID_Viaje, b.ID_Cliente, b.Fecha, b.Devuelto FROM Pasaje as b where b.ID_Cliente = " + pId;
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    PasajeBE mPasaje = new PasajeBE();
                    ValorizarEntidad(mPasaje, mRow);
                    Lista.Add(mPasaje);

                }
            }
            return Lista;
        }
        public static List<PasajeBE> ListarClienteDevueltos(int pId)
        {
            List<PasajeBE> Lista = new List<PasajeBE>();
            string mCommand = "SELECT b.ID_Pasaje, b.ID_Viaje, b.ID_Cliente, b.Fecha, b.Devuelto FROM Pasaje as b where b.ID_Cliente = " + pId;
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    PasajeBE mPasaje = new PasajeBE();
                    ValorizarEntidad(mPasaje, mRow);
                    if (!mPasaje.Devuelto)
                    {
                        Lista.Add(mPasaje);
                    }

                }
            }
            return Lista;
        }
        public static List<PasajeBE> ListarViaje(int pId)
        {
            List<PasajeBE> Lista = new List<PasajeBE>();
            string mCommand = "SELECT b.ID_Pasaje, b.ID_Viaje, b.ID_Cliente, b.Fecha, b.Devuelto FROM Pasaje as b where b.ID_Viaje = " + pId;
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    PasajeBE mPasaje = new PasajeBE();
                    ValorizarEntidad(mPasaje, mRow);
                    if (!mPasaje.Devuelto)
                    {
                        Lista.Add(mPasaje);
                    }
                }
            }
            return Lista;
        }
        public static List<PasajeBE> ListarViajeDevueltos(int pId)
        {
            List<PasajeBE> Lista = new List<PasajeBE>();
            string mCommand = "SELECT b.ID_Pasaje, b.ID_Viaje, b.ID_Cliente, b.Fecha, b.Devuelto FROM Pasaje as b where b.ID_Viaje = " + pId;
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    PasajeBE mPasaje = new PasajeBE();
                    ValorizarEntidad(mPasaje, mRow);
                    Lista.Add(mPasaje);
                }
            }
            return Lista;
        }
        public static PasajeBE Obtener(int pId)
        {
            string mCommand = "SELECT b.ID_Pasaje, b.ID_Viaje, b.ID_Cliente, b.Fecha, b.Devuelto FROM Pasaje as b where b.ID_Pasaje = " + pId;
            DataSet mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                PasajeBE mPasaje = new PasajeBE();
                ValorizarEntidad(mPasaje, mDataSet.Tables[0].Rows[0]);
                return mPasaje;
            }
            else
            {
                return null;
            }
        }
        public static void Guardar(PasajeBE pPasaje)
        {
            string mCommand = "";
            if (pPasaje.ID_Pasaje == 0)
            {
                pPasaje.ID_Pasaje = ProximoId();
                string DVH = mIntegridad.CalcularDVH(pPasaje.ID_Pasaje.ToString() + pPasaje.ID_Viaje.ToString() + pPasaje.ID_Cliente.ToString() + pPasaje.Fecha.ToString() + pPasaje.Devuelto.ToString());
                mCommand = "INSERT INTO Pasaje(ID_Pasaje, ID_Usuario, ID_Viaje, ID_Cliente, Fecha, Devuelto, DVH) VALUES (@Pasaje, @Usuario, @Viaje, @Cliente, @Fecha, @Devuelto, @DVH)";
                Dictionary<string, Object> parameters = new Dictionary<string, Object>();
                parameters.Add("@Pasaje", pPasaje.ID_Pasaje);
                parameters.Add("@Viaje", pPasaje.ID_Viaje);
                parameters.Add("@Cliente", pPasaje.ID_Cliente);
                parameters.Add("@Fecha", pPasaje.Fecha);
                parameters.Add("@Devuelto", pPasaje.Devuelto);
                parameters.Add("@DVH", DVH);
                DAO.Instancia().ExecuteNonQuery(mCommand, parameters);
            }
            else
            {
                string DVH = mIntegridad.CalcularDVH(pPasaje.ID_Pasaje.ToString()+ pPasaje.ID_Viaje.ToString() + pPasaje.ID_Cliente.ToString() + pPasaje.Fecha.ToString() + pPasaje.Devuelto.ToString());
                mCommand = "UPDATE Pasaje SET ID_Usuario = @Usuario, ID_Viaje = @Viaje, ID_Cliente = @Cliente, Fecha = @Fecha, Devuelto = @Devuelto, DVH = @DVH WHERE ID_Pasaje = @Pasaje";
                Dictionary<string, Object> parameters = new Dictionary<string, Object>();
                parameters.Add("@Pasaje", pPasaje.ID_Pasaje);
                parameters.Add("@Viaje", pPasaje.ID_Viaje);
                parameters.Add("@Cliente", pPasaje.ID_Cliente);
                parameters.Add("@Fecha", pPasaje.Fecha);
                parameters.Add("@Devuelto", pPasaje.Devuelto);
                parameters.Add("@DVH", DVH);
                DAO.Instancia().ExecuteNonQuery(mCommand, parameters);

            }
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Pasaje"), "Pasaje");
        }
        public static void Borrar(PasajeBE pPasaje)
        {
            string mCommandText = "DELETE Pasaje WHERE ID_Pasaje = " + pPasaje.ID_Pasaje;
            DAO.Instancia().ExecuteNonQuery(mCommandText);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Pasaje"), "Pasaje");
        }
        private static void ValorizarEntidad(PasajeBE pPasaje, DataRow pDataRow)
        {
            pPasaje.ID_Pasaje = int.Parse(pDataRow["ID_Pasaje"].ToString());
            pPasaje.ID_Viaje = int.Parse(pDataRow["ID_Viaje"].ToString());
            pPasaje.ID_Cliente = int.Parse(pDataRow["ID_Cliente"].ToString());
            pPasaje.Fecha = DateTime.Parse(pDataRow["Fecha"].ToString());
            pPasaje.Devuelto = (bool)pDataRow["Devuelto"];
        }
        private static int ProximoId()
        {
            if (mId == 0)
                mId = (DAO.Instancia()).ObtenerUltimoId("Pasaje");
            mId += 1;
            return mId;
        }
    }
}
