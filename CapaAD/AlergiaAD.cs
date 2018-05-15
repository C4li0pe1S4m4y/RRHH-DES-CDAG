using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAD
{
    public class AlergiaAD
    {
        ConexionBD conexion;

        public DataTable ListadoAlergia()
        {
            conexion = new ConexionBD();
            DataTable tabla = new DataTable();
            conexion.AbrirConexion();
            string query = "call listado_alergia;";
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
            consulta.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable CrearAlergia(String alergia)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call crear_alergia ('" + alergia + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable GetAlergia(int id)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call get_alergia (" + id + ");";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable EditarAlergia(int id, string alergia)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call editar_alergia (" + id + ", '" + alergia + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable EliminarAlergia(int id)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call eliminar_alergia (" + id + ");";
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
