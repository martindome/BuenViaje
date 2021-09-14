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
            if (this.Hijos.Contains(p))
            {
                this.Hijos.Remove(p);
            }
        }



    }
}
