using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        AccesoDato accesoDato = new AccesoDato();
        Competidor competidor = new Competidor();
        List<Parametro> parametros = new List<Parametro>();
        public FrmDetalle()
        {
            InitializeComponent();
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            CargarCombo(cboEscuderia,"Escuderias");
            CargarCombo(cboPais,"Paises");
            CargarLista();
        }

        private void CargarCombo(ComboBox cbo, string nt)
        {
            DataTable dt = accesoDato.ConsultarTabla(nt);
            cbo.DataSource = dt;
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.SelectedIndex = -1;

        }

        private void CargarLista()
        {
            string consultaSql = "select numero, nombre, nombreEscuderia, year(fechaNacimiento) as Anio_nac from competidores c join Escuderias e on e.idEscuderia = c.escuderia";

            DataTable dt = accesoDato.ConsultarBD(consultaSql);

            lstCompetidores.Items.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                int edad = DateTime.Today.Year - Convert.ToInt32(dr["Anio_nac"]);

                string itemText = $"Numero: {dr["numero"]} - Nombre: {dr["nombre"]} - Escuderia: {dr["nombreEscuderia"]} - Edad: {edad}";

                lstCompetidores.Items.Add(itemText);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(ValidarCampos())
                GuardarCompetidor();
        }

        private bool ValidarCampos()
        {
            string consultaSql = "select numero from competidores";
            
            DataTable dt = accesoDato.ConsultarBD(consultaSql);
            foreach (DataRow dr in dt.Rows)
            {
                int numeroBD = Convert.ToInt32(dr["numero"]);
                if (numeroBD == nNumero.Value)
                {
                    MessageBox.Show("El numero del auto ya está en uso", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
            }
            
            if (nNumero.Value <= 0 || txtNombre.Text == "" || Convert.ToInt32(cboEscuderia.SelectedValue) <= 0 || Convert.ToInt32(cboPais.SelectedValue) <= 0)
            {
                MessageBox.Show("Todos los campos son obligatorios, hay un campo vacio", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        private void GuardarCompetidor()
        {
            string consultasql = "insert into Competidores (numero, nombre, pais, escuderia, fechaNacimiento) VALUES (@numero, @nombre, @pais, @escuderia ,@fechaNacimiento)";

            parametros.Clear();

            competidor.Numero = Convert.ToInt32(nNumero.Value);
            competidor.Nombre = Convert.ToString(txtNombre.Text);
            competidor.Pais = Convert.ToInt32(cboPais.SelectedValue);
            competidor.Escuderia = Convert.ToInt32(cboEscuderia.SelectedValue);
            competidor.FechaNacimiento = Convert.ToDateTime(dtpFecNac.Value);

            parametros.Add(new Parametro("numero", competidor.Numero));
            parametros.Add(new Parametro("nombre", competidor.Nombre));
            parametros.Add(new Parametro("pais", competidor.Pais));
            parametros.Add(new Parametro("escuderia", competidor.Escuderia));
            parametros.Add(new Parametro("fechaNacimiento", competidor.FechaNacimiento));

            int filasAfectadas = accesoDato.ActualizarBD(consultasql, parametros);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Guardado correctamente","Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
            }
        }
    }
}
