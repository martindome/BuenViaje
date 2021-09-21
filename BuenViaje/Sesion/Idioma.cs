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
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            IdiomaComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (IdiomaBE mIdioma in IdiomaBL.ListarIdiomas())
            {
                IdiomaComboBox1.Items.Add(mIdioma.Descripcion);
            }
            this.Text = IdiomaBL.ObtenerMensajeTextos("Idioma-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
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
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Idioma-Error-CambioIdioma", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
            
        }
    }
}
