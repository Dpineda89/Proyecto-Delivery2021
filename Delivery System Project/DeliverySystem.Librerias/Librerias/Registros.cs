using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public static class Registros
    {
        public static List<Client> Clientes { get; set; }
        public static List<OrdenDeEntrega> OrdenesDeEntrega { get; set; }
        public static List<OrdenDeEntregaDetalle> OrdenesDeEntregaDetalle { get; set; }
        public static List<Producto> Productos { get; set; }


        public static void AgregarInformacionPorDefecto()
        {
            Clientes = new List<Client>();
            Clientes.Add(new Client
            {
                Identidad = 1602199700135,
                Nombres = "Joel Ramiro",
                Apellidos = "Caballero Castellanos",
                CorreoElectronico = "joel.ramirocc@gmail.com",
                Direccion = "Barrio la Primavera, Choloma Cortes",
                FechaNacimiento = new DateTime(1997, 05, 26),
                Telefono = 31549099
            });

            OrdenesDeEntrega = new List<OrdenDeEntrega>();
            OrdenesDeEntregaDetalle = new List<OrdenDeEntregaDetalle>();
            Productos = new List<Producto>();

            Productos.Add(new Producto
            {
                Codigo = "BAS",
                Nombre = "Baleada",
                Descripcion = "Baleada sencilla",
                Cantidad = 15,
                PrecioUnitario = 10,
            });

            Productos.Add(new Producto
            {
                Codigo = "BAP",
                Nombre = "Baleada",
                Descripcion = "Baleada con pollo",
                Cantidad = 10,
                PrecioUnitario = 15,
            });

            Productos.Add(new Producto
            {
                Codigo = "TAC",
                Nombre = "Taco",
                Descripcion = "Tacos de pollo",
                Cantidad = 20,
                PrecioUnitario = 25,
            });
        }
    }
}
