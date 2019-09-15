using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Distribuidora.RF.Entities;
using Distribuidora.RF.BusinessLayer;

namespace Distribuidora.RF.GUILayer
{
    public partial class frmDetalle : Form
    {
        private ClienteService clienteService;
        
        public frmDetalle()
        {
            InitializeComponent();
            clienteService = new ClienteService();

        }

        internal void InicializarDetalle(int idCliente)
        {
            var resultado = clienteService.ConsultarClientesPorId(idCliente);

            if (resultado != null)
            {
                txtId.Text = resultado.ID_Cliente.ToString();
                txtNomLocal.Text = resultado.Nombre_Local;
                txtNomCliente.Text = resultado.Nombre_Cliente;
                txtCalle.Text = resultado.Domicilio_Calle;
                txtNumero.Text = resultado.Domicilio_Numero.ToString();
                txtBarrio.Text = resultado.Barrio.Nombre;
                txtEstado.Text = resultado.Estado_Cliente.Descripcion;
                txtTipo.Text = resultado.Tipo_Cliente.Descripcion;
                txtFechaRegistro.Text = resultado.Fecha_Registro.ToString();
                txtEmail.Text = resultado.Email;
            }

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
