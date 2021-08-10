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
    public class ClientLibreria
    {
        DeliverySystemContext DeliverySystem;
        public ClientLibreria()
        {
            var conn = new SqlConnection(GeneralData.conection);
            this.DeliverySystem = new DeliverySystemContext(conn);
        }

        public IEnumerable<Client> GetAll()
        {
            var clients = this.DeliverySystem.Client.ToList();
            return clients;
        }

        public bool AgregarCliente(Client clienteNuevo)
        {
            var clients = this.DeliverySystem.Client.ToList();

            foreach (Client cliente in clients)
            {
                if (cliente.Identidad == clienteNuevo.Identidad)
                {
                    return false;
                }
            }
            DeliverySystem.Client.Add(clienteNuevo);
            DeliverySystem.SaveChanges();
            return true;
        }

        public bool Eliminar(string identidad)
        {
            var ordenes = DeliverySystem.OrdenDeEntrega.Any(d => d.IdentidadCliente == identidad);

            if (ordenes)
            {
                return false;
            }

            var cliente = DeliverySystem.Client.FirstOrDefault(c => c.Identidad == identidad);

            if (cliente != null)
            {
                DeliverySystem.Client.Remove(cliente);
                DeliverySystem.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
