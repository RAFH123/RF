using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.Entities;
using Distribuidora.RF.DataAccessLayer;

namespace Distribuidora.RF.BusinessLayer
{
    public class Estado_ProveedorService
    {
        private Estado_ProveedorDao oEstado_ProveedorDao;
        public Estado_ProveedorService()
        {
            oEstado_ProveedorDao = new Estado_ProveedorDao();
        }
        public IList<Estado_Proveedor> ObtenerTodos()
        {
            return oEstado_ProveedorDao.GetAll();
        }

    }
}
