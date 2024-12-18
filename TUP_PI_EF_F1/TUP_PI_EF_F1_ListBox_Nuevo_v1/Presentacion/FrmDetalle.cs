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
        Competidor competidor = new Competidor();
        List<Parametro> parametros = new List<Parametro>();
        public FrmDetalle()
        {
            InitializeComponent();
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            CargarLista();
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

        private void CargarLista()
        {
            string consultaSql = "select numero, nombre, year(fechaNacimiento) as anioFecha from competidores";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            lstCompetidores.Items.Clear();
            foreach (DataRow fila in dt.Rows)
            {
                int fecha = Convert.ToInt32(fila["anioFecha"]);
                int fechaActual = DateTime.Today.Year;


                string itemText = $"Numero: {fila["numero"]} - Nombre: {fila["nombre"]} - Edad: {fechaActual - fecha}";                

                lstCompetidores.Items.Add(itemText);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarCompetidor();
        }

        private void GuardarCompetidor()
        {
            string consuntaSql = "INSERT INTO Competidores (numero, nombre, pais, escuderia, fechaNacimiento) VALUES (@numero, @nombre, @pais, @escuderia, @fechaNacimiento)";

            competidor.Numero = Convert.ToInt32(txtNumero.Text);
            competidor.Nombre = Convert.ToString(txtNombre.Text);
            competidor.Pais = Convert.ToInt32(cboPais.SelectedValue);
            competidor.FechaNacimiento = Convert.ToDateTime(dtpFecNac.Value);
            competidor.Escuderia = Convert.ToInt32(cboEscuderia.SelectedValue);

            parametros.Add(new Parametro("numero", competidor.Numero));
            parametros.Add(new Parametro("nombre", competidor.Nombre));
            parametros.Add(new Parametro("pais", competidor.Pais));
            parametros.Add(new Parametro("fechaNacimiento", competidor.FechaNacimiento));
            parametros.Add(new Parametro("escuderia", competidor.Escuderia));

            int filasAfectadas = accesoDatos.ActualizarBD(consuntaSql, parametros);

            if(filasAfectadas > 0)
            {
                MessageBox.Show("Guardado correctamemnte!!","Exito",MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
            }
        }
    }
}
