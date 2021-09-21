using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BE;
using BL;
using BuenViaje.Sesion;
using BuenViaje.Administracion;
using BuenViaje.Administracion.Usuarios;
using BuenViaje.Administracion.Permisos;
using BuenViaje.Administracion.Backup;

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
            this.WindowState = FormWindowState.Normal;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            string mIdioma = ConfigurationManager.AppSettings.Get("Idioma");
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            //Permisos Main Menu
            this.sesionToolStripMenuItem.Enabled = true;
            this.administracionToolStripMenuItem.Enabled = true;
            this.pasajesStripMenuItem.Enabled = true;
            this.rutasToolStripMenuItem.Enabled = true;

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
            DialogResult Resultado = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Principal-Confirmar-CerrarSesion", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), IdiomaBL.ObtenerMensajeTextos("Principal-Info-CerrarSesion", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                SingletonSesion.Instancia.Logout();
                //LoginBL loginbl = new LoginBL();
                //loginbl.Logout(LoginBL.SingleUsuario);
                this.Hide();
                Login mLogin = new Login();
                mLogin.ShowDialog();
                this.Close();
            }
        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Idioma mForm = new Idioma(this);
            //mForm.MdiParent = this;
            mForm.MinimizeBox = false;
            mForm.MaximizeBox = false;
            mForm.ShowDialog();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitacora mForm = new Bitacora(this);
            if (SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadBitacora))
            {
                //mForm.MdiParent = this;
                mForm.MinimizeBox = false;
                mForm.MaximizeBox = false;
                mForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Principal-Permiso-Denegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarContraseña mForm = new CambiarContraseña(this);
            //mForm.MdiParent = this;
            mForm.MinimizeBox = false;
            mForm.MaximizeBox = false;
            mForm.ShowDialog();
        }

        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadUsuarios))
            {
                UsuariosPrincipal form = new UsuariosPrincipal();
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Principal-Permiso-Denegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestionarPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadPermisos))
            {
                PermisosPrincipal form = new PermisosPrincipal();
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Principal-Permiso-Denegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminBackup)) 
            {

                Backup form = new Backup();
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Principal-Permiso-Denegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restauracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminBackup))
            {
                Restore form = new Restore();
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Principal-Permiso-Denegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
