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

namespace BuenViaje.Sesion
{
    public partial class Idioma : Form
    {
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        public Principal parent { get; set; }
        public Idioma()
        {
            InitializeComponent();
        }

        public Idioma(Principal fPrincipal)
        {
            parent = fPrincipal;
            InitializeComponent();
        }

        private void Idioma_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToParent();
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            IdiomaComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (IdiomaBE mIdioma in IdiomaBL.ListarIdiomas())
            {
                IdiomaComboBox1.Items.Add(mIdioma.Descripcion);
            }
            this.Text = IdiomaBL.ObtenerMensajeTextos("Idioma-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            SetToolTips();
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

        private void IdiomaBotton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdiomaComboBox1.SelectedItem != null)
                {
                    UsuarioBE mU = new UsuarioBE();
                    UsuarioBL mUsuariobl = new UsuarioBL();
                    mU = SingletonSesion.Instancia.Usuario;
                    mU.ID_Idioma = IdiomaComboBox1.SelectedIndex + 1;
                    mU.Idioma_Descripcion = IdiomaComboBox1.SelectedItem.ToString();
                    mUsuariobl.Actualizar(mU);
                    MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Idioma-Info-cambio", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
                    this.parent.CargarIdioma(IdiomaBL.ObtenerMensajeControladores(IdiomaComboBox1.SelectedItem.ToString()));
                }
            }
            catch(Exception ex)
            {
                BitacoraBL Bitacorabl = new BitacoraBL();
                BitacoraBE mBitacora = new BitacoraBE();
                mBitacora.Descripcion = "Error al cambiar idioma";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Idioma-Error-CambioIdioma", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
            
        }
    }
}
