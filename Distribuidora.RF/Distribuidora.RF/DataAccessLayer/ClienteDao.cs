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
        public Cliente GetClienteById(int IDCliente)
        {
            var strSql = "SELECT C.id_cliente, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.borrado = 0 AND C.id.cliente = " + IDCliente.ToString();
            return MappingCliente(DBHelper.GetDBHelper().ConsultaSQL(strSql).Rows[0]);
        }
        
        public IList<Cliente> GetClienteByFilters(Dictionary<string, object> parametros)
        {
            List<Cliente> listadoClientes = new List<Cliente>();

            var strSql = "SELECT C.id_cliente, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.borrado = 0 ";

            if (parametros.ContainsKey("fechaDesde") && parametros.ContainsKey("fechaHasta"))
                strSql += " AND (fecha_registro>=@fechaDesde AND fecha_registro<=@fechaHasta) ";
            if (parametros.ContainsKey("idBarrio"))
                strSql += " AND (B.id_barrio=@idBarrio) ";
            if (parametros.ContainsKey("idEstadoCliente"))
                strSql += " AND (E.id_estadoC=@idEstadoCliente) ";
            if (parametros.ContainsKey("idTipoCliente"))
                strSql += " AND (T.id_tipoC=@idTipoCliente) ";
            strSql += " ORDER BY C.nombre_cliente DESC";

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
                                        + "C.domicilio_numero, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
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
            oCliente.Barrio.Nombre = row["nombre"].ToString();

            oCliente.Tipo_Cliente = new Tipo_Cliente();
            oCliente.Tipo_Cliente.ID_TipoC = Convert.ToInt32(row["id_tipoc"].ToString());
            oCliente.Tipo_Cliente.Descripcion = row["descripciont"].ToString();

            oCliente.Estado_Cliente = new Estado_Cliente();
            oCliente.Estado_Cliente.ID_EstadoC = Convert.ToInt32(row["id_estadoc"].ToString());
            oCliente.Estado_Cliente.Descripcion = row["descripcione"].ToString();

            return oCliente;
        }
    }
}
