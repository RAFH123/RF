using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Distribuidora.RF
{
    class Datos
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
//        private string cadenaConexion = @"Provider=SQLNCLI11;Data Source=MAQUIS;User ID=avisuales1;Initial Catalog=BD_bugs;Password=avisuales1";
//        private string cadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\31823\ProyectoNum\ProyectoNum\BD\BDUsuarios.mdb";
        private string cadenaConexion = @"Provider=SQLNCLI11;Data Source=ESCRITORIO10\SQLExpress;Integrated Security=SSPI;Initial Catalog=RF";

        private void conectar()
        {
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }
        private void desconectar()
        {
            conexion.Close();
        }
        public DataTable consultar(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            this.conectar();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            this.desconectar();
            return tabla;
        }

    }
}
