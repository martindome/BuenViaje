using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;

namespace BL
{
    public class IdiomaBL
    {
        public static List<IdiomaBE> ListarIdiomas()
        {
            List<IdiomaBE> Lista = new List<IdiomaBE>();
            foreach (IdiomaBE mIdioma in IdiomaDAL.Listar())
            {
                Lista.Add(mIdioma);
            }
            return Lista;
        }

        public static IdiomaBE Obtener(int pId)
        {
            return IdiomaDAL.Obtener(pId);
        }

        public static List<ControlBE> ObtenerMensajeControladores(string pIdioma)
        {
            List<ControlBE> Textos = new List<ControlBE>();
            foreach (ControlBE Texto in IdiomaDAL.ObtenerMensajesControladores(pIdioma))
            {
                Textos.Add(Texto);
            }
            return Textos;
        }

        public static string ObtenerMensajeTextos(string Texto, string Idioma)
        {
            return IdiomaDAL.ObtenerMensajesTextos(Texto, Idioma);
        }
    }
}
