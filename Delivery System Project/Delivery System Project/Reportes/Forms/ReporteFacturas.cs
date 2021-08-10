using Delivery_System_Project.Reportes.CrystalReports;
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

namespace Delivery_System_Project.Reportes.Forms
{
    public partial class ReporteFacturas : Form
    {
        FacturaLibreria facturaLibreria;
        public ReporteFacturas()
        {
            InitializeComponent();
            this.facturaLibreria = new FacturaLibreria();
            var facturas = this.facturaLibreria.GetAllToReport().ToList();
            var source = new BindingSource();
            source.DataSource = facturas;
            var reporte = new CrystalReporteFacturas();
            reporte.SetDataSource(source);
            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
