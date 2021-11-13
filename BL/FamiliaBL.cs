using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BE;
using BE.Composite;


namespace BL
{
    public class FamiliaBL
    {
        public FamiliaBE Obtener(int pID)
        {
            return FamiliaDAL.Obtener(pID);
        }

        public List<FamiliaBE> Listar()
        {
            return FamiliaDAL.Listar();
        }

        public void Guardar(FamiliaBE pFamilia)
        {
            UsuarioBL usuarioBl = new UsuarioBL();
            PatenteBL patentebl = new PatenteBL();
            UsuarioBL usuariobl = new UsuarioBL();
            List<UsuarioBE> usuarios = usuarioBl.Listar();
            List<PatenteBE> patentes = patentebl.Listar();
            List<CompuestoBE> patentesFamiliaActuales = pFamilia.ObtenerHijos();
            List<PatenteBE> patentesFamiliaViejas = this.ListarPatentes(pFamilia);

            List<PatenteBE> patentesFamiliaBorradas = new List<PatenteBE>();
            foreach (PatenteBE patenteVieja in patentesFamiliaViejas)
            {
                bool flag = false;
                foreach (PatenteBE patenteNueva in patentesFamiliaActuales)
                {
                    if (patenteVieja.ID_Compuesto == patenteNueva.ID_Compuesto)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    patentesFamiliaBorradas.Add(patenteVieja);
                }
            }

            //Todas las patentes de la familia que son borradas deben estar asignadas a usuarios por otras familias / asignaciones
            bool TodasPatentesFlag = true;
            foreach (PatenteBE patente in patentesFamiliaBorradas)
            {
                bool PatenteFlag = false;
                foreach (UsuarioBE user in UsuarioDAL.Listar())
                {
                    //Familias
                    foreach (FamiliaBE familia in usuariobl.ObtenerFamilias(user))
                    {
                        if (familia.ID_Compuesto != pFamilia.ID_Compuesto)
                        {
                            foreach (CompuestoBE permiso in this.ListarPatentes(familia))
                            {
                                if (permiso is PatenteBE && ((PatenteBE)permiso).Tipo == patente.Tipo)
                                {
                                    PatenteFlag = true;
                                    break;
                                }
                            }
                            if (PatenteFlag)
                            {
                                break;
                            }
                        }
                    }
                    if (PatenteFlag)
                    {
                        break;
                    }
                    //Patentes
                    foreach (CompuestoBE permiso in usuariobl.ObtenerPatentes(user))
                    {
                        if (permiso is PatenteBE && ((PatenteBE)permiso).Tipo == patente.Tipo)
                        {
                            PatenteFlag = true;
                            break;
                        }
                    }
                    if (PatenteFlag)
                    {
                        break;
                    }
                }
                TodasPatentesFlag = TodasPatentesFlag && PatenteFlag;
                if (!TodasPatentesFlag)
                {
                    throw new Exception(IdiomaBL.ObtenerMensajeTextos("No todas las patentes estan asignadas a un usuario", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
                }
            }

            FamiliaDAL.Guardar(pFamilia);
            List<PatenteBE> permisosViejos = this.ListarPatentes(pFamilia);
            foreach (PatenteBE patente in pFamilia.ObtenerHijos())
            {
                bool flag = false;
                foreach (PatenteBE patenteVieja in permisosViejos)
                {
                    if (patenteVieja.ID_Compuesto == patente.ID_Compuesto)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    GuardarFamiliaPermiso(pFamilia, patente);
                }
            }
            foreach (PatenteBE permisoViejo in permisosViejos)
            {
                bool flag = false;
                foreach (PatenteBE patente in pFamilia.ObtenerHijos())
                {
                    if (patente.ID_Compuesto == permisoViejo.ID_Compuesto)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    EliminarFamiliaPermiso(pFamilia, permisoViejo);
                }
            }
            
        }

        public void Eliminar (FamiliaBE familia)
        {
            UsuarioBL usuarioBl = new UsuarioBL();
            PatenteBL patentebl = new PatenteBL();
            UsuarioBL usuariobl = new UsuarioBL();
            List<UsuarioBE> usuarios = usuarioBl.Listar();
            List<PatenteBE> patentesFamilia = this.ListarPatentes(familia);
            List<PatenteBE> patentes = patentebl.Listar();

            //Todas las patentes de la familia deben estar asignadas a usuarios por otras familias / asignaciones
            bool TodasPatentesFlag = true;
            foreach (PatenteBE patente in patentesFamilia)
            {
                bool PatenteFlag = false;
                foreach (UsuarioBE user in UsuarioDAL.Listar())
                {
                    foreach (CompuestoBE permiso in usuariobl.ObtenerPermisos(user))
                    {
                        if (permiso is PatenteBE && ((PatenteBE)permiso).Tipo == patente.Tipo)
                        {
                            PatenteFlag = true;
                            break;
                        }
                    }
                    if (PatenteFlag)
                    {
                        break;
                    }
                }
                TodasPatentesFlag = TodasPatentesFlag && PatenteFlag;
                if (!TodasPatentesFlag)
                {
                    throw new Exception(IdiomaBL.ObtenerMensajeTextos("No todas las patentes estan asignadas a un usuario", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
                }
            }
            //No se pueden eliminar familias con usuarios asignados
            //foreach (UsuarioBE usuario in usuarios)
            //{
            //    List<CompuestoBE> familias = usuarioBl.ObtenerFamilias(usuario);
            //    if (familias.Any(item => item.ID_Compuesto == familia.ID_Compuesto))
            //    {
            //        throw new Exception("Hay usuarios asignados a la familia");
            //    }
            //}
            foreach (PatenteBE patente in familia.ObtenerHijos())
            {
                EliminarFamiliaPermiso(familia, patente);
            }
            FamiliaDAL.Eliminar(familia);
        }

        public void GuardarFamiliaUsuario(FamiliaBE familia, UsuarioBE usuario)
        {
            FamiliaDAL.GuardarFamiliaUsuario(familia, usuario);
        }

        public void EliminarFamiliaUsuario(FamiliaBE familia, UsuarioBE usuario)
        {
            FamiliaDAL.BorrarFamiliaUsuario(familia, usuario);
        }

        public void GuardarFamiliaPermiso(FamiliaBE familia, PatenteBE patente)
        {
            FamiliaDAL.GuardarFamiliaPatente(familia, patente);
        }

        public void EliminarFamiliaPermiso(FamiliaBE familia, PatenteBE patente)
        {
            FamiliaDAL.BorrarFamiliaPatente(familia, patente);
        }

        public List<PatenteBE> ListarPatentes(FamiliaBE pFamilia)
        {
            return FamiliaDAL.ListarPatentes(pFamilia);
        }

    }
}
