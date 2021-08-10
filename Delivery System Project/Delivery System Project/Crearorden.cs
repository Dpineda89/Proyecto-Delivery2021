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
    public partial class Crearorden : Form
    {
        OrdenDeEntregaLibreria ordenDeEntregaLibreria;
        ProductoLibreria ProductoLibreria;
        ClientLibreria clientLibreria;
        public Crearorden()
        {
            this.clientLibreria = new ClientLibreria();
            this.ordenDeEntregaLibreria = new OrdenDeEntregaLibreria();
            this.ProductoLibreria = new ProductoLibreria();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Crearorden_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void LoadData()
        {
            this.ClearAll();
            this.comboBox1.DataSource = null;
            this.dateTimePicker1.Value = DateTime.Now;
            var result = clientLibreria.GetAll().Select(c => new { Text = c.Nombres, Value = c.Identidad }).ToArray();
            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.ValueMember = "Value";
            this.comboBox1.DataSource = result;

            var products = ProductoLibreria.GetAll().Where(p => p.Cantidad > 0)
                .Select(p => new ProductsModel
                {
                    Codigo = p.Codigo,
                    Cantidad = p.Cantidad,
                    SelectedQuantity = 0,
                    UnitPrice = p.PrecioUnitario,
                    Producto = p.Descripcion,
                }).ToList();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = products;
            this.dataGridView1.Columns[1].Width = 200;
            //this.dataGridView1.Columns[3].HeaderText = "Precio unitario";
            //this.dataGridView1.Columns[4].HeaderText = "Seleccione cantidad";

            this.dataGridView1.Columns[0].ReadOnly = true;
            this.dataGridView1.Columns[1].ReadOnly = true;
            this.dataGridView1.Columns[2].ReadOnly = true;
            this.dataGridView1.Columns[3].ReadOnly = true;
            this.dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            this.dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;

            this.textBox1.Focus();
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var result = (ProductsModel)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;
                if (result.SelectedQuantity > result.Cantidad)
                {
                    result.SelectedQuantity = result.Cantidad;
                }
                else if (result.SelectedQuantity < 0)
                {
                    result.SelectedQuantity = 0;
                }
            }
            catch (Exception es)
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[4].Value = 0;
            }
            return;
        }

        void ClearAll()
        {
            this.dateTimePicker1.Value = DateTime.Now;
            this.textBox1.Text = string.Empty;
            this.richTextBox1.Text = string.Empty;
            this.comboBox1.DataSource = null;
            this.dataGridView1.DataSource = null;
            this.textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textBox1.Text) || string.IsNullOrEmpty(this.richTextBox1.Text) || this.comboBox1.SelectedValue == null || this.dateTimePicker1.Value == null)
                {
                    MessageBox.Show("Los campos son requeridos.");
                    return;
                }
                var result = ((List<ProductsModel>)this.dataGridView1.DataSource).Where(r => r.SelectedQuantity > 0);

                if (!result.Any())
                {
                    MessageBox.Show("Se debe ingresar por lo menos un producto a la orden.");
                    return;
                }
                var resultSave = this.ordenDeEntregaLibreria.AgregarOrdenDeEntrega(new DeliverySystem.Security.OrdenDeEntrega
                {
                    Codigo = this.textBox1.Text,
                    Descripcion = this.richTextBox1.Text,
                    FechaEntrega = this.dateTimePicker1.Value,
                    IdentidadCliente = this.comboBox1.SelectedValue.ToString(),
                    Total = result.Sum(d => d.UnitPrice * d.SelectedQuantity),
                },
                result.Select(d => new DeliverySystem.Security.OrdenDeEntregaDetalle
                {
                    Cantidad = d.SelectedQuantity,
                    CodigoProducto = d.Codigo,
                    Total = d.UnitPrice * d.SelectedQuantity,
                }).ToList());

                if (resultSave == false)
                {
                    MessageBox.Show("No se pudo crear la orden de entrega.");
                }
                else
                {
                    MessageBox.Show("Se registro la orden de entrega correctamente.");
                    this.LoadData();
                    return;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Ocurrio un error generando la orden de entrega.");
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

    public class ProductsModel
    {
        public string Codigo { get; set; }

        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public decimal UnitPrice { get; set; }

        public int SelectedQuantity { get; set; }
    }
}
