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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToParent();
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-UsuarioID"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-UsuarioID"));
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-Nombre"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-Nombre"));
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-Apellido"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-Apellido"));
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-Usuario"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-Usuario"));
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-Logins"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-Logins"));
            grillaUsuarios.Columns.Add(ObtenerMensajeColumna("UsuarioPrincipal-Columna-Languaje"), ObtenerMensajeColumna("UsuarioPrincipal-Columna-Languaje"));
            grillaUsuarios.Columns[ObtenerMensajeColumna("UsuarioPrincipal-Columna-UsuarioID")].Visible = false;

            grillaUsuarios.MultiSelect = false;
            grillaUsuarios.EditMode = DataGridViewEditMode.EditProgrammatically;
            grillaUsuarios.AllowUserToAddRows = false;
            grillaUsuarios.AllowUserToDeleteRows = false;
            grillaUsuarios.AllowUserToResizeColumns = true;
            grillaUsuarios.AllowUserToResizeRows = false;
            grillaUsuarios.RowHeadersVisible = false;
            grillaUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grillaUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminUsuarios))
            {
                UsuarioPrincipalBotton2.Enabled = true;
                UsuarioPrincipalBotton3.Enabled = true;
                UsuarioPrincipalBotton4.Enabled = true;
                UsuarioPrincipalBotton7.Enabled = true;
            }
            else
            {
                UsuarioPrincipalBotton2.Enabled = false;
                UsuarioPrincipalBotton3.Enabled = false;
                UsuarioPrincipalBotton4.Enabled = false;
                UsuarioPrincipalBotton7.Enabled = false;
            }

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

        private void UsuarioPrincipalBotton2_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.Instancia.VerificarPermiso(TipoPermiso.AdminUsuarios))
            {
                UsuarioBL usuariobl = new UsuarioBL();
                ABMUsuarios abmusuarios = new ABMUsuarios();
                abmusuarios.operacion = Operacion.Alta;
                //abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].ToString());
                abmusuarios.usuariobe = new UsuarioBE();
                abmusuarios.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("UsuarioPrincipal-Permiso-Usuario-Denegado", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UsuarioPrincipalBotton1_Click(object sender, EventArgs e)
        {
            UsuarioBL usuariobl = new UsuarioBL();
            ABMUsuarios abmusuarios = new ABMUsuarios();
            abmusuarios.operacion = Operacion.Ver;
            abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].Value.ToString());
            abmusuarios.ShowDialog();
            ActualizarGrilla();
        }

        private void UsuarioPrincipalBotton3_Click(object sender, EventArgs e)
        {
            UsuarioBL usuariobl = new UsuarioBL();
            ABMUsuarios abmusuarios = new ABMUsuarios();
            abmusuarios.operacion = Operacion.Modificacion;
            abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].Value.ToString());
            abmusuarios.ShowDialog();
            ActualizarGrilla();
        }

        private void UsuarioPrincipalBotton4_Click(object sender, EventArgs e)
        {
            UsuarioBL usuariobl = new UsuarioBL();
            ABMUsuarios abmusuarios = new ABMUsuarios();
            abmusuarios.operacion = Operacion.Baja;
            abmusuarios.usuariobe = usuariobl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].Value.ToString());
            abmusuarios.usuariobe.Permisos = usuariobl.ObtenerPermisos(abmusuarios.usuariobe);
            abmusuarios.ShowDialog();
            ActualizarGrilla();
        }

        private void UsuarioPrincipalBotton7_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBL usuarioBl = new UsuarioBL();
                BitacoraBE mBitacora = new BitacoraBE();
                BitacoraBL Bitacorabl = new BitacoraBL();
                UsuarioBE usuariobe = usuarioBl.Obtener(grillaUsuarios.SelectedRows[0].Cells[3].Value.ToString());
                usuariobe.Permisos = usuarioBl.ObtenerPermisos(usuariobe);
                DialogResult result = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuarios-Validacion-Resetear", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    usuarioBl.ResetarConstrasenia(usuariobe);
                }
                //Bitacora
                mBitacora.Descripcion = "Se cambio la clave al usuario: " + usuariobe.Nombre_Usuario;
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
            }
            catch(Exception ex)
            {
                BitacoraBL Bitacorabl = new BitacoraBL();
                BitacoraBE mBitacora = new BitacoraBE();
                mBitacora.Descripcion = "Error al resetear password";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = 0;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMUsuario-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }
    }
}
