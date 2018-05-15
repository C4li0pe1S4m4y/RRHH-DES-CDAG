﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using System.Data;

namespace AplicacionSIPA1.RH.Catalogos.Parentesco
{
    public partial class Eliminar : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la descripción del parentesco a eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ParentescoLN parentescoLN = new ParentescoLN();
            int id = Convert.ToInt32(Request["id"]);
            DataTable dt = parentescoLN.GetParentesco(id);
            Button1.Attributes.Add("data-id", id.ToString());
            if (!Page.IsPostBack) descripcion.Text = dt.Rows[0]["descripcion"].ToString();
        }

        /// <summary>
        /// Elimina el parentesco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EliminarParentesco(object sender, EventArgs e)
        {
            ParentescoLN parentescoLN = new ParentescoLN();
            int id = Convert.ToInt32(Button1.Attributes["data-id"]);
            DataTable dt = parentescoLN.EliminarParentesco(id);
            if (!dt.HasErrors)
            {
                Response.Redirect("ListadoParentesco.aspx");
            }
            else
            {
                Page_Load(sender, e);
            }
        }

        /// <summary>
        /// Redirecciona a la página para ver el listado de parentescos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("ListadoParentesco.aspx");
        }
    }
}