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
    public partial class frmABMTablasSimples : Form
    {
        private EntidadSimpleService oESimpleService;

        bool nuevo = false;
        string tabla;

        public frmABMTablasSimples(string t)
        {
            InitializeComponent();

            oESimpleService = new EntidadSimpleService();
            tabla = t;
        }

        private void frmABMTablasSimples_Load(object sender, EventArgs e)
        {
            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvTablaSimple.AutoGenerateColumns = false;

            dgvTablaSimple.DataSource = oESimpleService.ObtenerTodos(tabla);

            this.habilitar(false);
        }

        private void limpiar()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
        }
        private void habilitar(bool x)
        {
            txtDescripcion.Enabled = x;

            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnEliminar.Enabled = !x;
            btnSalir.Enabled = !x;
            btnCancelar.Enabled = x;
            btnGrabar.Enabled = x;
        }

        private void actualizarCampos(int id)
        {
            EntidadSimple oESimple = oESimpleService.ConsultarEntidadSimplePorId(id, tabla);

            if (oESimple != null)
            {
                txtCodigo.Text = oESimple.Codigo.ToString();
                txtDescripcion.Text = oESimple.Descripcion;
            }
        }

        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtDescripcion.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ingrese una descripcion...");
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }

        private bool ExisteEntidadSimple()
        {
            return oESimpleService.ObtenerEntidadSimple(txtDescripcion.Text, tabla) != null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevo = true;
            this.limpiar();
            this.habilitar(true);
            txtDescripcion.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.habilitar(true);
            this.nuevo = false;
            this.txtDescripcion.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                EntidadSimple oESimple = new EntidadSimple();

                int i = 0;
                oESimple.Codigo = Int32.TryParse(txtCodigo.Text, out i) ? i : 0;
                oESimple.Descripcion = txtDescripcion.Text;
                
                if (this.nuevo == true)
                {
                    if (ExisteEntidadSimple() == false)
                    {
                        if (oESimpleService.CrearEntidadSimple(oESimple, tabla))
                        {
                            MessageBox.Show("Registro grabado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Error al grabar el registro!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Descripcion encontrada!. Ingrese una descripcion diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (ExisteEntidadSimple() == false)
                    {
                        if (oESimpleService.ActualizarEntidadSimple(oESimple, tabla))
                        {
                            MessageBox.Show("Registro actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Error al actualizar el registro!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Descripcion encontrada!. Ingrese una descripcion diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.dgvTablaSimple.DataSource = oESimpleService.ObtenerTodos(tabla);

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.nuevo)
                this.limpiar();

            this.habilitar(false);
            this.nuevo = false;
            this.dgvTablaSimple_SelectionChanged(null, null);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de eliminar el registro " + txtDescripcion.Text,
                                "ELIMINANDO",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                EntidadSimple oESimple = new EntidadSimple();
                oESimple.Codigo = int.Parse(txtCodigo.Text);
                //oESimple.Tabla = tabla;

                if (oESimpleService.EliminarEntidadSimple(oESimple, tabla))
                    MessageBox.Show("Registro Eliminado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error al eliminar el registro!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvTablaSimple.DataSource = oESimpleService.ObtenerTodos(tabla);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTablaSimple_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos(Convert.ToInt32(dgvTablaSimple.CurrentRow.Cells[0].Value));
            this.habilitar(false);
        }
    }
}
