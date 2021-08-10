using DeliverySystem.Libreria.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class ProductoLibreria
    {
        DeliverySystemContext deliverySystemContext;
        public ProductoLibreria()
        {
            var conn = new SqlConnection(GeneralData.conection);
            this.deliverySystemContext = new DeliverySystemContext(conn);
        }

        public IEnumerable<Producto> GetAll() 
        {
            var products = deliverySystemContext.Producto.ToList();
            return products;
        }

        public bool AgregarProducto(Producto productoNuevo) 
        {
            var products = deliverySystemContext.Producto.Any(p => p.Codigo == productoNuevo.Codigo);
            if (products)
            {
                return false;
            }

            deliverySystemContext.Producto.Add(productoNuevo);
            deliverySystemContext.SaveChanges();
            return true;
        }

        public bool EliminarProducto(string codigo)
        {
            var ordenes = deliverySystemContext.OrdenDeEntregaDetalle.Any(o => o.CodigoProducto == codigo);

            if (ordenes)
            {
                return false;
            }

            var product = deliverySystemContext.Producto.FirstOrDefault(p => p.Codigo == codigo);

            if (product != null)
            {
                deliverySystemContext.Producto.Remove(product);
                deliverySystemContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
