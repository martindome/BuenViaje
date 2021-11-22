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

namespace BuenViaje
{
    public partial class CambiarConString : Form
    {
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        public string mIdioma;

        private void textBox_HelpRequested(object sender, System.Windows.Forms.HelpEventArgs hlpevent)
        {
            // This event is raised when the F1 key is pressed or the
            // Help cursor is clicked on any of the address fields.
            // The Help text for the field is in the control's
            // Tag property. It is retrieved and displayed in the label.

            Control requestingControl = (Control)sender;
            string message = IdiomaBL.ObtenerMensajeTextos(requestingControl.Name, mIdioma);
            if (message != "")
            {
                MessageBox.Show(message);
                hlpevent.Handled = true;
            }
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

        public CambiarConString()
        {
            InitializeComponent();
            CambiarConStringText1.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
        }

        private void CambiarConString_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //string mIdioma = ConfigurationManager.AppSettings.Get("Idioma");
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(mIdioma));
            SetToolTips();
            this.CambiarConStringButton1.Enabled = false;
            this.Text = IdiomaBL.ObtenerMensajeTextos("CambiarConString-Form", mIdioma);
        }

        private void CambiarConStringButton1_Click(object sender, EventArgs e)
        {
            try
            {
                LoginBL.CambiarConnectionString(this.CambiarConStringText1.Text);
                BitacoraBE mBitacora = new BitacoraBE();
                BitacoraBL Bitacorabl = new BitacoraBL();
                mBitacora.Descripcion = "Cambio de connection string";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.Nombre_Usuario = "NULL";
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show("CambiarConString-Info-CambioCorrecto", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception ex)
            {
                BitacoraBL Bitacorabl = new BitacoraBL();
                BitacoraBE mBitacora = new BitacoraBE();
                mBitacora.Descripcion = "Error al resetear password";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.Nombre_Usuario = "NULL";
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("CambiarConString-Error-CambioClave", mIdioma) + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CambiarConStringText1_TextChanged(object sender, EventArgs e)
        {
            if (this.CambiarConStringText1.Text.Length > 0)
            {
                this.CambiarConStringButton1.Enabled = true;
            }
            else
            {
                this.CambiarConStringButton1.Enabled = false;
            }
        }
    }
}
