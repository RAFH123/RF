using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Distribuidora.RF.BusinessLayer;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.GUILayer
{
    public partial class frmClientes : Form
    {
        private ClienteService oClienteService;
        private Tipo_ClienteService oTipoClienteService;
        private Estado_ClienteService oEstadoService;
        private CiudadService oCiudadService;
        private BarrioService oBarrioService;

        bool nuevo = false;

        public frmClientes()
        {
            InitializeComponent();
         
            oClienteService = new ClienteService();
            oTipoClienteService = new Tipo_ClienteService();
            oEstadoService = new Estado_ClienteService();
            oCiudadService = new CiudadService();
            oBarrioService = new BarrioService();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboCiudad, oCiudadService.ObtenerTodos(), "Nombre", "ID_Ciudad");
            LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(""), "Nombre", "ID_Barrio");
            LlenarCombo(cboEstado, oEstadoService.ObtenerTodos(), "Descripcion", "ID_EstadoC");
            LlenarCombo(cboTipo, oTipoClienteService.ObtenerTodos(), "Descripcion", "ID_TipoC");

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvClientes.AutoGenerateColumns = false;

            IList<Cliente> listcli = new List<Cliente>();
            listcli = oClienteService.ObtenerTodos();

//            dgvClientes.DataSource = oClienteService.ObtenerTodos();
            dgvClientes.DataSource = listcli;
            for (int i = 0; i < dgvClientes.RowCount; i++)
            {
                dgvClientes.Rows[i].Cells["Ciudad"].Value = listcli[i].Barrio.Ciudad;
            }

            this.habilitar(false);
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DataSource = source;
            cbo.SelectedIndex = -1;
        }
        
        private void limpiar()
        {
            txtId.Clear();
            txtNomLocal.Clear();
            txtNomCliente.Clear();
            cboTipo.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
            txtCalle.Clear();
            txtNumero.Clear();
            cboCiudad.SelectedIndex = -1;
            cboBarrio.SelectedIndex = -1;
            txtTelefono.Clear();
            txtEmail.Clear();
            txtFechaRegistro.Clear();
            LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(""), "Nombre", "ID_Barrio");
        }
        private void habilitar(bool x)
        {
            txtNomLocal.Enabled = x;
            txtNomCliente.Enabled = x;
            cboTipo.Enabled = x;
            cboEstado.Enabled = x;
            txtCalle.Enabled = x;
            txtNumero.Enabled = x;
            cboCiudad.Enabled = x;
            cboBarrio.Enabled = x;
            txtTelefono.Enabled = x;
            txtEmail.Enabled = x;
            txtFechaRegistro.Enabled = x;

            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnEliminar.Enabled = !x;
            btnSalir.Enabled = !x;
            btnCancelar.Enabled = x;
            btnGrabar.Enabled = x;
        }

        private void actualizarCampos(int id)
        {
            Cliente oCli = new Cliente();
            oCli = oClienteService.ConsultarClientesPorId(id);

            if (oCli != null)
            { 
                txtId.Text = oCli.ID_Cliente.ToString();
                txtNomLocal.Text = oCli.Nombre_Local;
                txtNomCliente.Text = oCli.Nombre_Cliente;
                cboTipo.SelectedValue = oCli.Tipo_Cliente.ID_TipoC;
                cboEstado.SelectedValue = oCli.Estado_Cliente.ID_EstadoC;
                txtCalle.Text = oCli.Domicilio_Calle;
                txtNumero.Text = oCli.Domicilio_Numero.ToString();
                cboCiudad.SelectedValue = oCli.Barrio.Ciudad.ID_Ciudad;

                if (cboCiudad.SelectedValue != null)
                    LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(cboCiudad.SelectedValue.ToString()), "Nombre", "ID_Barrio");
                else
                    LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(""), "Nombre", "ID_Barrio");
                cboBarrio.SelectedValue = oCli.Barrio.ID_Barrio;
                
                txtTelefono.Text = oCli.Telefono;
                txtEmail.Text = oCli.Email;

                if (oCli.Fecha_Registro.ToString("dd/MM/yyyy") != "01/01/0001")
                    txtFechaRegistro.Text = oCli.Fecha_Registro.ToString("dd/MM/yyyy");
                else
                {  
//                    if (this.nuevo)
//                        txtFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");
//                    else
                        txtFechaRegistro.Text = string.Empty;
                }
            }
        }

        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtNomCliente.Text.Trim() == string.Empty)
            {
                txtNomCliente.Focus();
                return false;
            }
            else
            { 
                if (txtCalle.Text == string.Empty)
                {
                    txtCalle.Focus();
                    return false;
                }
                else
                { 
                    if (txtNumero.Text == string.Empty)
                    {
                        txtNumero.Focus();
                        return false;
                    }
                    else
                        return true;
                }
            }

        }

        private bool ExisteCliente()
        {
            return oClienteService.ObtenerCliente(txtNomCliente.Text) != null;
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos(Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value));
            this.habilitar(false);
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevo = true;
            this.limpiar();
            this.habilitar(true);
            txtFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtNomLocal.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.habilitar(true);
            this.nuevo = false;
            this.txtNomLocal.Focus();
            this.btnCancelar.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Cliente oCli = new Cliente();

                int i = 0;
                oCli.ID_Cliente = Int32.TryParse(txtId.Text, out i) ? i : 0;
                oCli.Nombre_Local = txtNomLocal.Text;
                oCli.Nombre_Cliente = txtNomCliente.Text;

                oCli.Tipo_Cliente = new Tipo_Cliente();
                oCli.Tipo_Cliente.ID_TipoC = cboTipo.SelectedValue == null ? 0 : (int)cboTipo.SelectedValue;

                oCli.Estado_Cliente = new Estado_Cliente();
                oCli.Estado_Cliente.ID_EstadoC = cboEstado.SelectedValue == null ? 0 : (int)cboEstado.SelectedValue;
                oCli.Domicilio_Calle = txtCalle.Text;
                oCli.Domicilio_Numero = Int32.TryParse(txtNumero.Text, out i) ? i : 0;

                oCli.Barrio = new Barrio();
                oCli.Barrio.ID_Barrio = cboBarrio.SelectedValue == null ? 0 : (int)cboBarrio.SelectedValue;

                oCli.Barrio.Ciudad = new Ciudad();
                oCli.Barrio.Ciudad.ID_Ciudad = cboCiudad.SelectedValue == null ? 0 : (int)cboCiudad.SelectedValue;

                oCli.Telefono = txtTelefono.Text;
                oCli.Email = txtEmail.Text;

                DateTime result;
                if (DateTime.TryParse(txtFechaRegistro.Text, out result))
                    oCli.Fecha_Registro = result;
                else
                {  
                    if (this.nuevo)
                        oCli.Fecha_Registro = DateTime.Now;
                    else
                        oCli.Fecha_Registro = DateTime.Parse("01/01/0001");
                }

                if (this.nuevo == true)
                { 
                    if (ExisteCliente() == false)
                    {
                        if (oClienteService.CrearCliente(oCli))
                        {
                            MessageBox.Show("Cliente grabado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Error al grabar el cliente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Nombre de cliente encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }      
                else
                {
                    if (oClienteService.ActualizarCliente(oCli))
                    {
                        MessageBox.Show("Cliente actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Error al actualizar el cliente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }   

//                this.dgvClientes.DataSource = oClienteService.ObtenerTodos();
                IList<Cliente> listcli = new List<Cliente>();
                listcli = oClienteService.ObtenerTodos();

//                dgvClientes.DataSource = oClienteService.ObtenerTodos();
                dgvClientes.DataSource = listcli;
                for (i = 0; i < dgvClientes.RowCount; i++)
                {
                    dgvClientes.Rows[i].Cells["Ciudad"].Value = listcli[i].Barrio.Ciudad;
                }

                this.habilitar(false);
            }
            else
            { 
                if (this.nuevo)
                { 
                    //this.habilitar(false);
                    this.nuevo = false;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de eliminar el cliente " + txtNomCliente.Text,
                                "ELIMINANDO",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Cliente oCli = new Cliente();
                oCli.ID_Cliente = int.Parse(txtId.Text);

// No hace falta cargar todos los datos del cliente
//                oCli.Nombre_Local = txtNomLocal.Text;
//                oCli.Nombre_Cliente = txtNomCliente.Text;

//                oCli.Tipo_Cliente = new Tipo_Cliente();
//                oCli.Tipo_Cliente.ID_TipoC = (int)cboTipo.SelectedValue;

//                oCli.Estado_Cliente = new Estado_Cliente();
//                oCli.Estado_Cliente.ID_EstadoC = (int)cboEstado.SelectedValue;
//                oCli.Domicilio_Calle = txtCalle.Text;
//                oCli.Domicilio_Numero = int.Parse(txtNumero.Text);

//                oCli.Barrio = new Barrio();
//                oCli.Barrio.ID_Barrio = (int)cboBarrio.SelectedValue;

//                oCli.Barrio.Ciudad = new Ciudad();
//                oCli.Barrio.Ciudad.ID_Ciudad = (int)cboCiudad.SelectedValue;

//                oCli.Telefono = txtTelefono.Text;
//                oCli.Email = txtEmail.Text;
//                oCli.Fecha_Registro = DateTime.Parse(txtFechaRegistro.Text);

                if (oClienteService.EliminarCliente(oCli))
                    MessageBox.Show("Cliente Eliminado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error al eliminar el cliente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //this.dgvClientes.DataSource = oClienteService.ObtenerTodos();
                IList<Cliente> listcli = new List<Cliente>();
                listcli = oClienteService.ObtenerTodos();

//                dgvClientes.DataSource = oClienteService.ObtenerTodos();
                dgvClientes.DataSource = listcli;
                for (int i = 0; i < dgvClientes.RowCount; i++)
                {
                    dgvClientes.Rows[i].Cells["Ciudad"].Value = listcli[i].Barrio.Ciudad;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.nuevo)
                this.limpiar();

            this.habilitar(false);
            this.nuevo = false;
            this.dgvClientes_SelectionChanged(null, null);
        }

        private void cboCiudad_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCiudad.SelectedValue != null)
                LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(cboCiudad.SelectedValue.ToString()), "Nombre", "ID_Barrio");
        }
    }
}
