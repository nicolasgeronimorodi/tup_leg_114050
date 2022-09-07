using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoAppV6.frontend
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmClientes = new frmClientes();
            frmClientes.ShowDialog();
        }

        private void asociarClienteConCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmCuentas = new frmCuentas();
            frmCuentas.ShowDialog();
        }
    }
}
