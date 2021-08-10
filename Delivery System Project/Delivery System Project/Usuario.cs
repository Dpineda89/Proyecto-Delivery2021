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
    public partial class Usuario : Form
    {
        UsuarioLibreria usuarioLibreria;

        public Usuario()
        {
            InitializeComponent();
            this.usuarioLibreria = new UsuarioLibreria();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }


        void LoadData()
        {
            this.dataGridView1.DataSource = null;
            var usuarios = usuarioLibreria.GetAll().ToList();
            this.dataGridView1.DataSource = usuarios;
            this.dataGridView1.Columns[0].Width = 200;
            this.dataGridView1.Columns[1].Width = 200;
            this.dataGridView1.Columns[2].Visible = false;
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
                    var usuario = (DeliverySystem.Libreria.Model.Usuario)this.dataGridView1.SelectedRows[i].DataBoundItem;
                    codes.Add(usuario.Id.ToString());
                }


                bool allDeleted = true;
                foreach (var item in codes)
                {
                    var result = this.usuarioLibreria.Eliminar(System.Convert.ToInt32(item));
                    if (!result)
                    {
                        allDeleted = false;
                    }
                }

                if (!allDeleted)
                {
                    MessageBox.Show("Algun(nos) usuario(s) no se pudieron eliminar");
                }
                else
                {
                    MessageBox.Show("El(los) usuario(s) se eliminaron correctamente");
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
