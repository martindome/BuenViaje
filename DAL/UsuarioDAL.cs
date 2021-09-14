using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using SERV;
using System.Data;
using System.Data.SqlClient;
using BE.Composite;

namespace DAL
{
    public class UsuarioDAL
    {
        static int mId;
        static SERV.Seguridad.Cifrado mCifra = new SERV.Seguridad.Cifrado();
        static SERV.Integridad mIntegridad = new SERV.Integridad();

        public static List<UsuarioBE> Listar()
        {
            List<UsuarioBE> ListaUsuarios = new List<UsuarioBE>();

            string mCommandText = "Select u.ID_Usuario, u.Nombre, u.Apellido, u.Nombre_Usuario, u.Contrasenia, u.Intentos_Login, u.ID_Idioma, i.Descripcion FROM Usuarios u INNER JOIN Idioma i ON u.ID_Idioma=i.ID_Idioma";

            DataSet mDataSet = DAO.GetInstance().ExecuteDataSet(mCommandText);


            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow mDataRow in mDataSet.Tables[0].Rows)
                {
                    UsuarioBE pUsuario = new UsuarioBE(int.Parse(mDataRow["ID_Usuario"].ToString()));
                    ValorizarEntidad(pUsuario, mDataRow);
                    ListaUsuarios.Add(pUsuario);
                }
            }
            return ListaUsuarios;

        }
        private static int ProximoId()
        {
            if (mId == 0)
                mId = (DAO.GetInstance()).ObtenerUltimoId("Usuario");
            mId += 1;
            return mId;
        }
        public static UsuarioBE Obtener(string pNombreUsuario)
        {
            string nombre_usuario = SERV.Seguridad.Cifrado.Cifrar(pNombreUsuario);
            string mCommandText = "Select u.ID_Usuario, u.Nombre, u.Apellido, u.Nombre_Usuario, u.Contrasenia, u.Intentos_Login, u.ID_Idioma, i.Descripcion FROM Usuario u INNER JOIN Idioma i ON u.ID_Idioma=i.ID_Idioma WHERE u.Nombre_Usuario = '" + nombre_usuario + "'";
            DataSet mDataSet = DAO.GetInstance().ExecuteDataSet(mCommandText);

            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                UsuarioBE mUsuario = new UsuarioBE();
                ValorizarEntidad(mUsuario, mDataSet.Tables[0].Rows[0]);
                return mUsuario;
            }
            else
            {
                return null;
            }
        }
        public static int Guardar(UsuarioBE pUsuario)
        {
            string mCommand = "";
            string Nombre_Usuario = SERV.Seguridad.Cifrado.Cifrar(pUsuario.Nombre_Usuario);
            string DVH = mIntegridad.CalcularDVH(pUsuario.ID_Usuario.ToString() + pUsuario.Nombre + pUsuario.Apellido + pUsuario.Nombre_Usuario + pUsuario.Contrasenia + pUsuario.Intentos_Login.ToString());
            if (pUsuario.ID_Usuario == 0)
            {
                pUsuario.ID_Usuario = ProximoId(); 
                mCommand = "INSERT INTO Usuario(ID_Usuario, Nombre, Apellido, Nombre_Usuario, Contrasenia, Intentos_Login, ID_Idioma, DVH) VALUES (" + pUsuario.ID_Usuario + ", '" + pUsuario.Nombre + "', '" + pUsuario.Apellido + "', '" + pUsuario.Nombre_Usuario + "', '" + pUsuario.Contrasenia + "', " + pUsuario.ID_Idioma +", '" + DVH + "')";
                
            }
            else
            { 
                mCommand = "Update Usuario SET Nombre = '" + pUsuario.Nombre
                    + "', Apellido = '" + pUsuario.Apellido
                    + "', Nombre_Usuario = '" + pUsuario.Nombre_Usuario
                    + "', Contrasenia = '" + pUsuario.Contrasenia
                    + "', Intentos_Login = " + pUsuario.Intentos_Login
                    + ", ID_Idioma = " + pUsuario.ID_Idioma
                    + ", DVH = '" + DVH + "', WHERE ID_Usuario =" + pUsuario.ID_Usuario;
            }
            int value = DAO.GetInstance().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario"), "Usuario");
            return value;
        }
        public static void Actualizar(UsuarioBE pUsuario)
        {
            string Nombre_Usuario = SERV.Seguridad.Cifrado.Cifrar(pUsuario.Nombre_Usuario);
            string DVH = mIntegridad.CalcularDVH(pUsuario.ID_Usuario.ToString() + pUsuario.Nombre + pUsuario.Apellido + Nombre_Usuario + pUsuario.Contrasenia + pUsuario.Intentos_Login.ToString() + pUsuario.ID_Idioma.ToString());
            string mCommand = "Update Usuario SET Nombre = '" + pUsuario.Nombre
                + "', Apellido = '" + pUsuario.Apellido
                + "', Nombre_Usuario = '" + Nombre_Usuario
                + "', Contrasenia = '" + pUsuario.Contrasenia
                + "', Intentos_Login = " + pUsuario.Intentos_Login
                + ", ID_Idioma = " + pUsuario.ID_Idioma
                + ", DVH = '" + DVH + "' WHERE ID_Usuario =" + pUsuario.ID_Usuario;
            int value = DAO.GetInstance().ExecuteNonQuery(mCommand);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario"), "Usuario");
        }
        public static List<CompuestoBE> ObtenerPermisos(UsuarioBE pUsuario)
        {
            List<CompuestoBE> familias = UsuarioDAL.ListarFamilias(pUsuario);
            
            foreach (FamiliaBE familia in familias)
            {
                List<PatenteBE> patentes= FamiliaDAL.ListarPatentes(familia);
                foreach (PatenteBE patente in patentes)
                {
                    familia.AgregarPermiso(patente);
                }
            }

            return familias;
        }
        public static int Eliminar (UsuarioBE pUsuario)
        {
            string mCommandText = "DELETE Usuario WHERE ID_Usuario = " + pUsuario.ID_Usuario;
            int value = DAO.GetInstance().ExecuteNonQuery(mCommandText);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario"), "Usuario");
            return value;
        }
        public static string ObtenerIdiomaUsuario(UsuarioBE pUsuario)
        {
            string mCommand = "SELECT i.Descripcion FROM Usuario u INNER JOIN Idioma i on u.ID_Idioma = i.ID_Idioma WHERE u.ID_Idioma = '" + pUsuario.ID_Idioma + "' AND u.ID_Usuario = " + pUsuario.ID_Usuario;
            return DAO.GetInstance().ExecuteScalar(mCommand).ToString();
        }
        public static List<CompuestoBE> ListarFamilias(UsuarioBE pUsuario)
        {
            List<CompuestoBE> familias = new List<CompuestoBE>();
            string mCommand = "SELECT f.ID_Familia, f.Nombre, f.Descripcion, u.ID_Usuario " +
                "FROM Familia AS f " + 
                "INNER JOIN Usuario_Familia AS uf ON uf.ID_Familia = f.ID_Familia " +
                "INNER JOIN Usuario AS u ON uf.ID_Usuario = u.ID_Usuario " + 
                "WHERE u.ID_Usuario = " + pUsuario.ID_Usuario;

            DataSet mDataSet = new DataSet();
            mDataSet = DAO.GetInstance().ExecuteDataSet(mCommand);
            if (mDataSet.Tables.Count > 0 && mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDataRow in mDataSet.Tables[0].Rows)
                {
                    FamiliaBE pFamilia = new FamiliaBE();
                    FamiliaDAL.ValorizarEntidad(pFamilia, mDataRow);
                    familias.Add(pFamilia);
                }
            }

            return familias;
        }
        public static List<PatenteBE> ListarPatentes(UsuarioBE pUsuario)
        {
            List<PatenteBE> patentes = new List<PatenteBE>();
            string mCommand = "SELECT p.ID_Permiso, p.Nombre, p.Descripcion, p.Tipo_Permiso, u.ID_Usuario " +
                "FROM Permiso AS p " +
                "INNER JOIN Usuario_Permiso AS up ON up.ID_Permiso = f.ID_Permiso " +
                "INNER JOIN Usuario AS u ON up.ID_Usuario = u.ID_Usuario " +
                "WHERE u.ID_Usuario = " + pUsuario.ID_Usuario;

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
        #region private functions
        private static void ValorizarEntidad(UsuarioBE pUsuario, DataRow pDataRow)
        {
            pUsuario.ID_Usuario = int.Parse(pDataRow["ID_Usuario"].ToString());
            pUsuario.Nombre = pDataRow["Nombre"].ToString();
            pUsuario.Apellido = pDataRow["Apellido"].ToString();
            pUsuario.Nombre_Usuario = SERV.Seguridad.Cifrado.Descifrar((pDataRow["Nombre_Usuario"].ToString()));
            pUsuario.Contrasenia = (pDataRow["Contrasenia"].ToString());
            pUsuario.Intentos_Login = int.Parse((pDataRow["Intentos_Login"].ToString()));
            pUsuario.ID_Idioma = int.Parse(pDataRow["ID_Idioma"].ToString());
            pUsuario.Idioma_Descripcion = pDataRow["Descripcion"].ToString();
        }
        #endregion
    }
}
