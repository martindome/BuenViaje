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
            ViajeBL viajebl = new ViajeBL();
            DateTime Desde = DateTime.Today.Date + DateTime.Today.TimeOfDay;
            DateTime Hasta = Desde.AddYears(100);
            foreach (ViajeBE viaje in viajebl.Listar(Desde, Hasta))
            {
                if (viaje.ID_Bus == pBus.ID_Bus && !viaje.Cancelado)
                {
                    throw new Exception(IdiomaBL.ObtenerMensajeTextos("BusEnUso", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
                }
            }
            BusDAL.Eliminar(pBus);
        }
    }
}
