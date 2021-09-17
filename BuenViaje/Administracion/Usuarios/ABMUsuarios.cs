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

            CargarGrillas();

            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);


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
                            foreach (ControlBE c in pControles)
                            {
                                if (c.ID_Control == InnerControl.Name)
                                {
                                    InnerControl.Text = c.Mensaje;
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
