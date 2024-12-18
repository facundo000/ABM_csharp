using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_EF_F1.Datos
{
    public class Parametro
    {
        private string nombre;
        private object valor;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public object Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public Parametro(string nombre, object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
