namespace Distribuidora.RF.GUILayer
{
    partial class frmABMProveedores
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblNomLocal = new System.Windows.Forms.Label();
            this.lblNomProveedor = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNomLocal = new System.Windows.Forms.TextBox();
            this.txtNomProveedor = new System.Windows.Forms.TextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.cboCiudad = new System.Windows.Forms.ComboBox();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.cboBarrio = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barrio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFechaRegistro = new System.Windows.Forms.Label();
            this.txtFechaRegistro = new System.Windows.Forms.MaskedTextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.MaskedTextBox();
            this.txtCUIT = new System.Windows.Forms.MaskedTextBox();
            this.lblCUIT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(86, 23);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id";
            // 
            // lblNomLocal
            // 
            this.lblNomLocal.AutoSize = true;
            this.lblNomLocal.Location = new System.Drawing.Point(29, 61);
            this.lblNomLocal.Name = "lblNomLocal";
            this.lblNomLocal.Size = new System.Drawing.Size(73, 13);
            this.lblNomLocal.TabIndex = 1;
            this.lblNomLocal.Text = "Nombre Local";
            // 
            // lblNomProveedor
            // 
            this.lblNomProveedor.AutoSize = true;
            this.lblNomProveedor.Location = new System.Drawing.Point(12, 88);
            this.lblNomProveedor.Name = "lblNomProveedor";
            this.lblNomProveedor.Size = new System.Drawing.Size(106, 13);
            this.lblNomProveedor.TabIndex = 2;
            this.lblNomProveedor.Text = "Nombre Proveedor(*)";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(74, 126);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(299, 27);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(299, 59);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(40, 13);
            this.lblCalle.TabIndex = 5;
            this.lblCalle.Text = "Calle(*)";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(508, 58);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(34, 13);
            this.lblNumero.TabIndex = 6;
            this.lblNumero.Text = "Nro(*)";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(299, 93);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(40, 13);
            this.lblCiudad.TabIndex = 7;
            this.lblCiudad.Text = "Ciudad";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(626, 58);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(626, 88);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(123, 20);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(65, 20);
            this.txtId.TabIndex = 0;
            // 
            // txtNomLocal
            // 
            this.txtNomLocal.Location = new System.Drawing.Point(123, 53);
            this.txtNomLocal.Name = "txtNomLocal";
            this.txtNomLocal.Size = new System.Drawing.Size(148, 20);
            this.txtNomLocal.TabIndex = 1;
            // 
            // txtNomProveedor
            // 
            this.txtNomProveedor.Location = new System.Drawing.Point(123, 84);
            this.txtNomProveedor.Name = "txtNomProveedor";
            this.txtNomProveedor.Size = new System.Drawing.Size(148, 20);
            this.txtNomProveedor.TabIndex = 2;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(123, 118);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(84, 21);
            this.cboTipo.TabIndex = 3;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(345, 22);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(62, 21);
            this.cboEstado.TabIndex = 4;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(345, 56);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(153, 20);
            this.txtCalle.TabIndex = 5;
            // 
            // cboCiudad
            // 
            this.cboCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudad.FormattingEnabled = true;
            this.cboCiudad.Location = new System.Drawing.Point(345, 88);
            this.cboCiudad.Name = "cboCiudad";
            this.cboCiudad.Size = new System.Drawing.Size(90, 21);
            this.cboCiudad.TabIndex = 7;
            this.cboCiudad.SelectedValueChanged += new System.EventHandler(this.cboCiudad_SelectedValueChanged);
            // 
            // lblBarrio
            // 
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(299, 126);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(34, 13);
            this.lblBarrio.TabIndex = 18;
            this.lblBarrio.Text = "Barrio";
            // 
            // cboBarrio
            // 
            this.cboBarrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBarrio.FormattingEnabled = true;
            this.cboBarrio.Location = new System.Drawing.Point(345, 121);
            this.cboBarrio.Name = "cboBarrio";
            this.cboBarrio.Size = new System.Drawing.Size(140, 21);
            this.cboBarrio.TabIndex = 8;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(709, 55);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(114, 20);
            this.txtTelefono.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(709, 85);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.AllowUserToOrderColumns = true;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NombreLocal,
            this.NombreProveedor,
            this.Cuit,
            this.Tipo,
            this.Estado,
            this.Calle,
            this.Numero,
            this.Ciudad,
            this.Barrio,
            this.Telefono,
            this.Email,
            this.FechaRegistro});
            this.dgvProveedores.Location = new System.Drawing.Point(12, 162);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(884, 190);
            this.dgvProveedores.TabIndex = 12;
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "ID_Proveedor";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 25;
            // 
            // NombreLocal
            // 
            this.NombreLocal.DataPropertyName = "Nombre_Local";
            this.NombreLocal.HeaderText = "Nombre Local";
            this.NombreLocal.Name = "NombreLocal";
            this.NombreLocal.ReadOnly = true;
            this.NombreLocal.Width = 75;
            // 
            // NombreProveedor
            // 
            this.NombreProveedor.DataPropertyName = "Nombre_Proveedor";
            this.NombreProveedor.HeaderText = "Nombre Proveedor";
            this.NombreProveedor.Name = "NombreProveedor";
            this.NombreProveedor.ReadOnly = true;
            this.NombreProveedor.Width = 90;
            // 
            // Cuit
            // 
            this.Cuit.DataPropertyName = "CUIT";
            this.Cuit.HeaderText = "CUIT";
            this.Cuit.Name = "Cuit";
            this.Cuit.ReadOnly = true;
            this.Cuit.Width = 85;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo_Proveedor";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 70;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado_Proveedor";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 50;
            // 
            // Calle
            // 
            this.Calle.DataPropertyName = "Domicilio_Calle";
            this.Calle.HeaderText = "Calle";
            this.Calle.Name = "Calle";
            this.Calle.ReadOnly = true;
            this.Calle.Width = 85;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Domicilio_Numero";
            this.Numero.HeaderText = "Nro.";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 35;
            // 
            // Ciudad
            // 
            this.Ciudad.DataPropertyName = "Ciudad";
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.ReadOnly = true;
            this.Ciudad.Width = 70;
            // 
            // Barrio
            // 
            this.Barrio.DataPropertyName = "Barrio";
            this.Barrio.HeaderText = "Barrio";
            this.Barrio.Name = "Barrio";
            this.Barrio.ReadOnly = true;
            this.Barrio.Width = 75;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "Telefono";
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 50;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 50;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "Fecha_Registro";
            this.FechaRegistro.HeaderText = "Fecha Registro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            this.FechaRegistro.Width = 70;
            // 
            // lblFechaRegistro
            // 
            this.lblFechaRegistro.AutoSize = true;
            this.lblFechaRegistro.Location = new System.Drawing.Point(625, 121);
            this.lblFechaRegistro.Name = "lblFechaRegistro";
            this.lblFechaRegistro.Size = new System.Drawing.Size(79, 13);
            this.lblFechaRegistro.TabIndex = 28;
            this.lblFechaRegistro.Text = "Fecha Registro";
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.Location = new System.Drawing.Point(710, 117);
            this.txtFechaRegistro.Mask = "00/00/0000";
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(71, 20);
            this.txtFechaRegistro.TabIndex = 11;
            this.txtFechaRegistro.ValidatingType = typeof(System.DateTime);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = global::Distribuidora.RF.Properties.Resources.cancelar3;
            this.btnCancelar.Location = new System.Drawing.Point(370, 360);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 36);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Distribuidora.RF.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(682, 358);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 39);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::Distribuidora.RF.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(567, 359);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 39);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Image = global::Distribuidora.RF.Properties.Resources.grabar3;
            this.btnGrabar.Location = new System.Drawing.Point(264, 359);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 39);
            this.btnGrabar.TabIndex = 15;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::Distribuidora.RF.Properties.Resources.editar;
            this.btnEditar.Location = new System.Drawing.Point(159, 360);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 39);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Distribuidora.RF.Properties.Resources.agregar;
            this.btnNuevo.Location = new System.Drawing.Point(52, 359);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 39);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(548, 56);
            this.txtNumero.Mask = "99999";
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(39, 20);
            this.txtNumero.TabIndex = 6;
            this.txtNumero.ValidatingType = typeof(int);
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(709, 20);
            this.txtCUIT.Mask = "00-00000000-0";
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(96, 20);
            this.txtCUIT.TabIndex = 29;
            this.txtCUIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Location = new System.Drawing.Point(626, 23);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(32, 13);
            this.lblCUIT.TabIndex = 30;
            this.lblCUIT.Text = "CUIT";
            // 
            // frmABMProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 407);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.lblCUIT);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtFechaRegistro);
            this.Controls.Add(this.lblFechaRegistro);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.cboBarrio);
            this.Controls.Add(this.lblBarrio);
            this.Controls.Add(this.cboCiudad);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.txtNomProveedor);
            this.Controls.Add(this.txtNomLocal);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblNomProveedor);
            this.Controls.Add(this.lblNomLocal);
            this.Controls.Add(this.lblId);
            this.Name = "frmABMProveedores";
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.frmProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNomLocal;
        private System.Windows.Forms.Label lblNomProveedor;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNomLocal;
        private System.Windows.Forms.TextBox txtNomProveedor;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.ComboBox cboCiudad;
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.ComboBox cboBarrio;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblFechaRegistro;
        private System.Windows.Forms.MaskedTextBox txtFechaRegistro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MaskedTextBox txtNumero;
        private System.Windows.Forms.MaskedTextBox txtCUIT;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barrio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
    }
}