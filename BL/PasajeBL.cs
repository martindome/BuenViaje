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

        public PasajeBE Obtener(int pId)
        {
            return PasajeDAL.Obtener(pId);
        }

        public void Guardar(PasajeBE pasaje)
        {
            PasajeDAL.Guardar(pasaje);
        }

        public void Borrar (PasajeBE pasaje)
        {
            PasajeDAL.Borrar(pasaje);
        } 
    }
}