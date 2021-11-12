using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BE;
using BE.Composite;
using BL;

namespace BuenViaje.Administracion.Permisos
{
    public partial class ABMPermisos : Form
    {
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        internal Operacion operacion;
        internal FamiliaBE familiabe;
        List<PatenteBE> patentesFamilia = new List<PatenteBE>();
        UsuarioBL usuarioBl = new UsuarioBL();
        PatenteBL patenteBl = new PatenteBL();
        FamiliaBL familiaBl = new FamiliaBL();
        BitacoraBL Bitacorabl = new BitacoraBL();

        public ABMPermisos()
        {
            InitializeComponent();
            ABMPermisoTextoNombre.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
            ABMPermisoTextoDescripcion.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
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

        private void ABMPermisos_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToParent();
            ABMPermisoGrillaPatente1.Columns.Add(ObtenerMensajeColumna("ABMPermiso-Columna-PatenteID"), ObtenerMensajeColumna("ABMPermiso-Columna-PatenteID"));
            ABMPermisoGrillaPatente1.Columns.Add(ObtenerMensajeColumna("ABMPermiso-Columna-PatenteNombre"), ObtenerMensajeColumna("ABMPermiso-Columna-PatenteNombre"));
            ABMPermisoGrillaPatente1.Columns[ObtenerMensajeColumna("ABMPermiso-Columna-PatenteID")].Visible = false;
            ABMPermisoGrillaPatente1.MultiSelect = false;
            ABMPermisoGrillaPatente1.EditMode = DataGridViewEditMode.EditProgrammatically;
            ABMPermisoGrillaPatente1.AllowUserToAddRows = false;
            ABMPermisoGrillaPatente1.AllowUserToDeleteRows = false;
            ABMPermisoGrillaPatente1.AllowUserToResizeColumns = true;
            ABMPermisoGrillaPatente1.AllowUserToResizeRows = false;
            ABMPermisoGrillaPatente1.RowHeadersVisible = false;
            ABMPermisoGrillaPatente1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ABMPermisoGrillaPatente1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ABMPermisoGrillaPatente1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            ABMPermisoGrillaPatente2.Columns.Add(ObtenerMensajeColumna("ABMPermiso-Columna-PatenteID"), ObtenerMensajeColumna("ABMPermiso-Columna-PatenteID"));
            ABMPermisoGrillaPatente2.Columns.Add(ObtenerMensajeColumna("ABMPermiso-Columna-PatenteNombre"), ObtenerMensajeColumna("ABMPermiso-Columna-PatenteNombre"));
            ABMPermisoGrillaPatente2.Columns[ObtenerMensajeColumna("ABMPermiso-Columna-PatenteID")].Visible = false;
            ABMPermisoGrillaPatente2.MultiSelect = false;
            ABMPermisoGrillaPatente2.EditMode = DataGridViewEditMode.EditProgrammatically;
            ABMPermisoGrillaPatente2.AllowUserToAddRows = false;
            ABMPermisoGrillaPatente2.AllowUserToDeleteRows = false;
            ABMPermisoGrillaPatente2.AllowUserToResizeColumns = true;
            ABMPermisoGrillaPatente2.AllowUserToResizeRows = false;
            ABMPermisoGrillaPatente2.RowHeadersVisible = false;
            ABMPermisoGrillaPatente2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ABMPermisoGrillaPatente2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ABMPermisoGrillaPatente2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            List<CompuestoBE> patentesUsuario = new List<CompuestoBE>();
            if (this.familiabe.ID_Compuesto != 0)
            {
                patentesFamilia = familiaBl.ListarPatentes(this.familiabe);
            }
            ABMPermisoBotton1.Enabled = false;
            CargarGrillas();

            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("ABMPermisos-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            SetToolTips();
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

        private string ObtenerMensajeColumna(string pstring)
        {
            return IdiomaBL.ObtenerMensajeTextos(pstring, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
        }

        private void CargarGrillas()
        {
            switch (this.operacion)
            {
                case Operacion.Alta:
                    Limpiar();
                    ListarPatentes();
                    break;
                case Operacion.Ver:
                    Limpiar();
                    ListarPatentes();
                    this.ABMPermisoTextoNombre.Text = this.familiabe.Nombre;
                    this.ABMPermisoTextoDescripcion.Text = this.familiabe.Descripcion;
                    DeshabilitarBotones();
                    this.ABMPermisoBotton1.Enabled = false;
                    break;
                case Operacion.Modificacion:
                    Limpiar();
                    ListarPatentes();
                    this.ABMPermisoTextoNombre.Text = this.familiabe.Nombre;
                    this.ABMPermisoTextoDescripcion.Text = this.familiabe.Descripcion;
                    break;
                case Operacion.Baja:
                    Limpiar();
                    ListarPatentes();
                    this.ABMPermisoTextoNombre.Text = this.familiabe.Nombre;
                    this.ABMPermisoTextoDescripcion.Text = this.familiabe.Descripcion;
                    DeshabilitarBotones();
                    break;
            }
        }

        private void DeshabilitarBotones()
        {
            this.ABMPermisoTextoNombre.Enabled = false;
            this.ABMPermisoTextoDescripcion.Enabled = false;
            this.ABMPermisoBotton3.Enabled = false;
            this.ABMPermisoBotton4.Enabled = false;
        }

        private void Limpiar()
        {
            this.ABMPermisoTextoNombre.Text = "";
            this.ABMPermisoTextoDescripcion.Text = "";
        }

        private void ListarPatentes()
        {
            ABMPermisoGrillaPatente1.Rows.Clear();
            ABMPermisoGrillaPatente2.Rows.Clear();
            List<PatenteBE> patentes = patenteBl.Listar();

            foreach (PatenteBE patente in patentes)
            {
                bool flag = false;
                foreach (PatenteBE patenteFamilia in this.patentesFamilia)
                {
                    if (patente.ID_Compuesto == patenteFamilia.ID_Compuesto)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    ABMPermisoGrillaPatente1.Rows.Add(patente.ID_Compuesto, patente.Nombre);
                }
            }
            foreach (PatenteBE patenteFamilia in patentesFamilia)
            {
                ABMPermisoGrillaPatente2.Rows.Add(patenteFamilia.ID_Compuesto, patenteFamilia.Nombre);
            }

            if (ABMPermisoGrillaPatente1.Rows.Count == 0)
            {
                ABMPermisoBotton3.Enabled = false;
            }
            else
            {
                ABMPermisoBotton3.Enabled = true;
            }
            if (ABMPermisoGrillaPatente2.Rows.Count == 0)
            {
                ABMPermisoBotton4.Enabled = false;
            }
            else
            {
                ABMPermisoBotton4.Enabled = true;
            }
        }

        private void ABMPermisoBotton1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            BitacoraBE mBitacora = new BitacoraBE();
            //Boton Aplicar
            try
            {
                switch (this.operacion)
                {
                    case Operacion.Alta:
                        if (!ValidarNombre())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMPermisos-Validacion-Nombre", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarDescripcion())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMPermisos-Validacion-Nombre", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.familiabe.Nombre = this.ABMPermisoTextoNombre.Text;
                        this.familiabe.Descripcion = this.ABMPermisoTextoDescripcion.Text;
                        //foreach (PatenteBE patente in this.patentesFamilia)
                        //{
                        //    this.familiabe.AgregarPermiso(patente);
                        //}
                        familiaBl.Guardar(familiabe);
                        //Bitacora
                        mBitacora.Descripcion = "Se dio de alta a la familia: " + this.familiabe.Nombre;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.Nombre_Usuario = SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        Bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Modificacion:
                        if (!ValidarNombre())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMPermisos-Validacion-Nombre", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarDescripcion())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMPermisos-Validacion-Nombre", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.familiabe.Nombre = this.ABMPermisoTextoNombre.Text;
                        this.familiabe.Descripcion = this.ABMPermisoTextoDescripcion.Text;
                        //foreach (PatenteBE patente in this.patentesFamilia)
                        //{
                        //    this.familiabe.AgregarPermiso(patente);
                        //}
                        familiaBl.Guardar(familiabe);
                        //Bitacora
                        mBitacora.Descripcion = "Se modifico a a la familia: " + this.familiabe.Nombre;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.Nombre_Usuario = SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        Bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Baja:
                        DialogResult result = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMPermisos-Confirmacion-Baja", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.familiaBl.Eliminar(this.familiabe);

                        }
                        //Bitacora
                        mBitacora.Descripcion = "Se elimino a la familia: " + this.familiabe.Nombre;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.Nombre_Usuario = SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                        mBitacora.Tipo_Evento = "HIGH";
                        Bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                }
                if (flag)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                BitacoraBL Bitacorabl = new BitacoraBL();
                mBitacora.Descripcion = "Error al operar con permisos";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.Nombre_Usuario = SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMPermiso-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private bool ValidarNombre()
        {
            bool output = !(this.ABMPermisoTextoNombre.Text.Length > 50 || !Regex.IsMatch(this.ABMPermisoTextoNombre.Text, @"^[a-zA-Z\s]+$"));
            if (output)
            {
                List<FamiliaBE> familias = familiaBl.Listar();
                foreach (FamiliaBE familia in familias)
                {
                    if (familia.ID_Compuesto != this.familiabe.ID_Compuesto && familia.Nombre == this.ABMPermisoTextoNombre.Text)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
            
        }

        private bool ValidarDescripcion()
        {
            return !(this.ABMPermisoTextoDescripcion.Text.Length > 50 || !Regex.IsMatch(this.ABMPermisoTextoDescripcion.Text, @"^[a-zA-Z\s]+$"));
        }

        private void ABMPermisoBotton3_Click(object sender, EventArgs e)
        {
            PatenteBE patente = patenteBl.Obtener(int.Parse(ABMPermisoGrillaPatente1.SelectedRows[0].Cells[0].Value.ToString()));
            familiabe.AgregarPermiso(patente);
            patentesFamilia.Add(patente);
            ListarPatentes();
        }

        private void ABMPermisoBotton4_Click(object sender, EventArgs e)
        {
            PatenteBE patente = patenteBl.Obtener(int.Parse(ABMPermisoGrillaPatente2.SelectedRows[0].Cells[0].Value.ToString()));
            List<PatenteBE> aux = new List<PatenteBE>();
            foreach (PatenteBE p in patentesFamilia)
            {
                if (p.ID_Compuesto != patente.ID_Compuesto)
                {
                    aux.Add(p);
                }
            }
            familiabe.QuitarPermiso((CompuestoBE)patente);
            this.patentesFamilia = aux;
            //patentesUsuario.Remove(patente);
            ListarPatentes();
        }

        private void ABMPermisoTextoNombre_TextChanged(object sender, EventArgs e)
        {
            if (ABMPermisoTextoNombre.Text.Length > 0 && ABMPermisoTextoDescripcion.Text.Length > 0)
            {
                ABMPermisoBotton1.Enabled = true;
            }
            else
            {
                ABMPermisoBotton1.Enabled = false;
            }
        }

        private void ABMPermisoTextoDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (ABMPermisoTextoNombre.Text.Length > 0 && ABMPermisoTextoDescripcion.Text.Length > 0)
            {
                ABMPermisoBotton1.Enabled = true;
            }
            else
            {
                ABMPermisoBotton1.Enabled = false;
            }
        }

        private void ABMPermisoBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
