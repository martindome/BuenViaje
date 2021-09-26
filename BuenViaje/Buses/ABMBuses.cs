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

        }
    }
}
