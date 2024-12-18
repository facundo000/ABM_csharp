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
            CargarCombo(cboPais, "Paises");
            CargarCombo(cboEscuderia, "Escuderias");
        }

        private void CargarCombo(ComboBox combo, string nt)
        {
            DataTable dt = accesoDatos.ConsultarTabla(nt);
            combo.DataSource = dt;
            combo.ValueMember = dt.Columns[0].ColumnName;
            combo.DisplayMember = dt.Columns[1].ColumnName;
            combo.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
                GuardarCompetidor();
        }

        private void GuardarCompetidor()
        {
            string consultaSql = "INSERT INTO Competidores (numero ,nombre ,pais ,escuderia ,fechaNacimiento) " +
                "VALUES (" +
                "@numero " +
                ",@nombre " +
                ",@pais " +
                ",@escuderia " +
                ",@fechaNacimiento)";

            parametros.Clear();

            competidor.Numero = Convert.ToInt32(numericNumero.Text);
            competidor.Nombre = Convert.ToString(txtNombre.Text);
            competidor.Pais = Convert.ToInt32(cboPais.SelectedValue);
            competidor.FechaNacimiento = Convert.ToDateTime(dtpFecNac.Value);
            competidor.Escuderia = Convert.ToInt32(cboEscuderia.SelectedValue);
            
            parametros.Add(new Parametro("numero", competidor.Numero));
            parametros.Add(new Parametro("nombre", competidor.Nombre));
            parametros.Add(new Parametro("pais", competidor.Pais));
            parametros.Add(new Parametro("fechaNacimiento", competidor.FechaNacimiento));
            parametros.Add(new Parametro("escuderia", competidor.Escuderia));

            int filasAfectadas = accesoDatos.ActualizarBD(consultaSql, parametros);

            if(filasAfectadas > 0)
            {
                MessageBox.Show("Guardado correctamente","Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();                
            }
        }

        private bool ValidarCampos()
        
        {
            if (numericNumero.Value <= 0)
            {
                MessageBox.Show("El campo numero no puede quedar vacio", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            int numeroIngresado = Convert.ToInt32(numericNumero.Text);
            string numeroAuto = $"select numero from Competidores";
            DataTable dt = accesoDatos.ConsultarBD(numeroAuto);
            foreach (DataRow fila in dt.Rows)
            {
                int numerosOcupados = Convert.ToInt32(fila["numero"]);
                if (numerosOcupados == numeroIngresado)
                {
                    MessageBox.Show($"El numero {numeroIngresado} del auto ya está en uso", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El campo nombre no puede quedar vacio", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            
            int cboP = Convert.ToInt32(cboPais.SelectedValue);
            int cboC = Convert.ToInt32(cboEscuderia.SelectedValue);
            if (cboP <= 0 || cboC <= 0)
            {
                MessageBox.Show($"Debe seleccionar un pais y una categoria", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            DateTime fechaSeleccionada = dtpFecNac.Value;
            DateTime fechaValida = DateTime.Today.AddYears(-18);
            if (fechaSeleccionada > fechaValida)
            {
                MessageBox.Show("El competidor tiene que ser mayor a 18 años", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFecNac.Value = fechaValida;

                return false;
            }
        
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
