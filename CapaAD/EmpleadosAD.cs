using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using CapaEN;


namespace CapaAD
{
    public class EmpleadosAD
    {
        ConexionBD conectar;
        
       public DataTable DdlUnidades()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = "call slctNombreUnidad();" ;
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable DdlPuestos()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL sp_slctDatosEmpleado(0, 0, '', 0, 4);");
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable AlmacenarEmpleado(EmpleadosEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable dt = new DataTable();

           string idEmpleado, nombres, apellidos, direccion, telefono, email, idGenero, nit, cui, fechaNac, idPuesto, renglon, idUnidad, idEstado, sueldoNominal, usuario = "";
           idEmpleado = ObjEN.ID_EMPLEADO.ToString();
           nombres = "'" + ObjEN.NOMBRES + "'";
           apellidos = "'" + ObjEN.APELLIDOS + "'";
           direccion = "'" + ObjEN.DIRECCION + "'";
           telefono = "'" + ObjEN.TELEFONO + "'";
           email = "'" + ObjEN.EMAIL + "'";
           idGenero = ObjEN.ID_GENERO.ToString();
           nit = "'" + ObjEN.NIT + "'";
           cui = "'" + ObjEN.CUI + "'";

           fechaNac = "null";
           string[] f;
           if (!ObjEN.FECHA_NACIMINETO.Equals(string.Empty))
           {
               f = ObjEN.FECHA_NACIMINETO.Split('/');
               fechaNac = "'" + f[2] + "-" + f[1] + "-" + f[0];
           }           

           idPuesto = ObjEN.ID_PUESTO.ToString();
           renglon = "'" + ObjEN.RENGLON + "'";
           idUnidad = ObjEN.ID_UNIDAD.ToString();
           idEstado = ObjEN.ID_ESTADO.ToString();
           sueldoNominal = ObjEN.SUELDO_NOMINAL.ToString();
           usuario = ObjEN.USUARIO;

           nombres = nombres.Replace("''", "null");
           apellidos = apellidos.Replace("''", "null");
           direccion = direccion.Replace("''", "null");
           telefono = telefono.Replace("''", "null");
           email = email.Replace("''", "null");
           nit = nit.Replace("''", "null");
           cui = cui.Replace("''", "null");
           renglon = renglon.Replace("''", "null");
           //idGenero = idGenero.Replace("0", "null");
           //idPuesto = idPuesto.Replace("0", "null");
           //idUnidad = idUnidad.Replace("0", "null");
           //idEstado = idEstado.Replace("0", "null");
           sueldoNominal = ObjEN.SUELDO_NOMINAL.ToString();

           string query = "CALL sp_iue_empleados(" + idEmpleado + ", " + nombres + ", " + apellidos + ", " + direccion + ", " + telefono + ", " + email + ", " + idGenero + ", " + nit + ", " + cui + ", " + fechaNac + ", " + idPuesto + ", " + renglon + ", " + idUnidad + ", " + idEstado + ", " + sueldoNominal + ", '" + usuario + "', 1,'"+ObjEN.Motivo_Baja+"');";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(dt);
           conectar.CerrarConexion();
           return dt;
       }

       public DataTable EliminarEmpleado(int id)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = "CALL sp_iue_empleados(" + id + ", '', '', '', '', '', 0, '', '', null, 0, '', 0, 0, '', 2);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InformacionEmpleados(int id, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctDatosEmpleado({0}, 0, '', 0, {1});", id, opcion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       
       private DataSet armarDsResultado()
       {
           DataSet ds = new DataSet();
           DataTable dt = new DataTable("RESULTADO");

           dt.Columns.Add("ERRORES", typeof(String));
           dt.Columns.Add("MSG_ERROR", typeof(String));
           dt.Columns.Add("VALOR", typeof(String));
           dt.Columns.Add("CODIGO", typeof(String));
           ds.Tables.Add(dt);

           DataRow dr = ds.Tables[0].NewRow();
           ds.Tables[0].Rows.Add(dr);
           ds.Tables[0].Rows[0]["ERRORES"] = true;
           ds.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
           return ds;
       }

        #region New Code

        public DataTable Search (int codigo, string cui, string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido)
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "call search_empleados(" + codigo + ",'" + cui + "','" + primer_nombre + "','" + segundo_nombre + "','" +
                primer_apellido + "','" + segundo_apellido + "');";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable NuevoEmpleado (EmpleadoNew empleado)
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL crear_empleado(";
            query += empleado.codigo + ", '";
            query += empleado.cui + "', '";
            query += empleado.primer_nombre + "', '";
            query += empleado.segundo_nombre + "', '";
            query += empleado.primer_apellido + "', '";
            query += empleado.segundo_apellido + "', '";
            query += empleado.apellido_casada + "', '";
            query += empleado.nit + "', ";
            query += empleado.id_genero + ", ";
            query += "STR_TO_DATE('" + empleado.fecha_nacimiento.ToString("yyyy-MM-dd") + "', '%Y-%m-%d'), '";
            query += empleado.lugar_nacimiento + "', ";
            query += empleado.id_municipio_cui + ", ";
            query += empleado.telefono_movil.HasValue ? empleado.telefono_movil.Value.ToString() + ", " : "null, ";
            query += empleado.telefono_residencial.HasValue ? empleado.telefono_residencial.Value.ToString() + ", " : "null, ";
            query += empleado.id_estado_civil + ", ";
            query += empleado.tipo_vivienda + ", '";
            query += empleado.direccion_residencial + "', ";
            query += empleado.id_municipio_residencial + ", ";
            query += empleado.id_profesion + ", '";
            query += empleado.afiliacion_igss + "', '";
            query += empleado.licencia_conducir+"', ";
            query += empleado.id_tipo_licencia.HasValue ? empleado.id_tipo_licencia.ToString() : "null";
            query += ", ";
            query += empleado.id_archivo.HasValue ? empleado.id_archivo.ToString() : "null";
            query += ", '";
            query += empleado.correo + "');";
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
            string query = "call get_empleado(" + id_empleado + ");";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable EditarEmpleado(EmpleadoNew empleado)
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL editar_empleado(";
            query += empleado.codigo + ", '";
            query += empleado.cui.ToString() + "', '";
            query += empleado.primer_nombre + "', '";
            query += empleado.segundo_nombre + "', '";
            query += empleado.primer_apellido + "', '";
            query += empleado.segundo_apellido + "', '";
            query += empleado.apellido_casada + "', '";
            query += empleado.nit + "', ";
            query += empleado.id_genero + ", ";
            query += "STR_TO_DATE('" + empleado.fecha_nacimiento.ToString("yyyy-MM-dd") + "', '%Y-%m-%d'), '";
            query += empleado.lugar_nacimiento + "', ";
            query += empleado.id_municipio_cui + ", ";
            query += empleado.telefono_movil.HasValue ? empleado.telefono_movil.ToString() + ", " : "null, ";
            query += empleado.telefono_residencial.HasValue ? empleado.telefono_residencial.Value.ToString() + ", " : "null, ";
            query += empleado.id_estado_civil + ", ";
            query += empleado.tipo_vivienda + ", '";
            query += empleado.direccion_residencial + "', ";
            query += empleado.id_municipio_residencial + ", ";
            query += empleado.id_profesion + ", '";
            query += empleado.afiliacion_igss + "', '";
            query += empleado.licencia_conducir + "', ";
            query += empleado.id_tipo_licencia.HasValue ? empleado.id_tipo_licencia.ToString() : "null";
            query += ", ";
            query += empleado.id_archivo.HasValue ? empleado.id_archivo.ToString() : "null";
            query += ", '";
            query += empleado.correo + "');";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable EditarAlergiasEnfermedades(AlergiasYEnfermedadesNew alergiasenfermedades)
        {
            string query = "call eliminar_empleado_alergia(" + alergiasenfermedades.id_empleado + ");" +
                "call eliminar_empleado_enfermedad(" + alergiasenfermedades.id_empleado + ");" +
                "call editar_empleado_tipo_sangre(" + alergiasenfermedades.id_empleado + "," + alergiasenfermedades.id_tipo_sangre + ");";
            for (int i = 0; i < alergiasenfermedades.Alergias.Count; i++)
            {
                query += "call crear_empleado_alergia(" + alergiasenfermedades.id_empleado + "," + alergiasenfermedades.Alergias[i] + ");";
            }
            for (int i = 0; i < alergiasenfermedades.Enfermedades.Count; i++)
            {
                query += "call crear_empleado_enfermedad(" + alergiasenfermedades.id_empleado + "," + alergiasenfermedades.Enfermedades[i] + ");";
            }

            conectar = new ConexionBD();
            conectar.AbrirConexion();
            DataTable dt = new DataTable();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public List<bool> AlergiasSelected(int id_empleado, List<ListItem> alergias)
        {
            List<bool> respuesta = new List<bool>();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            DataTable dt = new DataTable();
            string query = "call get_empleado_alergia(" + id_empleado + ");";
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);

            bool encontrado;
            for (int i = 0; i < alergias.Count; i++)
            {
                encontrado = false;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (alergias[i].Value == dt.Rows[j].ItemArray[1].ToString())
                    {
                        respuesta.Add(true);
                        encontrado = true;
                    }
                }
                if (!encontrado)
                {
                    respuesta.Add(false);
                }
            }
            return respuesta;
        }

        public List<bool> EnfermedadesSelected(int id_empleado, List<ListItem> enfermedades)
        {
            List<bool> respuesta = new List<bool>();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            DataTable dt = new DataTable();
            string query = "call get_empleado_enfermedad(" + id_empleado + ");";
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);

            bool encontrado;
            for (int i = 0; i < enfermedades.Count; i++)
            {
                encontrado = false;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (enfermedades[i].Value == dt.Rows[j].ItemArray[1].ToString())
                    {
                        respuesta.Add(true);
                        encontrado = true;
                    }
                }
                if (!encontrado)
                {
                    respuesta.Add(false);
                }
            }
            return respuesta;
        }

        public DataTable ReporteEmpleados()
        {
            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "call rpt_empleados;";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        #endregion


    }
}
