using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class OrdenDeEntregaDetalle
    {
        public string CodigoOrdenDeEntrega { get; set; }

        public string CodigoProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal Total { get; set; }
    }
}
