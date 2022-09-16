using BancoApp.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.dominio
{
    internal class Cuenta:ICuenta
    {
        //public int NroCuenta { get; set; }
        public int Cbu { get; set; }

        public double Saldo { get; set; }

        public int TipoCuenta { get; set; }
        public DateTime UltimoMov { get; set; }


        public Cuenta(int cbu, double saldo, int tipoCuenta, DateTime ultimoMov)
        {

            Cbu = cbu;
            Saldo = saldo;
            TipoCuenta = tipoCuenta;
            UltimoMov = ultimoMov;

        }
        public Cuenta()
        {

            Cbu = 0;
            Saldo = 0;
            TipoCuenta = 1;
            UltimoMov = DateTime.MinValue;
        }


        public override string ToString()
        {
            return " CBU: " + Cbu;
        }




    }
}
