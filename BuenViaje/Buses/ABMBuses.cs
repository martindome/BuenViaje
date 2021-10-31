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

namespace BuenViaje.Buses
{
    public partial class ABMBuses : Form
    {

        internal Operacion operacion;
        internal BusBE busbe;
        internal BusBL busbl= new BusBL();
        internal BitacoraBL bitacorabl = new BitacoraBL();
        public ABMBuses()
        {
            InitializeComponent();
        }

        private void ABMBuses_Load(object sender, EventArgs e)
        {
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("ABMBuses-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            CargarCampos();
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
                        if (!Regex.IsMatch(this.ABMBusesTexto1.Text, "[A-Za-z0-9]+"))
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMBuses-ValidacionPatente-Bus", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.busbe.Patente = this.ABMBusesTexto1.Text.ToUpper();
                        this.busbe.Marca = this.ABMBusesTexto2.Text;
                        this.busbe.Asientos = int.Parse(this.ABMBusesTexto3.Text);
                        this.busbl.Guardar(busbe);
                        mBitacora.Descripcion = "Se dio de alta al bus: " + this.busbe.Patente;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
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
                        if (!Regex.IsMatch(this.ABMBusesTexto1.Text, "[A-Za-z0-9]+"))
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMBuses-ValidacionPatente-Bus", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        this.busbe.Patente = this.ABMBusesTexto1.Text;
                        this.busbe.Marca = this.ABMBusesTexto2.Text;
                        this.busbe.Asientos = int.Parse(this.ABMBusesTexto3.Text);
                        this.busbl.Guardar(busbe);
                        mBitacora.Descripcion = "Se modifico el bus: " + this.busbe.Patente;
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
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
                mBitacora.Descripcion = "Error al operar con buses";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMBuses-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void ABMBusessBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
