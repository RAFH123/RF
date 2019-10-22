namespace Distribuidora.RF.GUILayer
{
    partial class frmReporteProductosVendidos
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
            this.dstProdVendidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProdVendidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dstProdVendidos = new Distribuidora.RF.BD.dstProdVendidos();
            this.prodVendidosTableAdapter = new Distribuidora.RF.BD.dstProdVendidosTableAdapters.ProdVendidosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dstProdVendidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdVendidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstProdVendidos)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dstProductosVendidos";
            reportDataSource1.Value = this.ProdVendidosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Distribuidora.RF.Reportes.rptProdVendidos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(728, 419);
            this.reportViewer1.TabIndex = 0;
            // 
            // dstProdVendidosBindingSource
            // 
            this.dstProdVendidosBindingSource.DataSource = this.ProdVendidosBindingSource;
            // 
            // ProdVendidosBindingSource
            // 
            this.ProdVendidosBindingSource.DataMember = "ProdVendidos";
            this.ProdVendidosBindingSource.DataSource = this.dstProdVendidos;
            // 
            // dstProdVendidos
            // 
            this.dstProdVendidos.DataSetName = "dstProdVendidos";
            this.dstProdVendidos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // prodVendidosTableAdapter
            // 
            this.prodVendidosTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteProductosVendidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 419);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteProductosVendidos";
            this.Text = "Reporte Productos Vendidos";
            this.Load += new System.EventHandler(this.frmReporteProductosVendidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dstProdVendidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdVendidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstProdVendidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProdVendidosBindingSource;
        private BD.dstProdVendidos dstProdVendidos;
        private System.Windows.Forms.BindingSource dstProdVendidosBindingSource;
        private BD.dstProdVendidosTableAdapters.ProdVendidosTableAdapter prodVendidosTableAdapter;
    }
}