using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJOO_ListBox.Datos
{
    public class AccesoDatos
    {
        private string CadenaConexion = "Data Source=DESKTOP-Q6GKN7O\\SQLEXPRESS;Initial Catalog=JJOO;Integrated Security=True;";
        private SqlConnection conexion;
        private SqlCommand comando;

        public AccesoDatos()
        {
            conexion = new SqlConnection(CadenaConexion);
        }

        private void Conectar()
        {
            conexion.Open();
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType= CommandType.Text;
        }

        private void Desconectar()
        {
            conexion.Close();
        }

        public DataTable ConsultarTabla(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            Conectar();
            comando.CommandText = "SELECT * FROM "+ consultaSQL;
            tabla.Load(comando.ExecuteReader());
            Desconectar();

            return tabla;
        }

        public DataTable ConsultarBD(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            Conectar();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            Desconectar();

            return tabla;
        }

        public int ActualizarBD(string consultaSQL, List<Parametro> lista)
        {
            int filasAfectadas = 0;
            Conectar();
            comando.CommandText = consultaSQL;
            foreach (Parametro p in lista)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            filasAfectadas = comando.ExecuteNonQuery();
            Desconectar();

            return filasAfectadas;
        }
    }
}
