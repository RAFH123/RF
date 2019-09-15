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

namespace Distribuidora.RF.GUILayer
{
    public partial class frmLogin : Form
    {

        private readonly UsuarioService usuarioService;

        public string UsuarioLogueado { get; internal set; }
        public frmLogin()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

         private void frmLogin_Load(object sender, EventArgs e)
        {
            //Mostramos el formulario al centro del formulario padre.
            this.CenterToParent();
        }

         private void btnIngresar_Click(object sender, EventArgs e)
         {
             //Validamos que se haya ingresado un usuario.
             if ((txtUsuario.Text == ""))
             {
                 MessageBox.Show("Se debe ingresar un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
             }

             //Validamos que se haya ingresado una password
             if ((txtClave.Text == ""))
             {
                 MessageBox.Show("Se debe ingresar una contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
             }

             var usr = usuarioService.ValidarUsuario(txtUsuario.Text, txtClave.Text);
             //Controlamos que las creadenciales sean las correctas. 
             if (usr != null)
             {
                 // Login OK
                 UsuarioLogueado = usr.NombreUsuario;
                 this.Close();
             }
             else
             {
                 //Limpiamos el campo password, para que el usuario intente ingresar un usuario distinto.
                 txtClave.Text = "";
                 // Enfocamos el cursor en el campo password para que el usuario complete sus datos.
                 txtClave.Focus();
                 //Mostramos un mensaje indicando que el usuario/password es invalido.
                 MessageBox.Show("Debe ingresar usuario y/o contraseña válidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

         private void btnSalir_Click(object sender, EventArgs e)
         {
             // Terminamos la aplicacion dado que el usuario no inicio sesion.
             Environment.Exit(0);
         }

         private void button1_Click(object sender, EventArgs e)
         {
             MessageBox.Show("Lo sentimos. Aún no se puede registrarse");
         }

         private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == Convert.ToChar(Keys.Return))
                 this.btnIngresar.PerformClick();
         }

         private void frmLogin_Shown(object sender, EventArgs e)
         {
             txtUsuario.Focus();
         }
    }
}
