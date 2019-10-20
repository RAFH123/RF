using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.DataAccessLayer
{
    class Estado_ProveedorDao
    {
        public IList<Estado_Proveedor> GetAll()
        {
            List<Estado_Proveedor> listadoEstadoProveedores = new List<Estado_Proveedor>();

            var strSql = "SELECT id_estadop, descripcion from EstadoProveedor where borrado=0";
            
            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoEstadoProveedores.Add(MappingEstadoProveedor(row));
            }

            return listadoEstadoProveedores;
        }

        private Estado_Proveedor MappingEstadoProveedor(DataRow row)
        {
            Estado_Proveedor oEstadoProveedor = new Estado_Proveedor
            {
                ID_EstadoP = Convert.ToInt32(row["id_estadop"].ToString()),
                Descripcion = row["descripcion"].ToString()
            };

            return oEstadoProveedor;
        }
    }
}
