namespace BuenViaje
{
    partial class CambiarPassword
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
            this.CambiarPasswordLabel1 = new System.Windows.Forms.Label();
            this.CambiarPasswordText1 = new System.Windows.Forms.TextBox();
            this.CambiarPasswordButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CambiarPasswordLabel1
            // 
            this.CambiarPasswordLabel1.AutoSize = true;
            this.CambiarPasswordLabel1.Location = new System.Drawing.Point(12, 9);
            this.CambiarPasswordLabel1.Name = "CambiarPasswordLabel1";
            this.CambiarPasswordLabel1.Size = new System.Drawing.Size(83, 13);
            this.CambiarPasswordLabel1.TabIndex = 0;
            this.CambiarPasswordLabel1.Text = "Nombre Usuario";
            // 
            // CambiarPasswordText1
            // 
            this.CambiarPasswordText1.Location = new System.Drawing.Point(15, 25);
            this.CambiarPasswordText1.Name = "CambiarPasswordText1";
            this.CambiarPasswordText1.Size = new System.Drawing.Size(191, 20);
            this.CambiarPasswordText1.TabIndex = 1;
            // 
            // CambiarPasswordButton1
            // 
            this.CambiarPasswordButton1.Location = new System.Drawing.Point(15, 51);
            this.CambiarPasswordButton1.Name = "CambiarPasswordButton1";
            this.CambiarPasswordButton1.Size = new System.Drawing.Size(117, 23);
            this.CambiarPasswordButton1.TabIndex = 2;
            this.CambiarPasswordButton1.Text = "Resetear Clave";
            this.CambiarPasswordButton1.UseVisualStyleBackColor = true;
            this.CambiarPasswordButton1.Click += new System.EventHandler(this.CambiarPasswordButton1_Click);
            // 
            // CambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 88);
            this.Controls.Add(this.CambiarPasswordButton1);
            this.Controls.Add(this.CambiarPasswordText1);
            this.Controls.Add(this.CambiarPasswordLabel1);
            this.Name = "CambiarPassword";
            this.Text = "CambiarPassword";
            this.Load += new System.EventHandler(this.CambiarPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CambiarPasswordLabel1;
        private System.Windows.Forms.TextBox CambiarPasswordText1;
        private System.Windows.Forms.Button CambiarPasswordButton1;
    }
}