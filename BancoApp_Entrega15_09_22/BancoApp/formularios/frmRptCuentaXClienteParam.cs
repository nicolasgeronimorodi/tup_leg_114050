using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BancoApp.datos;

namespace BancoApp.formularios
{
    public partial class frmRptCuentaXClienteParam : Form
    {
        public frmRptCuentaXClienteParam()
        {
            InitializeComponent();
        }

        private void frmRptCuentaXClienteParam_Load(object sender, EventArgs e)
        {

           // this.reportViewer1.RefreshReport();
        }

        private void btnIngresarDni_Click(object sender, EventArgs e)
        {
            cargarDataTable();

        }

        private void cargarDataTable()
        {
            int dni;
            dni = Convert.ToInt32(txtDni.Text);

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@dni", dni));
            DataTable tabla = new DataTable();
            
            tabla=HelperDAO.obtenerInstancia().consultaSQL("SP_consultarCuentasXCliente", parametros);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", tabla)); ///el DataSet1 es el nombre del data set usado al crear el reporte
            this.reportViewer1.RefreshReport();






        }
    }
}
