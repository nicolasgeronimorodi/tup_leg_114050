using BancoApp.datos.interfaces;
using BancoApp.dominio;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.datos.implementaciones
{
    internal class ClienteDAO:IClienteDAO
    {
        public List<Cliente> getClientes() 
        {
            DataTable tabla=new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            List<Cliente> clientes = new List<Cliente>();
            parametros.Add(new Parametro("@esActivo", 1));
            tabla = HelperDAO.obtenerInstancia().consultaSQL("SP_consultarClientes", parametros);
            foreach (DataRow r in tabla.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.NroCliente = Convert.ToInt32(r[0]);
                cliente.Nombre = Convert.ToString(r[1]);
                cliente.Apellido = Convert.ToString(r[2]);
                cliente.Dni = Convert.ToInt32(r[3]);


                
                clientes.Add(cliente);
            }

            return clientes;
        }


        public int insertCliente(Cliente cliente)
        {
            List <Parametro> parametros= new List<Parametro>();
            parametros.Add(new Parametro("@nombre", cliente.Nombre));
            parametros.Add(new Parametro("@apellido", cliente.Apellido));
            parametros.Add(new Parametro("@dni", cliente.Dni));

            return HelperDAO.obtenerInstancia().ejecutarSQL("SP_insertarCliente", CommandType.StoredProcedure, parametros);
               
        }

        public bool logicDeleteCliente(Cliente cliente)
        {

           List<Parametro> parametrosMaestro = new List<Parametro>();
           parametrosMaestro.Add(new Parametro("@nro_cliente", cliente.NroCliente));

            List<Parametro> parametrosDetalle = new List<Parametro>();
            parametrosDetalle.Add(new Parametro("@nro_cliente", cliente.NroCliente));




            return HelperDAO.obtenerInstancia().confirmarTransaccion(CommandType.StoredProcedure, "SP_registrarBajaCliente", "SP_registrarBajaCuenta", parametrosMaestro, parametrosDetalle);

        }

        public bool confirmarAsociacion(ResumenCliente resumenCliente)
        {
           return HelperDAO.obtenerInstancia().ConfirmarResumenCliente(resumenCliente);

        }














    }
}
