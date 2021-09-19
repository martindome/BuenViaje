using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using BE.Composite;
using DAL;
using BE.Composite;
using SERV;

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
            List<CompuestoBE> permisosViejos = this.ObtenerPermisos(pUsuario);
            UsuarioDAL.Guardar(pUsuario);
            foreach (CompuestoBE permiso in pUsuario.Permisos)
            {
                bool flag = false;
                foreach (CompuestoBE permisoViejo in permisosViejos)
                {
                    if (permiso is PatenteBE && permisoViejo is PatenteBE && permisoViejo.ID_Compuesto == permiso.ID_Compuesto)
                    {
                        flag = true;  
                    }
                    else if (permiso is FamiliaBE && permisoViejo is FamiliaBE && permisoViejo.ID_Compuesto == permiso.ID_Compuesto)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    if (permiso is PatenteBE)
                    {
                        PatenteDAL.GuardarPatenteUsuario((PatenteBE)permiso, pUsuario);
                    }
                    else if (permiso is FamiliaBE)
                    {
                        FamiliaDAL.GuardarFamiliaUsuario((FamiliaBE)permiso, pUsuario);
                    }
                }
            }
            foreach (CompuestoBE permisoViejo in permisosViejos)
            {
                bool flag = false;
                foreach (CompuestoBE permiso in pUsuario.Permisos)
                {
                    if (permiso is PatenteBE && permisoViejo is PatenteBE && permisoViejo.ID_Compuesto == permiso.ID_Compuesto)
                    {
                        flag = true;
                    }
                    else if (permiso is FamiliaBE && permisoViejo is FamiliaBE && permisoViejo.ID_Compuesto == permiso.ID_Compuesto)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    if (permisoViejo is PatenteBE)
                    {
                        PatenteDAL.BorrarPatenteUsuario((PatenteBE)permisoViejo, pUsuario);
                    }
                    else if (permisoViejo is FamiliaBE)
                    {
                        FamiliaDAL.BorrarFamiliaUsuario((FamiliaBE)permisoViejo, pUsuario);
                    }
                }
            }
        }

        public void Eliminar(UsuarioBE pUsuario)
        {
            foreach (CompuestoBE permiso in pUsuario.Permisos)
            {
                if (permiso is PatenteBE)
                {
                    PatenteDAL.BorrarPatenteUsuario((PatenteBE)permiso, pUsuario);
                }
                else if (permiso is FamiliaBE)
                {
                    FamiliaDAL.BorrarFamiliaUsuario((FamiliaBE)permiso, pUsuario);
                }
            }
            UsuarioDAL.Eliminar(pUsuario);
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

        public void ResetarConstrasenia(UsuarioBE pUsuario)
        {
            string newPassword = UsuarioDAL.ResetearConstrasenia(pUsuario);
        }
        public List<CompuestoBE> ObtenerPermisos(UsuarioBE pUsuario)
        {
            return UsuarioDAL.ObtenerPermisos(pUsuario);
        }

        public List<CompuestoBE> ObtenerPatentes(UsuarioBE usuario)
        {
            return UsuarioDAL.ListarPatentes(usuario);
        }

        public List<CompuestoBE> ObtenerFamilias(UsuarioBE usuario)
        {
            return UsuarioDAL.ListarFamilias(usuario);
        }
    }
}
