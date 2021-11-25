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
using System.IO;
using System.Configuration;

namespace BuenViaje
{
    public partial class Inicio : Form
    {

        BL.IniciadorBL mIniciador = new IniciadorBL();
        public Inicio()
        {
            InitializeComponent();
        }

        private void InicioTimer1_Tick(object sender, EventArgs e)
        {
            this.InicioProgressBar1.Increment(1);
        }

        private void InicioProgressBar1_Click(object sender, EventArgs e)
        {
            this.InicioTimer1.Start();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToScreen();
            string mIdioma = ConfigurationManager.AppSettings.Get("Idioma");
            bool fallos = false;
            try
            {
                try
                {
                    if (!ChequearConexionBD())
                    {
                        //BitacoraBE mBitacora = new BitacoraBE();
                        //BitacoraBL bitacoraBL = new BitacoraBL();

                        //mBitacora.Descripcion = "Error conexion base de datos";
                        //mBitacora.Tipo_Evento = "HIGH";
                        //mBitacora.Fecha = DateTime.Now;
                        //mBitacora.Nombre_Usuario = "NULL";
                        //bitacoraBL.Guardar(mBitacora);
                        try
                        {
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Inicio-Error-ConexionBaseDatos", mIdioma), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch
                        {
                            MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        fallos = true;
                        //this.Close();
                    }
                }
                catch (Exception ex) 
                {
                    try
                    {
                        MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Inicio-Error-ConexionBaseDatos", mIdioma) + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    fallos = true;
                }
                //CargarIdioma(IdiomaBL.ObtenerMensajeControladores(mIdioma));
                try
                {
                    if (ChequearIntegridadBD() && !fallos)
                    {
                        MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Inicio-Info-CargaCorrecta", mIdioma), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Login mLogin = new Login();
                        mLogin.fallos = false;
                        mLogin.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        fallos = true;
                    }
                    //this.Close();
                }
                catch (Exception ex)
                {
                    try
                    {
                        BitacoraBE mBitacora = new BitacoraBE();
                        BitacoraBL bitacoraBL = new BitacoraBL();
                        mBitacora.Descripcion = "Error Integridad base de datos";
                        mBitacora.Tipo_Evento = "HIGH";
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.Nombre_Usuario = "NULL";
                        bitacoraBL.Guardar(mBitacora);
                    }
                    catch { }  
                    fallos = true;
                    try
                    {
                        MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Inicio-Error-IntegridadBaseDatos", mIdioma) + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //this.Close();
                }
                if (fallos)
                {
                    Login mLoginFallos = new Login();
                    mLoginFallos.fallos = true;
                    mLoginFallos.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    BitacoraBE mBitacora = new BitacoraBE();
                    BitacoraBL bitacoraBL = new BitacoraBL();
                    mBitacora.Descripcion = "Error Carga del programa";
                    mBitacora.Tipo_Evento = "HIGH";
                    mBitacora.Fecha = DateTime.Now;
                    mBitacora.Nombre_Usuario = "NULL";
                    bitacoraBL.Guardar(mBitacora);
                }
                catch { }
                
                try
                {
                    MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Inicio-Error-CargaIncorrecta", mIdioma) + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private bool ChequearConexionBD()
        {
            try
            {
                mIniciador.ConectarBD();
                this.InicioProgressBar1.Increment(50);
                return true;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private bool ChequearIntegridadBD()
        {
            try
            {
                mIniciador.ChequearIntegridad();
                this.InicioProgressBar1.Increment(50);
                return true;
            }
            catch (Exception ex) { throw (ex); }
        }

        private void CargarIdioma(List<ControlBE> Lista)
        {
            foreach (Control Control in this.Controls)
            {
                foreach (ControlBE c in Lista)
                {
                    if (c.ID_Control == Control.Name)
                    {
                        Control.Text = c.Mensaje;
                    }
                }
            }
        }

    }
}
