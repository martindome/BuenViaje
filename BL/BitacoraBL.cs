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
            if (pBitacora.Nombre_Usuario != "*")
            {
                //pUsuario.Nombre_Usuario = pBitacora.Nombre_Usuario;
                pBitacora.ID_Usuario = pUsuario.Obtener(pBitacora.Nombre_Usuario).ID_Usuario;
            }
            if (pBitacora.Tipo_Evento == "*")
            {
                pBitacora.Tipo_Evento = "*";
            }
            List<BitacoraBE> Registros = new List<BitacoraBE>();
            List<BitacoraBE> RegistrosTemp = BitacoraDAL.Listar(pBitacora);
            foreach (BitacoraBE mRegistro in RegistrosTemp)
            {
                bool Flag = true;
                if (pBitacora.Nombre_Usuario != "*")
                {
                    if (mRegistro.Nombre_Usuario != pBitacora.Nombre_Usuario)
                    {
                        Flag = false;
                    }
                }
                if (pBitacora.Tipo_Evento != "*")
                {
                    if (mRegistro.Tipo_Evento != pBitacora.Tipo_Evento)
                    {
                        Flag = false;
                    }
                }
                if (mRegistro.Fecha > Hasta || mRegistro.Fecha < Desde) 
                {
                    Flag = false;
                }
                if (Flag == true)
                {
                    Registros.Add(mRegistro);
                }
            }
            return Registros;
        }

        static public List<string> ListarUsuarios()
        {
            return DAL.BitacoraDAL.ListarUsuarios();
        }
    }
}
