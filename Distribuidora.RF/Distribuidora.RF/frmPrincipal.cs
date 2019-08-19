using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distribuidora.RF
{
    public partial class frmPrincipal : Form
    {
        Usuarios usuarioActual;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin fl = new frmLogin();
            this.Visible = false;
            fl.ShowDialog();
            this.Visible = true;

            this.usuarioActual = fl.MiUsuario;
            if (this.usuarioActual.Id_usuario == 0)
                this.Close();
            else
                this.Text = this.Text + "    -     Usuario: " + this.usuarioActual.N_usuario;
            //            this.Text = this.Text + " Usuario: ";

            fl.Dispose();

        }
    }
}
