using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distribuidora.RF.GUILayer
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            frmLogin login = new frmLogin();

            this.Visible = false;
            login.ShowDialog();
            this.Visible = true;

            this.Text = this.Text + "  - Usuario: " + login.UsuarioLogueado;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMClientes frmC = new frmABMClientes();
            frmC.ShowDialog();
        }

        private void buscarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscarClientes frmC = new frmBuscarClientes();
            frmC.ShowDialog();            
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rpta;
            rpta = MessageBox.Show("Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.No)
                e.Cancel = true;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frmDetalle = new frmUsuarios();
            frmDetalle.ShowDialog();
        }

        private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactura ofrmFactura = new frmFactura();
            ofrmFactura.ShowDialog();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMTablasSimples ofrmTablaSimple = new frmABMTablasSimples("Categorias");
            ofrmTablaSimple.ShowDialog();
        }

        private void ciudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMTablasSimples ofrmTablaSimple = new frmABMTablasSimples("Ciudades");
            ofrmTablaSimple.ShowDialog();
        }

        private void estadosClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMTablasSimples ofrmTablaSimple = new frmABMTablasSimples("EstadoCliente");
            ofrmTablaSimple.ShowDialog();
        }

        private void estadosProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMTablasSimples ofrmTablaSimple = new frmABMTablasSimples("EstadoProducto");
            ofrmTablaSimple.ShowDialog();
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMTablasSimples ofrmTablaSimple = new frmABMTablasSimples("Perfiles");
            ofrmTablaSimple.ShowDialog();
        }

        private void tiposClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMTablasSimples ofrmTablaSimple = new frmABMTablasSimples("TipoCliente");
            ofrmTablaSimple.ShowDialog();
        }
    }
}
