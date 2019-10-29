using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Distribuidora.RF.BusinessLayer;

namespace Distribuidora.RF.GUILayer
{
    public partial class frmProductosVendidosParametrizados : Form
    {
        private CategoriaService oCategoriaService;
        private ClienteService oClienteService;

        public frmProductosVendidosParametrizados()
        {
            InitializeComponent();
            oCategoriaService = new CategoriaService();
            oClienteService = new ClienteService();
        }

        private void frmProductosVendidosParametrizados_Load(object sender, EventArgs e)
        {
            // Fechadesde es la menor fecha de facturación
            dtpFechaDesde.Value = DateTime.Parse("01/01/2019 00:00:00");
            dtpFechaHasta.Value = DateTime.Now;
            LlenarCombo(cboCliente, oClienteService.ObtenerTodos(), "Nombre_Cliente", "ID_Cliente");
            LlenarCombo(cboCategoria, oCategoriaService.ObtenerTodos(), "Descripcion", "ID_Categoria");

            //this.reportViewer1.RefreshReport();
        }
        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DataSource = source;
            cbo.SelectedIndex = -1;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Array que contendrá los parámetros
            ReportParameter[] parametros = new ReportParameter[6];
            //Establecemos el valor de los parámetros
            parametros[0] = new ReportParameter("fechadesde", dtpFechaDesde.Value.ToShortDateString());
            parametros[1] = new ReportParameter("fechahasta", dtpFechaHasta.Value.ToShortDateString());
            parametros[2] = new ReportParameter("IdCategoria", cboCategoria.SelectedIndex == -1 ? "0" : cboCategoria.SelectedValue.ToString());
            parametros[3] = new ReportParameter("IdCliente", cboCliente.SelectedIndex == -1 ? "0" : cboCliente.SelectedValue.ToString());
            parametros[4] = new ReportParameter("Categoria", cboCategoria.SelectedIndex == -1 ? "Todas" : cboCategoria.SelectedItem.ToString());
            parametros[5] = new ReportParameter("Cliente", cboCliente.SelectedIndex == -1 ? "Todos" : cboCliente.SelectedItem.ToString());

            if (cboCategoria.SelectedIndex > -1 && cboCliente.SelectedIndex > -1)
                this.csltProductosVendidosTableAdapter.FillConsultaconFechaClienteCategoria
                    (this.dstProductosVendidosParametrizados.csltProductosVendidos, dtpFechaDesde.Value.ToShortDateString(),
                    dtpFechaHasta.Value.ToShortDateString(), (int)cboCliente.SelectedValue, (int)cboCategoria.SelectedValue);
            else
                if (cboCategoria.SelectedIndex > -1 && cboCliente.SelectedIndex == -1)
                    this.csltProductosVendidosTableAdapter.FillByConsultaconFechaCategoria
                        (this.dstProductosVendidosParametrizados.csltProductosVendidos, dtpFechaDesde.Value.ToShortDateString(),
                        dtpFechaHasta.Value.ToShortDateString(), (int)cboCategoria.SelectedValue);
                else
                    if (cboCliente.SelectedIndex > -1 && cboCategoria.SelectedIndex == -1)
                        this.csltProductosVendidosTableAdapter.FillByConsultaconFechaCliente
                            (this.dstProductosVendidosParametrizados.csltProductosVendidos, dtpFechaDesde.Value.ToShortDateString(),
                            dtpFechaHasta.Value.ToShortDateString(), (int)cboCliente.SelectedValue);
                    else
                        this.csltProductosVendidosTableAdapter.FillByConsultaconFecha
                            (this.dstProductosVendidosParametrizados.csltProductosVendidos, dtpFechaDesde.Value.ToShortDateString(),
                            dtpFechaHasta.Value.ToShortDateString());


            //Pasamos el array de los parámetros al ReportViewer
            reportViewer1.LocalReport.SetParameters(parametros);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Parse("01/01/2019 00:00:00");
            dtpFechaHasta.Value = DateTime.Now;
            cboCategoria.SelectedIndex = -1;
            cboCliente.SelectedIndex = -1;
        }
    }
}
