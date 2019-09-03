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
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.cboCiudad = new System.Windows.Forms.ComboBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.cboBarrio = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barrio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalida)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.BackColor = System.Drawing.SystemColors.Control;
            this.gbFiltros.Controls.Add(this.cboBarrio);
            this.gbFiltros.Controls.Add(this.cboTipo);
            this.gbFiltros.Controls.Add(this.cboEstado);
            this.gbFiltros.Controls.Add(this.cboCiudad);
            this.gbFiltros.Controls.Add(this.dtpFechaHasta);
            this.gbFiltros.Controls.Add(this.dtpFechaDesde);
            this.gbFiltros.Controls.Add(this.lblBarrio);
            this.gbFiltros.Controls.Add(this.lblTipo);
            this.gbFiltros.Controls.Add(this.lblEstado);
            this.gbFiltros.Controls.Add(this.lblCiudad);
            this.gbFiltros.Controls.Add(this.lblFechaHasta);
            this.gbFiltros.Controls.Add(this.lblFechaDesde);
            this.gbFiltros.Location = new System.Drawing.Point(15, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(528, 142);
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
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
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
            this.dgvSalida.AllowUserToAddRows = false;
            this.dgvSalida.AllowUserToDeleteRows = false;
            this.dgvSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCliente,
            this.NomLocal,
            this.NomCliente,
            this.Ciudad,
            this.Barrio,
            this.Estado,
            this.TipoCliente,
            this.FechaRegistro});
            this.dgvSalida.Location = new System.Drawing.Point(15, 160);
            this.dgvSalida.Name = "dgvSalida";
            this.dgvSalida.ReadOnly = true;
            this.dgvSalida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalida.Size = new System.Drawing.Size(865, 223);
            this.dgvSalida.TabIndex = 3;
            this.dgvSalida.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalida_CellContentClick);
            // 
            // lblBuscarPorID
            // 
            this.lblBuscarPorID.AutoSize = true;
            this.lblBuscarPorID.Location = new System.Drawing.Point(592, 44);
            this.lblBuscarPorID.Name = "lblBuscarPorID";
            this.lblBuscarPorID.Size = new System.Drawing.Size(67, 13);
            this.lblBuscarPorID.TabIndex = 4;
            this.lblBuscarPorID.Text = "Bucar por ID";
            // 
            // cboBuscarPorID
            // 
            this.cboBuscarPorID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscarPorID.FormattingEnabled = true;
            this.cboBuscarPorID.Location = new System.Drawing.Point(706, 36);
            this.cboBuscarPorID.Name = "cboBuscarPorID";
            this.cboBuscarPorID.Size = new System.Drawing.Size(121, 21);
            this.cboBuscarPorID.TabIndex = 5;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Location = new System.Drawing.Point(6, 32);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(72, 13);
            this.lblFechaDesde.TabIndex = 0;
            this.lblFechaDesde.Text = "Fecha desde:";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Location = new System.Drawing.Point(204, 32);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(69, 13);
            this.lblFechaHasta.TabIndex = 1;
            this.lblFechaHasta.Text = "Fecha hasta:";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(6, 65);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(40, 13);
            this.lblCiudad.TabIndex = 2;
            this.lblCiudad.Text = "Ciudad";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(188, 65);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(366, 65);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 4;
            this.lblTipo.Text = "Tipo";
            // 
            // lblBarrio
            // 
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(7, 101);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(34, 13);
            this.lblBarrio.TabIndex = 5;
            this.lblBarrio.Text = "Barrio";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(85, 24);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(107, 20);
            this.dtpFechaDesde.TabIndex = 6;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(280, 24);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(115, 20);
            this.dtpFechaHasta.TabIndex = 7;
            // 
            // cboCiudad
            // 
            this.cboCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudad.FormattingEnabled = true;
            this.cboCiudad.Location = new System.Drawing.Point(52, 62);
            this.cboCiudad.Name = "cboCiudad";
            this.cboCiudad.Size = new System.Drawing.Size(121, 21);
            this.cboCiudad.TabIndex = 8;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(234, 61);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(111, 21);
            this.cboEstado.TabIndex = 9;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(400, 61);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(106, 21);
            this.cboTipo.TabIndex = 10;
            // 
            // cboBarrio
            // 
            this.cboBarrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBarrio.FormattingEnabled = true;
            this.cboBarrio.Location = new System.Drawing.Point(52, 93);
            this.cboBarrio.Name = "cboBarrio";
            this.cboBarrio.Size = new System.Drawing.Size(121, 21);
            this.cboBarrio.TabIndex = 11;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(18, 398);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // idCliente
            // 
            this.idCliente.HeaderText = "Id";
            this.idCliente.Name = "idCliente";
            this.idCliente.ReadOnly = true;
            this.idCliente.Width = 30;
            // 
            // NomLocal
            // 
            this.NomLocal.HeaderText = "Nombre Local";
            this.NomLocal.Name = "NomLocal";
            this.NomLocal.ReadOnly = true;
            // 
            // NomCliente
            // 
            this.NomCliente.HeaderText = "Nombre Cliente";
            this.NomCliente.Name = "NomCliente";
            this.NomCliente.ReadOnly = true;
            // 
            // Ciudad
            // 
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.ReadOnly = true;
            // 
            // Barrio
            // 
            this.Barrio.HeaderText = "Barrio";
            this.Barrio.Name = "Barrio";
            this.Barrio.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // TipoCliente
            // 
            this.TipoCliente.HeaderText = "Tipo";
            this.TipoCliente.Name = "TipoCliente";
            this.TipoCliente.ReadOnly = true;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.HeaderText = "Fecha Registro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            // 
            // frmBuscarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(891, 434);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cboBuscarPorID);
            this.Controls.Add(this.lblBuscarPorID);
            this.Controls.Add(this.dgvSalida);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.gbFiltros);
            this.Name = "frmBuscarClientes";
            this.Text = "Buscar Clientes";
            this.Load += new System.EventHandler(this.frmBuscarClientes_Load);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
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
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.ComboBox cboBarrio;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.ComboBox cboCiudad;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barrio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
    }
}