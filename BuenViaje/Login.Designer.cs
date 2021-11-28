namespace BuenViaje
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginLabel1 = new System.Windows.Forms.Label();
            this.LoginLabel2 = new System.Windows.Forms.Label();
            this.LoginButton1 = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.LoginBotton2 = new System.Windows.Forms.Button();
            this.LoginButton3 = new System.Windows.Forms.Button();
            this.LoginComboBox1 = new System.Windows.Forms.ComboBox();
            this.loginLabel3 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.LoginButton4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginLabel1
            // 
            this.LoginLabel1.AutoSize = true;
            this.LoginLabel1.Location = new System.Drawing.Point(9, 9);
            this.LoginLabel1.Name = "LoginLabel1";
            this.LoginLabel1.Size = new System.Drawing.Size(43, 13);
            this.LoginLabel1.TabIndex = 0;
            this.LoginLabel1.Tag = "LoginLabel1";
            this.LoginLabel1.Text = "Usuario";
            // 
            // LoginLabel2
            // 
            this.LoginLabel2.AutoSize = true;
            this.LoginLabel2.Location = new System.Drawing.Point(9, 46);
            this.LoginLabel2.Name = "LoginLabel2";
            this.LoginLabel2.Size = new System.Drawing.Size(34, 13);
            this.LoginLabel2.TabIndex = 1;
            this.LoginLabel2.Tag = "LoginLabel2";
            this.LoginLabel2.Text = "Clave";
            // 
            // LoginButton1
            // 
            this.LoginButton1.Location = new System.Drawing.Point(11, 86);
            this.LoginButton1.Name = "LoginButton1";
            this.LoginButton1.Size = new System.Drawing.Size(118, 23);
            this.LoginButton1.TabIndex = 2;
            this.LoginButton1.Text = "Login";
            this.LoginButton1.UseVisualStyleBackColor = true;
            this.LoginButton1.Click += new System.EventHandler(this.LoginButton1_Click);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.Info;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Location = new System.Drawing.Point(11, 24);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(237, 20);
            this.txtUser.TabIndex = 3;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.SystemColors.Info;
            this.txtPass.Location = new System.Drawing.Point(11, 61);
            this.txtPass.Margin = new System.Windows.Forms.Padding(2);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(237, 20);
            this.txtPass.TabIndex = 4;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // LoginBotton2
            // 
            this.LoginBotton2.Location = new System.Drawing.Point(135, 86);
            this.LoginBotton2.Margin = new System.Windows.Forms.Padding(2);
            this.LoginBotton2.Name = "LoginBotton2";
            this.LoginBotton2.Size = new System.Drawing.Size(113, 24);
            this.LoginBotton2.TabIndex = 6;
            this.LoginBotton2.Text = "Exit";
            this.LoginBotton2.UseVisualStyleBackColor = true;
            this.LoginBotton2.Click += new System.EventHandler(this.LoginBotton2_Click);
            // 
            // LoginButton3
            // 
            this.LoginButton3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LoginButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LoginButton3.Location = new System.Drawing.Point(282, 86);
            this.LoginButton3.Name = "LoginButton3";
            this.LoginButton3.Size = new System.Drawing.Size(169, 23);
            this.LoginButton3.TabIndex = 7;
            this.LoginButton3.Text = "Resetear Clave";
            this.LoginButton3.UseVisualStyleBackColor = false;
            this.LoginButton3.Click += new System.EventHandler(this.LoginButton3_Click);
            // 
            // LoginComboBox1
            // 
            this.LoginComboBox1.BackColor = System.Drawing.SystemColors.Info;
            this.LoginComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoginComboBox1.FormattingEnabled = true;
            this.LoginComboBox1.Location = new System.Drawing.Point(304, 25);
            this.LoginComboBox1.Name = "LoginComboBox1";
            this.LoginComboBox1.Size = new System.Drawing.Size(147, 21);
            this.LoginComboBox1.TabIndex = 8;
            this.LoginComboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // loginLabel3
            // 
            this.loginLabel3.AutoSize = true;
            this.loginLabel3.Location = new System.Drawing.Point(301, 9);
            this.loginLabel3.Name = "loginLabel3";
            this.loginLabel3.Size = new System.Drawing.Size(38, 13);
            this.loginLabel3.TabIndex = 9;
            this.loginLabel3.Tag = "LoginLabel2";
            this.loginLabel3.Text = "Idioma";
            // 
            // LoginButton4
            // 
            this.LoginButton4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LoginButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LoginButton4.Location = new System.Drawing.Point(282, 61);
            this.LoginButton4.Name = "LoginButton4";
            this.LoginButton4.Size = new System.Drawing.Size(169, 23);
            this.LoginButton4.TabIndex = 10;
            this.LoginButton4.Text = "Cambiar String Conexion";
            this.LoginButton4.UseVisualStyleBackColor = false;
            this.LoginButton4.Click += new System.EventHandler(this.LoginButton4_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(457, 129);
            this.Controls.Add(this.LoginButton4);
            this.Controls.Add(this.loginLabel3);
            this.Controls.Add(this.LoginComboBox1);
            this.Controls.Add(this.LoginButton3);
            this.Controls.Add(this.LoginBotton2);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.LoginButton1);
            this.Controls.Add(this.LoginLabel2);
            this.Controls.Add(this.LoginLabel1);
            this.HelpButton = true;
            this.Name = "Login";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginLabel1;
        private System.Windows.Forms.Label LoginLabel2;
        private System.Windows.Forms.Button LoginButton1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button LoginBotton2;
        private System.Windows.Forms.Button LoginButton3;
        private System.Windows.Forms.ComboBox LoginComboBox1;
        private System.Windows.Forms.Label loginLabel3;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button LoginButton4;
    }
}

