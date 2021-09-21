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

namespace BuenViaje.Administracion.Backup
{
    public partial class Restore : Form
    {
        List<string> archivos;
        public Restore()
        {
            InitializeComponent();
        }

        private void Restore_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToParent();
            archivos = new List<string>();
            RestoreGrilla1.Columns.Add(ObtenerMensajeColumna("Restore-Columna-Volumen"), ObtenerMensajeColumna("Restore-Columna-Volumen"));
            RestoreGrilla1.RowHeadersVisible = false;
            RestoreGrilla1.AllowUserToAddRows = false;
            RestoreGrilla1.AllowUserToDeleteRows = false;
            RestoreGrilla1.EditMode = DataGridViewEditMode.EditProgrammatically;
            RestoreGrilla1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RestoreGrilla1.AutoResizeColumns();

            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("Restore-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
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
                    if (C is GroupBox)
                    {
                        foreach (Control InnerControl in C.Controls)
                        {
                            foreach (ControlBE InnerC in pControles)
                            {
                                if (InnerC.ID_Control == InnerControl.Name)
                                {
                                    InnerControl.Text = InnerC.Mensaje;
                                }
                                if (InnerControl is GroupBox)
                                {
                                    foreach (Control DoubleInnerControl in InnerControl.Controls)
                                    {
                                        foreach (ControlBE DoubleInnerC in pControles)
                                        {
                                            if (DoubleInnerC.ID_Control == DoubleInnerControl.Name)
                                            {
                                                DoubleInnerControl.Text = DoubleInnerC.Mensaje;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private string ObtenerMensajeColumna(string pstring)
        {
            return IdiomaBL.ObtenerMensajeTextos(pstring, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
        }

        private void RestoreButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            RestoreGrilla1.Rows.Clear();
            archivos.Clear();
            fileDialog.Filter = "bak files (*.bak)|*.bak|All files (*.*)|*.*";
            fileDialog.Multiselect = true;
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (String file in fileDialog.FileNames)
                {
                    RestoreGrilla1.Rows.Add(file);
                    archivos.Add(file);
                }
            }
        }

        private void RestoreButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarArchivos() && archivos.Count > 0)
                {
                    DialogResult resultado = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Restore-Confirmacion-Ejecucion", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    try
                    {
                        BackupBL backupBl = new BackupBL();
                        backupBl.RealizarRestore(archivos);
                        BitacoraBE mBitacora = new BitacoraBE();
                        BitacoraBL Bitacorabl = new BitacoraBL();
                        mBitacora.Descripcion = "Se realizo una restauracion del sistema";
                        mBitacora.Fecha = DateTime.Now;
                        mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                        mBitacora.Tipo_Evento = "HIGH";
                        Bitacorabl.Guardar(mBitacora);
                        MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Restore-Confirmacion-Backup", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Restore-Validacion-Rutas", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                BitacoraBE mBitacora = new BitacoraBE();
                BitacoraBL Bitacorabl = new BitacoraBL();
                mBitacora.Descripcion = "Error al restaurar el sistema";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Restore-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
            
        }

        private bool ValidarArchivos()
        {
            foreach (string file in archivos)
            {
                if (!File.Exists(file))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
