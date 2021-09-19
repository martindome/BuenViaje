﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using BE;
using BE.Composite;

namespace BuenViaje.Administracion.Permisos
{
    public partial class PermisosPrincipal : Form
    {
        FamiliaBL familiabl = new FamiliaBL();
        PatenteBL patentebl = new PatenteBL();

        public PermisosPrincipal()
        {
            InitializeComponent();
        }

        private void PermisosPrincipal_Load(object sender, EventArgs e)
        {
            grillaFamilias.Columns.Add(ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaID"), ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaID"));
            grillaFamilias.Columns.Add(ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaNombre"), ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaNombre"));
            grillaFamilias.Columns.Add(ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaDescripcion"), ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaDescripcion"));
            grillaFamilias.Columns[ObtenerMensajeColumna("PermisosPrincipal-Columna-FamiliaID")].Visible = false;


            grillaFamilias.MultiSelect = false;
            grillaFamilias.EditMode = DataGridViewEditMode.EditProgrammatically;
            grillaFamilias.AllowUserToAddRows = false;
            grillaFamilias.AllowUserToDeleteRows = false;
            grillaFamilias.AllowUserToResizeColumns = true;
            grillaFamilias.AllowUserToResizeRows = false;
            grillaFamilias.RowHeadersVisible = false;
            grillaFamilias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaFamilias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grillaFamilias.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (SingletonSesion.Instancia.VerificarPermiso(BE.Composite.TipoPermiso.AdminPermisos))
            {
                PermisosPrincipalBotton2.Enabled = true;
                PermisosPrincipalBotton3.Enabled = true;
                PermisosPrincipalBotton4.Enabled = true;
            }
            else
            {
                PermisosPrincipalBotton2.Enabled = false;
                PermisosPrincipalBotton3.Enabled = false;
                PermisosPrincipalBotton4.Enabled = false;
            }

            ActualizarGrilla();
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("PermisosPrincipal-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);

        }

        private string ObtenerMensajeColumna(string pstring)
        {
            return IdiomaBL.ObtenerMensajeTextos(pstring, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
        }

        private void ActualizarGrilla()
        {
            List<FamiliaBE> familias = familiabl.Listar();
            List<PatenteBE> patentes = patentebl.Listar();
            grillaFamilias.Rows.Clear();
            foreach (FamiliaBE familia in familias)
            {
                bool flag = true;
                if (this.PermisosPrinciplaText1.Text != "" && this.PermisosPrinciplaText1.Text != familia.Nombre)
                {
                    flag = false;
                }
                if (this.PermisosPrinciplaText2.Text != "" && this.PermisosPrinciplaText2.Text != familia.Descripcion)
                {
                    flag = false;
                }
                if (flag)
                {
                    grillaFamilias.Rows.Add(familia.ID_Compuesto, familia.Nombre, familia.Descripcion);
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

        private void PermisosPrincipalBotton5_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void PermisosPrincipalBotton6_Click(object sender, EventArgs e)
        {
            this.PermisosPrinciplaText1.Text = "";
            this.PermisosPrinciplaText2.Text = "";
            ActualizarGrilla();
        }
    }
}