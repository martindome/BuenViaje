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

        public void Guardar(FamiliaBE familia)
        {
            FamiliaDAL.Guardar(familia);
            List<PatenteBE> permisosViejos = this.ListarPatentes(familia);
            foreach (PatenteBE patente in familia.ObtenerHijos())
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
                    GuardarFamiliaPermiso(familia, patente);
                }
            }
            foreach (PatenteBE permisoViejo in permisosViejos)
            {
                bool flag = false;
                foreach (PatenteBE patente in familia.ObtenerHijos())
                {
                    if (patente.ID_Compuesto == permisoViejo.ID_Compuesto)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    EliminarFamiliaPermiso(familia, permisoViejo);
                }
            }
        }

        public void Eliminar (FamiliaBE familia)
        {
            UsuarioBL usuarioBl = new UsuarioBL();
            List<UsuarioBE> usuarios = usuarioBl.Listar();
            foreach (UsuarioBE usuario in usuarios)
            {
                List<CompuestoBE> familias = usuarioBl.ObtenerFamilias(usuario);
                if (familias.Any(item => item.ID_Compuesto == familia.ID_Compuesto))
                {
                    throw new Exception("Hay usuarios asignados a la familia");
                }
            }
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
