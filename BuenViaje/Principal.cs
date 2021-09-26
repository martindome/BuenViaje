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
using BuenViaje.Localidades;
using BuenViaje.Buses;
using BE.Composite;

namespace BuenViaje
{
    public partial class Principal : Form
    {
        #region principal
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToScreen();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            string mIdioma = ConfigurationManager.AppSettings.Get("Idioma");
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            //Permisos Main Menu
            this.sesionToolStripMenuItem.Enabled = true;
            this.administracionToolStripMenuItem.Enabled = true;
            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminRutas) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadRutas))
            {
                this.tabControl1.TabPages.Remove(this.tabPageRutas);
            }
            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminClientes) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadClientes))
            {
                this.tabControl1.TabPages.Remove(this.tabPageClientes);
            }
            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminViajes) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadViajes))
            {
                this.tabControl1.TabPages.Remove(this.tabPageViajes);
            }
            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminLocalidades) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadLocalidades))
            {
                this.tabControl1.TabPages.Remove(this.tabPageLocalidades);
            }
            else
            {
                this.Load_tabPageLocalidades();
            }
            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.VendedorPasajes))
            {
                this.tabControl1.TabPages.Remove(this.tabPageClientes);
                this.tabControl1.TabPages.Remove(this.tabPagePasajes);
            }
            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminBuses) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadBuses))
            {
                this.tabControl1.TabPages.Remove(this.tabPageBuses);
            }
            else
            {
                this.Load_tabPageBuses();
            }
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

            foreach (TabPage page in tabControl1.TabPages)
            {
                page.Text = IdiomaBL.ObtenerMensajeTextos(page.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
                foreach (Control control in page.Controls)
                {
                    foreach (ControlBE c in Lista)
                    {
                        if (c.ID_Control == control.Name)
                        {
                            control.Text = c.Mensaje;
                        }
                    }
                    if (control is GroupBox)
                    {
                        CargarIdiomaGroupBox((GroupBox)control, Lista) ;
                    }
                }
            }
        }

        public void CargarIdiomaGroupBox(GroupBox groupBox, List<ControlBE> Lista)
        {
            foreach (Control control in groupBox.Controls)
            {
                foreach (ControlBE c in Lista)
                {
                    if (c.ID_Control == control.Name)
                    {
                        control.Text = c.Mensaje;
                    }
                }
                if (control is GroupBox)
                {
                    CargarIdiomaGroupBox((GroupBox)control, Lista);
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

        private string ObtenerMensajeColumna(string pstring)
        {
            return IdiomaBL.ObtenerMensajeTextos(pstring, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
        }

        #endregion

        #region Localidades
        private void tabPageLocalidades_Click(object sender, EventArgs e)
        {

            //if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminLocalidades))
            //{
            //    LocalidadBotton2.Enabled = false;
            //    LocalidadBotton3.Enabled = false;
            //    LocalidadBotton4.Enabled = false;
            //}
            //else
            //{
            //    LocalidadBotton2.Enabled = true;
            //    LocalidadBotton3.Enabled = true;
            //    LocalidadBotton4.Enabled = true;
            //}
            //CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            //ActulizarGrillaLocalidades();
        }

        private void Load_tabPageLocalidades()
        {
            grillaLocalidad.Rows.Clear();
            grillaLocalidad.Columns.Clear();
            grillaLocalidad.Columns.Add(ObtenerMensajeColumna("LocalidadPrincipal-Columna-LocalidadID"), ObtenerMensajeColumna("LocalidadPrincipal-Columna-LocalidadID"));
            grillaLocalidad.Columns.Add(ObtenerMensajeColumna("LocalidadPrincipal-Columna-Nombre"), ObtenerMensajeColumna("LocalidadPrincipal-Columna-Nombre"));
            grillaLocalidad.Columns.Add(ObtenerMensajeColumna("LocalidadPrincipal-Columna-Provincia"), ObtenerMensajeColumna("LocalidadPrincipal-Columna-Provincia"));
            grillaLocalidad.Columns.Add(ObtenerMensajeColumna("LocalidadPrincipal-Columna-Pais"), ObtenerMensajeColumna("LocalidadPrincipal-Columna-Pais"));
            grillaLocalidad.Columns[ObtenerMensajeColumna("LocalidadPrincipal-Columna-LocalidadID")].Visible = false;

            grillaLocalidad.MultiSelect = false;
            grillaLocalidad.EditMode = DataGridViewEditMode.EditProgrammatically;
            grillaLocalidad.AllowUserToAddRows = false;
            grillaLocalidad.AllowUserToDeleteRows = false;
            grillaLocalidad.AllowUserToResizeColumns = true;
            grillaLocalidad.AllowUserToResizeRows = false;
            grillaLocalidad.RowHeadersVisible = false;
            grillaLocalidad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaLocalidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grillaLocalidad.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grillaLocalidad.Rows.Clear();


            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminLocalidades))
            {
                LocalidadBotton2.Enabled = false;
                LocalidadBotton3.Enabled = false;
                LocalidadBotton4.Enabled = false;
            }
            else
            {
                LocalidadBotton2.Enabled = true;
                LocalidadBotton3.Enabled = true;
                LocalidadBotton4.Enabled = true;
            }

            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ActulizarGrillaLocalidades();
        }

        private void ActulizarGrillaLocalidades()
        {
            this.grillaLocalidad.Rows.Clear();
            LocalidadBL localidadbl = new LocalidadBL();
            List<LocalidadBE> lista = localidadbl.Listar();
            foreach (LocalidadBE localidad in lista)
            {
                bool flag = true;
                if (this.LocalidadPrincipalText1.Text != "" && this.LocalidadPrincipalText1.Text != localidad.Nombre)
                {
                    flag = false;
                }
                if (this.LocalidadPrincipalText2.Text != "" && this.LocalidadPrincipalText2.Text != localidad.Provincia)
                {
                    flag = false;
                }
                if (this.LocalidadPrincipalText3.Text != "" && this.LocalidadPrincipalText3.Text != localidad.Pais)
                {
                    flag = false;
                }
                if (flag)
                {
                    grillaLocalidad.Rows.Add(localidad.ID_Localidad, localidad.Nombre, localidad.Provincia, localidad.Pais);
                }
            }
        }

        private void LocalidadBotton5_Click(object sender, EventArgs e)
        {
            ActulizarGrillaLocalidades();
        }

        private void LocalidadBotton6_Click(object sender, EventArgs e)
        {
            this.LocalidadPrincipalText1.Text = "";
            this.LocalidadPrincipalText2.Text = "";
            this.LocalidadPrincipalText3.Text = "";
            ActulizarGrillaLocalidades();
        }

        private void LocalidadBotton2_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminLocalidades))
            {
                LocalidadBL localidadbl = new LocalidadBL();
                ABMLocalidades localidadesabm = new ABMLocalidades();
                localidadesabm.operacion = Operacion.Alta;
                //abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].ToString());
                localidadesabm.localidadbe = new LocalidadBE();
                localidadesabm.ShowDialog();
                ActulizarGrillaLocalidades();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Localidades-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LocalidadBotton3_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminLocalidades))
            {
                LocalidadBL localidadbl = new LocalidadBL();
                ABMLocalidades localidadesabm = new ABMLocalidades();
                localidadesabm.operacion = Operacion.Modificacion;
                //abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].ToString());
                localidadesabm.localidadbe = localidadbl.Obtener(int.Parse(this.grillaLocalidad.SelectedRows[0].Cells[0].Value.ToString()));
                localidadesabm.ShowDialog();
                ActulizarGrillaLocalidades();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Localidades-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LocalidadBotton4_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminLocalidades))
            {
                LocalidadBL localidadbl = new LocalidadBL();
                ABMLocalidades localidadesabm = new ABMLocalidades();
                localidadesabm.operacion = Operacion.Baja;
                //abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].ToString());
                localidadesabm.localidadbe = localidadbl.Obtener(int.Parse(this.grillaLocalidad.SelectedRows[0].Cells[0].Value.ToString()));
                localidadesabm.ShowDialog();
                ActulizarGrillaLocalidades();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Localidades-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Buses

        private void Load_tabPageBuses()
        {
            grillaBuses.Rows.Clear();
            grillaBuses.Columns.Clear();
            grillaBuses.Columns.Add(ObtenerMensajeColumna("BusPrincipal-Columna-BusID"), ObtenerMensajeColumna("BusPrincipal-Columna-BusID"));
            grillaBuses.Columns.Add(ObtenerMensajeColumna("BusPrincipal-Columna-Patente"), ObtenerMensajeColumna("BusPrincipal-Columna-Patente"));
            grillaBuses.Columns.Add(ObtenerMensajeColumna("BusPrincipal-Columna-Marca"), ObtenerMensajeColumna("BusPrincipal-Columna-Marca"));
            grillaBuses.Columns.Add(ObtenerMensajeColumna("BusPrincipal-Columna-Asientos"), ObtenerMensajeColumna("BusPrincipal-Columna-Asientos"));
            grillaBuses.Columns[ObtenerMensajeColumna("BusPrincipal-Columna-BusID")].Visible = false;

            grillaBuses.MultiSelect = false;
            grillaBuses.EditMode = DataGridViewEditMode.EditProgrammatically;
            grillaBuses.AllowUserToAddRows = false;
            grillaBuses.AllowUserToDeleteRows = false;
            grillaBuses.AllowUserToResizeColumns = true;
            grillaBuses.AllowUserToResizeRows = false;
            grillaBuses.RowHeadersVisible = false;
            grillaBuses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaBuses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grillaBuses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grillaBuses.Rows.Clear();


            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminLocalidades))
            {
                busesButton2.Enabled = false;
                busesButton3.Enabled = false;
                busesButton4.Enabled = false;
            }
            else
            {
                busesButton2.Enabled = true;
                busesButton3.Enabled = true;
                busesButton4.Enabled = true;
            }

            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ActulizarGrillaBuses();
        }

        private void ActulizarGrillaBuses()
        {
            this.grillaLocalidad.Rows.Clear();
            BusBL busbl = new BusBL();
            List<BusBE> lista = busbl.Listar();
            foreach (BusBE localidad in lista)
            {
                bool flag = true;
                if (this.busesText1.Text != "" && this.busesText1.Text != localidad.Patente)
                {
                    flag = false;
                }
                if (this.busesText2.Text != "" && this.busesText2.Text != localidad.Marca)
                {
                    flag = false;
                }
                if (this.busesText3.Text != "" && this.busesText3.Text != localidad.Asientos.ToString())
                {
                    flag = false;
                }
                if (flag)
                {
                    grillaLocalidad.Rows.Add(localidad.ID_Bus, localidad.Patente, localidad.Marca, localidad.Asientos);
                }
            }
        }

        private void busesButton2_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminBuses))
            {
                BusBL busbl = new BusBL();
                ABMBuses busesabm = new ABMBuses();
                busesabm.operacion = Operacion.Alta;
                //abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].ToString());
                busesabm.busbe = new BusBE();
                busesabm.ShowDialog();
                ActulizarGrillaBuses();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Buses-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void busesButton3_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminBuses))
            {
                LocalidadBL localidadbl = new LocalidadBL();
                ABMLocalidades localidadesabm = new ABMLocalidades();
                localidadesabm.operacion = Operacion.Modificacion;
                //abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].ToString());
                localidadesabm.localidadbe = localidadbl.Obtener(int.Parse(this.grillaLocalidad.SelectedRows[0].Cells[0].Value.ToString()));
                localidadesabm.ShowDialog();
                ActulizarGrillaLocalidades();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Buses-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void busesButton4_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminBuses))
            {
                LocalidadBL localidadbl = new LocalidadBL();
                ABMLocalidades localidadesabm = new ABMLocalidades();
                localidadesabm.operacion = Operacion.Baja;
                //abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].ToString());
                localidadesabm.localidadbe = localidadbl.Obtener(int.Parse(this.grillaLocalidad.SelectedRows[0].Cells[0].Value.ToString()));
                localidadesabm.ShowDialog();
                ActulizarGrillaLocalidades();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Buses-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void busesButton5_Click(object sender, EventArgs e)
        {
            ActulizarGrillaBuses();
        }

        private void busesButton6_Click(object sender, EventArgs e)
        {
            this.busesText1.Text = "";
            this.busesText2.Text = "";
            this.busesText3.Text = "";
            ActulizarGrillaBuses();
        }

        private void tabPageBuses_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        
    }
}
