﻿using System;
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
            ClienteDAL.Eliminar(pCliente);
        }
    }
}