
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

    public class VacacionesSolicitudAD
    {


        ConexionBD conectar;

        public DataSet ListadoVacaciones(int idvacacion)
        {
            conectar = new ConexionBD();
            DataSet tabla = new DataSet();
            conectar.AbrirConexion();
            string query = string.Format("select a.codigo, trim(concat(a.primer_nombre,' ',a.primer_apellido,' ',a.segundo_apellido))  as nombre,b.puesto, b.area from new_empleados a, contratos b where  a.id_empleado = b.id_empleado order by  a.codigo desc");
            //string query = string.Format("select a.codigo, trim(concat(a.primer_nombre,' ',a.primer_apellido,' ',a.segundo_apellido))  as nombre,b.puesto, b.area from new_empleados a, contratos b where  a.id_empleado = b.id_empleado order by  a.codigo desc");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }



    }
}
