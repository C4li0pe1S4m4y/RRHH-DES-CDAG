using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using CapaEN;
using System.Web.UI.WebControls;
using System.Data;


namespace CapaLN
{
    public class EmpleadosLN
    {
        EmpleadosAD ObjAD;

        public void DdlUnidades(DropDownList drop)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Unidad >>");
            drop.Items[0].Value = "0";
            ObjAD = new EmpleadosAD();
            drop.DataSource = ObjAD.DdlUnidades();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlPuestos(DropDownList drop)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Puesto >>");
            drop.Items[0].Value = "0";
            ObjAD = new EmpleadosAD();
            drop.DataSource = ObjAD.DdlPuestos();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public DataSet AlmacenarEmpleado(EmpleadosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new EmpleadosAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarEmpleado(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString(); ;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarEmpleado(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarEmpleado(int id)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new EmpleadosAD();
            try
            {
                DataTable dt = ObjAD.EliminarEmpleado(id);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarEmpleado(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionEmpleado(int id, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new EmpleadosAD();

            try
            {
                DataTable dt = ObjAD.InformacionEmpleados(id, opcion);

                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionEmpleado(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet armarDsResultado()
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

        #region Nuevo codigo

        EmpleadoNew empleado;

        public DataTable Search(int codigo, string cui, string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido)
        {
            DataTable dt = new DataTable();
            try
            {
                ObjAD = new EmpleadosAD();
                dt = ObjAD.Search(codigo, cui, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido);
            }
            catch (Exception ex)
            {
                
            }
            return dt;
        }



        
        public DataTable NuevoEmpleado (EmpleadoNew empleado)
        {
            EmpleadosAD empleadoAD = new EmpleadosAD();
            return empleadoAD.NuevoEmpleado(empleado);
        }

        public DataTable GetEmpleado(int id_empleado)
        {
            EmpleadosAD empleadoAD = new EmpleadosAD();
            return empleadoAD.GetEmpleado(id_empleado);
        }

        public DataTable EditarEmpleado(EmpleadoNew empleado)
        {
            EmpleadosAD empleadoAD = new EmpleadosAD();
            return empleadoAD.EditarEmpleado(empleado);
        }

        public DataTable EditarAlergiaEnfermedad(AlergiasYEnfermedadesNew alergiasenfermedades)
        {
            EmpleadosAD empleadoAD = new EmpleadosAD();
            return empleadoAD.EditarAlergiasEnfermedades(alergiasenfermedades);
        }

        public List<bool> AlergiasSelected(int id_empleado, List<ListItem> alergias)
        {
            EmpleadosAD empleadoAD = new EmpleadosAD();
            return empleadoAD.AlergiasSelected(id_empleado, alergias);
        }

        public List<bool> EnfermedadesSelected(int id_empleado, List<ListItem> enfermedades)
        {
            EmpleadosAD empleadoAD = new EmpleadosAD();
            return empleadoAD.EnfermedadesSelected(id_empleado, enfermedades);
        }

        public DataTable ReporteEmpleados()
        {
            EmpleadosAD empleadoAD = new EmpleadosAD();
            return empleadoAD.ReporteEmpleados();
        }

        #endregion
    }
}
