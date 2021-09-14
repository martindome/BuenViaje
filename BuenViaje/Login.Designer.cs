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
            this.LoginLabel1.Click += new System.EventHandler(this.label1_Click);
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
            this.LoginButton1.Location = new System.Drawing.Point(12, 86);
            this.LoginButton1.Name = "LoginButton1";
            this.LoginButton1.Size = new System.Drawing.Size(75, 23);
            this.LoginButton1.TabIndex = 2;
            this.LoginButton1.Text = "Login";
            this.LoginButton1.UseVisualStyleBackColor = true;
            this.LoginButton1.Click += new System.EventHandler(this.LoginButton1_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(11, 24);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(185, 20);
            this.txtUser.TabIndex = 3;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(11, 61);
            this.txtPass.Margin = new System.Windows.Forms.Padding(2);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(185, 20);
            this.txtPass.TabIndex = 4;
            // 
            // LoginBotton2
            // 
            this.LoginBotton2.Location = new System.Drawing.Point(121, 85);
            this.LoginBotton2.Margin = new System.Windows.Forms.Padding(2);
            this.LoginBotton2.Name = "LoginBotton2";
            this.LoginBotton2.Size = new System.Drawing.Size(75, 24);
            this.LoginBotton2.TabIndex = 6;
            this.LoginBotton2.Text = "Exit";
            this.LoginBotton2.UseVisualStyleBackColor = true;
            this.LoginBotton2.Click += new System.EventHandler(this.LoginBotton2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 136);
            this.Controls.Add(this.LoginBotton2);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.LoginButton1);
            this.Controls.Add(this.LoginLabel2);
            this.Controls.Add(this.LoginLabel1);
            this.Name = "Login";
            this.Text = "Login";
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
    }
}

