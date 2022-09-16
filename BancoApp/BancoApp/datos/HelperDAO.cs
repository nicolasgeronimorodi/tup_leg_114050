using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BancoApp.dominio;


namespace BancoApp.datos 
{
    internal class HelperDAO {
    
        private static HelperDAO instancia;
        private string cadenaConexion;

        private HelperDAO()
        {
            cadenaConexion = Properties.Resources.cnnString;

        }

        public static HelperDAO obtenerInstancia()
        {
            if(instancia== null)
                instancia= new HelperDAO();
            return instancia;
        }

        public DataTable consultaSQL(string consulta)
        {
            SqlConnection cnn=new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = consulta;
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public DataTable consultaSQL(string consulta, List<Parametro> parametros)
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = consulta;
            cmd.Parameters.Clear();
            foreach (Parametro parametro in parametros)
            {
                cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
            }
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }





        public int ejecutarSQL(string consulta, CommandType type, List<Parametro> parametros)
        {
            int afectadas;
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = consulta;
            cmd.CommandType = type;
            cmd.Parameters.Clear();
            foreach (Parametro p in parametros)
            {
                cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
             



            afectadas = cmd.ExecuteNonQuery();
            cnn.Close();

            return afectadas;


        }



        public bool ConfirmarResumenCliente(ResumenCliente resumenCliente)
        {
            bool ok = true;
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trs = null;

            try
            {
                cnn.Open();
                trs = cnn.BeginTransaction(); //la conexion avisa que está bajo transaccion
                cmd.Transaction = trs;
                cmd.Connection = cnn;
                cmd.CommandText = "SP_insertarResumenCliente";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@nro_cliente", resumenCliente.Cliente.NroCliente);
                cmd.ExecuteNonQuery();

                SqlCommand cmdDetalle;
                //int detalleNro = 1;
                foreach (Cuenta item in resumenCliente.Cuentas)
                {
                    cmdDetalle = new SqlCommand();
                    cmdDetalle.Connection = cnn;
                    cmdDetalle.Transaction = trs;
                    cmdDetalle.CommandText = "SP_insertarCuenta";
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@nro_cliente", resumenCliente.Cliente.NroCliente);
                    cmdDetalle.Parameters.AddWithValue("@id_tipoCuenta", item.TipoCuenta);
                    cmdDetalle.Parameters.AddWithValue("@cbu", item.Cbu);
                    cmdDetalle.ExecuteNonQuery();

                }
                trs.Commit();
            }
            catch (Exception)
            {
                trs.Rollback();
                ok = false;

            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return ok;

        }


        public bool ConfirmarBajaLogicaCliente(Cliente cliente)
        {
            bool ok = true;
             SqlConnection cnn = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trs = null;

            try
            {
                cnn.Open();
                trs = cnn.BeginTransaction(); //la conexion avisa que está bajo transaccion
                cmd.Transaction = trs;
                cmd.Connection = cnn;
                cmd.CommandText = "SP_registrarBajaCliente";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@nro_cliente", cliente.NroCliente);
                cmd.ExecuteNonQuery();

                SqlCommand cmdDetalle;


                cmdDetalle = new SqlCommand();
                cmdDetalle.Connection = cnn;
                cmdDetalle.Transaction = trs; //la transaccion aplica sobre la conexion y el comando
                cmdDetalle.CommandText = "UPDATE CUENTAS SET esActiva=0 WHERE nro_cliente=@nro_cliente";
                cmdDetalle.CommandType = CommandType.Text;
                cmdDetalle.Parameters.AddWithValue("@nro_cliente", cliente.NroCliente);

                cmdDetalle.ExecuteNonQuery();


                trs.Commit();
            }
            catch (Exception)
            {
                trs.Rollback();
                ok = false;

            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return ok;

        }


        /*
         * La idea ahora sería parametrizar una operación de confirmacion maestro-detalle
         * debido a que los metodos anteriores ConfirmarBajaLogicaCliente() y ConfirmarResumenCliente()
         * son demasiado específicos y no corresponden en el HelperDAO.
         */



       

        public bool confirmarTransaccion(CommandType commandType, string spMaestro, string spDetalle, List<Parametro> parametrosMaestro, List<Parametro> parametrosDetalle )
        {
            bool ok = true;
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trs = null;

            try
            {
                cnn.Open();
                trs = cnn.BeginTransaction(); 
                cmd.Transaction = trs;
                cmd.Connection = cnn;
                cmd.CommandType = commandType;
                cmd.CommandText = spMaestro;
                cmd.Parameters.Clear();
                foreach (Parametro parametro in parametrosMaestro)
                {
                    cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                }
                cmd.ExecuteNonQuery();


                SqlCommand cmdDetalle = new SqlCommand();
                cmdDetalle.Connection = cnn;
                cmdDetalle.Transaction = trs; //la transaccion aplica sobre la conexion y el comando
                cmdDetalle.CommandType = commandType;
                cmdDetalle.CommandText = spDetalle;
                cmdDetalle.Parameters.Clear();
                foreach (Parametro parametro in parametrosDetalle)
                {
                    cmdDetalle.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                }
                cmdDetalle.ExecuteNonQuery();
                trs.Commit();
            }
            catch (Exception)
            {

                trs.Rollback();
                ok = false;

            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return ok;

        }



















    }
}
