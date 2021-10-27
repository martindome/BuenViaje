using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class ViajeBE
    {
        public int ID_Viaje { get; set; }
        public int ID_Ruta { get; set; }
        public int ID_Bus { get; set; }
        public DateTime Fecha { get; set; }
        public bool Cancelado { get; set; }
    }
}
