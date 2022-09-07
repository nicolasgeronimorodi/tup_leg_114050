using BancoAppV6.datos;
using BancoAppV6.dominio;
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
    public partial class frmCuentas : Form
    {
        ResumenCliente nuevoResumenCliente;
        DBHelper gestor;
        
        public frmCuentas()
        {
            InitializeComponent(); 
            nuevoResumenCliente = new ResumenCliente();
            gestor = new DBHelper();
        }
        private void frmCuentas_Load(object sender, EventArgs e)
        {
            cargarCboClientes();
        }

        private void cargarCboClientes()
        {
            DataTable table = gestor.ConsultaSQL("SP_consultarClientes");
            if (table != null)
            {
                cboClientes.DataSource = table;
                cboClientes.DisplayMember = "datosCliente";
                cboClientes.ValueMember = "nro_cliente";
                cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;

            }
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            string tipoCuenta;
            if (cboClientes.SelectedIndex == -1)
            {

                MessageBox.Show("Debe seleccionar un cliente");


            }

            Cuenta c = new Cuenta();
            c.Cbu = generarCbu();
            if (rbtCuentaCorriente.Checked)
            {
                c.TipoCuenta = 1;
                tipoCuenta = "Cuenta Corriente";
            }
            else
            {
                c.TipoCuenta = 2;
                tipoCuenta = "Caja de ahorro";
            }
         

           
 
            //DetalleCliente detalle = new DetalleCliente(c);
            nuevoResumenCliente.AgregarDetalle(c);
            dgvCuentas.Rows.Add(c.Cbu, tipoCuenta );
        }

        private int generarCbu()
        {
            Random generator = new Random();
            int rand = generator.Next(100000, 1000000);
            return rand;



        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
            guardarMaestro();
        }

        private void guardarMaestro()
        {
            Cliente cliente = new Cliente();
            cliente.NroCliente = Convert.ToInt32(cboClientes.SelectedValue);
            nuevoResumenCliente.Cliente = cliente;
            if (gestor.ConfirmarResumenCliente(nuevoResumenCliente))
            {
                MessageBox.Show("Se asociaron las cuentas al cliente", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar el cliente con las cuentas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
