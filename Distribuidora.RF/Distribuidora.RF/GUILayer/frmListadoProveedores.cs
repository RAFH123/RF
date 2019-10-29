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
    public partial class frmListadoProveedores : Form
    {
        public frmListadoProveedores()
        {
            InitializeComponent();
        }

        private void frmListadoProveedores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dstProveedores.Proveedores' Puede moverla o quitarla según sea necesario.
            this.proveedoresTableAdapter.Fill(this.dstProveedores.Proveedores);

            this.reportViewer1.RefreshReport();
        }
    }
}
