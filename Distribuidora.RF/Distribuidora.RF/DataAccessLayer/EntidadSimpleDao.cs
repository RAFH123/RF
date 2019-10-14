using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.DataAccessLayer
{
    public class EntidadSimpleDao
    {
        internal bool Create(EntidadSimple oESimple, string tabla)
        {
            //SIN PARAMETROS
            string str_sql = "INSERT INTO " + tabla +
                                " VALUES ('" + oESimple.Descripcion + "', 0)";

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Update(EntidadSimple oESimple, string tabla)
        {
            string str_sql = "UPDATE " + tabla + 
                                " SET " + GetDescriptionColumn(tabla) + " = '" + oESimple.Descripcion + "'" + 
                                " WHERE " + GetIdColumn(tabla) + " = " + oESimple.Codigo ;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Eliminar(EntidadSimple oESimple, string tabla)
        {
            string str_sql = "UPDATE " + tabla +
                                " SET borrado = 1 WHERE " + GetIdColumn(tabla) + " = " + oESimple.Codigo;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        public IList<EntidadSimple> GetAll(string tabla)
        {
            List<EntidadSimple> listadoESimples = new List<EntidadSimple>();

            var strSql = "SELECT * FROM "  + tabla + " WHERE borrado = 0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoESimples.Add(MappingESimple(row));
            }

            return listadoESimples;
        }

        public EntidadSimple GetEntidadSimpleById(int codigo, string tabla)
        {
//            strSql = "SELECT * FROM " + tabla +
//                            " WHERE borrado = 0 AND " + DatosTabla.Columns[0].ColumnName + " = " + codigo.ToString();
            string strSql = "SELECT * FROM " + tabla +
                            " WHERE borrado = 0 AND " + GetIdColumn(tabla) + " = " + codigo.ToString();

            DataTable fila = DBHelper.GetDBHelper().ConsultaSQL(strSql);
            if (fila.Rows.Count > 0)
                return MappingESimple(fila.Rows[0]);
            else
                return null;
        }

        public EntidadSimple GetEntidadSimpleSinParametros(string descrip, string tabla)
        {
            String strSql = "SELECT * FROM " + tabla + " WHERE borrado = 0 AND " + 
                                GetDescriptionColumn(tabla) + " = '" + descrip + "'";

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingESimple(resultado.Rows[0]);
            }

            return null;
        }
        
        private EntidadSimple MappingESimple(DataRow row)
        {
            EntidadSimple oESimple = new EntidadSimple();
            oESimple.Codigo = Convert.ToInt32(row[0].ToString());
            oESimple.Descripcion = row[1].ToString();
            return oESimple;
        }

        public string GetIdColumn(string tabla)
        {
            string strSql = "SELECT * FROM " + tabla + " WHERE 1 = 2";
            return DBHelper.GetDBHelper().ConsultaSQL(strSql).Columns[0].ColumnName;
        }
        public string GetDescriptionColumn(string tabla)
        {
            string strSql = "SELECT * FROM " + tabla + " WHERE 1 = 2";
            return DBHelper.GetDBHelper().ConsultaSQL(strSql).Columns[1].ColumnName;
        }
    }
}
