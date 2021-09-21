﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BE;
using BL;

namespace BuenViaje.Administracion.Backup
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToParent();
            for (int i = 1; i < 6; i++)
            {
                BackupComboBox1.Items.Add(i);
            }
            BackupComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            BackupComboBox1.SelectedIndex = 0;
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("Backup-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
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

        private void BackupButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                this.BackupText1.Text = fbd.SelectedPath;
            }
        }

        private void BackupButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarRuta())
                {
                    DialogResult resultado = MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Backup-Confirmacion-Ejecucion", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        try
                        {
                            BackupBL backupBl = new BackupBL();
                            backupBl.RealizarBackup(int.Parse(this.BackupComboBox1.SelectedItem.ToString()), this.BackupText1.Text);
                            BitacoraBE mBitacora = new BitacoraBE();
                            BitacoraBL Bitacorabl = new BitacoraBL();
                            mBitacora.Descripcion = "Se realizo una copia de seguridad";
                            mBitacora.Fecha = DateTime.Now;
                            mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                            mBitacora.Tipo_Evento = "HIGH";
                            Bitacorabl.Guardar(mBitacora);
                            MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Backup-Confirmacion-Backup", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Backup-Validacion-Ruta", SingletonSesion.Instancia.Usuario.Idioma_Descripcion), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                BitacoraBE mBitacora = new BitacoraBE();
                BitacoraBL Bitacorabl = new BitacoraBL();
                mBitacora.Descripcion = "Error al realizar una copia de seguridad";
                mBitacora.Fecha = DateTime.Now;
                mBitacora.ID_Usuario = SingletonSesion.Instancia.Usuario.ID_Usuario;
                mBitacora.Tipo_Evento = "HIGH";
                Bitacorabl.Guardar(mBitacora);
                MessageBox.Show(IdiomaBL.ObtenerMensajeTextos("Backup-Error-Aplicar", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private bool ValidarRuta()
        {
            return Directory.Exists(this.BackupText1.Text);
        }
    }
}
