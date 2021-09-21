namespace BuenViaje.Sesion
{
    partial class Idioma
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
            this.IdiomaLabel1 = new System.Windows.Forms.Label();
            this.IdiomaComboBox1 = new System.Windows.Forms.ComboBox();
            this.IdiomaBotton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IdiomaLabel1
            // 
            this.IdiomaLabel1.AutoSize = true;
            this.IdiomaLabel1.Location = new System.Drawing.Point(56, 23);
            this.IdiomaLabel1.Name = "IdiomaLabel1";
            this.IdiomaLabel1.Size = new System.Drawing.Size(67, 13);
            this.IdiomaLabel1.TabIndex = 0;
            this.IdiomaLabel1.Text = "Elegir Idioma";
            // 
            // IdiomaComboBox1
            // 
            this.IdiomaComboBox1.FormattingEnabled = true;
            this.IdiomaComboBox1.Location = new System.Drawing.Point(22, 38);
            this.IdiomaComboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.IdiomaComboBox1.Name = "IdiomaComboBox1";
            this.IdiomaComboBox1.Size = new System.Drawing.Size(149, 21);
            this.IdiomaComboBox1.TabIndex = 2;
            // 
            // IdiomaBotton1
            // 
            this.IdiomaBotton1.Location = new System.Drawing.Point(59, 63);
            this.IdiomaBotton1.Margin = new System.Windows.Forms.Padding(2);
            this.IdiomaBotton1.Name = "IdiomaBotton1";
            this.IdiomaBotton1.Size = new System.Drawing.Size(78, 21);
            this.IdiomaBotton1.TabIndex = 3;
            this.IdiomaBotton1.Text = "Aceptar";
            this.IdiomaBotton1.UseVisualStyleBackColor = true;
            this.IdiomaBotton1.Click += new System.EventHandler(this.IdiomaBotton1_Click);
            // 
            // Idioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(206, 109);
            this.Controls.Add(this.IdiomaBotton1);
            this.Controls.Add(this.IdiomaComboBox1);
            this.Controls.Add(this.IdiomaLabel1);
            this.Name = "Idioma";
            this.Text = "Idioma";
            this.Load += new System.EventHandler(this.Idioma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IdiomaLabel1;
        private System.Windows.Forms.ComboBox IdiomaComboBox1;
        private System.Windows.Forms.Button IdiomaBotton1;
    }
}