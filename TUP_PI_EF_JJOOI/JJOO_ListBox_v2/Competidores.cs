using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJOO_ListBox
{
    public class Competidores
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Disciplina { get; set; }
        public char Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Competidores()
        {
            Codigo = 0;
            Nombre = string.Empty;
            Disciplina = 0;
            Sexo = ' ';
            FechaNacimiento = DateTime.Today;
        }

        public Competidores(int codigo, string nombre, int disciplina, char sexo, DateTime fechaNacimiento)
        {
            Codigo = codigo;
            Nombre = nombre;
            Disciplina = disciplina;
            Sexo = sexo;
            FechaNacimiento =fechaNacimiento;
        }
    }
}
