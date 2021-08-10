using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class ProductoLibreria
    {

        public bool AgregarProducto(Producto productoNuevo) 
        {
            foreach (Producto producto in Registros.Productos)
            {
                if (producto.Codigo == productoNuevo.Codigo)
                {
                    return false;
                }
            }

            Registros.Productos.Add(productoNuevo);
            return true;
        }

        public bool EliminarProducto(string codigo)
        {
            foreach (var producto in Registros.OrdenesDeEntregaDetalle)
            {
                if (producto.CodigoProducto == codigo)
                {
                    return false;
                }
            }

            foreach (Producto producto in Registros.Productos)
            {
                if (producto.Codigo == codigo)
                {
                    Registros.Productos.Remove(producto);
                    return true;
                }
            }

            return false;
        }
    }
}
