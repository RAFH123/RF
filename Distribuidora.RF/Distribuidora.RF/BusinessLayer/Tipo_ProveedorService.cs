using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.Entities;
using Distribuidora.RF.DataAccessLayer;

namespace Distribuidora.RF.BusinessLayer
{
    public class Tipo_ProveedorService
    {
        private Tipo_ProveedorDao oTipo_ProveedorDao;
        public Tipo_ProveedorService()
        {
            oTipo_ProveedorDao = new Tipo_ProveedorDao();
        }
        public IList<Tipo_Proveedor> ObtenerTodos()
        {
            return oTipo_ProveedorDao.GetAll();
        }

    }
}
