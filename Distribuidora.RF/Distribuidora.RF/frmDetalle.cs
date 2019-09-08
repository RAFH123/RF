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
    public partial class frmDetalle : Form
    {
        public frmDetalle()
        {
            InitializeComponent();
        }

        internal void InicializarDetalle(string idCliente)
        {
            string strSql = "SELECT C.id_cliente, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.id_cliente = " + idCliente.ToString();

            var resultado = Datos.GetDatos().consultar(strSql);

            if (resultado.Rows.Count > 0)
            {
                var oClienteSeleccionado = resultado.Rows[0];
                txtId.Text = oClienteSeleccionado["id_cliente"].ToString();
                txtNomLocal.Text = oClienteSeleccionado["nombre_local"].ToString();
                txtNomCliente.Text = oClienteSeleccionado["nombre_cliente"].ToString();
                txtCalle.Text = oClienteSeleccionado["domicilio_calle"].ToString();
                txtNumero.Text = oClienteSeleccionado["domicilio_numero"].ToString();
                txtBarrio.Text = oClienteSeleccionado["barrio"].ToString();
                txtEstado.Text = oClienteSeleccionado["estado"].ToString();
                txtTipo.Text = oClienteSeleccionado["tipo"].ToString();
                txtFechaRegistro.Text = oClienteSeleccionado["fecha_registro"].ToString();
                txtEmail.Text = oClienteSeleccionado["email"].ToString();
            }

//            InicializarHistoricoBug(idBug);
        }
 
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
