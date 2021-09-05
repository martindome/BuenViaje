using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BL;
using BE;

namespace BuenViaje
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton1_Click(object sender, EventArgs e)
        {

        }

        private void LoginBotton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load (object sender, EventArgs e)
        {
            string mIdioma = ConfigurationManager.AppSettings.Get("Idioma");
            
            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(mIdioma));
        }

        private void CargarIdioma (List<ControlBE> Lista)
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
