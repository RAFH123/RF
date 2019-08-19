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
    public partial class frmLogin : Form
    {

        Usuarios miUsuario = new Usuarios();

        internal Usuarios MiUsuario
        {
            get { return miUsuario; }
            set { miUsuario = value; }
        }

        public frmLogin()
        {
            InitializeComponent();
        }

         private void frmLogin_Load(object sender, EventArgs e)
        {

        }

         private void btnIngresar_Click(object sender, EventArgs e)
         {
             miUsuario.N_usuario = txtUsuario.Text;
             miUsuario.Password = txtClave.Text;


             miUsuario.Id_usuario = miUsuario.validarUsuario(miUsuario.N_usuario, miUsuario.Password);
             if (miUsuario.Id_usuario == 0)
             {
                 MessageBox.Show("Usuario no válido...");
                 txtUsuario.Text = "";
                 txtClave.Clear();
                 txtUsuario.Focus();
             }
             else
             {
                 this.Close();
             }

         }

         private void btnSalir_Click(object sender, EventArgs e)
         {
             this.Close();
         }
    }
}
