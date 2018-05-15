using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEN;
using CapaLN;

namespace AplicacionSIPA1.RH.Catalogos.Estado_Contrato
{
    public partial class Editar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción del estado del contrato a editar 
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
        /// Edita la descripción del estado del contrato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditarEstadoContrato(object sender, EventArgs e)
        {
            EstadoContratoLN estadocontratoLN = new EstadoContratoLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            string descripcion = this.descripcion.Text;
            if (!string.IsNullOrEmpty(descripcion))
            {
                DataTable dt = estadocontratoLN.EditarEstadoContrato(id, descripcion.ToUpper());
                if (!dt.HasErrors)
                {
                    Response.Redirect("ListadoEstadoContrato.aspx");
                }
                else
                {
                    Page_Load(sender, e);
                }
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