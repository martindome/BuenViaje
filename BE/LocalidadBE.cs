using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class LocalidadBE
    {
        public int ID_Localidad { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }

        public LocalidadBE()
        {

        }

        public LocalidadBE (int pId)
        {
            ID_Localidad = pId;
        }
        
        public override string ToString()
        {
            return this.Nombre + "-" + this.Provincia + "-" + this.Pais;
        }
    }
}
