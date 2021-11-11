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
        public static List<BitacoraBE> Listar()
        {
            List<BitacoraBE> Lista = new List<BitacoraBE>();
            string mCommand = "SELECT b.ID_Bitacora, b.Fecha, b.Tipo_Evento, b.Descripcion, b.Nombre_Usuario, b.DVH, b.Nombre_Usuario FROM Bitacora as b";
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    BitacoraBE mBitacora = new BitacoraBE();
                    ValorizarEntidad(mBitacora, mRow);
                    Lista.Add(mBitacora);

                }
            }
            return Lista;
        }

        public static void Guardar(BitacoraBE pBitacora)
        {
            string mCommand = "";
            pBitacora.ID_Bitacora = ProximoId();
            pBitacora.Descripcion = SERV.Seguridad.Cifrado.Cifrar(pBitacora.Descripcion);
            Dictionary<string, Object> parameters = new Dictionary<string, Object>();
            if (pBitacora.Nombre_Usuario == "NULL")
            {
                pBitacora.Nombre_Usuario = SERV.Seguridad.Cifrado.Cifrar("NULL");
                string DVH = mIntegridad.CalcularDVH(pBitacora.ID_Bitacora.ToString() + pBitacora.Fecha.ToString() + pBitacora.Tipo_Evento + pBitacora.Descripcion + pBitacora.Nombre_Usuario);
                //mCommand = "INSERT INTO Bitacora (ID_Bitacora, Fecha, Tipo_Evento, Descripcion, DVH, Nombre_Usuario) VALUES (" + pBitacora.ID_Bitacora + ", '" + pBitacora.Fecha.ToString() + "', '" + pBitacora.Tipo_Evento + "', '" + pBitacora.Descripcion + "', '" + DVH + "', NULL)";
                mCommand = "INSERT INTO Bitacora(ID_Bitacora, Fecha, Tipo_Evento, Descripcion, DVH, Nombre_Usuario) VALUES (@ID_Bitacora, @Fecha, @Tipo, @Descripcion, @DVH, @Nombre_Usuario)";    
                parameters.Add("@ID_Bitacora", pBitacora.ID_Bitacora);
                parameters.Add("@Fecha", pBitacora.Fecha.ToString());
                parameters.Add("@Tipo", pBitacora.Tipo_Evento);
                parameters.Add("@Descripcion", pBitacora.Descripcion);
                parameters.Add("@DVH", DVH);
                parameters.Add("@Nombre_Usuario", pBitacora.Nombre_Usuario);
                //DAO.Instancia().ExecuteNonQuery(mCommand, parameters);
            }
            else
            {
                pBitacora.Nombre_Usuario = SERV.Seguridad.Cifrado.Cifrar(pBitacora.Nombre_Usuario);
                string DVH = mIntegridad.CalcularDVH(pBitacora.ID_Bitacora.ToString() + pBitacora.Fecha.ToString() + pBitacora.Tipo_Evento + pBitacora.Descripcion + pBitacora.Nombre_Usuario);
                //mCommand = "INSERT INTO Bitacora (ID_Bitacora, Fecha, Tipo_Evento, Descripcion, DVH, Nombre_Usuario) VALUES (" + pBitacora.ID_Bitacora + ", '" + pBitacora.Fecha.ToString() + "', '" + pBitacora.Tipo_Evento + "', '" + pBitacora.Descripcion + "', '" + DVH + "', NULL)";
                mCommand = "INSERT INTO Bitacora(ID_Bitacora, Fecha, Tipo_Evento, Descripcion, DVH, Nombre_Usuario) VALUES (@ID_Bitacora, @Fecha, @Tipo, @Descripcion, @DVH, @Nombre_Usuario)";
                parameters.Add("@ID_Bitacora", pBitacora.ID_Bitacora);
                parameters.Add("@Fecha", pBitacora.Fecha.ToString());
                parameters.Add("@Tipo", pBitacora.Tipo_Evento);
                parameters.Add("@Descripcion", pBitacora.Descripcion);
                parameters.Add("@DVH", DVH);
                parameters.Add("@Nombre_Usuario", pBitacora.Nombre_Usuario);
                //DAO.Instancia().ExecuteNonQuery(mCommand, parameters);
            }
            DAO.Instancia().ExecuteNonQuery(mCommand, parameters);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Bitacora"), "Bitacora");
        }

        //public static void UpdateBitacora(BitacoraBE pBitacora)
        //{
        //    List<Bitacora> registros = 
        //}

        public static List<string> ListarUsuarios()
        {
            string mCommand = "SELECT DISTINCT(b.Nombre_Usuario), u.Nombre_Usuario FROM Bitacora b INNER JOIN Usuario u on b.Nombre_Usuario = u.Nombre_Usuario";
            List<string> Lista = new List<string>();
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.Instancia().ExecuteDataSet(mCommand);
            foreach (DataRow mRow in mDataSet.Tables[0].Rows)
            {      
                Lista.Add(SERV.Seguridad.Cifrado.Descifrar(mRow["Nombre_Usuario"].ToString()));
            }
            return Lista;
        }

        #region private
        private static void ValorizarEntidad(BitacoraBE pBitacora, DataRow pDataRow)
        {
            pBitacora.ID_Bitacora = int.Parse(pDataRow["ID_Bitacora"].ToString());
            pBitacora.Fecha = DateTime.Parse(pDataRow["Fecha"].ToString());
            pBitacora.Tipo_Evento = pDataRow["Tipo_Evento"].ToString();
            pBitacora.Descripcion = SERV.Seguridad.Cifrado.Descifrar(pDataRow["Descripcion"].ToString());
            pBitacora.DVH = (pDataRow["DVH"].ToString());
            pBitacora.Nombre_Usuario = (pDataRow["Nombre_Usuario"].ToString() != "NULL") ? SERV.Seguridad.Cifrado.Descifrar(pDataRow["Nombre_Usuario"].ToString()) : "NULL"; 
        }

        private static int ProximoId()
        {
            if (mId == 0)
                mId = (DAO.Instancia()).ObtenerUltimoId("Bitacora");
            mId += 1;
            return mId;
        }

        #endregion
    }
}
