using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class OrdenDeEntregaLibreria
    {

        public bool AgregarOrdenDeEntrega(OrdenDeEntrega ordenDeEntregaNuevo) 
        {
            foreach (OrdenDeEntrega ordenDeEntrega in Registros.OrdenesDeEntrega)
            {
                if (ordenDeEntrega.Codigo == ordenDeEntregaNuevo.Codigo)
                {
                    return false;
                }
            }

            Registros.OrdenesDeEntrega.Add(ordenDeEntregaNuevo);
            return true;
        }
    }
}
