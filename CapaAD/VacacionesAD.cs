
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using CapaEN;

namespace CapaAD
{
    public class VacacionesAD
    {
        ConexionBD conectar;

        public DataSet ObtenerContratoEmpleado(string criterio)
        {
            conectar = new ConexionBD();
            DataSet tabla = new DataSet();
            conectar.AbrirConexion();
            string query = string.Format("select concat(e.primer_nombre,' ',e.primer_apellido) as nombres,e.id_empleado,c.id_renglon_presupuestario,c.fecha_inicial from new_empleados e inner join contratos c on c.id_empleado = e.id_empleado where c.id_contrato = {0};", criterio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataSet ListadoVacaciones(int idvacacion)
        {
            conectar = new ConexionBD();
            DataSet tabla = new DataSet();
            conectar.AbrirConexion();
            string query = string.Format("select id_detalle_vacaciones ID, cantidad_dias as 'Cantidad', date_format(fecha_inicio,'%d/%m/%Y') as 'Fecha Inicio', date_format(fecha_fin,'%d/%m/%Y') as 'Fecha Final' from detalle_vacaciones where id_vacaciones ={0} ", idvacacion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataSet ObtenerDiasVacaciones(int id)
        {
            conectar = new ConexionBD();
            DataSet tabla = new DataSet();
            conectar.AbrirConexion();
            string query = string.Format("select fecha_inicio,dias_disponibles,dias_tomados,id_vacaciones from vacaciones where id_contrato = {0};", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public int InserVacaciones(int id, string fehca,string dias_disponibles,string dias_tomados,string dias,string id_empleado)
        {
            int result = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            int diasDispo = int.Parse(dias_disponibles) - int.Parse(dias);
            string query = string.Format("");
            if (id < 1)
            {
                query = string.Format("insert into vacaciones(fecha_inicio,dias_disponibles,dias_tomados,id_contrato,fecha_fin) values ('{0}',{1},{2},{3},'{4}')", 
                    fehca,dias_tomados, diasDispo, id_empleado,fehca);
                MySqlCommand command = new MySqlCommand(query, conectar.conectar);
                result = command.ExecuteNonQuery();
                
            }
            else
            {
                int diferencia = int.Parse(dias_disponibles) - int.Parse(dias);
                query = string.Format("Update  vacaciones set dias_tomados = '{0}' where id_vacaciones = {1};", diferencia, id);
                MySqlCommand command = new MySqlCommand(query, conectar.conectar);
                result = command.ExecuteNonQuery();
            }
            return result;
        }

        public int InsertVacacionesDetalle(int id_vaciones,string dias,string fechaI, string fechaF)
        {
            int result = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string query = string.Format("");
            if (id_vaciones < 1)
            {
                query = string.Format("insert into detalle_vacaciones(id_vacaciones,cantidad_dias,fecha_inicio,fecha_fin) values ((select max(id_vacaciones) from vacaciones),{0},'{1}','{2}')",
                   dias,fechaI,fechaF);
                MySqlCommand command = new MySqlCommand(query, conectar.conectar);
                result = command.ExecuteNonQuery();

            }
            else
            {
                query = string.Format("insert into detalle_vacaciones(id_vacaciones,cantidad_dias,fecha_inicio,fecha_fin) values ({0},{1},'{2}','{3}')",
                    id_vaciones,dias, fechaI, fechaF);
                MySqlCommand command = new MySqlCommand(query, conectar.conectar);
                result = command.ExecuteNonQuery();
            }
            return result;
        }

        public int EliminarVacacion(int id, int cantidad, string dias_disponibles, string idVacacion)
        {
            int result = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string query = string.Format("");
            try
            {
                query = string.Format("Delete from detalle_vacaciones where id_detalle_vacaciones = {0}", id);
                MySqlCommand command = new MySqlCommand(query, conectar.conectar);
                result = command.ExecuteNonQuery();
                int diferencia = int.Parse(dias_disponibles) + cantidad;
                query = string.Format("Update  vacaciones set dias_tomados = '{0}' where id_vacaciones = {1};", diferencia, idVacacion);
                command = new MySqlCommand(query, conectar.conectar);
                result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            conectar.CerrarConexion();
            return result;
        }






    }
}
