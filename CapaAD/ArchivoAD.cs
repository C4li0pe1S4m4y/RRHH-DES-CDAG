using CapaEN;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAD
{
    public class ArchivoAD
    {
        ConexionBD conectar;

        public DataTable GuardarArchivo(Archivo archivo)
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL crear_archivo('";
            query += archivo.url + "'); ";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }
        public DataTable ModificarArchivo(Archivo archivo)
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL modificar_archivo( ";
            query += archivo.id_archivo + " , '";
            query += archivo.url + "'); ";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable GetEmpleado(int id_empleado)
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "call get_empleado_imagen(" + id_empleado + ");";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }



    }
}
