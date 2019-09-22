using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.Entities;
using Distribuidora.RF.DataAccessLayer;

namespace Distribuidora.RF.BusinessLayer
{
    public class PerfilService
    {
        private PerfilDao oPerfilDao;
        public PerfilService()
        {
            oPerfilDao = new PerfilDao();
        }
        public IList<Perfil> ObtenerTodos()
        {
            return oPerfilDao.GetAll();
        }        
    }
}
