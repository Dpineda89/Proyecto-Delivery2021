using DeliverySystem.Security;
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
    public partial class CrearCliente : Form
    {
        private ClientLibreria clientLibreria;

        public CrearCliente()
        {
            this.clientLibreria = new ClientLibreria();
            InitializeComponent();
            this.LimpiarTodo();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text) || string.IsNullOrEmpty(this.textBox2.Text) || string.IsNullOrEmpty(this.textBox3.Text) || string.IsNullOrEmpty(this.textBox4.Text) || this.dateTimePicker1.Value == null || string.IsNullOrEmpty(this.richTextBox1.Text))
            {
                MessageBox.Show("Los campos son requeridos");
            }
            else
            {
                try
                {
                    var cliente = new DeliverySystem.Security.Client
                    {
                        Nombres = this.textBox1.Text,
                        Apellidos = this.textBox2.Text,
                        CorreoElectronico = this.textBox5.Text,
                        Direccion = this.richTextBox1.Text,
                        FechaNacimiento = this.dateTimePicker1.Value,
                        Identidad = this.textBox4.Text,
                        Telefono = System.Convert.ToInt32(this.textBox3.Text),
                    };

                    var result = this.clientLibreria.AgregarCliente(cliente);

                    if (result == false)
                    {
                        MessageBox.Show("No se pudo crear el cliente");
                    }
                    else
                    {
                        MessageBox.Show("Se registro el cliente correctamente.");
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
            this.textBox4.Text = string.Empty;
            this.textBox5.Text = string.Empty;
            this.richTextBox1.Text = string.Empty;
            this.dateTimePicker1.Value = DateTime.Now;
            this.textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CrearCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
