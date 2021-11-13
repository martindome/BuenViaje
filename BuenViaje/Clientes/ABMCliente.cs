using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BE;
using BL;

namespace BuenViaje.Clientes
{
    public partial class ABMCliente : Form
    {
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        internal Operacion operacion;
        internal ClienteBE clientebe;
        internal ClienteBL clientebl = new ClienteBL();
        internal BitacoraBL bitacorabl = new BitacoraBL();

        public ABMCliente()
        {
            InitializeComponent();
            
            ABMClientesTexto1.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
            ABMClientesTexto2.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
            ABMClientesTexto3.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
            
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

        private void ABMCliente_Load(object sender, EventArgs e)
        {
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("ABMClientes-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            CargarCampos();
            SetToolTips();
            if (operacion != Operacion.Baja)
            {
                ABMClientesBotton1.Enabled = false;
            }
            else
            {
                ABMClientesBotton1.Enabled = true;
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
                    this.ABMClientesTexto1.Text = this.clientebe.Nombre;
                    this.ABMClientesTexto2.Text = this.clientebe.Apellido;
                    this.ABMClientesTexto3.Text = this.clientebe.DNI;
                    this.ABMClientesTexto4.Text = this.clientebe.Email;
                    break;
                case Operacion.Baja:
                    Limpiar();
                    this.ABMClientesTexto1.Text = this.clientebe.Nombre;
                    this.ABMClientesTexto2.Text = this.clientebe.Apellido;
                    this.ABMClientesTexto3.Text = this.clientebe.DNI;
                    this.ABMClientesTexto4.Text = this.clientebe.Email;
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
            this.ABMClientesTexto1.Enabled = false;
            this.ABMClientesTexto2.Enabled = false;
            this.ABMClientesTexto3.Enabled = false;
            this.ABMClientesTexto4.Enabled = false;
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

        private bool ValidarCliente()
        {
            foreach (ClienteBE clientebe in clientebl.Listar())
            {
                if (clientebe.DNI == this.ABMClientesTexto3.Text && this.operacion != Operacion.Modificacion)
                {
                    return false;
                }
            }
            return true;
        }

        private void ABMClientesBotton1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            BitacoraBE mBitacora = new BitacoraBE();
            try
            {
                switch (this.operacion)
                {
                    case Operacion.Alta:
                        if (!ValidarCliente())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMClientes-Validacion-Cliente", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.clientebe.Nombre = this.ABMClientesTexto1.Text;
                        this.clientebe.Apellido = this.ABMClientesTexto2.Text;
                        this.clientebe.DNI = this.ABMClientesTexto3.Text;
                        this.clientebe.Email = this.ABMClientesTexto4.Text;
                        this.clientebl.Guardar(clientebe);
                        mBitacora.Descripcion = "Se dio de alta al cliente: " + this.clientebe.DNI;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.Nombre_Usuario= SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Modificacion:
                        if (!ValidarCliente())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMClientes-Validacion-Cliente", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.clientebe.Nombre = this.ABMClientesTexto1.Text;
                        this.clientebe.Apellido = this.ABMClientesTexto2.Text;
                        this.clientebe.DNI = this.ABMClientesTexto3.Text;
                        this.clientebe.Email = this.ABMClientesTexto4.Text;
                        this.clientebl.Guardar(clientebe);
                        mBitacora.Descripcion = "Se modifico el cliente: " + this.clientebe.DNI;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.Nombre_Usuario= SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Baja:
                        DialogResult result = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMClientes-Confirmacion-Baja", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.clientebl.Eliminar(this.clientebe);
                        }
                        //Bitacora
                        mBitacora.Descripcion = "Se elimino al cliente: " + this.clientebe.DNI;
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
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMClientes-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ABMClientesBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMClientesTexto1_TextChanged(object sender, EventArgs e)
        {
            if (ABMClientesTexto1.Text.Length > 0 && ABMClientesTexto1.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto1.Text, @"^[a-zA-Z\s]+$") && ABMClientesTexto2.Text.Length > 0 && ABMClientesTexto2.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto2.Text, @"^[a-zA-Z\s]+$") && ABMClientesTexto3.Text.Length > 0 && ABMClientesTexto3.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto3.Text, @"^[a-zA-Z0-9]+$") && ABMClientesTexto4.Text.Length > 0 && ABMClientesTexto4.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto4.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                ABMClientesBotton1.Enabled = true;
            }
            else
            {
                ABMClientesBotton1.Enabled = false;
            }
        }

        private void ABMClientesTexto2_TextChanged(object sender, EventArgs e)
        {
            if (ABMClientesTexto1.Text.Length > 0 && ABMClientesTexto1.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto1.Text, @"^[a-zA-Z\s]+$") && ABMClientesTexto2.Text.Length > 0 && ABMClientesTexto2.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto2.Text, @"^[a-zA-Z\s]+$") && ABMClientesTexto3.Text.Length > 0 && ABMClientesTexto3.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto3.Text, @"^[a-zA-Z0-9]+$") && ABMClientesTexto4.Text.Length > 0 && ABMClientesTexto4.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto4.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                ABMClientesBotton1.Enabled = true;
            }
            else
            {
                ABMClientesBotton1.Enabled = false;
            }
        }

        private void ABMClientesTexto3_TextChanged(object sender, EventArgs e)
        {
            if (ABMClientesTexto1.Text.Length > 0 && ABMClientesTexto1.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto1.Text, @"^[a-zA-Z\s]+$") && ABMClientesTexto2.Text.Length > 0 && ABMClientesTexto2.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto2.Text, @"^[a-zA-Z\s]+$") && ABMClientesTexto3.Text.Length > 0 && ABMClientesTexto3.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto3.Text, @"^[a-zA-Z0-9]+$") && ABMClientesTexto4.Text.Length > 0 && ABMClientesTexto4.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto4.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                ABMClientesBotton1.Enabled = true;
            }
            else
            {
                ABMClientesBotton1.Enabled = false;
            }
        }

        private void ABMClientesTexto4_TextChanged(object sender, EventArgs e)
        {
            if (ABMClientesTexto1.Text.Length > 0 && ABMClientesTexto1.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto1.Text, @"^[a-zA-Z\s]+$") && ABMClientesTexto2.Text.Length > 0 && ABMClientesTexto2.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto2.Text, @"^[a-zA-Z\s]+$") && ABMClientesTexto3.Text.Length > 0 && ABMClientesTexto3.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto3.Text, @"^[a-zA-Z0-9]+$") && ABMClientesTexto4.Text.Length > 0 && ABMClientesTexto4.Text.Length < 50 && Regex.IsMatch(ABMClientesTexto4.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                ABMClientesBotton1.Enabled = true;
            }
            else
            {
                ABMClientesBotton1.Enabled = false;
            }
        }
    }
}
