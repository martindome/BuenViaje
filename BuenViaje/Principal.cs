using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Drawing.Printing;
using BE;
using BE.Composite;
using BL;
using BuenViaje.Sesion;
using BuenViaje.Administracion;
using BuenViaje.Administracion.Usuarios;
using BuenViaje.Administracion.Permisos;
using BuenViaje.Administracion.Backup;
using BuenViaje.Localidades;
using BuenViaje.Buses;
using BuenViaje.Clientes;
using BuenViaje.Rutas;
using BuenViaje.Viajes;
using BuenViaje.Pasajes;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.Rendering.ChartMapper;
using MigraDoc.Rendering.UnitTest;
using MigraDoc.RtfRendering;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.DocumentObjectModel.Fields;

namespace BuenViaje
{
    public partial class Principal : Form
    {
        #region principal
        internal PasajeBE pasajebe;
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        public Principal()
        {
            InitializeComponent();
        }

        private void CallOnLoad()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToScreen();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            string mIdioma = ConfigurationManager.AppSettings.Get("Idioma");
            
            //Permisos Main Menu
            this.sesionToolStripMenuItem.Enabled = true;
            this.administracionToolStripMenuItem.Enabled = true;
            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminClientes) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadClientes))
            {
                this.tabControl1.TabPages.Remove(this.tabPageClientes);
            }
            else
            {
                if (!this.tabControl1.TabPages.Contains(this.tabPageClientes))
                {
                    this.tabControl1.TabPages.Insert(this.tabControl1.TabPages.Count, this.tabPageClientes);
                }
                Load_tabPageClientes();
            }
            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminLocalidades) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadLocalidades))
            {
                this.tabControl1.TabPages.Remove(this.tabPageLocalidades);
            }
            else
            {
                if (!this.tabControl1.TabPages.Contains(this.tabPageLocalidades))
                {
                    this.tabControl1.TabPages.Insert(this.tabControl1.TabPages.Count, this.tabPageLocalidades);
                }
                this.Load_tabPageLocalidades();
            }
            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminBuses) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadBuses))
            {
                this.tabControl1.TabPages.Remove(this.tabPageBuses);
            }
            else
            {
                if (!this.tabControl1.TabPages.Contains(this.tabPageBuses))
                {
                    this.tabControl1.TabPages.Insert(this.tabControl1.TabPages.Count, this.tabPageBuses);
                }
                this.Load_tabPageBuses();
            }
            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminRutas) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadRutas))
            {
                this.tabControl1.TabPages.Remove(this.tabPageRutas);
            }
            else
            {
                if (!this.tabControl1.TabPages.Contains(this.tabPageRutas))
                {
                    this.tabControl1.TabPages.Insert(this.tabControl1.TabPages.Count, this.tabPageRutas);
                }
                this.Load_tabPageRutas();
            }
            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminViajes) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadViajes))
            {
                this.tabControl1.TabPages.Remove(this.tabPageViajes);
            }
            else
            {
                if (!this.tabControl1.TabPages.Contains(this.tabPageViajes))
                {
                    this.tabControl1.TabPages.Insert(this.tabControl1.TabPages.Count, this.tabPageViajes);
                }
                Load_tabPageViajes();
            }

            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.VendedorPasajes) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadVentas))
            {
                this.tabControl1.TabPages.Remove(this.tabPagePasajes);
            }
            else
            {
                if (!this.tabControl1.TabPages.Contains(this.tabPagePasajes))
                {
                    this.tabControl1.TabPages.Insert(this.tabControl1.TabPages.Count, this.tabPagePasajes);
                }
                Load_tabPagePasajes();
            }

            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            SetToolTips();


        }

        private void Principal_Load(object sender, EventArgs e)
        {
            CallOnLoad();
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
                if (Control is GroupBox)
                {
                    CargarIdiomaGroupBox((GroupBox)Control, Lista);
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
                //page.Text = IdiomaBL.ObtenerMensajeTextos(page.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
                //foreach (Control control in page.Controls)
                //{
                //    foreach (ControlBE c in Lista)
                //    {
                //        if (c.ID_Control == control.Name)
                //        {
                //            control.Text = c.Mensaje;
                //        }
                //    }
                //    if (control is GroupBox)
                //    {
                //        CargarIdiomaGroupBox((GroupBox)control, Lista) ;
                //    }
                //}
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
                        CargarIdiomaGroupBox((GroupBox)control, Lista);
                    }
                }
                foreach (ControlBE c in Lista)
                {
                    if (c.ID_Control == page.Name)
                    {
                        page.Text = c.Mensaje;
                        break;
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

        private void SetToolTips()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            foreach (Control c in this.Controls)
            {
                ToolTip toolTip;
                string tooltipMessaje = IdiomaBL.ObtenerMensajeTextos(c.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
                if (tooltipMessaje != "")
                {
                    if (tooltips.Keys.Contains(c.Name))
                    {
                        toolTip = tooltips[c.Name];
                    }
                    else
                    {
                        toolTip = new ToolTip();
                        toolTip.AutoPopDelay = 5000;
                        toolTip.InitialDelay = 1000;
                        toolTip.ReshowDelay = 500;
                        // Force the ToolTip text to be displayed whether or not the form is active.
                        toolTip.ShowAlways = true;
                        tooltips[c.Name] = toolTip;
                    }

                    toolTip.SetToolTip(c, tooltipMessaje);
                }
                if (c is GroupBox)
                {
                    SetToolTipsGroupBox((GroupBox)c);
                }
            }
            foreach (TabPage page in tabControl1.TabPages)
            {
                foreach (Control c in page.Controls)
                {
                    ToolTip toolTip;
                    string tooltipMessaje = IdiomaBL.ObtenerMensajeTextos(c.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
                    if (tooltipMessaje != "")
                    {
                        if (tooltips.Keys.Contains(c.Name))
                        {
                            toolTip = tooltips[c.Name];
                        }
                        else
                        {
                            toolTip = new ToolTip();
                            toolTip.AutoPopDelay = 5000;
                            toolTip.InitialDelay = 1000;
                            toolTip.ReshowDelay = 500;
                            // Force the ToolTip text to be displayed whether or not the form is active.
                            toolTip.ShowAlways = true;
                            tooltips[c.Name] = toolTip;
                        }

                        toolTip.SetToolTip(c, tooltipMessaje);
                    }
                    if (c is GroupBox)
                    {
                        SetToolTipsGroupBox((GroupBox)c);
                    }
                }
            }

        }

        private void SetToolTipsGroupBox(GroupBox groupBox)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            foreach (Control c in groupBox.Controls)
            {
                ToolTip toolTip;
                string tooltipMessaje = IdiomaBL.ObtenerMensajeTextos(c.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
                if (tooltipMessaje != "")
                {
                    if (tooltips.Keys.Contains(c.Name))
                    {
                        toolTip = tooltips[c.Name];
                    }
                    else
                    {
                        toolTip = new ToolTip();
                        toolTip.AutoPopDelay = 5000;
                        toolTip.InitialDelay = 1000;
                        toolTip.ReshowDelay = 500;
                        // Force the ToolTip text to be displayed whether or not the form is active.
                        toolTip.ShowAlways = true;
                        tooltips[c.Name] = toolTip;
                    }

                    toolTip.SetToolTip(c, tooltipMessaje);
                }
                if (c is GroupBox)
                {
                    SetToolTipsGroupBox((GroupBox)c);
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
            //this.Controls.Clear();
            //this.InitializeComponent();
            CallOnLoad();
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
                CallOnLoad();
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
            CallOnLoad();
        }

        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.ReadUsuarios))
            {
                UsuariosPrincipal form = new UsuariosPrincipal();
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowDialog();
                CallOnLoad();
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
                CallOnLoad();
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
                CallOnLoad();
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
                CallOnLoad();
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

            //CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
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

            //CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ActulizarGrillaBuses();
        }

        private void ActulizarGrillaBuses()
        {
            this.grillaBuses.Rows.Clear();
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
                    grillaBuses.Rows.Add(localidad.ID_Bus, localidad.Patente, localidad.Marca, localidad.Asientos);
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
                BusBL busbl = new BusBL();
                ABMBuses busesabm = new ABMBuses();
                busesabm.operacion = Operacion.Modificacion;
                //abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].ToString());
                busesabm.busbe = busbl.Obtener(int.Parse(this.grillaBuses.SelectedRows[0].Cells[0].Value.ToString()));
                busesabm.ShowDialog();
                ActulizarGrillaBuses();
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

                BusBL busbl = new BusBL();
                ABMBuses busesabm = new ABMBuses();
                busesabm.operacion = Operacion.Baja;
                //abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].ToString());
                busesabm.busbe = busbl.Obtener(int.Parse(this.grillaBuses.SelectedRows[0].Cells[0].Value.ToString()));
                busesabm.ShowDialog();
                ActulizarGrillaBuses();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Buses-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void busesButton7_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = @"report_" + this.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @".pdf";
            // set filters - this can be done in properties as well
            savefile.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                Document document = new Document();
                document.DefaultPageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Portrait;
                document.DefaultPageSetup.PageFormat = PageFormat.A4;
                Section section = document.AddSection();

                //Titulo
                Paragraph Title = document.LastSection.AddParagraph(IdiomaBL.ObtenerMensajeTextos("Buses-pdf-Title", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n\n", "Heading1");
                Title.AddBookmark("Title");
                Title.Format.Font.Size = 30;
                //Title.Format.Font.Color = Colors.DarkBlue;
                Title.Format.Alignment = ParagraphAlignment.Center;

                Paragraph Date = document.LastSection.AddParagraph(IdiomaBL.ObtenerMensajeTextos("Buses-pdf-Date", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + ": " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\nn", "Heading1");
                Date.AddBookmark("Date");
                Date.Format.Font.Size = 15;
                //Date.Format.Font.Color = Colors.DarkBlue;
                Date.Format.Alignment = ParagraphAlignment.Left;

                Paragraph Requested = document.LastSection.AddParagraph(IdiomaBL.ObtenerMensajeTextos("Buses-pdf-Requested", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + ": " + SingletonSesion.Instancia.Usuario.Nombre_Usuario + "\nn", "Heading1");
                Requested.AddBookmark("Requested");
                Requested.Format.Font.Size = 15;
                //Requested.Format.Font.Color = Colors.DarkBlue;
                Requested.Format.Alignment = ParagraphAlignment.Left;

                this.CreateTable(document, savefile.FileName);
                var renderer = new PdfDocumentRenderer();
                renderer.Document = document;
                renderer.RenderDocument();
                renderer.Save(savefile.FileName);

            }
        }

        private void CreateTable(Document document, string TableName)
        {
            //Paragraph paragraph = document.LastSection.AddParagraph(TableName, "Heading2");

            Table table = new Table();
            table.Borders.Width = 0.75;

            Column column1 = table.AddColumn(Unit.FromCentimeter(2));
            column1.Format.Alignment = ParagraphAlignment.Center;
            Column column2 = table.AddColumn(Unit.FromCentimeter(5));
            column2.Format.Alignment = ParagraphAlignment.Center;
            Column column3 = table.AddColumn(Unit.FromCentimeter(2));
            column3.Format.Alignment = ParagraphAlignment.Center;
            Column column4 = table.AddColumn(Unit.FromCentimeter(8));
            column4.Format.Alignment = ParagraphAlignment.Center;

            Row row = table.AddRow();
            Cell cell = row.Cells[0];
            cell.AddParagraph(ObtenerMensajeColumna("BusPrincipal-Columna-Patente"));
            cell = row.Cells[1];
            cell.AddParagraph((ObtenerMensajeColumna("BusPrincipal-Columna-Marca")));
            cell = row.Cells[2];
            cell.AddParagraph((ObtenerMensajeColumna("BusPrincipal-Columna-Asientos")));

            //BitacoraDataGrid1.Sort(BitacoraDataGrid1.Columns[1], ListSortDirection.Ascending);
            foreach (DataGridViewRow GridRow in grillaBuses.Rows)
            {
                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph(GridRow.Cells[1].Value.ToString());
                cell = row.Cells[1];
                cell.AddParagraph(GridRow.Cells[2].Value.ToString());
                cell = row.Cells[2];
                cell.AddParagraph(GridRow.Cells[3].Value.ToString());
            }
            //table.SetEdge(0, 0, 2, 3, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 1.5, Colors.Black);
            document.LastSection.Add(table);
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

        #endregion

        #region Clientes
        private void Load_tabPageClientes()
        {
            grillaClientes.Columns.Clear();
            grillaClientes.Columns.Add(ObtenerMensajeColumna("ClientesPrincipal-Columna-ClienteID"), ObtenerMensajeColumna("ClientesPrincipal-Columna-ClienteID"));
            grillaClientes.Columns.Add(ObtenerMensajeColumna("ClientesPrincipal-Columna-Nombre"), ObtenerMensajeColumna("ClientesPrincipal-Columna-Nombre"));
            grillaClientes.Columns.Add(ObtenerMensajeColumna("ClientesPrincipal-Columna-Apellido"), ObtenerMensajeColumna("ClientesPrincipal-Columna-Apellido"));
            grillaClientes.Columns.Add(ObtenerMensajeColumna("ClientesPrincipal-Columna-DNI"), ObtenerMensajeColumna("ClientesPrincipal-Columna-DNI"));
            grillaClientes.Columns.Add(ObtenerMensajeColumna("ClientesPrincipal-Columna-Email"), ObtenerMensajeColumna("ClientesPrincipal-Columna-Email"));
            grillaClientes.Columns[ObtenerMensajeColumna("ClientesPrincipal-Columna-ClienteID")].Visible = false;

            grillaClientes.MultiSelect = false;
            grillaClientes.EditMode = DataGridViewEditMode.EditProgrammatically;
            grillaClientes.AllowUserToAddRows = false;
            grillaClientes.AllowUserToDeleteRows = false;
            grillaClientes.AllowUserToResizeColumns = true;
            grillaClientes.AllowUserToResizeRows = false;
            grillaClientes.RowHeadersVisible = false;
            grillaClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grillaClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminClientes))
            {
                ClientesBotton2.Enabled = false;
                ClientesBotton3.Enabled = false;
                ClientesBotton4.Enabled = false;
            }
            else
            {
                ClientesBotton2.Enabled = true;
                ClientesBotton3.Enabled = true;
                ClientesBotton4.Enabled = true;
            }

            //CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ActualizarGrillaClientes();
        }

        private void ActualizarGrillaClientes()
        {
            this.grillaClientes.Rows.Clear();
            ClienteBL clientebl = new ClienteBL();
            List<ClienteBE> lista = clientebl.Listar();
            foreach (ClienteBE clientebe in lista)
            {
                bool flag = true;
                if (this.ClientesTextBox1.Text != "" && this.ClientesTextBox1.Text != clientebe.Nombre)
                {
                    flag = false;
                }
                if (this.ClientesTextBox2.Text != "" && this.ClientesTextBox2.Text != clientebe.Apellido)
                {
                    flag = false;
                }
                if (this.ClientesTextBox3.Text != "" && this.ClientesTextBox3.Text != clientebe.DNI)
                {
                    flag = false;
                }
                if (this.ClientesTextBox4.Text != "" && this.ClientesTextBox4.Text != clientebe.Email)
                {
                    flag = false;
                }
                if (flag)
                {
                    grillaClientes.Rows.Add(clientebe.ID_Cliente, clientebe.Nombre, clientebe.Apellido, clientebe.DNI, clientebe.Email);
                }
            }
        }

        private void tabPageClientes_Click(object sender, EventArgs e)
        {

        }
        private void ClientesBotton2_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminClientes))
            {
                ClienteBL clientebl = new ClienteBL();
                ABMCliente abmcliente = new ABMCliente();
                abmcliente.operacion = Operacion.Alta;
                abmcliente.clientebe = new ClienteBE();
                abmcliente.ShowDialog();
                ActualizarGrillaClientes();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Clientes-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientesBotton3_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminClientes))
            {
                ClienteBL clientebl = new ClienteBL();
                ABMCliente abmcliente = new ABMCliente();
                abmcliente.operacion = Operacion.Modificacion;
                abmcliente.clientebe = clientebl.Obtener(int.Parse(this.grillaClientes.SelectedRows[0].Cells[0].Value.ToString()));
                abmcliente.ShowDialog();
                ActualizarGrillaClientes();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Clientes-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientesBotton4_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminClientes))
            {
                ClienteBL clientebl = new ClienteBL();
                ABMCliente abmcliente = new ABMCliente();
                abmcliente.operacion = Operacion.Baja;
                abmcliente.clientebe = clientebl.Obtener(int.Parse(this.grillaClientes.SelectedRows[0].Cells[0].Value.ToString()));
                abmcliente.ShowDialog();
                ActualizarGrillaClientes();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Clientes-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientesBotton5_Click(object sender, EventArgs e)
        {
            ActualizarGrillaClientes();
        }

        private void ClientesBotton6_Click(object sender, EventArgs e)
        {
            this.ClientesTextBox1.Text = "";
            this.ClientesTextBox2.Text = "";
            this.ClientesTextBox3.Text = "";
            this.ClientesTextBox4.Text = "";
            ActualizarGrillaClientes();
        }

        private void ClientesBotton1_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #region rutas
        private void Load_tabPageRutas()
        {
            dataGridRutas.Rows.Clear();
            dataGridRutas.Columns.Clear();
            dataGridRutas.Columns.Add(ObtenerMensajeColumna("RutaPrincpal-Columna-RutaID"), ObtenerMensajeColumna("RutaPrincpal-Columna-RutaID"));
            dataGridRutas.Columns.Add(ObtenerMensajeColumna("RutaPrincpal-Columna-Origen"), ObtenerMensajeColumna("RutaPrincpal-Columna-Origen"));
            dataGridRutas.Columns.Add(ObtenerMensajeColumna("RutaPrincpal-Columna-Destino"), ObtenerMensajeColumna("RutaPrincpal-Columna-Destino"));
            dataGridRutas.Columns.Add(ObtenerMensajeColumna("RutaPrincpal-Columna-Nombre"), ObtenerMensajeColumna("RutaPrincpal-Columna-Nombre"));
            dataGridRutas.Columns.Add(ObtenerMensajeColumna("RutaPrincpal-Columna-Duracion"), ObtenerMensajeColumna("RutaPrincpal-Columna-Duracion"));
            dataGridRutas.Columns[ObtenerMensajeColumna("RutaPrincpal-Columna-RutaID")].Visible = false;

            dataGridRutas.MultiSelect = false;
            dataGridRutas.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridRutas.AllowUserToAddRows = false;
            dataGridRutas.AllowUserToDeleteRows = false;
            dataGridRutas.AllowUserToResizeColumns = true;
            dataGridRutas.AllowUserToResizeRows = false;
            dataGridRutas.RowHeadersVisible = false;
            dataGridRutas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridRutas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminRutas))
            {
                RutasButton2.Enabled = false;
                RutasButton3.Enabled = false;
                RutasButton4.Enabled = false;
            }
            else
            {
                RutasButton2.Enabled = true;
                RutasButton3.Enabled = true;
                RutasButton4.Enabled = true;
            }
            //CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ActualizarGrillaRutas();
        }
        private void ActualizarGrillaRutas()
        {
            this.dataGridRutas.Rows.Clear();
            RutaBL rutabl = new RutaBL();
            List<RutaBE> lista = rutabl.Listar();
            foreach (RutaBE rutabe in lista)
            {
                bool flag = true;
                //if (this.RutasPrincipalText2.Text != "" && this.RutasPrincipalText2.Text != rutabe.Origen.Nombre)
                if (this.RutasPrincipalText2.Text != "" && !(rutabe.Origen.Nombre.Contains(this.RutasPrincipalText2.Text) || rutabe.Origen.Provincia.Contains(this.RutasPrincipalText2.Text) || rutabe.Origen.Pais.Contains(this.RutasPrincipalText2.Text)))
                {
                    flag = false;
                }
                //if (this.RutasPrincipalText3.Text != "" && this.RutasPrincipalText3.Text != rutabe.Destino.Nombre)
                if (this.RutasPrincipalText3.Text != "" && !(rutabe.Destino.Nombre.Contains(this.RutasPrincipalText3.Text) || rutabe.Destino.Provincia.Contains(this.RutasPrincipalText3.Text) || rutabe.Destino.Pais.Contains(this.RutasPrincipalText3.Text)))
                {
                    flag = false;
                }
                if (flag)
                {
                   dataGridRutas.Rows.Add(rutabe.ID_Ruta, rutabe.Origen.Pais + "-" + rutabe.Origen.Provincia + "-" + rutabe.Origen.Nombre, rutabe.Destino.Pais + "-" + rutabe.Destino.Provincia + "-" + rutabe.Destino.Nombre, rutabe.Nombre, rutabe.Duracion.ToString());
                }
            }
        }

        private void RutasButton5_Click(object sender, EventArgs e)
        {
            ActualizarGrillaRutas();
        }

        private void RutasButton6_Click(object sender, EventArgs e)
        {
            this.RutasPrincipalText2.Text = "";
            this.RutasPrincipalText3.Text = "";
            ActualizarGrillaRutas();
        }
        private void RutasButton1_Click(object sender, EventArgs e)
        {

        }

        private void RutasButton2_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminRutas))
            {
                RutaBL rutabl = new RutaBL();
                ABMRutas abmruta = new ABMRutas();
                abmruta.operacion = Operacion.Alta;
                abmruta.rutabe = new RutaBE();
                abmruta.ShowDialog();
                ActualizarGrillaRutas();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Rutas-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RutasButton3_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminRutas))
            {
                RutaBL rutabl = new RutaBL();
                ABMRutas abmruta = new ABMRutas();
                abmruta.operacion = Operacion.Modificacion;
                abmruta.rutabe = rutabl.Obtener(int.Parse(this.dataGridRutas.SelectedRows[0].Cells[0].Value.ToString()));
                abmruta.ShowDialog();
                ActualizarGrillaRutas();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Rutas-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RutasButton4_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminRutas))
            {
                RutaBL rutabl = new RutaBL();
                ABMRutas abmruta = new ABMRutas();
                abmruta.operacion = Operacion.Baja;
                abmruta.rutabe = rutabl.Obtener(int.Parse(this.dataGridRutas.SelectedRows[0].Cells[0].Value.ToString()));
                abmruta.ShowDialog();
                ActualizarGrillaRutas();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Rutas-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Viajes
        private void Load_tabPageViajes()
        {
            ViajeDatePickerDesde.CustomFormat = "MM-dd-yyyy";
            ViajeDatePickerDesde.Format = DateTimePickerFormat.Custom;

            ViajeDatePickerDesdeHora.Format = DateTimePickerFormat.Time;
            ViajeDatePickerDesdeHora.ShowUpDown = true;

            ViajeDatePickerHasta.CustomFormat = "MM-dd-yyyy";
            ViajeDatePickerHasta.Format = DateTimePickerFormat.Custom;
            ViajeDatePickerHasta.Value = DateTime.Now.AddDays(7);

            ViajeDatePickerHastaHora.Format = DateTimePickerFormat.Time;
            ViajeDatePickerHastaHora.ShowUpDown = true;
            ViajesPrincipalDataGrid.Rows.Clear();
            ViajesPrincipalDataGrid.Columns.Clear();
            ViajesPrincipalDataGrid.Columns.Add(ObtenerMensajeColumna("ViajePrincpal-Columna-ViajeID"), ObtenerMensajeColumna("ViajePrincpal-Columna-ViajeID"));
            ViajesPrincipalDataGrid.Columns.Add(ObtenerMensajeColumna("ViajePrincpal-Columna-RutaID"), ObtenerMensajeColumna("ViajePrincpal-Columna-RutaID"));
            ViajesPrincipalDataGrid.Columns.Add(ObtenerMensajeColumna("ViajePrincpal-Columna-BusID"), ObtenerMensajeColumna("ViajePrincpal-Columna-BusID"));
            ViajesPrincipalDataGrid.Columns.Add(ObtenerMensajeColumna("ViajePrincpal-Columna-RutaNombre"), ObtenerMensajeColumna("ViajePrincpal-Columna-RutaNombre"));
            ViajesPrincipalDataGrid.Columns.Add(ObtenerMensajeColumna("ViajePrincpal-Columna-BusPatente"), ObtenerMensajeColumna("ViajePrincpal-Columna-BusPatente"));
            ViajesPrincipalDataGrid.Columns.Add(ObtenerMensajeColumna("ViajePrincpal-Columna-Fecha"), ObtenerMensajeColumna("ViajePrincpal-Columna-Fecha"));
            ViajesPrincipalDataGrid.Columns.Add(ObtenerMensajeColumna("ViajePrincpal-Columna-Cancelado"), ObtenerMensajeColumna("ViajePrincpal-Columna-Cancelado"));
            ViajesPrincipalDataGrid.Columns[ObtenerMensajeColumna("ViajePrincpal-Columna-ViajeID")].Visible = false;
            ViajesPrincipalDataGrid.Columns[ObtenerMensajeColumna("ViajePrincpal-Columna-RutaID")].Visible = false;
            ViajesPrincipalDataGrid.Columns[ObtenerMensajeColumna("ViajePrincpal-Columna-BusID")].Visible = false;

            ViajesPrincipalDataGrid.MultiSelect = false;
            ViajesPrincipalDataGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
            ViajesPrincipalDataGrid.AllowUserToAddRows = false;
            ViajesPrincipalDataGrid.AllowUserToDeleteRows = false;
            ViajesPrincipalDataGrid.AllowUserToResizeColumns = true;
            ViajesPrincipalDataGrid.AllowUserToResizeRows = false;
            ViajesPrincipalDataGrid.RowHeadersVisible = false;
            ViajesPrincipalDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ViajesPrincipalDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ViajesPrincipalDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ViajesPrincipalDataGrid.Rows.Clear();


            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminViajes))
            {
                ViajesPrincipalButton1.Enabled = false;
                ViajesPrincipalButton2.Enabled = false;
                ViajesPrincipalButton3.Enabled = false;
                ViajesPrincipalButton4.Enabled = false;
            }
            else
            {
                ViajesPrincipalButton1.Enabled = true;
                ViajesPrincipalButton2.Enabled = true;
                ViajesPrincipalButton3.Enabled = true;
                ViajesPrincipalButton4.Enabled = true;
            }
            //CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ActualizarGrillaViajes();
        }

        private void ActualizarGrillaViajes()
        {
            this.ViajesPrincipalDataGrid.Rows.Clear();
            ViajeBL viajebl = new ViajeBL();
            RutaBL rutabl = new RutaBL();
            BusBL busbl = new BusBL();
            DateTime Desde = ViajeDatePickerDesde.Value.Date + ViajeDatePickerDesdeHora.Value.TimeOfDay;
            DateTime Hasta = ViajeDatePickerHasta.Value.Date + ViajeDatePickerHastaHora.Value.TimeOfDay;
            foreach (ViajeBE viaje in viajebl.Listar(Desde, Hasta))
            {
                bool flag = true;
                //if (this.RutasPrincipalText2.Text != "" && this.RutasPrincipalText2.Text != rutabe.Origen.Nombre)
                if (this.ViajesPrincipalText1.Text != "" && !(busbl.Obtener(viaje.ID_Bus).Patente.Contains(this.ViajesPrincipalText1.Text)))
                {
                    flag = false;
                }
                //if (this.RutasPrincipalText3.Text != "" && this.RutasPrincipalText3.Text != rutabe.Destino.Nombre)
                if (this.ViajesPrincipalText1.Text != "" && !(rutabl.Obtener(viaje.ID_Ruta).Nombre.Contains(this.ViajesPrincipalText2.Text)))                {
                    flag = false;
                }
                if (ViajesPrincipalCheckBox.Checked && !viaje.Cancelado)
                {
                    flag = false;
                }
                if (flag)
                {
                    string cancelado;
                    if (viaje.Cancelado)
                    {
                        cancelado = IdiomaBL.ObtenerMensajeTextos("Cancelado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
                    }
                    else
                    {
                        cancelado = IdiomaBL.ObtenerMensajeTextos("No Cancelado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
                    }
                    ViajesPrincipalDataGrid.Rows.Add(viaje.ID_Viaje, viaje.ID_Ruta, viaje.ID_Bus, rutabl.Obtener(viaje.ID_Ruta).Nombre, busbl.Obtener(viaje.ID_Bus).Patente, viaje.Fecha, cancelado);
                }
            }
        }
        private void ViajesPrincipalButton5_Click(object sender, EventArgs e)
        {
            ActualizarGrillaViajes();
        }

        private void ViajesPrincipalButton6_Click(object sender, EventArgs e)
        {
            this.ViajesPrincipalText1.Text = "";
            this.ViajesPrincipalText2.Text = "";
            ViajeDatePickerDesde.Value = DateTime.Now;
            ViajeDatePickerHasta.Value = DateTime.Now;
            ActualizarGrillaViajes();
        }

        private void ViajesPrincipalButton2_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminViajes))
            {
                ViajeBL rutabl = new ViajeBL();
                ABMViajes abmviajes = new ABMViajes();
                abmviajes.operacion = Operacion.Alta;
                abmviajes.viajebe = new ViajeBE();
                abmviajes.ShowDialog();
                ActualizarGrillaViajes();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Viajes-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void ViajesPrincipalButton3_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminViajes))
            {
                ViajeBL viajebl = new ViajeBL();
                ABMViajes abmviajes = new ABMViajes();
                abmviajes.operacion = Operacion.Modificacion;
                abmviajes.viajebe = viajebl.Obtener(int.Parse(this.ViajesPrincipalDataGrid.SelectedRows[0].Cells[0].Value.ToString()));
                abmviajes.ShowDialog();
                ActualizarGrillaViajes();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Viajes-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViajesPrincipalButton4_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminViajes))
            {
                ViajeBL viajebl = new ViajeBL();
                ABMViajes abmviajes = new ABMViajes();
                abmviajes.operacion = Operacion.Baja;
                abmviajes.viajebe = viajebl.Obtener(int.Parse(this.ViajesPrincipalDataGrid.SelectedRows[0].Cells[0].Value.ToString()));
                abmviajes.ShowDialog();
                ActualizarGrillaViajes();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Viajes-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViajesPrincipalButton1_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminViajes))
            {
                ViajeBL viajebl = new ViajeBL();
                ABMViajes abmviajes = new ABMViajes();
                abmviajes.operacion = Operacion.Ver;
                abmviajes.viajebe = viajebl.Obtener(int.Parse(this.ViajesPrincipalDataGrid.SelectedRows[0].Cells[0].Value.ToString()));
                abmviajes.ShowDialog();
                ActualizarGrillaViajes();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Viajes-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion Viajes

        #region Pasajes

        private void Load_tabPagePasajes()
        {
            pasajeDateTimePicker1.CustomFormat = "MM-dd-yyyy";
            pasajeDateTimePicker1.Format = DateTimePickerFormat.Custom;

            pasajeDateTimePicker2.CustomFormat = "MM-dd-yyyy";
            pasajeDateTimePicker2.Format = DateTimePickerFormat.Custom;
            pasajeDateTimePicker2.Value = DateTime.Now.AddDays(7);

            pasajesPrincipalDataGridClientes.Rows.Clear();
            pasajesPrincipalDataGridClientes.Columns.Clear();
            pasajesPrincipalDataGridClientes.Columns.Add(ObtenerMensajeColumna("ClientesPrincipal-Columna-ClienteID"), ObtenerMensajeColumna("ClientesPrincipal-Columna-ClienteID"));
            pasajesPrincipalDataGridClientes.Columns.Add(ObtenerMensajeColumna("ClientesPrincipal-Columna-Nombre"), ObtenerMensajeColumna("ClientesPrincipal-Columna-Nombre"));
            pasajesPrincipalDataGridClientes.Columns.Add(ObtenerMensajeColumna("ClientesPrincipal-Columna-Apellido"), ObtenerMensajeColumna("ClientesPrincipal-Columna-Apellido"));
            pasajesPrincipalDataGridClientes.Columns.Add(ObtenerMensajeColumna("ClientesPrincipal-Columna-DNI"), ObtenerMensajeColumna("ClientesPrincipal-Columna-DNI"));
            pasajesPrincipalDataGridClientes.Columns.Add(ObtenerMensajeColumna("ClientesPrincipal-Columna-Email"), ObtenerMensajeColumna("ClientesPrincipal-Columna-Email"));
            pasajesPrincipalDataGridClientes.Columns[ObtenerMensajeColumna("ClientesPrincipal-Columna-ClienteID")].Visible = false;
            pasajesPrincipalDataGridClientes.MultiSelect = false;
            pasajesPrincipalDataGridClientes.EditMode = DataGridViewEditMode.EditProgrammatically;
            pasajesPrincipalDataGridClientes.AllowUserToAddRows = false;
            pasajesPrincipalDataGridClientes.AllowUserToDeleteRows = false;
            pasajesPrincipalDataGridClientes.AllowUserToResizeColumns = true;
            pasajesPrincipalDataGridClientes.AllowUserToResizeRows = false;
            pasajesPrincipalDataGridClientes.RowHeadersVisible = false;
            pasajesPrincipalDataGridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pasajesPrincipalDataGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pasajesPrincipalDataGridClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            pasajesPrincipalDataGridClientes.Rows.Clear();

            pasajesPrincipalDataGridViajes.Rows.Clear();
            pasajesPrincipalDataGridViajes.Columns.Clear();
            pasajesPrincipalDataGridViajes.Columns.Add(ObtenerMensajeColumna("PasajePrincipal-Columna-ViajeID"), ObtenerMensajeColumna("PasajePrincipal-Columna-ViajeID"));
            pasajesPrincipalDataGridViajes.Columns.Add(ObtenerMensajeColumna("PasajePrincipal-Columna-RutaID"), ObtenerMensajeColumna("PasajePrincipal-Columna-RutaID"));
            pasajesPrincipalDataGridViajes.Columns.Add(ObtenerMensajeColumna("PasajePrincipal-Columna-BusID"), ObtenerMensajeColumna("PasajePrincipal-Columna-BusID"));
            pasajesPrincipalDataGridViajes.Columns.Add(ObtenerMensajeColumna("PasajePrincipal-Columna-Origen"), ObtenerMensajeColumna("PasajePrincipal-Columna-Origen"));
            pasajesPrincipalDataGridViajes.Columns.Add(ObtenerMensajeColumna("PasajePrincipal-Columna-Destino"), ObtenerMensajeColumna("PasajePrincipal-Columna-Destino"));
            pasajesPrincipalDataGridViajes.Columns.Add(ObtenerMensajeColumna("PasajePrincipal-Columna-Fecha"), ObtenerMensajeColumna("PasajePrincipal-Columna-Fecha"));
            pasajesPrincipalDataGridViajes.Columns.Add(ObtenerMensajeColumna("PasajePrincipal-Columna-Disponibles"), ObtenerMensajeColumna("PasajePrincipal-Columna-Disponibles"));
            pasajesPrincipalDataGridViajes.Columns[ObtenerMensajeColumna("PasajePrincipal-Columna-ViajeID")].Visible = false;
            pasajesPrincipalDataGridViajes.Columns[ObtenerMensajeColumna("PasajePrincipal-Columna-RutaID")].Visible = false;
            pasajesPrincipalDataGridViajes.Columns[ObtenerMensajeColumna("PasajePrincipal-Columna-BusID")].Visible = false;

            pasajesPrincipalDataGridViajes.MultiSelect = false;
            pasajesPrincipalDataGridViajes.EditMode = DataGridViewEditMode.EditProgrammatically;
            pasajesPrincipalDataGridViajes.AllowUserToAddRows = false;
            pasajesPrincipalDataGridViajes.AllowUserToDeleteRows = false;
            pasajesPrincipalDataGridViajes.AllowUserToResizeColumns = true;
            pasajesPrincipalDataGridViajes.AllowUserToResizeRows = false;
            pasajesPrincipalDataGridViajes.RowHeadersVisible = false;
            pasajesPrincipalDataGridViajes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pasajesPrincipalDataGridViajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pasajesPrincipalDataGridViajes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            pasajesPrincipalDataGridViajes.Rows.Clear();

            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminClientes) && !SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.VendedorPasajes))
            {
                pasajesPrincipalButton3.Enabled = false;
            }
            else
            {
                pasajesPrincipalButton3.Enabled = true;
            }

            if (!SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.VendedorPasajes))
            {
                pasajesPrincipalButton4.Enabled = false;
                pasajesPrincipalButton5.Enabled = false;
            }
            else
            {
                pasajesPrincipalButton4.Enabled= true;
                pasajesPrincipalButton5.Enabled = true;
            }
            //CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ActualizarGrillasPasajeCliente();
            ActualizarGrillasPasajeViajes();
        }

        private void ActualizarGrillasPasajeViajes()
        {
            //Viajes
            this.pasajesPrincipalDataGridViajes.Rows.Clear();
            ViajeBL viajebl = new ViajeBL();
            BusBL busbl = new BusBL();
            RutaBL rutabl = new RutaBL();
            PasajeBL pasajebl = new PasajeBL();
            DateTime Desde = pasajeDateTimePicker1.Value.Date;
            DateTime Hasta = pasajeDateTimePicker2.Value.Date;
            foreach (ViajeBE viaje in viajebl.Listar(Desde, Hasta))
            {
                List<PasajeBE> PasajesViaje = pasajebl.ListarViaje(viaje.ID_Viaje);
                BusBE bus = busbl.Obtener(viaje.ID_Bus);
                int Disponibles = bus.Asientos - PasajesViaje.Count;


                bool flag = true;
                RutaBE rutabe = rutabl.Obtener(viaje.ID_Ruta);
                //if (this.RutasPrincipalText2.Text != "" && this.RutasPrincipalText2.Text != rutabe.Origen.Nombre)
                if (this.pasajesPrincipalTextBox4.Text != "" && !(rutabe.Origen.Nombre.Contains(this.pasajesPrincipalTextBox4.Text) || rutabe.Origen.Provincia.Contains(this.pasajesPrincipalTextBox4.Text) || rutabe.Origen.Pais.Contains(this.pasajesPrincipalTextBox4.Text)))
                {
                    flag = false;
                }
                //if (this.RutasPrincipalText3.Text != "" && this.RutasPrincipalText3.Text != rutabe.Destino.Nombre)
                if (this.pasajesPrincipalTextBox5.Text != "" && !(rutabe.Destino.Nombre.Contains(this.pasajesPrincipalTextBox5.Text) || rutabe.Destino.Provincia.Contains(this.pasajesPrincipalTextBox5.Text) || rutabe.Destino.Pais.Contains(this.pasajesPrincipalTextBox5.Text)))
                {
                    flag = false;
                }

                if (flag)
                {
                    pasajesPrincipalDataGridViajes.Rows.Add(viaje.ID_Viaje, viaje.ID_Ruta, viaje.ID_Bus, rutabe.Origen.Pais + "-" + rutabe.Origen.Provincia + "-" + rutabe.Origen.Nombre, rutabe.Destino.Pais + "-" + rutabe.Destino.Provincia + "-" + rutabe.Destino.Nombre, viaje.Fecha, Disponibles);
                }
            }
        }
        private void ActualizarGrillasPasajeCliente()
        {
            this.pasajesPrincipalDataGridClientes.Rows.Clear();
            ClienteBL clientebl = new ClienteBL();
            List<ClienteBE> lista = clientebl.Listar();
            foreach (ClienteBE clientebe in lista)
            {
                bool flag = true;
                if (this.pasajesPrincipalTextBox1.Text != "" && !clientebe.Nombre.Contains(this.pasajesPrincipalTextBox1.Text))
                {
                    flag = false;
                }
                if (this.pasajesPrincipalTextBox2.Text != "" && !clientebe.Apellido.Contains(this.pasajesPrincipalTextBox2.Text))
                {
                    flag = false;
                }
                if (this.pasajesPrincipalTextBox3.Text != "" && !clientebe.DNI.Contains(this.pasajesPrincipalTextBox3.Text))
                {
                    flag = false;
                }
                if (flag)
                {
                    pasajesPrincipalDataGridClientes.Rows.Add(clientebe.ID_Cliente, clientebe.Nombre, clientebe.Apellido, clientebe.DNI, clientebe.Email);
                }
            }
        }
        private void pasajesPrincipalButton3_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminClientes))
            {
                ClienteBL clientebl = new ClienteBL();
                ABMCliente abmcliente = new ABMCliente();
                abmcliente.operacion = Operacion.Alta;
                abmcliente.clientebe = new ClienteBE();
                abmcliente.ShowDialog();
                ActualizarGrillasPasajeCliente();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Clientes-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pasajesPrincipalButton1_Click(object sender, EventArgs e)
        {
            ActualizarGrillasPasajeCliente();
        }
        private void pasajesPrincipalButton2_Click(object sender, EventArgs e)
        {
            ActualizarGrillasPasajeViajes();
        }

        private void pasajesPrincipalButton4_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.VendedorPasajes))
            {
                try
                {
                    BusBL busbl = new BusBL();
                    PasajeBL pasajebl = new PasajeBL();
                    ViajeBL viajebl = new ViajeBL();
                    ViajeBE viaje = viajebl.Obtener(int.Parse(pasajesPrincipalDataGridViajes.SelectedRows[0].Cells[0].Value.ToString()));
                    BusBE bus = busbl.Obtener(viaje.ID_Bus);
                    if (int.Parse(pasajesPrincipalTextBox6.Text) > 7 || int.Parse(pasajesPrincipalDataGridViajes.SelectedRows[0].Cells[6].Value.ToString()) - int.Parse(pasajesPrincipalTextBox6.Text) < 0)
                    {
                        MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Error-CantidadPasaje", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < int.Parse(pasajesPrincipalTextBox6.Text); i++) {
                            PasajeBE pasaje = new PasajeBE();
                            pasaje.ID_Cliente = int.Parse(pasajesPrincipalDataGridClientes.SelectedRows[0].Cells[0].Value.ToString());
                            pasaje.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                            pasaje.Devuelto = false;
                            pasaje.ID_Viaje = viaje.ID_Viaje;
                            pasaje.Fecha = DateTime.Now;
                            pasajebl.Vender(pasaje);
                            this.pasajebe = pasaje;
                            ImprimirPasaje(pasaje);
                            //Bitacora
                            BitacoraBL Bitacorabl = new BitacoraBL();
                            BitacoraBE mBitacora = new BitacoraBE();
                            mBitacora.Descripcion = "Comprado pasaje: " + pasaje.ID_Pasaje;
                            mBitacora.Fecha = DateTime.Now;
                            mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                            mBitacora.Tipo_Evento = "MEDIUM";
                            Bitacorabl.Guardar(mBitacora);
                        }
                    }
                    ActualizarGrillasPasajeViajes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Error-VentaPasaje", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Clientes-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pasajesPrincipalButton5_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.VendedorPasajes))
            {
                DevolucionPasajes formPasajes = new DevolucionPasajes();
                
                formPasajes.clientebe = new ClienteBL().Obtener(int.Parse(pasajesPrincipalDataGridClientes.SelectedRows[0].Cells[0].Value.ToString()));
                formPasajes.ShowDialog();
                ActualizarGrillasPasajeViajes();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Clientes-AccesoDenegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirPasaje(PasajeBE pasaje)
        {

            PrintDocument pd = new PrintDocument();
            PaperSize ps = new PaperSize("", 475, 550);

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            pd.PrintController = new StandardPrintController();
            pd.DefaultPageSettings.Margins.Left = 0;
            pd.DefaultPageSettings.Margins.Right = 0;
            pd.DefaultPageSettings.Margins.Top = 0;
            pd.DefaultPageSettings.Margins.Bottom = 0;

            pd.DefaultPageSettings.PaperSize = ps;
            pd.Print();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {

            ViajeBE viaje = new ViajeBL().Obtener(pasajebe.ID_Viaje);
            RutaBE ruta = new RutaBL().Obtener(viaje.ID_Ruta);
            BusBE bus = new BusBL().Obtener(viaje.ID_Bus);
            ClienteBE cliente = new ClienteBL().Obtener(pasajebe.ID_Cliente);
            
            int SPACE = 145;
            Graphics g = e.Graphics;
            g.DrawRectangle(Pens.Black, 5, 5, 420, 450);

            // g.DrawImage(Image.FromFile(title),50,7);
            System.Drawing.Font fBody = new System.Drawing.Font("Lucida Console", 15, FontStyle.Bold);
            System.Drawing.Font fBody1 = new System.Drawing.Font("Lucida Console", 15, FontStyle.Regular);
            System.Drawing.Font rs = new System.Drawing.Font("Stencil", 25, FontStyle.Bold);
            System.Drawing.Font fTType = new System.Drawing.Font("Stencil", 50, FontStyle.Bold);
            SolidBrush sb = new SolidBrush(System.Drawing.Color.Black);

            g.DrawString("BuenViaje", fTType, sb, 10, 20);

            g.DrawString("-------------------------------", fBody1, sb, 10, 120);

            g.DrawString("Date :", fBody, sb, 10, SPACE);
            g.DrawString(viaje.Fecha.ToShortDateString(), fBody1, sb, 90, SPACE);

            g.DrawString("Time :", fBody, sb, 10, SPACE + 30);
            g.DrawString(viaje.Fecha.ToShortTimeString(), fBody1, sb, 90, SPACE + 30);

            g.DrawString("BusNo.:", fBody, sb, 10, SPACE + 60);
            g.DrawString(bus.Patente, fBody1, sb, 100, SPACE + 60);

            g.DrawString("Client:", fBody, sb, 10, SPACE + 90);
            g.DrawString(cliente.DNI, fBody1, sb, 100, SPACE + 90);

            g.DrawString("Route:", fBody, sb, 10, SPACE + 120);
            g.DrawString(ruta.Nombre, fBody1, sb, 100, SPACE + 120);

            g.DrawString("Sold:", fBody, sb, 10, SPACE + 150);
            g.DrawString(pasajebe.Fecha.ToShortDateString(), fBody1, sb, 100, SPACE + 150);

            g.DrawString("-------------------------------", fBody1, sb, 10, SPACE + 175);
        }

        #endregion Pasajes

        
    }
}
