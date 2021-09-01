using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class DigitoVerificadorVerticalBE
    {
        public int ID_DVV { get; set; }
        public string Tabla { get; set; }
        public string DVV { get; set; }
        public DigitoVerificadorVerticalBE() {}
        public DigitoVerificadorVerticalBE(int pId)
        {
            this.ID_DVV = pId;
        }
    } 
}
