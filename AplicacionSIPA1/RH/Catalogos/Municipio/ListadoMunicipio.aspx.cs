using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using CapaLN;

namespace AplicacionSIPA1.RH.Catalogos.Municipio
{
    public partial class ListadoMunicipio : System.Web.UI.Page
    {
        /// <summary>
        /// Se cargan todas los municipios existentes en el catálogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MunicipioLN municipioLN = new MunicipioLN();
            int depto = Convert.ToInt32(Request["id"]);
            DataTable dt = municipioLN.ObtenerMunicipio(depto);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int fil = i + 1;

                int id = Convert.ToInt32(dt.Rows[i]["id_municipio"]);
                tabla_municipio.Rows.Add(new TableRow());
                tabla_municipio.Rows[fil].Cells.Add(new TableCell());
                tabla_municipio.Rows[fil].Cells.Add(new TableCell());
                tabla_municipio.Rows[fil].Cells.Add(new TableCell());

                if ((fil % 2) == 0)
                    tabla_municipio.Rows[fil].BackColor = Color.LightBlue;
                else
                    tabla_municipio.Rows[fil].BackColor = Color.White;

                tabla_municipio.Rows[fil].Cells[0].Text = dt.Rows[i]["descripcion"].ToString();
                tabla_municipio.Rows[fil].Cells[1].Text = dt.Rows[i]["codigo"].ToString();
                tabla_municipio.Rows[fil].Cells[2].Width = 100;
                tabla_municipio.Rows[fil].Cells[2].Controls.Add(BotonEditar(id,depto));
                tabla_municipio.Rows[fil].Cells[2].Controls.Add(BotonEliminar(id,depto));
            }
        }

        /// <summary>
        /// Botón para redireccionar a una nueva pagina donde se edita el municipio seleccionado
        /// </summary>
        /// <param name="id">Id del municipio a editar</param>
        /// <param name="depto">Id del departamento al que pertenece el municipio a editar</param>
        /// <returns></returns>
        private ImageButton BotonEditar(int id, int depto)
        {
            ImageButton button = new ImageButton();
            button.PostBackUrl = "Editar.aspx?id=" + id + "&depto=" + depto;
            button.ImageUrl = "~/img/24_bits/edit.png";
            button.Attributes.Add("data-id", id.ToString());
            return button;
        }

        /// <summary>
        /// Botón para redireccionar a una nueva pagina donde se elimina el municipio seleccionado
        /// </summary>
        /// <param name="id">Id del municipio a eliminar</param>
        /// <param name="depto">Id del departamento al que pertenece el municipio a eliminar</param>
        /// <returns></returns>
        private ImageButton BotonEliminar(int id, int depto)
        {
            ImageButton button = new ImageButton();
            button.PostBackUrl = "Eliminar.aspx?id=" + id + "&depto=" + depto;
            button.ImageUrl = "~/img/24_bits/trash.png";
            button.Attributes.Add("data-id", id.ToString());
            return button;
        }

        /// <summary>
        /// Obtiene la descripción del municipio y lo crea/agrega
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Crear(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(descripcion.Text))
            {
                string municipio = descripcion.Text.Trim().ToUpper();
                int code = Convert.ToInt32((String.IsNullOrEmpty(codigo.Text) ? "-1" : codigo.Text).ToString());
                int depto = Convert.ToInt32(Request["id"]);
                MunicipioLN municipioLN = new MunicipioLN();
                if (code >= 0)
                {
                    if (!municipioLN.CrearMunicipio(municipio, code, depto).HasErrors)
                    {
                        Response.Redirect("ListadoMunicipio.aspx?id=" + Request["id"]);
                    }
                    else
                    {
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "Mensaje", "alert('Debe ingresar el código del municipio');", true);
                }
                
            }
        }

        protected void EditarClick(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            int id = Convert.ToInt32(button.Attributes["data-id"]);
            Response.Redirect("Editar.aspx");
        }

        /// <summary>
        /// Regresa al catalogo de departamentos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {

            Response.Redirect("/RH/Catalogos/Departamento/ListadoDepartamento.aspx");
        }

    }
}