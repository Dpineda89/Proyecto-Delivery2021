using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class OrdenDeEntregaDetalle
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(Producto))]
        public string CodigoProducto { get; set; }


        [ForeignKey(nameof(OrdenDeEntrega))]
        public string OrdenDeEntregaCodigo { get; set; }

        public OrdenDeEntrega OrdenDeEntrega { get; set; }

        public int Cantidad { get; set; }

        public decimal Total { get; set; }

        public Producto Producto { get; set; }
    }
}
