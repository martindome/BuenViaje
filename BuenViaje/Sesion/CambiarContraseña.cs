using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuenViaje;
using BL;
using BE;
using System.Text.RegularExpressions;

namespace BuenViaje.Sesion
{
    public partial class CambiarContraseña : Form
    {
        public Principal parent { get; set; }
        public CambiarContraseña()
        {
            InitializeComponent();
        }

        public CambiarContraseña(Principal fPrincipal)
        {
            parent = fPrincipal;
            InitializeComponent();
        }

        private void CambiarContraseña_Load(object sender, EventArgs e)
        {
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.CambiarContraseniaButton1.Enabled = false;
            this.CambiarContraseniaLabel4.Visible = false;
            CambiarContraseniaLabel6.Enabled = false;
            CambiarContraseniaLabel6.WordWrap = true;
            this.CambiarContraseniaLabel7.Visible = false;
            this.Text = IdiomaBL.ObtenerMensajeTextos("CambiarContrasenia-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
        }

        private void CambiarContraseniaTextBox3_TextChanged(object sender, EventArgs e)
        {
            if ((this.CambiarContraseniaTextBox2.Text != "" && this.CambiarContraseniaTextBox3.Text != ""))
            {
                if ((this.CambiarContraseniaTextBox2.Text == this.CambiarContraseniaTextBox3.Text))
                {
                    this.CambiarContraseniaLabel4.Visible = false;
                    if (ConstraseniaValida(this.CambiarContraseniaTextBox3.Text))
                    {
                        this.CambiarContraseniaLabel7.Visible = false;
                    }
                    else
                    {
                        this.CambiarContraseniaLabel7.Visible = true;
                    }
                }
                else
                {
                    this.CambiarContraseniaLabel7.Visible = false;
                    this.CambiarContraseniaLabel4.Visible = true;
                }
            }
            else
            {
                this.CambiarContraseniaLabel7.Visible = false;
                this.CambiarContraseniaLabel4.Visible = false;
            }
            if (ConstraseniaValida(this.CambiarContraseniaTextBox2.Text) && CompareBox())
            {
                this.CambiarContraseniaButton1.Enabled = true;
            }
            else
            {
                this.CambiarContraseniaButton1.Enabled = false;
            }
        }

        private void CambiarContraseniaTextBox2_TextChanged(object sender, EventArgs e)
        {
            if ((this.CambiarContraseniaTextBox2.Text != "" && this.CambiarContraseniaTextBox3.Text != ""))
            {
                if ((this.CambiarContraseniaTextBox2.Text == this.CambiarContraseniaTextBox3.Text))
                {
                    this.CambiarContraseniaLabel4.Visible = false;
                    if (ConstraseniaValida(this.CambiarContraseniaTextBox2.Text))
                    {
                        this.CambiarContraseniaLabel7.Visible = false;
                    }
                    else
                    {
                        this.CambiarContraseniaLabel7.Visible = true;
                    }
                }
                else
                {
                    this.CambiarContraseniaLabel7.Visible = false;
                    this.CambiarContraseniaLabel4.Visible = true;
                }
            }
            else
            {
                this.CambiarContraseniaLabel7.Visible = false;
                this.CambiarContraseniaLabel4.Visible = false;
            }
            if (ConstraseniaValida(this.CambiarContraseniaTextBox2.Text) && CompareBox())
            {
                this.CambiarContraseniaButton1.Enabled = true;
            }
            else
            {
                this.CambiarContraseniaButton1.Enabled = false;
            }
        }

        private void CambiarContraseniaTextBox1_TextChanged(object sender, EventArgs e){
            
            //if (this.CambiarContraseniaTextBox1.Text != "") {
            //    if (ConstraseniaValida(this.CambiarContraseniaTextBox1.Text))
            //    {
            //        this.CambiarContraseniaLabel5.Visible = false;
            //    }
            //    else
            //    {
            //        this.CambiarContraseniaLabel5.Visible = true;
            //    }
            //}
            //else
            //{
            //    this.CambiarContraseniaLabel5.Visible = false;
            //}
            //if ( ConstraseniaValida(this.CambiarContraseniaTextBox1.Text) && ConstraseniaValida(this.CambiarContraseniaTextBox2.Text) && CompareBox())
            //{
            //    this.CambiarContraseniaButton1.Enabled = true;
            //}
            //else
            //{
            //    this.CambiarContraseniaButton1.Enabled = false;
            //}

        }

        private bool ConstraseniaValida(string Password){
            string regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            return Regex.Match(Password, regex).Success;
        }

        private bool CompareBox()
        {
            return (this.CambiarContraseniaTextBox2.Text != "" && this.CambiarContraseniaTextBox3.Text != "") && (this.CambiarContraseniaTextBox2.Text == this.CambiarContraseniaTextBox3.Text);
        }

        private void CargarIdioma(List<ControlBE> pControles)
        {
            foreach (Control C in this.Controls)
            {
                foreach (ControlBE pControl in pControles)
                {
                    if (pControl.ID_Control == C.Name)
                        C.Text = pControl.Mensaje;
                }
            }
        }

        private void CambiarContraseniaButton1_Click(object sender, EventArgs e)
        {
            UsuarioBE pUsuario = SingletonSesion.Instancia.Usuario;
            UsuarioBL Usuariobl = new UsuarioBL();
            try
            {
                Usuariobl.CambiarContrasenia(pUsuario, this.CambiarContraseniaTextBox1.Text, this.CambiarContraseniaTextBox2.Text);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("CambiarContrasenia-Info-CambioCorrecto", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("CambiarContrasenia-Error-CambioClave", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void CambiarContraseniaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
