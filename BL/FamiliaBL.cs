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
        }

        public void Eliminar (FamiliaBE familia)
        {
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

    }
}
