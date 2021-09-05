using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BitacoraBE
    {
        public int ID_Bitacora { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo_Evento { get; set; }
        public string Descripcion { get; set; }
        public string DVH { get; set; }
        public int ID_Usuario { get; set; }

        public BitacoraBE() { }
        public BitacoraBE(int pId) { this.ID_Bitacora = pId; }
    }
}
