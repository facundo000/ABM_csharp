using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TUP_PI_EF_F1.Datos;
using TUP_PI_EF_F1.Negocio;

//CURSO – LEGAJO – APELLIDO – NOMBRE

namespace TUP_PI_EF_F1
{
    public enum Modo
    {
        Editar
    }
    public partial class FrmDetalle : Form
    {
        Modo accion;
        int numero;
        AccesoDatos accesoDatos = new AccesoDatos();
        Competidor competidor = new Competidor();
        List<Parametro> parametros = new List<Parametro>();
        public FrmDetalle()
        {
            InitializeComponent();
        }

        public FrmDetalle(Modo accion, int numero)
        {
            InitializeComponent();
            this.accion = accion;
            this.numero = numero;
        }


        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            CargarCombo(cboPais, "paises");
            CargarCombo(cboEscuderia, "escuderias");
            CargarCampos(numero);
        }

        private void CargarCombo(ComboBox cbo, string nt)
        {
            DataTable dt = accesoDatos.ConsultarTabla(nt);
            cbo.DataSource = dt;
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.SelectedIndex = 0;
        }

        private void CargarCampos(int numero)
        {
            string consultaSql = $"select * from Competidores where numero = {numero}";

            DataTable tabla = accesoDatos.ConsultarBD(consultaSql);

            DataRow fila = tabla.Rows[0];

            competidor.Numero = Convert.ToInt32(fila["numero"]);
            competidor.Nombre = Convert.ToString(fila["nombre"]);
            competidor.Pais = Convert.ToInt32(fila["pais"]);
            competidor.Escuderia = Convert.ToInt32(fila["escuderia"]);
            competidor.FechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"]);

            //txtNumero.Text = fila["numero"].ToString();
            //txtNombre.Text = fila["nombre"].ToString();
            //cboPais.SelectedValue = Convert.ToInt32(fila["pais"]);
            //cboEscuderia.SelectedValue = Convert.ToInt32(fila["escuderia"]);
            //dtpFecNac.Value = Convert.ToDateTime(fila["fechaNacimiento"]);

            nNumero.Text = competidor.Numero.ToString();
            txtNombre.Text = competidor.Nombre;
            cboPais.SelectedValue = competidor.Pais;
            cboEscuderia.SelectedValue = competidor.Escuderia;
            dtpFecNac.Value = competidor.FechaNacimiento;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                GuardarCompetidor(numero);
            }
        }

        private bool ValidarCampos()
        {
            if (nNumero.Value <= 0)
            {
                MessageBox.Show("El numero del competidor tiene que ser del 1 al 150", "Campo no validos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("El nombre no puede quedar vacío", "Campo no validos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            string consultaSql = "select numero, nombre from Competidores";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            foreach (DataRow dr in dt.Rows)
            {
                int numeroBd = Convert.ToInt32(dr["numero"]);
                int numeroEleguido = Convert.ToInt32(nNumero.Text);
                if (numeroBd == numeroEleguido && numeroEleguido != numero)
                {
                    MessageBox.Show("El numero selecciomnado ya está ocupado", "Campo no validos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }

                //string nombrebd = Convert.ToString(dr["nombre"]);
                //string nombreEleguido = Convert.ToString(txtNombre.Text);
                //if (nombrebd == nombreEleguido)
                //{
                //    MessageBox.Show("El nombre ya existe en la base de datos", "Campo no validos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //    return false;
                //}
            }
            
            DateTime fechaSeleccionada = dtpFecNac.Value;
            DateTime fechaValida = DateTime.Today.AddYears(-18);
            if (fechaSeleccionada > fechaValida)
            {
                MessageBox.Show("El competidor tiene que ser mayor a 18 años", "Campo no validos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void GuardarCompetidor(int numero)
        {
            string consultaSql = "UPDATE Competidores SET numero = @numero, nombre = @nombre, pais = @pais, escuderia = @escuderia, fechaNacimiento = @fechaNacimiento " +
                $"where numero = {numero}";

            competidor.Numero = Convert.ToInt32(nNumero.Text);
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
                MessageBox.Show("Guardado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { Close(); }
        }
    }
}
