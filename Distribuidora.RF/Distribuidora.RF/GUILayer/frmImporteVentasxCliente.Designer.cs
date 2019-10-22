namespace Distribuidora.RF.GUILayer
{
    partial class frmImporteVentasxCliente
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dstVentasxClientes = new Distribuidora.RF.BD.dstVentasxClientes();
            this.dstVentasxClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.csltVentasxClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.csltVentasxClientesTableAdapter = new Distribuidora.RF.BD.dstVentasxClientesTableAdapters.csltVentasxClientesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dstVentasxClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstVentasxClientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.csltVentasxClientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "VentasxCliente";
            reportDataSource1.Value = this.csltVentasxClientesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Distribuidora.RF.Reportes.rptVentasxClientes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(828, 403);
            this.reportViewer1.TabIndex = 0;
            // 
            // dstVentasxClientes
            // 
            this.dstVentasxClientes.DataSetName = "dstVentasxClientes";
            this.dstVentasxClientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dstVentasxClientesBindingSource
            // 
            this.dstVentasxClientesBindingSource.DataSource = this.dstVentasxClientes;
            this.dstVentasxClientesBindingSource.Position = 0;
            this.dstVentasxClientesBindingSource.CurrentChanged += new System.EventHandler(this.dstVentasxClientesBindingSource_CurrentChanged);
            // 
            // csltVentasxClientesBindingSource
            // 
            this.csltVentasxClientesBindingSource.DataMember = "csltVentasxClientes";
            this.csltVentasxClientesBindingSource.DataSource = this.dstVentasxClientesBindingSource;
            // 
            // csltVentasxClientesTableAdapter
            // 
            this.csltVentasxClientesTableAdapter.ClearBeforeFill = true;
            // 
            // frmImporteVentasxCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 403);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmImporteVentasxCliente";
            this.Text = "frmImporteVentasxCliente";
            this.Load += new System.EventHandler(this.frmImporteVentasxCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dstVentasxClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstVentasxClientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.csltVentasxClientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dstVentasxClientesBindingSource;
        private BD.dstVentasxClientes dstVentasxClientes;
        private System.Windows.Forms.BindingSource csltVentasxClientesBindingSource;
        private BD.dstVentasxClientesTableAdapters.csltVentasxClientesTableAdapter csltVentasxClientesTableAdapter;
    }
}