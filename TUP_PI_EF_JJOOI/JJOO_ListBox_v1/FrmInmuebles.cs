using JJOO_ListBox;
using JJOO_ListBox.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

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
            string consultaSql = "select numero, nombre, disciplina, fechaNacimiento from Competidores";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            lstCompetidores.Items.Clear();
            foreach (DataRow fila in dt.Rows)
            {
                int disciplina = Convert.ToInt32(fila["disciplina"]);
                string disciplinaStr;
                switch (disciplina)
                {
                    case 1:
                        disciplinaStr = "Natación";
                        break;
                    case 2:
                        disciplinaStr = "Esgrima";
                        break;
                    case 3:
                        disciplinaStr = "Atletismo";
                        break;
                    case 4:
                        disciplinaStr = "Boxeo";
                        break;
                    case 5:
                        disciplinaStr = "Yude";
                        break;
                    default:
                        disciplinaStr = "Desconocido";
                        break;
                }

                string itemText = $"Nombre {fila["nombre"]} - Disciplina {disciplinaStr} - Fecha De Nacimiento {fila["fechaNacimiento"]}";

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
            if (itemSeleccionado  == null)
            {
                MessageBox.Show("Debe seleccionar un registro", "Advertencia",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int codigo = Convert.ToInt32(itemSeleccionado.Tag);
            CargarCampos(codigo);
            btnGrabar.Enabled = true;
        }

        private void CargarCampos(int codigo)
        {
            string consultaSql = $"select * from Competidores where numero = {codigo}";

            DataTable dt = accesoDatos.ConsultarBD(consultaSql);

            DataRow fila = dt.Rows[0];

            competidores.Codigo = Convert.ToInt32(fila["numero"]);
            competidores.Nombre = Convert.ToString(fila["Nombre"]);
            competidores.Disciplina = Convert.ToInt32(fila["disciplina"]);
            competidores.Sexo = Convert.ToChar(fila["sexo"]);
            competidores.FechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"]);

            txtId.Text = competidores.Codigo.ToString();
            txtNomenclatura.Text = competidores.Nombre;
            cboDisciplina.SelectedValue = competidores.Disciplina;
            if (competidores.Sexo == 'M')
            {
                rbtMasculino.Checked = true;
            }
            else
            {
                rbtFemenino.Checked = true;
            }
            dateTimePicker1.Value = competidores.FechaNacimiento;
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
                int codigo = Convert.ToInt32(itemSeleccionado.Tag);
                GuardarCompetidor(codigo);
            }
            
        }

        private bool ValidarCampos()
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value;
            DateTime fechaValida = DateTime.Today.AddYears(-15);
            if (fechaSeleccionada > fechaValida)
            {
                MessageBox.Show("El Competidor no puede ser menor a 15 años", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker1.Value = fechaValida;

                return false;
            }
            if (string.IsNullOrEmpty(txtNomenclatura.Text))
            {
                MessageBox.Show("El campo nombre no puede quedar vacio", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void GuardarCompetidor(int codigo)
        {
            try
            {
                string consultaSql = "update Competidores SET nombre = @nombre, disciplina = @disciplina, sexo = @sexo, fechaNacimiento = @fechaNacimiento " +
                $"WHERE numero ={codigo}";

                parametros.Clear();

                competidores.Nombre = txtNomenclatura.Text.ToString();
                competidores.Disciplina = Convert.ToInt32(cboDisciplina.SelectedValue);
                if (rbtMasculino.Checked)
                {
                    competidores.Sexo = 'M';
                }
                else
                {
                    competidores.Sexo = 'F';
                }
                competidores.FechaNacimiento = Convert.ToDateTime(dateTimePicker1.Value);


                parametros.Add(new Parametro("nombre", competidores.Nombre));
                parametros.Add(new Parametro("disciplina", competidores.Disciplina));
                parametros.Add(new Parametro("sexo", competidores.Sexo));
                parametros.Add(new Parametro("fechaNacimiento", competidores.FechaNacimiento));

                int filasAfectadas = accesoDatos.ActualizarBD(consultaSql, parametros);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Actualizado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    btnGrabar.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Hubo un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
