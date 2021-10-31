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

        private bool ValidarFecha()
        {
            if (ViajeABMDatePickerDesde.Value.Date + ViajeABMDatePickerDesdeHora.Value.TimeOfDay < DateTime.Now)
            {
                return false;
            }
            
            if (ViajeABMDatePickerDesde.Value.Date + ViajeABMDatePickerDesdeHora.Value.TimeOfDay <= ViajeABMDatePickerHasta.Value.Date)
            {
                return false;
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
                    RutaBE ruta = rutaBL.Obtener(viaje.ID_Ruta);
                    if (Desde > viaje.Fecha && Desde < viaje.Fecha.AddMinutes(ruta.Duracion))
                    {
                        return false;
                    }
                }
            }
            else
            {
                while (Desde < Hasta)
                {
                    foreach (ViajeBE viaje in viajes)
                    {
                        RutaBE ruta = rutaBL.Obtener(viaje.ID_Ruta);
                        if (Desde > viaje.Fecha && Desde < viaje.Fecha.AddMinutes(ruta.Duracion))
                        {
                            return false;
                        }
                    }
                    switch (ViajeABMCombo3.SelectedIndex)
                    {
                        case (0):
                            Desde.AddMonths(1);
                            break;
                        case (1):
                            Desde.AddDays(7);
                            break;
                        case (2):
                            Desde.AddDays(1);
                            break;
                        case (3):
                            Desde = Hasta;
                            Desde.AddYears(100);
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
                            mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
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
                                        Desde.AddMonths(1);
                                        break;
                                    case (1):
                                        Desde.AddDays(7);
                                        break;
                                    case (2):
                                        Desde.AddDays(1);
                                        break;
                                }
                                mBitacora.Descripcion = "Se dio de alta al viaje: " + this.viajebe.ID_Viaje;
                                mBitacora.Fecha = DateTime.Now;
                                mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
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
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
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
        }
    }
}
