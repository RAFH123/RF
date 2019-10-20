using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.RF.Entities
{
    public class Proveedor
    {
        public int ID_Proveedor { get; set; }

        public string CUIT { get; set; }

        public string Nombre_Local { get; set; }

        public string Nombre_Proveedor { get; set; }

        public string Domicilio_Calle { get; set; }

        public int Domicilio_Numero { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public DateTime Fecha_Registro { get; set; }

        public Barrio Barrio { get; set; }

        public Estado_Proveedor Estado_Proveedor { get; set; }

        public Tipo_Proveedor Tipo_Proveedor { get; set; }

        public override string ToString()
        {
            return Nombre_Proveedor;
        }
    }
}
