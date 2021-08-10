using DeliverySystem.Libreria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class OrdenDeEntrega
    {
        [Key]
        public string Codigo { get; set; }

        public DateTime FechaEntrega { get; set; }

        public string Descripcion { get; set; }

        [ForeignKey(nameof(Client))]
        public string IdentidadCliente { get; set; }

        public Client Client { get; set; }

        public decimal Total { get; set; }

        [ForeignKey(nameof(Factura))]
        public string CodigoFactura { get; set; }

        public Factura Factura { get; set; }
        public ICollection<OrdenDeEntregaDetalle> Detalles { get; set; }
    }
}
