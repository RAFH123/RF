namespace Distribuidora.RF.GUILayer
{
    partial class frmFactura
    {
        //cambio para que se suba en el repositorio
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
            this.lblTipoFact = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblNroFact = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblCondIVA = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboTipoFact = new System.Windows.Forms.ComboBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.cboCondIVA = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNroFact = new System.Windows.Forms.TextBox();
            this.dpbDetalle = new System.Windows.Forms.GroupBox();
            this._txtCantidad = new System.Windows.Forms.MaskedTextBox();
            this._txtImporte = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this._btnNuevo = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this._btnQuitar = new System.Windows.Forms.Button();
            this._btnAgregar = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.NroItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this._lblCantidad = new System.Windows.Forms.Label();
            this._lblArticulo = new System.Windows.Forms.Label();
            this._cboArticulo = new System.Windows.Forms.ComboBox();
            this.lblCondVenta = new System.Windows.Forms.Label();
            this.cboCondVenta = new System.Windows.Forms.ComboBox();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.txtCUIT = new System.Windows.Forms.MaskedTextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblImporteNeto = new System.Windows.Forms.Label();
            this.lblIVAInscr = new System.Windows.Forms.Label();
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtImporteNeto = new System.Windows.Forms.TextBox();
            this.txtIVAInscr = new System.Windows.Forms.TextBox();
            this.txtImporteTotal = new System.Windows.Forms.TextBox();
            this.lblSugerido = new System.Windows.Forms.Label();
            this.dpbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTipoFact
            // 
            this.lblTipoFact.AutoSize = true;
            this.lblTipoFact.Location = new System.Drawing.Point(23, 24);
            this.lblTipoFact.Name = "lblTipoFact";
            this.lblTipoFact.Size = new System.Drawing.Size(55, 13);
            this.lblTipoFact.TabIndex = 0;
            this.lblTipoFact.Text = "Tipo Fact.";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(559, 30);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(23, 65);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente";
            // 
            // lblNroFact
            // 
            this.lblNroFact.AutoSize = true;
            this.lblNroFact.Location = new System.Drawing.Point(252, 27);
            this.lblNroFact.Name = "lblNroFact";
            this.lblNroFact.Size = new System.Drawing.Size(54, 13);
            this.lblNroFact.TabIndex = 3;
            this.lblNroFact.Text = "Nro. Fact.";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(233, 65);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblCondIVA
            // 
            this.lblCondIVA.AutoSize = true;
            this.lblCondIVA.Location = new System.Drawing.Point(20, 106);
            this.lblCondIVA.Name = "lblCondIVA";
            this.lblCondIVA.Size = new System.Drawing.Size(55, 13);
            this.lblCondIVA.TabIndex = 5;
            this.lblCondIVA.Text = "Cond. IVA";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(619, 27);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha.TabIndex = 1;
            this.dtpFecha.Value = new System.DateTime(2019, 9, 29, 17, 20, 8, 0);
            // 
            // cboTipoFact
            // 
            this.cboTipoFact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFact.FormattingEnabled = true;
            this.cboTipoFact.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cboTipoFact.Location = new System.Drawing.Point(84, 23);
            this.cboTipoFact.Name = "cboTipoFact";
            this.cboTipoFact.Size = new System.Drawing.Size(121, 21);
            this.cboTipoFact.TabIndex = 0;
            this.cboTipoFact.SelectionChangeCommitted += new System.EventHandler(this.cboTipoFact_SelectionChangeCommitted);
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(84, 62);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(121, 21);
            this.cboCliente.TabIndex = 2;
            this.cboCliente.SelectionChangeCommitted += new System.EventHandler(this.cboCliente_SelectionChangeCommitted);
            // 
            // cboCondIVA
            // 
            this.cboCondIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondIVA.FormattingEnabled = true;
            this.cboCondIVA.Items.AddRange(new object[] {
            "Consumidor Final",
            "Exento",
            "No Responsable",
            "Responsable Monotributo",
            "Responsable No Inscripto",
            "Responsable Inscripto"});
            this.cboCondIVA.Location = new System.Drawing.Point(84, 103);
            this.cboCondIVA.Name = "cboCondIVA";
            this.cboCondIVA.Size = new System.Drawing.Size(143, 21);
            this.cboCondIVA.TabIndex = 5;
            this.cboCondIVA.SelectionChangeCommitted += new System.EventHandler(this.cboCondIVA_SelectionChangeCommitted);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(291, 62);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(255, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // txtNroFact
            // 
            this.txtNroFact.Location = new System.Drawing.Point(325, 24);
            this.txtNroFact.Name = "txtNroFact";
            this.txtNroFact.ReadOnly = true;
            this.txtNroFact.Size = new System.Drawing.Size(100, 20);
            this.txtNroFact.TabIndex = 1;
            // 
            // dpbDetalle
            // 
            this.dpbDetalle.Controls.Add(this._txtCantidad);
            this.dpbDetalle.Controls.Add(this._txtImporte);
            this.dpbDetalle.Controls.Add(this.lblImporte);
            this.dpbDetalle.Controls.Add(this._btnNuevo);
            this.dpbDetalle.Controls.Add(this._btnCancelar);
            this.dpbDetalle.Controls.Add(this._btnQuitar);
            this.dpbDetalle.Controls.Add(this._btnAgregar);
            this.dpbDetalle.Controls.Add(this.dgvDetalle);
            this.dpbDetalle.Controls.Add(this._txtPrecio);
            this.dpbDetalle.Controls.Add(this.lblPrecio);
            this.dpbDetalle.Controls.Add(this._lblCantidad);
            this.dpbDetalle.Controls.Add(this._lblArticulo);
            this.dpbDetalle.Controls.Add(this._cboArticulo);
            this.dpbDetalle.Location = new System.Drawing.Point(26, 146);
            this.dpbDetalle.Name = "dpbDetalle";
            this.dpbDetalle.Size = new System.Drawing.Size(773, 264);
            this.dpbDetalle.TabIndex = 7;
            this.dpbDetalle.TabStop = false;
            this.dpbDetalle.Text = "Detalle";
            // 
            // _txtCantidad
            // 
            this._txtCantidad.Enabled = false;
            this._txtCantidad.Location = new System.Drawing.Point(267, 29);
            this._txtCantidad.Mask = "99999";
            this._txtCantidad.Name = "_txtCantidad";
            this._txtCantidad.Size = new System.Drawing.Size(41, 20);
            this._txtCantidad.TabIndex = 1;
            this._txtCantidad.ValidatingType = typeof(int);
            this._txtCantidad.TextChanged += new System.EventHandler(this._txtCantidad_TextChanged);
            // 
            // _txtImporte
            // 
            this._txtImporte.Location = new System.Drawing.Point(512, 28);
            this._txtImporte.Name = "_txtImporte";
            this._txtImporte.ReadOnly = true;
            this._txtImporte.Size = new System.Drawing.Size(68, 20);
            this._txtImporte.TabIndex = 3;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(467, 33);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(42, 13);
            this.lblImporte.TabIndex = 8;
            this.lblImporte.Text = "Importe";
            // 
            // _btnNuevo
            // 
            this._btnNuevo.Image = global::Distribuidora.RF.Properties.Resources.nuevo1;
            this._btnNuevo.Location = new System.Drawing.Point(600, 19);
            this._btnNuevo.Name = "_btnNuevo";
            this._btnNuevo.Size = new System.Drawing.Size(37, 36);
            this._btnNuevo.TabIndex = 4;
            this._btnNuevo.UseVisualStyleBackColor = true;
            this._btnNuevo.Click += new System.EventHandler(this._btnNuevo_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::Distribuidora.RF.Properties.Resources.cancelar3;
            this._btnCancelar.Location = new System.Drawing.Point(729, 19);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(38, 36);
            this._btnCancelar.TabIndex = 7;
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _btnQuitar
            // 
            this._btnQuitar.Image = global::Distribuidora.RF.Properties.Resources.eliminar;
            this._btnQuitar.Location = new System.Drawing.Point(685, 19);
            this._btnQuitar.Name = "_btnQuitar";
            this._btnQuitar.Size = new System.Drawing.Size(38, 36);
            this._btnQuitar.TabIndex = 6;
            this._btnQuitar.UseVisualStyleBackColor = true;
            this._btnQuitar.Click += new System.EventHandler(this._btnQuitar_Click);
            // 
            // _btnAgregar
            // 
            this._btnAgregar.Image = global::Distribuidora.RF.Properties.Resources.agregar;
            this._btnAgregar.Location = new System.Drawing.Point(643, 19);
            this._btnAgregar.Name = "_btnAgregar";
            this._btnAgregar.Size = new System.Drawing.Size(36, 36);
            this._btnAgregar.TabIndex = 5;
            this._btnAgregar.UseVisualStyleBackColor = true;
            this._btnAgregar.Click += new System.EventHandler(this._btnAgregar_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroItem,
            this.CodArt,
            this.Descripcion,
            this.Cantidad,
            this.Precio,
            this.Importe});
            this.dgvDetalle.Location = new System.Drawing.Point(13, 61);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(760, 180);
            this.dgvDetalle.TabIndex = 7;
            this.dgvDetalle.SelectionChanged += new System.EventHandler(this.dgvDetalle_SelectionChanged);
            // 
            // NroItem
            // 
            this.NroItem.HeaderText = "Nro. Ítem";
            this.NroItem.Name = "NroItem";
            this.NroItem.ReadOnly = true;
            this.NroItem.Width = 70;
            // 
            // CodArt
            // 
            this.CodArt.HeaderText = "Cod. Art.";
            this.CodArt.Name = "CodArt";
            this.CodArt.ReadOnly = true;
            this.CodArt.Width = 70;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 250;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 70;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 70;
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 150;
            // 
            // _txtPrecio
            // 
            this._txtPrecio.Location = new System.Drawing.Point(379, 30);
            this._txtPrecio.Name = "_txtPrecio";
            this._txtPrecio.ReadOnly = true;
            this._txtPrecio.Size = new System.Drawing.Size(68, 20);
            this._txtPrecio.TabIndex = 2;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(336, 33);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Precio";
            // 
            // _lblCantidad
            // 
            this._lblCantidad.AutoSize = true;
            this._lblCantidad.Location = new System.Drawing.Point(212, 33);
            this._lblCantidad.Name = "_lblCantidad";
            this._lblCantidad.Size = new System.Drawing.Size(49, 13);
            this._lblCantidad.TabIndex = 2;
            this._lblCantidad.Text = "Cantidad";
            // 
            // _lblArticulo
            // 
            this._lblArticulo.AutoSize = true;
            this._lblArticulo.Location = new System.Drawing.Point(8, 32);
            this._lblArticulo.Name = "_lblArticulo";
            this._lblArticulo.Size = new System.Drawing.Size(44, 13);
            this._lblArticulo.TabIndex = 1;
            this._lblArticulo.Text = "Artículo";
            // 
            // _cboArticulo
            // 
            this._cboArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboArticulo.FormattingEnabled = true;
            this._cboArticulo.Location = new System.Drawing.Point(58, 28);
            this._cboArticulo.Name = "_cboArticulo";
            this._cboArticulo.Size = new System.Drawing.Size(133, 21);
            this._cboArticulo.TabIndex = 0;
            this._cboArticulo.SelectionChangeCommitted += new System.EventHandler(this._cboArticulo_SelectionChangeCommitted);
            // 
            // lblCondVenta
            // 
            this.lblCondVenta.AutoSize = true;
            this.lblCondVenta.Location = new System.Drawing.Point(252, 109);
            this.lblCondVenta.Name = "lblCondVenta";
            this.lblCondVenta.Size = new System.Drawing.Size(66, 13);
            this.lblCondVenta.TabIndex = 13;
            this.lblCondVenta.Text = "Cond. Venta";
            // 
            // cboCondVenta
            // 
            this.cboCondVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondVenta.FormattingEnabled = true;
            this.cboCondVenta.Items.AddRange(new object[] {
            "Contado",
            "Cuenta Corriente",
            "Tarjeta"});
            this.cboCondVenta.Location = new System.Drawing.Point(352, 106);
            this.cboCondVenta.Name = "cboCondVenta";
            this.cboCondVenta.Size = new System.Drawing.Size(121, 21);
            this.cboCondVenta.TabIndex = 6;
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Location = new System.Drawing.Point(574, 68);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(32, 13);
            this.lblCUIT.TabIndex = 15;
            this.lblCUIT.Text = "CUIT";
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(633, 65);
            this.txtCUIT.Mask = "00-00000000-0";
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(96, 20);
            this.txtCUIT.TabIndex = 4;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Distribuidora.RF.Properties.Resources.nuevo1;
            this.btnNuevo.Location = new System.Drawing.Point(152, 472);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 36);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = global::Distribuidora.RF.Properties.Resources.grabar3;
            this.btnGrabar.Location = new System.Drawing.Point(285, 473);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 35);
            this.btnGrabar.TabIndex = 14;
            this.btnGrabar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Distribuidora.RF.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(672, 473);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 35);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(103, 413);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(46, 13);
            this.lblSubtotal.TabIndex = 20;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(217, 413);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(76, 13);
            this.lblDescuento.TabIndex = 21;
            this.lblDescuento.Text = "Descuento (%)";
            // 
            // lblImporteNeto
            // 
            this.lblImporteNeto.AutoSize = true;
            this.lblImporteNeto.Location = new System.Drawing.Point(346, 413);
            this.lblImporteNeto.Name = "lblImporteNeto";
            this.lblImporteNeto.Size = new System.Drawing.Size(68, 13);
            this.lblImporteNeto.TabIndex = 22;
            this.lblImporteNeto.Text = "Importe Neto";
            // 
            // lblIVAInscr
            // 
            this.lblIVAInscr.AutoSize = true;
            this.lblIVAInscr.Location = new System.Drawing.Point(468, 413);
            this.lblIVAInscr.Name = "lblIVAInscr";
            this.lblIVAInscr.Size = new System.Drawing.Size(62, 13);
            this.lblIVAInscr.TabIndex = 23;
            this.lblIVAInscr.Text = "I.V.A. Inscr.";
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.AutoSize = true;
            this.lblImporteTotal.Location = new System.Drawing.Point(647, 413);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(69, 13);
            this.lblImporteTotal.TabIndex = 24;
            this.lblImporteTotal.Text = "Importe Total";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Enabled = false;
            this.txtSubtotal.Location = new System.Drawing.Point(82, 437);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(100, 20);
            this.txtSubtotal.TabIndex = 8;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(206, 437);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(100, 20);
            this.txtDescuento.TabIndex = 9;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            // 
            // txtImporteNeto
            // 
            this.txtImporteNeto.Enabled = false;
            this.txtImporteNeto.Location = new System.Drawing.Point(335, 437);
            this.txtImporteNeto.Name = "txtImporteNeto";
            this.txtImporteNeto.Size = new System.Drawing.Size(100, 20);
            this.txtImporteNeto.TabIndex = 10;
            // 
            // txtIVAInscr
            // 
            this.txtIVAInscr.Enabled = false;
            this.txtIVAInscr.Location = new System.Drawing.Point(456, 437);
            this.txtIVAInscr.Name = "txtIVAInscr";
            this.txtIVAInscr.Size = new System.Drawing.Size(100, 20);
            this.txtIVAInscr.TabIndex = 11;
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Enabled = false;
            this.txtImporteTotal.Location = new System.Drawing.Point(633, 437);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.Size = new System.Drawing.Size(100, 20);
            this.txtImporteTotal.TabIndex = 12;
            // 
            // lblSugerido
            // 
            this.lblSugerido.AutoSize = true;
            this.lblSugerido.Location = new System.Drawing.Point(431, 27);
            this.lblSugerido.Name = "lblSugerido";
            this.lblSugerido.Size = new System.Drawing.Size(53, 13);
            this.lblSugerido.TabIndex = 30;
            this.lblSugerido.Text = "(sugerido)";
            // 
            // frmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 520);
            this.Controls.Add(this.lblSugerido);
            this.Controls.Add(this.txtImporteTotal);
            this.Controls.Add(this.txtIVAInscr);
            this.Controls.Add(this.txtImporteNeto);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.lblImporteTotal);
            this.Controls.Add(this.lblIVAInscr);
            this.Controls.Add(this.lblImporteNeto);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.lblCUIT);
            this.Controls.Add(this.cboCondVenta);
            this.Controls.Add(this.lblCondVenta);
            this.Controls.Add(this.dpbDetalle);
            this.Controls.Add(this.txtNroFact);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.cboCondIVA);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.cboTipoFact);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblCondIVA);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblNroFact);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTipoFact);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmFactura";
            this.Load += new System.EventHandler(this.frmFactura_Load);
            this.dpbDetalle.ResumeLayout(false);
            this.dpbDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipoFact;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblNroFact;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblCondIVA;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboTipoFact;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.ComboBox cboCondIVA;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNroFact;
        private System.Windows.Forms.GroupBox dpbDetalle;
        private System.Windows.Forms.Button _btnCancelar;
        private System.Windows.Forms.Button _btnQuitar;
        private System.Windows.Forms.Button _btnAgregar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.TextBox _txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label _lblCantidad;
        private System.Windows.Forms.Label _lblArticulo;
        private System.Windows.Forms.ComboBox _cboArticulo;
        private System.Windows.Forms.Label lblCondVenta;
        private System.Windows.Forms.ComboBox cboCondVenta;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.MaskedTextBox txtCUIT;
        private System.Windows.Forms.Button _btnNuevo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblImporteNeto;
        private System.Windows.Forms.Label lblIVAInscr;
        private System.Windows.Forms.Label lblImporteTotal;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtImporteNeto;
        private System.Windows.Forms.TextBox txtIVAInscr;
        private System.Windows.Forms.TextBox txtImporteTotal;
        private System.Windows.Forms.Label lblSugerido;
        private System.Windows.Forms.TextBox _txtImporte;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.MaskedTextBox _txtCantidad;
    }
}