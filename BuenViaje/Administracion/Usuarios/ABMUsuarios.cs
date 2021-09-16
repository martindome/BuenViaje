using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuenViaje;
using BuenViaje.Administracion;
using BE;
using BL;

namespace BuenViaje.Administracion.Usuarios
{
    public partial class ABMUsuarios : Form
    {
        internal Operacion operacion;
        internal UsuarioBE usuariobe;
        public ABMUsuarios()
        {
            InitializeComponent();
        }

        private void ABMUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void ABMUsuariosBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMUsuariosBotton1_Click(object sender, EventArgs e)
        {

        }
    }
}
