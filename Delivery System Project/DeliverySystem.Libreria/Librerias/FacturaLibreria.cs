using DeliverySystem.Libreria.Context;
using DeliverySystem.Libreria.Model;
using DeliverySystem.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Libreria.Librerias
{
    public class FacturaLibreria
    {
        DeliverySystemContext deliverySystem;
        public FacturaLibreria()
        {
            var conn = new SqlConnection(GeneralData.conection);
            this.deliverySystem = new DeliverySystemContext(conn);
        }
        public IEnumerable<Factura> GetAll()
        {
            var facturas = this.deliverySystem.Factura.ToList();
            return facturas;
        }
        public IEnumerable<Factura> GetAllToReport()
        {
            var facturas = this.deliverySystem.Factura
                .Include(d => d.OrdenesDeEntrega.Select(o => o.Client))
                .ToList();

            return facturas;
        }
        public Factura GetByCode(string code)
        {
            var factura = this.deliverySystem.Factura.Include(f => f.OrdenesDeEntrega.Select(d => d.Detalles))
                                                      .FirstOrDefault(f => f.Code == code);

            return factura;
        }

        public bool CrearFactura(List<OrdenDeEntrega> ordenes)
        {
            if (!ordenes.Any())
            {
                return false;
            }
            ordenes = ordenes.Where(o => string.IsNullOrEmpty(o.CodigoFactura)).ToList();

            if (!ordenes.Any())
            {
                return false;
            }

            var factureCode = string.Join("", ordenes.Select(o => o.Codigo.Substring(0, 1))) + DateTime.Now.ToString("-yyyyMMdd");
            var factura = new Factura
            {
                Code = factureCode,
                CreatedDate = DateTime.Now,
                Total = ordenes.Sum(o => o.Total),
            };

            try
            {
                var result = this.deliverySystem.Factura.Add(factura);
                foreach (var item in ordenes)
                {
                    item.CodigoFactura = result.Code;
                    this.deliverySystem.Entry(item).State = EntityState.Modified;
                }

                this.deliverySystem.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                var mm = err.Message;
                return false;
            }
        }
    }
}
