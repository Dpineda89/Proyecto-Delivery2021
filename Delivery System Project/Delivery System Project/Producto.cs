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
    public partial class Producto : Form
    {
        ProductoLibreria productoLibreria;
        public Producto()
        {
            this.productoLibreria = new ProductoLibreria();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void LoadData()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.productoLibreria.GetAll().ToList();
            this.dataGridView1.Columns[0].Width = 200;
            this.dataGridView1.Columns[2].Width = 200;
            this.dataGridView1.Columns[4].Width = 150;
            this.dataGridView1.Columns[4].HeaderText = "Cantidad disponible";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ninguna fila seleccionada");
                return;
            }
            try
            {
                var codes = new List<string>();
                for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                {
                    var product = (DeliverySystem.Security.Producto)this.dataGridView1.SelectedRows[i].DataBoundItem;
                    codes.Add(product.Codigo);
                }


                bool allDeleted = true;
                foreach (var item in codes)
                {
                    var result = this.productoLibreria.EliminarProducto(item);
                    if (!result)
                    {
                        allDeleted = false;
                    }
                }

                if (!allDeleted)
                {
                    MessageBox.Show("Algun(nos) producto(s) no se pudieron eliminar");
                }
                else
                {
                    MessageBox.Show("El(los) producto(s) se eliminaron correctamente");
                }
                this.LoadData();
            }
            catch (Exception es)
            {
                var a = es.Message;
            }
        }
    }
}
