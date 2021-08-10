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
    public partial class Cliente : Form
    {
        ClientLibreria clientLibreria;
        public Cliente()
        {
            this.clientLibreria = new ClientLibreria();
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void LoadData()
        {
            this.dataGridView1.DataSource = null;
            var clients = clientLibreria.GetAll().ToList();
            this.dataGridView1.DataSource = clients;
            this.dataGridView1.Columns[0].Width = 200;
            this.dataGridView1.Columns[1].Width = 200;
            this.dataGridView1.Columns[5].Width = 200;
            this.dataGridView1.Columns[6].Width = 500;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    var client = (DeliverySystem.Security.Client)this.dataGridView1.SelectedRows[i].DataBoundItem;
                    codes.Add(client.Identidad.ToString());
                }


                bool allDeleted = true;
                foreach (var item in codes)
                {
                    var result = this.clientLibreria.Eliminar(item.ToString());
                    if (!result)
                    {
                        allDeleted = false;
                    }
                }

                if (!allDeleted)
                {
                    MessageBox.Show("Algun(nos) cliente(s) no se pudieron eliminar");
                }
                else
                {
                    MessageBox.Show("El(los) cliente(s) se eliminaron correctamente");
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