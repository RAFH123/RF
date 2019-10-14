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
    public partial class frmFactura : Form
    {
        private ClienteService oClienteService;
        //private DireccionService oDireccionService;
        private ProductoService oProductoService;
        private TipoFacturaService oTipoFacturaService;
        private VentasService oVentasService;

        int stockArt = 0;
        Cliente oCli = new Cliente();
        
        public frmFactura()
        {
            InitializeComponent();
            oClienteService = new ClienteService();
            oProductoService = new ProductoService();
            oTipoFacturaService = new TipoFacturaService();
            oVentasService = new VentasService();
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            this.dtpFecha.Value = DateTime.Now;
            this.lblCUIT.Visible = false;
            this.txtCUIT.Visible = false;
            this.lblIVAInscr.Visible = false;
            this.txtIVAInscr.Visible = false;
            LlenarCombo(cboTipoFact, oTipoFacturaService.ObtenerTodos(), "Descripción", "Id_tipoFactura");
            LlenarCombo(cboCliente, oClienteService.ObtenerTodos(), "Nombre_Cliente", "ID_Cliente");
            LlenarCombo(_cboArticulo, oProductoService.ObtenerTodos(), "Nombre", "Id_producto");
            
            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvDetalle.AutoGenerateColumns = false;

            txtSubtotal.Text = "0";
            LimpiarDetalle();
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.ValueMember = value;
            cbo.DisplayMember = display;
            cbo.DataSource = source;
            cbo.SelectedIndex = -1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cboCliente.SelectedValue != null)
            {
                oCli = this.oClienteService.ConsultarClientesPorId((int)this.cboCliente.SelectedValue);
                this.txtDireccion.Text = oCli.Domicilio_Calle + " " + oCli.Domicilio_Numero + ", Bº " 
                                            + oCli.Barrio + ", " + oCli.Barrio.Ciudad;
                if (cboCondIVA.SelectedIndex >= 0 && ((cboCondIVA.SelectedItem.ToString() == "Responsable Inscripto") 
                    || (cboCondIVA.SelectedItem.ToString() == "Responsable Monotributo"))
                    && oCli.CUIT == string.Empty)
                {
                    MessageBox.Show("El cliente " + oCli.Nombre_Cliente + " no tiene número de CUIT cargado...");
                    cboCliente.SelectedIndex = -1;
                    cboCondIVA.SelectedIndex = -1;
                    txtDireccion.Text = "";
                    cboCliente.Focus();
                }
                this.txtCUIT.Text = oCli.CUIT;
            }
        }

        private void cboTipoFact_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (Convert.ToChar(this.cboTipoFact.SelectedValue))
            {
                case 'A':
                    this.txtNroFact.Text = oVentasService.ObtenerProximoNroFactura('A').ToString("0001-00000000");
                    HabilitarCamposFA();
                    RecalcularImporteT("A");
                    break;
                case 'B':
                    this.txtNroFact.Text = oVentasService.ObtenerProximoNroFactura('B').ToString("0001-00000000");
//                    this.cboCondIVA.Text = "Consumidor final";
                    this.cboCondIVA.SelectedIndex = 0;
                    this.cboCondIVA.Enabled = false;
                    HabilitarCamposFBC();
                    RecalcularImporteT(string.Empty);
                    break;
                case 'C':
                    this.txtNroFact.Text = oVentasService.ObtenerProximoNroFactura('C').ToString("0001-00000000");
                    this.cboCondIVA.SelectedIndex = -1;
                    this.cboCondIVA.Enabled = true;
                    HabilitarCamposFBC();
                    RecalcularImporteT(string.Empty);
                    break;
            }
        }
        private void HabilitarCamposFA()
        {
            this.cboCondIVA.SelectedIndex = 5;
            this.cboCondIVA.Enabled = false;
            this.lblCUIT.Visible = true;
            this.txtCUIT.Visible = true;
            this.txtCUIT.Enabled = true;
            this.txtCUIT.ReadOnly = true;
            this.txtCUIT.TabStop = false;
            this.lblIVAInscr.Visible = true;
            this.txtIVAInscr.Visible = true;
            this.txtIVAInscr.Enabled = true;
            this.txtIVAInscr.ReadOnly = true;
            this.txtIVAInscr.TabStop = false;
        }

        private void HabilitarCamposFBC()
        {
            this.lblCUIT.Visible = false;
            this.txtCUIT.Visible = false;
            this.lblIVAInscr.Visible = false;
            this.txtIVAInscr.Visible = false;
        }

        private void RecalcularImporteT(string TipoFactura)
        {
            string TFactura = TipoFactura;
            if (this.txtImporteTotal.Text != string.Empty)
            {
                if (TFactura == "A")
                {
                    decimal MontoNeto = Convert.ToDecimal(this.txtImporteNeto.Text);
                    decimal MontoIva = Convert.ToDecimal(this.txtIVAInscr.Text);
                    this.txtImporteTotal.Text = (MontoNeto + MontoIva).ToString();//Strings.Format(MontoNeto + MontoIva, "#,##0.00");
                }
                else
                {
                    this.txtImporteTotal.Text = this.txtImporteNeto.Text;
                }
            }
        }

        private void cboCondIVA_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex < 0)
                return;
            if (cboCondIVA.SelectedItem.ToString() == "Responsable Inscripto" 
                    || cboCondIVA.SelectedItem.ToString() == "Responsable Monotributo")
            {
                if (oCli.CUIT != string.Empty)
                { 
                    this.lblCUIT.Visible = true;
                    this.txtCUIT.Visible = true;
                    this.txtCUIT.Enabled = true;
                    this.txtCUIT.ReadOnly = true;
                    this.txtCUIT.TabStop = false;
                    txtCUIT.Text = oCli.CUIT;
                }
                else
                {
                    this.lblCUIT.Visible = false;
                    this.txtCUIT.Visible = false;
                    MessageBox.Show("El cliente " + oCli.Nombre_Cliente + " no tiene número de CUIT cargado...");
                    cboCondIVA.SelectedIndex = -1;
                    cboCondIVA.Focus();
                }
            }
            else
            {
                this.lblCUIT.Visible = false;
                this.txtCUIT.Visible = false;
            }
        }

        void LimpiarDetalle()
        {
            this._cboArticulo.Enabled = false;
            this._cboArticulo.SelectedIndex = -1;
            this._txtCantidad.Enabled = false;
            this._txtCantidad.Text = "";
            this._txtPrecio.Enabled = false;
            this._txtPrecio.Text = "0,00";
            this._txtImporte.Enabled = false;
            this._txtImporte.Text = "0,00";
            this._btnAgregar.Enabled = false;
            this._btnCancelar.Enabled = false;
            this._btnQuitar.Enabled = false;

            this._btnNuevo.Enabled = true;
        }

        void Deshabilitar_HabilitarDetalle(bool x)
        {
            this._cboArticulo.Enabled = x;
            this._txtCantidad.Enabled = x;
            this._txtPrecio.Enabled = x;
            this._txtImporte.Enabled = x;
        }

        private void _btnNuevo_Click(object sender, EventArgs e)
        {
            Deshabilitar_HabilitarDetalle(true);

            this._cboArticulo.SelectedIndex = -1;
            this._txtCantidad.Text = "";
            this._txtPrecio.Text = "0,00";
            this._txtImporte.Text = "0,00";
            this._cboArticulo.Focus();

            _btnCancelar.Enabled = true;
            _btnNuevo.Enabled = false;
            _btnQuitar.Enabled = false;
            _btnAgregar.Enabled = true;
            
        }

        private void _btnAgregar_Click(object sender, EventArgs e)
        {
            if(ValidarItem())
            {
                int idArt = (int) _cboArticulo.SelectedValue;
                this.dgvDetalle.Rows.Add((this.dgvDetalle.Rows.Count + 1), idArt, _cboArticulo.Text,
                                        _txtCantidad.Text, _txtPrecio.Text,
                                        (int.Parse(_txtCantidad.Text) * decimal.Parse(_txtPrecio.Text)));

                _btnNuevo.Enabled = true;
                _btnAgregar.Enabled = false;
                _btnCancelar.Enabled = false;
                _btnQuitar.Enabled = true;

                dgvDetalle.CurrentCell = dgvDetalle.Rows[dgvDetalle.Rows.Count - 1].Cells[0];
                dgvDetalle.Rows[dgvDetalle.Rows.Count - 1].Selected = true;
                dgvDetalle_SelectionChanged(null, null);

                CalcularImportesFactura();
            }
        }

        private bool ValidarItem()
        {
            if (_cboArticulo.SelectedIndex < 0)
            { 
                MessageBox.Show("Ingrese un artículo...");
                _cboArticulo.Focus();
                return false;
            } 
            else
            {
                if (_txtCantidad.Text.Length > 0 && int.Parse(_txtCantidad.Text) <= 0)
                {
                    MessageBox.Show("Ingrese la cantidad del artículo...");
                    _txtCantidad.Focus();
                    return false;
                }
                if((int.Parse(_txtCantidad.Text)) > stockArt)
                {
                    MessageBox.Show("El stock actual del artículo es : " + stockArt.ToString());
                    _txtCantidad.Focus();
                    return false;
                }

            }
            return true;
        }

        private void CalcularImportesFactura()
        {
            decimal subtotal = 0;
            int descuento = 0;
            for (int i = 0; i < dgvDetalle.Rows.Count; i++)
            {
                dgvDetalle.Rows[i].Cells[0].Value = i + 1;
                subtotal += decimal.Parse(dgvDetalle.Rows[i].Cells["Importe"].Value.ToString());
            }
            txtSubtotal.Text = subtotal.ToString();
            Int32.TryParse(txtDescuento.Text.Trim(), out descuento);
            decimal neto = Math.Round(subtotal - (subtotal * descuento / 100), 2);
            txtImporteNeto.Text = neto.ToString();
            txtIVAInscr.Text = Math.Round(neto * 21 / 100, 2).ToString();
            txtImporteTotal.Text = txtIVAInscr.Visible ? Math.Round((neto + (neto * 21 / 100)), 2).ToString() : neto.ToString();

        }
        private void _cboArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Producto oProd;
            oProd = oProductoService.ObtenerProductoPorId(int.Parse(_cboArticulo.SelectedValue.ToString()));

            if (oProd.Stock <= 0)
            {
                MessageBox.Show("El artículo " + _cboArticulo.SelectedText + " no tiene existencias...");
                _cboArticulo.SelectedIndex = -1;
                _txtPrecio.Text = "0";
                return;
            }

            if (dgvDetalle.Rows.Count > 0)
            {
                for (int i = 0; i < dgvDetalle.Rows.Count; i++)
                {
                    if (dgvDetalle.Rows[i].Cells["CodArt"].Value.ToString() == _cboArticulo.SelectedValue.ToString())
                    {
                        MessageBox.Show("El artículo " + _cboArticulo.SelectedText + " ya se ingresó en el Detalle...");
                        _cboArticulo.SelectedIndex = -1;
                        _txtPrecio.Text = "0";
                        return;
                    }
                }
            }

            _txtPrecio.Text = oProd.Precio.ToString();
            stockArt = oProd.Stock;

            _txtCantidad.Enabled = true;
            _txtCantidad.Text = "";
            _txtImporte.Text = "0,00";

            _btnCancelar.Enabled = true;
            _btnAgregar.Enabled = false;
        }

        private void _txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (_cboArticulo.SelectedIndex >= 0)
            { 
                Producto oProd;
                oProd = oProductoService.ObtenerProductoPorId(int.Parse(_cboArticulo.SelectedValue.ToString()));
                stockArt = oProd.Stock;

                if (_txtCantidad.Text.Length > 0 && (int.Parse(_txtCantidad.Text) > 0 && double.Parse(_txtPrecio.Text) > 0))
                { 
                    if ((int.Parse(_txtCantidad.Text)) > stockArt)
                    {
                        MessageBox.Show("El stock actual del artículo es : " + stockArt.ToString());
                        _txtCantidad.Text = stockArt.ToString();
                        _txtCantidad.Focus();
                    }
                    else
                        _txtImporte.Text = (int.Parse(_txtCantidad.Text) * double.Parse(_txtPrecio.Text)).ToString();
                }
            }
            _btnAgregar.Enabled = true;
            _btnNuevo.Enabled = false;
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarDetalle();
            dgvDetalle_SelectionChanged(null, null);
        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            Deshabilitar_HabilitarDetalle(false);

            if (dgvDetalle.CurrentRow != null)
            { 
                _cboArticulo.SelectedValue = dgvDetalle.CurrentRow.Cells["CodArt"].Value;
                _txtCantidad.Text = dgvDetalle.CurrentRow.Cells["Cantidad"].Value.ToString();
                _txtPrecio.Text = dgvDetalle.CurrentRow.Cells["Precio"].Value.ToString();
                _txtImporte.Text = dgvDetalle.CurrentRow.Cells["Importe"].Value.ToString();

                _btnNuevo.Enabled = true;
                _btnAgregar.Enabled = false;
                _btnQuitar.Enabled = true;
                _btnCancelar.Enabled = false;
            }
            else
            {
                _btnNuevo.Enabled = true;
                _btnAgregar.Enabled = false;
                _btnQuitar.Enabled = false;
                _btnCancelar.Enabled = false;
            
                _cboArticulo.SelectedIndex = -1;
                _txtCantidad.Text = "";
                _txtPrecio.Text = "0,00";
                _txtImporte.Text = "0,00";
            }

        }

        private void _btnQuitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de eliminar el articulo " + _cboArticulo.Text + "?",
                                "Eliminando",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (dgvDetalle.CurrentRow == null)
                    return;

                dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);

                if (dgvDetalle.Rows.Count > 0)
                {
                    CalcularImportesFactura();

                    dgvDetalle.CurrentCell = dgvDetalle.Rows[dgvDetalle.Rows.Count - 1].Cells[0];
                    dgvDetalle.Rows[dgvDetalle.Rows.Count - 1].Selected = true;
                }
                
                dgvDetalle_SelectionChanged(null, null);
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            int desc = 0;
            Int32.TryParse(txtDescuento.Text.Trim(), out desc);

            if (desc >=0 && desc <= 100)
            { 
                decimal subtotal = decimal.Parse(txtSubtotal.Text);
                decimal neto = Math.Round(subtotal - (subtotal * desc / 100), 2);
                txtImporteNeto.Text = neto.ToString();
                decimal iva = Math.Round(neto * 21 / 100, 2);
                txtIVAInscr.Text = iva.ToString();
                txtImporteTotal.Text = txtIVAInscr.Visible ? (neto + iva).ToString() : neto.ToString();
            }
            else
            {
                MessageBox.Show("Ingrese un número un número entre 0 y 100...");
                txtDescuento.Text = "0";
                txtDescuento.Focus();
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarFactura())
            {
                Ventas oVenta = new Ventas();
                oVenta.TipoFactura = new TipoFactura();
                oVenta.TipoFactura.Id_TipoFactura = Convert.ToChar(this.cboTipoFact.SelectedValue);
                oVenta.Fecha = dtpFecha.Value;
                oVenta.Cliente = new Cliente();
                oVenta.Cliente.ID_Cliente = (int)cboCliente.SelectedValue;
                oVenta.CondIVA = cboCondIVA.SelectedItem != null ? cboCondIVA.SelectedItem.ToString() : string.Empty;
                oVenta.CondVenta = cboCondVenta.SelectedItem != null ? cboCondVenta.SelectedItem.ToString() : string.Empty;
                oVenta.Subtotal = decimal.Parse(txtSubtotal.Text);
                oVenta.PorcDescuento = txtDescuento.Text == string.Empty ? 0 : int.Parse(txtDescuento.Text);
                oVenta.ImporteNeto = decimal.Parse(txtImporteNeto.Text);
                oVenta.ImporteTotal = decimal.Parse(txtImporteTotal.Text);

                List<ItemVenta> oDetalleVentas;
                oDetalleVentas = new List<ItemVenta>();
                for (int i = 0; i < dgvDetalle.Rows.Count; i++)
                {
                    ItemVenta oItemVenta = new ItemVenta();
                    oItemVenta.ProdDetalle = new Producto();
                    oItemVenta.NroItem = int.Parse(dgvDetalle.Rows[i].Cells["NroItem"].Value.ToString());
                    oItemVenta.ProdDetalle.Id_Producto = int.Parse(dgvDetalle.Rows[i].Cells["CodArt"].Value.ToString());
                    oItemVenta.Cantidad = int.Parse(dgvDetalle.Rows[i].Cells["Cantidad"].Value.ToString());
                    oItemVenta.Precio = decimal.Parse(dgvDetalle.Rows[i].Cells["Precio"].Value.ToString());
                    oItemVenta.Importe = decimal.Parse(dgvDetalle.Rows[i].Cells["Importe"].Value.ToString());
                    oDetalleVentas.Add(oItemVenta);
                }

                int nrofactcargada = oVentasService.CargarFactura(oVenta, oDetalleVentas);
                if (nrofactcargada > 0)
                    MessageBox.Show("Factura " + oVenta.TipoFactura.Id_TipoFactura + " Nro.: "
                                    + nrofactcargada.ToString("0001-00000000")
                                    + " cargada!.");
                else
                    MessageBox.Show("No pudo cargarse la factura...");

                btnGrabar.Enabled = false;

                _btnNuevo.Enabled = false;
                _btnQuitar.Enabled = false;
                _btnCancelar.Enabled = false;
                _btnAgregar.Enabled = false;

                cboTipoFact.Enabled = false;
                cboCliente.Enabled = false;
                cboCondIVA.Enabled = false;
                cboCondVenta.Enabled = false;
                txtDireccion.Enabled = false;
                txtCUIT.Enabled = false;
                dtpFecha.Enabled = false;
                txtNroFact.Enabled = false;
                dgvDetalle.Enabled = false;
                txtDescuento.Enabled = false;

            }
        }

        private bool ValidarFactura()
        {
            if (cboTipoFact.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un tipo de factura...");
                cboTipoFact.Focus();
                return false;
            }
            if (cboCliente.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un cliente...");
                cboCliente.Focus();
                return false;
            }
            if (Convert.ToChar(cboTipoFact.SelectedValue) == 'C' && cboCondIVA.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una condicion de IVA...");
                cboCondIVA.Focus();
                return false;
            }
            if (cboCondVenta.SelectedIndex < 0)
            {
                MessageBox.Show("Ingrese una condición de venta...");
                cboCondVenta.Focus();
                return false;
            }
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Ingrese al menos un ítem en el Detalle de la Factura...");
                _btnNuevo.Focus();
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!btnGrabar.Enabled)
            {
                LimpiarTodo();

                cboTipoFact.Enabled = true;
                cboCliente.Enabled = true;
                cboCondIVA.Enabled = true;
                cboCondVenta.Enabled = true;
                txtDireccion.Enabled = true;
                txtCUIT.Enabled = true;
                dtpFecha.Enabled = true;
                txtNroFact.Enabled = true;
                dgvDetalle.Enabled = true;
                txtDescuento.Enabled = true;

                return;
            }

            if (cboTipoFact.SelectedIndex >= 0 || cboCliente.SelectedIndex >= 0 || dgvDetalle.Rows.Count > 0)
            {
                if (MessageBox.Show("Está seguro de cancelar la carga de la factura?",
                                    "Cancelando",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    LimpiarTodo();
            }
        }

        void LimpiarTodo()
        {
            cboTipoFact.SelectedIndex = -1;
            txtNroFact.Text = string.Empty;
            cboCliente.SelectedIndex = -1;
            cboCondIVA.SelectedIndex = -1;
            cboCondVenta.SelectedIndex = -1;
            txtCUIT.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            dgvDetalle.Rows.Clear();
            LimpiarDetalle();

            txtSubtotal.Text = "0";
            txtDescuento.Text = "0";
            txtImporteNeto.Text = "0";
            txtIVAInscr.Text = "0";
            txtImporteTotal.Text = "0";

            _btnAgregar.Enabled = false;
            _btnNuevo.Enabled = true;
            _btnCancelar.Enabled = false;
            _btnQuitar.Enabled = false;

            btnGrabar.Enabled = true;
        }
    }
}
