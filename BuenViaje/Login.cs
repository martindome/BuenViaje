using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BL;
using BE;

namespace BuenViaje
{
    public partial class Login : Form
    {
        LoginBL Loginbl = new LoginBL();
        UsuarioBL Usuariobl = new UsuarioBL();
        string mIdioma;

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton1_Click(object sender, EventArgs e)
        {
            UsuarioBE pUsuario = new UsuarioBE();
            pUsuario.Nombre_Usuario = txtUser.Text;
            try
            {
                Loginbl.ValidarLogin(txtUser.Text, txtPass.Text);
                Principal mPrincipal = new Principal();
                mPrincipal.MinimizeBox = false;
                mPrincipal.MaximizeBox = false;
                mPrincipal.StartPosition = FormStartPosition.CenterParent;
                //SingletonSesion.Instancia = Usuariobl.Obtener(pUsuario.Nombre_Usuario);
                this.Hide();
                mPrincipal.ShowDialog(this);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Login-Error-InicioSesion", mIdioma) + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load (object sender, EventArgs e)
        {
            mIdioma = ConfigurationManager.AppSettings.Get("Idioma");
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(mIdioma));
            foreach (IdiomaBE mIdioma in IdiomaBL.ListarIdiomas())
            {
                LoginComboBox1.Items.Add(mIdioma.Descripcion);
            }
        }

        private void CargarIdioma (List<ControlBE> Lista)
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
        }

        private void LoginButton3_Click(object sender, EventArgs e)
        {
            try
            {

                CambiarPassword mCambiarPassword = new CambiarPassword();
                mCambiarPassword.mIdioma = mIdioma;
                mCambiarPassword.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Login-Error-cambiarClave", mIdioma) + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mIdioma = LoginComboBox1.SelectedItem.ToString();
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(mIdioma));
        }
    }
}
