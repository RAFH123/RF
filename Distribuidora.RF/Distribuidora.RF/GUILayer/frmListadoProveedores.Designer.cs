namespace Distribuidora.RF.GUILayer
{
    partial class frmListadoProveedores
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
            this.dstProveedores = new Distribuidora.RF.BD.dstProveedores();
            this.dstProveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proveedoresBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.proveedoresTableAdapter = new Distribuidora.RF.BD.dstProveedoresTableAdapters.ProveedoresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dstProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstProveedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProveedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dstListadoProveedores";
            reportDataSource1.Value = this.proveedoresBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Distribuidora.RF.Reportes.rptProveedores.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(770, 474);
            this.reportViewer1.TabIndex = 0;
            // 
            // dstProveedores
            // 
            this.dstProveedores.DataSetName = "dstProveedores";
            this.dstProveedores.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dstProveedoresBindingSource
            // 
            this.dstProveedoresBindingSource.DataSource = this.dstProveedores;
            this.dstProveedoresBindingSource.Position = 0;
            // 
            // ProveedoresBindingSource
            // 
            this.ProveedoresBindingSource.DataMember = "Proveedores";
            this.ProveedoresBindingSource.DataSource = this.dstProveedores;
            // 
            // proveedoresBindingSource1
            // 
            this.proveedoresBindingSource1.DataMember = "Proveedores";
            this.proveedoresBindingSource1.DataSource = this.dstProveedoresBindingSource;
            // 
            // proveedoresTableAdapter
            // 
            this.proveedoresTableAdapter.ClearBeforeFill = true;
            // 
            // frmListadoProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 474);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmListadoProveedores";
            this.Text = "Listado de Proveedores";
            this.Load += new System.EventHandler(this.frmListadoProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dstProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstProveedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProveedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProveedoresBindingSource;
        private BD.dstProveedores dstProveedores;
        private System.Windows.Forms.BindingSource dstProveedoresBindingSource;
        private System.Windows.Forms.BindingSource proveedoresBindingSource1;
        private BD.dstProveedoresTableAdapters.ProveedoresTableAdapter proveedoresTableAdapter;
    }
}