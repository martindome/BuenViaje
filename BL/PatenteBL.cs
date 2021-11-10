using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BE;
using BE.Composite;

namespace BL
{
    public class PatenteBL
    {
        public PatenteBE Obtener(int pID)
        {
            return PatenteDAL.Obtener(pID);
        }

        public List<PatenteBE> Listar()
        {
            return PatenteDAL.Listar();
        }

        public void GuardarFamiliaUsuario(PatenteBE patente, UsuarioBE usuario)
        {
            PatenteDAL.GuardarPatenteUsuario(patente, usuario);
        }

        public void EliminarFamiliaUsuario(PatenteBE patente, UsuarioBE usuario)
        {
            PatenteDAL.BorrarPatenteUsuario(patente, usuario);
        }

        public bool PermisoAsignado(PatenteBE permiso)
        {
            FamiliaBL familiabl = new FamiliaBL();
            UsuarioBL usuariobl = new UsuarioBL();
            PatenteBL patentebl = new PatenteBL();
            List<PatenteBE> patentes = patentebl.Listar();
            List<FamiliaBE> familias = new FamiliaBL().Listar();
            List<UsuarioBE> usuarios = usuariobl.Listar();
            bool TodasPatentes = true;
            bool Familia = false;
            //Chequeo que la patente este asignada a una familia
            foreach (FamiliaBE familia in familias)
            {
                List<PatenteBE> permisos = familiabl.ListarPatentes(familia);
                foreach (PatenteBE p in permisos)
                {
                    if (p.Tipo == permiso.Tipo)
                    {
                        Familia = true;
                        break;
                    }
                }
                if (Familia)
                {
                    break;
                }
            }
            //Chequeo que la patente este asignada a algun usuario
            bool Usuario = false;
            if (!Familia)
            {
                foreach (UsuarioBE usuario in usuarios)
                {
                    List<CompuestoBE> permisos = usuariobl.ObtenerPermisos(usuario);
                    foreach (CompuestoBE p in permisos)
                    {
                        if (p is PatenteBE && ((PatenteBE)p).Tipo == permiso.Tipo)
                        {
                            Usuario = true;
                            break;
                        }
                    }
                    if (Usuario)
                    {
                        break;
                    }
                }
            }
            TodasPatentes = TodasPatentes && (Familia || Usuario);
            if (TodasPatentes == false)
            {
                return false;
            }
            return TodasPatentes;
        }

    }
}
