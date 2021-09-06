using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BE;

namespace BL
{
    public class BitacoraBL
    {
        public void Guardar(BitacoraBE pBitacora)
        {
            BitacoraDAL.Guardar(pBitacora);
        }

        public List<BitacoraBE> Listar(BitacoraBE pBitacora, DateTime Desde, DateTime Hasta)
        {
            UsuarioBL pUsuario = new UsuarioBL();
            if (pBitacora.Nombre_Usuario != "ALL")
            {
                //pUsuario.Nombre_Usuario = pBitacora.Nombre_Usuario;
                pBitacora.ID_Usuario = pUsuario.Obtener(pBitacora.Nombre_Usuario).ID_Usuario;
            }
            if (pBitacora.Tipo_Evento == "ALL")
            {
                pBitacora.Tipo_Evento = null;
            }
            List<BitacoraBE> Registros = new List<BitacoraBE>();
            foreach (BitacoraBE mRegistro in BitacoraDAL.Listar(pBitacora, Desde, Hasta))
                Registros.Add(mRegistro);
            return Registros;
        }

        static public List<string> ListarUsuarios()
        {
            return DAL.BitacoraDAL.ListarUsuarios();
        }
    }
}
