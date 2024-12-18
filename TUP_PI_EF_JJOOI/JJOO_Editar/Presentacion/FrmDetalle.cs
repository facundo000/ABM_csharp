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
        int codigo;
        Modo accion;
        AccesoDatos accesoDatos = new AccesoDatos();
        Competidor competidor = new Competidor();
        List<Parametro> parametros = new List<Parametro>();
        public FrmDetalle()
        {
            InitializeComponent();
        }

        public FrmDetalle(int codigo, Modo accion)
        {
            InitializeComponent();
            this.codigo = codigo;
            this.accion = accion;
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            CargarCombo(cboDisciplina, "Disciplinas");
            CargarFormulario(codigo);
        }

        private void CargarFormulario(int codigo)
        {
            string consultaSql = $"select * from Competidores where numero = {codigo}";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            DataRow fila = dt.Rows[0];

            competidor.Numero = Convert.ToInt32(fila["numero"]);
            competidor.Nombre = Convert.ToString(fila["nombre"]);
            competidor.Disciplina = Convert.ToInt32(fila["disciplina"]);
            competidor.Sexo = Convert.ToString(fila["sexo"]);
            competidor.FechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"]);

            txtNumero.Text = Convert.ToString(competidor.Numero);
            txtNombre.Text = Convert.ToString(competidor.Nombre);
            cboDisciplina.SelectedValue = competidor.Disciplina;
            if(competidor.Sexo == "F")
            {
                rbtFemenino.Checked = true;
            }
            else
            {
                rbtMasculino.Checked = true;
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
            if (CamposValidos())
            {
                GuardarCompetidor(codigo);
            }
        }

        private void GuardarCompetidor(int codigo)
        {
            string consultaSql = "update competidores set nombre=@nombre, disciplina = @disciplina, sexo = @sexo, fechaNacimiento = @fechaNacimiento" +
                $" where numero = {codigo}";

            competidor.Nombre = Convert.ToString(txtNombre.Text);
            competidor.Disciplina = Convert.ToInt32(cboDisciplina.SelectedValue);
            if (rbtFemenino.Checked)
            {
                competidor.Sexo = "F";
            }
            else
            {
                competidor.Sexo = "M";
            }
            competidor.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Value);
            
            parametros.Add(new Parametro("nombre", competidor.Nombre));
            parametros.Add(new Parametro("disciplina", competidor.Disciplina));
            parametros.Add(new Parametro("sexo", competidor.Sexo));
            parametros.Add(new Parametro("fechaNacimiento", competidor.FechaNacimiento));

            int fiasAfectadas = accesoDatos.ActualizarBD(consultaSql, parametros);
            if (fiasAfectadas > 0)
            {
                MessageBox.Show("Guaedafdoo", "+Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool CamposValidos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("No se puede dejar el campo Nombre vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            DateTime fechaSeleccionada = dtpFechaNacimiento.Value;
            DateTime fechaLimite = DateTime.Today.AddYears(-15);
            DateTime fechaValida = DateTime.Today.AddYears(-16);
            if (fechaSeleccionada > fechaLimite)
            {
                MessageBox.Show("El atleta no puede ser menor a 15 años", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaNacimiento.Value = fechaValida;

                return false;
            }

            return true;
        }
    }
}
