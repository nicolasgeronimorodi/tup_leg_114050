using BancoApp.servicios.implementaciones;
using BancoApp.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.servicios
{
    internal class ServiceFactoryImplementation:AbstractServiceFactory
    {
        public override IClienteService crearClienteService()
        {
            return new ClienteService();
        }
    }
}
