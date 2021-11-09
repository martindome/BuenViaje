using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using BE;
using BE.Composite;

namespace BuenViaje.Administracion.Permisos
{
    public partial class PermisosPrincipal : Form
    {
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        FamiliaBL familiabl = new FamiliaBL();
        PatenteBL patentebl = new PatenteBL();

        public PermisosPrincipal()
        {
            InitializeComponent();

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

        private void textBox_HelpRequested(object sender, System.Windows.Forms.HelpEventArgs hlpevent)
        {
            // This event is raised when the F1 key is pressed or the
            // Help cursor is clicked on any of the address fields.
            // The Help text for the field is in the control's
            // Tag property. It is retrieved and displayed in the label.

            Control requestingControl = (Control)sender;
            string message = IdiomaBL.ObtenerMensajeTextos(requestingControl.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            if (message != "")
            {
                MessageBox.Show(message);
                hlpevent.Handled = true;
            }
        }

        private void PermisosPrincipal_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToParent();
            grillaFamilias.Columns.Add(ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaID"), ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaID"));
            grillaFamilias.Columns.Add(ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaNombre"), ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaNombre"));
            grillaFamilias.Columns.Add(ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaDescripcion"), ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaDescripcion"));
            grillaFamilias.Columns[ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaID")].Visible = false;


            grillaFamilias.MultiSelect = false;
            grillaFamilias.EditMode = DataGridViewEditMode.EditProgrammatically;
            grillaFamilias.AllowUserToAddRows = false;
            grillaFamilias.AllowUserToDeleteRows = false;
            grillaFamilias.AllowUserToResizeColumns = true;
            grillaFamilias.AllowUserToResizeRows = false;
            grillaFamilias.RowHeadersVisible = false;
            grillaFamilias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaFamilias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grillaFamilias.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminPermisos))
            {
                PermisosPrincipalBotton2.Enabled = true;
                PermisosPrincipalBotton3.Enabled = true;
                PermisosPrincipalBotton4.Enabled = true;
            }
            else
            {
                PermisosPrincipalBotton2.Enabled = false;
                PermisosPrincipalBotton3.Enabled = false;
                PermisosPrincipalBotton4.Enabled = false;
            }

            ActualizarGrilla();
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("PermisosPrincipal-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            SetToolTips();
        }

        private string ObtenerMensajeColumna(string pstring)
        {
            return IdiomaBL.ObtenerMensajeTextos(pstring, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
        }

        private void ActualizarGrilla()
        {
            List<FamiliaBE> familias = familiabl.Listar();
            List<PatenteBE> patentes = patentebl.Listar();
            grillaFamilias.Rows.Clear();
            foreach (FamiliaBE familia in familias)
            {
                bool flag = true;
                if (this.PermisosPrinciplaText1.Text != "" && this.PermisosPrinciplaText1.Text != familia.Nombre)
                {
                    flag = false;
                }
                if (this.PermisosPrinciplaText2.Text != "" && this.PermisosPrinciplaText2.Text != familia.Descripcion)
                {
                    flag = false;
                }
                if (flag)
                {
                    grillaFamilias.Rows.Add(familia.ID_Compuesto, familia.Nombre, familia.Descripcion);
                }
            }

        }
        private void CargarIdioma(List<ControlBE> pControles)
        {
            foreach (Control C in this.Controls)
            {
                foreach (ControlBE pControl in pControles)
                {
                    if (pControl.ID_Control == C.Name)
                    {
                        C.Text = pControl.Mensaje;
                        break;
                    }
                    if (C is GroupBox)
                    {
                        foreach (Control InnerControl in C.Controls)
                        {
                            foreach (ControlBE InnerC in pControles)
                            {
                                if (InnerC.ID_Control == InnerControl.Name)
                                {
                                    InnerControl.Text = InnerC.Mensaje;
                                }
                                if (InnerControl is GroupBox)
                                {
                                    foreach (Control DoubleInnerControl in InnerControl.Controls)
                                    {
                                        foreach (ControlBE DoubleInnerC in pControles)
                                        {
                                            if (DoubleInnerC.ID_Control == DoubleInnerControl.Name)
                                            {
                                                DoubleInnerControl.Text = DoubleInnerC.Mensaje;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PermisosPrincipalBotton5_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void PermisosPrincipalBotton6_Click(object sender, EventArgs e)
        {
            this.PermisosPrinciplaText1.Text = "";
            this.PermisosPrinciplaText2.Text = "";
            ActualizarGrilla();
        }

        private void PermisosPrincipalBotton1_Click(object sender, EventArgs e)
        {
            FamiliaBL familiabl = new FamiliaBL();
            ABMPermisos abmpermisos = new ABMPermisos();
            abmpermisos.operacion = Operacion.Ver;
            abmpermisos.familiabe = familiabl.Obtener(int.Parse(this.grillaFamilias.SelectedRows[0].Cells[0].Value.ToString()));
            abmpermisos.ShowDialog();
            ActualizarGrilla();
        }

        private void PermisosPrincipalBotton2_Click(object sender, EventArgs e)
        {
            FamiliaBL familiabl = new FamiliaBL();
            ABMPermisos abmpermisos = new ABMPermisos();
            abmpermisos.operacion = Operacion.Alta;
            abmpermisos.familiabe = new FamiliaBE();
            abmpermisos.ShowDialog();
            ActualizarGrilla();
        }

        private void PermisosPrincipalBotton3_Click(object sender, EventArgs e)
        {
            FamiliaBL familiabl = new FamiliaBL();
            ABMPermisos abmpermisos = new ABMPermisos();
            abmpermisos.operacion = Operacion.Modificacion;
            abmpermisos.familiabe = familiabl.Obtener(int.Parse(this.grillaFamilias.SelectedRows[0].Cells[0].Value.ToString()));
            abmpermisos.ShowDialog();
            ActualizarGrilla();
        }

        private void PermisosPrincipalBotton4_Click(object sender, EventArgs e)
        {
            FamiliaBL familiabl = new FamiliaBL();
            ABMPermisos abmpermisos = new ABMPermisos();
            abmpermisos.operacion = Operacion.Baja;
            abmpermisos.familiabe = familiabl.Obtener(int.Parse(this.grillaFamilias.SelectedRows[0].Cells[0].Value.ToString()));
            abmpermisos.ShowDialog();
            ActualizarGrilla();
        }
    }
}
