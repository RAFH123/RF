using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.Entities;
using Distribuidora.RF.DataAccessLayer;

namespace Distribuidora.RF.BusinessLayer
{
    public class Tipo_ClienteService
    {
        private Tipo_ClienteDao oTipo_ClienteDao;
        public Tipo_ClienteService()
        {
            oTipo_ClienteDao = new Tipo_ClienteDao();
        }
        public IList<Tipo_Cliente> ObtenerTodos()
        {
            return oTipo_ClienteDao.GetAll();
        }

    }
}
