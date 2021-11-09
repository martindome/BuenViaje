using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BE;
using BL;

namespace BuenViaje.Rutas
{
    public partial class ABMRutas : Form
    {
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        internal Operacion operacion;
        internal RutaBE rutabe;
        internal RutaBL rutabl = new RutaBL();
        internal LocalidadBL localidadbl= new LocalidadBL();
        internal BitacoraBL bitacorabl = new BitacoraBL();
        public ABMRutas()
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

        private void ABMRutas_Load(object sender, EventArgs e)
        {
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("ABMRutas-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            rutasCombo1.DropDownStyle = ComboBoxStyle.DropDownList;
            rutasCombo2.DropDownStyle = ComboBoxStyle.DropDownList;
            List<string> localidades = new List<string>();
            foreach (LocalidadBE mLocalidad in localidadbl.Listar())
            {
                rutasCombo1.Items.Add(mLocalidad.Provincia + "-" + mLocalidad.Nombre);
                rutasCombo2.Items.Add(mLocalidad.Provincia + "-" + mLocalidad.Nombre);
            }
            //localidades.Sort();
            //foreach (string localidad in localidades)
            //{
            //    rutasCombo1.Items.Add(localidad);
            //    rutasCombo2.Items.Add(localidad);
            //}
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
                    this.RutasText2.Text = this.rutabe.Duracion.ToString();
                    this.rutasCombo1.SelectedItem = rutabe.Origen.Provincia + "-" + rutabe.Origen.Nombre;
                    this.rutasCombo2.SelectedItem = rutabe.Destino.Provincia + "-" + rutabe.Destino.Nombre;
                    
                    break;
                case Operacion.Baja:
                    Limpiar();
                    this.RutasText2.Text = this.rutabe.Duracion.ToString();
                    this.rutasCombo1.SelectedItem = rutabe.Origen.Provincia + "-" + rutabe.Origen.Nombre;
                    this.rutasCombo2.SelectedItem = rutabe.Destino.Provincia + "-" + rutabe.Destino.Nombre;
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
            this.RutasText2.Enabled = false;
            this.rutasCombo1.Enabled = false;
            this.rutasCombo1.Enabled = false;
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

        private bool ValidarRutaMisma()
        {
            
            string ProvinciaOrigen = this.rutasCombo1.SelectedItem.ToString().Split('-')[0];
            string ProvinciaDestino = this.rutasCombo2.SelectedItem.ToString().Split('-')[0];
            string LocalidadedOrigen = this.rutasCombo1.SelectedItem.ToString().Split('-')[1];
            string LocalidadDestino = this.rutasCombo2.SelectedItem.ToString().Split('-')[1];
            if (ProvinciaOrigen == ProvinciaDestino && LocalidadedOrigen == LocalidadDestino)
            {
                return false;
            }
            return true;
        }

        private bool ValidarRutaIgual()
        {
            LocalidadBE Origen = localidadbl.Obtener(rutasCombo1.SelectedIndex + 1);
            LocalidadBE Destino = localidadbl.Obtener(rutasCombo2.SelectedIndex + 1);
            List<LocalidadBE> Localidades = localidadbl.Listar();
            foreach (RutaBE ruta in rutabl.Listar())
            {
                if (ruta.Destino.Equals(Origen) && ruta.Origen.Equals(Destino))
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidarNombre()
        {
            foreach (RutaBE ruta in rutabl.Listar())
            {
                if (ruta.Nombre == this.RutasText3.Text)
                {
                    return false;
                } 
            }
            return true;
        }
          

        private void RutasButton1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            BitacoraBE mBitacora = new BitacoraBE();
            try
            {
                switch (this.operacion)
                {
                    case Operacion.Alta:
                        if (!ValidarRutaMisma())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMRuta-Validacion-Misma", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarRutaIgual())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMRuta-Validacion-Igual", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarNombre())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMRuta-Validacion-Nombre", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.rutabe.Origen = localidadbl.Obtener(rutasCombo1.SelectedIndex + 1);
                        this.rutabe.Destino = localidadbl.Obtener(rutasCombo2.SelectedIndex + 1);
                        this.rutabe.Duracion = int.Parse(this.RutasText2.Text);
                        this.rutabe.Nombre = (this.RutasText3.Text);
                        this.rutabl.Guardar(rutabe);
                        mBitacora.Descripcion = "Se dio de alta a la ruta: " + this.rutabe.Origen.Nombre + "-" + this.rutabe.Destino.Nombre;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Modificacion:
                        if (!ValidarRutaMisma())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMRuta-Validacion-Misma", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarRutaIgual())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMRuta-Validacion-Igual", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.rutabe.Origen = localidadbl.Obtener(rutasCombo1.SelectedIndex + 1);
                        this.rutabe.Destino = localidadbl.Obtener(rutasCombo2.SelectedIndex + 1);
                        this.rutabe.Duracion = int.Parse(this.RutasText2.Text);
                        this.rutabe.Nombre = (this.RutasText3.Text);
                        this.rutabl.Guardar(rutabe);
                        mBitacora.Descripcion = "Se modifico la ruta: " + this.rutabe.Origen.Nombre + "-" + this.rutabe.Destino.Nombre;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Baja:
                        DialogResult result = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMRuta-Confirmacion-Baja", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.rutabl.Eliminar(this.rutabe);
                        }
                        //Bitacora
                        mBitacora.Descripcion = "Se elimino la ruta: " + this.rutabe.Origen.Nombre + "-" + this.rutabe.Destino.Nombre;
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
                mBitacora.Descripcion = "Error al operar con Rutas";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMRuta-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void RutasButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
