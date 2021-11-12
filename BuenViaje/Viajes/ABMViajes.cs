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

namespace BuenViaje.Viajes
{
    public partial class ABMViajes : Form
    {
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        internal Operacion operacion;
        internal ViajeBE viajebe;
        internal ViajeBL viajeBL = new ViajeBL();
        internal RutaBL rutaBL = new RutaBL();
        internal BusBL busBL = new BusBL();
        internal BitacoraBL bitacorabl = new BitacoraBL();
        public ABMViajes()
        {
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
        private void ViajesABM_Load(object sender, EventArgs e)
        {
            this.ViajeABMDatePickerDesde.CustomFormat = "MM-dd-yyyy";
            this.ViajeABMDatePickerDesde.Format = DateTimePickerFormat.Custom;

            this.ViajeABMDatePickerDesdeHora.Format = DateTimePickerFormat.Time;
            this.ViajeABMDatePickerDesdeHora.ShowUpDown = true;

            this.ViajeABMDatePickerHasta.CustomFormat = "MM-dd-yyyy";
            this.ViajeABMDatePickerHasta.Format = DateTimePickerFormat.Custom;

            //this.ViajeABMDatePickerHastaHora.Format = DateTimePickerFormat.Time;
            //this.ViajeABMDatePickerHastaHora.ShowUpDown = true;

            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("ABMViajes-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            ViajeABMCombo1.DropDownStyle = ComboBoxStyle.DropDownList;
            ViajeABMCombo2.DropDownStyle = ComboBoxStyle.DropDownList;
            ViajeABMCombo3.DropDownStyle = ComboBoxStyle.DropDownList;

            ViajeABMCombo3.Items.Add(IdiomaBL.ObtenerMensajeTextos("ABMViajes-Mensual", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ViajeABMCombo3.Items.Add(IdiomaBL.ObtenerMensajeTextos("ABMViajes-Semanal", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ViajeABMCombo3.Items.Add(IdiomaBL.ObtenerMensajeTextos("ABMViajes-Diario", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ViajeABMCombo3.Items.Add(IdiomaBL.ObtenerMensajeTextos("ABMViajes-Especial", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ViajeABMCombo3.SelectedIndex = 0;
            foreach (RutaBE mRuta in rutaBL.Listar())
            {
                ViajeABMCombo1.Items.Add(mRuta.Nombre);
                
            }
            foreach (BusBE mBus in busBL.Listar())
            {
                ViajeABMCombo2.Items.Add(mBus.Patente);
            }
            CargarCampos();
            SetToolTips();
            ViajeABMButton1.Enabled = false;
        }

        private void CargarCampos()
        {
            switch (this.operacion)
            {
                case Operacion.Alta:
                    Limpiar();
                    this.ViajeABMCheckBox1.Enabled = false;
                    break;
                case Operacion.Modificacion:
                    Limpiar();
                    this.ViajeABMCombo1.SelectedIndex = this.viajebe.ID_Ruta-1;
                    this.ViajeABMCombo2.SelectedIndex = this.viajebe.ID_Bus-1;
                    this.ViajeABMDatePickerDesde.Value = this.viajebe.Fecha;
                    this.ViajeABMDatePickerDesdeHora.Value = this.viajebe.Fecha;
                    
                    //Deshabilito botones
                    this.ViajeABMCombo1.Enabled = false;
                    this.ViajeABMCombo3.Enabled = false;
                    this.ViajeABMCombo3.SelectedIndex = 3;
                    this.ViajeABMCheckBox1.Enabled = true;
                    this.ViajeABMDatePickerHasta.Enabled = false;

                    break;
                case Operacion.Baja:
                    Limpiar();
                    this.ViajeABMCombo1.SelectedIndex = this.viajebe.ID_Ruta - 1;
                    this.ViajeABMCombo2.SelectedIndex = this.viajebe.ID_Bus - 1;
                    this.ViajeABMDatePickerDesde.Value = this.viajebe.Fecha;
                    this.ViajeABMDatePickerDesdeHora.Value = this.viajebe.Fecha;
                    this.ViajeABMCheckBox1.Enabled = false;
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
            this.ViajeABMCombo1.Enabled = false;
            this.ViajeABMCombo2.Enabled = false;
            this.ViajeABMCombo3.Enabled = false;
            this.ViajeABMDatePickerDesdeHora.Enabled = false;
            this.ViajeABMDatePickerDesde.Enabled = false;
            this.ViajeABMDatePickerHasta.Enabled = false;
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

        private bool ValidarFecha()
        {
            if (ViajeABMDatePickerDesde.Value.Date + ViajeABMDatePickerDesdeHora.Value.TimeOfDay < DateTime.Now)
            {
                return false;
            }
            if (ViajeABMCombo3.SelectedIndex != 3)
            {
                if (ViajeABMDatePickerDesde.Value.Date + ViajeABMDatePickerDesdeHora.Value.TimeOfDay > ViajeABMDatePickerHasta.Value.Date)
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidarBus()
        {
            DateTime Desde = ViajeABMDatePickerDesde.Value.Date + ViajeABMDatePickerDesdeHora.Value.TimeOfDay;
            DateTime Hasta = ViajeABMDatePickerHasta.Value.Date;
            BusBE busbe = busBL.Obtener(this.ViajeABMCombo2.SelectedIndex + 1);
            RutaBE rutabe = rutaBL.Obtener(this.ViajeABMCombo1.SelectedIndex + 1);
            List<ViajeBE> viajes = viajeBL.ListarBus(this.ViajeABMCombo2.SelectedIndex + 1);

            if (ViajeABMCombo3.SelectedIndex == 3)
            {
                foreach (ViajeBE viaje in viajes)
                {
                    if (!viaje.Cancelado && viajebe.ID_Viaje != viaje.ID_Viaje)
                    {
                        RutaBE ruta = rutaBL.Obtener(viaje.ID_Ruta);
                        DateTime StartA = Desde;
                        DateTime EndA = Desde.AddMinutes(ruta.Duracion);
                        DateTime StartB = viaje.Fecha;
                        DateTime EndB = viaje.Fecha.AddMinutes(ruta.Duracion);
                        if (StartA <= EndB && StartB <= EndA)
                        {
                            return false;
                        }
                    }
               
                }
            }
            else
            {
                while (Desde < Hasta)
                {
                    foreach (ViajeBE viaje in viajes)
                    {
                        if (!viaje.Cancelado)
                        {
                            RutaBE ruta = rutaBL.Obtener(viaje.ID_Ruta);
                            DateTime StartA = Desde;
                            DateTime EndA = Desde.AddMinutes(ruta.Duracion);
                            DateTime StartB = viaje.Fecha;
                            DateTime EndB = viaje.Fecha.AddMinutes(ruta.Duracion);
                            if (StartA <= EndB && StartB <= EndA)
                            {
                                return false;
                            }
                        }
                        
                    }
                    switch (ViajeABMCombo3.SelectedIndex)
                    {
                        case (0):
                            Desde = Desde.AddMonths(1);
                            break;
                        case (1):
                            Desde = Desde.AddDays(7);
                            break;
                        case (2):
                            Desde = Desde.AddDays(1);
                            break;
                        case (3):
                            Desde = Hasta;
                            Desde = Desde.AddYears(100);
                            break;
                    }
                }
            }
            return true;
        }

        private void ViajeABMButton1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            BitacoraBE mBitacora = new BitacoraBE();
            DateTime Desde = ViajeABMDatePickerDesde.Value.Date + ViajeABMDatePickerDesdeHora.Value.TimeOfDay;
            DateTime Hasta = ViajeABMDatePickerHasta.Value.Date;
            try
            {
                switch (this.operacion)
                {
                    case Operacion.Alta:
                        if (!ValidarFecha())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMViaje-Validacion-Fecha", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarBus())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMViaje-Validacion-Bus", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        
                        viajebe.ID_Ruta = ViajeABMCombo1.SelectedIndex + 1;
                        viajebe.ID_Bus = ViajeABMCombo2.SelectedIndex + 1;
                        if (ViajeABMCombo3.SelectedIndex == 3)
                        {
                            viajebe.ID_Viaje = 0;
                            viajebe.Fecha = Desde;
                            viajeBL.Guardar(viajebe);
                            mBitacora.Descripcion = "Se dio de alta al viaje: " + this.viajebe.ID_Viaje;
                            mBitacora.Fecha = DateTime.Now;
                            mBitacora.Nombre_Usuario= SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                            mBitacora.Tipo_Evento = "MEDIUM";
                            bitacorabl.Guardar(mBitacora);
                            flag = true;
                        }
                        else
                        {
                            while (Desde < Hasta)
                            {
                                viajebe.ID_Viaje = 0;
                                viajebe.Fecha = Desde;
                                viajeBL.Guardar(viajebe);
                                switch (ViajeABMCombo3.SelectedIndex)
                                {
                                    case (0):
                                        Desde = Desde.AddMonths(1);
                                        break;
                                    case (1):
                                        Desde = Desde.AddDays(7);
                                        break;
                                    case (2):
                                        Desde = Desde.AddDays(1);
                                        break;
                                }
                                mBitacora.Descripcion = "Se dio de alta al viaje: " + this.viajebe.ID_Viaje;
                                mBitacora.Fecha = DateTime.Now;
                                mBitacora.Nombre_Usuario= SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                                mBitacora.Tipo_Evento = "MEDIUM";
                                bitacorabl.Guardar(mBitacora);
                                flag = true;
                            }
                        }
                        
                        break;
                    case Operacion.Modificacion:
                        if (!ValidarFecha())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMViaje-Validacion-Fecha", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (!ValidarBus())
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMViaje-Validacion-Bus", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        //viajebe.ID_Ruta = ViajeABMCombo1.SelectedIndex + 1;
                        viajebe.ID_Bus = ViajeABMCombo2.SelectedIndex + 1;
                        viajebe.Fecha = Desde;
                        viajeBL.Guardar(viajebe);
                        mBitacora.Descripcion = "Se modifico el viaje: " + this.viajebe.ID_Viaje;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.Nombre_Usuario= SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                        mBitacora.Tipo_Evento = "MEDIUM";
                        bitacorabl.Guardar(mBitacora);
                        flag = true;
                        break;
                    case Operacion.Baja:
                        DialogResult result = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMViajes-Confirmacion-Baja", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.viajebe.Cancelado = true;
                            this.viajeBL.Guardar(viajebe);
                        }
                        //Bitacora
                        mBitacora.Descripcion = "Se cancelo el viaje: " + this.viajebe.ID_Viaje;
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
                mBitacora.Descripcion = "Error al operar con Rutas";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.Nombre_Usuario= SingletonSesion.Instancia.Usuario.Nombre_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMViajes-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void ViajeABMButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViajeABMCombo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ViajeABMCombo3.SelectedItem.ToString() == "Especial")
            {
                this.ViajeABMDatePickerHasta.Enabled = false;
            }
            else
            {
                this.ViajeABMDatePickerHasta.Enabled = true;
            }

            if (ViajeABMCombo3.SelectedItem.ToString().Length >0 && ViajeABMCombo1.SelectedItem.ToString().Length > 0 && ViajeABMCombo2.SelectedItem.ToString().Length > 0)
            {
                ViajeABMButton1.Enabled = true;
            }
            else
            {
                ViajeABMButton1.Enabled = false;
            }
        }

        private void ViajeABMCombo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViajeABMCombo3.SelectedItem.ToString().Length > 0 && ViajeABMCombo1.SelectedItem.ToString().Length > 0 && ViajeABMCombo2.SelectedItem.ToString().Length > 0)
            {
                ViajeABMButton1.Enabled = true;
            }
            else
            {
                ViajeABMButton1.Enabled = false;
            }
        }

        private void ViajeABMCombo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViajeABMCombo3.SelectedItem.ToString().Length > 0 && ViajeABMCombo1.SelectedItem.ToString().Length > 0 && ViajeABMCombo2.SelectedItem.ToString().Length > 0)
            {
                ViajeABMButton1.Enabled = true;
            }
            else
            {
                ViajeABMButton1.Enabled = false;
            }
        }
    }
}
