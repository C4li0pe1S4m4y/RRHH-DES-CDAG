using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEN;
using MySql.Data.MySqlClient;

namespace CapaAD
{
    /// <summary>
    /// Clase constancia educativa base de datos 
    /// </summary>
    public class ConstanciasEducativasAD
    {
        /// <summary>
        /// Conexión a base de datos
        /// </summary>
        ConexionBD conectar;

        /// <summary>
        ///  Obtener constancia educativas
        /// </summary>
        /// <param name="id_empleado">Identificador de empleado</param>
        /// <returns></returns>
        public DataTable GetConstanciasEducativas(int id_empleado)
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "call get_constancias_educativas(" + id_empleado + ");";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        /// <summary>
        ///  Obtener constancia educativa
        /// </summary>
        /// <param name="id_empleado">Identificador de empleado</param>
        /// <returns></returns>
        public DataTable GetConstanciaEducativa(int id_constancia)
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "call get_constancia_educativa(" + id_constancia + ");";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        /// <summary>
        /// Eliminar constancia educativa 
        /// </summary>
        /// <param name="id">identificador constancia</param>
        /// <returns></returns>
        public DataTable EliminarConstanciaEducativa(int id)
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "call eliminar_constancia_educativa(" + id + ");";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        /// <summary>
        /// Crear constancia 
        /// </summary>
        /// <param name="constancia"> objeto constancia </param>
        /// <returns></returns>
        public DataTable NuevaConstancia(ConstanciaEducativa constancia)
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL crear_constancia_educativa(";
            query += constancia.id_empleado + ", ";
            query += constancia.id_nivel + ", '";
            query += constancia.lugar + "', '";
            query += constancia.descripcion + "', ";
            query += "STR_TO_DATE('" + constancia.fecha_desde.ToString("yyyy-MM-dd") + "', '%Y-%m-%d'), ";
            query += "STR_TO_DATE('" + constancia.fecha_hasta.ToString("yyyy-MM-dd") + "', '%Y-%m-%d'), ";
            query += (constancia.id_archivo.HasValue ? constancia.id_archivo.ToString() : "null") + ") ";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        /// <summary>
        /// Modificar constancia 
        /// </summary>
        /// <param name="constancia"> objeto constancia </param>
        /// <returns></returns>
        public DataTable ModificarConstancia(ConstanciaEducativa constancia)
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL editar_constancia_educativa(";
            query += constancia.id_constancia + ", ";
            query += constancia.id_nivel + ", '";
            query += constancia.lugar + "', '";
            query += constancia.descripcion + "', ";
            query += "STR_TO_DATE('" + constancia.fecha_desde.ToString("yyyy-MM-dd") + "', '%Y-%m-%d'), ";
            query += "STR_TO_DATE('" + constancia.fecha_hasta.ToString("yyyy-MM-dd") + "', '%Y-%m-%d'), ";
            query += (constancia.id_archivo.HasValue ? constancia.id_archivo.ToString() : "null") + ") ";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }
    }
}
