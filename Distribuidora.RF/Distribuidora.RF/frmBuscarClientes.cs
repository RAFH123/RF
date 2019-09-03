using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distribuidora.RF
{
    public partial class frmBuscarClientes : Form
    {
        public frmBuscarClientes()
        {
            InitializeComponent();
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
        }

        private void frmBuscarClientes_Load(object sender, EventArgs e)
        {
//            dtpFechaDesde.Value = DateTime.Today;
//            dtpFechaHasta.Value = DateTime.Today;
            LlenarCombo(cboBuscarPorID, Datos.GetDatos().consultar("Select * from Clientes"), "nombre", "id_cliente");
            LlenarCombo(cboCiudad, Datos.GetDatos().consultar("Select * from Ciudades"), "nombre", "id_ciudad");
            LlenarCombo(cboBarrio, Datos.GetDatos().consultar("Select * from Barrios"), "nombre", "id_barrio");
            LlenarCombo(cboEstado, Datos.GetDatos().consultar("Select * from EstadoCliente"), "descripcion", "id_estadoC");
            LlenarCombo(cboTipo, Datos.GetDatos().consultar("Select * from TipoCliente"), "descripcion", "id_tipoC");

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            string strSql = "SELECT TOP 20 * FROM Clientes WHERE 1=1 ";

            // Dictionary: Representa una colección de claves y valores.
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            DateTime fechaDesde;
            DateTime fechaHasta;
            if (DateTime.TryParse(txtFechaDesde.Text, out fechaDesde) &&
                DateTime.TryParse(txtFechaHasta.Text, out fechaHasta))
            {
                strSql += " AND (fecha_registro>=@fechaDesde AND fecha_registro<=@fechaHasta) ";
                parametros.Add("fechaDesde", txtFechaDesde.Text);
                parametros.Add("fechaHasta", txtFechaHasta.Text);
            }


            if (!string.IsNullOrEmpty(cboBarrio.Text))
            {
                var idBarrioc = cboBarrio.SelectedValue.ToString();
                strSql += "AND (barrio=@idBarrio) ";
                parametros.Add("idBarrio", idBarrioc);
            }

            if (!string.IsNullOrEmpty(cboEstado.Text))
            {
                var estadoc = cboEstado.SelectedValue.ToString();
                strSql += "AND (estado_cliente=@estadoc) ";
                parametros.Add("estado", estadoc);
            }

            if (!string.IsNullOrEmpty(cboTipo.Text))
            {
                var tipoc = cboTipo.SelectedValue.ToString();
                strSql += "AND (tipo_cliente=@tipoc) ";
                parametros.Add("tipo_cliente", tipoc);
            }

            strSql += " ORDER BY nombre_local";
            MessageBox.Show(strSql);

            dgvSalida.DataSource = Datos.GetDatos().ConsultaSQLConParametros(strSql, parametros);
            if (dgvSalida.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSalida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
