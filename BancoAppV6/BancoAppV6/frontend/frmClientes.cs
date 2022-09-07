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
    public partial class frmClientes : Form
    {
        DBHelper gestor;
        List<Cliente> clientes;
        public frmClientes()
        {
            InitializeComponent();
            gestor=new DBHelper();
            clientes=new List<Cliente>();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            if (validarCamposCliente())
            {
                insertarCliente();
            }
        }

        private bool validarCamposCliente()
        {

            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Ingresar un nombre");
                return false;
            }
            if (txtApellido.Text == string.Empty)
            {
                MessageBox.Show("Ingresar un apellido");
                return false;
            }
            if (txtDni.Text == string.Empty)
            {
                MessageBox.Show("Ingresar un dni");
                return false;
            }
            return true;

        }
        private void insertarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Dni = Convert.ToInt32(txtDni.Text);

            List<Parametro> parametros = new List<Parametro>();

            parametros.Add(new Parametro("@nombre", cliente.Nombre));
            parametros.Add(new Parametro("@apellido", cliente.Apellido));
            parametros.Add(new Parametro("@dni", cliente.Dni));

            if (gestor.EjecutarSQL("SP_insertarCliente", CommandType.StoredProcedure, parametros) > 0)
            {
                MessageBox.Show("Se agregó un nuevo cliente");
                cargarClientes();
            }

        }

        private void cargarClientes()
        {
            clientes.Clear();
            dgvClientes.Rows.Clear();
            DataTable tabla = new DataTable();
            tabla = gestor.ConsultaSQL("SP_consultarClientes");



            foreach (DataRow r in tabla.Rows)

            {
                Cliente cliente = new Cliente();
                cliente.NroCliente = Convert.ToInt32(r[0]);
                cliente.Nombre = Convert.ToString(r[1]);
                cliente.Apellido = Convert.ToString(r[2]);
                cliente.Dni = Convert.ToInt32(r[3]);    


                dgvClientes.Rows.Add(r[0], r[1], r[2], r[3]);
                clientes.Add(cliente);
            }
            
           

          
          
        }

        private bool registrarBajaLogicaCliente(int nroCliente)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.NroCliente == nroCliente)
                {
                    if (gestor.ConfirmarBajaLogicaCliente(cliente)) 
                    { return true;
                    }
                    
                }
            }return false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int nroCliente =Convert.ToInt32( dgvClientes.CurrentRow.Cells[0].Value);
            if (registrarBajaLogicaCliente(nroCliente))
            {
                MessageBox.Show("Se dio de baja el cliente");
            }
            else
            {
                MessageBox.Show("Error. No se pudo procesar la baja del cliente");
            }

            
        }
    }
}
