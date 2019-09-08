﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using System.Data.OleDb;
using System.Data.SqlClient;

namespace Distribuidora.RF
{
    class Datos
    {
        private static Datos instance = new Datos();
        SqlConnection cnn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

//        private OleDbConnection conexion = new OleDbConnection();
//        private OleDbCommand comando = new OleDbCommand();
//        private string cadenaConexion = @"Provider=SQLNCLI11;Data Source=MAQUIS;User ID=avisuales1;Initial Catalog=BD_bugs;Password=avisuales1";
//        private string cadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\31823\ProyectoNum\ProyectoNum\BD\BDUsuarios.mdb";
//        private string cadenaConexion = @"Provider=SQLNCLI11;Data Source=ESCRITORIO10\SQLExpress;Integrated Security=SSPI;Initial Catalog=RF";

//        private string cadenaConexion = @"Provider=SQLNCLI11;Data Source=Ariel-PC\SQLExpress;Integrated Security=SSPI;Initial Catalog=Distribuidora_v1";
//        private string cadenaConexion = @"Provider=SQLNCLI11;Data Source=ESCRITORIO10\SQLExpress;Integrated Security=SSPI;Initial Catalog=Distribuidora_v1
//        private string cadenaConexion = @"Provider=SQLNCLI11;Data Source=Ariel-PC\SQLExpress;Integrated Security=SSPI;Initial Catalog=Distribuidora_v1";
        private string cadenaConexion = @"Data Source=ESCRITORIO10\SQLExpress;Initial Catalog=Distribuidora_v1;Integrated Security=True";

        public static Datos GetDatos()
        {
            if (instance == null)
                instance = new Datos();
            return instance;
        }

        private void conectar()
        {
            cnn.ConnectionString = cadenaConexion;
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
        }
        private void desconectar()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                cnn.Dispose();
            }
        }
        public DataTable consultar(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            this.conectar();
            cmd.CommandText = consultaSQL;
            tabla.Load(cmd.ExecuteReader());
            this.desconectar();
            return tabla;
        }

        /// Resumen:
        ///      Se utiliza para sentencias SQL del tipo “Select” con parámetros recibidos desde la interfaz
        ///      La función recibe por valor una sentencia sql como string y un diccionario de objetos como parámetros
        /// Devuelve:
        ///      un objeto de tipo DataTable con el resultado de la consulta
        /// Excepciones:
        ///      System.Data.SqlClient.SqlException:
        ///          El error de conexión se produce:
        ///              a) durante la apertura de la conexión
        ///              b) durante la ejecución del comando.
        public DataTable ConsultaSQLConParametros(string sqlStr, Dictionary<string, object> prs)
        {
            SqlConnection cnn2 = new SqlConnection();
            SqlCommand cmd2 = new SqlCommand();
            DataTable tabla = new DataTable();

            try
            {
                cnn2.ConnectionString = cadenaConexion;
                cnn2.Open();
                cmd2.Connection = cnn2;

                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = sqlStr;

                //Agregamos a la colección de parámetros del comando los filtros recibidos
                foreach (var item in prs)
                {
                    cmd2.Parameters.AddWithValue(item.Key, item.Value);
                }

                tabla.Load(cmd2.ExecuteReader());
                return tabla;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.desconectar();
            }
        }

    }
}
