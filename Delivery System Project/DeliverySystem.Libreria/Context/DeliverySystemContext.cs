using DeliverySystem.Libreria.Model;
using DeliverySystem.Security;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Libreria.Context
{
    public class DeliverySystemContext : DbContext
    {
        public DeliverySystemContext(DbConnection dbConnection) 
            :base(dbConnection,true)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<OrdenDeEntrega> OrdenDeEntrega { get; set; }
        public DbSet<OrdenDeEntregaDetalle> OrdenDeEntregaDetalle { get; set; }
        public DbSet<Factura> Factura { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new SeedData());
        }
    }
}
