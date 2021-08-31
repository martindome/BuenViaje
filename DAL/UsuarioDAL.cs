using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class UsuarioDAL
    {

        public static List<UsuarioBE> Listar()
        {
            List<UsuarioBE> ListaUsuarios = new List<UsuarioBE>();

            string mCommandText = "Select u.ID_Usuario, u.Nombre, u.Apellido, u.Nombre_Usuario, u.Contraseña, u.Intentos_Login FROM Usuarios u";
            DAO mDao = new DAO();

            DataSet mDataSet = mDao.ExecuteDataSet(mCommandText);


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

        private static void ValorizarEntidad(UsuarioBE pUsuario, DataRow pDataRow)
        {
            pUsuario.Nombre = pDataRow["Nombre"].ToString();
            pUsuario.Apellido = pDataRow["Apellido"].ToString();
            pUsuario.Nombre_Usuario = (pDataRow["Nombre_Usuario"].ToString());
            pUsuario.Contrasenia = (pDataRow["Contraseña"].ToString());
            pUsuario.Intentos_Login = int.Parse((pDataRow["Intentos_Login"].ToString()));
        }

    }
}
