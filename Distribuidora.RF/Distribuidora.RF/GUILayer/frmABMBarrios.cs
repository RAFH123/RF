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
    public partial class frmABMBarrios : Form
    {
        private BarrioService oBarrioService;
        private CiudadService oCiudadService;

        bool nuevo = false;

        public frmABMBarrios()
        {
            InitializeComponent();
         
            oCiudadService = new CiudadService();
            oBarrioService = new BarrioService();
        }

        private void frmBarrios_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboCiudad, oCiudadService.ObtenerTodos(), "Nombre", "ID_Ciudad");

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvBarrios.AutoGenerateColumns = false;

            dgvBarrios.DataSource = oBarrioService.ObtenerTodos(string.Empty);

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
            cboCiudad.SelectedIndex = -1;
            txtNomBarrio.Clear();
        }
        private void habilitar(bool x)
        {
            txtNomBarrio.Enabled = x;
            cboCiudad.Enabled = x;

            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnEliminar.Enabled = !x;
            btnSalir.Enabled = !x;
            btnCancelar.Enabled = x;
            btnGrabar.Enabled = x;
        }

        private void actualizarCampos(int id)
        {
            Barrio oBa = new Barrio();
            oBa = oBarrioService.ConsultarBarriosPorId(id);

            if (oBa != null)
            { 
                txtId.Text = oBa.ID_Barrio.ToString();
                cboCiudad.SelectedValue = oBa.Ciudad.ID_Ciudad;
                txtNomBarrio.Text = oBa.Nombre;
            }
        }

        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtNomBarrio.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ingrese un nombre del barrio...");
                txtNomBarrio.Focus();
                return false;
            }
            if (cboCiudad.SelectedIndex < 0)
            {
                    MessageBox.Show("Ingrese la ciudad...");
                    cboCiudad.Focus();
                    return false;
            }
            return true;
        }

        private bool ExisteBarrio()
        {
            return oBarrioService.ObtenerBarrio(txtNomBarrio.Text) != null;
        }

        private void dgvBarrios_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos(Convert.ToInt32(dgvBarrios.CurrentRow.Cells[0].Value));
            this.habilitar(false);
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevo = true;
            this.limpiar();
            this.habilitar(true);
            this.txtNomBarrio.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.habilitar(true);
            this.nuevo = false;
            this.txtNomBarrio.Focus();
            this.btnCancelar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Barrio oBa = new Barrio();

                int i = 0;
                oBa.ID_Barrio = Int32.TryParse(txtId.Text, out i) ? i : 0;
                oBa.Nombre = txtNomBarrio.Text.Trim();

                oBa.Ciudad = new Ciudad();
                oBa.Ciudad.ID_Ciudad = cboCiudad.SelectedValue == null ? 0 : (int)cboCiudad.SelectedValue;

                if (this.nuevo == true)
                { 
                    if (ExisteBarrio() == false)
                    {
                        if (oBarrioService.CrearBarrio(oBa))
                            MessageBox.Show("Barrio grabado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Error al grabar el barrio!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Nombre de barrio encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }      
                else
                {
                    if (oBarrioService.ActualizarBarrio(oBa))
                    {
                        MessageBox.Show("Barrio actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                            MessageBox.Show("Error al actualizar el barrio!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvBarrios.DataSource = oBarrioService.ObtenerTodos(string.Empty);

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
            if (MessageBox.Show("Está seguro de eliminar el barrio " + txtNomBarrio.Text,
                                "ELIMINANDO",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Barrio oBa = new Barrio();
                // No hace falta cargar todos los datos del cliente
                oBa.ID_Barrio = int.Parse(txtId.Text);


                if (oBarrioService.EliminarBarrio(oBa))
                    MessageBox.Show("Barrio Eliminado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error al eliminar el barrio!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvBarrios.DataSource = oBarrioService.ObtenerTodos(string.Empty);
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
            this.dgvBarrios_SelectionChanged(null, null);
        }
    }
}
