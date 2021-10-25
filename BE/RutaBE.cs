using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class RutaBE
    {
        public int ID_Ruta { get; set; }
        public LocalidadBE Origen { get; set; }
        public LocalidadBE Destino { get; set; }
        public int Duracion { get; set; }


        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                RutaBE ruta = (RutaBE)obj;
                return (this.Origen.Nombre == ruta.Origen.Nombre && this.Origen.Provincia == ruta.Origen.Provincia && this.Origen.Pais == ruta.Origen.Pais && this.Destino.Nombre == ruta.Destino.Nombre && this.Destino.Provincia == ruta.Destino.Provincia && this.Destino.Pais == ruta.Destino.Pais);
            }
        }
    }
}
