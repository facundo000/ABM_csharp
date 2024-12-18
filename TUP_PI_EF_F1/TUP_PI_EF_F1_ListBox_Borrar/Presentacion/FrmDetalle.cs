using System;
using System.Collections.Generic;
using System.Data;
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
            CargarCombo(cboPais, "Paises");
            CargarCombo(cboEscuderia, "Escuderias");
            CargarLista();
        }

        private void CargarCombo(ComboBox cbo, string nt)
        {
            DataTable dt = accesoDatos.ConsultarTabla(nt);
            cbo.DataSource = dt;
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.SelectedIndex = -1;
        }

        private void CargarLista()
        {
            string consulraSql = "select numero, nombre, nombreEscuderia, YEAR(fechaNacimiento) anio_nac from competidores c join Escuderias e on e.idEscuderia = c.escuderia";

            DataTable dt = accesoDatos.ConsultarBD(consulraSql);

            lstCompetidores.Items.Clear();
            foreach (DataRow fila in dt.Rows)
            {
                int edad = DateTime.Today.Year - Convert.ToInt32(fila["anio_nac"]);

                string itemText = $"Numero: {fila["numero"]} - Nombre: {fila["nombre"]} - Escuderia: {fila["nombreEscuderia"]} - Edad: {edad}";

                var item = new ListBoxItem
                {
                    Text = itemText,
                    Tag = fila["numero"]
                };

                lstCompetidores.Items.Add(item);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var itemSeleccionado = lstCompetidores.SelectedItem as ListBoxItem;
            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un registro", "Seleccione un reguistro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            int numero = Convert.ToInt32(itemSeleccionado.Tag);
            CargarCampos(numero);
        }

        private void CargarCampos(int numero)
        {
            string consultaSql = $"select * from competidores where numero = {numero}";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            DataRow dr = dt.Rows[0];

            competidor.Numero = Convert.ToInt32(dr["numero"]);
            competidor.Nombre = Convert.ToString(dr["nombre"]);
            competidor.Pais = Convert.ToInt32(dr["pais"]);
            competidor.Escuderia = Convert.ToInt32(dr["escuderia"]);
            competidor.FechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);

            txtNumero.Text = competidor.Numero.ToString();
            txtNombre.Text = competidor.Nombre;
            cboPais.SelectedValue = competidor.Pais;
            cboEscuderia.SelectedValue = competidor.Escuderia;
            dtpFecNac.Value = competidor.FechaNacimiento;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de querer borrar el registro?", "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var itemSeleccionado = lstCompetidores.SelectedItem as ListBoxItem;
                if (itemSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un registro", "Seleccione un reguistro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                int numero = Convert.ToInt32(itemSeleccionado.Tag);
                EliminarCompetidor(numero);
            }
        }

        private void EliminarCompetidor(int numero)
        {
            string consultaSql = $"delete from competidores where numero = {numero}";

            parametros.Clear();

            int filasAfectadas = accesoDatos.ActualizarBD(consultaSql, parametros);
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
            }
        }
    }
}
