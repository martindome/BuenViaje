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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.LocalidadGroupBox = new System.Windows.Forms.GroupBox();
            this.LocalidadBotton6 = new System.Windows.Forms.Button();
            this.LocalidadBotton5 = new System.Windows.Forms.Button();
            this.LocalidadLabel2 = new System.Windows.Forms.Label();
            this.LocalidadPrincipalText2 = new System.Windows.Forms.TextBox();
            this.LocalidadLabel1 = new System.Windows.Forms.Label();
            this.LocalidadPrincipalText1 = new System.Windows.Forms.TextBox();
            this.LocalidadBotton4 = new System.Windows.Forms.Button();
            this.LocalidadBotton3 = new System.Windows.Forms.Button();
            this.LocalidadBotton2 = new System.Windows.Forms.Button();
            this.LocalidadBotton1 = new System.Windows.Forms.Button();
            this.grillaLocalidad = new System.Windows.Forms.DataGridView();
            this.LocalidadLabel3 = new System.Windows.Forms.Label();
            this.LocalidadPrincipalText3 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageLocalidades.SuspendLayout();
            this.LocalidadGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaLocalidad)).BeginInit();
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
            this.tabPageLocalidades.Controls.Add(this.LocalidadGroupBox);
            this.tabPageLocalidades.Controls.Add(this.LocalidadBotton4);
            this.tabPageLocalidades.Controls.Add(this.LocalidadBotton3);
            this.tabPageLocalidades.Controls.Add(this.LocalidadBotton2);
            this.tabPageLocalidades.Controls.Add(this.LocalidadBotton1);
            this.tabPageLocalidades.Controls.Add(this.grillaLocalidad);
            this.tabPageLocalidades.Location = new System.Drawing.Point(4, 24);
            this.tabPageLocalidades.Name = "tabPageLocalidades";
            this.tabPageLocalidades.Size = new System.Drawing.Size(1147, 552);
            this.tabPageLocalidades.TabIndex = 4;
            this.tabPageLocalidades.Text = "Localidades";
            this.tabPageLocalidades.Click += new System.EventHandler(this.tabPageLocalidades_Click);
            // 
            // LocalidadGroupBox
            // 
            this.LocalidadGroupBox.Controls.Add(this.LocalidadLabel3);
            this.LocalidadGroupBox.Controls.Add(this.LocalidadPrincipalText3);
            this.LocalidadGroupBox.Controls.Add(this.LocalidadBotton6);
            this.LocalidadGroupBox.Controls.Add(this.LocalidadBotton5);
            this.LocalidadGroupBox.Controls.Add(this.LocalidadLabel2);
            this.LocalidadGroupBox.Controls.Add(this.LocalidadPrincipalText2);
            this.LocalidadGroupBox.Controls.Add(this.LocalidadLabel1);
            this.LocalidadGroupBox.Controls.Add(this.LocalidadPrincipalText1);
            this.LocalidadGroupBox.Location = new System.Drawing.Point(533, 5);
            this.LocalidadGroupBox.Name = "LocalidadGroupBox";
            this.LocalidadGroupBox.Size = new System.Drawing.Size(252, 237);
            this.LocalidadGroupBox.TabIndex = 23;
            this.LocalidadGroupBox.TabStop = false;
            this.LocalidadGroupBox.Text = "Filtros";
            // 
            // LocalidadBotton6
            // 
            this.LocalidadBotton6.Location = new System.Drawing.Point(176, 161);
            this.LocalidadBotton6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LocalidadBotton6.Name = "LocalidadBotton6";
            this.LocalidadBotton6.Size = new System.Drawing.Size(71, 27);
            this.LocalidadBotton6.TabIndex = 19;
            this.LocalidadBotton6.Text = "Limpiar";
            this.LocalidadBotton6.UseVisualStyleBackColor = true;
            this.LocalidadBotton6.Click += new System.EventHandler(this.LocalidadBotton6_Click);
            // 
            // LocalidadBotton5
            // 
            this.LocalidadBotton5.Location = new System.Drawing.Point(3, 161);
            this.LocalidadBotton5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LocalidadBotton5.Name = "LocalidadBotton5";
            this.LocalidadBotton5.Size = new System.Drawing.Size(71, 27);
            this.LocalidadBotton5.TabIndex = 18;
            this.LocalidadBotton5.Text = "Aplicar";
            this.LocalidadBotton5.UseVisualStyleBackColor = true;
            this.LocalidadBotton5.Click += new System.EventHandler(this.LocalidadBotton5_Click);
            // 
            // LocalidadLabel2
            // 
            this.LocalidadLabel2.AutoSize = true;
            this.LocalidadLabel2.Location = new System.Drawing.Point(0, 66);
            this.LocalidadLabel2.Name = "LocalidadLabel2";
            this.LocalidadLabel2.Size = new System.Drawing.Size(51, 13);
            this.LocalidadLabel2.TabIndex = 11;
            this.LocalidadLabel2.Text = "Provincia";
            // 
            // LocalidadPrincipalText2
            // 
            this.LocalidadPrincipalText2.Location = new System.Drawing.Point(0, 82);
            this.LocalidadPrincipalText2.Name = "LocalidadPrincipalText2";
            this.LocalidadPrincipalText2.Size = new System.Drawing.Size(240, 20);
            this.LocalidadPrincipalText2.TabIndex = 10;
            // 
            // LocalidadLabel1
            // 
            this.LocalidadLabel1.AutoSize = true;
            this.LocalidadLabel1.Location = new System.Drawing.Point(0, 17);
            this.LocalidadLabel1.Name = "LocalidadLabel1";
            this.LocalidadLabel1.Size = new System.Drawing.Size(44, 13);
            this.LocalidadLabel1.TabIndex = 9;
            this.LocalidadLabel1.Text = "Nombre";
            // 
            // LocalidadPrincipalText1
            // 
            this.LocalidadPrincipalText1.Location = new System.Drawing.Point(0, 33);
            this.LocalidadPrincipalText1.Name = "LocalidadPrincipalText1";
            this.LocalidadPrincipalText1.Size = new System.Drawing.Size(240, 20);
            this.LocalidadPrincipalText1.TabIndex = 7;
            // 
            // LocalidadBotton4
            // 
            this.LocalidadBotton4.Location = new System.Drawing.Point(232, 298);
            this.LocalidadBotton4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LocalidadBotton4.Name = "LocalidadBotton4";
            this.LocalidadBotton4.Size = new System.Drawing.Size(71, 27);
            this.LocalidadBotton4.TabIndex = 22;
            this.LocalidadBotton4.Text = "Baja";
            this.LocalidadBotton4.UseVisualStyleBackColor = true;
            // 
            // LocalidadBotton3
            // 
            this.LocalidadBotton3.Location = new System.Drawing.Point(157, 298);
            this.LocalidadBotton3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LocalidadBotton3.Name = "LocalidadBotton3";
            this.LocalidadBotton3.Size = new System.Drawing.Size(71, 27);
            this.LocalidadBotton3.TabIndex = 21;
            this.LocalidadBotton3.Text = "Modificar";
            this.LocalidadBotton3.UseVisualStyleBackColor = true;
            // 
            // LocalidadBotton2
            // 
            this.LocalidadBotton2.Location = new System.Drawing.Point(82, 298);
            this.LocalidadBotton2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LocalidadBotton2.Name = "LocalidadBotton2";
            this.LocalidadBotton2.Size = new System.Drawing.Size(71, 27);
            this.LocalidadBotton2.TabIndex = 20;
            this.LocalidadBotton2.Text = "Alta";
            this.LocalidadBotton2.UseVisualStyleBackColor = true;
            this.LocalidadBotton2.Click += new System.EventHandler(this.LocalidadBotton2_Click);
            // 
            // LocalidadBotton1
            // 
            this.LocalidadBotton1.Location = new System.Drawing.Point(7, 298);
            this.LocalidadBotton1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LocalidadBotton1.Name = "LocalidadBotton1";
            this.LocalidadBotton1.Size = new System.Drawing.Size(71, 27);
            this.LocalidadBotton1.TabIndex = 19;
            this.LocalidadBotton1.Text = "Ver";
            this.LocalidadBotton1.UseVisualStyleBackColor = true;
            // 
            // grillaLocalidad
            // 
            this.grillaLocalidad.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.grillaLocalidad.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grillaLocalidad.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grillaLocalidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaLocalidad.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaLocalidad.DefaultCellStyle = dataGridViewCellStyle9;
            this.grillaLocalidad.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.grillaLocalidad.Location = new System.Drawing.Point(7, 3);
            this.grillaLocalidad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grillaLocalidad.Name = "grillaLocalidad";
            this.grillaLocalidad.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grillaLocalidad.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grillaLocalidad.RowHeadersWidth = 51;
            this.grillaLocalidad.RowTemplate.Height = 24;
            this.grillaLocalidad.Size = new System.Drawing.Size(521, 289);
            this.grillaLocalidad.TabIndex = 18;
            // 
            // LocalidadLabel3
            // 
            this.LocalidadLabel3.AutoSize = true;
            this.LocalidadLabel3.Location = new System.Drawing.Point(0, 119);
            this.LocalidadLabel3.Name = "LocalidadLabel3";
            this.LocalidadLabel3.Size = new System.Drawing.Size(27, 13);
            this.LocalidadLabel3.TabIndex = 21;
            this.LocalidadLabel3.Text = "Pais";
            // 
            // LocalidadPrincipalText3
            // 
            this.LocalidadPrincipalText3.Location = new System.Drawing.Point(0, 135);
            this.LocalidadPrincipalText3.Name = "LocalidadPrincipalText3";
            this.LocalidadPrincipalText3.Size = new System.Drawing.Size(240, 20);
            this.LocalidadPrincipalText3.TabIndex = 20;
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
            this.tabPageLocalidades.ResumeLayout(false);
            this.LocalidadGroupBox.ResumeLayout(false);
            this.LocalidadGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaLocalidad)).EndInit();
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
        private System.Windows.Forms.GroupBox LocalidadGroupBox;
        private System.Windows.Forms.Button LocalidadBotton6;
        private System.Windows.Forms.Button LocalidadBotton5;
        private System.Windows.Forms.Label LocalidadLabel2;
        private System.Windows.Forms.TextBox LocalidadPrincipalText2;
        private System.Windows.Forms.Label LocalidadLabel1;
        private System.Windows.Forms.TextBox LocalidadPrincipalText1;
        private System.Windows.Forms.Button LocalidadBotton4;
        private System.Windows.Forms.Button LocalidadBotton3;
        private System.Windows.Forms.Button LocalidadBotton2;
        private System.Windows.Forms.Button LocalidadBotton1;
        private System.Windows.Forms.DataGridView grillaLocalidad;
        private System.Windows.Forms.Label LocalidadLabel3;
        private System.Windows.Forms.TextBox LocalidadPrincipalText3;
    }
}