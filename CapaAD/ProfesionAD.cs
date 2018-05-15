using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaAD
{
    public class ProfesionAD
    {
        ConexionBD conexion;

        public DataTable ListadoProfesion()
        {
            conexion = new ConexionBD();
            DataTable tabla = new DataTable();
            conexion.AbrirConexion();
            string query = "call listado_profesion;";
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
            consulta.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable CrearProfesion (String profesion)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            { 
                conexion.AbrirConexion();
                string query = "call crear_profesion ('" + profesion + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {
                
            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable GetProfesion (int id)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call get_profesion (" + id + ");";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable EditarProfesion(int id, string profesion)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call editar_profesion (" + id + ", '" + profesion + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable EliminarProfesion(int id)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call eliminar_profesion (" + id + ");";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

    }
}
