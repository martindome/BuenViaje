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
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();

        public Login()
        {   
            InitializeComponent();
            this.txtUser.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
            this.txtPass.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
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
                this.MaximizeBox = false;
                BitacoraBL Bitacorabl = new BitacoraBL();
                BitacoraBE mBitacora = new BitacoraBE();
                mBitacora.Descripcion = "Error al iniciar sesion";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.Nombre_Usuario = "NULL";
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Login-Error-InicioSesion", mIdioma) + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load (object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToScreen();
            mIdioma = ConfigurationManager.AppSettings.Get("Idioma");
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(mIdioma));
            foreach (IdiomaBE mIdioma in IdiomaBL.ListarIdiomas())
            {
                LoginComboBox1.Items.Add(mIdioma.Descripcion);
            }
            LoginComboBox1.SelectedIndex = 1;
            SetToolTips();
            
        }

        private void textBox_HelpRequested(object sender, System.Windows.Forms.HelpEventArgs hlpevent)
        {
            // This event is raised when the F1 key is pressed or the
            // Help cursor is clicked on any of the address fields.
            // The Help text for the field is in the control's
            // Tag property. It is retrieved and displayed in the label.

            Control requestingControl = (Control)sender;
            string message = IdiomaBL.ObtenerMensajeTextos(requestingControl.Name, mIdioma);
            if ( message != ""){
                MessageBox.Show(message);
                hlpevent.Handled = true;
            }
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
                string tooltipMessaje = IdiomaBL.ObtenerMensajeTextos(c.Name, mIdioma);
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
                SetToolTips();
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
            SetToolTips();
        }
    }
}
