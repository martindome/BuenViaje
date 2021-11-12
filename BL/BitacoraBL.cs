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

        public List<BitacoraBE> Listar(DateTime Desde, DateTime Hasta)
        {
            //UsuarioBL pUsuario = new UsuarioBL();
            //if (pBitacora.Nombre_Usuario != "*")
            //{
            //    //pUsuario.Nombre_Usuario = pBitacora.Nombre_Usuario;
            //    pBitacora.Nombre_Usuario = pUsuario.Obtener(pBitacora.Nombre_Usuario).Nombre_Usuario;
            //}
            //if (pBitacora.Tipo_Evento == "*")
            //{
            //    pBitacora.Tipo_Evento = "*";
            //}
            //List<BitacoraBE> Registros = new List<BitacoraBE>();
            //List<BitacoraBE> RegistrosTemp = BitacoraDAL.Listar(pBitacora);
            //foreach (BitacoraBE mRegistro in RegistrosTemp)
            //{
            //    bool Flag = true;
            //    if (pBitacora.Nombre_Usuario != "*")
            //    {
            //        if (mRegistro.Nombre_Usuario != pBitacora.Nombre_Usuario)
            //        {
            //            Flag = false;
            //        }
            //    }
            //    if (pBitacora.Tipo_Evento != "*")
            //    {
            //        if (mRegistro.Tipo_Evento != pBitacora.Tipo_Evento)
            //        {
            //            Flag = false;
            //        }
            //    }
            //    if (mRegistro.Fecha > Hasta || mRegistro.Fecha < Desde) 
            //    {
            //        Flag = false;
            //    }
            //    if (Flag == true)
            //    {
            //        Registros.Add(mRegistro);
            //    }
            //}
            //return Registros;

            //List<BitacoraBE> lista = new List<BitacoraBE>();

            //foreach (BitacoraBE bitacora in BitacoraDAL.Listar(Desde, Hasta))
            //{
            //    if (bitacora.Fecha > Desde && bitacora.Fecha < Hasta)
            //    {
            //        lista.Add(bitacora);
            //    }
            //}
            //return lista;
            return BitacoraDAL.Listar(Desde, Hasta);
        }

        static public List<string> ListarUsuarios()
        {
            return DAL.BitacoraDAL.ListarUsuarios();
        }
    }
}
