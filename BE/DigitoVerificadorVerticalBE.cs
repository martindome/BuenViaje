using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class DigitoVerificadorVerticalBE
    {
        public int ID_Digito_Verificador { get; set; }
        public string Tabla { get; set; }
        public string DVV { get; set; }
        public DigitoVerificadorVerticalBE() {}
        public DigitoVerificadorVerticalBE(int pId)
        {
            this.ID_Digito_Verificador = pId;
        }
    } 
}
