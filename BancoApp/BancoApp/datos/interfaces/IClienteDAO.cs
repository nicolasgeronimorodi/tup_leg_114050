using BancoApp.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.datos.interfaces
{
    internal interface IClienteDAO
    {
        List<Cliente> getClientes();

        int insertCliente(Cliente cliente);

        bool logicDeleteCliente(Cliente cliente);

        bool confirmarAsociacion(ResumenCliente resumenCliente);






    }
}
