using BancoApp.datos;
using BancoApp.dominio;
using BancoApp.servicios;
using BancoApp.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BancoApp.formularios
{
    public partial class frmCuentas : Form
    {
        
        ResumenCliente nuevoResumenCliente;

        private IClienteService oServicioCliente; //gestor de servicios de cliente para cargarCboClientes


        public frmCuentas()
        {
            InitializeComponent();
            nuevoResumenCliente = new ResumenCliente();
            oServicioCliente = new ServiceFactoryImplementation().crearClienteService();

        }

        private void frmCuentas_Load(object sender, EventArgs e)
        {
            cargarCboClientes();
        }

        private void cargarCboClientes()
        {
            /*
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@esActivo", 1));
            DataTable tabla = HelperDAO.obtenerInstancia().consultaSQL("SP_consultarClientes", parametros);
            if (tabla != null)
            {
                cboClientes.DataSource = tabla;
                cboClientes.DisplayMember = "datosCliente";
                cboClientes.ValueMember = "nro_cliente";
                cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            */

            List<Cliente> clientes = new List<Cliente>();
            clientes = oServicioCliente.getClientes();
            cboClientes.DataSource = clientes;
            cboClientes.DisplayMember = "Apellido";
            cboClientes.ValueMember = "NroCliente";
            cboClientes.DropDownStyle=ComboBoxStyle.DropDownList;







        }


        private void agregarCuenta()
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
            nuevoResumenCliente.AgregarDetalle(c);
            dgvCuentas.Rows.Add(c.Cbu, tipoCuenta);
        }

        private int generarCbu()
        {
            Random generator = new Random();
            int rand = generator.Next(100000, 1000000);
            return rand;
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            agregarCuenta();
        }


        private bool guardarMaestro()
        {
            /*
            Cliente cliente = new Cliente();
            cliente.NroCliente = Convert.ToInt32(cboClientes.SelectedValue);
            nuevoResumenCliente.Cliente = cliente;
            if (HelperDAO.obtenerInstancia().ConfirmarResumenCliente(nuevoResumenCliente))
            {
                MessageBox.Show("Se asociaron las cuentas al cliente", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar el cliente con las cuentas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            */
            Cliente cliente = new Cliente();
            cliente.NroCliente = Convert.ToInt32(cboClientes.SelectedValue);
            nuevoResumenCliente.Cliente = cliente;

            return oServicioCliente.confirmarAsociacion(nuevoResumenCliente);





        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
           if( guardarMaestro())
            {
                MessageBox.Show("Se asociaron las cuentas al cliente", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();

            }else
            {
                MessageBox.Show("ERROR. No se pudo registrar el cliente con las cuentas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }







    }
}
