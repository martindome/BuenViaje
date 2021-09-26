using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;

namespace BL
{
    public class BusBL
    {
        public BusBL()
        {

        }

        public List<BusBE> Listar()
        {
            return BusDAL.Listar();
        }

        public BusBE Obtener(int pId)
        {
            return BusDAL.Obtener(pId);
        }

        public void Guardar(BusBE pBus)
        {
            BusDAL.Guardar(pBus);
        }

        public void Eliminar(BusBE pBus)
        {
            BusDAL.Eliminar(pBus);
        }
    }
}
