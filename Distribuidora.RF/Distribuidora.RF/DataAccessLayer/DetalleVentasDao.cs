using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.RF.Entities;

namespace Distribuidora.RF.DataAccessLayer
{
    class DetalleVentasDao
    {
        public bool Create(char tipofact, int nrofact, List<ItemVenta> oListDetalle)
        {
            foreach (ItemVenta oDet in oListDetalle)
            {
                string strSql = "UPDATE Productos SET stock = stock - " + oDet.Cantidad
                                + " WHERE id_producto = " + oDet.ProdDetalle.Id_Producto;

                DBHelper.GetDBHelper().EjecutarSQLconTransaccion(strSql);

                strSql = "INSERT INTO DetVentas (tipo_factura, nro_factura, id_producto, precio, cantidad, importe)"
                                + " VALUES ('" + tipofact + "', " + nrofact + ", " + oDet.ProdDetalle.Id_Producto + ", "
                                + oDet.Precio.ToString().Replace(',', '.') + ", " 
                                + oDet.Cantidad + ", "
                                + oDet.Importe.ToString().Replace(',', '.') + ")";

                //System.Windows.Forms.MessageBox.Show(strSql);
                DBHelper.GetDBHelper().EjecutarSQLconTransaccion(strSql);
            }

            return true;
        }
    }
}
