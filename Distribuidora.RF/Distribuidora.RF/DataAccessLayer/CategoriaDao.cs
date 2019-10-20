using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.DataAccessLayer
{
    class CategoriaDao
    {
        public IList<Categoria> GetAll()
        {
            List<Categoria> listadoCategorias = new List<Categoria>();

            var strSql = "SELECT id_categoria, descripcion from Categorias where borrado=0";
            
            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoCategorias.Add(MappingCategoria(row));
            }

            return listadoCategorias;
        }

        private Categoria MappingCategoria(DataRow row)
        {
            Categoria oCategoria = new Categoria
            {
                ID_Categoria = Convert.ToInt32(row["id_categoria"].ToString()),
                Descripcion = row["descripcion"].ToString()
            };

            return oCategoria;
        }
    }
}
