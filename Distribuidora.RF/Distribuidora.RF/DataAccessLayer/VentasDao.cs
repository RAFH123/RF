using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.Entities;
using System.Data;

namespace Distribuidora.RF.DataAccessLayer
{
    class VentasDao
    {
        internal bool Create(Cliente oCli)
        {
            string nomlocal, tel, email, fecreg, barrio, tipoc, estadoc;
            nomlocal = oCli.Nombre_Local.Trim() == string.Empty ? "NULL" : ("'" + oCli.Nombre_Local + "'");
            tel = oCli.Telefono.Trim() == string.Empty ? "NULL" : ("'" + oCli.Telefono + "'");
            email = oCli.Email.Trim() == string.Empty ? "NULL" : ("'" + oCli.Email + "'");
            if (oCli.Fecha_Registro.ToString("dd/MM/yyyy") != "01/01/0001")
                fecreg = "'" + oCli.Fecha_Registro.ToString("dd/MM/yyyy") + "'";
            else
                fecreg = "NULL";
            barrio = oCli.Barrio.ID_Barrio == 0 ? "NULL" : oCli.Barrio.ID_Barrio.ToString();
            tipoc = oCli.Tipo_Cliente.ID_TipoC == 0 ? "NULL" : oCli.Tipo_Cliente.ID_TipoC.ToString();
            estadoc = oCli.Estado_Cliente.ID_EstadoC == 0 ? "NULL" : oCli.Estado_Cliente.ID_EstadoC.ToString();

            string str_sql = "INSERT INTO Clientes (nombre_local, nombre_cliente, domicilio_calle, domicilio_numero, " +
                                "telefono, email, fecha_registro, barrio, tipo_cliente, estado_cliente, borrado)" +
                            " VALUES (" +
                            nomlocal + ", " +
                            "'" + oCli.Nombre_Cliente + "', " +
                            "'" + oCli.Domicilio_Calle + "', " +
                            "'" + oCli.Domicilio_Numero + "', " +
                            tel + ", " +
                            email + ", " +
                            fecreg + ", " +
                            barrio + ", " +
                            tipoc + ", " +
                            estadoc + ", 0)";

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        public int GetNextNumberFact(char tipoFact)
        {
            var strSql = "SELECT MAX(nro_factura) AS UltimoNro FROM Ventas WHERE tipoFactura = '" + tipoFact + "' AND borrado = 0";
            DataTable fila = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            return (fila.Rows[0]["UltimoNro"] != DBNull.Value ? (int)fila.Rows[0]["UltimoNro"] : 0);
        }
    }
}
