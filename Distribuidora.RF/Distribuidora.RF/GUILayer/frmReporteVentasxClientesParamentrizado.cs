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
    public partial class frmReporteVentasxClientesParamentrizado : Form
    {
        private CiudadService oCiudadService;

        public frmReporteVentasxClientesParamentrizado()
        {
            InitializeComponent();
            oCiudadService = new CiudadService();
        }

        private void frmReporteVentasxClientesParamentrizado_Load(object sender, EventArgs e)
        {
            // Fechadesde es la menor fecha de facturación
            dtpFechaDesde.Value = DateTime.Parse("01/01/2019 00:00:00");
            dtpFechaHasta.Value = DateTime.Now;
            LlenarCombo(cboCiudad, oCiudadService.ObtenerTodos(), "Nombre", "ID_Ciudad");

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
            ReportParameter[] parametros = new ReportParameter[5];
            //Establecemos el valor de los parámetros
            parametros[0] = new ReportParameter("fechadesde", dtpFechaDesde.Value.ToShortDateString());
            parametros[1] = new ReportParameter("fechahasta", dtpFechaHasta.Value.ToShortDateString());
            parametros[2] = new ReportParameter("IdCiudad", cboCiudad.SelectedIndex == -1 ? "0" : cboCiudad.SelectedValue.ToString());
            parametros[3] = new ReportParameter("Ciudad", cboCiudad.SelectedIndex == -1 ? "Todas" : cboCiudad.SelectedItem.ToString());
            parametros[4] = new ReportParameter("CondVenta", cboCondVenta.SelectedIndex == -1 ? "Todas" : cboCondVenta.SelectedItem.ToString());

            if (cboCiudad.SelectedIndex > -1 && cboCondVenta.SelectedIndex > -1)
                this.csltVentasxClientesTableAdapter.FillConsultaconFechaCiudadCondVenta
                    (this.dstVentasxClientes.csltVentasxClientes, dtpFechaDesde.Value.ToShortDateString(),
                    dtpFechaHasta.Value.ToShortDateString(), (int)cboCiudad.SelectedValue, cboCondVenta.SelectedItem.ToString());
            else
                if (cboCiudad.SelectedIndex > -1 && cboCondVenta.SelectedIndex == -1)
                    this.csltVentasxClientesTableAdapter.FillByConsultaconFechaCiudad
                        (this.dstVentasxClientes.csltVentasxClientes, dtpFechaDesde.Value.ToShortDateString(),
                        dtpFechaHasta.Value.ToShortDateString(), (int)cboCiudad.SelectedValue);
                else
                    if (cboCondVenta.SelectedIndex > -1 && cboCiudad.SelectedIndex == -1)
                        this.csltVentasxClientesTableAdapter.FillByConsultaconFechaCondVenta
                            (this.dstVentasxClientes.csltVentasxClientes, dtpFechaDesde.Value.ToShortDateString(),
                            dtpFechaHasta.Value.ToShortDateString(), cboCondVenta.SelectedItem.ToString());
                    else
                        this.csltVentasxClientesTableAdapter.FillByConsultaconFecha
                            (this.dstVentasxClientes.csltVentasxClientes, dtpFechaDesde.Value.ToShortDateString(),
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
            cboCiudad.SelectedIndex = -1;
            cboCondVenta.SelectedIndex = -1;
        }
    }
}
