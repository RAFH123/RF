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
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today;
            LlenarCombo(cboBuscarPorID, Datos.GetDatos().consultar("Select * from Clientes"), "nombre", "id_cliente");
            LlenarCombo(cboCiudad, Datos.GetDatos().consultar("Select * from Ciudades"), "nombre", "id_ciudad");
            LlenarCombo(cboBarrio, Datos.GetDatos().consultar("Select * from Barrios"), "nombre", "id_barrio");
            LlenarCombo(cboEstado, Datos.GetDatos().consultar("Select * from EstadoCliente"), "descripcion", "id_estadoC");
            LlenarCombo(cboTipo, Datos.GetDatos().consultar("Select * from TipoCliente"), "descripcion", "id_tipoC");

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            //string consultaSQL = "SELECT "
        }

        private void dgvSalida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
