using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.DataAccessLayer
{
    class ProductoDao
    {
        public IList<Producto> GetAll()
        {
            List<Producto> listadoProductos = new List<Producto>();

            var strSql = "SELECT P.id_producto, P.nombre, P.unidad, P.precio, P.stock, "
                                + " P.categoria, C.descripcion, P.proveedor, Prov.nombre_proveedor, P.fecha_registro "
                            + "FROM Productos P "
                                + "FULL JOIN Categorias C ON P.categoria = C.id_categoria "
                                + "FULL JOIN Proveedores Prov ON P.proveedor = Prov.id_proveedor "
                            + "WHERE P.borrado = 0 ORDER BY P.categoria, P.nombre";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoProductos.Add(MappingProducto(row));
            }

            return listadoProductos;
        }

        public Producto GetProductoById(int IDProd)
        {
            var strSql = "SELECT P.id_producto, P.nombre, P.unidad, P.precio, P.stock, "
                                + " P.categoria, C.descripcion, P.proveedor, Prov.nombre_proveedor, P.fecha_registro "
                            + "FROM Productos P "
                                + "FULL JOIN Categorias C ON P.categoria = C.id_categoria "
                                + "FULL JOIN Proveedores Prov ON P.proveedor = Prov.id_proveedor "
                            + "WHERE P.borrado = 0 AND id_producto = " + IDProd.ToString();

            DataTable fila = DBHelper.GetDBHelper().ConsultaSQL(strSql);
            if (fila.Rows.Count > 0)
                return MappingProducto(fila.Rows[0]);
            else
                return null;
        }

        internal bool Create(Producto oProd)
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

            string nomprod, unidad, fecreg, categoria, proveedor, precio, stock;
            nomprod = oProd.Nombre.Trim() == string.Empty ? "NULL" : ("'" + oProd.Nombre + "'");
            unidad = oProd.Unidad.Trim() == string.Empty ? "NULL" : ("'" + oProd.Unidad + "'");
            if (oProd.Fecha_Registro.ToString("dd/MM/yyyy") != "01/01/0001")
                fecreg = "'" + oProd.Fecha_Registro.ToString("dd/MM/yyyy") + "'";
            else
                fecreg = "NULL";
            categoria = oProd.Categoria.ID_Categoria == 0 ? "NULL" : oProd.Categoria.ID_Categoria.ToString();
            proveedor = oProd.Proveedor.ID_Proveedor == 0 ? "NULL" : oProd.Proveedor.ID_Proveedor.ToString();
            precio = oProd.Precio == 0 ? "NULL" : oProd.Precio.ToString().Replace(",",".");
            stock = oProd.Stock == 0 ? "NULL" : oProd.Stock.ToString();

            string str_sql = "INSERT INTO Productos (nombre, unidad, categoria, proveedor, precio, stock, fecha_registro, borrado) "
                                    + " VALUES ("
                                        + nomprod + ", "
                                        + unidad + ", "
                                        + categoria + ", "
                                        + proveedor + ", "
                                        + precio + ", "
                                        + stock + ", "
                                        + fecreg + ", 0)";

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Update(Producto oProd)
        {
            //SIN PARAMETROS

            string nomprod, unidad, fecreg, categoria, proveedor, precio, stock;
            nomprod = oProd.Nombre.Trim() == string.Empty ? "NULL" : ("'" + oProd.Nombre + "'");
            unidad = oProd.Unidad.Trim() == string.Empty ? "NULL" : ("'" + oProd.Unidad + "'");
            if (oProd.Fecha_Registro.ToString("dd/MM/yyyy") != "01/01/0001")
                fecreg = "'" + oProd.Fecha_Registro.ToString("dd/MM/yyyy") + "'";
            else
                fecreg = "NULL";
            categoria = oProd.Categoria.ID_Categoria == 0 ? "NULL" : oProd.Categoria.ID_Categoria.ToString();
            proveedor = oProd.Proveedor.ID_Proveedor == 0 ? "NULL" : oProd.Proveedor.ID_Proveedor.ToString();
            precio = oProd.Precio == 0 ? "NULL" : oProd.Precio.ToString().Replace(",", ".");
            stock = oProd.Stock == 0 ? "NULL" : oProd.Stock.ToString();

            string str_sql = "UPDATE Productos " +
                             "SET nombre = " + nomprod + ", " +
                             "unidad = " + unidad + ", " +
                             "categoria = " + categoria + ", " +
                             "proveedor = " + proveedor + ", " +
                             "fecha_registro = " + fecreg + ", " +
                             "precio = " + precio + ", " +
                             "stock = " + stock + ", " +
                             "borrado = 0 WHERE id_Producto = " + oProd.ID_Producto;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Eliminar(Producto oProd)
        {
            string str_sql = "UPDATE Productos " +
                             "SET borrado = 1 WHERE id_Producto = " + oProd.ID_Producto;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        public Producto GetProductoSinParametros(string prod)
        {
            //Construimos la consulta sql para buscar el cliente en la base de datos.
            var strSql = "SELECT id_producto, nombre, precio, stock FROM Productos "
                        + "WHERE borrado = 0 AND nombre = '" + prod+ "'";

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingProducto(resultado.Rows[0]);
            }

            return null;
        }
        private Producto MappingProducto(DataRow row)
        {
            Producto oProducto = new Producto();
            oProducto.ID_Producto = Convert.ToInt32(row["id_producto"].ToString());
            oProducto.Nombre = row["nombre"].ToString();
            oProducto.Unidad = row["unidad"].ToString();
            oProducto.Precio = Convert.ToDouble(row["precio"].ToString());
            oProducto.Stock = Convert.ToInt32(row["stock"].ToString());
            
            DateTime result = new DateTime(1900, 1, 1, 0, 0, 0);
            if (DateTime.TryParse(row["fecha_registro"].ToString(), out result))
                oProducto.Fecha_Registro = result;

            oProducto.Categoria = new Categoria();
            int i = 0;
            oProducto.Categoria.ID_Categoria = Int32.TryParse(row["categoria"].ToString(), out i) ? i : 0;
            oProducto.Categoria.Descripcion = row["descripcion"].ToString();

            oProducto.Proveedor = new Proveedor();
            oProducto.Proveedor.ID_Proveedor = Int32.TryParse(row["proveedor"].ToString(), out i) ? i : 0;
            oProducto.Proveedor.Nombre_Proveedor = row["nombre_proveedor"].ToString();

            return oProducto;
        }
    }
}
