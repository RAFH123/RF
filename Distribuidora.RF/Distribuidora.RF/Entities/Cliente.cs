using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.RF.Entities
{
    public class Cliente
    {
        public int ID_Cliente { get; set; }

        public string Nombre_Local { get; set; }

        public string Nombre_Cliente { get; set; }

        public string Domicilio_Calle { get; set; }

        public int Domicilio_Numero { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public DateTime Fecha_Registro { get; set; }

        public Barrio Barrio { get; set; }

        public Estado_Cliente Estado_Cliente { get; set; }

        public Tipo_Cliente Tipo_Cliente { get; set; }

        public override string ToString()
        {
            return Nombre_Cliente;
        }
    }
}
