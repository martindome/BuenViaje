using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class PasajeBE
    {
        public int ID_Pasaje { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Viaje { get; set; }
        public int ID_Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public bool Devuelto { get; set; }
    }
}
