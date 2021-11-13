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
            ViajeBL viajebl = new ViajeBL();
            DateTime Desde = DateTime.Today.Date + DateTime.Today.TimeOfDay;
            DateTime Hasta = Desde.AddYears(100);
            foreach (ViajeBE viaje in viajebl.Listar(Desde, Hasta))
            {
                if (viaje.ID_Ruta == pRuta.ID_Ruta && !viaje.Cancelado)
                {
                    throw new Exception(IdiomaBL.ObtenerMensajeTextos("RutaEnUso", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
                }
            }
            RutaDAL.Eliminar(pRuta);
        }

    }
}
