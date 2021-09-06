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

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                LoginBL.SingleUsuario = Usuariobl.Obtener(pUsuario.Nombre_Usuario);
                this.Hide();
                mPrincipal.ShowDialog(this);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load (object sender, EventArgs e)
        {
            string mIdioma = ConfigurationManager.AppSettings.Get("Idioma");
            
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(mIdioma));
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
    }
}
