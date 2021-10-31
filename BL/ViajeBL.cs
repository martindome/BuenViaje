using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;

namespace BL
{
    public class ViajeBL
    {
        public List<ViajeBE> Listar()
        {
            return ViajeDAL.Listar();
        }

        public List<ViajeBE> Listar(DateTime Desde, DateTime Hasta)
        {
            List<ViajeBE> lista = new List<ViajeBE>();

            foreach (ViajeBE viaje in ViajeDAL.Listar())
            {
                if (viaje.Fecha > Desde && viaje.Fecha < Hasta)
                {
                    lista.Add(viaje);
                }
            }
            return lista;
        }
        public List<ViajeBE> ListarBus(int pId)
        {
            return ViajeDAL.ListarBus(pId);
        }


        public ViajeBE Obtener(int pId)
        {
            return ViajeDAL.Obtener(pId);
        }

        public void Guardar(ViajeBE pViaje)
        {
            ViajeDAL.Guardar(pViaje);
        }

        public void Borrar(ViajeBE pViaje)
        {
            ViajeDAL.Borrar(pViaje);
        }
    }
}
