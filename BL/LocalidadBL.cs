using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BE;

namespace BL
{
    public class LocalidadBL
    {

        public LocalidadBL()
        {

        }

        public List<LocalidadBE> Listar()
        {
            return LocalidadDAL.Listar();

        }

        public void Guardar(LocalidadBE pLocalidad)
        {
            LocalidadDAL.Guardar(pLocalidad);
        }

        public void Eliminar(LocalidadBE pLocalidad)
        {
            RutaBL rutabl = new RutaBL();
            foreach (RutaBE ruta  in rutabl.Listar())
            {
                if (ruta.Destino.ID_Localidad == pLocalidad.ID_Localidad || ruta.Origen.ID_Localidad == pLocalidad.ID_Localidad)
                {
                    throw new Exception(IdiomaBL.ObtenerMensajeTextos("LocalidadEnUso", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
                }
            }
            LocalidadDAL.Eliminar(pLocalidad);
        }

        public LocalidadBE Obtener (int pId)
        {
            return LocalidadDAL.Obtener(pId);
        }
    }
}
