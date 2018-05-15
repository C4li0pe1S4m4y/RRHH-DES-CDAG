using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.RH.Catalogos.Alergia
{
    public partial class Eliminar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción de la alergia a eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            AlergiaLN alergiaLN = new AlergiaLN();
            int id = Convert.ToInt32(Request["id"]);
            DataTable dt = alergiaLN.GetAlergia(id);
            Button1.Attributes.Add("data-id", id.ToString());
            if (!Page.IsPostBack) descripcion.Text = dt.Rows[0]["descripcion"].ToString();
        }

        /// <summary>
        /// Elimina la alergia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EliminarAlergia(object sender, EventArgs e)
        {
            AlergiaLN alergiaLN = new AlergiaLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            DataTable dt = alergiaLN.EliminarAlergia(id);
            if (!dt.HasErrors)
            {
                Response.Redirect("ListadoAlergia.aspx");
            }
            else
            {
                Page_Load(sender, e);
            }
        }
        /// <summary>
        /// Redirecciona a la página para ver el listado de alergias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("ListadoAlergia.aspx");
        }
    }
}