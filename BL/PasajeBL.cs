using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BE;

namespace BL
{
    public class PasajeBL
    {
        public List<PasajeBE> Listar()
        {
            return PasajeDAL.Listar();
        }

        public List<PasajeBE> ListarCliente(int pId)
        {
            return PasajeDAL.ListarCliente(pId);
        }

        public List<PasajeBE> ListarClienteDevueltos(int pId)
        {
            return PasajeDAL.ListarClienteNoDevueltos(pId);
        }

        public List<PasajeBE> ListarViaje(int pId)
        {
            return PasajeDAL.ListarViaje(pId);
        }

        public List<PasajeBE> ListarViajeDevueltos(int pId)
        {
            return PasajeDAL.ListarViajeDevueltos(pId);
        }

        public PasajeBE Obtener(int pId)
        {
            return PasajeDAL.Obtener(pId);
        }

        public void Vender(PasajeBE pasaje)
        {
            PasajeDAL.Guardar(pasaje);
        }

        public void Devolver(PasajeBE pasaje)
        {
            pasaje.Devuelto = true;
            PasajeDAL.Guardar(pasaje);
        }

        public void Borrar (PasajeBE pasaje)
        {
            PasajeDAL.Borrar(pasaje);
        } 
    }
}