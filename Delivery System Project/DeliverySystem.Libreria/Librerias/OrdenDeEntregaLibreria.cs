using DeliverySystem.Libreria.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class OrdenDeEntregaLibreria
    {

        DeliverySystemContext DeliverySystem;

        public OrdenDeEntregaLibreria()
        {
            var conn = new SqlConnection(GeneralData.conection);
            this.DeliverySystem = new DeliverySystemContext(conn);
        }

        public IEnumerable<OrdenDeEntrega> GetAll()
        {
            var orden = DeliverySystem.OrdenDeEntrega.ToList();
            return orden;
        }

        public IEnumerable<OrdenDeEntregaDetalle> GetDetailByCode(string code)
        {
            var detalle = DeliverySystem.OrdenDeEntregaDetalle.Where(d => d.OrdenDeEntregaCodigo == code);
            return detalle;
        }

        public bool AgregarOrdenDeEntrega(OrdenDeEntrega ordenDeEntregaNuevo, List<OrdenDeEntregaDetalle> detalle)
        {
            try
            {
                var orden = DeliverySystem.OrdenDeEntrega.Any(o => o.Codigo == ordenDeEntregaNuevo.Codigo);

                if (orden)
                {
                    return false;
                }


                var join = detalle
                    .Join(DeliverySystem.Producto, d => d.CodigoProducto, d => d.Codigo, (origin, destino) => new { origin, destino }).ToList();

                if (join.Count() < detalle.Count)
                {
                    return false;
                }
                foreach (var item in join)
                {
                    if (item.origin.Cantidad > item.destino.Cantidad)
                    {
                        return false;
                    }
                    else
                    {
                        item.destino.Cantidad -= item.origin.Cantidad;
                        DeliverySystem.Entry(item.destino).State = EntityState.Modified;
                    }
                }

                ordenDeEntregaNuevo.Detalles = detalle;
                DeliverySystem.OrdenDeEntrega.Add(ordenDeEntregaNuevo);
                DeliverySystem.SaveChanges();
                return true;

            }
            catch (Exception es)
            {
                var mm = es.Message;
                return false;
            }
        }
    }
}
