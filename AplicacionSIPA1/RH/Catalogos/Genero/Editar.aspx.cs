using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEN;
using CapaLN;

namespace AplicacionSIPA1.RH.Catalogos.Genero
{
    public partial class Editar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción del género a editar 
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
        /// Edita la descripción del género
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditarGenero(object sender, EventArgs e)
        {
            GeneroLN generoLN = new GeneroLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            string descri = this.descripcion.Text;
            if (!string.IsNullOrEmpty(descri))
            {
                DataTable dt = generoLN.EditarGenero(id, descri.ToUpper());
                if (!dt.HasErrors)
                {
                    Response.Redirect("ListadoGeneros.aspx");
                }
                else
                {
                    Page_Load(sender, e);
                }
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