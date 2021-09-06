using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BE;
using BL;
using System.Configuration;
using BuenViaje.Sesion;

namespace BuenViaje
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            string mIdioma = ConfigurationManager.AppSettings.Get("Idioma");
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(LoginBL.SingleUsuario.Idioma_Descripcion));
        }

        public void CargarIdioma(List<ControlBE> Lista)
        {
            foreach (Control Control in this.Controls)
            {
                foreach (ControlBE c in Lista)
                {
                    if (c.ID_Control == Control.Name)
                    {
                        Control.Text = c.Mensaje;
                    }
                }
            }

            foreach (ToolStripMenuItem menu in this.menuStrip1.Items)
            {
                foreach (ControlBE c in Lista)
                {
                    if (c.ID_Control == menu.Name)
                    {
                        menu.Text = c.Mensaje;
                    }
                    foreach (ToolStripItem inner in menu.DropDownItems)
                    {
                        if (c.ID_Control == inner.Name)
                        {
                            inner.Text = c.Mensaje;
                        }
                    }
                }
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Principal-Confirmar-CerrarSesion", LoginBL.SingleUsuario.Idioma_Descripcion), IdiomaBL.ObtenerMensajeTextos("Principal-Info-CerrarSesion", LoginBL.SingleUsuario.Idioma_Descripcion), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                LoginBL loginbl = new LoginBL();
                loginbl.Logout(LoginBL.SingleUsuario);
                this.Close();
            }
        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Idioma mForm = new Idioma(this);
            //mForm.MdiParent = this;
            mForm.MinimizeBox = false;
            mForm.MaximizeBox = false;
            mForm.Show();
        }
    }
}
