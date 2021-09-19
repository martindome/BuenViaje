using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using BE.Composite;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class FamiliaDAL
    {
        static private int mId;
        static private SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static private SERV.Integridad mIntegridad = new SERV.Integridad();
        public static List<PatenteBE> ListarPatentes(FamiliaBE pFamilia)
        {
            List<PatenteBE> patentes = new List<PatenteBE>();

            string mCommand = "SELECT p.ID_Permiso, p.Nombre, p.Descripcion, p.Tipo_Permiso, f.ID_Familia " +
                "FROM Permiso AS p " +
                "INNER JOIN Permiso_Familia AS pf ON pf.ID_Permiso = p.ID_Permiso " +
                "INNER JOIN Familia AS f ON pf.ID_Familia = f.ID_Familia " +
                "WHERE f.ID_Familia = " + pFamilia.ID_Compuesto;
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.GetInstance().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDataRow in mDataSet.Tables[0].Rows)
                {
                    PatenteBE pPatente = new PatenteBE();
                    PatenteDAL.ValorizarEntidad(pPatente, mDataRow);
                    patentes.Add(pPatente);
                }
            }
            return patentes;
        }

        public static List<FamiliaBE> Listar()
        {
            List<FamiliaBE> familias = new List<FamiliaBE>();
            string mCommand = "Select p.ID_Familia, p.Nombre, p.Descripcion from Familia p";
            DataSet mDataSet = DAO.GetInstance().ExecuteDataSet(mCommand);


            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDataRow in mDataSet.Tables[0].Rows)
                {
                    FamiliaBE mFamilia = new FamiliaBE();
                    ValorizarEntidad(mFamilia, mDataRow);
                    familias.Add(mFamilia);
                }
            }
            foreach (FamiliaBE familia in familias)
            {
                List<PatenteBE> InnerPatentes = FamiliaDAL.ListarPatentes(familia);
                foreach (PatenteBE patente in InnerPatentes)
                {
                    familia.AgregarPermiso(patente);
                }
            }
            return familias;
        }

        public static FamiliaBE Obtener(int id)
        {
            string mCommand = "Select p.ID_Familia, p.Nombre, p.Descripcion from Familia p WHERE p.ID_Familia = " + id;
            DataSet mDataSet = new DataSet();
            mDataSet = DAO.GetInstance().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                FamiliaBE mFamilia = new FamiliaBE();
                ValorizarEntidad(mFamilia, mDataSet.Tables[0].Rows[0]);
                return mFamilia;
            }
            else
            {
                return null;
            }
        }
        public static void Guardar(FamiliaBE pFamilia)
        {
            string mCommand = "";
            string Nombre_Familia = SERV.Seguridad.Cifrado.Cifrar(pFamilia.Nombre);
            if (pFamilia.ID_Compuesto == 0)
            {
                pFamilia.ID_Compuesto = ProximoId();
                mCommand = "INSERT INTO Familia (ID_Familia, Nombre, Descripcion) VALUES ("+pFamilia.ID_Compuesto + ", '" + pFamilia.Nombre + "', '" + pFamilia.Descripcion + "')";
            }
            else
            {
                mCommand = "UPDATE Familia SET Nombre = '" + pFamilia.Nombre + "', Descipcion = '" + pFamilia.Descripcion + "' WHERE ID_Familia = " + pFamilia.ID_Compuesto;
            }
            DAO.GetInstance().ExecuteNonQuery(mCommand);
        }

        public static void Eliminar(FamiliaBE pFamilia)
        {
            string mCommand = "DELETE Familia WHERE ID_Familia = " + pFamilia.ID_Compuesto;
            DAO.GetInstance().ExecuteNonQuery(mCommand);
        }

        public static void GuardarFamiliaUsuario(FamiliaBE familia, UsuarioBE usuario)
        {
            string DVH = mIntegridad.CalcularDVH(usuario.ID_Usuario.ToString() + familia.ID_Compuesto.ToString());
            string mCommand = "INSERT INTO Usuario_Familia (ID_Familia, ID_Usuario, DVH) VALUES (" + familia.ID_Compuesto + ", " + usuario.ID_Usuario + ", '" + DVH + "')";
            DAO.GetInstance().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario_Familia"), "Usuario_Familia");
        }

        public static void BorrarFamiliaUsuario(FamiliaBE familia, UsuarioBE usuario)
        {
            string mCommand = "DELETE FROM Usuario_Familia WHERE ID_Familia = " + familia.ID_Compuesto + " AND ID_Usuario = " + usuario.ID_Usuario;
            DAO.GetInstance().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario_Familia"), "Usuario_Familia");
        }

        public static void GuardarFamiliaPatente(FamiliaBE familia, PatenteBE patente)
        {
            string DVH = mIntegridad.CalcularDVH(patente.ID_Compuesto.ToString() + familia.ID_Compuesto.ToString());
            string mCommand = "INSERT INTO Permiso_Familia (ID_Familia, ID_Permiso, DVH) VALUES (" + familia.ID_Compuesto + ", " + patente.ID_Compuesto + ", '" + DVH + "')";
            DAO.GetInstance().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Permiso_Familia"), "Permiso_Familia");
        }

        public static void BorrarFamiliaPatente(FamiliaBE familia, PatenteBE patente)
        {
            string mCommand = "DELETE FROM Permiso_Familia WHERE ID_Familia = " + familia.ID_Compuesto + " AND ID_Permiso = " + patente.ID_Compuesto;
            DAO.GetInstance().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Permiso_Familia"), "Permiso_Familia");
        }

        private static int ProximoId()
        {
            if (mId == 0)
                mId = (DAO.GetInstance()).ObtenerUltimoId("Familia");
            mId += 1;
            return mId;
        }

        internal static void ValorizarEntidad(FamiliaBE pFamilia, DataRow mDataRow)
        {
            pFamilia.ID_Compuesto = int.Parse(mDataRow["ID_Familia"].ToString());
            pFamilia.Nombre = mDataRow["Nombre"].ToString();
            pFamilia.Descripcion = mDataRow["Descripcion"].ToString();
        }
    }
}
