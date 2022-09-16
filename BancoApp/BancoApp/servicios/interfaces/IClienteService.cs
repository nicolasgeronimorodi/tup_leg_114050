using BancoApp.dominio;
using BancoApp.servicios.implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.servicios.interfaces
{
    internal interface IClienteService
    {
        List<Cliente> getClientes();
        int insertCliente(Cliente cliente);
        bool logicDeleteCliente(Cliente cliente);
        bool confirmarAsociacion(ResumenCliente resumenCliente);
    }
}
