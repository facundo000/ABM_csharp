using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJOO_ListBox.Datos
{
    public class AcceesoDatos
    {
        private string Cadenaconexion = "Data Source=DESKTOP-Q6GKN7O\\SQLEXPRESS;Initial Catalog=JJOO;Integrated Security=True;";
        private SqlConnection conexion;
        private SqlCommand comando;

        public AcceesoDatos()
        {
            conexion = new SqlConnection(Cadenaconexion);
        }

        private void Conectar()
        {
            conexion.Open();
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        private void Desconectar()
        {
            conexion.Close();
        }

        public DataTable ConsultarTabla(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            Conectar();
            comando.CommandText = "SELECT * FROM " + consultaSQL;
            comando.ExecuteReader();
            Desconectar();

            return tabla;
        }

        public DataTable ConsultarBD(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            Conectar();
            comando.CommandText = consultaSQL;
            comando.ExecuteReader();
            Desconectar();

            return tabla;
        }

        public int ActualizarBD(string consultaSQL, List<Paramettro> lista)
        {
            int filasAfectadas = 0;
            Conectar();
            comando.CommandText = consultaSQL;
            foreach (Paramettro p in lista)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            filasAfectadas = comando.ExecuteNonQuery();
            Desconectar();

            return filasAfectadas;
        }
    }
}
