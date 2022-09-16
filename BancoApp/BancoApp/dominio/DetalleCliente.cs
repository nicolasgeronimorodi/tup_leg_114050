using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.dominio
{
    internal class DetalleCliente
    {
        public Cuenta Cuenta { get; set; }

        public DetalleCliente(Cuenta cuenta)
        {
            Cuenta = cuenta;

        }




    }
}
