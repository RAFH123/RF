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
            Cliente oCli = new Cliente();
            if (this.cboCliente.SelectedValue != null)
            {
                oCli = this.oClienteService.ConsultarClientesPorId((int)this.cboCliente.SelectedValue);
                this.txtDireccion.Text = oCli.Domicilio_Calle + " " + oCli.Domicilio_Numero + ", Bº " + oCli.Barrio + ", " + oCli.Barrio.Ciudad;
                this.txtCUIT.Text = oCli.CUIT;
            }
        }

        private void cboTipoFact_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (this.cboTipoFact.SelectedValue.ToString())
            {
                case "65":
                    this.txtNroFact.Text = (oVentasService.ObtenerProximoNroFactura('A') + 1).ToString("0001-00000000");
                    HabilitarCamposFA();
                    RecalcularImporteT("A");
                    break;
                case "66":
                    this.txtNroFact.Text = (oVentasService.ObtenerProximoNroFactura('B') + 1).ToString("0001-00000000");
//                    this.cboCondIVA.Text = "Consumidor final";
                    this.cboCondIVA.SelectedIndex = 0;
                    this.cboCondIVA.Enabled = false;
                    HabilitarCamposFBC();
                    RecalcularImporteT(string.Empty);
                    break;
                case "67":
                    this.txtNroFact.Text = (oVentasService.ObtenerProximoNroFactura('C') + 1).ToString("0001-00000000");
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
            if ((this.cboCondIVA.SelectedItem.ToString() == "Responsable Inscripto") || (this.cboCondIVA.SelectedItem.ToString() == "Responsable Monotributo"))
            {
                this.lblCUIT.Visible = true;
                this.txtCUIT.Visible = true;
                this.txtCUIT.Enabled = true;
                this.txtCUIT.ReadOnly = true;
                this.txtCUIT.TabStop = false;
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
            this._cboArticulo.Select();

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
                this.dgvDetalle.Rows.Add((this.dgvDetalle.Rows.Count + 1), idArt, oProductoService.ObtenerProductoPorId(idArt), 
                                        _txtCantidad.Text, _txtPrecio.Text, 
                                        (int.Parse(_txtCantidad.Text) * decimal.Parse(_txtPrecio.Text)));

                _btnNuevo.Enabled = true;
                _btnAgregar.Enabled = false;
                _btnCancelar.Enabled = false;
                _btnQuitar.Enabled = true;

                dgvDetalle.FirstDisplayedScrollingRowIndex = dgvDetalle.Rows[dgvDetalle.Rows.Count - 1].Index;
                dgvDetalle.ClearSelection();
                dgvDetalle.Refresh();
                dgvDetalle.CurrentCell = dgvDetalle.Rows[dgvDetalle.Rows.Count - 1].Cells[0];
                dgvDetalle.Rows[dgvDetalle.Rows.Count - 1].Selected = true;
                dgvDetalle_SelectionChanged(null, null);

                decimal subtotal = 0;
                int descuento = 0;
                for (int i = 0; i < dgvDetalle.Rows.Count; i++ )
                { 
                        dgvDetalle.Rows[i].Cells[0].Value = i + 1;
                        subtotal += decimal.Parse(dgvDetalle.Rows[i].Cells["Importe"].Value.ToString());
                }
                txtSubtotal.Text = subtotal.ToString();
                Int32.TryParse(txtDescuento.Text.Trim(), out descuento);
                decimal neto = Math.Round(subtotal - (subtotal * descuento / 100), 2);
                txtImporteNeto.Text = neto.ToString();
                txtIVAInscr.Text = Math.Round(neto * 21 / 100, 2).ToString();
                txtImporteTotal.Text = txtIVAInscr.Enabled ? Math.Round((neto + (neto * 21 / 100)), 2).ToString() : neto.ToString();
            }
        }

        private bool ValidarItem()
        {
            if (_cboArticulo.SelectedIndex < 0)
            { 
                MessageBox.Show("Ingrese un artículo...");
                _cboArticulo.Select();
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
                    MessageBox.Show("El stock actual del artículo es :" + stockArt.ToString());
                    _txtCantidad.Focus();
                    return false;
                }

            }
            return true;
        }

        private void _cboArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Producto oProd;
            oProd = oProductoService.ObtenerProductoPorId(int.Parse(_cboArticulo.SelectedValue.ToString()));

            _txtPrecio.Text = oProd.Precio.ToString();
            stockArt = oProd.Stock;

            _txtCantidad.Enabled = true;
            _txtCantidad.Text = "";
            _txtImporte.Text = "0,00";

            this._btnCancelar.Enabled = true;
            _btnAgregar.Enabled = false;
        }

        private void _txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (_txtCantidad.Text.Length > 0 && (int.Parse(_txtCantidad.Text) > 0 && double.Parse(_txtPrecio.Text) > 0))
                _txtImporte.Text = (int.Parse(_txtCantidad.Text) * double.Parse(_txtPrecio.Text)).ToString();
            _btnAgregar.Enabled = true;
            _btnNuevo.Enabled = false;
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarDetalle();
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
                                "ELiminando",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (dgvDetalle.CurrentRow == null)
                    return;

                dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);

                if (dgvDetalle.Rows.Count > 0)
                {
                    decimal subtotal = 0;
                    int descuento = 0;
                    for (int i = 0; i < dgvDetalle.Rows.Count; i++ )
                    { 
                        dgvDetalle.Rows[i].Cells[0].Value = i + 1;
                        subtotal += decimal.Parse(dgvDetalle.Rows[i].Cells["Importe"].Value.ToString());
                    }
                    txtSubtotal.Text = subtotal.ToString();
                    Int32.TryParse(txtDescuento.Text.Trim(), out descuento);
                    decimal neto = Math.Round(subtotal - (subtotal * descuento / 100), 2);
                    txtImporteNeto.Text = neto.ToString();
                    txtIVAInscr.Text = Math.Round(neto * 21 / 100, 2).ToString();
                    txtImporteTotal.Text = txtIVAInscr.Enabled ? Math.Round((neto + (neto * 21 / 100)), 2).ToString() : neto.ToString();

                    dgvDetalle.FirstDisplayedScrollingRowIndex = dgvDetalle.Rows[dgvDetalle.Rows.Count - 1].Index;
                    dgvDetalle.ClearSelection();
                    dgvDetalle.Refresh();
                    dgvDetalle.CurrentCell = dgvDetalle.Rows[dgvDetalle.Rows.Count - 1].Cells[0];
                    dgvDetalle.Rows[dgvDetalle.Rows.Count - 1].Selected = true;
                }
                
                dgvDetalle_SelectionChanged(null, null);


                
            }
        }

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //dgvDetalle_SelectionChanged(null, null);
        }

        private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //dgvDetalle_SelectionChanged(null, null);
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            int desc = 0;
            decimal subtotal = decimal.Parse(txtSubtotal.Text);
            Int32.TryParse(txtDescuento.Text.Trim(), out desc);

            decimal neto = Math.Round(subtotal - (subtotal * desc / 100), 2);
            txtImporteNeto.Text = neto.ToString();
            decimal iva = Math.Round(neto * 21 / 100, 2);
            txtIVAInscr.Text = iva.ToString();
            txtImporteTotal.Text = txtIVAInscr.Enabled ? (neto + iva).ToString() : neto.ToString();


        }

    }
}
