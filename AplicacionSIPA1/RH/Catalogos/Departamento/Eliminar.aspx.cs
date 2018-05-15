using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.RH.Catalogos.Departamento
{
    public partial class Eliminar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción del departamento a eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            DepartamentoLN departamentoLN = new DepartamentoLN();
            int id = Convert.ToInt32(Request["id"]);
            DataTable dt = departamentoLN.GetDepartamento(id);
            Button1.Attributes.Add("data-id", id.ToString());
            if (!Page.IsPostBack) descripcion.Text = dt.Rows[0]["descripcion"].ToString();
        }

        /// <summary>
        /// Elimina el departamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EliminarDepartamento(object sender, EventArgs e)
        {
            DepartamentoLN departamentoLN = new DepartamentoLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            DataTable dt = departamentoLN.EliminarDepartamento(id);
            if (!dt.HasErrors)
            {
                Response.Redirect("ListadoDepartamento.aspx");
            }
            else
            {
                Page_Load(sender, e);
            }
        }

        /// <summary>
        /// Redirecciona a la página para ver el listado de departamentos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("ListadoDepartamento.aspx");
        }
    }
}