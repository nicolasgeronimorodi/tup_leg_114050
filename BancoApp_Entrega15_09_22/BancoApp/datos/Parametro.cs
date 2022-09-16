using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.datos
{
    internal class Parametro
    {

        public Parametro(string nombre, Object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
        public string Nombre { get; set; }
        public Object Valor { get; set; }

        public Parametro(string nombre)
        {
            Nombre = nombre;
        }



    }
}
