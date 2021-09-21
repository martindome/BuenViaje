using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using BE.Composite;
using System.Data;
using System.Data.SqlClient;
using SERV;

namespace DAL
{
    public class PatenteDAL
    {
        static SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static SERV.Integridad mIntegridad = new SERV.Integridad();
        public static void ValorizarEntidad(PatenteBE pPatente, DataRow mDataRow)
        {
            pPatente.ID_Compuesto = int.Parse(mDataRow["ID_Permiso"].ToString());
            pPatente.Nombre = SERV.Seguridad.Cifrado.Descifrar(mDataRow["Nombre"].ToString());
            pPatente.Descripcion = mDataRow["Descripcion"].ToString();
            pPatente.Tipo = (BE.Composite.TipoPermiso)Enum.Parse(typeof(BE.Composite.TipoPermiso), mDataRow["Tipo_Permiso"].ToString());
        }

        public static PatenteBE Obtener(int id)
        {
            string mCommand = "Select p.ID_Permiso, p.Nombre, p.Descripcion, Tipo_Permiso from Permiso p WHERE p.ID_Permiso = " + id;
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.GetInstance().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                PatenteBE mPatente = new PatenteBE();
                ValorizarEntidad(mPatente, mDataSet.Tables[0].Rows[0]);
                return mPatente;
            }
            else
            {
                return null;
            }
        }

        public static List<PatenteBE> Listar()
        {
            List<PatenteBE> patentes = new List<PatenteBE>();
            string mCommand = "Select p.ID_Permiso, p.Nombre, p.Descripcion, Tipo_Permiso from Permiso p";
            DataSet mDataSet = DAO.GetInstance().ExecuteDataSet(mCommand);


            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDataRow in mDataSet.Tables[0].Rows)
                {
                    PatenteBE mPatente = new PatenteBE();
                    ValorizarEntidad(mPatente, mDataRow);
                    patentes.Add(mPatente);
                }
            }
            return patentes;
        }

        public static void GuardarPatenteUsuario(PatenteBE patente, UsuarioBE usuario)
        {
            string DVH = mIntegridad.CalcularDVH(usuario.ID_Usuario.ToString() + patente.ID_Compuesto.ToString());
            string mCommand = "INSERT INTO Usuario_Permiso (ID_Permiso, ID_Usuario, DVH) VALUES (" +patente.ID_Compuesto + ", " + usuario.ID_Usuario  + ", '" + DVH +"')";
            DAO.GetInstance().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario_Permiso"), "Usuario_Permiso");
        }

        public static void BorrarPatenteUsuario(PatenteBE patente, UsuarioBE usuario)
        {
            string mCommand = "DELETE FROM Usuario_Permiso WHERE ID_Permiso = " + patente.ID_Compuesto + " AND ID_Usuario = " + usuario.ID_Usuario;
            DAO.GetInstance().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario_Permiso"), "Usuario_Permiso");
        }
    }
}
