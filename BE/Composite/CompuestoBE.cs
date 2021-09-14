using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace BE.Composite
{
    public abstract class CompuestoBE
    {

        public string Nombre { get; set; }
        public int ID_Compuesto { get; set; }
        public string Descripcion { get; set; }

        public abstract void AgregarPermiso(CompuestoBE p);

        public abstract void QuitarPermiso(CompuestoBE p);

        public abstract List<CompuestoBE> ObtenerHijos();

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
