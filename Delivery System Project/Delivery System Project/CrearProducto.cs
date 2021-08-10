using DeliverySystem.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery_System_Project
{
    public partial class CrearProducto : Form
    {
        private ProductoLibreria productoLibreria;

        public CrearProducto()
        {
            InitializeComponent();
            this.productoLibreria = new ProductoLibreria();
            this.textBox1.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((int)this.numericUpDown1.Value <= 0 || string.IsNullOrEmpty(this.textBox1.Text) || string.IsNullOrEmpty(this.textBox2.Text) || string.IsNullOrEmpty(this.textBox2.Text) || string.IsNullOrEmpty(this.textBox4.Text) || string.IsNullOrEmpty(this.richTextBox1.Text))
            {
                MessageBox.Show("Los campos son requeridos");
            }
            else
            {
                try
                {
                    var producto = new DeliverySystem.Security.Producto
                    {
                        Nombre = this.textBox1.Text,
                        Descripcion = this.richTextBox1.Text,
                        Codigo = this.textBox4.Text,
                        Cantidad = (int)this.numericUpDown1.Value,
                        PrecioUnitario = System.Convert.ToInt32(this.textBox2.Text),
                    };

                    if (pictureBox1.Image != null)
                    {
                        producto.Foto = Program.ConvetImageToBytes(pictureBox1.Image);
                    }

                    var result = this.productoLibreria.AgregarProducto(producto);

                    if (result == false)
                    {
                        MessageBox.Show("No se pudo crear el producto.");
                    }
                    else
                    {
                        MessageBox.Show("Se registro el producto correctamente.");
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
            this.textBox4.Text = string.Empty;
            this.richTextBox1.Text = string.Empty;
            this.numericUpDown1.Value = 0;
            this.textBox1.Focus();
        }

        private void CrearProducto_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            var archivo = openFileDialog1.FileName;
            if (!string.IsNullOrEmpty(archivo))
            {
                var fileInfo = new FileInfo(archivo);
                var fileStream = fileInfo.OpenRead();
                this.pictureBox1.Image = Image.FromStream(fileStream);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = null;
        }
    }
}
