using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;


namespace Distribuidora.RF.DataAccessLayer
{
    class ClienteDao
    {
        internal bool Create(Cliente oCli)
        {
            //CON PARAMETROS
            //string str_sql = "     INSERT INTO Usuarios (n_usuario, password, email, id_perfil, estado, borrado)" +
            //                 "     VALUES (@usuario, @password, @email, @id_perfil, 'S', 0)";

            // var parametros = new Dictionary<string, object>();
            //parametros.Add("n_usuario", oUsuario.NombreUsuario);
            //parametros.Add("password", oUsuario.Password);
            //parametros.Add("email", oUsuario.Email);
            //parametros.Add("id_perfil", oUsuario.Perfil.IdPerfil);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            //con parametros
            //return (DBHelper.GetDBHelper().EjecutarSQLConParametros(str_sql, parametros) == 1);

            //SIN PARAMETROS

            string str_sql = "INSERT INTO Clientes (nombre_local, nombre_cliente, domicilio_calle, domicilio_numero, " +
                                "telefono, email, fecha_registro, barrio, tipo_cliente, estado_cliente, borrado)" +
                            " VALUES (" +
                            "'" + oCli.Nombre_Local + "', " +
                            "'" + oCli.Nombre_Cliente + "', " +
                            "'" + oCli.Domicilio_Calle + "', " +
                            "'" + oCli.Domicilio_Numero + "', " +
                            "'" + oCli.Telefono + "', " +
                            "'" + oCli.Email + "', " +
                            "'" + oCli.Fecha_Registro.ToString("dd/MM/yyyy") + "', " +
                            "'" + oCli.Barrio.ID_Barrio + "', " +
                            "'" + oCli.Tipo_Cliente.ID_TipoC + "', " +
                            "'" + oCli.Estado_Cliente.ID_EstadoC + "', 0)";

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Update(Cliente oCli)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Clientes " +
                             "SET nombre_local = '" + oCli.Nombre_Local + "', " +
                             "nombre_cliente = '" + oCli.Nombre_Cliente + "', " +
                             "domicilio_calle = '" + oCli.Domicilio_Calle + "', " +
                             "domicilio_numero = '" + oCli.Domicilio_Numero + "', " +
                             "telefono = '" + oCli.Telefono + "', " +
                             "email = '" + oCli.Email + "', " +
                             "fecha_registro = '" + oCli.Fecha_Registro.ToString("dd/MM/yyyy") + "', " +
                             "barrio = '" + oCli.Barrio.ID_Barrio + "', " +
                            "tipo_cliente = '" + oCli.Tipo_Cliente.ID_TipoC + "', " +
                            "estado_cliente = '" + oCli.Estado_Cliente.ID_EstadoC + "', " +
                            "borrado = 0 WHERE id_cliente=" + oCli.ID_Cliente;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Eliminar(Cliente oCli)
        {
            string str_sql = "UPDATE Clientes " +
                             "SET borrado = 1 WHERE id_cliente = " + oCli.ID_Cliente;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }
        
        public Cliente GetClienteSinParametros(string nombreCliente)
        {
            //Construimos la consulta sql para buscar el cliente en la base de datos.
            String strSql = "SELECT C.id_cliente, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "E.id_estadoc, T.id_tipoc, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.borrado = 0 AND C.nombre_cliente = '" + nombreCliente + "'";

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingCliente(resultado.Rows[0]);
            }

            return null;
        }
        
        public IList<Cliente> GetAll()
        {
            List<Cliente> listadoClientes = new List<Cliente>();

//            var strSql = "SELECT id_cliente, nombre_cliente FROM Clientes WHERE borrado = 0";

            var strSql = "SELECT C.id_cliente, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "E.id_estadoc, T.id_tipoc, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.borrado = 0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            Cliente oCliente = new Cliente();
   
            foreach (DataRow row in resultadoConsulta.Rows)
            {
//                listadoClientes.Add(MappingClienteSimple(row));
                listadoClientes.Add(MappingCliente(row));
            }

            return listadoClientes;
        }

        public Cliente GetClienteById(int IDCliente)
        {
            var strSql = "SELECT C.id_cliente, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "E.id_estadoc, T.id_tipoc, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.borrado = 0 AND C.id_cliente = " + IDCliente.ToString();

            DataTable fila = DBHelper.GetDBHelper().ConsultaSQL(strSql);
            if (fila.Rows.Count > 0)
                //                return MappingCliente(DBHelper.GetDBHelper().ConsultaSQL(strSql).Rows[0]);
                return MappingCliente(fila.Rows[0]);
            else
                return null;
        }
        
        public IList<Cliente> GetClienteByFilters(Dictionary<string, object> parametros)
        {
            List<Cliente> listadoClientes = new List<Cliente>();

//            var strSql = "SELECT C.id_cliente, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
//                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, "
//                                        + "E.id_estadoc, E.descripcion AS estado, "
//                                        + "T.id_tipoc, T.descripcion AS tipo, C.fecha_registro, C.email "
//                                    + "FROM Clientes C "
//                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
//                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
//                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
//                                    + "WHERE C.borrado = 0 ";

            var strSql = "SELECT C.id_cliente, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, "
                                        + "E.id_estadoc, E.descripcion AS estado, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.id_tipoc, T.descripcion AS tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                        + "INNER JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                    + "WHERE C.borrado = 0 ";

            if (parametros.ContainsKey("fechaDesde") && parametros.ContainsKey("fechaHasta"))
                strSql += " AND (fecha_registro>=@fechaDesde AND fecha_registro<=@fechaHasta) ";
            if (parametros.ContainsKey("idBarrio"))
                strSql += " AND (B.id_barrio=@idBarrio) ";
            if (parametros.ContainsKey("estado"))
                strSql += " AND (E.id_estadoC=@estado) ";
            if (parametros.ContainsKey("tipo"))
                strSql += " AND (T.id_tipoC=@tipo) ";
            if (parametros.ContainsKey("id_cliente"))
                strSql += " AND (C.id_cliente=@id_cliente) ";
            if (parametros.ContainsKey("id_ciudad"))
                strSql += " AND (Ciu.id_ciudad=@id_ciudad) ";

            strSql += " ORDER BY C.nombre_cliente";

            var resultadoConsulta = (DataRowCollection)DBHelper.GetDBHelper().ConsultaSQLConParametros(strSql, parametros).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoClientes.Add(MappingCliente(row));
            }

            return listadoClientes;
        }

        public IList<Cliente> GetClienteByFiltersCondiciones(String condiciones)
        {
            List<Cliente> listadoClientes = new List<Cliente>();
            String sqlcondiciones = condiciones;

            var strSql = "SELECT C.id_cliente, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, C.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "T.descripcion AS tipo, C.fecha_registro, C.email, B.ciudad, Ciu.nombre AS nomciu "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.borrado = 0 ";

            strSql += sqlcondiciones;

            //sin parametros
            strSql += "ORDER BY C.nombre_cliente DESC";


            var resultadoConsulta = (DataRowCollection)DBHelper.GetDBHelper().ConsultaSQL(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoClientes.Add(MappingCliente(row));
            }

            return listadoClientes;
        }

        private Cliente MappingCliente(DataRow row)
        {
            Cliente oCliente = new Cliente();
            oCliente.ID_Cliente = Convert.ToInt32(row["id_cliente"].ToString());
            oCliente.Nombre_Local = row["nombre_local"].ToString();
            oCliente.Nombre_Cliente = row["nombre_cliente"].ToString();
            oCliente.Domicilio_Calle = row["domicilio_calle"].ToString();
            oCliente.Domicilio_Numero = Convert.ToInt32(row["domicilio_numero"].ToString());
            oCliente.Telefono = row["telefono"].ToString();
            oCliente.Email = row["email"].ToString();
            oCliente.Fecha_Registro = Convert.ToDateTime(row["fecha_registro"].ToString());

            oCliente.Barrio = new Barrio();
            oCliente.Barrio.ID_Barrio = Convert.ToInt32(row["id_barrio"].ToString());
            oCliente.Barrio.Nombre = row["barrio"].ToString();

            oCliente.Barrio.Ciudad = new Ciudad();
            oCliente.Barrio.Ciudad.ID_Ciudad = Convert.ToInt32(row["ciudad"].ToString());
            oCliente.Barrio.Ciudad.Nombre = row["nomciu"].ToString();

            oCliente.Tipo_Cliente = new Tipo_Cliente();
            oCliente.Tipo_Cliente.ID_TipoC = Convert.ToInt32(row["id_tipoc"].ToString());
            oCliente.Tipo_Cliente.Descripcion = row["tipo"].ToString();

            oCliente.Estado_Cliente = new Estado_Cliente();
            oCliente.Estado_Cliente.ID_EstadoC = Convert.ToInt32(row["id_estadoc"].ToString());
            oCliente.Estado_Cliente.Descripcion = row["estado"].ToString();

            return oCliente;
        }
//        private Cliente MappingClienteSimple(DataRow row)
//        {
//            Cliente oCliente = new Cliente();
//            oCliente.ID_Cliente = Convert.ToInt32(row["id_cliente"].ToString());
//            oCliente.Nombre_Cliente = row["nombre_cliente"].ToString();
//
//            return oCliente;
//        }
    }
}
