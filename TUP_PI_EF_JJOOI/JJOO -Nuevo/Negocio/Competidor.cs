using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_EF_JJOOI.Negocio
{
    class Competidor
    {
        private int numero;
        private string nombre;
        private int disciplina;
        private string sexo;
        private DateTime fechaNacimiento;
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Disciplina
        {
            get { return disciplina; }
            set { disciplina = value; }
        }
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public Competidor()
        {
            this.numero = 0;
            this.nombre = "";
            this.disciplina = 0;
            this.sexo = "";
            this.fechaNacimiento = DateTime.Today;
        }
        public Competidor(int numero, string nombre, int disciplina, string sexo,DateTime fechaNacimiento)
        {
            this.numero = numero;
            this.nombre = nombre;
            this.disciplina = disciplina;
            this.sexo = sexo;
            this.fechaNacimiento = fechaNacimiento;
        }
        public override string ToString()
        {
            return numero + " - " + nombre;
        }
    }
}
