using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;

namespace BL
{
    public class UsuarioBL
    {
        private UsuarioBE mBE = new UsuarioBE();
        public int ID_Usuario { get {return mBE.ID_Usuario; } set { mBE.ID_Usuario = value; } }
        public string Nombre { get { return mBE.Nombre; } set { mBE.Nombre = value; } }
        public string Apellido { get { return mBE.Apellido; } set { mBE.Apellido = value; } }
        public string Nombre_Usuario { get { return mBE.Nombre_Usuario; } set { mBE.Nombre_Usuario = value; } }
        public string Contrasenia { get { return mBE.Contrasenia; } set { mBE.Contrasenia = value; } }
        public string DVH { get { return mBE.DVH; } set { mBE.DVH = value; } }
        public int Intentos_Login { get { return mBE.Intentos_Login; } set { mBE.Intentos_Login = value; } }

        public UsuarioBE Obtener(string pNombreUsuario)
        {
            //this.user = pUsuario.user;
            return (UsuarioBE)UsuarioDAL.Obtener(pNombreUsuario);
        }

        public void Guardar(UsuarioBE pUsuario)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(UsuarioBE pUsuario)
        {
            throw new NotImplementedException();
        }

        public string ObtenerIdiomaUsuario(UsuarioBE pUsuario)
        {
            return UsuarioDAL.ObtenerIdiomaUsuario(pUsuario);
        }

    }
}
