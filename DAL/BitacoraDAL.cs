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
        public static List<BitacoraBE> Listar(DateTime Desde, DateTime Hasta)
        {
            List<BitacoraBE> Lista = new List<BitacoraBE>();
            string mCommand = "SELECT * FROM Bitacora WHERE Fecha >= '" + Desde + "' AND Fecha <= '" + Hasta + "' ";
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
            pBitacora.ID_Bitacora = ProximoId();
            pBitacora.Descripcion = SERV.Seguridad.Cifrado.Cifrar(pBitacora.Descripcion);
            string DVH = mIntegridad.CalcularDVH(pBitacora.ID_Bitacora.ToString() + pBitacora.Fecha.ToString() + pBitacora.Tipo_Evento + pBitacora.Descripcion + pBitacora.ID_Usuario.ToString());
            string mCommand = "INSERT INTO Bitacora (ID_Usuario, Fecha, Tipo_Evento, Descripcion, DVH, ID_Usuario) VALUES (" + pBitacora.ID_Bitacora + ", " + pBitacora.Fecha + ", '" + pBitacora.Tipo_Evento + "', '" + pBitacora.Descripcion + "', '"+ DVH + "', " + pBitacora.ID_Usuario + ")";
            DAO.GetInstance().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Bitacora"), "Bitacora");
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
