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
    public partial class frmABMProductos : Form
    {
        private ProductoService oProductoService;
        private CategoriaService oCategoriaService;
        private ProveedorService oProveedorService;

        bool nuevo = false;

        public frmABMProductos()
        {
            InitializeComponent();
         
            oProductoService = new ProductoService();
            oCategoriaService = new CategoriaService();
            oProveedorService = new ProveedorService();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboProveedor, oProveedorService.ObtenerTodos(), "Nombre_Proveedor", "ID_Proveedor");
            LlenarCombo(cboCategoria, oCategoriaService.ObtenerTodos(), "Descripcion", "ID_Categoria");

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvProductos.AutoGenerateColumns = false;

            dgvProductos.DataSource = oProductoService.ObtenerTodos();

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
            txtUnidad.Clear();
            txtNomProducto.Clear();
            cboCategoria.SelectedIndex = -1;
            cboProveedor.SelectedIndex = -1;
            txtPrecio.Clear();
            txtStock.Clear();
            txtFechaRegistro.Clear();
        }
        private void habilitar(bool x)
        {
            txtUnidad.Enabled = x;
            txtNomProducto.Enabled = x;
            cboCategoria.Enabled = x;
            cboProveedor.Enabled = x;
            txtPrecio.Enabled = x;
            txtStock.Enabled = x;
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
            Producto oProd = new Producto();
            oProd = oProductoService.ObtenerProductoPorId(id);

            if (oProd != null)
            { 
                txtId.Text = oProd.ID_Producto.ToString();
                txtUnidad.Text = oProd.Unidad;
                txtNomProducto.Text = oProd.Nombre;
                cboCategoria.SelectedValue = oProd.Categoria.ID_Categoria;
                cboProveedor.SelectedValue = oProd.Proveedor.ID_Proveedor;
                txtPrecio.Text = oProd.Precio.ToString();
                txtStock.Text = oProd.Stock.ToString();

                if (oProd.Fecha_Registro.ToString("dd/MM/yyyy") != "01/01/0001")
                    txtFechaRegistro.Text = oProd.Fecha_Registro.ToString("dd/MM/yyyy");
                else
                {  
                    txtFechaRegistro.Text = string.Empty;
                }
            }
        }

        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtNomProducto.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ingrese un nombre de Producto...");
                txtNomProducto.Focus();
                return false;
            }
            if (txtPrecio.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un precio...");
                txtPrecio.Focus();
                return false;
            }
            if (txtStock.Text == string.Empty)
            {
                MessageBox.Show("Ingrese el stock...");
                txtStock.Focus();
                return false;
            }
            return true;
        }

        private bool ExisteProducto()
        {
            return oProductoService.ObtenerProducto(txtNomProducto.Text) != null;
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
            this.habilitar(false);
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevo = true;
            this.limpiar();
            this.habilitar(true);
            txtFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtNomProducto.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.habilitar(true);
            this.nuevo = false;
            this.txtNomProducto.Focus();
            this.btnCancelar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Producto oProd = new Producto();

                int i = 0;
                oProd.ID_Producto = Int32.TryParse(txtId.Text, out i) ? i : 0;
                oProd.Nombre = txtNomProducto.Text;
                oProd.Unidad = txtUnidad.Text;

                oProd.Categoria = new Categoria();
                oProd.Categoria.ID_Categoria = cboCategoria.SelectedValue == null ? 0 : (int)cboCategoria.SelectedValue;

                oProd.Proveedor = new Proveedor();
                oProd.Proveedor.ID_Proveedor = cboProveedor.SelectedValue == null ? 0 : (int)cboProveedor.SelectedValue;

                double d;
                oProd.Precio = Double.TryParse(txtPrecio.Text, out d) ? d : 0;
                oProd.Stock = Int32.TryParse(txtStock.Text, out i) ? i : 0;

                DateTime result;
                if (DateTime.TryParse(txtFechaRegistro.Text, out result))
                    oProd.Fecha_Registro = result;
                else
                {  
                    if (this.nuevo)
                        oProd.Fecha_Registro = DateTime.Now;
                    else
                        oProd.Fecha_Registro = DateTime.Parse("01/01/0001");
                }

                if (this.nuevo == true)
                { 
                    if (ExisteProducto() == false)
                    {
                        if (oProductoService.CrearProducto(oProd))
                        {
                            MessageBox.Show("Producto grabado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Error al grabar el Producto!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Nombre de Producto encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }      
                else
                {
                    //if (ExisteProducto() == false)
                    //{
                        if (oProductoService.ActualizarProducto(oProd))
                        {
                            MessageBox.Show("Producto actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Error al actualizar el Producto!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //    MessageBox.Show("Nombre de Producto encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvProductos.DataSource = oProductoService.ObtenerTodos();

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
            if (MessageBox.Show("Está seguro de eliminar el Producto " + txtNomProducto.Text,
                                "ELIMINANDO",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Producto oProd = new Producto();
                // No hace falta cargar todos los datos del Producto
                oProd.ID_Producto = int.Parse(txtId.Text);


                if (oProductoService.EliminarProducto(oProd))
                    MessageBox.Show("Producto Eliminado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error al eliminar el Producto!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvProductos.DataSource = oProductoService.ObtenerTodos();
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
            this.dgvProductos_SelectionChanged(null, null);
        }
    }
}
