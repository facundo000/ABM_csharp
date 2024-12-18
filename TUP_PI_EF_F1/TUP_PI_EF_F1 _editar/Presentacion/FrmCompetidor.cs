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
            string consultaSql = "select numero, nombre, nombreEscuderia, YEAR(fechaNacimiento) Año_nacimiento from Competidores c join Escuderias e on e.idEscuderia = c.escuderia ";

            if (txtNombre.Text != "")
            {
                consultaSql += $"where nombre like '%{txtNombre.Text}%'";
            }
            
            DataTable tabla = accesoDatos.ConsultarBD(consultaSql);
            dgvCompetidores.Columns.Clear();

            dgvCompetidores.Columns.Add("numero", "numero");
            dgvCompetidores.Columns.Add("nombre", "nombre");
            dgvCompetidores.Columns.Add("nombreEscuderia", "nombreEscuderia");
            dgvCompetidores.Columns.Add("Año_nacimiento", "Edad");


            
            foreach (DataRow fila in tabla.Rows)
            {
                int edad = DateTime.Today.Year - Convert.ToInt32(fila["Año_nacimiento"]);

                dgvCompetidores.Rows.Add(fila["numero"], fila["nombre"], fila["nombreEscuderia"], edad);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int numero = Convert.ToInt32(dgvCompetidores.CurrentRow.Cells[0].Value);
            FrmDetalle frmDetalle = new FrmDetalle(Modo.Editar, numero);
            frmDetalle.ShowDialog();
        }
    }
}
