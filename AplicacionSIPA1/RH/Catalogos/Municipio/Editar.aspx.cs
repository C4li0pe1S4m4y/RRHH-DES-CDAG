using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEN;
using CapaAD;

namespace AplicacionSIPA1.RH.Catalogos.Municipio
{
    public partial class Editar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción del municipio a editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MunicipioLN municipioLN = new MunicipioLN();
            int id = Convert.ToInt32(Request["id"]);
            DataTable dt = municipioLN.GetMunicipio(id);
            Button1.Attributes.Add("data-id", id.ToString());
            if (!Page.IsPostBack) descripcion.Text = dt.Rows[0]["descripcion"].ToString();
            if (!Page.IsPostBack) codigo.Text = dt.Rows[0]["codigo"].ToString();
        }

        /// <summary>
        /// Edita la descripción del municipio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditarMunicipio(object sender, EventArgs e)
        {
            MunicipioLN municipioLN = new MunicipioLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            string descripcion = this.descripcion.Text;
            int code = Convert.ToInt32(this.codigo.Text);
            if (!string.IsNullOrEmpty(descripcion))
            {
                DataTable dt = municipioLN.EditarMunicipio(id, descripcion.ToUpper(), code);
                if (!dt.HasErrors)
                {
                    Response.Redirect("ListadoMunicipio.aspx?id=" + Request["depto"]);
                }
                else
                {
                    Page_Load(sender, e);
                }
            }
        }

        /// <summary>
        /// Redirecciona a la página para ver el listado de municipios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("ListadoMunicipio.aspx?id=" + Request["depto"]);
        }
    }
}