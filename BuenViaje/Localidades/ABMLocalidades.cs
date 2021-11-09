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

namespace BuenViaje.Localidades
{
    public partial class ABMLocalidades : Form
    {
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        internal Operacion operacion;
        internal LocalidadBE localidadbe;
        internal LocalidadBL localidadbl = new LocalidadBL();
        internal BitacoraBL bitacorabl = new BitacoraBL();

        public ABMLocalidades()
        {
            InitializeComponent();
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

        private void ABMLocalidades_Load(object sender, EventArgs e)
        {
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("ABMLocalidades-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            CargarCampos();
            SetToolTips();
        }

        private void CargarCampos()
        {
            switch (this.operacion)
            {
                case Operacion.Alta:
                    Limpiar();
                    break;
                case Operacion.Modificacion:
                    Limpiar();
                    this.ABMLocalidadesTexto1.Text = this.localidadbe.Nombre;
                    this.ABMLocalidadesTexto2.Text = this.localidadbe.Provincia;
                    this.ABMLocalidadesTexto3.Text = this.localidadbe.Pais;
                    break;
                case Operacion.Baja:
                    Limpiar();
                    this.ABMLocalidadesTexto1.Text = this.localidadbe.Nombre;
                    this.ABMLocalidadesTexto2.Text = this.localidadbe.Provincia;
                    this.ABMLocalidadesTexto3.Text = this.localidadbe.Pais;
                    DeshabilitarBotones();
                    break;
            }
        }

        private void Limpiar()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
            }
        }

        private void DeshabilitarBotones()
        {
            this.ABMLocalidadesTexto1.Enabled = false;
            this.ABMLocalidadesTexto2.Enabled = false;
            this.ABMLocalidadesTexto3.Enabled = false;
        }

        private void CargarIdioma(List<ControlBE> pControles)
        {
            foreach (Control C in this.Controls)
            {
                foreach (ControlBE pControl in pControles)
                {
                    if (pControl.ID_Control == C.Name)
                    {
                        C.Text = pControl.Mensaje;
                        break;
                    }
                }
            }
        }

        private void ABMLocalidadesBotton1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            BitacoraBE mBitacora = new BitacoraBE();
            try
            {
                switch (this.operacion)
                {
                    case Operacion.Alta:
                        if (!ValidarLocalidad())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMLocalidades-Validacion-Localidad", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.localidadbe.Nombre = this.ABMLocalidadesTexto1.Text;
                        this.localidadbe.Provincia = this.ABMLocalidadesTexto2.Text;
                        this.localidadbe.Pais = this.ABMLocalidadesTexto3.Text;
                        this.localidadbl.Guardar(localidadbe);
                        mBitacora.Descripcion = "Se dio de alta a la localidad: " + this.ABMLocalidadesTexto1.Text + "-" + this.ABMLocalidadesTexto2.Text + "-" + this.ABMLocalidadesTexto3.Text;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Modificacion:
                        if (!ValidarLocalidad())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMLocalidades-Validacion-Localidad", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.localidadbe.Nombre = this.ABMLocalidadesTexto1.Text;
                        this.localidadbe.Provincia = this.ABMLocalidadesTexto2.Text;
                        this.localidadbe.Pais = this.ABMLocalidadesTexto3.Text;
                        this.localidadbl.Guardar(localidadbe);
                        mBitacora.Descripcion = "Se modifico la localidad: " + this.ABMLocalidadesTexto1.Text + "-" + this.ABMLocalidadesTexto2.Text + "-" + this.ABMLocalidadesTexto3.Text;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Baja:
                        DialogResult result = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMLocalidades-Confirmacion-Baja", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.localidadbl.Eliminar(this.localidadbe);
                        }
                        //Bitacora
                        mBitacora.Descripcion = "Se elimino la localidad: " + this.localidadbe.Nombre + "-" + this.localidadbe.Provincia + "-" + this.localidadbe.Pais;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                        mBitacora.Tipo_Evento = "HIGH";
                        bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                }
                if (flag)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                BitacoraBL Bitacorabl = new BitacoraBL();
                mBitacora.Descripcion = "Error al operar con localidades";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMLocalidades-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
            
        }

        private bool ValidarLocalidad()
        {
            foreach(LocalidadBE localidadbe in localidadbl.Listar())
            {
                if (localidadbe.Provincia == this.ABMLocalidadesTexto2.Text && localidadbe.Pais == this.ABMLocalidadesTexto3.Text && localidadbe.Nombre == this.ABMLocalidadesTexto1.Text)
                {
                    return false;
                }
            }
            return true;
        }

        private void ABMLocalidadesBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
