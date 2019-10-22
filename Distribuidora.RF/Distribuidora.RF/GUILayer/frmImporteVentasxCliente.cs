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
    public partial class frmImporteVentasxCliente : Form
    {
        public frmImporteVentasxCliente()
        {
            InitializeComponent();
        }

        private void frmImporteVentasxCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dstVentasxClientes.csltVentasxClientes' Puede moverla o quitarla según sea necesario.
            this.csltVentasxClientesTableAdapter.Fill(this.dstVentasxClientes.csltVentasxClientes);

            this.reportViewer1.RefreshReport();
        }

        private void dstVentasxClientesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
