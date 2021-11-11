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
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        public CambiarContraseña()
        {
            InitializeComponent();
            CambiarContraseniaTextBox1.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
            CambiarContraseniaTextBox2.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
            CambiarContraseniaTextBox3.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
            
        }

        public CambiarContraseña(Principal fPrincipal)
        {
            parent = fPrincipal;
            InitializeComponent();
        }

        private void textBox_HelpRequested(object sender, System.Windows.Forms.HelpEventArgs hlpevent)
        {
            // This event is raised when the F1 key is pressed or the
            // Help cursor is clicked on any of the address fields.
            // The Help text for the field is in the control's
            // Tag property. It is retrieved and displayed in the label.

            Control requestingControl = (Control)sender;
            string message = IdiomaBL.ObtenerMensajeTextos(requestingControl.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            if (message != "")
            {
                MessageBox.Show(message);
                hlpevent.Handled = true;
            }
        }

        private void CambiarContraseña_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.CambiarContraseniaButton1.Enabled = false;
            this.CambiarContraseniaLabel4.Visible = false;
            CambiarContraseniaLabel6.Enabled = false;
            CambiarContraseniaLabel6.WordWrap = true;
            this.CambiarContraseniaLabel7.Visible = false;
            this.Text = IdiomaBL.ObtenerMensajeTextos("CambiarContrasenia-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            SetToolTips();
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
                string tooltipMessaje = IdiomaBL.ObtenerMensajeTextos(c.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
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
                if (c is GroupBox)
                {
                    SetToolTipsGroupBox((GroupBox)c);
                }
            }

        }

        private void SetToolTipsGroupBox(GroupBox groupBox)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            foreach (Control c in groupBox.Controls)
            {
                ToolTip toolTip;
                string tooltipMessaje = IdiomaBL.ObtenerMensajeTextos(c.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
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
                if (c is GroupBox)
                {
                    SetToolTipsGroupBox((GroupBox)c);
                }
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
                BitacoraBE mBitacora = new BitacoraBE();
                BitacoraBL Bitacorabl = new BitacoraBL();
                mBitacora.Descripcion = "Cambio de clave usuario: " + pUsuario.Nombre_Usuario;
                mBitacora.Fecha = DateTime.Now;
                mBitacora.Nombre_Usuario= SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("CambiarContrasenia-Info-CambioCorrecto", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                BitacoraBL Bitacorabl = new BitacoraBL();
                BitacoraBE mBitacora = new BitacoraBE();
                mBitacora.Descripcion = "Error al cambiar clave";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.Nombre_Usuario = SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
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
