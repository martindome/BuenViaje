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
    public partial class CambiarPassword : Form
    {
        public CambiarPassword()
        {
            InitializeComponent();
        }

        public string mIdioma;

        private void CambiarPasswordButton1_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBL Usuariobl = new UsuarioBL();
                UsuarioBE mUsuario = Usuariobl.Obtener(CambiarPasswordText1.Text);
                if (mUsuario != null)
                {
                    Usuariobl.ResetarConstrasenia(mUsuario);
                    MessageBox.Show("Clave actualizada", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario no encotrado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Login-Error-cambiarClave", mIdioma) + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CambiarPassword_Load(object sender, EventArgs e)
        {
            //string mIdioma = ConfigurationManager.AppSettings.Get("Idioma");
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(mIdioma));
        }

        private void CargarIdioma(List<ControlBE> Lista)
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
