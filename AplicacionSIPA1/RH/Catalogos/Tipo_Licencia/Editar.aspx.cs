using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.RH.Catalogos.Tipo_Licencia
{
    public partial class Editar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción del tipo de licencia a editar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoLicenciaLN tipolicenciaLN = new TipoLicenciaLN();
            int id = Convert.ToInt32(Request["id"]);
            DataTable dt = tipolicenciaLN.GetTipoLicencia(id);
            Button1.Attributes.Add("data-id", id.ToString());
            if (!Page.IsPostBack) descripcion.Text = dt.Rows[0]["descripcion"].ToString();
        }

        /// <summary>
        /// Edita la descripción del tipo de licencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditarTipoLicencia(object sender, EventArgs e)
        {
            TipoLicenciaLN tipolicenciaLN = new TipoLicenciaLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            string descripcion = this.descripcion.Text;
            if (!string.IsNullOrEmpty(descripcion))
            {
                DataTable dt = tipolicenciaLN.EditarTipoLicencia(id, descripcion.ToUpper());
                if (!dt.HasErrors)
                {
                    Response.Redirect("ListadoTipoLicencia.aspx");
                }
                else
                {
                    Page_Load(sender, e);
                }
            }
        }

        /// <summary>
        /// Redirecciona a la página para ver el listado de tipos de licencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("ListadoTipoLicencia.aspx");
        }
    }
}