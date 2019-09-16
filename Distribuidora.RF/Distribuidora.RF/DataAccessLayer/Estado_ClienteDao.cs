using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.DataAccessLayer
{
    class Estado_ClienteDao
    {
        public IList<Estado_Cliente> GetAll()
        {
            List<Estado_Cliente> listadoEstadoClientes = new List<Estado_Cliente>();

            var strSql = "SELECT id_estadoc, descripcion from EstadoCliente where borrado=0";
            
            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoEstadoClientes.Add(MappingEstadoCliente(row));
            }

            return listadoEstadoClientes;
        }

        private Estado_Cliente MappingEstadoCliente(DataRow row)
        {
            Estado_Cliente oEstadoCliente = new Estado_Cliente
            {
                ID_EstadoC = Convert.ToInt32(row["id_estadoc"].ToString()),
                Descripcion = row["descripcion"].ToString()
            };

            return oEstadoCliente;
        }
    }
}
