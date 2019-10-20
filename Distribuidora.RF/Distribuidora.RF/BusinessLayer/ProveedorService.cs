using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.Entities;
using Distribuidora.RF.DataAccessLayer;

namespace Distribuidora.RF.BusinessLayer
{
    public class ProveedorService
    {
        private ProveedorDao oProveedorDao;
        public ProveedorService()
        {
            oProveedorDao = new ProveedorDao();
        }

        public IList<Proveedor> ConsultarProveedoresConFiltrosCondiciones(String condiciones)
        {
            return oProveedorDao.GetProveedorByFiltersCondiciones(condiciones);
        }

        public IList<Proveedor> ConsultarProveedoresConFiltros(Dictionary<string, object> parametros)
        {
            return oProveedorDao.GetProveedorByFilters(parametros);
        }

        public Proveedor ConsultarProveedoresPorId(int id)
        {
            return oProveedorDao.GetProveedorById(id);
        }
        public IList<Proveedor> ObtenerTodos()
        {
            return oProveedorDao.GetAll();
        }
        internal bool CrearProveedor(Proveedor oUsuario)
        {
            return oProveedorDao.Create(oUsuario);
        }

        internal bool ActualizarProveedor(Proveedor oProveedorSelected)
        {
            return oProveedorDao.Update(oProveedorSelected);
        }

        internal object ObtenerProveedor(string Proveedor)
        {
            //SIN PARAMETROS
            return oProveedorDao.GetProveedorSinParametros(Proveedor);

            //CON PARAMETROS
            // return oUsuarioDao.GetUserConParametros(usuario);
        }
        internal bool EliminarProveedor(Proveedor oProveedorSelected)
        {
            //            throw new NotImplementedException();
            return oProveedorDao.Eliminar(oProveedorSelected);
        }
    }
}
