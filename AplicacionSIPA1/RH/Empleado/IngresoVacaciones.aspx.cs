using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace AplicacionSIPA1.RH.Vacaciones
{
    public partial class IngresoVacaciones : System.Web.UI.Page
    {
        VacacionesLN objVac;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                idVacacion.Text = "0";
                int id = Convert.ToInt32(Request["id"]);
                idContrato.Text = id.ToString();
                objVac = new VacacionesLN();
                DataSet dsResultado = objVac.ObtenerContratoEmpleado(id.ToString());
                if (dsResultado.Tables[0].Rows.Count > 0)
                {
                    lblCodigo.Text = dsResultado.Tables[0].Rows[0]["id_empleado"].ToString() + "-" + dsResultado.Tables[0].Rows[0]["nombres"].ToString();
                    lblFecha.Text = Convert.ToDateTime(dsResultado.Tables[0].Rows[0]["fecha_inicial"].ToString(), CultureInfo.GetCultureInfo("es-GT")).ToString("dd/MM/yyyy hh:mm:ss");

                    dsResultado = objVac.ObtenerDiasVacaciones(int.Parse(idContrato.Text));
                    if (dsResultado.Tables[0].Rows.Count > 0)
                    {
                        txtTotalVacaciones.Text = dsResultado.Tables[0].Rows[0]["dias_disponibles"].ToString();
                        txtDisponibles.Text = dsResultado.Tables[0].Rows[0]["dias_tomados"].ToString();
                        idVacacion.Text = dsResultado.Tables[0].Rows[0]["id_vacaciones"].ToString();

                        dsResultado = objVac.ListadoVacaciones(int.Parse(idVacacion.Text));
                        tabla_vacaciones.DataSource = dsResultado;
                        tabla_vacaciones.DataBind();
                    }
                    else
                    {
                        int inicio = 0;
                        string temp = lblFecha.Text.ToString().Substring(6, 5);
                        int.TryParse(temp, out inicio);
                        int numero_anios = DateTime.Now.Year - inicio;
                        if (1 > numero_anios && numero_anios < 6)
                        {
                            txtTotalVacaciones.Text = "22";
                            txtDisponibles.Text = "22";
                        }
                        else if (numero_anios < 12)
                        {
                            txtTotalVacaciones.Text = "24";
                            txtDisponibles.Text = "24";
                        }
                        else
                        {
                            txtTotalVacaciones.Text = "26";
                            txtDisponibles.Text = "26";

                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "Mensaje", "alert('Empleado No encontrado');", true);
                }
            }
        }



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           
            if (int.Parse(txtDias.Text) < int.Parse(txtDisponibles.Text))
            {
                if (!string.IsNullOrEmpty(txtInicioVac.Text) && !string.IsNullOrEmpty(txtFinVac.Text))
                {
                    try
                    {
                        objVac = new VacacionesLN();
                        int result = objVac.InserVacaciones(int.Parse(idVacacion.Text), lblFecha.Text, txtDisponibles.Text, txtTotalVacaciones.Text, txtDias.Text, idContrato.Text);
                        if (result == 1)
                        {
                            int diasg = int.Parse(txtDisponibles.Text) - int.Parse(txtDias.Text);
                            result = objVac.InsertVacacionesDetalle(int.Parse(idVacacion.Text), txtDias.Text, txtInicioVac.Text, txtFinVac.Text);
                            if (result == 1)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "Mensaje", "alert('Guardado Exitosamente');", true);
                                int id = Convert.ToInt32(Request["id"]);
                                objVac = new VacacionesLN();
                                DataSet dsResultado = objVac.ObtenerContratoEmpleado(id.ToString());
                                if (dsResultado.Tables[0].Rows.Count > 0)
                                {
                                    lblCodigo.Text = dsResultado.Tables[0].Rows[0]["id_empleado"].ToString() + "-" + dsResultado.Tables[0].Rows[0]["nombres"].ToString();
                                    lblFecha.Text = dsResultado.Tables[0].Rows[0]["fecha_inicial"].ToString();

                                    dsResultado = objVac.ObtenerDiasVacaciones(int.Parse(idContrato.Text));
                                    if (dsResultado.Tables[0].Rows.Count > 0)
                                    {
                                        txtTotalVacaciones.Text = dsResultado.Tables[0].Rows[0]["dias_disponibles"].ToString();
                                        txtDisponibles.Text = dsResultado.Tables[0].Rows[0]["dias_tomados"].ToString();
                                        idVacacion.Text = dsResultado.Tables[0].Rows[0]["id_vacaciones"].ToString();

                                        dsResultado = objVac.ListadoVacaciones(int.Parse(idVacacion.Text));
                                        tabla_vacaciones.DataSource = dsResultado;
                                        tabla_vacaciones.DataBind();
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "Mensaje", "alert('Vacaciones no Ingresadas');", true);
                                Page_Load(sender, e);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
                else
                {
                    lblError.Text = "Error: Ingresar las dos fechas";
                }
            }
            else
            {
                lblError.Text = "Error: Los días a pedir superan a días disponibles";
            }

        }

        /// <summary>
        /// Redirecciona a la página de edición de empleados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("Editar.aspx?id=" + Request["emp"]);
        }

        protected void tabla_vacaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idDetalle = int.Parse(e.Keys["ID"].ToString());
                int cantidad = int.Parse(e.Keys["Cantidad"].ToString());
                if (idDetalle == 0)
                    throw new Exception("No existe Vacacion para eliminar");
                VacacionesLN vacaciones = new VacacionesLN();
                int result = vacaciones.EliminarVacacion(idDetalle, cantidad, txtDisponibles.Text, idVacacion.Text);
                if (result == 1)
                {
                    int id = Convert.ToInt32(Request["id"]);
                    objVac = new VacacionesLN();
                    DataSet dsResultado = objVac.ObtenerContratoEmpleado(id.ToString());
                    if (dsResultado.Tables[0].Rows.Count > 0)
                    {
                        lblNombre.Text = dsResultado.Tables[0].Rows[0]["nombres"].ToString();
                        lblCodigo.Text = dsResultado.Tables[0].Rows[0]["id_empleado"].ToString();
                        lblFecha.Text = dsResultado.Tables[0].Rows[0]["fecha_inicial"].ToString();

                        dsResultado = objVac.ObtenerDiasVacaciones(int.Parse(idContrato.Text));
                        if (dsResultado.Tables[0].Rows.Count > 0)
                        {
                            txtTotalVacaciones.Text = dsResultado.Tables[0].Rows[0]["dias_disponibles"].ToString();
                            txtDisponibles.Text = dsResultado.Tables[0].Rows[0]["dias_tomados"].ToString();
                            idVacacion.Text = dsResultado.Tables[0].Rows[0]["id_vacaciones"].ToString();

                            dsResultado = objVac.ListadoVacaciones(int.Parse(idVacacion.Text));
                            tabla_vacaciones.DataSource = dsResultado;
                            tabla_vacaciones.DataBind();
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}