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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string consultaSql = "select numero,nombre, nombreDisciplina, fechaNacimiento from Competidores c join Disciplinas d on d.idDisciplina = c.disciplina ";

            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                consultaSql += $"where nombre like '%{txtNombre.Text}%'";
            }

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);
            dgvCompetidores.Columns.Clear();

            dgvCompetidores.Columns.Add("numero", "numero");

            dgvCompetidores.Columns.Add("nombre", "Nombre");
            dgvCompetidores.Columns.Add("nombreDisciplina", "Disciplina");
            dgvCompetidores.Columns.Add("fechaNacimiento", "fecha de Nacimiento");

            dgvCompetidores.Columns["numero"].Visible = false;

            foreach (DataRow dr in dt.Rows)
            {
                dgvCompetidores.Rows.Add(dr["numero"], dr["nombre"], dr["nombreDisciplina"], dr["fechaNacimiento"]);
            
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(dgvCompetidores.CurrentRow.Cells[0].Value);
                FrmDetalle frmDetalle = new FrmDetalle(codigo, Modo.Editar);
                frmDetalle.ShowDialog(); 
            }
            catch
            {
                MessageBox.Show("Debe seleccionar un registro","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
