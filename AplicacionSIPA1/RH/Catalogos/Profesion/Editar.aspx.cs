using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEN;
using CapaLN;


namespace AplicacionSIPA1.RH.Catalogos.Profesion
{
    public partial class Editar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción de la profesión a editar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ProfesionLN generoLN = new ProfesionLN();
            int id = Convert.ToInt32(Request["id"]);
            DataTable dt = generoLN.GetProfesion(id);
            Button1.Attributes.Add("data-id", id.ToString());
            if (!Page.IsPostBack) descripcion.Text = dt.Rows[0]["descripcion"].ToString();
        }

        /// <summary>
        /// Edita la descripción de la profesión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditarProfesion(object sender, EventArgs e)
        {
            ProfesionLN profesionLN = new ProfesionLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            string descri = this.descripcion.Text;
            if (!string.IsNullOrEmpty(descri))
            {
                DataTable dt = profesionLN.EditarProfesion(id, descri.ToUpper());
                if (!dt.HasErrors)
                {
                    Response.Redirect("ListadoProfesion.aspx");
                }
                else
                {
                    Page_Load(sender, e);
                }
            }
        }

        /// <summary>
        /// Redirecciona a la página para ver el listado de profesiones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("ListadoProfesion.aspx");
        }
    }
}