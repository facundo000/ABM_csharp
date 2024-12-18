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
        AccesoDatos acceso = new AccesoDatos();
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
            string consultaGrilla = "select numero, nombre, disciplina, sexo, fechaNacimiento from Disciplinas d join Competidores c on d.idDisciplina = c.disciplina ";
            if (txtNombre.Text != "")
            {
                consultaGrilla += $"where nombre like '%{txtNombre.Text}%'";
            }

            dgvCompetidores.Columns.Clear();

            dgvCompetidores.Columns.Add("numero", "Numero");
            dgvCompetidores.Columns.Add("nombre", "Nombre");
            dgvCompetidores.Columns.Add("disciplina", "Disciplina");
            dgvCompetidores.Columns.Add("sexo", "Sexo");
            dgvCompetidores.Columns.Add("fechaNacimiento", "Fecha de Nacimiento");

            dgvCompetidores.Columns["numero"].Visible = false;


            DataTable dt = acceso.ConsultarBD(consultaGrilla);
            foreach (DataRow dr in dt.Rows) {
                dgvCompetidores.Rows.Add(dr["numero"], dr["nombre"], dr["disciplina"], dr["sexo"], dr["fechaNacimiento"]);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = Convert.ToInt32(dgvCompetidores.CurrentRow.Cells[0].Value);
                FrmDetalle frmDetalle = new FrmDetalle(numero, Modo.Editar);
                frmDetalle.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar un registro", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
