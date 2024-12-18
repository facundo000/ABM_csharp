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
        public FrmDetalle()
        {
            InitializeComponent();
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            CargarCombo(cboPais, "paises");
            CargarCombo(cboEscuderia, "escuderias");
            CargarLista();
        }

        private void CargarCombo(ComboBox cbo, string nt)
        {
            DataTable tabla = accesoDatos.ConsultarTabla(nt);
            cbo.DataSource = tabla;
            cbo.ValueMember = tabla.Columns[0].ColumnName;
            cbo.DisplayMember = tabla.Columns[1].ColumnName;
            //cbo.SelectedIndex = 0;
        }

        private void CargarLista()
        {
            string consultaSql = "select numero, nombre, escuderia, YEAR(fechaNacimiento) as AnioNac from competidores";
            
            DataTable tabla = accesoDatos.ConsultarBD(consultaSql);

            lstCompetidores.Items.Clear();
            foreach (DataRow fila in tabla.Rows)
            {
                int escuderia = Convert.ToInt32(fila["numero"]);
                string escuderiaStr;
                switch (escuderia)
                {
                    case 1:
                        escuderiaStr = "Ferrari";
                        break;
                    case 2:
                        escuderiaStr = "Mercedes";
                        break;
                    case 3:
                        escuderiaStr = "Red Bull";
                        break;
                    case 4:
                        escuderiaStr = "MacLaren";
                        break;
                    default:
                        escuderiaStr = "Otro...";
                        break;
                }

                int edad = DateTime.Today.Year - Convert.ToInt32(fila["AnioNac"]);

                string itemText = $"Numero: {fila["numero"]} - Nombre:{fila["nombre"]} - Escuderia:{escuderiaStr} - Edad: {edad}";

                var itemTag = new ListBoxItem
                {
                    Text = itemText,
                    Tag = fila["numero"]
                };

                lstCompetidores.Items.Add(itemTag);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var itemSeleccionado = lstCompetidores.SelectedItem as ListBoxItem;
            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un registro","Advertencia",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            int numero = Convert.ToInt32(itemSeleccionado.Tag);
            CargarCampos(numero);
        }

        private void CargarCampos(int numero)
        {
            string consultaSql = $"select * from competidores where numero = {numero}";

            DataTable tabla = accesoDatos.ConsultarBD(consultaSql);

            DataRow fila = tabla.Rows[0];

            competidor.Numero = Convert.ToInt32(fila["numero"]);
            competidor.Nombre = Convert.ToString(fila["nombre"]);
            competidor.Pais = Convert.ToInt32(fila["pais"]);
            competidor.Escuderia = Convert.ToInt32(fila["escuderia"]);
            competidor.FechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"]);

            txtNumero.Text = competidor.Numero.ToString();
            txtNombre.Text = competidor.Nombre;
            cboPais.SelectedValue = competidor.Pais;
            cboEscuderia.SelectedValue = competidor.Escuderia;
            dtpFecNac.Value = competidor.FechaNacimiento;
        }
    }
}
