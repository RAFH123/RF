using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.RF.Entities
{
    class Producto
    {
        public int Id_Producto { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public int Stock { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
