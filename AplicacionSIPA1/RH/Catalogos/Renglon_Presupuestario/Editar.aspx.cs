using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.RH.Catalogos.Renglon_Presupuestario
{
    public partial class Editar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción del renglón presupuestario a editar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            RenglonPresupuestarioLN renglonpresupuestarioLN = new RenglonPresupuestarioLN();
            int id = Convert.ToInt32(Request["id"]);
            DataTable dt = renglonpresupuestarioLN.GetRenglonPresupuestario(id);
            Button1.Attributes.Add("data-id", id.ToString());
            if (!Page.IsPostBack) descripcion.Text = dt.Rows[0]["descripcion"].ToString();
        }

        /// <summary>
        /// Edita la descripción del renglón presupuestario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditarRenglonPresupuestario(object sender, EventArgs e)
        {
            RenglonPresupuestarioLN renglonpresupuestarioLN = new RenglonPresupuestarioLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            string descripcion = this.descripcion.Text;
            if (!string.IsNullOrEmpty(descripcion))
            {
                DataTable dt = renglonpresupuestarioLN.EditarRenglonPresupuestario(id, descripcion.ToUpper());
                if (!dt.HasErrors)
                {
                    Response.Redirect("ListadoRenglonPresupuestario.aspx");
                }
                else
                {
                    Page_Load(sender, e);
                }
            }
        }

        /// <summary>
        /// Redirecciona a la página para ver el listado de renglones presupuestarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("ListadoRenglonPresupuestario.aspx");
        }
    }
}