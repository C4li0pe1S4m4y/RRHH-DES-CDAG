using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.RH.Catalogos.Enfermedad
{
    public partial class Editar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción de la enfermedad a editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            EnfermedadLN enfermedadLN = new EnfermedadLN();
            int id = Convert.ToInt32(Request["id"]);
            DataTable dt = enfermedadLN.GetEnfermedad(id);
            Button1.Attributes.Add("data-id", id.ToString());
            if (!Page.IsPostBack) descripcion.Text = dt.Rows[0]["descripcion"].ToString();
        }

        /// <summary>
        /// Edita la descripción de la enfermedad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditarEnfermedad(object sender, EventArgs e)
        {
            EnfermedadLN enfermedadLN = new EnfermedadLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            string descripcion = this.descripcion.Text;
            if (!string.IsNullOrEmpty(descripcion))
            {
                DataTable dt = enfermedadLN.EditarEnfermedad(id, descripcion.ToUpper());
                if (!dt.HasErrors)
                {
                    Response.Redirect("ListadoEnfermedad.aspx");
                }
                else
                {
                    Page_Load(sender, e);
                }
            }
        }

        /// <summary>
        /// Redirecciona a la página para ver el listado de enfermedades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("ListadoEnfermedad.aspx");
        }
    }
}