using DeliverySystem.Libreria.Context;
using DeliverySystem.Libreria.Model;
using DeliverySystem.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Libreria.Librerias
{
    public class UsuarioLibreria
    {
        DeliverySystemContext DeliverySystem;
        public UsuarioLibreria()
        {
            var conn = new SqlConnection(GeneralData.conection);
            this.DeliverySystem = new DeliverySystemContext(conn);
        }

        public IEnumerable<Usuario> GetAll()
        {
            var usuarios = this.DeliverySystem.Usuario.ToList();
            return usuarios;
        }

        public bool AgregarUsuario(Usuario usuarioNuevo)
        {
            var exist = this.DeliverySystem.Usuario.Any(d => d.UserName == usuarioNuevo.UserName);

            if (exist)
            {
                return false;
            }

            DeliverySystem.Usuario.Add(usuarioNuevo);
            DeliverySystem.SaveChanges();
            return true;
        }

        public bool Eliminar(int id)
        {
            var usuario = DeliverySystem.Usuario.FirstOrDefault(c => c.Id == id);

            if (usuario != null)
            {
                DeliverySystem.Usuario.Remove(usuario);
                DeliverySystem.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
