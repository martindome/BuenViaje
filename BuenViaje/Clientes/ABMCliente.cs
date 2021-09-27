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

namespace BuenViaje.Clientes
{
    public partial class ABMCliente : Form
    {
        internal Operacion operacion;
        internal ClienteBE clientebe;
        internal ClienteBL clientebl = new ClienteBL();
        internal BitacoraBL bitacorabl = new BitacoraBL();

        public ABMCliente()
        {
            InitializeComponent();
        }

        private void ABMCliente_Load(object sender, EventArgs e)
        {
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("ABMClientes-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
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
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
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
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
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
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("ABMClientes-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void ABMClientesBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
