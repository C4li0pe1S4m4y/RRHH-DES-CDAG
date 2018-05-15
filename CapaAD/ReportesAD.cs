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
    public class ReportesAD
    {

        ConexionBD conectar;



        public DataTable ReportesSipa(int id, int id2, string criterio, int opcion)
        {

            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("CALL sp_reportes({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            tabla.TableName = "Datos";
            return tabla;
        }




/// <summary>
/// ///////////////////////////////////////////////////////////////////
/// </summary>
/// <param name="idUnidad"></param>
/// <param name="idPoa"></param>
/// <returns></returns>
        public DataTable ConsultaProcedimiento(Int32 idUnidad, int idPoa)
        {

            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call sp_slctPlanAccionGB ({0}, {1})", idUnidad, idPoa); 
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            tabla.TableName="DataReporte";
            return tabla;
        }

        public DataTable unidadUsuario(string usuario)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsUnidadesUsuario ('{0}')", usuario); 
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable poaUsuario(int anio,int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsDatosPoa ({0},{1})", idUnidad, anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

             
        public DataTable fadnsSaldoRetencion(int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsFADNSaldo ({0});", anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable fadnsSaldosGeneral(int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsFADNGastos ({0});",anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoReglones(int opcion, int par)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldosReglones ({0},{1});", opcion,par);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoReglonesUnidad(string letra, int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPVReglones ('{0}',{1});", letra, anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoResumenes(int opcion, int par)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldosResumen ({0},{1});", opcion, par);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoProveedores(int opcion, int par)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoProveedores ({0},{1});", opcion, par);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable HistorialMovimiento(int opcion, int parametro, int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsHistorialMovimientos ({0},{1},{2});",opcion,parametro, anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        
        public DataSet SaldosxUnidad(int anio)
        {
            conectar = new ConexionBD();
            DataSet tabla = new DataSet();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select t.id as Unidad, t.MontoPoa, t.Codificado,  ((t.MontoPoa - t.Codificado)) Saldo from " +
                "(select u.unidad id, COALESCE(SUM(da.monto), 0) MontoPoa, COALESCE((SELECT SUM(gasto)  as Gasto FROM unionpedido up, sipa_detalles_accion da, sipa_acciones aa "+
                " WHERE up.estado_financiero = 1 AND up.id_detalle_accion = da.id_detalle AND da.id_accion = aa.id_accion AND da.no_renglon = da.no_renglon AND aa.id_poa = p.id_poa"+
                " ), 0) Codificado from sipa_acciones d inner join sipa_poa p on p.id_poa = d.id_poa inner join sipa_detalles_accion da on da.id_accion = d.id_accion " +
                " inner join ccl_unidades u on u.id_unidad = p.id_unidad and p.anio = {0} Group by p.id_unidad )t;",  anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
    }
}
