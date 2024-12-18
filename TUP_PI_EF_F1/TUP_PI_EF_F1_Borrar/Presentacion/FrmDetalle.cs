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
    public enum Modo
    {
        Borrar
    }
    public partial class FrmDetalle : Form
    {
        int numero;
        Modo accion;
        AccesoDatos accesoDatos = new AccesoDatos();
        Competidor competidor = new Competidor();
        List<Parametro> parametro = new List<Parametro>();
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
            CargarCombo(cboPais,"paises");
            CargarCombo(cboEscuderia,"escuderias");
            CargarCampos(numero);
        }

        private void CargarCombo(ComboBox cbo, string nt)
        {
            DataTable dt = accesoDatos.ConsultarTabla(nt);
            cbo.DataSource = dt;
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            //cbo.SelectedIndex = 0;
        }

        private void CargarCampos(int numero)
        {
            string consultaSql = $"select * from Competidores where numero = {numero}";

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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estass seguro de querer eliminar a este competidor?","Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                EliminarCompetidor(numero);
            }
        }

        private void EliminarCompetidor(int numero)
        {
            string consultaSql = $"delete from Competidores where numero = {numero}";

            competidor.Numero = Convert.ToInt32( txtNumero.Text);
            competidor.Nombre = txtNombre.Text.ToString();
            competidor.Pais = Convert.ToInt32(cboPais.SelectedValue);
            competidor.Escuderia = Convert.ToInt32(cboPais.SelectedValue);
            competidor.FechaNacimiento = Convert.ToDateTime(dtpFecNac.Value);

            parametro.Add(new Parametro("numero", competidor.Numero));
            parametro.Add(new Parametro("nombre", competidor.Nombre));
            parametro.Add(new Parametro("pais", competidor.Pais));
            parametro.Add(new Parametro("escuderia", competidor.Escuderia));
            parametro.Add(new Parametro("fechaNacimiento", competidor.FechaNacimiento));

            int filasAfectadas = accesoDatos.ActualizarBD(consultaSql);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Eliminado exitosamente", "Elinimado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
