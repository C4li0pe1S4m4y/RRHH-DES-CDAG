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
    public class ParentescoAD
    {
        ConexionBD conexion;

        public DataTable ListadoParentescos()
        {
            conexion = new ConexionBD();
            DataTable tabla = new DataTable();
            conexion.AbrirConexion();
            string query = "call listado_parentesco;";
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
            consulta.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable CrearParentesco (String parentesco)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            { 
                conexion.AbrirConexion();
                string query = "call crear_parentesco ('" + parentesco + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {
                
            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable GetParentesco (int id)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call get_parentesco (" + id + ");";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable EditarParentesco(int id, string parentesco)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call editar_parentesco (" + id + ", '" + parentesco + "');";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public DataTable EliminarParentesco(int id)
        {
            conexion = new ConexionBD();
            DataTable dt = new DataTable();
            try
            {
                conexion.AbrirConexion();
                string query = "call eliminar_parentesco (" + id + ");";
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
                consulta.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return dt;
        }

        public int IngresarFamiliar(string id_empleado, string nombre, string fecha_nacimiento, string contacto_emergencia, string telefono, string id_parentesco)
        {
            int result = 0;
            conexion = new ConexionBD();
            conexion.AbrirConexion();
            string query = string.Format("");
            try
            {
                query = string.Format("insert into Familiares (id_empleado,nombre,fecha_nacimiento,contacto_emergencia,telefono,id_parentesco) values ({0},'{1}','{2}',{3},{4},{5})",
                  id_empleado, nombre, fecha_nacimiento, contacto_emergencia, telefono, id_parentesco);
                MySqlCommand command = new MySqlCommand(query, conexion.conectar);
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            conexion.CerrarConexion();
            return result;
        }

        public DataSet listadoFamiliares(int id_empleado)
        {
            conexion = new ConexionBD();
            DataSet tabla = new DataSet();
            conexion.AbrirConexion();
            string query = string.Format("select f.id_familiar ID, f.nombre,f.fecha_nacimiento as 'Fecha Nacimiento',f.contacto_emergencia as 'Contacto De Emergencia',f.telefono,p.descripcion from familiares f" +
                " inner join parentesco p on p.id_parentesco = f.id_parentesco inner join new_empleados e on e.id_empleado = f.id_empleado where e.codigo = {0};", id_empleado);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conexion.conectar);
            consulta.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }

        public int ElliminarFamiliar(int id)
        {
            int result = 0;
            conexion = new ConexionBD();
            conexion.AbrirConexion();
            string query = string.Format("");
            try
            {
                query = string.Format("Delete from Familiares where id_familiar = {0}", id);
                MySqlCommand command = new MySqlCommand(query, conexion.conectar);
                result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            conexion.CerrarConexion();
            return result;
        }
    }
}
