using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.DataAccessLayer
{
    public class BarrioDao
    {
        internal bool Create(Barrio oBa)
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

            string nombarrio, idciudad;
            nombarrio = oBa.Nombre.Trim() == string.Empty ? "NULL" : ("'" + oBa.Nombre + "'");
            idciudad = oBa.Ciudad.ID_Ciudad == 0 ? "NULL" : oBa.Ciudad.ID_Ciudad.ToString();

            string str_sql = "INSERT INTO Barrios (nombre, ciudad, borrado)" +
                                " VALUES (" + nombarrio + ", " + idciudad + ", 0)";

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Update(Barrio oBa)
        {
            //SIN PARAMETROS

            string nombarrio, idciudad;
            nombarrio = oBa.Nombre.Trim() == string.Empty ? "NULL" : ("'" + oBa.Nombre + "'");
            idciudad = oBa.Ciudad.ID_Ciudad == 0 ? "NULL" : oBa.Ciudad.ID_Ciudad.ToString();

            string str_sql = "UPDATE Barrios " +
                                "SET nombre = " + nombarrio + ", " +
                                    "ciudad = " + idciudad + ", " +
                                    "borrado = 0 WHERE id_barrio = " + oBa.ID_Barrio;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Eliminar(Barrio oBa)
        {
            string str_sql = "UPDATE Barrios " +
                             "SET borrado = 1 WHERE id_barrio = " + oBa.ID_Barrio;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        public Barrio GetBarrioSinParametros(string nombarrio)
        {
            //Construimos la consulta sql para buscar el cliente en la base de datos.
            String strSql = "SELECT B.id_barrio, B.nombre, B.ciudad, C.nombre AS nomciu "
                                    + "FROM Barrios B "
                                        + "INNER JOIN Ciudades C ON B.ciudad = C.id_ciudad "
                                    + "WHERE B.borrado = 0 AND B.nombre = '" + nombarrio + "'";

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingBarrio(resultado.Rows[0]);
            }

            return null;
        }
        public IList<Barrio> GetAll(string idciu)
        {
            List<Barrio> listadoBarrios = new List<Barrio>();

            var strSql = "SELECT B.id_barrio, B.nombre, C.id_ciudad AS ciudad, C.nombre AS nomciu "
                            + "FROM Barrios B "
                                + "INNER JOIN Ciudades C ON B.ciudad = C.id_ciudad "
                            + "WHERE B.borrado = 0 ";
            
            if (!string.IsNullOrEmpty(idciu))
                strSql += " AND ciudad = " + idciu;

            strSql += " ORDER BY C.nombre, B.nombre";
            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBarrios.Add(MappingBarrio(row));
            }

            return listadoBarrios;
        }

        public Barrio GetBarrioById(int IDBarrio)
        {
            var strSql = "SELECT B.id_barrio, B.nombre, C.id_ciudad AS ciudad, C.nombre AS nomciu "
                                    + "FROM Barrios B "
                                        + "INNER JOIN Ciudades C ON B.ciudad = C.id_ciudad "
                                    + "WHERE B.borrado = 0 AND B.id_barrio = " + IDBarrio.ToString();

            DataTable fila = DBHelper.GetDBHelper().ConsultaSQL(strSql);
            if (fila.Rows.Count > 0)
                return MappingBarrio(fila.Rows[0]);
            else
                return null;
        }

        private Barrio MappingBarrio(DataRow row)
        {
            Barrio oBarrio = new Barrio();
            oBarrio.ID_Barrio = Convert.ToInt32(row["id_barrio"].ToString());
            oBarrio.Nombre = row["nombre"].ToString();

            oBarrio.Ciudad = new Ciudad();
            oBarrio.Ciudad.ID_Ciudad = Convert.ToInt32(row["ciudad"].ToString());
            oBarrio.Ciudad.Nombre = row["nomciu"].ToString();
            return oBarrio;
        }
    }
}
