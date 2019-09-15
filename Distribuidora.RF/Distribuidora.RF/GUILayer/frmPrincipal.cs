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
            login.ShowDialog();
//            lblUsuarioLogueado.Text = login.UsuarioLogueado;
            
//            frmLogin fl = new frmLogin();
//            this.Visible = false;
//            fl.ShowDialog();
//            this.Visible = true;
//
//            this.usuarioActual = fl.MiUsuario;
//            if (this.usuarioActual.Id_usuario == 0)
//                this.Close();
//            else
//                this.Text = this.Text + "    -     Usuario: " + this.usuarioActual.N_usuario;
//            //            this.Text = this.Text + " Usuario: ";

//            fl.Dispose();
            this.Text = this.Text + "  - Usuario: " + login.UsuarioLogueado;

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frmC = new frmClientes();
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
    }
}
