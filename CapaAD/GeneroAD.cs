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
    public class GeneroAD
    {
        ConexionBD conexion;

        public DataTable ListadoGeneros()
        {
            conexion = new ConexionBD();
            DataTable tabla = new DataTable();
            conexion.AbrirConexion();
            string query = "call listado_genero;";
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
            consulta.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable CrearGenero (String genero)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            { 
                conexion.AbrirConexion();
                string query = "call crear_genero ('" + genero + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {
                
            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable GetGenero (int id)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call get_genero (" + id + ");";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable EditarGenero(int id, string genero)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call editar_genero (" + id + ", '" + genero + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable EliminarGenero(int id)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call eliminar_genero (" + id + ");";
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
