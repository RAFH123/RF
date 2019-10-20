using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.DataAccessLayer
{
    class Tipo_ProveedorDao
    {
        public IList<Tipo_Proveedor> GetAll()
        {
            List<Tipo_Proveedor> listadoTipoProveedores = new List<Tipo_Proveedor>();

            var strSql = "SELECT id_tipop, descripcion from TipoProveedor where borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoTipoProveedores.Add(MappingTipoProveedor(row));
            }

            return listadoTipoProveedores;
        }

        private Tipo_Proveedor MappingTipoProveedor(DataRow row)
        {
            Tipo_Proveedor oTipoProveedor = new Tipo_Proveedor
            {
                ID_TipoP = Convert.ToInt32(row["id_tipop"].ToString()),
                Descripcion = row["descripcion"].ToString()
            };

            return oTipoProveedor;
        }
    }
}
