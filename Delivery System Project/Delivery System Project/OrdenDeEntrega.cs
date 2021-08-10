using DeliverySystem.Libreria.Librerias;
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
    public partial class OrdenDeEntrega : Form
    {
        OrdenDeEntregaLibreria ordenDeEntregaLibreria;
        FacturaLibreria factura;
        public OrdenDeEntrega()
        {
            this.factura = new FacturaLibreria();
            this.ordenDeEntregaLibreria = new OrdenDeEntregaLibreria();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrdenDeEntrega_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void LoadData()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = ordenDeEntregaLibreria.GetAll();
            this.dataGridView1.Columns[2].Width = 200;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                return;
            }
            try
            {
                var selectedRow = (DeliverySystem.Security.OrdenDeEntrega)dataGridView1.SelectedRows[0].DataBoundItem;
                var form = new OrdenDeEntregaDetalle(selectedRow.Codigo);
                form.Show();
                this.Close();
            }
            catch (Exception esc)
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ninguna fila seleccionada");
                return;
            }
            try
            {
                var codes = new List<DeliverySystem.Security.OrdenDeEntrega>();
                for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                {
                    var ordenDeEntrega = (DeliverySystem.Security.OrdenDeEntrega)this.dataGridView1.SelectedRows[i].DataBoundItem;
                    codes.Add(ordenDeEntrega);
                }

                codes = codes.Where(c => string.IsNullOrEmpty(c.CodigoFactura)).ToList();
                var result = this.factura.CrearFactura(codes);
                if (result)
                {
                    MessageBox.Show("Se facturo correctamente.");
                    this.LoadData();
                }
                else
                {
                    MessageBox.Show("No se pudo facturar.");
                }
            }
            catch (Exception es)
            {
                var a = es.Message;
            }
        }
    }
}
