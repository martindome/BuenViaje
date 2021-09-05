using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using SERV;
using System.Data;
using System.Data.SqlClient;

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

            string mCommandText = "Select u.ID_Usuario, u.Nombre, u.Apellido, u.Nombre_Usuario, u.Contraseña, u.Intentos_Login, u.ID_Idioma, i.Descripcion FROM Usuarios u INNER JOIN Idioma i ON u.ID_Idioma=i.ID_Idioma";

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
            string mCommandText = "Select u.ID_Usuario, u.Nombre, u.Apellido, u.Nombre_Usuario, u.Contraseña, u.Intentos_Login, u.ID_Idioma, i.Descripcion FROM Usuarios u INNER JOIN Idioma i ON u.ID_Idioma=i.ID_Idioma WHERE u.Nombre_Usuario = " + nombre_usuario;
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
            if (pUsuario.ID_Usuario == 0)
            {
                pUsuario.ID_Usuario = ProximoId();
                string DVH = mIntegridad.CalcularDVH(pUsuario.ID_Usuario.ToString() + pUsuario.Nombre + pUsuario.Apellido + pUsuario.Nombre_Usuario + pUsuario.Contrasenia + pUsuario.Intentos_Login.ToString());
                string mCommand = "INSERT INTO Usuario(ID_Usuario, Nombre, Apellido, Nombre_Usuario, Contraseña, Intentos_Login, DVH) VALUES (" +pUsuario.ID_Usuario + ", '" + pUsuario.Nombre + "', '" + pUsuario.Apellido + "', '" + pUsuario.Nombre_Usuario + "', '" + pUsuario.Contrasenia + "', " +pUsuario.Intentos_Login +", '" + DVH + "')";
                int value = DAO.GetInstance().ExecuteNonQuery(mCommand);
                ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario"), "Usuario");
                return value;
            }
            else
            {
                string DVH = mIntegridad.CalcularDVH(pUsuario.ID_Usuario.ToString() + pUsuario.Nombre + pUsuario.Apellido + pUsuario.Nombre_Usuario + pUsuario.Contrasenia + pUsuario.Intentos_Login.ToString());
                string mCommand = "Update Usuario SET Nombre = '" + pUsuario.Nombre
                    + "', Apellido = '" + pUsuario.Apellido
                    + "', Nombre_Usuario = '" + pUsuario.Nombre_Usuario
                    + "', Contraseña = '" + pUsuario.Contrasenia
                    + "', Intentos_Login = " + pUsuario.Intentos_Login
                    + ", DVH = '" + DVH + "', WHERE ID_Usuario =" + pUsuario.ID_Usuario;
                int value = DAO.GetInstance().ExecuteNonQuery(mCommand);
                ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario"), "Usuario");
                return value;
            }
        }
        public static int Eliminar (UsuarioBE pUsuario)
        {
            string mCommandText = "DELETE Usuario WHERE ID_Usuario = " + pUsuario.ID_Usuario;
            int value = DAO.GetInstance().ExecuteNonQuery(mCommandText);
            ServDAL.GuardarDigitoVerificador(ServDAL.ObtenerDVHs("Usuario"), "Usuario");
            return value;
        }

        #region private functions
        private static void ValorizarEntidad(UsuarioBE pUsuario, DataRow pDataRow)
        {
            pUsuario.ID_Usuario = int.Parse(pDataRow["ID_Usuario"].ToString());
            pUsuario.Nombre = pDataRow["Nombre"].ToString();
            pUsuario.Apellido = pDataRow["Apellido"].ToString();
            pUsuario.Nombre_Usuario = SERV.Seguridad.Cifrado.Descifrar((pDataRow["Nombre_Usuario"].ToString()));
            pUsuario.Contrasenia = (pDataRow["Contraseña"].ToString());
            pUsuario.Intentos_Login = int.Parse((pDataRow["Intentos_Login"].ToString()));
            pUsuario.ID_Idioma = int.Parse(pDataRow["ID_Idioma"].ToString());
            pUsuario.Idioma_Descripcion = pDataRow["Descripcion"].ToString();
        }
        #endregion
    }
}
