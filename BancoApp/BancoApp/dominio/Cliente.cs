using BancoApp.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.dominio
{
    internal class Cliente : ICliente
    {
        public int NroCliente { get; set; }


        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }



        /*
        public Cliente(int numeroCliente, string nombre, string apellido, int dni)
        {
            NroCliente = numeroCliente+;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
        }
        */
        public Cliente(int nroCliente, string nombre, string apellido, int dni)
        {
            NroCliente = nroCliente;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
        }

        public Cliente()
        {
            NroCliente = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Dni = 0;

        }




        public override string ToString()
        {
            return "Nro. Cliente: " + NroCliente + " Nombre: " + Nombre + " Apellido: " + Apellido + " DNI: " + Dni;
        }














    }
}
