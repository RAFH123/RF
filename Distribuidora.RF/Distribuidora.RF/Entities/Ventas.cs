using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.RF.Entities
{
    class Ventas
    {
        public TipoFactura TipoFactura { get; set; }
        public int Nro_Factura { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public string CondIVA;
        public string CondVenta;
        public decimal Subtotal { get; set; }
        public int PorcDescuento { get; set; }
        public decimal ImporteNeto { get; set; }
        public decimal ImporteTotal { get; set; }
        public override string ToString()
        {
            return TipoFactura + Nro_Factura.ToString("0001-00000000");
        }
    }
}
