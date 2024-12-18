﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJOO_ListBox.Datos
{
    public class Paramettro
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
        public Paramettro(string nombre, object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }

    }
}