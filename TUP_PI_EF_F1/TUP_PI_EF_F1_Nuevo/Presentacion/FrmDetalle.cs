using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUP_PI_EF_F1.Datos;
using TUP_PI_EF_F1.Negocio;

//CURSO – LEGAJO – APELLIDO – NOMBRE

namespace TUP_PI_EF_F1
{
    public partial class FrmDetalle : Form
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        List<Parametro> parametros = new List<Parametro>();
        Competidor competidor = new Competidor();
        public FrmDetalle()
        {
            InitializeComponent();
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            CargarCombo(cboPais,"Paises");
            CargarCombo(cboEscuderia, "Escuderias");
        }

        private void CargarCombo(ComboBox cbo, string nt)
        {
            DataTable dt = accesoDatos.ConsultarTabla(nt);
            cbo.DataSource = dt;
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                GuardarCompetidor();
            }
        }

        private bool ValidarCampos()
        {
            
            if (nNumero.Value <= 0 || txtNombre.Text == "" || Convert.ToInt32(cboPais.SelectedValue) <= 0 || Convert.ToInt32(cboEscuderia.SelectedValue) <= 0 )
            {
                MessageBox.Show("Hay campos vacios", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            string consultaSql = "select numero from competidores";
            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            foreach (DataRow fila in dt.Rows)
            {
                int numeroBD = Convert.ToInt32(fila["numero"]);

                if (numeroBD == nNumero.Value)
                {
                    MessageBox.Show($"El numero {nNumero.Value} ya está en uso", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
            }

            DateTime fechaSeleccionada = dtpFecNac.Value;
            DateTime fechaValida = DateTime.Today.AddYears(-18);

            if (fechaSeleccionada > fechaValida)
            {
                MessageBox.Show($"El competidor tiene que ser mayor a 18 años", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }


            return true;
        }

        private void GuardarCompetidor()
        {
            string consultaSql = "INSERT INTO Competidores (numero, nombre, pais, escuderia, fechaNacimiento) " +
                "VALUES (@numero, @nombre, @pais, @escuderia, @fechaNacimiento)";

            competidor.Numero = Convert.ToInt32( nNumero.Value);
            competidor.Nombre = Convert.ToString( txtNombre.Text);
            competidor.Pais = Convert.ToInt32( cboPais.SelectedValue);
            competidor.Escuderia = Convert.ToInt32( cboEscuderia.SelectedValue);
            competidor.FechaNacimiento = Convert.ToDateTime( dtpFecNac.Value);

            parametros.Add(new Parametro("numero", competidor.Numero));
            parametros.Add(new Parametro("nombre", competidor.Nombre));
            parametros.Add(new Parametro("pais", competidor.Pais));
            parametros.Add(new Parametro("escuderia", competidor.Escuderia));
            parametros.Add(new Parametro("fechaNacimiento", competidor.FechaNacimiento));

            int filasAfectadas = accesoDatos.ActualizarBD(consultaSql, parametros);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Guardado correctamente","Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
