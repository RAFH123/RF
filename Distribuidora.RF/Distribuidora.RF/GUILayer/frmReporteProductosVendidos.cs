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
    public partial class frmReporteProductosVendidos : Form
    {
        public frmReporteProductosVendidos()
        {
            InitializeComponent();
        }

        private void frmReporteProductosVendidos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dstProdVendidos.ProdVendidos' Puede moverla o quitarla según sea necesario.
            this.prodVendidosTableAdapter.Fill(this.dstProdVendidos.ProdVendidos);

            this.reportViewer1.RefreshReport();
        }
    }
}
