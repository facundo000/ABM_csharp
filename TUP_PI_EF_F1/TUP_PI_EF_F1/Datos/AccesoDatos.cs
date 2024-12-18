﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_EF_F1.Datos
{
    public class AccesoDatos
    {
        private string CadenaConexion = @"Data Source=172.16.10.196;Initial Catalog=Formula1;User ID=alumno1w1;Password=alumno1w1";
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
            comando.CommandType = CommandType.Text;
        }
        public void Desconectar()
        {
            conexion.Close();
        }
        public DataTable ConsultarTabla(string nombreTabla)
        {
            DataTable tabla = new DataTable();
            this.Conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            tabla.Load(comando.ExecuteReader());
            this.Desconectar();
            return tabla;
        }
        public DataTable ConsultarBD(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            this.Conectar();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            this.Desconectar();
            return tabla;
        }
        public int ActualizarBD(string consultaSQL)
        {
            int filasAfectadas = 0;
            this.Conectar();
            comando.CommandText = consultaSQL;
            filasAfectadas = comando.ExecuteNonQuery();
            this.Desconectar();
            return filasAfectadas;
        }
        public int ActualizarBD(string consultaSQL, List<Parametro> lista)
        {
            int filasAfectadas = 0;
            this.Conectar();
            comando.CommandText = consultaSQL;
            foreach (Parametro p in lista)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            filasAfectadas = comando.ExecuteNonQuery();
            this.Desconectar();
            return filasAfectadas;
        }
    }
}