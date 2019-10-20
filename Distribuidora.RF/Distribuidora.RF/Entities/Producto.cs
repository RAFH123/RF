using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.RF.Entities
{
    class Producto
    {
        public int ID_Producto { get; set; }

        public string Nombre { get; set; }
        public string Unidad { get; set; }

        public DateTime Fecha_Registro { get; set; }

        public Categoria Categoria { get; set; }

        public Proveedor Proveedor { get; set; }

        public double Precio { get; set; }

        public int Stock { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
