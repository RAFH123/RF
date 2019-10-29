namespace Distribuidora.RF.GUILayer
{
    partial class frmReporteVentasxClientesParamentrizado
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.lblCondVenta = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.cboCondVenta = new System.Windows.Forms.ComboBox();
            this.cboCiudad = new System.Windows.Forms.ComboBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dstVentasxClientes = new Distribuidora.RF.BD.dstVentasxClientes();
            this.csltVentasxClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.csltVentasxClientesTableAdapter = new Distribuidora.RF.BD.dstVentasxClientesTableAdapters.csltVentasxClientesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dstVentasxClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.csltVentasxClientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(682, 32);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 20;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(565, 32);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 19;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // lblCondVenta
            // 
            this.lblCondVenta.AutoSize = true;
            this.lblCondVenta.Location = new System.Drawing.Point(257, 37);
            this.lblCondVenta.Name = "lblCondVenta";
            this.lblCondVenta.Size = new System.Drawing.Size(103, 13);
            this.lblCondVenta.TabIndex = 18;
            this.lblCondVenta.Text = "Condición de Venta:";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(29, 37);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(43, 13);
            this.lblCiudad.TabIndex = 17;
            this.lblCiudad.Text = "Ciudad:";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Location = new System.Drawing.Point(275, 8);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(69, 13);
            this.lblFechaHasta.TabIndex = 16;
            this.lblFechaHasta.Text = "Fecha hasta:";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Location = new System.Drawing.Point(64, 8);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(72, 13);
            this.lblFechaDesde.TabIndex = 15;
            this.lblFechaDesde.Text = "Fecha desde:";
            // 
            // cboCondVenta
            // 
            this.cboCondVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondVenta.FormattingEnabled = true;
            this.cboCondVenta.Items.AddRange(new object[] {
            "Contado",
            "Cuenta Corriente",
            "Tarjeta"});
            this.cboCondVenta.Location = new System.Drawing.Point(366, 34);
            this.cboCondVenta.Name = "cboCondVenta";
            this.cboCondVenta.Size = new System.Drawing.Size(153, 21);
            this.cboCondVenta.TabIndex = 14;
            // 
            // cboCiudad
            // 
            this.cboCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudad.FormattingEnabled = true;
            this.cboCiudad.Location = new System.Drawing.Point(87, 34);
            this.cboCiudad.Name = "cboCiudad";
            this.cboCiudad.Size = new System.Drawing.Size(149, 21);
            this.cboCiudad.TabIndex = 13;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(350, 3);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaHasta.TabIndex = 12;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(151, 3);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaDesde.TabIndex = 11;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dstRepoVentasxCliente";
            reportDataSource1.Value = this.csltVentasxClientesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Distribuidora.RF.Reportes.rptVentasxClientesParametrizados.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 61);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(799, 687);
            this.reportViewer1.TabIndex = 21;
            // 
            // dstVentasxClientes
            // 
            this.dstVentasxClientes.DataSetName = "dstVentasxClientes";
            this.dstVentasxClientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // csltVentasxClientesBindingSource
            // 
            this.csltVentasxClientesBindingSource.DataMember = "csltVentasxClientes";
            this.csltVentasxClientesBindingSource.DataSource = this.dstVentasxClientes;
            // 
            // csltVentasxClientesTableAdapter
            // 
            this.csltVentasxClientesTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteVentasxClientesParamentrizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 749);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.lblCondVenta);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.lblFechaHasta);
            this.Controls.Add(this.lblFechaDesde);
            this.Controls.Add(this.cboCondVenta);
            this.Controls.Add(this.cboCiudad);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Name = "frmReporteVentasxClientesParamentrizado";
            this.Text = "Reporte Ventas por Clientes";
            this.Load += new System.EventHandler(this.frmReporteVentasxClientesParamentrizado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dstVentasxClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.csltVentasxClientesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label lblCondVenta;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.ComboBox cboCondVenta;
        private System.Windows.Forms.ComboBox cboCiudad;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource csltVentasxClientesBindingSource;
        private BD.dstVentasxClientes dstVentasxClientes;
        private BD.dstVentasxClientesTableAdapters.csltVentasxClientesTableAdapter csltVentasxClientesTableAdapter;
    }
}