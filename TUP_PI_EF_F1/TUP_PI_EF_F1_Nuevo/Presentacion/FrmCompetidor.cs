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
            string consultaSql = "select numero, nombre, nombrePais, YEAR(fechaNacimiento) as anio_nac from Competidores c join Paises p on p.idPais = c.pais ";

            if (txtNombre.Text != "")
            {
                consultaSql += $"where nombre like '%{txtNombre.Text}%'";
            }

            
            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            dgvCompetidores.Columns.Clear();

            dgvCompetidores.Columns.Add("numero", "Numero");
            dgvCompetidores.Columns.Add("nombre", "Nombre");
            dgvCompetidores.Columns.Add("nombrePais", "Pais");
            dgvCompetidores.Columns.Add("anio_nac", "Edad");

            dgvCompetidores.Columns["numero"].Visible = false;

            foreach (DataRow fila in dt.Rows)
            {
                int edad = DateTime.Today.Year - Convert.ToInt32(fila["anio_nac"]);

                dgvCompetidores.Rows.Add(fila["numero"], fila["nombre"], fila["nombrePais"], edad);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {            
            FrmDetalle frmDetalle = new FrmDetalle();
            frmDetalle.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿Estas seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
