using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;
using BuenViaje;
using BuenViaje.Administracion;
using BE;
using BE.Composite;
using BL;

namespace BuenViaje.Administracion.Usuarios
{
    public partial class ABMUsuarios : Form
    {
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        internal Operacion operacion;
        internal UsuarioBE usuariobe;
        List<CompuestoBE> patentesUsuario = new List<CompuestoBE>();
        List<CompuestoBE> familiasUsuario = new List<CompuestoBE>();
        UsuarioBL usuarioBl = new UsuarioBL();
        PatenteBL patenteBl = new PatenteBL();
        FamiliaBL familiaBl = new FamiliaBL();
        BitacoraBL Bitacorabl = new BitacoraBL();

        public ABMUsuarios()
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

        private void ABMUsuarios_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToParent();
            #region Configuracion Grilla 

            ABMUsuariosGrillaFamilia1.Columns.Add(ObtenerMensajeColumna("ABMUSuarios-Columna-FamiliaID"), ObtenerMensajeColumna("ABMUSuarios-Columna-FamiliaID"));
            ABMUsuariosGrillaFamilia1.Columns.Add(ObtenerMensajeColumna("ABMUSuarios-Columna-FamiliaNombre"), ObtenerMensajeColumna("ABMUSuarios-Columna-FamiliaNombre"));
            ABMUsuariosGrillaFamilia1.Columns[ObtenerMensajeColumna("ABMUSuarios-Columna-FamiliaID")].Visible = false;
            ABMUsuariosGrillaFamilia1.MultiSelect = false;
            ABMUsuariosGrillaFamilia1.EditMode = DataGridViewEditMode.EditProgrammatically;
            ABMUsuariosGrillaFamilia1.AllowUserToAddRows = false;
            ABMUsuariosGrillaFamilia1.AllowUserToDeleteRows = false;
            ABMUsuariosGrillaFamilia1.AllowUserToResizeColumns = true;
            ABMUsuariosGrillaFamilia1.AllowUserToResizeRows = false;
            ABMUsuariosGrillaFamilia1.RowHeadersVisible = false;
            ABMUsuariosGrillaFamilia1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ABMUsuariosGrillaFamilia1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ABMUsuariosGrillaFamilia1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            ABMUsuariosGrillaFamilia2.Columns.Add(ObtenerMensajeColumna("ABMUSuarios-Columna-FamiliaID"), ObtenerMensajeColumna("ABMUSuarios-Columna-FamiliaID"));
            ABMUsuariosGrillaFamilia2.Columns.Add(ObtenerMensajeColumna("ABMUSuarios-Columna-FamiliaNombre"), ObtenerMensajeColumna("ABMUSuarios-Columna-FamiliaNombre"));
            ABMUsuariosGrillaFamilia2.Columns[ObtenerMensajeColumna("ABMUSuarios-Columna-FamiliaID")].Visible = false;
            ABMUsuariosGrillaFamilia2.MultiSelect = false;
            ABMUsuariosGrillaFamilia2.EditMode = DataGridViewEditMode.EditProgrammatically;
            ABMUsuariosGrillaFamilia2.AllowUserToAddRows = false;
            ABMUsuariosGrillaFamilia2.AllowUserToDeleteRows = false;
            ABMUsuariosGrillaFamilia2.AllowUserToResizeColumns = true;
            ABMUsuariosGrillaFamilia2.AllowUserToResizeRows = false;
            ABMUsuariosGrillaFamilia2.RowHeadersVisible = false;
            ABMUsuariosGrillaFamilia2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ABMUsuariosGrillaFamilia2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ABMUsuariosGrillaFamilia2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            ABMUsuariosGrillaPatente1.Columns.Add(ObtenerMensajeColumna("ABMUSuarios-Columna-PatenteID"), ObtenerMensajeColumna("ABMUSuarios-Columna-PatenteID"));
            ABMUsuariosGrillaPatente1.Columns.Add(ObtenerMensajeColumna("ABMUSuarios-Columna-PatenteNombre"), ObtenerMensajeColumna("ABMUSuarios-Columna-PatenteNombre"));
            ABMUsuariosGrillaPatente1.Columns[ObtenerMensajeColumna("ABMUSuarios-Columna-PatenteID")].Visible = false;
            ABMUsuariosGrillaPatente1.MultiSelect = false;
            ABMUsuariosGrillaPatente1.EditMode = DataGridViewEditMode.EditProgrammatically;
            ABMUsuariosGrillaPatente1.AllowUserToAddRows = false;
            ABMUsuariosGrillaPatente1.AllowUserToDeleteRows = false;
            ABMUsuariosGrillaPatente1.AllowUserToResizeColumns = true;
            ABMUsuariosGrillaPatente1.AllowUserToResizeRows = false;
            ABMUsuariosGrillaPatente1.RowHeadersVisible = false;
            ABMUsuariosGrillaPatente1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ABMUsuariosGrillaPatente1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ABMUsuariosGrillaPatente1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            ABMUsuariosGrillaPatente2.Columns.Add(ObtenerMensajeColumna("ABMUSuarios-Columna-PatenteID"), ObtenerMensajeColumna("ABMUSuarios-Columna-PatenteID"));
            ABMUsuariosGrillaPatente2.Columns.Add(ObtenerMensajeColumna("ABMUSuarios-Columna-PatenteNombre"), ObtenerMensajeColumna("ABMUSuarios-Columna-PatenteNombre"));
            ABMUsuariosGrillaPatente2.Columns[ObtenerMensajeColumna("ABMUSuarios-Columna-PatenteID")].Visible = false;
            ABMUsuariosGrillaPatente2.MultiSelect = false;
            ABMUsuariosGrillaPatente2.EditMode = DataGridViewEditMode.EditProgrammatically;
            ABMUsuariosGrillaPatente2.AllowUserToAddRows = false;
            ABMUsuariosGrillaPatente2.AllowUserToDeleteRows = false;
            ABMUsuariosGrillaPatente2.AllowUserToResizeColumns = true;
            ABMUsuariosGrillaPatente2.AllowUserToResizeRows = false;
            ABMUsuariosGrillaPatente2.RowHeadersVisible = false;
            ABMUsuariosGrillaPatente2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ABMUsuariosGrillaPatente2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ABMUsuariosGrillaPatente2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            #endregion

            

            ABMUsuariosComboIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (IdiomaBE mIdioma in IdiomaBL.ListarIdiomas())
            {
                ABMUsuariosComboIdioma.Items.Add(mIdioma.Descripcion);
            }

            #region Obtener permisos
            List<CompuestoBE> patentesUsuario = new List<CompuestoBE>();
            if (this.usuariobe.ID_Usuario != 0)
            {
                patentesUsuario = usuarioBl.ObtenerPatentes(this.usuariobe);
            }
            #endregion

            CargarGrillas();
    
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
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
            this.patentesUsuario = this.usuarioBl.ObtenerPatentes(this.usuariobe);
            this.familiasUsuario = this.usuarioBl.ObtenerFamilias(this.usuariobe);
            switch (this.operacion)
            {
                case Operacion.Alta:
                    Limpiar();
                    ListarPatentes();
                    ListarFamilias();
                    ABMUsuariosComboIdioma.SelectedItem = 1;
                    ABMUsuariosComboIdioma.SelectedIndex = 1;
                    break;
                case Operacion.Ver:
                    Limpiar();
                    ListarPatentes();
                    ListarFamilias();
                    this.ABMUsuariosComboIdioma.SelectedIndex = usuariobe.ID_Idioma -1;
                    this.ABMUsuariosTextoNombre.Text = this.usuariobe.Nombre;
                    this.ABMUsuariosTextoApellido.Text = this.usuariobe.Apellido;
                    this.ABMUsuariosTextoUsuario.Text = this.usuariobe.Nombre_Usuario;
                    DeshabilitarBotones();
                    this.ABMUsuariosBotton1.Enabled = false;
                    break;
                case Operacion.Modificacion:
                    Limpiar();
                    ListarPatentes();
                    ListarFamilias();
                    this.ABMUsuariosComboIdioma.SelectedIndex = usuariobe.ID_Idioma - 1;
                    this.ABMUsuariosTextoNombre.Text = this.usuariobe.Nombre;
                    this.ABMUsuariosTextoApellido.Text = this.usuariobe.Apellido;
                    this.ABMUsuariosTextoUsuario.Text = this.usuariobe.Nombre_Usuario;
                    break;
                case Operacion.Baja:
                    Limpiar();
                    ListarPatentes();
                    ListarFamilias();
                    this.ABMUsuariosComboIdioma.SelectedIndex = usuariobe.ID_Idioma - 1;
                    this.ABMUsuariosTextoNombre.Text = this.usuariobe.Nombre;
                    this.ABMUsuariosTextoApellido.Text = this.usuariobe.Apellido;
                    this.ABMUsuariosTextoUsuario.Text = this.usuariobe.Nombre_Usuario;
                    DeshabilitarBotones();
                    break;
            }
        }

        private void ABMUsuariosBotton1_Click(object sender, EventArgs e)
        {
            
            bool flag = false;
            int idiomaId = 0;
            BitacoraBE mBitacora = new BitacoraBE();
            try 
            {
                switch (this.operacion)
                {
                    case Operacion.Alta:
                        if (!ValidarClave())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Validacion-Clave", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarUsuarioUnico())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Validacion-UsuarioUnico", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarUsuarioMail())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Validacion-UsuarioMail", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarNombre())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Validacion-Nombre", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        //Valorizamos entidad
                        this.usuariobe.Nombre = this.ABMUsuariosTextoNombre.Text;
                        this.usuariobe.Apellido = this.ABMUsuariosTextoApellido.Text;
                        this.usuariobe.Nombre_Usuario = this.ABMUsuariosTextoUsuario.Text;
                        this.usuariobe.Contrasenia = this.ABMUsuariosTextoClave.Text;
                        this.usuariobe.Idioma_Descripcion = this.ABMUsuariosComboIdioma.SelectedItem.ToString();
                        idiomaId = 0;
                        foreach (IdiomaBE idioma in IdiomaBL.ListarIdiomas())
                        {
                            if (idioma.Descripcion == this.usuariobe.Idioma_Descripcion)
                            {
                                idiomaId = idioma.ID_Idioma;
                            }
                        }
                        this.usuariobe.ID_Idioma = idiomaId;
                        this.usuariobe.Permisos = new List<CompuestoBE>();
                        this.usuariobe.Permisos.AddRange(this.familiasUsuario);
                        this.usuariobe.Permisos.AddRange(this.patentesUsuario);
                        this.usuarioBl.Guardar(usuariobe);
                        //Bitacora
                        mBitacora.Descripcion = "Se dio de alta al usuario: " + this.usuariobe.Nombre_Usuario;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        Bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Modificacion:
                        if (this.ABMUsuariosTextoClave.Text.Length != 0)
                        {
                            if (!ValidarClave())
                            {
                                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Validacion-Clave", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            this.usuariobe.Contrasenia = this.ABMUsuariosTextoClave.Text;
                        }
                        if (!ValidarUsuarioUnico())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Validacion-UsuarioUnico", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarUsuarioMail())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Validacion-UsuarioMail", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarNombre())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Validacion-Nombre", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        //Valorizamos entidad
                        this.usuariobe.Nombre = this.ABMUsuariosTextoNombre.Text;
                        this.usuariobe.Apellido = this.ABMUsuariosTextoApellido.Text;
                        this.usuariobe.Nombre_Usuario = this.ABMUsuariosTextoUsuario.Text;
                        this.usuariobe.Idioma_Descripcion = this.ABMUsuariosComboIdioma.SelectedItem.ToString();
                        idiomaId = 0;
                        foreach (IdiomaBE idioma in IdiomaBL.ListarIdiomas())
                        {
                            if (idioma.Descripcion == this.usuariobe.Idioma_Descripcion)
                            {
                                idiomaId = idioma.ID_Idioma;
                            }
                        }
                        this.usuariobe.ID_Idioma = idiomaId;
                        this.usuariobe.Permisos = new List<CompuestoBE>();
                        this.usuariobe.Permisos.AddRange(this.familiasUsuario);
                        this.usuariobe.Permisos.AddRange(this.patentesUsuario);
                        this.usuarioBl.Guardar(usuariobe);
                        //Bitacora
                        mBitacora.Descripcion = "Se modifico al usuario: " + this.usuariobe.Nombre_Usuario;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        Bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Baja:
                        DialogResult result = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Confirmacion-Baja", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.usuarioBl.Eliminar(this.usuariobe);

                        }
                        //Bitacora
                        mBitacora.Descripcion = "Se elimino al usuario: " + this.usuariobe.Nombre_Usuario;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                        mBitacora.Tipo_Evento = "HIGH";
                        Bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Ver:
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
                mBitacora.Descripcion = "Error al operar con usuarios";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuario-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
            //Boton Aplicar
            
        }
        private void ABMUsuariosBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeshabilitarBotones()
        {
            this.ABMUsuariosComboIdioma.Enabled = false;
            this.ABMUsuariosTextoNombre.Enabled = false;
            this.ABMUsuariosTextoApellido.Enabled = false;
            this.ABMUsuariosTextoUsuario.Enabled = false;
            this.ABMUsuariosTextoClave.Enabled = false;
            this.ABMUsuariosBotton3.Enabled = false;
            this.ABMUsuariosBotton4.Enabled = false;
            this.ABMUsuariosBotton5.Enabled = false;
            this.ABMUsuariosBotton6.Enabled = false;
        }

        private void Limpiar()
        {
            this.ABMUsuariosTextoNombre.Text = "";
            this.ABMUsuariosTextoApellido.Text = "";
            this.ABMUsuariosTextoUsuario.Text = "";
            this.ABMUsuariosTextoClave.Text = "";
        }

        private void ListarPatentes()
        {
            ABMUsuariosGrillaPatente1.Rows.Clear();
            ABMUsuariosGrillaPatente2.Rows.Clear();
            List<PatenteBE> patentes = patenteBl.Listar();

            foreach (PatenteBE patente in patentes)
            {
                bool flag = false;
                foreach (PatenteBE patenteUsuario in patentesUsuario)
                {
                    if (patente.ID_Compuesto == patenteUsuario.ID_Compuesto)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    ABMUsuariosGrillaPatente1.Rows.Add(patente.ID_Compuesto, patente.Nombre);
                }
            }
            foreach (PatenteBE patenteUsuario in patentesUsuario)
            {
                ABMUsuariosGrillaPatente2.Rows.Add(patenteUsuario.ID_Compuesto, patenteUsuario.Nombre);
            }

            if (ABMUsuariosGrillaPatente1.Rows.Count == 0)
            {
                ABMUsuariosBotton5.Enabled = false;
            }
            else
            {
                ABMUsuariosBotton5.Enabled = true;
            }
            if (ABMUsuariosGrillaPatente2.Rows.Count == 0)
            {
                ABMUsuariosBotton6.Enabled = false;
            }
            else
            {
                ABMUsuariosBotton6.Enabled = true;
            }
        }

        private void ListarFamilias()
        {
            ABMUsuariosGrillaFamilia1.Rows.Clear();
            ABMUsuariosGrillaFamilia2.Rows.Clear();
            List<FamiliaBE> familias = familiaBl.Listar();

            foreach (FamiliaBE familia in familias)
            {
                bool flag = false;
                foreach (FamiliaBE familiaUsuario in familiasUsuario)
                {
                    if (familia.ID_Compuesto == familiaUsuario.ID_Compuesto)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    ABMUsuariosGrillaFamilia1.Rows.Add(familia.ID_Compuesto, familia.Nombre);
                }
            }
            foreach (FamiliaBE familiaUsuario in familiasUsuario)
            {
                ABMUsuariosGrillaFamilia2.Rows.Add(familiaUsuario.ID_Compuesto, familiaUsuario.Nombre);
            }

            if (ABMUsuariosGrillaFamilia1.Rows.Count == 0)
            {
                ABMUsuariosBotton3.Enabled = false;
            }
            else
            {
                ABMUsuariosBotton3.Enabled = true;
            }
            if (ABMUsuariosGrillaFamilia2.Rows.Count == 0)
            {
                ABMUsuariosBotton4.Enabled = false;
            }
            else
            {
                ABMUsuariosBotton4.Enabled = true;
            }
        }

        private bool ValidarClave()
        {
            string Password = this.ABMUsuariosTextoClave.Text;
            string regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            return Regex.Match(Password, regex).Success;

        }

        private bool ValidarUsuarioUnico()
        {
            List<UsuarioBE> usuarios = usuarioBl.Listar();
            switch (this.operacion)
            {
                case Operacion.Alta:
                    return !(usuarios.Any(item => item.Nombre_Usuario == this.ABMUsuariosTextoUsuario.Text));
                case Operacion.Modificacion:
                    foreach (UsuarioBE user in usuarios)
                    {
                        if (user.Nombre_Usuario == this.ABMUsuariosTextoUsuario.Text)
                        {
                            if (user.ID_Usuario != this.usuariobe.ID_Usuario)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    return true;
                default:
                    return true;
            }
        }

        private bool ValidarUsuarioMail()
        {
            try
            {
                MailAddress m = new MailAddress(ABMUsuariosTextoUsuario.Text);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool ValidarNombre()
        {
            return !(this.ABMUsuariosTextoNombre.Text.Length > 50 || this.ABMUsuariosTextoApellido.Text.Length > 50);
        }

        private void ABMUsuariosBotton5_Click(object sender, EventArgs e)
        {
            PatenteBE patente = patenteBl.Obtener(int.Parse(ABMUsuariosGrillaPatente1.SelectedRows[0].Cells[0].Value.ToString()));
            patentesUsuario.Add(patente);
            ListarPatentes();
        }

        private void ABMUsuariosBotton6_Click(object sender, EventArgs e)
        {
            PatenteBE patente = patenteBl.Obtener(int.Parse(ABMUsuariosGrillaPatente2.SelectedRows[0].Cells[0].Value.ToString()));
            List<CompuestoBE> aux = new List<CompuestoBE>();
            foreach (PatenteBE p in patentesUsuario)
            {
                if (p.ID_Compuesto != patente.ID_Compuesto)
                {
                    aux.Add(p);
                }
            }
            this.patentesUsuario = aux;
            //patentesUsuario.Remove(patente);
            ListarPatentes();
        }

        private void ABMUsuariosBotton3_Click(object sender, EventArgs e)
        {
            FamiliaBE familia = familiaBl.Obtener(int.Parse(ABMUsuariosGrillaFamilia1.SelectedRows[0].Cells[0].Value.ToString()));
            familiasUsuario.Add(familia);
            ListarFamilias();
        }

        private void ABMUsuariosBotton4_Click(object sender, EventArgs e)
        {
            FamiliaBE familia = familiaBl.Obtener(int.Parse(ABMUsuariosGrillaFamilia2.SelectedRows[0].Cells[0].Value.ToString()));
            List<CompuestoBE> aux = new List<CompuestoBE>();
            foreach (FamiliaBE p in familiasUsuario)
            {
                if (p.ID_Compuesto != familia.ID_Compuesto)
                {
                    aux.Add(p);
                }
            }
            this.familiasUsuario = aux;
            //patentesUsuario.Remove(patente);
            ListarFamilias();
        }
    }
}
