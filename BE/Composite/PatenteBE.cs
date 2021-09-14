using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE.Composite
{
    public class PatenteBE: CompuestoBE
    {

        public TipoPermiso Tipo { get; set; }

        public override void AgregarPermiso(CompuestoBE p)
        {
            throw new NotImplementedException();
        }

        public override void QuitarPermiso(CompuestoBE p)
        {
            throw new NotImplementedException();
        }

        public override List<CompuestoBE> ObtenerHijos()
        {
            return new List<CompuestoBE>();
        }
    }
}
