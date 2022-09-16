using BancoApp.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.dominio
{
    internal class ResumenCliente:IResumenCliente
    {
        public Cliente Cliente { get; set; }
        //public List<DetalleCliente> Detalles { get; set; }
        public List<Cuenta> Cuentas { get; set; }
        public ResumenCliente()
        {
            // Detalles = new List<DetalleCliente>();
            Cuentas = new List<Cuenta>();
        }

        public void AgregarDetalle(Cuenta cuenta)
        {
            //Detalles.Add(detalle);
            Cuentas.Add(cuenta);
        }

        public void QuitarDetalle(int indice)
        {
            //Detalles.RemoveAt(indice);
            Cuentas.RemoveAt(indice);
        }





    }
}
