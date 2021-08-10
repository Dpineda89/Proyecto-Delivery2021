using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class ClientLibreria
    {

        public bool AgregarCliente(Client clienteNuevo) 
        {
            foreach (Client cliente in Registros.Clientes)
            {
                if (cliente.Identidad == clienteNuevo.Identidad)
                {
                    return false;
                }
            }

            Registros.Clientes.Add(clienteNuevo);
            return true;
        }

        public bool Eliminar(long identidad)
        {
            foreach (var orden in Registros.OrdenesDeEntrega)
            {
                if (orden.IdentidadCliente == identidad)
                {
                    return false;
                }
            }

            foreach (Client cliente in Registros.Clientes)
            {
                if (cliente.Identidad == identidad)
                {
                    Registros.Clientes.Remove(cliente);
                    return true;
                }
            }

            return false;
        }
    }
}
