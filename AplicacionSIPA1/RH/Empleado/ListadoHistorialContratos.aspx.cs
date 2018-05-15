using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEN;
using CapaLN;
using System.Data;

namespace AplicacionSIPA1.RH.Empleado
{
    public partial class ListadoHistorialContratos : System.Web.UI.Page
    {
        int id_empleado;

        /// <summary>
        /// Carga los contratos que ha tenido el empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session["id"] = Request["id"];
            id_empleado = Convert.ToInt32(Request["id"]);
            CargarHistorial();

        }

        /// <summary>
        /// Método con el cuál se obtienen los contratos asignados el empleado según su código de empleado
        /// </summary>
        public void CargarHistorial()
        {
            ContratoLN contratoLN = new ContratoLN();
            try
            {
                DataTable datos_contrato = contratoLN.ObtenerHistorialContrato(id_empleado);

                if (!datos_contrato.HasErrors)
                {
                    for (int i = 0; i < datos_contrato.Rows.Count; i++)
                    {
                        int fil = i + 1;
                        int id = Convert.ToInt32(datos_contrato.Rows[i]["id_empleado"]);
                        tabla_contratos.Rows.Add(NewRow());
                        tabla_contratos.Rows[fil].Cells.Add(NewCell());
                        tabla_contratos.Rows[fil].Cells.Add(NewCell());
                        tabla_contratos.Rows[fil].Cells.Add(NewCell());
                        tabla_contratos.Rows[fil].Cells.Add(NewCell());
                        tabla_contratos.Rows[fil].Cells.Add(NewCell());
                        tabla_contratos.Rows[fil].Cells.Add(NewCell());
                        tabla_contratos.Rows[fil].Cells.Add(NewCell());
                        tabla_contratos.Rows[fil].Cells.Add(NewCell());
                        tabla_contratos.Rows[fil].Cells.Add(NewCell());
                        tabla_contratos.Rows[fil].Cells.Add(NewCell());

                        tabla_contratos.Rows[fil].Cells[0].Text = datos_contrato.Rows[i]["id_contrato"].ToString();
                        tabla_contratos.Rows[fil].Cells[1].Text = datos_contrato.Rows[i]["puesto"].ToString();
                        tabla_contratos.Rows[fil].Cells[2].Text = datos_contrato.Rows[i]["area"].ToString();
                        tabla_contratos.Rows[fil].Cells[3].Text = ObtenerRenglon(Convert.ToInt32(datos_contrato.Rows[i]["id_renglon_presupuestario"].ToString()));
                        tabla_contratos.Rows[fil].Cells[4].Text = datos_contrato.Rows[i]["salario"].ToString();
                        tabla_contratos.Rows[fil].Cells[5].Text = datos_contrato.Rows[i]["jefe_inmediato"].ToString();
                        tabla_contratos.Rows[fil].Cells[6].Text = Convert.ToDateTime(datos_contrato.Rows[0]["fecha_inicial"].ToString()).ToString("dd-MM-yyyy");
                        tabla_contratos.Rows[fil].Cells[7].Text = Convert.ToDateTime(datos_contrato.Rows[0]["fecha_fin"].ToString()).ToString("dd-MM-yyyy");
                        tabla_contratos.Rows[fil].Cells[8].Text = datos_contrato.Rows[i]["motivo"].ToString();
                        tabla_contratos.Rows[fil].Cells[9].Text = ObtenerEstado(Convert.ToInt32(datos_contrato.Rows[i]["id_estado_contrato"].ToString()));


                    }
                }
            }
            catch (Exception ex)
            {

            }
           
        }

        private TableRow NewRow()
        {
            TableRow tr = new TableRow();

            return tr;
        }

        private TableCell NewCell()
        {
            TableCell cell = new TableCell();

            return cell;
        }

        /// <summary>
        /// Función para obtener la descripción del renglón presupuestario
        /// </summary>
        /// <param name="id_renglon">Id del renglón presupuestario a obtener</param>
        /// <returns></returns>
        private String ObtenerRenglon(int id_renglon)
        {
            string descripcion = "";

            RenglonPresupuestarioLN renglon = new RenglonPresupuestarioLN();
            DataTable datos_contrato = renglon.GetRenglonPresupuestario(id_renglon);
            if (!datos_contrato.HasErrors)
            {
                descripcion = datos_contrato.Rows[0]["descripcion"].ToString();
            }

            return descripcion;
        }

        /// <summary>
        /// Función para obtener la descripción del estado del contrato
        /// </summary>
        /// <param name="id_estado">Id del estado de contrato a obtener</param>
        /// <returns></returns>
        private String ObtenerEstado(int id_estado)
        {
            string descripcion = "";

            EstadoContratoLN estado = new EstadoContratoLN();
            DataTable datos_contrato = estado.GetEstadoContrato(id_estado);
            if (!datos_contrato.HasErrors)
            {
                descripcion = datos_contrato.Rows[0]["descripcion"].ToString();
            }

            return descripcion;
        }

        /// <summary>
        /// Redirecciona a la página para editar el empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("Editar.aspx?id=" + Request["id"] + "#tab_contrato");
        }

    }
}