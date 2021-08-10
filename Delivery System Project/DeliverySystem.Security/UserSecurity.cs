using DeliverySystem.Libreria.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class UserSecurity
    {
        DeliverySystemContext deliverySystem;
        public UserSecurity()
        {
            var conn = new SqlConnection(GeneralData.conection);
            this.deliverySystem = new DeliverySystemContext(conn);
        }

        public Libreria.Model.Usuario ValidateUser(string user, string password)
        {
            var usuario = this.deliverySystem.Usuario.FirstOrDefault(u => u.UserName == user && u.Password == password);
            return usuario;
        }
    }
}
