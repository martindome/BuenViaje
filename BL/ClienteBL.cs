using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;

namespace BL
{
    public class ClienteBL
    {

        public ClienteBL()
        {

        }

        public List<ClienteBE> Listar()
        {
            return ClienteDAL.Listar();
        }

        public ClienteBE Obtener(int pId)
        {
            return ClienteDAL.Obtener(pId);
        }

        public void Guardar(ClienteBE pCliente)
        {
            ClienteDAL.Guardar(pCliente);
        }

        public void Eliminar(ClienteBE pCliente)
        {
            PasajeBL pasajebl = new PasajeBL();
            foreach (PasajeBE pasaje in pasajebl.ListarCliente(pCliente.ID_Cliente))
            {
                pasajebl.Borrar(pasaje);
            }
            ClienteDAL.Eliminar(pCliente);
        }
    }
}
