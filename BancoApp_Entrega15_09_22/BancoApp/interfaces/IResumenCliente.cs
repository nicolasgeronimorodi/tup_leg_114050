using BancoApp.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.interfaces
{
    internal interface IResumenCliente
    {
        void AgregarDetalle(Cuenta cuenta);
        void QuitarDetalle(int indice);


    }
}
