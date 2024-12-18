using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_EF_DGR
{
    class Inmueble
    {
        public int IdInmueble { get; set; }
        public string Titular { get; set; }
        public int Nomenclatura { get; set; }
        public int Tipo { get; set; }
        public int Categoria { get; set; }
        public double SupTerreno { get; set; }
        public double SupEdificada { get; set; }
        public double Valuacion { get; set; }

        public Inmueble()
        {
            IdInmueble = 0;
            Titular = string.Empty;
            Nomenclatura = 0;
            Tipo = 0;
            Categoria = 0;
            SupTerreno = 0;
            SupEdificada = 0;
            Valuacion = 0;
        }

        public Inmueble(int idInmueble, string titular, int nomenclatura, int tipo, int categoria, double supTerreno, double supEdificada, double valuacion)
        {
            IdInmueble = idInmueble;
            Titular = titular;
            Nomenclatura = nomenclatura;
            Tipo = tipo;
            Categoria = categoria;
            SupTerreno = supTerreno;
            SupEdificada = supEdificada;
            Valuacion = valuacion;
        }

        public override string ToString()
        {
            return Nomenclatura + " - " + Valuacion;
        }
    }
}
