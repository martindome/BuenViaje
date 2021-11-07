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

namespace BuenViaje.Pasajes
{
    public partial class DevolucionPasajes : Form
    {
        internal ClienteBE clientebe;
        internal Operacion operacion;
        internal ViajeBE viajebe;
        internal ViajeBL viajeBL = new ViajeBL();
        internal RutaBL rutaBL = new RutaBL();
        internal BusBL busBL = new BusBL();
        internal PasajeBL pasajeBL = new PasajeBL();
        internal BitacoraBL bitacorabl = new BitacoraBL();
        public DevolucionPasajes()
        {
            InitializeComponent();
        }

        private void DevolucionPasajes_Load(object sender, EventArgs e)
        {
            pasajeDateTimePicker1.CustomFormat = "MM-dd-yyyy";
            pasajeDateTimePicker1.Format = DateTimePickerFormat.Custom;

            pasajeDateTimePicker2.CustomFormat = "MM-dd-yyyy";
            pasajeDateTimePicker2.Format = DateTimePickerFormat.Custom;
            pasajeDateTimePicker2.Value = DateTime.Now.AddDays(7);

            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("Devolucion-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);

            pasajesDevolucionDataGridViajes.Rows.Clear();
            pasajesDevolucionDataGridViajes.Columns.Clear();
            pasajesDevolucionDataGridViajes.Columns.Add(IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-ViajeID", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-ViajeID", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            pasajesDevolucionDataGridViajes.Columns.Add(IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-RutaID", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-RutaID", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            pasajesDevolucionDataGridViajes.Columns.Add(IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-BusID", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-BusID", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            pasajesDevolucionDataGridViajes.Columns.Add(IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-Origen", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-Origen", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            pasajesDevolucionDataGridViajes.Columns.Add(IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-Destino", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-Destino", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            pasajesDevolucionDataGridViajes.Columns.Add(IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-Fecha", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-Fecha", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            pasajesDevolucionDataGridViajes.Columns.Add(IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-PasajeID", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-PasajeID", SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            pasajesDevolucionDataGridViajes.Columns[IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-ViajeID", SingletonSesion.Instancia.Usuario.Idioma_Descripcion)].Visible = false;
            pasajesDevolucionDataGridViajes.Columns[IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-RutaID", SingletonSesion.Instancia.Usuario.Idioma_Descripcion)].Visible = false;
            pasajesDevolucionDataGridViajes.Columns[IdiomaBL.ObtenerMensajeTextos("PasajePrincipal-Columna-BusID", SingletonSesion.Instancia.Usuario.Idioma_Descripcion)].Visible = false;

            pasajesDevolucionDataGridViajes.MultiSelect = false;
            pasajesDevolucionDataGridViajes.EditMode = DataGridViewEditMode.EditProgrammatically;
            pasajesDevolucionDataGridViajes.AllowUserToAddRows = false;
            pasajesDevolucionDataGridViajes.AllowUserToDeleteRows = false;
            pasajesDevolucionDataGridViajes.AllowUserToResizeColumns = true;
            pasajesDevolucionDataGridViajes.AllowUserToResizeRows = false;
            pasajesDevolucionDataGridViajes.RowHeadersVisible = false;
            pasajesDevolucionDataGridViajes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pasajesDevolucionDataGridViajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pasajesDevolucionDataGridViajes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            pasajesDevolucionDataGridViajes.Rows.Clear();

            //CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            ActualizarGrillasPasajeViajes();
        }

        private void ActualizarGrillasPasajeViajes()
        {
            //Viajes
            this.pasajesDevolucionDataGridViajes.Rows.Clear();
            ViajeBL viajebl = new ViajeBL();
            BusBL busbl = new BusBL();
            RutaBL rutabl = new RutaBL();
            PasajeBL pasajebl = new PasajeBL();
            DateTime Desde = pasajeDateTimePicker1.Value.Date;
            DateTime Hasta = pasajeDateTimePicker2.Value.Date;
            foreach (ViajeBE viaje in viajebl.Listar(Desde, Hasta))
            {
                List<PasajeBE> PasajesViaje = pasajebl.ListarClienteDevueltos(viaje.ID_Viaje);
                foreach (PasajeBE pasaje in PasajesViaje)
                {
                    if (pasaje.ID_Viaje == viaje.ID_Viaje)
                    {
                        BusBE bus = busbl.Obtener(viaje.ID_Bus);
                        bool flag = true;
                        RutaBE rutabe = rutabl.Obtener(viaje.ID_Ruta);
                        //if (this.RutasPrincipalText2.Text != "" && this.RutasPrincipalText2.Text != rutabe.Origen.Nombre)
                        if (this.pasajesPrincipalTextBox4.Text != "" && !(rutabe.Origen.Nombre.Contains(this.pasajesPrincipalTextBox4.Text) || rutabe.Origen.Provincia.Contains(this.pasajesPrincipalTextBox4.Text) || rutabe.Origen.Pais.Contains(this.pasajesPrincipalTextBox4.Text)))
                        {
                            flag = false;
                        }
                        //if (this.RutasPrincipalText3.Text != "" && this.RutasPrincipalText3.Text != rutabe.Destino.Nombre)
                        if (this.pasajesPrincipalTextBox5.Text != "" && !(rutabe.Destino.Nombre.Contains(this.pasajesPrincipalTextBox5.Text) || rutabe.Destino.Provincia.Contains(this.pasajesPrincipalTextBox5.Text) || rutabe.Destino.Pais.Contains(this.pasajesPrincipalTextBox5.Text)))
                        {
                            flag = false;
                        }

                        if (flag)
                        {
                            pasajesDevolucionDataGridViajes.Rows.Add(viaje.ID_Viaje, viaje.ID_Ruta, viaje.ID_Bus, rutabe.Origen.Pais + "-" + rutabe.Origen.Provincia + "-" + rutabe.Origen.Nombre, rutabe.Destino.Pais + "-" + rutabe.Destino.Provincia + "-" + rutabe.Destino.Nombre, viaje.Fecha, pasaje.ID_Pasaje);
                        }
                    }
                }
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

        private void pasajesPrincipalButton2_Click(object sender, EventArgs e)
        {
            ActualizarGrillasPasajeViajes();
        }

        private void DevolucionText1_Click(object sender, EventArgs e)
        {
            try
            {
                pasajeBL.Devolver(pasajeBL.Obtener(int.Parse(pasajesDevolucionDataGridViajes.SelectedRows[0].Cells[6].Value.ToString())));
                BitacoraBL Bitacorabl = new BitacoraBL();
                BitacoraBE mBitacora = new BitacoraBE();
                mBitacora.Descripcion = "Devulto pasaje: " + int.Parse(pasajesDevolucionDataGridViajes.SelectedRows[0].Cells[0].Value.ToString());
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                mBitacora.Tipo_Evento = "MEDIUM";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Devolucion-Info-Correcta", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarGrillasPasajeViajes();
            }
            catch (Exception ex)
            {
                BitacoraBL Bitacorabl = new BitacoraBL();
                BitacoraBE mBitacora = new BitacoraBE();
                mBitacora.Descripcion = "Error al devolver pasaje";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Devolucion-Error-Exception", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
        }

        private void DevolucionText2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
