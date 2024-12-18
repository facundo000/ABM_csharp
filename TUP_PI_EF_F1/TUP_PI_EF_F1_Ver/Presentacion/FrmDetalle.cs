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
        Ver
    }
    public partial class FrmDetalle : Form
    {
        Modo accion;
        int codigo;
        AccesoDatos accesoDatos = new AccesoDatos();
        Competidor competidor = new Competidor();
        public FrmDetalle()
        {
            InitializeComponent();
        }

        public FrmDetalle(Modo accion, int codigo)
        {
            InitializeComponent();
            this.accion = accion;
            this.codigo = codigo;
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            CargarCombo(cboPais, "Paises");
            CargarCombo(cboEscuderia, "Escuderias");
            CargarCampos(codigo);

        }

        private void CargarCombo(ComboBox cbo, string nt)
        {
            DataTable dt = accesoDatos.ConsultarTabla(nt);
            cbo.DataSource = dt;
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            //cbo.SelectedIndex = -1;
        }

        private void CargarCampos(int codigo)
        {
            string consultaSql = $"select * from Competidores where numero = {codigo}";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            DataRow fila = dt.Rows[0];

            competidor.Numero = Convert.ToInt32(fila["numero"]);
            competidor.Nombre = Convert.ToString(fila["nombre"]);
            competidor.Pais = Convert.ToInt32(fila["pais"]);
            competidor.FechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"]);
            competidor.Escuderia = Convert.ToInt32(fila["escuderia"]);
            
            txtNumero.Text = competidor.Numero.ToString();
            txtNombre.Text = competidor.Nombre;
            cboPais.SelectedValue = competidor.Pais;
            dtpFecNac.Value = competidor.FechaNacimiento;
            cboEscuderia.SelectedValue  = competidor.Escuderia;

        }
    }
}
