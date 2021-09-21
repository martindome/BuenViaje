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
                    BitacoraBE mBitacora = new BitacoraBE();
                    BitacoraBL Bitacorabl = new BitacoraBL();
                    mBitacora.Descripcion = "Reset clave usuario: " + CambiarPasswordText1.Text;
                    mBitacora.Fecha = DateTime.Now;
                    mBitacora.ID_Usuario = 0;
                    mBitacora.Tipo_Evento = "HIGH";
                    Bitacorabl.Guardar(mBitacora);
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
                BitacoraBL Bitacorabl = new BitacoraBL();
                BitacoraBE mBitacora = new BitacoraBE();
                mBitacora.Descripcion = "Error al resetear password";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = 0;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Login-Error-cambiarClave", mIdioma) + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CambiarPassword_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
