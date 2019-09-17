using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.Entities;
using Distribuidora.RF.DataAccessLayer;

namespace Distribuidora.RF.BusinessLayer
{
    public class ClienteService
    {
        private ClienteDao oClienteDao;
        public ClienteService()
        {
            oClienteDao = new ClienteDao();
        }

        public IList<Cliente> ConsultarClientesConFiltrosCondiciones(String condiciones)
        {
            return oClienteDao.GetClienteByFiltersCondiciones(condiciones);
        }

        public IList<Cliente> ConsultarClientesConFiltros(Dictionary<string, object> parametros)
        {
            return oClienteDao.GetClienteByFilters(parametros);
        }

        public Cliente ConsultarClientesPorId(int id)
        {
            return oClienteDao.GetClienteById(id);
        }
        public IList<Cliente> ObtenerTodos()
        {
            return oClienteDao.GetAll();
        }

    }
}
