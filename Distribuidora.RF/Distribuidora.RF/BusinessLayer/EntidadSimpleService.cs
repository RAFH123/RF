using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.DataAccessLayer;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.BusinessLayer
{
    public class EntidadSimpleService
    {
        private EntidadSimpleDao oESimpleDao;
        public EntidadSimpleService()
        {
            oESimpleDao = new EntidadSimpleDao();
        }

        public IList<EntidadSimple> ObtenerTodos(string tabla)
        {
            return oESimpleDao.GetAll(tabla);
        }

        internal bool CrearEntidadSimple(EntidadSimple oESimple, string tabla)
        {
            return oESimpleDao.Create(oESimple, tabla);
        }

        internal bool ActualizarEntidadSimple(EntidadSimple oESimpleSelected, string tabla)
        {
            return oESimpleDao.Update(oESimpleSelected, tabla);
        }

        internal bool EliminarEntidadSimple(EntidadSimple oESimpleSelected, string tabla)
        {
            return oESimpleDao.Eliminar(oESimpleSelected, tabla);
        }
        public EntidadSimple ConsultarEntidadSimplePorId(int id, string tabla)
        {
            return oESimpleDao.GetEntidadSimpleById(id, tabla);
        }
        internal object ObtenerEntidadSimple(string descrip, string tabla)
        {
            //SIN PARAMETROS
            return oESimpleDao.GetEntidadSimpleSinParametros(descrip, tabla);
        }

        internal string ObtenerColumnaCodigo(string tabla)
        {
            return oESimpleDao.GetIdColumn(tabla);
        }
        internal string ObtenerColumnaDescripcion(string tabla)
        {
            return oESimpleDao.GetDescriptionColumn(tabla);
        }
    }
}
