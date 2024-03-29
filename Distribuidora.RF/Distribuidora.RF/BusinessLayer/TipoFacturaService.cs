﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.DataAccessLayer;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.BusinessLayer
{
    class TipoFacturaService
    {
        private TipoFacturaDao oTipoFacturaDao;
        public TipoFacturaService()
        {
            oTipoFacturaDao = new TipoFacturaDao();
        }
        public IList<TipoFactura> ObtenerTodos()
        {
            return oTipoFacturaDao.GetAll();
        }
    }
}
