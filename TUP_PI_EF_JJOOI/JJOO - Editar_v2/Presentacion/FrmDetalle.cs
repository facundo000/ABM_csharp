using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUP_PI_EF_JJOOI.Datos;
using TUP_PI_EF_JJOOI.Negocio;

namespace TUP_PI_EF_JJOOI.Presentacion
{
    public enum Modo
    {
        Editar
    }
    public partial class FrmDetalle : Form
    {
        int numero;
        Modo accion;
        AccesoDatos accesoDatos = new AccesoDatos();
        Competidor competidor = new Competidor();
        List<Parametro> parametros = new List<Parametro>();
        public FrmDetalle()
        {
            InitializeComponent();
        }
        public FrmDetalle(int numero, Modo accion)
        {
            InitializeComponent();
            this.numero = numero;
            this.accion = accion;
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            CargarCombo(cboDisciplina, "Disciplinas");
            CargarCampos(numero);
        }

        private void CargarCampos(int numero)
        {
            string consultaSql = $"select * from Competidores where numero = {numero}";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            DataRow fila = dt.Rows[0];
            competidor.Numero = Convert.ToInt32(fila["numero"]);
            competidor.Nombre = Convert.ToString(fila["nombre"]);
            competidor.Disciplina = Convert.ToInt32(fila["disciplina"]);
            competidor.Sexo = Convert.ToString(fila["sexo"]);
            competidor.FechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"]);

            txtNumero.Text = Convert.ToString(competidor.Numero);
            txtNombre.Text = competidor.Nombre;
            cboDisciplina.SelectedValue = competidor.Disciplina;
            if (competidor.Sexo == "M")
            {
                rbtMasculino.Checked = true;
            }
            else
            {
                rbtFemenino.Checked = true;
            }
            dtpFechaNacimiento.Value = competidor.FechaNacimiento;


        }

        private void CargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable dt = accesoDatos.ConsultarTabla(nombreTabla);
            combo.DataSource = dt;
            combo.ValueMember = dt.Columns[0].ColumnName;
            combo.DisplayMember = dt.Columns[1].ColumnName;
            //combo.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(ValidarCampos())
                GuardarCompetidor(numero);
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("No puede quedar el campo Nombre vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            int cbo = Convert.ToInt32(cboDisciplina.SelectedValue);
            if (cbo < 0)
            {
                MessageBox.Show("Debe seleccionar una disciplina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            DateTime fechaSeleccionada = dtpFechaNacimiento.Value;
            DateTime fechaMinima = DateTime.Today.AddYears(-15);
            if (fechaSeleccionada > fechaMinima)
            {
                MessageBox.Show("No puede ser menor a 15 años", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaNacimiento.Value = DateTime.Today.AddYears(-16);

                return false;
            }


            return true;
        }

        private void GuardarCompetidor(int numero)
        {
            string consultaSql = "update Competidores set nombre = @nombre, disciplina = @disciplina, sexo = @sexo, fechaNacimiento = @fechaNacimiento " +
                $"where numero = {numero}";

            competidor.Nombre = Convert.ToString(txtNombre.Text);
            competidor.Disciplina = Convert.ToInt32(cboDisciplina.SelectedValue);
            if (rbtMasculino.Checked)
            {
                competidor.Sexo = "M";
            }
            else
            {
                competidor.Sexo = "F";
            }
            competidor.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Value);

            parametros.Add(new Parametro("nombre", competidor.Nombre));
            parametros.Add(new Parametro("disciplina", competidor.Disciplina));
            parametros.Add(new Parametro("sexo", competidor.Sexo));
            parametros.Add(new Parametro("fechaNacimiento", competidor.FechaNacimiento));

            int filasAfectadas = accesoDatos.ActualizarBD(consultaSql, parametros);
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Actualizado correctamente!!","Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de querer salir?","Salir", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                Close();
            }
        }
    }
}
