using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using BE.Composite;

namespace BL
{
    public class Sesion
    {
        private UsuarioBE usuario { get; set; }

        public UsuarioBE Usuario
        {
            get
            {
                return this.usuario;
            }
        }

        public void Login(UsuarioBE pUsuario)
        {
            this.usuario = pUsuario;
            UsuarioBL usuarioBl = new UsuarioBL();
            this.usuario.Permisos = usuarioBl.ObtenerPermisos(this.usuario);
        }

        public void Logout()
        {
            BitacoraBE mBitacora = new BitacoraBE();
            BitacoraBL bitacoraBL = new BitacoraBL();
            mBitacora.Descripcion = "Usuario cerro sesion";
            mBitacora.Tipo_Evento = "LOW";
            mBitacora.Fecha = DateTime.Now;
            mBitacora.Nombre_Usuario = this.usuario.Nombre_Usuario;
            bitacoraBL.Guardar(mBitacora);

            this.usuario = null;
        }

        public bool EstaLogueado()
        {
            return this.usuario != null;
        }

        public bool VerificarPermiso(TipoPermiso permiso)
        {
            if (usuario == null)
            {
                return false;
            }
            UsuarioBL usuarioBl = new UsuarioBL();
            this.usuario.Permisos = usuarioBl.ObtenerPermisos(this.usuario);

            bool valido = false;
            foreach (var p in this.usuario.Permisos)
            {
                if (p is PatenteBE && ((PatenteBE)p).Tipo.Equals(permiso))
                {
                    valido = true;
                }
                else
                {
                    valido = VerificarPermiso(p, permiso, valido);
                }
            }
            return valido;
        }

        public bool VerificarPermiso(CompuestoBE p, TipoPermiso permiso, bool valido)
        {
            foreach (var item in p.ObtenerHijos())
            {
                if (item is PatenteBE && ((PatenteBE)item).Tipo.Equals(permiso))
                {
                    valido = true;
                }
                else
                {
                    valido = VerificarPermiso(item, permiso, valido);
                }
            }
            return valido;
        }


    }
}
