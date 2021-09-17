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
using BE.Composite;
using BL;

namespace BuenViaje.Administracion.Usuarios
{
    public partial class ABMUsuarios : Form
    {
        internal Operacion operacion;
        internal UsuarioBE usuariobe;
        List<PatenteBE> patentesUsuario = new List<PatenteBE>();
        List<FamiliaBE> familiasUsuario = new List<FamiliaBE>();
        UsuarioBL usuarioBl = new UsuarioBL();
        PatenteBL patenteBl = new PatenteBL();
        FamiliaBL familiaBl = new FamiliaBL();

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
                    //Limpiar();
                    ListarPatentes();
                    //ListarFamilias();
                    ABMUsuariosComboIdioma.SelectedItem = 1;
                    break;
            }
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
            throw new NotImplementedException();
        }


        private void Limpiar()
        {
            throw new NotImplementedException();
        }

        private void ABMUsuariosBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMUsuariosBotton1_Click(object sender, EventArgs e)
        {

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
            List<PatenteBE> aux = new List<PatenteBE>();
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
    }
}
