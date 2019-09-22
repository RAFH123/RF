using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.DataAccessLayer
{
    public class UsuarioDao
    {
        public IList<Usuario> GetAll()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();

            String strSql = string.Concat(" SELECT id_usuario, ",
                                          "        n_usuario, ",
                                          "        email, ",
                                          "        estado, ",
                                          "        password, ",
                                          "        p.id_perfil, ",
                                          "        p.descripcion as perfil",
                                          "   FROM Usuarios u",
                                          "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil WHERE u.borrado=0 ");

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoUsuarios.Add(ObjectMapping(row));
            }

            return listadoUsuarios;
        }
        public Usuario GetUserConParametros(string nombreUsuario)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT id_usuario, ",
                                          "        n_usuario, ",
                                          "        email, ",
                                          "        estado, ",
                                          "        password, ",
                                          "        p.id_perfil, ",
                                          "        p.descripcion as perfil",
                                          "   FROM Usuarios u",
                                          "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil ",
                                          "  WHERE u.n_usuario =  @usuario AND u.borrado=0 ");

            var parametros = new Dictionary<string, object>();
            parametros.Add("usuario", nombreUsuario);
            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQLConParametros(strSql, parametros);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }


        public Usuario GetUserSinParametros(string nombreUsuario)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT id_usuario, ",
                                          "        n_usuario, ",
                                          "        email, ",
                                          "        estado, ",
                                          "        password, ",
                                          "        p.id_perfil, ",
                                          "        p.descripcion as perfil ",
                                          "   FROM Usuarios u",
                                          "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil ",
                                          "  WHERE u.borrado =0 ");

            strSql +=" AND n_usuario="+"'"+nombreUsuario+"'";
                                          
           
            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Usuario> GetByFiltersConParametros(Dictionary<string, object> parametros)
        {
                        
            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT id_usuario, ",
                                              "        n_usuario, ",
                                              "        email, ",
                                              "        estado, ",
                                              "        password, ",
                                              "        p.id_perfil, ",
                                              "        p.descripcion as perfil ",
                                              "   FROM Usuarios u",
                                              "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil ",
                                              "  WHERE u.borrado = 0 AND u.estado = 'S'");


            if (parametros.ContainsKey("idPerfil"))
            strSql += " AND (u.id_perfil = @idPerfil) ";


            if (parametros.ContainsKey("usuario"))
            strSql += " AND (u.n_usuario LIKE '%' + @usuario + '%') ";

         var resultado = DBHelper.GetDBHelper().ConsultaSQLConParametros(strSql, parametros);
             
           
            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }


        public IList<Usuario> GetByFiltersSinParametros(String condiciones)
        {

            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT id_usuario, ",
                                              "        n_usuario, ",
                                              "        email, ",
                                              "        estado, ",
                                              "        password, ",
                                              "        p.id_perfil, ",
                                              "        p.descripcion as perfil ",
                                              "   FROM Usuarios u",
                                              "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil ",
                                              "  WHERE u.borrado =0 AND u.estado = 'S'");


           // if (parametros.ContainsKey("idPerfil"))
             //   strSql += " AND (u.id_perfil = @idPerfil) ";


           // if (parametros.ContainsKey("usuario"))
            //    strSql += " AND (u.usuario LIKE '%' + @usuario + '%') ";

            strSql += condiciones;

            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);


            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        internal bool Create(Usuario oUsuario)
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

            string str_sql = "INSERT INTO Usuarios (n_usuario, password, email, estado, id_perfil, borrado)" +
                            " VALUES (" + 
                            "'" + oUsuario.NombreUsuario + "'" +","+
                            "'" + oUsuario.Password + "'" +"," +
                            "'" + oUsuario.Email + "'" + "," +
                            "'" + oUsuario.Estado+ "'" + "," +
                            oUsuario.Perfil.IdP +  ",0)";
                       
            
            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql)==1);
        }

        internal bool Update(Usuario oUsuario)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Usuarios " +
                             "SET n_usuario=" + "'" + oUsuario.NombreUsuario + "'" + "," +
                             " password=" + "'" + oUsuario.Password + "'" + "," +
                             " email=" + "'" + oUsuario.Email + "'" + "," +
                             " estado=" + "'" + oUsuario.Estado + "'" + "," +
                             " id_perfil=" + oUsuario.Perfil.IdP +
                             " WHERE id_usuario=" + oUsuario.IdUsuario;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool ModifyState(Usuario oUsuario)
        {
            //Errores arreglados en el ABM de Usuarios:
            //1) No tomaba las condiciones cuando no se chequeaban todos
            //2) No se adecuaba las condiciones para tomar el operador LIKE
            //3) Implementar la habilitacion/deshabilitación de Usuarios


            //CON PARAMETROS
            Usuario oUser = new Usuario();
            oUser = GetUserConParametros(oUsuario.NombreUsuario);
            oUser.Estado = oUser.Estado == "S" ? "N" : "S"; 

            string str_sql = "UPDATE Usuarios " +
                             "SET estado = " + "'" + oUser.Estado + "'"  +
                             " WHERE id_usuario=" + oUser.IdUsuario;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        private Usuario ObjectMapping(DataRow row)
        {
            Usuario oUsuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"].ToString()),
                NombreUsuario = row["n_usuario"].ToString(),
                Email = row["email"].ToString(),
                Estado = row["estado"].ToString(),
                Password = row.Table.Columns.Contains("password") ? row["password"].ToString() : null,
                Perfil = new Perfil() {
                    IdP = Convert.ToInt32(row["id_perfil"].ToString()),
                    Nombre = row["perfil"].ToString(),
                }                
            };

            return oUsuario;
        }
    }
}

