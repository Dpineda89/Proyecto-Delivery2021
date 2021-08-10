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
    public partial class Factura : Form
    {
        FacturaLibreria facturaLibreria;
        public Factura()
        {
            this.facturaLibreria = new FacturaLibreria();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                return;
            }
            try
            {
                var selectedRow = (DeliverySystem.Libreria.Model.Factura)dataGridView1.SelectedRows[0].DataBoundItem;
                var form = new FacturaDetalle(selectedRow.Code);
                form.Show();
                this.Close();
            }
            catch (Exception esc)
            {
                return;
            }
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void LoadData()
        {
            var result = this.facturaLibreria.GetAll();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = result.ToList();
            this.dataGridView1.Columns[0].Width = 150;
            this.dataGridView1.Columns[1].Width = 150;
            this.dataGridView1.Columns[2].Visible = false;
            this.dataGridView1.Columns[3].Width = 150;
        }
    }

}
