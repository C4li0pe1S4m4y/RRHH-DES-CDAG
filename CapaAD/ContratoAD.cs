using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using System.Data;
using MySql.Data.MySqlClient;
using CapaEN;

namespace CapaAD
{
    public class ContratoAD
    {
        ConexionBD conexion;

        /// <summary>
        /// Inserta un nuevo contrato a la BD
        /// </summary>
        /// <param name="p_contrato">Objeto contrato con todos los datos</param>
        /// <returns></returns>
        public DataTable CrearContrato (Contratos p_contrato)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            { 
                conexion.AbrirConexion();
                string query = "call crear_contrato (" + p_contrato.id_empleado + ",'" + p_contrato.puesto + "','" + p_contrato.area + "'," + p_contrato.id_renglon_presupuestario + ",'" + p_contrato.jefe_inmediato  + "','" + p_contrato.puesto_jefe_inmediato + "'," +p_contrato.salario + ",'" + p_contrato.fecha_inicial + "','" + p_contrato.fecha_final + "'," + p_contrato.id_estado_contrato + ",'" + p_contrato.motivo + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {
                
            }
            conexion.CerrarConexion();
            return dt;
        }

        /// <summary>
        /// Obtiene datos del contrato desde la bd
        /// </summary>
        /// <param name="id_empleado"></param>
        /// <returns></returns>
        public DataTable GetContrato (int id_empleado)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call get_contrato (" + id_empleado + ");";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        /// <summary>
        /// Edita los datos de un contrato en la BD
        /// </summary>
        /// <param name="p_contrato">Objeto contrato con los datos del mismo</param>
        /// <returns></returns>
        public DataTable EditarContrato(Contratos p_contrato)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call editar_contrato (" + p_contrato.id_contrato + "," + p_contrato.id_empleado + ",'" + p_contrato.puesto + "','" + p_contrato.area + "'," + p_contrato.id_renglon_presupuestario + ",'" + p_contrato.puesto_jefe_inmediato + "'," + ",'" + p_contrato.jefe_inmediato + "'," + p_contrato.salario + ",'" + p_contrato.fecha_inicial + "','" + p_contrato.fecha_final + "'," + p_contrato.id_estado_contrato + ",'" + p_contrato.motivo + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        /// <summary>
        /// Deshabilita un contrato en la BD
        /// </summary>
        /// <param name="p_id_contrato">Id del contrato a deshabilitar</param>
        /// <returns></returns>
        public DataTable EliminarContrato(int p_id_contrato)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call eliminar_contrato (" + p_id_contrato + ");";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        /// <summary>
        /// Obtiene el historial del contrato que estan almacenados en la BD para un empleado
        /// </summary>
        /// <param name="p_id_empleado">Id del empleado</param>
        /// <returns></returns>
        public DataTable ObtenerHistorialContrato(int p_id_empleado)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call listado_historial_contrato (" + p_id_empleado + ");";
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
