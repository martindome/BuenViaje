namespace BuenViaje
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiaDeSeguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restauracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInicio = new System.Windows.Forms.TabPage();
            this.tabPagePasajes = new System.Windows.Forms.TabPage();
            this.tabPageClientes = new System.Windows.Forms.TabPage();
            this.tabPageViajes = new System.Windows.Forms.TabPage();
            this.tabPageRutas = new System.Windows.Forms.TabPage();
            this.tabPageLocalidades = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Azure;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sesionToolStripMenuItem,
            this.administracionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1155, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sesionToolStripMenuItem
            // 
            this.sesionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarIdiomaToolStripMenuItem,
            this.cambiarContraseñaToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.sesionToolStripMenuItem.Name = "sesionToolStripMenuItem";
            this.sesionToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.sesionToolStripMenuItem.Text = "Sesion";
            // 
            // cambiarIdiomaToolStripMenuItem
            // 
            this.cambiarIdiomaToolStripMenuItem.Name = "cambiarIdiomaToolStripMenuItem";
            this.cambiarIdiomaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cambiarIdiomaToolStripMenuItem.Text = "Cambiar Idioma";
            this.cambiarIdiomaToolStripMenuItem.Click += new System.EventHandler(this.cambiarIdiomaToolStripMenuItem_Click);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar Contraseña";
            this.cambiarContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambiarContraseñaToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitacoraToolStripMenuItem,
            this.gestionarUsuariosToolStripMenuItem,
            this.gestionarPermisosToolStripMenuItem,
            this.copiaDeSeguridadToolStripMenuItem,
            this.restauracionToolStripMenuItem});
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administracionToolStripMenuItem.Text = "Administracion";
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.bitacoraToolStripMenuItem.Text = "Bitacora";
            this.bitacoraToolStripMenuItem.Click += new System.EventHandler(this.bitacoraToolStripMenuItem_Click);
            // 
            // gestionarUsuariosToolStripMenuItem
            // 
            this.gestionarUsuariosToolStripMenuItem.Name = "gestionarUsuariosToolStripMenuItem";
            this.gestionarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.gestionarUsuariosToolStripMenuItem.Text = "Gestionar Usuarios";
            this.gestionarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.gestionarUsuariosToolStripMenuItem_Click);
            // 
            // gestionarPermisosToolStripMenuItem
            // 
            this.gestionarPermisosToolStripMenuItem.Name = "gestionarPermisosToolStripMenuItem";
            this.gestionarPermisosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.gestionarPermisosToolStripMenuItem.Text = "Gestionar Permisos";
            this.gestionarPermisosToolStripMenuItem.Click += new System.EventHandler(this.gestionarPermisosToolStripMenuItem_Click);
            // 
            // copiaDeSeguridadToolStripMenuItem
            // 
            this.copiaDeSeguridadToolStripMenuItem.Name = "copiaDeSeguridadToolStripMenuItem";
            this.copiaDeSeguridadToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.copiaDeSeguridadToolStripMenuItem.Text = "Copia de seguridad";
            this.copiaDeSeguridadToolStripMenuItem.Click += new System.EventHandler(this.copiaDeSeguridadToolStripMenuItem_Click);
            // 
            // restauracionToolStripMenuItem
            // 
            this.restauracionToolStripMenuItem.Name = "restauracionToolStripMenuItem";
            this.restauracionToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.restauracionToolStripMenuItem.Text = "Restauracion";
            this.restauracionToolStripMenuItem.Click += new System.EventHandler(this.restauracionToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInicio);
            this.tabControl1.Controls.Add(this.tabPagePasajes);
            this.tabControl1.Controls.Add(this.tabPageClientes);
            this.tabControl1.Controls.Add(this.tabPageViajes);
            this.tabControl1.Controls.Add(this.tabPageRutas);
            this.tabControl1.Controls.Add(this.tabPageLocalidades);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(159, 20);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1155, 580);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageInicio
            // 
            this.tabPageInicio.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPageInicio.Location = new System.Drawing.Point(4, 24);
            this.tabPageInicio.Name = "tabPageInicio";
            this.tabPageInicio.Size = new System.Drawing.Size(1147, 552);
            this.tabPageInicio.TabIndex = 5;
            this.tabPageInicio.Text = "Inicio";
            // 
            // tabPagePasajes
            // 
            this.tabPagePasajes.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPagePasajes.Location = new System.Drawing.Point(4, 24);
            this.tabPagePasajes.Name = "tabPagePasajes";
            this.tabPagePasajes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePasajes.Size = new System.Drawing.Size(1147, 552);
            this.tabPagePasajes.TabIndex = 0;
            this.tabPagePasajes.Text = "Pasajes";
            // 
            // tabPageClientes
            // 
            this.tabPageClientes.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPageClientes.Location = new System.Drawing.Point(4, 24);
            this.tabPageClientes.Name = "tabPageClientes";
            this.tabPageClientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClientes.Size = new System.Drawing.Size(1147, 552);
            this.tabPageClientes.TabIndex = 1;
            this.tabPageClientes.Text = "Clientes";
            // 
            // tabPageViajes
            // 
            this.tabPageViajes.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPageViajes.Location = new System.Drawing.Point(4, 24);
            this.tabPageViajes.Name = "tabPageViajes";
            this.tabPageViajes.Size = new System.Drawing.Size(1147, 552);
            this.tabPageViajes.TabIndex = 2;
            this.tabPageViajes.Text = "Viajes";
            // 
            // tabPageRutas
            // 
            this.tabPageRutas.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPageRutas.Location = new System.Drawing.Point(4, 24);
            this.tabPageRutas.Name = "tabPageRutas";
            this.tabPageRutas.Size = new System.Drawing.Size(1147, 552);
            this.tabPageRutas.TabIndex = 3;
            this.tabPageRutas.Text = "Rutas";
            // 
            // tabPageLocalidades
            // 
            this.tabPageLocalidades.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPageLocalidades.Location = new System.Drawing.Point(4, 24);
            this.tabPageLocalidades.Name = "tabPageLocalidades";
            this.tabPageLocalidades.Size = new System.Drawing.Size(1147, 552);
            this.tabPageLocalidades.TabIndex = 4;
            this.tabPageLocalidades.Text = "Localidades";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1155, 604);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiaDeSeguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restauracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePasajes;
        private System.Windows.Forms.TabPage tabPageClientes;
        private System.Windows.Forms.TabPage tabPageViajes;
        private System.Windows.Forms.TabPage tabPageRutas;
        private System.Windows.Forms.TabPage tabPageLocalidades;
        private System.Windows.Forms.TabPage tabPageInicio;
    }
}