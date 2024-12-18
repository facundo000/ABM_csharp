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
        AccesoDatos accesoDatos= new AccesoDatos();
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
            dgvCompetidores.Columns.Clear();
            string consultaSql = "select numero, nombre, nombreEscuderia, year(fechaNacimiento) fecha_nac from Competidores c join Escuderias e on e.idEscuderia = c.escuderia ";

            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                consultaSql += $"where nombre like '%{txtNombre.Text}%'";
            }


            dgvCompetidores.Columns.Add("numero", "Numero");
            dgvCompetidores.Columns.Add("nombre", "Nombre");
            dgvCompetidores.Columns.Add("nombreEscuderia", "Escuderia");
            dgvCompetidores.Columns.Add("fecha_nac", "Edad");

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);
            foreach (DataRow dr in dt.Rows)
            {
                int edad = DateTime.Today.Year - Convert.ToInt32(dr["fecha_nac"]);


                dgvCompetidores.Rows.Add(dr["numero"], dr["nombre"], dr["nombreEscuderia"], edad);
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int numero = Convert.ToInt32(dgvCompetidores.CurrentRow.Cells[0].Value);
            FrmDetalle frmDetalle = new FrmDetalle(numero, Modo.Borrar);
            frmDetalle.ShowDialog();
        }
    }
}
