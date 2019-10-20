using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.DataAccessLayer;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.BusinessLayer
{
    class ProductoService
    {
        private ProductoDao oProductoDao;
        public ProductoService()
        {
            oProductoDao = new ProductoDao();
        }
        public IList<Producto> ObtenerTodos()
        {
            return oProductoDao.GetAll();
        }
        public Producto ObtenerProductoPorId(int id)
        {
            return oProductoDao.GetProductoById(id);
        }
        internal bool CrearProducto(Producto oProd)
        {
            return oProductoDao.Create(oProd);
        }

        internal bool ActualizarProducto(Producto oProductoSelected)
        {
            return oProductoDao.Update(oProductoSelected);
        }

        internal object ObtenerProducto(string Producto)
        {
            //SIN PARAMETROS
            return oProductoDao.GetProductoSinParametros(Producto);

            //CON PARAMETROS
            // return oUsuarioDao.GetUserConParametros(usuario);
        }
        internal bool EliminarProducto(Producto oProductoSelected)
        {
            //            throw new NotImplementedException();
            return oProductoDao.Eliminar(oProductoSelected);
        }

    }
}
