using Delivery_System_Project.Reportes.Forms;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

        }
        void btnUpdate_Click(object sender, EventArgs e) 
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            var form = new Login();
            form.MdiParent = this;
            form.FormClosed += Form_FormClosed;
            form.Show();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            toolStripStatusLabel1.Text += DeliverySystem.Libreria.Utilidades.GeneralInfo.Usuario;
        }

        void ob_ButtonClicked(object sender, EventArgs e)
        {
        }

        private void mostrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Cliente();
            form.MdiParent = this;
            form.Show();
        }

        private void crearClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CrearCliente();
            form.MdiParent = this;
            form.Show();
        }

        private void mostrarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Producto();
            form.MdiParent = this;
            form.Show();
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CrearProducto();
            form.MdiParent = this;
            form.Show();
        }

        private void mostrarOrdenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OrdenDeEntrega();
            form.MdiParent = this;
            form.Show();
        }

        private void crearOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Crearorden();
            form.MdiParent = this;
            form.Show();
        }

        private void mostrarFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Factura();
            form.MdiParent = this;
            form.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ReporteFacturas();
            form.MdiParent = this;
            form.Show();
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new ReporteProductos();
            form.MdiParent = this;
            form.Show();
        }

        private void facturasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new GFacturas();
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Usuario();
            form.MdiParent = this;
            form.Show();
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CrearUsuario();
            form.MdiParent = this;
            form.Show();
        }
    }
}
