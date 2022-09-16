using BancoApp.datos;
using BancoApp.dominio;
using BancoApp.servicios;
using BancoApp.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoApp.formularios
{
    public partial class frmClientes : Form
    {
        
        //List<Cliente> clientes;
        private IClienteService oServicio; //gestor de servicios

        public frmClientes()
        {
            InitializeComponent();
            //clientes=new List<Cliente>();
            oServicio = new ServiceFactoryImplementation().crearClienteService();
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

        private void insertarCliente()
        {
            /*
            Cliente cliente = new Cliente();
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Dni = Convert.ToInt32(txtDni.Text);

            List<Parametro> parametros = new List<Parametro>();

            parametros.Add(new Parametro("@nombre", cliente.Nombre));
            parametros.Add(new Parametro("@apellido", cliente.Apellido));
            parametros.Add(new Parametro("@dni", cliente.Dni));

            if (HelperDAO.obtenerInstancia().ejecutarSQL("SP_insertarCliente", CommandType.StoredProcedure, parametros) > 0)
            {
                MessageBox.Show("Se agregó un nuevo cliente");
                cargarClientes();
            } */



            Cliente cliente = new Cliente();
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Dni = Convert.ToInt32(txtDni.Text);


            if(oServicio.insertCliente(cliente)>0)
                MessageBox.Show("Se agregó un nuevo cliente");
                cargarClientes();



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





        private void cargarClientes()
        {
            /* 
            clientes.Clear();
            dgvClientes.Rows.Clear();
            DataTable tabla = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@esActivo", 1));
            tabla = HelperDAO.obtenerInstancia().consultaSQL("SP_consultarClientes", parametros);
            
            foreach(DataRow r in tabla.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.NroCliente = Convert.ToInt32(r[0]);
                cliente.Nombre = Convert.ToString(r[1]);
                cliente.Apellido = Convert.ToString(r[2]);
                cliente.Dni = Convert.ToInt32(r[3]);


                dgvClientes.Rows.Add(r[0], r[1], r[2], r[3]);
                clientes.Add(cliente);
            }


            */


            dgvClientes.Rows.Clear();
            List<Cliente> clientes;
            clientes = new List<Cliente>();
            clientes=oServicio.getClientes();
            foreach (Cliente cliente in clientes)
            {
                dgvClientes.Rows.Add(cliente.NroCliente, cliente.Nombre, cliente.Apellido);
            }

            }

        private bool registrarBajaLogicaCliente(int nroCliente)
        {
            /*
            foreach (Cliente cliente in clientes)
            {
                if (cliente.NroCliente == nroCliente)
                {
                    if (HelperDAO.obtenerInstancia().ConfirmarBajaLogicaCliente(cliente))
                    {
                        return true;
                    }

                }
            }
            return false;
        */

            List<Cliente> clientes = new List<Cliente>();
            foreach (DataRow row in dgvClientes.Rows)
            {
                Cliente c = new Cliente();
                c.NroCliente = Convert.ToInt32(row[0]);
                clientes.Add(c);
            }

            foreach(Cliente cliente in clientes)
            {
                if(cliente.NroCliente==nroCliente)
                    if(oServicio.logicDeleteCliente(cliente))
                    {
                        return true;
                    }

            }
            return false;


        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int nroCliente = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
            if (registrarBajaLogicaCliente(nroCliente))
            {
                MessageBox.Show("Se dio de baja el cliente");
            }
            else
            {
                MessageBox.Show("Error. No se pudo procesar la baja del cliente");
            }
        }





        ///### NO TOCAR ESTE EVENTO
        private void btnAltaCliente_Click_1(object sender, EventArgs e)
        {

        }
        //// ### NO TOCAR ESTE EVENTO
    }
}
