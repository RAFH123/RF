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
        public IList<Barrio> ObtenerTodos()
        {
            return oBarrioDao.GetAll();
        }

    }
}
