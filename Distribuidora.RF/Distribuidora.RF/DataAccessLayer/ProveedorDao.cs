using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;


namespace Distribuidora.RF.DataAccessLayer
{
    class ProveedorDao
    {
        internal bool Create(Proveedor oCli)
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

            string nomlocal, cuit, tel, email, fecreg, barrio, tipop, estadop;
            nomlocal = oCli.Nombre_Local.Trim() == string.Empty ? "NULL" : ("'" + oCli.Nombre_Local + "'");
            cuit = oCli.CUIT.Trim() == string.Empty ? "NULL" : ("'" + oCli.CUIT + "'");
            tel = oCli.Telefono.Trim() == string.Empty ? "NULL" : ("'" + oCli.Telefono + "'");
            email = oCli.Email.Trim() == string.Empty ? "NULL" : ("'" + oCli.Email + "'");
            if (oCli.Fecha_Registro.ToString("dd/MM/yyyy") != "01/01/0001")
                fecreg = "'" + oCli.Fecha_Registro.ToString("dd/MM/yyyy") + "'";
            else
                fecreg = "NULL";
            barrio = oCli.Barrio.ID_Barrio == 0 ? "NULL" : oCli.Barrio.ID_Barrio.ToString();
            tipop = oCli.Tipo_Proveedor.ID_TipoP == 0 ? "NULL" : oCli.Tipo_Proveedor.ID_TipoP.ToString();
            estadop = oCli.Estado_Proveedor.ID_EstadoP == 0 ? "NULL" : oCli.Estado_Proveedor.ID_EstadoP.ToString();

            string str_sql = "INSERT INTO Proveedores (nombre_local, nombre_Proveedor, domicilio_calle, domicilio_numero, " +
                                "cuit, telefono, email, fecha_registro, barrio, tipo_Proveedor, estado_Proveedor, borrado)" +
                            " VALUES (" +
                            nomlocal + ", " +
                            "'" + oCli.Nombre_Proveedor + "', " +
                            "'" + oCli.Domicilio_Calle + "', " +
                            "'" + oCli.Domicilio_Numero + "', " +
                            cuit + ", " +
                            tel + ", " +
                            email + ", " +
                            fecreg + ", " +
                            barrio + ", " +
                            tipop + ", " +
                            estadop + ", 0)";

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Update(Proveedor oCli)
        {
            //SIN PARAMETROS

            string nomlocal, cuit, tel, email, fecreg, barrio, tipop, estadop;
            nomlocal = oCli.Nombre_Local.Trim() == string.Empty ? "NULL" : ("'" + oCli.Nombre_Local + "'");
            cuit = oCli.CUIT.Trim() == string.Empty ? "NULL" : ("'" + oCli.CUIT + "'");
            tel = oCli.Telefono.Trim() == string.Empty ? "NULL" : ("'" + oCli.Telefono + "'");
            email = oCli.Email.Trim() == string.Empty ? "NULL" : ("'" + oCli.Email + "'");
            if (oCli.Fecha_Registro.ToString("dd/MM/yyyy") != "01/01/0001")
                fecreg = "'" + oCli.Fecha_Registro.ToString("dd/MM/yyyy") + "'";
            else
                fecreg = "NULL";
            barrio = oCli.Barrio.ID_Barrio == 0 ? "NULL" : oCli.Barrio.ID_Barrio.ToString();
            tipop = oCli.Tipo_Proveedor.ID_TipoP == 0 ? "NULL" : oCli.Tipo_Proveedor.ID_TipoP.ToString();
            estadop = oCli.Estado_Proveedor.ID_EstadoP == 0 ? "NULL" : oCli.Estado_Proveedor.ID_EstadoP.ToString();
 
            string str_sql = "UPDATE Proveedores " +
                             "SET nombre_local = " + nomlocal + ", " +
                             "nombre_Proveedor = '" + oCli.Nombre_Proveedor + "', " +
                             "domicilio_calle = '" + oCli.Domicilio_Calle + "', " +
                             "domicilio_numero = '" + oCli.Domicilio_Numero + "', " +
                             "cuit = " + cuit + ", " +
                             "telefono = " + tel + ", " +
                             "email = " + email + ", " +
                             "fecha_registro = " + fecreg + ", " +
                             "barrio = " + barrio + ", " +
                            "tipo_Proveedor = " + tipop + ", " +
                            "estado_Proveedor = " + estadop + ", " +
                            "borrado = 0 WHERE id_Proveedor = " + oCli.ID_Proveedor;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Eliminar(Proveedor oCli)
        {
            string str_sql = "UPDATE Proveedores " +
                             "SET borrado = 1 WHERE id_Proveedor = " + oCli.ID_Proveedor;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }
        
        public Proveedor GetProveedorSinParametros(string nombreProveedor)
        {
            //Construimos la consulta sql para buscar el Proveedor en la base de datos.
            String strSql = "SELECT C.id_Proveedor, C.cuit, C.nombre_local, C.nombre_Proveedor, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "E.id_estadop, T.id_tipop, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Proveedores C "
                                        + "FULL JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "FULL JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "FULL JOIN EstadoProveedor E ON E.id_estadop = C.estado_Proveedor "
                                        + "FULL JOIN TipoProveedor T ON T.id_tipop = C.tipo_Proveedor "
                                    + "WHERE C.borrado = 0 AND C.nombre_Proveedor = '" + nombreProveedor + "'";

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingProveedor(resultado.Rows[0]);
            }

            return null;
        }
        
        public IList<Proveedor> GetAll()
        {
            List<Proveedor> listadoProveedores = new List<Proveedor>();

            var strSql = "SELECT C.id_Proveedor, C.cuit, C.nombre_local, C.nombre_Proveedor, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "E.id_estadop, T.id_tipop, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Proveedores C "
                                        + "FULL JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "FULL JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "FULL JOIN EstadoProveedor E ON E.id_estadop = C.estado_proveedor "
                                        + "FULL JOIN TipoProveedor T ON T.id_tipop = C.tipo_Proveedor "
                                    + "WHERE C.borrado = 0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            Proveedor oProveedor = new Proveedor();
   
            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoProveedores.Add(MappingProveedor(row));
            }

            return listadoProveedores;
        }

        public Proveedor GetProveedorById(int IDProveedor)
        {
            var strSql = "SELECT C.id_Proveedor, C.cuit, C.nombre_local, C.nombre_Proveedor, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "E.id_estadop, T.id_tipop, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Proveedores C "
                                        + "FULL JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "FULL JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "FULL JOIN EstadoProveedor E ON E.id_estadop = C.estado_proveedor "
                                        + "FULL JOIN TipoProveedor T ON T.id_tipop = C.tipo_proveedor "
                                    + "WHERE C.borrado = 0 AND C.id_Proveedor = " + IDProveedor.ToString();

            DataTable fila = DBHelper.GetDBHelper().ConsultaSQL(strSql);
            if (fila.Rows.Count > 0)
                return MappingProveedor(fila.Rows[0]);
            else
                return null;
        }
        
        public IList<Proveedor> GetProveedorByFilters(Dictionary<string, object> parametros)
        {
            List<Proveedor> listadoProveedores = new List<Proveedor>();

            var strSql = "SELECT C.id_Proveedor, C.cuit, C.nombre_local, C.nombre_Proveedor, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, "
                                        + "E.id_estadop, E.descripcion AS estado, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.id_tipop, T.descripcion AS tipo, C.fecha_registro, C.email "
                                    + "FROM Proveedores C "
                                        + "FULL JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "FULL JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "FULL JOIN EstadoProveedor E ON E.id_estadop = C.estado_Proveedor "
                                        + "FULL JOIN TipoProveedor T ON T.id_tipop = C.tipo_Proveedor "
                                    + "WHERE C.borrado = 0 ";

            if (parametros.ContainsKey("fechaDesde") && parametros.ContainsKey("fechaHasta"))
                strSql += " AND (fecha_registro>=@fechaDesde AND fecha_registro<=@fechaHasta) ";
            if (parametros.ContainsKey("idBarrio"))
                strSql += " AND (B.id_barrio=@idBarrio) ";
            if (parametros.ContainsKey("estado"))
                strSql += " AND (E.id_estadop=@estado) ";
            if (parametros.ContainsKey("tipo"))
                strSql += " AND (T.id_tipop=@tipo) ";
            if (parametros.ContainsKey("id_Proveedor"))
                strSql += " AND (C.id_Proveedor=@id_Proveedor) ";
            if (parametros.ContainsKey("id_ciudad"))
                strSql += " AND (Ciu.id_ciudad=@id_ciudad) ";

            strSql += " ORDER BY C.nombre_Proveedor";

            var resultadoConsulta = (DataRowCollection)DBHelper.GetDBHelper().ConsultaSQLConParametros(strSql, parametros).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoProveedores.Add(MappingProveedor(row));
            }

            return listadoProveedores;
        }

        public IList<Proveedor> GetProveedorByFiltersCondiciones(String condiciones)
        {
            List<Proveedor> listadoProveedores = new List<Proveedor>();
            String sqlcondiciones = condiciones;

            var strSql = "SELECT C.id_Proveedor, C.cuit, C.nombre_local, C.nombre_Proveedor, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, C.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "T.descripcion AS tipo, C.fecha_registro, C.email, B.ciudad, Ciu.nombre AS nomciu "
                                    + "FROM Proveedores C "
                                        + "FULL JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "FULL JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "FULL JOIN EstadoProveedor E ON E.id_estadop = C.estado_Proveedor "
                                        + "FULL JOIN TipoProveedor T ON T.id_tipop = C.tipo_Proveedor "
                                    + "WHERE C.borrado = 0 ";

            strSql += sqlcondiciones;

            //sin parametros
            strSql += "ORDER BY C.nombre_Proveedor DESC";

            var resultadoConsulta = (DataRowCollection)DBHelper.GetDBHelper().ConsultaSQL(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoProveedores.Add(MappingProveedor(row));
            }

            return listadoProveedores;
        }

        private Proveedor MappingProveedor(DataRow row)
        {
            Proveedor oProveedor = new Proveedor();
            oProveedor.ID_Proveedor = Convert.ToInt32(row["id_Proveedor"].ToString());
            oProveedor.CUIT = row["cuit"].ToString();
            oProveedor.Nombre_Local = row["nombre_local"].ToString();
            oProveedor.Nombre_Proveedor = row["nombre_Proveedor"].ToString();
            oProveedor.Domicilio_Calle = row["domicilio_calle"].ToString();
            oProveedor.Domicilio_Numero = Convert.ToInt32(row["domicilio_numero"].ToString());
            oProveedor.Telefono = row["telefono"].ToString();
            oProveedor.Email = row["email"].ToString();

            //oProveedor.Fecha_Registro = Convert.ToDateTime(row["fecha_registro"].ToString());
            //string fecha_nula = "00/00/0000";
            DateTime result = new DateTime(1900,1,1,0,0,0);
            if (DateTime.TryParse(row["fecha_registro"].ToString(), out result))
                oProveedor.Fecha_Registro = result;

            oProveedor.Barrio = new Barrio();
            //oProveedor.Barrio.ID_Barrio = Convert.ToInt32(row["id_barrio"].ToString());
            int i = 0;
            oProveedor.Barrio.ID_Barrio = Int32.TryParse(row["id_barrio"].ToString(), out i) ? i : 0;
            oProveedor.Barrio.Nombre = row["barrio"].ToString();

            oProveedor.Barrio.Ciudad = new Ciudad();
//            oProveedor.Barrio.Ciudad.ID_Ciudad = Convert.ToInt32(row["ciudad"].ToString());
            oProveedor.Barrio.Ciudad.ID_Ciudad = Int32.TryParse(row["ciudad"].ToString(), out i) ? i : 0;
            oProveedor.Barrio.Ciudad.Nombre = row["nomciu"].ToString();

            oProveedor.Tipo_Proveedor = new Tipo_Proveedor();
            oProveedor.Tipo_Proveedor.ID_TipoP = Int32.TryParse(row["id_tipop"].ToString(), out i) ? i : 0;
            oProveedor.Tipo_Proveedor.Descripcion = row["tipo"].ToString();

            oProveedor.Estado_Proveedor = new Estado_Proveedor();
            oProveedor.Estado_Proveedor.ID_EstadoP = Int32.TryParse(row["id_estadop"].ToString(), out i) ? i : 0;
            oProveedor.Estado_Proveedor.Descripcion = row["estado"].ToString();

            return oProveedor;
        }
    }
}
