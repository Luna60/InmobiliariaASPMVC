﻿namespace InmobiliariaASPMVC.Windows
{
    partial class FrmMenuPrincipal
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
            this.btnProvincias = new System.Windows.Forms.Button();
            this.btnLocalidades = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProvincias
            // 
            this.btnProvincias.Location = new System.Drawing.Point(105, 46);
            this.btnProvincias.MaximumSize = new System.Drawing.Size(93, 38);
            this.btnProvincias.MinimumSize = new System.Drawing.Size(93, 38);
            this.btnProvincias.Name = "btnProvincias";
            this.btnProvincias.Size = new System.Drawing.Size(93, 38);
            this.btnProvincias.TabIndex = 0;
            this.btnProvincias.Text = "Provincias";
            this.btnProvincias.UseVisualStyleBackColor = true;
            this.btnProvincias.Click += new System.EventHandler(this.btnProvincias_Click);
            // 
            // btnLocalidades
            // 
            this.btnLocalidades.Location = new System.Drawing.Point(105, 126);
            this.btnLocalidades.MaximumSize = new System.Drawing.Size(93, 38);
            this.btnLocalidades.MinimumSize = new System.Drawing.Size(93, 38);
            this.btnLocalidades.Name = "btnLocalidades";
            this.btnLocalidades.Size = new System.Drawing.Size(93, 38);
            this.btnLocalidades.TabIndex = 1;
            this.btnLocalidades.Text = "Localidades";
            this.btnLocalidades.UseVisualStyleBackColor = true;
            this.btnLocalidades.Click += new System.EventHandler(this.btnLocalidades_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 295);
            this.Controls.Add(this.btnLocalidades);
            this.Controls.Add(this.btnProvincias);
            this.MaximumSize = new System.Drawing.Size(313, 334);
            this.MinimumSize = new System.Drawing.Size(313, 334);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal:";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProvincias;
        private System.Windows.Forms.Button btnLocalidades;
    }
}

