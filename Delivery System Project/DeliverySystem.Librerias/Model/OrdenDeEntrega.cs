using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class OrdenDeEntrega
    {
        public string Codigo { get; set; }

        public DateTime FechaEntrega { get; set; }

        public string Descripcion { get; set; }

        public long IdentidadCliente { get; set; }

        public decimal Total { get; set; }
    }
}
