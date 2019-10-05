using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.RF.Entities
{
    class ItemVenta
    {
        public int NroItem { get; set; }
        public Producto ProdDetalle { get; set; }
        public decimal Precio {get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
    }
}
