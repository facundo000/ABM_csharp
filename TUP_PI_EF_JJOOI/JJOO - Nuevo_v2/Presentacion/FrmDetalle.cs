﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUP_PI_EF_JJOOI.Datos;
using TUP_PI_EF_JJOOI.Negocio;

namespace TUP_PI_EF_JJOOI.Presentacion
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Estas seguro de querere salir?","Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            CargarCombo(cboDisciplina, "Disciplinas");
        }

        private void CargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable dt = accesoDatos.ConsultarTabla(nombreTabla);
            combo.DataSource = dt;
            combo.ValueMember = dt.Columns[0].ColumnName;
            combo.DisplayMember = dt.Columns[1].ColumnName;
            combo.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(ValidarCampos())
            GuardarCompetidor();
        }

        private bool ValidarCampos()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El campo nombre no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int cbo = Convert.ToInt32(cboDisciplina.SelectedValue);
            if (cbo <= 0)
            {
                MessageBox.Show("Debe selecionar una disciplina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!rbtFemenino.Checked && !rbtMasculino.Checked)
            {
                MessageBox.Show("Debe selecionar un sexo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DateTime fechaSeleccionada = dtpFechaNacimiento.Value;
            DateTime fechaMinima = DateTime.Today.AddYears(-15);
            if (fechaSeleccionada > fechaMinima)
            {
                MessageBox.Show("NO puede ser menor a 15 años", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaNacimiento.Value = DateTime.Today.AddYears(-16);
                return false;
            }
            return true;
        }

        private void GuardarCompetidor()
        {
            string consultaSql = "insert into Competidores(nombre, disciplina, sexo, fechaNacimiento) values (" +
                "@nombre, " +
                "@disciplina, " +
                "@sexo, " +
                "@fechaNacimiento" +
                ")";

            competidor.Nombre= Convert.ToString( txtNombre.Text);
            competidor.Disciplina = Convert.ToInt32(cboDisciplina.SelectedValue);
            if (rbtMasculino.Checked)
            {
                competidor.Sexo = "M";
            }
            else
            {
                competidor.Sexo = "F";
            }
            competidor.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Value);

            parametros.Add(new Parametro("nombre", competidor.Nombre));
            parametros.Add(new Parametro("disciplina", competidor.Disciplina));
            parametros.Add(new Parametro("sexo", competidor.Sexo));
            parametros.Add(new Parametro("fechaNacimiento", competidor.FechaNacimiento));

            int filasAfectadas = accesoDatos.ActualizarBD(consultaSql, parametros);

            if(filasAfectadas > 0)
            {
                MessageBox.Show("Guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Algo salio mal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
    }
}
