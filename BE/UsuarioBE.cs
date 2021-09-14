using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE.Composite;

namespace BE
{
    public class UsuarioBE
    {
        public int ID_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string DVH { get; set; }
        public int Intentos_Login { get; set; }
        public int ID_Idioma { get; set; }
        public string Idioma_Descripcion { get; set; }
        public List<CompuestoBE> Permisos {get; set;}



        public UsuarioBE()
        {
            Permisos = new List<CompuestoBE>();
        }
        public UsuarioBE(int pId)
        {
            ID_Usuario = pId;
            Permisos = new List<CompuestoBE>();
        }

    }
}
