using JJOO_ListBox.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

//CURSO – LEGAJO – APELLIDO – NOMBRE
//1w2 - 412304- Guzman Olariaga - Facundo Nicolas
namespace JJOO_ListBox
{
    public partial class FrmInmuebles : Form
    {
        AcceesoDatos accesoDatos = new AcceesoDatos();
        public FrmInmuebles()
        {
            InitializeComponent();
        }
 

        private void CargarLista()
        {
            string consultaSql = "select numero, nombre, disciplina, fechaNacimiento from Competidores";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            lstCompetidores.Items.Clear();
            foreach (DataRow fila in dt.Rows)
            { 
                int disciplina = Convert.ToInt32(fila["disciplina"]);
                string disciplinaStr;
                switch (disciplina)
                {
                    case 1:
                        disciplinaStr = "Natacion";
                        break;
                    case 2:
                        disciplinaStr = "Esgrima";
                        break;
                    case 3:
                        disciplinaStr = "Atletismo";
                        break;
                    case 4:
                        disciplinaStr = "Boxeo";
                        break;
                    case 5:
                        disciplinaStr = "Yudo";
                        break;
                    default:
                        disciplinaStr = "Desconicido";
                        break;
                }


                string itemText = $"Nombre: {fila["nombre"]} - Disciplina: {disciplinaStr} - FechaNacimiento: {fila["fechaNacimiento"]}";

                lstCompetidores.Items.Add(itemText);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }       

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void FrmInmuebles_Load(object sender, EventArgs e)
        {
            CargarLista();
        }
    }
}
