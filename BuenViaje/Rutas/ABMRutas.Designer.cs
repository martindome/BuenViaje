namespace BuenViaje.Rutas
{
    partial class ABMRutas
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
            this.ABMRutasButton2 = new System.Windows.Forms.Button();
            this.ABMRutasButton1 = new System.Windows.Forms.Button();
            this.RutasLabel1 = new System.Windows.Forms.Label();
            this.RutasText2 = new System.Windows.Forms.TextBox();
            this.RutasLabel3 = new System.Windows.Forms.Label();
            this.RutasLabel2 = new System.Windows.Forms.Label();
            this.rutasCombo1 = new System.Windows.Forms.ComboBox();
            this.rutasCombo2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ABMRutasButton2
            // 
            this.ABMRutasButton2.Location = new System.Drawing.Point(157, 136);
            this.ABMRutasButton2.Margin = new System.Windows.Forms.Padding(2);
            this.ABMRutasButton2.Name = "ABMRutasButton2";
            this.ABMRutasButton2.Size = new System.Drawing.Size(66, 21);
            this.ABMRutasButton2.TabIndex = 40;
            this.ABMRutasButton2.Text = "Cancelar";
            this.ABMRutasButton2.UseVisualStyleBackColor = true;
            this.ABMRutasButton2.Click += new System.EventHandler(this.RutasButton2_Click);
            // 
            // ABMRutasButton1
            // 
            this.ABMRutasButton1.Location = new System.Drawing.Point(11, 136);
            this.ABMRutasButton1.Margin = new System.Windows.Forms.Padding(2);
            this.ABMRutasButton1.Name = "ABMRutasButton1";
            this.ABMRutasButton1.Size = new System.Drawing.Size(66, 21);
            this.ABMRutasButton1.TabIndex = 41;
            this.ABMRutasButton1.Text = "Aplicar";
            this.ABMRutasButton1.UseVisualStyleBackColor = true;
            this.ABMRutasButton1.Click += new System.EventHandler(this.RutasButton1_Click);
            // 
            // RutasLabel1
            // 
            this.RutasLabel1.AutoSize = true;
            this.RutasLabel1.Location = new System.Drawing.Point(11, 9);
            this.RutasLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RutasLabel1.Name = "RutasLabel1";
            this.RutasLabel1.Size = new System.Drawing.Size(38, 13);
            this.RutasLabel1.TabIndex = 39;
            this.RutasLabel1.Text = "Origen";
            // 
            // RutasText2
            // 
            this.RutasText2.Location = new System.Drawing.Point(10, 105);
            this.RutasText2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RutasText2.Name = "RutasText2";
            this.RutasText2.Size = new System.Drawing.Size(212, 20);
            this.RutasText2.TabIndex = 38;
            // 
            // RutasLabel3
            // 
            this.RutasLabel3.AutoSize = true;
            this.RutasLabel3.Location = new System.Drawing.Point(8, 89);
            this.RutasLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RutasLabel3.Name = "RutasLabel3";
            this.RutasLabel3.Size = new System.Drawing.Size(50, 13);
            this.RutasLabel3.TabIndex = 37;
            this.RutasLabel3.Text = "Duracion";
            // 
            // RutasLabel2
            // 
            this.RutasLabel2.AutoSize = true;
            this.RutasLabel2.Location = new System.Drawing.Point(8, 49);
            this.RutasLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RutasLabel2.Name = "RutasLabel2";
            this.RutasLabel2.Size = new System.Drawing.Size(43, 13);
            this.RutasLabel2.TabIndex = 34;
            this.RutasLabel2.Text = "Destino";
            // 
            // rutasCombo1
            // 
            this.rutasCombo1.FormattingEnabled = true;
            this.rutasCombo1.Location = new System.Drawing.Point(10, 25);
            this.rutasCombo1.Name = "rutasCombo1";
            this.rutasCombo1.Size = new System.Drawing.Size(212, 21);
            this.rutasCombo1.TabIndex = 42;
            // 
            // rutasCombo2
            // 
            this.rutasCombo2.FormattingEnabled = true;
            this.rutasCombo2.Location = new System.Drawing.Point(10, 65);
            this.rutasCombo2.Name = "rutasCombo2";
            this.rutasCombo2.Size = new System.Drawing.Size(212, 21);
            this.rutasCombo2.TabIndex = 43;
            // 
            // ABMRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 170);
            this.Controls.Add(this.rutasCombo2);
            this.Controls.Add(this.rutasCombo1);
            this.Controls.Add(this.ABMRutasButton2);
            this.Controls.Add(this.ABMRutasButton1);
            this.Controls.Add(this.RutasLabel1);
            this.Controls.Add(this.RutasText2);
            this.Controls.Add(this.RutasLabel3);
            this.Controls.Add(this.RutasLabel2);
            this.Name = "ABMRutas";
            this.Text = "ABMRutas";
            this.Load += new System.EventHandler(this.ABMRutas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ABMRutasButton2;
        private System.Windows.Forms.Button ABMRutasButton1;
        private System.Windows.Forms.Label RutasLabel1;
        private System.Windows.Forms.TextBox RutasText2;
        private System.Windows.Forms.Label RutasLabel3;
        private System.Windows.Forms.Label RutasLabel2;
        private System.Windows.Forms.ComboBox rutasCombo1;
        private System.Windows.Forms.ComboBox rutasCombo2;
    }
}