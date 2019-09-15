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
        public IList<Barrio> GetAll()
        {
            List<Barrio> listadoBarrios = new List<Barrio>();

            var strSql = "SELECT id_barrio, nombre from Barrios where borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBarrios.Add(MappingBarrio(row));
            }

            return listadoBarrios;
        }

        private Barrio MappingBarrio(DataRow row)
        {
            Barrio oBarrio = new Barrio
            {
                ID_Barrio = Convert.ToInt32(row["id_barrio"].ToString()),
                Nombre = row["nombre"].ToString()
            };

            return oBarrio;
        }
    }
}
