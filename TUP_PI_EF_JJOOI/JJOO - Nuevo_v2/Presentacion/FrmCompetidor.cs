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
using TUP_PI_EF_JJOOI.Datos;


namespace TUP_PI_EF_JJOOI.Presentacion
{
    public partial class FrmCompetidor : Form
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        public FrmCompetidor()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            string consultaSql = "select numero, nombre, nombreDisciplina, fechaNacimiento from Competidores c join Disciplinas d on d.idDisciplina =c.disciplina ";

            if (txtNombre.Text != "")
            {
                consultaSql += $"where nombre like '%{txtNombre.Text}%'";
            }

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);
            dgvCompetidores.Columns.Clear();

            dgvCompetidores.Columns.Add("numero", "Numero");
            dgvCompetidores.Columns.Add("nombre", "Nombre");
            dgvCompetidores.Columns.Add("nombreDisciplina", "Disciplina");
            dgvCompetidores.Columns.Add("fechaNacimiento", "fecha de Nacimiento");

            dgvCompetidores.Columns["numero"].Visible = false;

            foreach (DataRow fila in dt.Rows)
            {
                dgvCompetidores.Rows.Add(fila["numero"], fila["nombre"], fila["nombreDisciplina"], fila["fechaNacimiento"]);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalle frm = new FrmDetalle();
            frm.ShowDialog();
        }
    }
}
