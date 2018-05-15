using CapaLN;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.RH.Catalogos.Genero
{
    public partial class Eliminar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción del género a eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            GeneroLN generoLN = new GeneroLN();
            int id = Convert.ToInt32(Request["id"]);
            DataTable dt = generoLN.GetGenero(id);
            Button1.Attributes.Add("data-id", id.ToString());
            if (!Page.IsPostBack) descripcion.Text = dt.Rows[0]["descripcion"].ToString();
        }

        /// <summary>
        /// Elimina el género
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EliminarGenero(object sender, EventArgs e)
        {
            GeneroLN generoLN = new GeneroLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            DataTable dt = generoLN.EliminarGenero(id);
            if (!dt.HasErrors)
            {
                Response.Redirect("ListadoGeneros.aspx");
            }
            else
            {
                Page_Load(sender, e);
            }
        }

        /// <summary>
        /// Redirecciona a la página para ver el listado de géneros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("ListadoGeneros.aspx");
        }
    }
}