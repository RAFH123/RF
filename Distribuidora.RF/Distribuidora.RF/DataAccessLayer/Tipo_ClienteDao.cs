using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.DataAccessLayer
{
    class Tipo_ClienteDao
    {
        public IList<Tipo_Cliente> GetAll()
        {
            List<Tipo_Cliente> listadoTipoClientes = new List<Tipo_Cliente>();

            var strSql = "SELECT id_tipoc, descripcion from Tipo_Cliente where borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoTipoClientes.Add(MappingTipoCliente(row));
            }

            return listadoTipoClientes;
        }

        private Tipo_Cliente MappingTipoCliente(DataRow row)
        {
            Tipo_Cliente oTipoCliente = new Tipo_Cliente
            {
                ID_TipoC = Convert.ToInt32(row["id_tipoc"].ToString()),
                Descripcion = row["descripciont"].ToString()
            };

            return oTipoCliente;
        }
    }
}
