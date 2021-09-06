namespace BuenViaje
{
    partial class Inicio
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
            this.components = new System.ComponentModel.Container();
            this.InicioProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.InicioLabel1 = new System.Windows.Forms.Label();
            this.InicioTimer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // InicioProgressBar1
            // 
            this.InicioProgressBar1.Location = new System.Drawing.Point(12, 48);
            this.InicioProgressBar1.Name = "InicioProgressBar1";
            this.InicioProgressBar1.Size = new System.Drawing.Size(308, 23);
            this.InicioProgressBar1.TabIndex = 0;
            this.InicioProgressBar1.Tag = "InicioProgressBar1";
            this.InicioProgressBar1.Click += new System.EventHandler(this.InicioProgressBar1_Click);
            // 
            // InicioLabel1
            // 
            this.InicioLabel1.AutoSize = true;
            this.InicioLabel1.Location = new System.Drawing.Point(12, 32);
            this.InicioLabel1.Name = "InicioLabel1";
            this.InicioLabel1.Size = new System.Drawing.Size(43, 13);
            this.InicioLabel1.TabIndex = 1;
            this.InicioLabel1.Tag = "InicioLabel1";
            this.InicioLabel1.Text = "Starting";
            // 
            // InicioTimer1
            // 
            this.InicioTimer1.Tag = "InicioTimer1";
            this.InicioTimer1.Tick += new System.EventHandler(this.InicioTimer1_Tick);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 141);
            this.Controls.Add(this.InicioLabel1);
            this.Controls.Add(this.InicioProgressBar1);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar InicioProgressBar1;
        private System.Windows.Forms.Label InicioLabel1;
        private System.Windows.Forms.Timer InicioTimer1;
    }
}