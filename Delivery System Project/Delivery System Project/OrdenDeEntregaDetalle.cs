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
    public partial class OrdenDeEntregaDetalle : Form
    {
        OrdenDeEntregaLibreria OrdenDeEntrega;
        string code;
        public OrdenDeEntregaDetalle(string code)
        {
            this.OrdenDeEntrega = new OrdenDeEntregaLibreria();
            this.code = code;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new OrdenDeEntrega();
            form.Show();
            this.Close();
        }

        void LoadData()
        {
            this.dataGridView1.DataSource = null;
            var result = this.OrdenDeEntrega.GetDetailByCode(this.code).ToList();
            this.dataGridView1.DataSource = result;
            this.dataGridView1.Columns[0].Width = 150;
        }

        private void OrdenDeEntregaDetalle_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
    }
}
