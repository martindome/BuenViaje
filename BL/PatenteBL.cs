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

    }
}
