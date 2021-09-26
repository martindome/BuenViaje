using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BE;

namespace BL
{
    public class LocalidadBL
    {

        public LocalidadBL()
        {

        }

        public List<LocalidadBE> Listar()
        {
            return LocalidadDAL.Listar();

        }

        public void Guardar(LocalidadBE pLocalidad)
        {
            LocalidadDAL.Guardar(pLocalidad);
        }

        public void Eliminar(LocalidadBE pLocalidad)
        {
            LocalidadDAL.Eliminar(pLocalidad);
        }

        public LocalidadBE Obtener (int pId)
        {
            return LocalidadDAL.Obtener(pId);
        }
    }
}
