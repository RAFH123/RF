using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.Entities;
using Distribuidora.RF.DataAccessLayer;


namespace Distribuidora.RF.BusinessLayer
{
    public class BarrioService
    {
        private BarrioDao oBarrioDao;
        public BarrioService()
        {
            oBarrioDao = new BarrioDao();
        }
        public IList<Barrio> ObtenerTodos(string idciu)
        {
            return oBarrioDao.GetAll(idciu);
        }
        internal bool CrearBarrio(Barrio oBa)
        {
            return oBarrioDao.Create(oBa);
        }

        internal bool ActualizarBarrio(Barrio oBaSelected)
        {
            return oBarrioDao.Update(oBaSelected);
        }

        internal object ObtenerBarrio(string barrio)
        {
            return oBarrioDao.GetBarrioSinParametros(barrio);
        }
        internal bool EliminarBarrio(Barrio oBaSelected)
        {
            //            throw new NotImplementedException();
            return oBarrioDao.Eliminar(oBaSelected);
        }
        public Barrio ConsultarBarriosPorId(int id)
        {
            return oBarrioDao.GetBarrioById(id);
        }
    }
}
