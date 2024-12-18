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
            CargarLista();
            CargarCombos(cboPais, "Paises");
            CargarCombos(cboEscuderia, "Escuderias");
        }

        private void CargarCombos(ComboBox cbo, string nt)
        {
            DataTable dt = accesoDatos.ConsultarTabla(nt);
            cbo.DataSource = dt;
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.SelectedIndex = -1;
        }

        private void CargarLista()
        {
            string consultaSql = "select numero, nombre, nombrePais from competidores c join Paises p on p.idPais= c.pais";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            lstCompetidores.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                string itenText = $"Numero: {dr["numero"]} - Nombre: {dr["nombre"]} - Pais: {dr["nombrePais"]} ";

                var item = new ListBoxItem
                {
                    Text = itenText,
                    Tag = dr["numero"]
                };

                lstCompetidores.Items.Add(item);
            }

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            btnCancelar.Enabled = true;
            var itemSeleccionado = lstCompetidores.SelectedItem as ListBoxItem;

            int numero = Convert.ToInt32(itemSeleccionado.Tag);

            CargarCampos(numero);
        }

        private void CargarCampos(int numero)
        {
            string consultaSql = $"select * from competidores where numero = {numero}";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            DataRow fila = dt.Rows[0];

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var itemSeleccionado = lstCompetidores.SelectedItem as ListBoxItem;

            int numero = Convert.ToInt32(itemSeleccionado.Tag);

            if (ValidarCampos(numero))
            {

                GuardarCompetidor(numero);
            }
        }

        private bool ValidarCampos(int numero)
        {
            int pais = Convert.ToInt32(cboPais.SelectedValue);
            int escuderia = Convert.ToInt32(cboEscuderia.SelectedValue);

            if (string.IsNullOrEmpty(txtNombre.Text) || pais <= 0 || escuderia <= 0)
            {
                MessageBox.Show("Algunos campos no pueden quedar vacíos", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            string consultaSql = "select numero from Competidores";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);
            foreach (DataRow dr in dt.Rows)
            {
                int numeroBD = Convert.ToInt32(dr["numero"]);
                int numeroSeleccionado = Convert.ToInt32(txtNumero.Text);

                if (numeroBD == numeroSeleccionado && numero != numeroSeleccionado)
                {
                    MessageBox.Show("El numero de auto ya está en uso", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
            }            

            DateTime fechaseleccioanda = dtpFecNac.Value;
            DateTime fechaValida = DateTime.Today.AddYears(-18);

            if (fechaseleccioanda > fechaValida)
            {
                MessageBox.Show("El competidor tiene que ser mayor a 18 años", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void GuardarCompetidor(int numero)
        {
            try
            {
                string consultaSql = "UPDATE Competidores SET numero = @numero ,nombre = @nombre ,pais = @pais ,escuderia = @escuderia ,fechaNacimiento = @fechaNacimiento " +
                    $"WHERE numero = {numero}";

                competidor.Numero = Convert.ToInt32(txtNumero.Text);
                competidor.Nombre = Convert.ToString(txtNombre.Text);
                competidor.Pais = Convert.ToInt32(cboPais.SelectedValue);
                competidor.Escuderia = Convert.ToInt32(cboEscuderia.SelectedValue);
                competidor.FechaNacimiento = Convert.ToDateTime(dtpFecNac.Value);

                parametros.Add(new Parametro("numero", competidor.Numero));
                parametros.Add(new Parametro("nombre", competidor.Nombre));
                parametros.Add(new Parametro("pais", competidor.Pais));
                parametros.Add(new Parametro("escuderia", competidor.Escuderia));
                parametros.Add(new Parametro("fechaNacimiento", competidor.FechaNacimiento));

                int filasAfectadas = accesoDatos.ActualizarBD(consultaSql, parametros);
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                }
            }
            catch
            {
                MessageBox.Show("Algo salió mal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNumero.Text = string.Empty;
            txtNombre.Text = string.Empty;
            cboPais.SelectedIndex = -1;
            dtpFecNac.Value = DateTime.Now;
            cboEscuderia.SelectedIndex = -1;
        }
    }
}
