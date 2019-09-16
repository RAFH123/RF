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

            var strSql = "SELECT id_usuario, n_usuario, email, estado from Usuarios  where borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoUsuarios.Add(MappingUsuario(row));
            }

            return listadoUsuarios;
        }

        public Usuario GetUser(string pUsuario)
        {        
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String consultaSql = string.Concat(" SELECT id_usuario, n_usuario, email, estado, password ",
                                               "   FROM Usuarios ",
                                               "  WHERE borrado =  0 and n_usuario =  '", pUsuario, "'");

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(consultaSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingUsuario(resultado.Rows[0]);
            }

            return null;
        }

        private Usuario MappingUsuario(DataRow row)
        {
            Usuario oUsuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"].ToString()),
                NombreUsuario = row["n_usuario"].ToString(),
                Email = row["email"].ToString(),
                Estado = row["estado"].ToString(),
                Password = row.Table.Columns.Contains("password") ? row["password"].ToString() : null
            };

            return oUsuario;
        }
    }
}
