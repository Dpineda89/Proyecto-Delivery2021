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
    public partial class FacturaDetalle : Form
    {
        string code;
        FacturaLibreria facturaLibreria;
        public FacturaDetalle(string code)
        {
            this.facturaLibreria = new FacturaLibreria();
            this.code = code;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FacturaDetalle_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void LoadData()
        {
            var result = this.facturaLibreria.GetByCode(code);
            if (result != null)
            {
                this.dataGridView1.DataSource = null;
                var details = result.OrdenesDeEntrega.Select(o => o.Detalles)
                    .SelectMany(d => d).GroupBy(d => d.CodigoProducto)
                    .Select(d => new { CodigoProducto = d.Key, Cantidad = d.Sum(dd => dd.Cantidad), Total = d.Sum(dd => dd.Total) });
                this.dataGridView1.DataSource = details.ToList();
                this.dataGridView1.Columns[0].Width = 150;
                this.dataGridView1.Columns[2].Width = 150;
                this.textBox1.Text = result.Code;
                this.textBox2.Text = result.CreatedDate.ToString("yyyy/MM/dd");
            }
            else
            {
                MessageBox.Show($"No se encontro la factura con el codigo [{code}].");
            }
        }
    }
}
