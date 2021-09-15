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

namespace BuenViaje.Administracion.Usuarios
{
    public partial class UsuariosPrincipal : Form
    {
        public UsuariosPrincipal()
        {
            InitializeComponent();
        }

        private void UsuariosPrincipal_Load(object sender, EventArgs e)
        {
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-UsuarioID"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-UsuarioID"));
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-Nombre"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-Nombre"));
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-Apellido"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-Apellido"));
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-Usuario"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-Usuario"));
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-Logins"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-Logins"));
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-Languaje"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-Languaje"));
            grillaUsuarios.Columns[ObtenerMensajeColumna("UsuarioPrincipal-Columna-UsuarioID")].Visible = false;

            grillaUsuarios.EditMode = DataGridViewEditMode.EditProgrammatically;
            grillaUsuarios.AllowUserToAddRows = false;
            grillaUsuarios.AllowUserToDeleteRows = false;
            grillaUsuarios.AllowUserToResizeColumns = true;
            grillaUsuarios.AllowUserToResizeRows = false;
            grillaUsuarios.RowHeadersVisible = false;
            grillaUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grillaUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            ActualizarGrilla();
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
        }

        private void ActualizarGrilla()
        {
            grillaUsuarios.Rows.Clear();
            
            UsuarioBL usuariobl = new UsuarioBL();
            foreach (UsuarioBE usuariobe in usuariobl.Listar())
            {
                bool flag = true;
                if (this.UsuarioPrinciplaText1.Text != "" && this.UsuarioPrinciplaText1.Text != usuariobe.Nombre)
                {
                    flag = false;
                }
                if (this.UsuarioPrinciplaText2.Text != "" && this.UsuarioPrinciplaText2.Text != usuariobe.Apellido)
                {
                    flag = false;
                }
                if (this.UsuarioPrinciplaText3.Text != "" && this.UsuarioPrinciplaText3.Text != usuariobe.Nombre_Usuario)
                {
                    flag = false;
                }
                if (this.UsuarioPrinciplaText4.Text != "" && this.UsuarioPrinciplaText4.Text != usuariobe.Intentos_Login.ToString())
                {
                    flag = false;
                }
                if (this.UsuarioPrinciplaText5.Text != "" && this.UsuarioPrinciplaText5.Text != usuariobe.Idioma_Descripcion)
                {
                    flag = false;
                }
                if (flag)
                {
                    grillaUsuarios.Rows.Add(usuariobe.ID_Usuario, usuariobe.Nombre, usuariobe.Apellido, usuariobe.Nombre_Usuario, usuariobe.Intentos_Login, usuariobe.Idioma_Descripcion);
                }
                
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
            foreach (Control InnerControl in UsuarioPrincipalGroupBox.Controls)
            {
                foreach (ControlBE c in Lista)
                {
                    if (c.ID_Control == InnerControl.Name)
                    {
                        InnerControl.Text = c.Mensaje;
                    }
                }
            }
        }

        private string ObtenerMensajeColumna(string pstring)
        {
            return IdiomaBL.ObtenerMensajeTextos(pstring, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsuarioPrincipalBotton5_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void UsuarioPrincipalBotton6_Click(object sender, EventArgs e)
        {
            this.UsuarioPrinciplaText1.Text = "";
            this.UsuarioPrinciplaText2.Text = "";
            this.UsuarioPrinciplaText3.Text = "";
            this.UsuarioPrinciplaText4.Text = "";
            this.UsuarioPrinciplaText5.Text = "";
            ActualizarGrilla();
        }
    }
}
