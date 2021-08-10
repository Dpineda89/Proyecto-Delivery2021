        using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DeliverySystem.Libreria.Model;

namespace DeliverySystem.Libreria.Context
{
    public class SeedData : CreateDatabaseIfNotExists<DeliverySystemContext>
    {
        protected override void Seed(DeliverySystemContext deliverySystem)
        {
            try
            {
            deliverySystem.Usuario.Add(new Usuario
            {
                UserName = "darwintest",
                Password = "1",
            });


            deliverySystem.Usuario.Add(new Usuario
            {
                UserName = "joeltest",
                Password = "2",
            });

            deliverySystem.SaveChanges();


            }
            catch (Exception esa)
            {
                var mm = esa.Message;
            }

            deliverySystem.Client.Add(new Security.Client
            {
                Identidad = "1602199700135",
                Nombres = "Joel Ramiro",
                Apellidos = "Caballero Castellanos",
                CorreoElectronico = "joel.ramirocc@gmail.com",
                Direccion = "Barrio la Primavera, Choloma Cortes",
                FechaNacimiento = new DateTime(1997, 05, 26),
                Telefono = 31549099,
            });

            deliverySystem.Client.Add(new Security.Client
            {
                Identidad = "1602199300132",
                Nombres = "Bessy Yolani",
                Apellidos = "Caballero Castellanos",
                CorreoElectronico = "bessy.yolani@gmail.com",
                Direccion = "Villas del Marquez, Choloma Cortes",
                FechaNacimiento = new DateTime(1993, 05, 26),
                Telefono = 98605328,
            });

            deliverySystem.SaveChanges();
            deliverySystem.Producto.Add(new Security.Producto
            {
                Codigo = "BAS",
                Nombre = "Baleada",
                Descripcion = "Baleada sencilla",
                Cantidad = 15,
                PrecioUnitario = 10,
            });
            deliverySystem.Producto.Add(new Security.Producto
            {
                Codigo = "BAP",
                Nombre = "Baleada",
                Descripcion = "Baleada con pollo",
                Cantidad = 10,
                PrecioUnitario = 15,
            });
            deliverySystem.Producto.Add(new Security.Producto
            {
                Codigo = "TAC",
                Nombre = "Taco",
                Descripcion = "Tacos de pollo",
                Cantidad = 20,
                PrecioUnitario = 25,
            });

            deliverySystem.SaveChanges();
            var orden = deliverySystem.OrdenDeEntrega.Add(new Security.OrdenDeEntrega
            {
                Codigo = "1",
                Descripcion = "Little boys foods",
                FechaEntrega = DateTime.Now,
                IdentidadCliente = "1602199700135",
                Total = 200,
            });
            deliverySystem.OrdenDeEntregaDetalle.Add(new Security.OrdenDeEntregaDetalle
            {
                OrdenDeEntregaCodigo = "1",
                Cantidad = 5,
                CodigoProducto = "TAC",
                Total = 125,
            });
            deliverySystem.OrdenDeEntregaDetalle.Add(new Security.OrdenDeEntregaDetalle
            {
                OrdenDeEntregaCodigo = "1",
                Cantidad = 5,
                CodigoProducto = "BAP",
                Total = 75,
            });

            deliverySystem.SaveChanges();

            base.Seed(deliverySystem);
        }
    }
}
