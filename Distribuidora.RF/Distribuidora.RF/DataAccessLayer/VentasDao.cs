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
        public int Create(Ventas oVenta, List<ItemVenta> oListDetalle)
        {
            int nrofactreal = 0;
            try
            {
                DBHelper.GetDBHelper().Open();
                DBHelper.GetDBHelper().BeginTransaction();

                nrofactreal = GetNextNumberFact(oVenta.TipoFactura.Id_TipoFactura);

                string strSql = "INSERT INTO Ventas (tipoFactura, nro_factura, fecha, cliente, condiva, condventa," 
                                + "subtotal, porc_descuento, importe_neto, importe_iva, importe_total) "
                                + "VALUES ('" + oVenta.TipoFactura.Id_TipoFactura + "', " + nrofactreal + ", '" 
                                + oVenta.Fecha.ToString("dd/MM/yyyy") + "', " + oVenta.Cliente.ID_Cliente + ", '"
                                + oVenta.CondIVA + "', '" + oVenta.CondVenta + "', " + oVenta.Subtotal.ToString().Replace(',','.') + ", "
                                + oVenta.PorcDescuento.ToString().Replace(',', '.') + ", "
                                + oVenta.ImporteNeto.ToString().Replace(',', '.') + ", "
                                + oVenta.ImporteIva.ToString().Replace(',', '.') + ", "
                                + oVenta.ImporteTotal.ToString().Replace(',', '.') + ")";

                //System.Windows.Forms.MessageBox.Show(strSql);
                DBHelper.GetDBHelper().EjecutarSQLconTransaccion(strSql);

                DetalleVentasDao oDet = new DetalleVentasDao();
                oDet.Create(oVenta.TipoFactura.Id_TipoFactura, nrofactreal, oListDetalle);

                DBHelper.GetDBHelper().Commit();

            }
            catch (Exception ex)
            {
                DBHelper.GetDBHelper().Rollback();
                nrofactreal = 0;
                throw ex;
            }
            finally
            {
                // Cierra la conexión 
                DBHelper.GetDBHelper().Close();
            }
            return nrofactreal;
        }

        public int GetNextNumberFact(char tipoFact)
        {
            var strSql = "SELECT MAX(nro_factura) AS UltimoNro FROM Ventas WHERE tipoFactura = '" + tipoFact + "' AND borrado = 0";
            DataTable fila = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            return (fila.Rows[0]["UltimoNro"] != DBNull.Value ? Convert.ToInt32(fila.Rows[0]["UltimoNro"]) + 1 : 1);
        }
    }
}
