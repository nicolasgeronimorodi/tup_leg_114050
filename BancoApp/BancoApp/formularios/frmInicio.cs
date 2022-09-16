using BancoApp.formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoApp
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmCliente = new frmClientes();
            frmCliente.ShowDialog();
        }

        private void asociarClienteConCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmCuentas = new frmCuentas();
            frmCuentas.ShowDialog();
        }

        private void listarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Form frmRptListadoClientes = new frmRptListadoClientes();
            //frmRptListadoClientes.ShowDialog();
        }

        private void verCuentasPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmRptCuentaXClienteParam = new frmRptCuentaXClienteParam();
            frmRptCuentaXClienteParam.ShowDialog();
        }
    }
}
