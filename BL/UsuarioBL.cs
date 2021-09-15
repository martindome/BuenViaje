using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;
using BE.Composite;

namespace BL
{
    public class UsuarioBL
    {
        private UsuarioBE mBE = new UsuarioBE();
        //public int ID_Usuario { get {return mBE.ID_Usuario; } set { mBE.ID_Usuario = value; } }
        //public string Nombre { get { return mBE.Nombre; } set { mBE.Nombre = value; } }
        //public string Apellido { get { return mBE.Apellido; } set { mBE.Apellido = value; } }
        //public string Nombre_Usuario { get { return mBE.Nombre_Usuario; } set { mBE.Nombre_Usuario = value; } }
        //public string Contrasenia { get { return mBE.Contrasenia; } set { mBE.Contrasenia = value; } }
        //public string DVH { get { return mBE.DVH; } set { mBE.DVH = value; } }
        //public int Intentos_Login { get { return mBE.Intentos_Login; } set { mBE.Intentos_Login = value; } }

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
            UsuarioDAL.Actualizar(pUsuario);
        }

        public List<UsuarioBE> Listar()
        {
            return UsuarioDAL.Listar();
        }

        public string ObtenerIdiomaUsuario(UsuarioBE pUsuario)
        {
            return UsuarioDAL.ObtenerIdiomaUsuario(pUsuario);
        }

        public void CambiarContrasenia(UsuarioBE pUsuario, string contraseniaActual, string NuevaContrasenia)
        {
            contraseniaActual = DAL.LoginDAL.CalcularHashMD5(contraseniaActual);
            NuevaContrasenia = DAL.LoginDAL.CalcularHashMD5(NuevaContrasenia);
            if (pUsuario.Contrasenia != contraseniaActual)
            {
                throw new Exception("Clave actual incorrecta");
            }
            if (pUsuario.Contrasenia == NuevaContrasenia)
            {
                throw new Exception("La clave anterior y nueva son iguales");
            }
            BitacoraBE mBitacora = new BitacoraBE();
            BitacoraBL Bitacorabl = new BitacoraBL();
            UsuarioBL Usuariobl = new UsuarioBL();
            pUsuario.Contrasenia = DAL.LoginDAL.CalcularHashMD5(NuevaContrasenia);
            mBitacora.Descripcion = "Cambio de clave satisfactorio";
            mBitacora.Fecha = DateTime.Now;
            mBitacora.ID_Usuario = pUsuario.ID_Usuario;
            mBitacora.Tipo_Evento = "HIGH";
            Bitacorabl.Guardar(mBitacora);
            Usuariobl.Actualizar(pUsuario);
        }

        public List<CompuestoBE> ObtenerPermisos(UsuarioBE pUsuario)
        {
            return UsuarioDAL.ObtenerPermisos(pUsuario);
        }

    }
}
