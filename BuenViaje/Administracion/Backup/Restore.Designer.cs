namespace BuenViaje.Administracion.Backup
{
    partial class Restore
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
            this.RestoreButton2 = new System.Windows.Forms.Button();
            this.RestoreGrilla1 = new System.Windows.Forms.DataGridView();
            this.RestoreButton1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RestoreGrilla1)).BeginInit();
            this.SuspendLayout();
            // 
            // RestoreButton2
            // 
            this.RestoreButton2.Location = new System.Drawing.Point(12, 246);
            this.RestoreButton2.Name = "RestoreButton2";
            this.RestoreButton2.Size = new System.Drawing.Size(86, 23);
            this.RestoreButton2.TabIndex = 9;
            this.RestoreButton2.Text = "Restaurar DB";
            this.RestoreButton2.UseVisualStyleBackColor = true;
            this.RestoreButton2.Click += new System.EventHandler(this.RestoreButton2_Click);
            // 
            // RestoreGrilla1
            // 
            this.RestoreGrilla1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RestoreGrilla1.Location = new System.Drawing.Point(12, 50);
            this.RestoreGrilla1.Name = "RestoreGrilla1";
            this.RestoreGrilla1.Size = new System.Drawing.Size(402, 190);
            this.RestoreGrilla1.TabIndex = 8;
            // 
            // RestoreButton1
            // 
            this.RestoreButton1.Location = new System.Drawing.Point(12, 21);
            this.RestoreButton1.Name = "RestoreButton1";
            this.RestoreButton1.Size = new System.Drawing.Size(75, 23);
            this.RestoreButton1.TabIndex = 7;
            this.RestoreButton1.Text = "Examinar";
            this.RestoreButton1.UseVisualStyleBackColor = true;
            this.RestoreButton1.Click += new System.EventHandler(this.RestoreButton1_Click);
            // 
            // Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 281);
            this.Controls.Add(this.RestoreButton2);
            this.Controls.Add(this.RestoreGrilla1);
            this.Controls.Add(this.RestoreButton1);
            this.Name = "Restore";
            this.Text = "Restore";
            this.Load += new System.EventHandler(this.Restore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RestoreGrilla1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RestoreButton2;
        private System.Windows.Forms.DataGridView RestoreGrilla1;
        private System.Windows.Forms.Button RestoreButton1;
    }
}