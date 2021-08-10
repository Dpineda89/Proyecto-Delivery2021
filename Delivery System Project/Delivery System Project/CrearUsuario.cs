using DeliverySystem.Libreria.Librerias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery_System_Project
{
    public partial class CrearUsuario : Form
    {
        UsuarioLibreria usuarioLibreria;
        public CrearUsuario()
        {
            InitializeComponent();
            this.usuarioLibreria = new UsuarioLibreria();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text) || string.IsNullOrEmpty(this.textBox2.Text) || string.IsNullOrEmpty(this.textBox3.Text))
            {
                MessageBox.Show("Los campos son requeridos");
            }
            else
            {
                if (textBox3.Text != textBox2.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                    return;
                }
                try
                {
                    var usuario = new DeliverySystem.Libreria.Model.Usuario 
                    {
                        UserName = textBox1.Text,
                        Password = textBox2.Text,
                    };

                    var result = this.usuarioLibreria.AgregarUsuario(usuario);

                    if (result == false)
                    {
                        MessageBox.Show("No se pudo crear el usuario");
                    }
                    else
                    {
                        MessageBox.Show("Se registro el usuario correctamente.");
                        this.LimpiarTodo();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ingrese correctamente el valor de los campos.");
                }

            }
        }
        
            void LimpiarTodo()
        {
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
            this.textBox1.Focus();
        }
    }
}
