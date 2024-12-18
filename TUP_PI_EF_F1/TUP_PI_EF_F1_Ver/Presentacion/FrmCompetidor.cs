using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUP_PI_EF_F1.Datos;

//CURSO – LEGAJO – APELLIDO – NOMBRE


namespace TUP_PI_EF_F1.Presentacion
{    
    public partial class FrmCompetidor : Form
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        public FrmCompetidor()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            string consultaSql = "select numero, nombre, nombreEscuderia, YEAR(fechaNacimiento) as anioNac from Competidores c join Escuderias e on e.idEscuderia = c.escuderia ";

            if (txtNombre.Text != "")
            {
                consultaSql += $"where nombre like '%{txtNombre.Text}%'";
            }

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            dgvCompetidores.Columns.Clear();

            dgvCompetidores.Columns.Add("numero", "Numero");
            dgvCompetidores.Columns.Add("nombre", "Nombre");
            dgvCompetidores.Columns.Add("nombreEscuderia", "Escuderia");
            dgvCompetidores.Columns.Add("anioNac", "Edad");

            //dgvCompetidores.Columns["numero"].Displayed = true;

            foreach (DataRow row in dt.Rows)
            {
                int anioActual = DateTime.Today.Year;
                int edad = anioActual - Convert.ToInt32(row["anioNac"]);

                dgvCompetidores.Rows.Add(row["numero"], row["nombre"], row["nombreEscuderia"], edad);
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(dgvCompetidores.CurrentRow.Cells[0].Value);
            FrmDetalle frmDetalle = new FrmDetalle(Modo.Ver, codigo);
            frmDetalle.ShowDialog();
        }
    }
}
