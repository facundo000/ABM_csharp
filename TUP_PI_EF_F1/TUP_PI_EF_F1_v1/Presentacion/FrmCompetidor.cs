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
            string consultaSql = "select numero, nombre, Year(fechaNacimiento) as anioNac from Competidores ";

            string textBox = txtNombre.Text;
            if(textBox != "")
            {
                consultaSql += $"where nombre like '%{textBox}%'";
            }


            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            dgvCompetidores.Columns.Clear();

            dgvCompetidores.Columns.Add("numero", "Numero");
            dgvCompetidores.Columns.Add("nombre", "Nombre");
            dgvCompetidores.Columns.Add("anioNac", "Edad");


            foreach (DataRow fila in dt.Rows)
            {
                int anio = 2024 - Convert.ToInt32( fila["anioNac"]);

                dgvCompetidores.Rows.Add(fila["numero"], fila["nombre"], anio);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalle detalle = new FrmDetalle();
            detalle.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Estas seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }
    }
}
