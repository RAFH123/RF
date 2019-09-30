using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.DataAccessLayer;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.BusinessLayer
{
    class VentasService
    {
        private VentasDao oVentasDao;
        public VentasService()
        {
            oVentasDao = new VentasDao();
        }

        internal bool CrearCliente(Cliente oUsuario)
        {
            return oVentasDao.Create(oUsuario);
        }

        internal int ObtenerProximoNroFactura(char tipoFact)
        {
            return oVentasDao.GetNextNumberFact(tipoFact);
        }
    }
}
