using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.DataAccessLayer;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.BusinessLayer
{
    public class CategoriaService
    {
        private CategoriaDao oCategoriaDao;
        public CategoriaService()
        {
            oCategoriaDao = new CategoriaDao();
        }
        public IList<Categoria> ObtenerTodos()
        {
            return oCategoriaDao.GetAll();
        }

    }
}
