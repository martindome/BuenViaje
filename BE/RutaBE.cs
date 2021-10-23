using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class RutaBE
    {
        public int ID_Ruta { get; set; }
        public string Nombre { get; set; }
        public LocalidadBE Origen { get; set; }
        public LocalidadBE Destino { get; set; }
        public int Duracion { get; set; }

    }
}
