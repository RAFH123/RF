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
            LlenarCombo(cboBuscarPorID, Datos.GetDatos().consultar("Select * from Clientes"), "nombre_cliente", "id_cliente");
            LlenarCombo(cboCiudad, Datos.GetDatos().consultar("Select * from Ciudades"), "nombre", "id_ciudad");
            LlenarCombo(cboBarrio, Datos.GetDatos().consultar("Select * from Barrios"), "nombre", "id_barrio");
            LlenarCombo(cboEstado, Datos.GetDatos().consultar("Select * from EstadoCliente"), "descripcion", "id_estadoC");
            LlenarCombo(cboTipo, Datos.GetDatos().consultar("Select * from TipoCliente"), "descripcion", "id_tipoC");

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvSalida.AutoGenerateColumns = false;

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvSalida.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvSalida.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
//            string strSql = "SELECT TOP 20 * FROM Clientes WHERE 1=1 ";
            string strSql = "SELECT C.id_cliente, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE 1=1 ";


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
                strSql += "AND (estado_cliente=@estado) ";
                parametros.Add("estado", estadoc);
            }

            if (!string.IsNullOrEmpty(cboTipo.Text))
            {
                var tipocl = cboTipo.SelectedValue.ToString();
                strSql += "AND (tipo_cliente=@tipoc) ";
                parametros.Add("tipoc", tipocl);
            }

            if (!string.IsNullOrEmpty(cboBuscarPorID.Text))
            {
                var idc = cboBuscarPorID.SelectedValue.ToString();
                strSql += "AND (id_cliente=@idcliente) ";
                parametros.Add("idcliente", idc);
            }

            strSql += " ORDER BY nombre_local";
            //MessageBox.Show(strSql);

            dgvSalida.DataSource = Datos.GetDatos().ConsultaSQLConParametros(strSql, parametros);
            if (dgvSalida.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSalida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cuando seleccionamos una fila de la grilla habilitamos el boton btnDetalleBug.
            btnDetalle.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFechaDesde.Text = "";
            txtFechaHasta.Text = "";
            cboBarrio.SelectedIndex = -1;
            cboBuscarPorID.SelectedIndex = -1;
            cboCiudad.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvSalida.CurrentRow != null)
            {
                frmDetalle frmDet = new frmDetalle();
                var selectedItem = (DataRowView)dgvSalida.CurrentRow.DataBoundItem;
                frmDet.InicializarDetalle(selectedItem["id_cliente"].ToString());
                frmDet.Enabled = true;
                frmDet.ShowDialog();
            }
        }
    }
}
