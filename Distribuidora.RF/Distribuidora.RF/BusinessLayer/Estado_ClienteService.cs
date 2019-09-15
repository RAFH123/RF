using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.Entities;
using Distribuidora.RF.DataAccessLayer;

namespace Distribuidora.RF.BusinessLayer
{
    public class Estado_ClienteService
    {
        private Estado_ClienteDao oEstado_ClienteDao;
        public Estado_ClienteService()
        {
            oEstado_ClienteDao = new Estado_ClienteDao();
        }
        public IList<Estado_Cliente> ObtenerTodos()
        {
            return oEstado_ClienteDao.GetAll();
        }

    }
}
