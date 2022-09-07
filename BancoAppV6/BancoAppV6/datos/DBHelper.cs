using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BancoAppV6.dominio;

namespace BancoAppV6.datos
{
    class DBHelper
    {
       private SqlConnection cnn;

        public DBHelper()
        {
             cnn = new SqlConnection(@"Data Source=DESKTOP-52C9NV2;Initial Catalog=BancoV2;Integrated Security=True");
        }

        public DataTable ConsultaSQL(string strSql)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();

            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strSql;
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();

            return tabla;
        }


        public int EjecutarSQL(string strSql, CommandType type)
        {
            int afectadas = 0;
            SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-52C9NV2;Initial Catalog=BancoV2;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = strSql;
            afectadas = cmd.ExecuteNonQuery();
            cnn.Close();

            return afectadas;


        }
        public int EjecutarSQL(string strSql, CommandType type, List<Parametro> parametros)
        {
            int afectadas;
            SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-52C9NV2;Initial Catalog=BancoV2;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = strSql;
            cmd.CommandType = type;
            cmd.Parameters.Clear();
            foreach(Parametro p in parametros)
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





























    }
}
