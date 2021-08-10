using DeliverySystem.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Libreria.Model
{
    public class Factura
    {
        [Key]
        public string Code { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<OrdenDeEntrega> OrdenesDeEntrega { get; set; }

        public decimal Total { get; set; }
    }
}
