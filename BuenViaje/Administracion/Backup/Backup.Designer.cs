namespace BuenViaje.Administracion.Backup
{
    partial class Backup
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
            this.BackupComboBox1 = new System.Windows.Forms.ComboBox();
            this.BackupButton1 = new System.Windows.Forms.Button();
            this.BackupLabel2 = new System.Windows.Forms.Label();
            this.BackupButton2 = new System.Windows.Forms.Button();
            this.BackupText1 = new System.Windows.Forms.TextBox();
            this.BackupLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackupComboBox1
            // 
            this.BackupComboBox1.FormattingEnabled = true;
            this.BackupComboBox1.Location = new System.Drawing.Point(14, 69);
            this.BackupComboBox1.Name = "BackupComboBox1";
            this.BackupComboBox1.Size = new System.Drawing.Size(64, 21);
            this.BackupComboBox1.TabIndex = 13;
            this.BackupComboBox1.SelectedIndexChanged += new System.EventHandler(this.BackupComboBox1_SelectedIndexChanged);
            // 
            // BackupButton1
            // 
            this.BackupButton1.Location = new System.Drawing.Point(342, 21);
            this.BackupButton1.Margin = new System.Windows.Forms.Padding(2);
            this.BackupButton1.Name = "BackupButton1";
            this.BackupButton1.Size = new System.Drawing.Size(120, 25);
            this.BackupButton1.TabIndex = 12;
            this.BackupButton1.Text = "Buscar";
            this.BackupButton1.UseVisualStyleBackColor = true;
            this.BackupButton1.Click += new System.EventHandler(this.BackupButton1_Click);
            // 
            // BackupLabel2
            // 
            this.BackupLabel2.AutoSize = true;
            this.BackupLabel2.Location = new System.Drawing.Point(8, 53);
            this.BackupLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BackupLabel2.Name = "BackupLabel2";
            this.BackupLabel2.Size = new System.Drawing.Size(121, 13);
            this.BackupLabel2.TabIndex = 11;
            this.BackupLabel2.Text = "Dividir archivo en partes";
            // 
            // BackupButton2
            // 
            this.BackupButton2.Location = new System.Drawing.Point(11, 95);
            this.BackupButton2.Margin = new System.Windows.Forms.Padding(2);
            this.BackupButton2.Name = "BackupButton2";
            this.BackupButton2.Size = new System.Drawing.Size(120, 28);
            this.BackupButton2.TabIndex = 10;
            this.BackupButton2.Text = "Ejecutar";
            this.BackupButton2.UseVisualStyleBackColor = true;
            this.BackupButton2.Click += new System.EventHandler(this.BackupButton2_Click);
            // 
            // BackupText1
            // 
            this.BackupText1.Location = new System.Drawing.Point(14, 24);
            this.BackupText1.Margin = new System.Windows.Forms.Padding(2);
            this.BackupText1.Name = "BackupText1";
            this.BackupText1.Size = new System.Drawing.Size(324, 20);
            this.BackupText1.TabIndex = 9;
            this.BackupText1.TextChanged += new System.EventHandler(this.BackupText1_TextChanged);
            // 
            // BackupLabel1
            // 
            this.BackupLabel1.AutoSize = true;
            this.BackupLabel1.Location = new System.Drawing.Point(11, 9);
            this.BackupLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BackupLabel1.Name = "BackupLabel1";
            this.BackupLabel1.Size = new System.Drawing.Size(43, 13);
            this.BackupLabel1.TabIndex = 8;
            this.BackupLabel1.Text = "Destino";
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(478, 134);
            this.Controls.Add(this.BackupComboBox1);
            this.Controls.Add(this.BackupButton1);
            this.Controls.Add(this.BackupLabel2);
            this.Controls.Add(this.BackupButton2);
            this.Controls.Add(this.BackupText1);
            this.Controls.Add(this.BackupLabel1);
            this.Name = "Backup";
            this.Text = "Backup";
            this.Load += new System.EventHandler(this.Backup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BackupComboBox1;
        private System.Windows.Forms.Button BackupButton1;
        private System.Windows.Forms.Label BackupLabel2;
        private System.Windows.Forms.Button BackupButton2;
        private System.Windows.Forms.TextBox BackupText1;
        private System.Windows.Forms.Label BackupLabel1;
    }
}