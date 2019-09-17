using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.DataAccessLayer
{
    class CiudadDao
    {
        public IList<Ciudad> GetAll()
        {
            List<Ciudad> listadoCiudades = new List<Ciudad>();

            var strSql = "SELECT id_ciudad, nombre from Ciudades where borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoCiudades.Add(MappingCiudad(row));
            }

            return listadoCiudades;
        }

        private Ciudad MappingCiudad(DataRow row)
        {
            Ciudad oCiudad = new Ciudad
            {
                ID_Ciudad = Convert.ToInt32(row["id_ciudad"].ToString()),
                Nombre = row["nombre"].ToString()
            };

            return oCiudad;
        }
    }
}
