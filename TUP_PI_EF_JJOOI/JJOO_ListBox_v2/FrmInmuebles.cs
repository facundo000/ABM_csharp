using JJOO_ListBox.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

//CURSO – LEGAJO – APELLIDO – NOMBRE

//Cadena de Conexión: "Data Source=172.16.10.196;Initial Catalog=DGR;User ID=alumno1w1;Password=alumno1w1"

namespace JJOO_ListBox
{
    public partial class FrmInmuebles : Form
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        Competidores competidores = new Competidores();
        List<Parametro> parametros = new List<Parametro>();
        public FrmInmuebles()
        {
            InitializeComponent();
        }

        private void FrmInmuebles_Load(object sender, EventArgs e)
        {
            CargarLista();
            CargarCombo(cboDisciplina, "Disciplinas");
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
            string consultaSql = "select numero, nombre ,disciplina, fechaNacimiento FROM Competidores";

            DataTable dt =accesoDatos.ConsultarBD(consultaSql);

            lstCompetidores.Items.Clear();
            foreach (DataRow fila in dt.Rows)
            {
                int cbo = Convert.ToInt32(fila["disciplina"]);
                string cboStr;
                switch (cbo)
                {
                    case 1:
                        cboStr = "Natacion";
                        break;
                    case 2:
                        cboStr = "Esgrima";
                        break;
                    case 3:
                        cboStr = "Atletismo";
                        break;
                    case 4:
                        cboStr = "Boxeo";
                        break;
                    case 5:
                        cboStr = "Yudo";
                        break;
                    default :
                        cboStr = "Desconocido";
                        break;
                }

                string itemText = $"Nombre: {fila["nombre"]} - Disciplina: {cboStr} - Fecha de Nacimiento: {fila["fechaNacimiento"]}";

                var item = new ListBoxItem
                {
                    Text = itemText,
                    Tag = fila["numero"]
                };


                lstCompetidores.Items.Add(item);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var itemSeleccionado = lstCompetidores.SelectedItem as ListBoxItem;
            if(itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un registro","Advertencia", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            int numero = Convert.ToInt32(itemSeleccionado.Tag);
            CargarCampos(numero);
            btnGrabar.Enabled = true;
        }

        private void CargarCampos(int numero)
        {
            string consultaSql = $"select * from Competidores where numero = {numero}";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            DataRow fila = dt.Rows[0];

            competidores.Codigo = Convert.ToInt32(fila["numero"]);
            competidores.Nombre = fila["nombre"].ToString();
            competidores.Disciplina = Convert.ToInt32(fila["disciplina"]);
            competidores.Sexo = Convert.ToChar(fila["sexo"]);
            competidores.FechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"]);

            txtId.Text = competidores.Codigo.ToString();
            txtNombre.Text = competidores.Nombre;
            cboDisciplina.SelectedValue = competidores.Disciplina;
            if (competidores.Sexo == 'M')
            {
                rbtUrbano.Checked = true;
            }
            else
            {
                rbtRural.Checked = true;
            }
            dtpFechaNacimiento.Value = competidores.FechaNacimiento;

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var itemSeleccionado = lstCompetidores.SelectedItem as ListBoxItem;
                if (itemSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int numero = Convert.ToInt32(itemSeleccionado.Tag);
                GuardarCompetidor(numero);
            }
            
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El campo nombre no puede quedar vacio", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return false;
            }
            DateTime fechaSeleccionada = dtpFechaNacimiento.Value;
            DateTime fechaValida = DateTime.Now.AddYears(-15);
            int atleta = Convert.ToInt32(cboDisciplina.SelectedValue);
            if (atleta == 3 && fechaSeleccionada > fechaValida)
            {
                MessageBox.Show("Atletismo no permite menores de 15 años", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaNacimiento.Value = fechaValida;

                return false;
            }

            return true;
        }

        private void GuardarCompetidor(int numero)
        {
            string consultaSql = "UPDATE Competidores SET nombre = @nombre, disciplina= @disciplina, sexo = @sexo, fechaNacimiento = @fechaNacimiento " +
                $"WHERE numero = {numero}";

            competidores.Nombre = txtNombre.Text.ToString();
            competidores.Disciplina = Convert.ToInt32(cboDisciplina.SelectedValue);
            if (rbtUrbano.Checked)
            {
                competidores.Sexo = 'M';
            }
            else
            {
                competidores.Sexo = 'F';
            }
            competidores.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Value);

             parametros.Clear();

            parametros.Add(new Parametro("nombre", competidores.Nombre));
            parametros.Add(new Parametro("disciplina", competidores.Disciplina));
            parametros.Add(new Parametro("sexo", competidores.Sexo));
            parametros.Add(new Parametro("fechaNacimiento", competidores.FechaNacimiento));

            int filasAfectadas = accesoDatos.ActualizarBD(consultaSql, parametros);

            if(filasAfectadas > 0)
            {
                MessageBox.Show("Guardado correctamente!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
                btnGrabar.Enabled = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
