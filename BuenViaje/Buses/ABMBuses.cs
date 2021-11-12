using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BE;
using BL;

namespace BuenViaje.Buses
{
    public partial class ABMBuses : Form
    {
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        internal Operacion operacion;
        internal BusBE busbe;
        internal BusBL busbl= new BusBL();
        internal BitacoraBL bitacorabl = new BitacoraBL();
        public ABMBuses()
        {
            InitializeComponent();
            
            ABMBusesTexto1.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
            ABMBusesTexto2.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
            ABMBusesTexto3.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
            
        }

        private void ABMBuses_Load(object sender, EventArgs e)
        {
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("ABMBuses-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            CargarCampos();
            SetToolTips();
            ABMBusesBotton1.Enabled = false;
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

        private void CargarCampos()
        {
            switch (this.operacion)
            {
                case Operacion.Alta:
                    Limpiar();
                    break;
                case Operacion.Modificacion:
                    Limpiar();
                    this.ABMBusesTexto1.Text = this.busbe.Patente;
                    this.ABMBusesTexto2.Text = this.busbe.Marca;
                    this.ABMBusesTexto3.Text = this.busbe.Asientos.ToString();
                    this.ABMBusesTexto1.Enabled = false;
                    break;
                case Operacion.Baja:
                    Limpiar();
                    this.ABMBusesTexto1.Text = this.busbe.Patente;
                    this.ABMBusesTexto2.Text = this.busbe.Marca;
                    this.ABMBusesTexto3.Text = this.busbe.Asientos.ToString();
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
            this.ABMBusesTexto1.Enabled = false;
            this.ABMBusesTexto2.Enabled = false;
            this.ABMBusesTexto3.Enabled = false;
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

        private bool ValidarBusExistente()
        {
            foreach (BusBE busbe in busbl.Listar())
            {
                if (busbe.Patente == this.ABMBusesTexto1.Text && this.operacion != Operacion.Modificacion)
                {
                    return false;
                }
            }
            return true;
        }

        private void ABMBusesBotton1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            BitacoraBE mBitacora = new BitacoraBE();
            try
            {
                switch (this.operacion)
                {
                    case Operacion.Alta:
                        if (!ValidarBusExistente())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMBuses-Validacion-Bus", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!Regex.IsMatch(this.ABMBusesTexto1.Text, "^[A-Z0-9]+$"))
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMBuses-ValidacionPatente-Bus", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.busbe.Patente = this.ABMBusesTexto1.Text.ToUpper();
                        this.busbe.Marca = this.ABMBusesTexto2.Text;
                        this.busbe.Asientos = int.Parse(this.ABMBusesTexto3.Text);
                        this.busbl.Guardar(busbe);
                        mBitacora.Descripcion = "Se dio de alta al bus: " + this.ABMBusesTexto1.Text.ToUpper();
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.Nombre_Usuario= SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Modificacion:
                        if (!ValidarBusExistente())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMBuses-Validacion-Bus", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!Regex.IsMatch(this.ABMBusesTexto1.Text, "^[A-Z0-9]+$"))
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMBuses-ValidacionPatente-Bus", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.busbe.Patente = this.ABMBusesTexto1.Text;
                        this.busbe.Marca = this.ABMBusesTexto2.Text;
                        this.busbe.Asientos = int.Parse(this.ABMBusesTexto3.Text);
                        this.busbl.Guardar(busbe);
                        mBitacora.Descripcion = "Se modifico el bus: " + this.ABMBusesTexto1.Text.ToUpper();
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.Nombre_Usuario= SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Baja:
                        DialogResult result = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMBuses-Confirmacion-Baja", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.busbl.Eliminar(this.busbe);
                        }
                        //Bitacora
                        mBitacora.Descripcion = "Se elimino al bus: " + this.busbe.Patente;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.Nombre_Usuario= SingletonSesion.Instancia.Usuario.Nombre_Usuario;
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
                mBitacora.Descripcion = "Error al operar con buses";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.Nombre_Usuario= SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMBuses-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ABMBusessBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMBusesTexto1_TextChanged(object sender, EventArgs e)
        {
            if (this.ABMBusesTexto1.Text.Length >0 && this.ABMBusesTexto2.Text.Length > 0 && this.ABMBusesTexto3.Text.Length > 0 && Regex.IsMatch(this.ABMBusesTexto3.Text, @"^\d+$") && Regex.IsMatch(this.ABMBusesTexto2.Text, @"^[A-Za-z]+$")  )
            {
                ABMBusesBotton1.Enabled = true;
            }
            else
            {
                ABMBusesBotton1.Enabled = false;
            }
        }

        private void ABMBusesTexto2_TextChanged(object sender, EventArgs e)
        {
            if (this.ABMBusesTexto1.Text.Length > 0 && this.ABMBusesTexto2.Text.Length > 0 && this.ABMBusesTexto3.Text.Length > 0 && Regex.IsMatch(this.ABMBusesTexto3.Text, @"^\d+$" ) && Regex.IsMatch(this.ABMBusesTexto2.Text, @"^[A-Za-z]+$"))
            {
                ABMBusesBotton1.Enabled = true;
            }
            else
            {
                ABMBusesBotton1.Enabled = false;
            }
        }

        private void ABMBusesTexto3_TextChanged(object sender, EventArgs e)
        {
            if (this.ABMBusesTexto1.Text.Length > 0 && this.ABMBusesTexto2.Text.Length > 0 && this.ABMBusesTexto3.Text.Length > 0 && Regex.IsMatch(this.ABMBusesTexto3.Text, @"^\d+$") && Regex.IsMatch(this.ABMBusesTexto2.Text, @"^[A-Za-z]+$"))
            {
                ABMBusesBotton1.Enabled = true;
            }
            else
            {
                ABMBusesBotton1.Enabled = false;
            }
        }
    }
}
