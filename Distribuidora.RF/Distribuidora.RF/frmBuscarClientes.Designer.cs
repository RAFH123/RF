namespace Distribuidora.RF
{
    partial class frmBuscarClientes
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
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvSalida = new System.Windows.Forms.DataGridView();
            this.lblBuscarPorID = new System.Windows.Forms.Label();
            this.cboBuscarPorID = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalida)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.BackColor = System.Drawing.SystemColors.Control;
            this.gbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(528, 178);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Aplicar Filtros";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(384, 398);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 1;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(465, 398);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;            
            // 
            // dgvSalida
            // 
            this.dgvSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalida.Location = new System.Drawing.Point(13, 245);
            this.dgvSalida.Name = "dgvSalida";
            this.dgvSalida.Size = new System.Drawing.Size(527, 147);
            this.dgvSalida.TabIndex = 3;
            // 
            // lblBuscarPorID
            // 
            this.lblBuscarPorID.AutoSize = true;
            this.lblBuscarPorID.Location = new System.Drawing.Point(12, 213);
            this.lblBuscarPorID.Name = "lblBuscarPorID";
            this.lblBuscarPorID.Size = new System.Drawing.Size(67, 13);
            this.lblBuscarPorID.TabIndex = 4;
            this.lblBuscarPorID.Text = "Bucar por ID";
            // 
            // cboBuscarPorID
            // 
            this.cboBuscarPorID.FormattingEnabled = true;
            this.cboBuscarPorID.Location = new System.Drawing.Point(86, 210);
            this.cboBuscarPorID.Name = "cboBuscarPorID";
            this.cboBuscarPorID.Size = new System.Drawing.Size(121, 21);
            this.cboBuscarPorID.TabIndex = 5;
            // 
            // frmBuscarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(552, 439);
            this.Controls.Add(this.cboBuscarPorID);
            this.Controls.Add(this.lblBuscarPorID);
            this.Controls.Add(this.dgvSalida);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.gbFiltros);
            this.Name = "frmBuscarClientes";
            this.Text = "Buscar Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvSalida;
        private System.Windows.Forms.Label lblBuscarPorID;
        private System.Windows.Forms.ComboBox cboBuscarPorID;
    }
}