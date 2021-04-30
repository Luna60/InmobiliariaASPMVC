namespace InmobiliariaASPMVC.Windows
{
    partial class FrmDetalleCompra
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cmnPropiedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDatos);
            this.panel1.Location = new System.Drawing.Point(2, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 255);
            this.panel1.TabIndex = 0;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnPropiedad,
            this.cmnPrecioUnitario,
            this.cmnTotal});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(598, 255);
            this.dgvDatos.TabIndex = 0;
            // 
            // cmnPropiedad
            // 
            this.cmnPropiedad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnPropiedad.HeaderText = "Propiedad";
            this.cmnPropiedad.Name = "cmnPropiedad";
            // 
            // cmnPrecioUnitario
            // 
            this.cmnPrecioUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnPrecioUnitario.HeaderText = "Precio Unitario";
            this.cmnPrecioUnitario.Name = "cmnPrecioUnitario";
            // 
            // cmnTotal
            // 
            this.cmnTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnTotal.HeaderText = "Total";
            this.cmnTotal.Name = "cmnTotal";
            // 
            // FrmDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDetalleCompra";
            this.Text = "FrmDetalleCompra";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPropiedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTotal;
    }
}