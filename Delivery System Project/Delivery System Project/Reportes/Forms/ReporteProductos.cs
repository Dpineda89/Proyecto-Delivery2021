using Delivery_System_Project.Reportes.CrystalReports;
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
    public partial class ReporteProductos : Form
    {
        ProductoLibreria productoLibreria;
        public ReporteProductos()
        {
            InitializeComponent();
            this.productoLibreria = new ProductoLibreria();
            var productos = this.productoLibreria.GetAll().ToList();
            var source = new BindingSource();
            source.DataSource = productos;
            var reporte = new CrystalReporteProductos();
            reporte.SetDataSource(source);
            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
