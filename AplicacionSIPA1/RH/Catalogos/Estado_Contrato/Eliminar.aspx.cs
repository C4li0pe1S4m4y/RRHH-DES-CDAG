using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.RH.Catalogos.Estado_Contrato
{
    public partial class Eliminar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción del estado del contrato a eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            EstadoContratoLN estadocontratoLN = new EstadoContratoLN();
            int id = Convert.ToInt32(Request["id"]);
            DataTable dt = estadocontratoLN.GetEstadoContrato(id);
            Button1.Attributes.Add("data-id", id.ToString());
            if (!Page.IsPostBack) descripcion.Text = dt.Rows[0]["descripcion"].ToString();
        }

        /// <summary>
        /// Elimina el estado del contrato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EliminarEstadoContrato(object sender, EventArgs e)
        {
            EstadoContratoLN estadocontratoLN = new EstadoContratoLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            DataTable dt = estadocontratoLN.EliminarEstadoContrato(id);
            if (!dt.HasErrors)
            {
                Response.Redirect("ListadoEstadoContrato.aspx");
            }
            else
            {
                Page_Load(sender, e);
            }
        }

        /// <summary>
        /// Redirecciona a la página para ver el listado de estados de contratos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("ListadoEstadoContrato.aspx");
        }
    }
}