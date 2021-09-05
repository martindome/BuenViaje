using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class IdiomaBE
    {
        public int ID_Idioma { get; set; }
        public string Descripcion { get; set; }

        public IdiomaBE()
        {

        }
        public IdiomaBE(int pId)
        {
            ID_Idioma = pId;
        }
    }
}
