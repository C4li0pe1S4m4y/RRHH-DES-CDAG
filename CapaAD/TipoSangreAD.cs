using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAD
{
    public class TipoSangreAD
    {
        ConexionBD conexion;

        public DataTable ListadoTipoSangre()
        {
            conexion = new ConexionBD();
            DataTable tabla = new DataTable();
            conexion.AbrirConexion();
            string query = "call listado_tipo_sangre;";
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
            consulta.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable CrearTipoSangre(String descripcion)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call crear_tipo_sangre ('" + descripcion + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable GetTipoSangre(int id)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call get_tipo_sangre (" + id + ");";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable EditarTipoSangre(int id, string descripcion)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call editar_tipo_sangre (" + id + ", '" + descripcion + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable EliminarTipoSangre(int id)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call eliminar_tipo_sangre (" + id + ");";
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
