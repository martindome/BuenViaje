using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;

namespace BL
{
    public class RutaBL
    {
        public RutaBL()
        {

        }

        public List<RutaBE> Listar()
        {
            return RutaDAL.Listar();
        }

        public RutaBE Obtener(int pId)
        {
            return RutaDAL.Obtener(pId);
        }

        public void Guardar(RutaBE pRuta)
        {
            RutaDAL.Guardar(pRuta);
        }

        public void Eliminar(RutaBE pRuta)
        {
            RutaDAL.Eliminar(pRuta);
        }

    }
}
