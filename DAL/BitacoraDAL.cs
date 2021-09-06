using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data;

namespace DAL
{
    public class BitacoraDAL
    {
        static int mId;
        static SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static SERV.Integridad mIntegridad = new SERV.Integridad();
        public static List<BitacoraBE> Listar(BitacoraBE pBitacora, DateTime Desde, DateTime Hasta)
        {
            List<BitacoraBE> Lista = new List<BitacoraBE>();
            string mCommand = "SELECT b.ID_Bitacora, b.Fecha, b.Tipo_Evento, b.Descripcion, b.ID_Usuario, u.Nombre_Usuario FROM Bitacora as b INNER JOIN Usuario as u on u.ID_Usuario=b.ID_Usuario WHERE b.Fecha >= '" + Desde + "' AND b.Fecha <= '" + Hasta + "' ";
            //NIVEL, USUARIO
            if (pBitacora.Tipo_Evento != null && pBitacora.Nombre_Usuario != null)
            {
                mCommand += "AND b.Tipo_Evento='" + pBitacora.Tipo_Evento + "' AND b.Nombre_Usuario='" + pBitacora.Nombre_Usuario + "'";
            }
            //NIVEL
            else if (pBitacora.Tipo_Evento != null && pBitacora.Nombre_Usuario == null)
            {
                mCommand += "AND b.Tipo_Evento='" + pBitacora.Tipo_Evento + "' ";
            }
            //Usuario
            else if (pBitacora.Nombre_Usuario != null && pBitacora.Tipo_Evento == null)
            {
                mCommand += "AND b.Nombre_Usuario='" + pBitacora.Nombre_Usuario + "' ";
            }
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.GetInstance().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                BitacoraBE mBitacora = new BitacoraBE();
                ValorizarEntidad(mBitacora, mDataSet.Tables[0].Rows[0]);
                Lista.Add(mBitacora);
            }
            return Lista;
        }

        public static void Guardar(BitacoraBE pBitacora)
        {
            string mCommand = "";
            pBitacora.ID_Bitacora = ProximoId();
            pBitacora.Descripcion = SERV.Seguridad.Cifrado.Cifrar(pBitacora.Descripcion);
            
            if (pBitacora.ID_Usuario == 0)
            {
                string DVH = mIntegridad.CalcularDVH(pBitacora.ID_Bitacora.ToString() + pBitacora.Fecha.ToString() + pBitacora.Tipo_Evento + pBitacora.Descripcion);
                mCommand = "INSERT INTO Bitacora (ID_Bitacora, Fecha, Tipo_Evento, Descripcion, DVH, ID_Usuario) VALUES (" + pBitacora.ID_Bitacora + ", '" + pBitacora.Fecha.ToString() + "', '" + pBitacora.Tipo_Evento + "', '" + pBitacora.Descripcion + "', '" + DVH + "', NULL)";
            }
            else
            {
                string DVH = mIntegridad.CalcularDVH(pBitacora.ID_Bitacora.ToString() + pBitacora.Fecha.ToString() + pBitacora.Tipo_Evento + pBitacora.Descripcion + pBitacora.ID_Usuario.ToString());
                mCommand = "INSERT INTO Bitacora (ID_Bitacora, Fecha, Tipo_Evento, Descripcion, DVH, ID_Usuario) VALUES (" + pBitacora.ID_Bitacora + ", '" + pBitacora.Fecha + "', '" + pBitacora.Tipo_Evento + "', '" + pBitacora.Descripcion + "', '" + DVH + "', " + pBitacora.ID_Usuario + ")";
                mCommand = "INSERT INTO Bitacora (ID_Bitacora, Fecha, Tipo_Evento, Descripcion, DVH, ID_Usuario) VALUES (" + pBitacora.ID_Bitacora + ", '" + pBitacora.Fecha + "', '" + pBitacora.Tipo_Evento + "', '" + pBitacora.Descripcion + "', '" + DVH + "', " + pBitacora.ID_Usuario + ")";
            }
            DAO.GetInstance().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Bitacora"), "Bitacora");
        }

        public static List<string> ListarUsuarios()
        {
            string mCommand = "SELECT DISTINCT(b.ID_Usuario), u.Nombre_Usuario FROM Bitacora b INNER JOIN Usuario u on b.ID_Usuario = u.ID_Usuario";
            List<string> Lista = new List<string>();
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.GetInstance().ExecuteDataSet(mCommand);
            foreach (DataRow mRow in mDataSet.Tables[0].Rows)
            {      
                Lista.Add(mRow["Nombre_Usuario"].ToString());
            }
            return Lista;
        }

        #region private
        private static void ValorizarEntidad(BitacoraBE pBitacora, DataRow pDataRow)
        {
            pBitacora.ID_Bitacora = int.Parse(pDataRow["ID_Bitacora"].ToString());
            pBitacora.Fecha = DateTime.Parse(pDataRow["Fecha"].ToString());
            pBitacora.Tipo_Evento = pDataRow["Tipo_Evento"].ToString();
            pBitacora.Descripcion = pDataRow["Descripcion"].ToString();
            pBitacora.DVH = (pDataRow["DVH"].ToString());
            pBitacora.ID_Usuario = int.Parse(pDataRow["ID_Usuario"].ToString());
        }

        private static int ProximoId()
        {
            if (mId == 0)
                mId = (DAO.GetInstance()).ObtenerUltimoId("Bitacora");
            mId += 1;
            return mId;
        }

        #endregion
    }
}
