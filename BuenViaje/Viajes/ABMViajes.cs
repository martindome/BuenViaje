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

            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("ABMRutas-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            ViajeABMCombo1.DropDownStyle = ComboBoxStyle.DropDownList;
            ViajeABMCombo2.DropDownStyle = ComboBoxStyle.DropDownList;
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
                    this.ViajeABMCheckBox1.Enabled = true;
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
            this.ViajeABMDatePickerDesdeHora.Enabled = false;
            this.ViajeABMDatePickerDesde.Enabled = false;
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

        private void ViajeABMButton1_Click(object sender, EventArgs e)
        {

        }

        private void ViajeABMButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
