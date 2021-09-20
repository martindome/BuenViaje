using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE.Composite
{
    public class FamiliaBE: CompuestoBE
    {

        private List<CompuestoBE> Hijos;

        public FamiliaBE()
        {
            Hijos = new List<CompuestoBE>();
        }

        public override void AgregarPermiso(CompuestoBE p)
        {
            if (!Hijos.Contains(p))
            {
                Hijos.Add(p);
            }
        }

        public override List<CompuestoBE> ObtenerHijos()
        {
            return this.Hijos;
        }

        public override void QuitarPermiso(CompuestoBE p)
        {
            if (this.Hijos.Any(item => item.ID_Compuesto == p.ID_Compuesto && item.Nombre == p.Nombre))
            {
                List<CompuestoBE> aux = new List<CompuestoBE>();
                foreach(CompuestoBE comp in this.ObtenerHijos())
                {
                    if (comp.ID_Compuesto != p.ID_Compuesto)
                    {
                        aux.Add(comp);
                    }
                }
                this.Hijos = aux;
            }
        }



    }
}
