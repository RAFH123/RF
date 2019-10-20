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
    public partial class frmABMProveedores : Form
    {
        private ProveedorService oProveedorService;
        private Tipo_ProveedorService oTipoProveedorService;
        private Estado_ProveedorService oEstadoService;
        private CiudadService oCiudadService;
        private BarrioService oBarrioService;

        bool nuevo = false;

        public frmABMProveedores()
        {
            InitializeComponent();
         
            oProveedorService = new ProveedorService();
            oTipoProveedorService = new Tipo_ProveedorService();
            oEstadoService = new Estado_ProveedorService();
            oCiudadService = new CiudadService();
            oBarrioService = new BarrioService();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboCiudad, oCiudadService.ObtenerTodos(), "Nombre", "ID_Ciudad");
            LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(""), "Nombre", "ID_Barrio");
            LlenarCombo(cboEstado, oEstadoService.ObtenerTodos(), "Descripcion", "ID_EstadoP");
            LlenarCombo(cboTipo, oTipoProveedorService.ObtenerTodos(), "Descripcion", "ID_TipoP");

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvProveedores.AutoGenerateColumns = false;

            IList<Proveedor> listcli = new List<Proveedor>();
            listcli = oProveedorService.ObtenerTodos();

            dgvProveedores.DataSource = listcli;
            for (int i = 0; i < dgvProveedores.RowCount; i++)
            {
                dgvProveedores.Rows[i].Cells["Ciudad"].Value = listcli[i].Barrio.Ciudad;
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
            txtNomProveedor.Clear();
            cboTipo.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
            txtCalle.Clear();
            txtNumero.Clear();
            cboCiudad.SelectedIndex = -1;
            cboBarrio.SelectedIndex = -1;
            txtTelefono.Clear();
            txtCUIT.Clear();
            txtEmail.Clear();
            txtFechaRegistro.Clear();
            LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(""), "Nombre", "ID_Barrio");
        }
        private void habilitar(bool x)
        {
            txtNomLocal.Enabled = x;
            txtNomProveedor.Enabled = x;
            cboTipo.Enabled = x;
            cboEstado.Enabled = x;
            txtCalle.Enabled = x;
            txtNumero.Enabled = x;
            cboCiudad.Enabled = x;
            cboBarrio.Enabled = x;
            txtTelefono.Enabled = x;
            txtCUIT.Enabled = x;
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
            Proveedor oCli = new Proveedor();
            oCli = oProveedorService.ConsultarProveedoresPorId(id);

            if (oCli != null)
            { 
                txtId.Text = oCli.ID_Proveedor.ToString();
                txtNomLocal.Text = oCli.Nombre_Local;
                txtNomProveedor.Text = oCli.Nombre_Proveedor;
                cboTipo.SelectedValue = oCli.Tipo_Proveedor.ID_TipoP;
                cboEstado.SelectedValue = oCli.Estado_Proveedor.ID_EstadoP;
                txtCalle.Text = oCli.Domicilio_Calle;
                txtNumero.Text = oCli.Domicilio_Numero.ToString();
                cboCiudad.SelectedValue = oCli.Barrio.Ciudad.ID_Ciudad;

                if (cboCiudad.SelectedValue != null)
                    LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(cboCiudad.SelectedValue.ToString()), "Nombre", "ID_Barrio");
                else
                    LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(""), "Nombre", "ID_Barrio");
                cboBarrio.SelectedValue = oCli.Barrio.ID_Barrio;
                
                txtTelefono.Text = oCli.Telefono;
                txtCUIT.Text = oCli.CUIT;
                txtEmail.Text = oCli.Email;

                if (oCli.Fecha_Registro.ToString("dd/MM/yyyy") != "01/01/0001")
                    txtFechaRegistro.Text = oCli.Fecha_Registro.ToString("dd/MM/yyyy");
                else
                {  
                    txtFechaRegistro.Text = string.Empty;
                }
            }
        }

        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtNomProveedor.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ingrese un nombre de Proveedor...");
                txtNomProveedor.Focus();
                return false;
            }
            else
            { 
                if (txtCalle.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese la calle...");
                    txtCalle.Focus();
                    return false;
                }
                else
                { 
                    if (txtNumero.Text == string.Empty)
                    {
                        MessageBox.Show("Ingrese el número de la calle...");
                        txtNumero.Focus();
                        return false;
                    }
                    else
                        return true;
                }
            }

        }

        private bool ExisteProveedor()
        {
            return oProveedorService.ObtenerProveedor(txtNomProveedor.Text) != null;
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos(Convert.ToInt32(dgvProveedores.CurrentRow.Cells[0].Value));
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
            this.btnCancelar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Proveedor oCli = new Proveedor();

                int i = 0;
                oCli.ID_Proveedor = Int32.TryParse(txtId.Text, out i) ? i : 0;
                oCli.Nombre_Local = txtNomLocal.Text;
                oCli.Nombre_Proveedor = txtNomProveedor.Text;

                oCli.Tipo_Proveedor = new Tipo_Proveedor();
                oCli.Tipo_Proveedor.ID_TipoP = cboTipo.SelectedValue == null ? 0 : (int)cboTipo.SelectedValue;

                oCli.Estado_Proveedor = new Estado_Proveedor();
                oCli.Estado_Proveedor.ID_EstadoP = cboEstado.SelectedValue == null ? 0 : (int)cboEstado.SelectedValue;
                oCli.Domicilio_Calle = txtCalle.Text;
                oCli.Domicilio_Numero = Int32.TryParse(txtNumero.Text, out i) ? i : 0;

                oCli.Barrio = new Barrio();
                oCli.Barrio.ID_Barrio = cboBarrio.SelectedValue == null ? 0 : (int)cboBarrio.SelectedValue;

                oCli.Barrio.Ciudad = new Ciudad();
                oCli.Barrio.Ciudad.ID_Ciudad = cboCiudad.SelectedValue == null ? 0 : (int)cboCiudad.SelectedValue;

                oCli.Telefono = txtTelefono.Text;
                oCli.CUIT = txtCUIT.Text.Replace("-", "").Trim() == string.Empty ? string.Empty : txtCUIT.Text;
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
                    if (ExisteProveedor() == false)
                    {
                        if (oProveedorService.CrearProveedor(oCli))
                        {
                            MessageBox.Show("Proveedor grabado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Error al grabar el Proveedor!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Nombre de Proveedor encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }      
                else
                {
                    //if (ExisteProveedor() == false)
                    //{
                        if (oProveedorService.ActualizarProveedor(oCli))
                        {
                            MessageBox.Show("Proveedor actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Error al actualizar el Proveedor!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //    MessageBox.Show("Nombre de Proveedor encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                IList<Proveedor> listcli = new List<Proveedor>();
                listcli = oProveedorService.ObtenerTodos();

                dgvProveedores.DataSource = listcli;
                for (i = 0; i < dgvProveedores.RowCount; i++)
                {
                    dgvProveedores.Rows[i].Cells["Ciudad"].Value = listcli[i].Barrio.Ciudad;
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
            if (MessageBox.Show("Está seguro de eliminar el Proveedor " + txtNomProveedor.Text,
                                "ELIMINANDO",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Proveedor oCli = new Proveedor();
                // No hace falta cargar todos los datos del Proveedor
                oCli.ID_Proveedor = int.Parse(txtId.Text);


                if (oProveedorService.EliminarProveedor(oCli))
                    MessageBox.Show("Proveedor Eliminado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error al eliminar el Proveedor!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //this.dgvProveedores.DataSource = oProveedoreservice.ObtenerTodos();
                IList<Proveedor> listcli = new List<Proveedor>();
                listcli = oProveedorService.ObtenerTodos();

//                dgvProveedores.DataSource = oProveedoreservice.ObtenerTodos();
                dgvProveedores.DataSource = listcli;
                for (int i = 0; i < dgvProveedores.RowCount; i++)
                {
                    dgvProveedores.Rows[i].Cells["Ciudad"].Value = listcli[i].Barrio.Ciudad;
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
            this.dgvProveedores_SelectionChanged(null, null);
        }

        private void cboCiudad_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCiudad.SelectedValue != null)
                LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(cboCiudad.SelectedValue.ToString()), "Nombre", "ID_Barrio");
        }
    }
}
