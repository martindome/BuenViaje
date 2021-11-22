namespace BuenViaje
{
    partial class CambiarConString
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
            this.CambiarConStringButton1 = new System.Windows.Forms.Button();
            this.CambiarConStringText1 = new System.Windows.Forms.TextBox();
            this.CambiarConStringLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CambiarConStringButton1
            // 
            this.CambiarConStringButton1.Location = new System.Drawing.Point(12, 49);
            this.CambiarConStringButton1.Name = "CambiarConStringButton1";
            this.CambiarConStringButton1.Size = new System.Drawing.Size(92, 23);
            this.CambiarConStringButton1.TabIndex = 5;
            this.CambiarConStringButton1.Text = "Cambiar String Conexion";
            this.CambiarConStringButton1.UseVisualStyleBackColor = true;
            this.CambiarConStringButton1.Click += new System.EventHandler(this.CambiarConStringButton1_Click);
            // 
            // CambiarConStringText1
            // 
            this.CambiarConStringText1.Location = new System.Drawing.Point(12, 23);
            this.CambiarConStringText1.Name = "CambiarConStringText1";
            this.CambiarConStringText1.Size = new System.Drawing.Size(503, 20);
            this.CambiarConStringText1.TabIndex = 4;
            this.CambiarConStringText1.TextChanged += new System.EventHandler(this.CambiarConStringText1_TextChanged);
            // 
            // CambiarConStringLabel1
            // 
            this.CambiarConStringLabel1.AutoSize = true;
            this.CambiarConStringLabel1.Location = new System.Drawing.Point(9, 7);
            this.CambiarConStringLabel1.Name = "CambiarConStringLabel1";
            this.CambiarConStringLabel1.Size = new System.Drawing.Size(81, 13);
            this.CambiarConStringLabel1.TabIndex = 3;
            this.CambiarConStringLabel1.Text = "String Conexion";
            // 
            // CambiarConString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(527, 86);
            this.Controls.Add(this.CambiarConStringButton1);
            this.Controls.Add(this.CambiarConStringText1);
            this.Controls.Add(this.CambiarConStringLabel1);
            this.Name = "CambiarConString";
            this.Text = "CambiarConString";
            this.Load += new System.EventHandler(this.CambiarConString_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CambiarConStringButton1;
        private System.Windows.Forms.TextBox CambiarConStringText1;
        private System.Windows.Forms.Label CambiarConStringLabel1;
    }
}