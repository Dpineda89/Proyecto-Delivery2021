using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class Client
    {
        public string Nombres { get; set; }

        public string Apellidos { get; set; }
         
        public DateTime FechaNacimiento { get; set; }

        public long Identidad { get; set; }

        public int Telefono { get; set; }

        public string CorreoElectronico { get; set; }

        public string Direccion { get; set; }
    }
}
