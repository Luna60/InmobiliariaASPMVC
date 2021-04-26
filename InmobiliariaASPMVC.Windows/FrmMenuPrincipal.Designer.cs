namespace InmobiliariaASPMVC.Windows
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
            this.btnTipoDoc = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProvincias
            // 
            this.btnProvincias.Location = new System.Drawing.Point(12, 31);
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
            this.btnLocalidades.Location = new System.Drawing.Point(175, 31);
            this.btnLocalidades.MaximumSize = new System.Drawing.Size(93, 38);
            this.btnLocalidades.MinimumSize = new System.Drawing.Size(93, 38);
            this.btnLocalidades.Name = "btnLocalidades";
            this.btnLocalidades.Size = new System.Drawing.Size(93, 38);
            this.btnLocalidades.TabIndex = 1;
            this.btnLocalidades.Text = "Localidades";
            this.btnLocalidades.UseVisualStyleBackColor = true;
            this.btnLocalidades.Click += new System.EventHandler(this.btnLocalidades_Click);
            // 
            // btnTipoDoc
            // 
            this.btnTipoDoc.Location = new System.Drawing.Point(12, 109);
            this.btnTipoDoc.MaximumSize = new System.Drawing.Size(93, 38);
            this.btnTipoDoc.MinimumSize = new System.Drawing.Size(93, 38);
            this.btnTipoDoc.Name = "btnTipoDoc";
            this.btnTipoDoc.Size = new System.Drawing.Size(93, 38);
            this.btnTipoDoc.TabIndex = 2;
            this.btnTipoDoc.Text = "Tipos de Documentos";
            this.btnTipoDoc.UseVisualStyleBackColor = true;
            this.btnTipoDoc.Click += new System.EventHandler(this.btnTipoDoc_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 109);
            this.button1.MaximumSize = new System.Drawing.Size(93, 38);
            this.button1.MinimumSize = new System.Drawing.Size(93, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Clientes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 199);
            this.button2.MaximumSize = new System.Drawing.Size(93, 38);
            this.button2.MinimumSize = new System.Drawing.Size(93, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "Propiedades";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 295);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTipoDoc);
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
        private System.Windows.Forms.Button btnTipoDoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

