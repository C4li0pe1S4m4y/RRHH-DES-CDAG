using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using CapaLN;

namespace AplicacionSIPA1.RH.Catalogos.Tipo_Sangre
{
    public partial class ListadoTipoSangre : System.Web.UI.Page
    {
        /// <summary>
        /// Se cargan todos los tipos de sangre existentes en el catálogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoSangreLN tiposangreLN = new TipoSangreLN();
            DataTable dt = tiposangreLN.ObtenerTipoSangre();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int fil = i + 1;

                int id = Convert.ToInt32(dt.Rows[i]["id_tipo_sangre"]);
                tabla_tipo_sangre.Rows.Add(new TableRow());
                tabla_tipo_sangre.Rows[fil].Cells.Add(new TableCell());
                tabla_tipo_sangre.Rows[fil].Cells.Add(new TableCell());

                if ((fil % 2) == 0)
                    tabla_tipo_sangre.Rows[fil].BackColor = Color.LightBlue;
                else
                    tabla_tipo_sangre.Rows[fil].BackColor = Color.White;

                tabla_tipo_sangre.Rows[fil].Cells[0].Text = dt.Rows[i]["descripcion"].ToString();
                tabla_tipo_sangre.Rows[fil].Cells[1].Width = 100;
                tabla_tipo_sangre.Rows[fil].Cells[1].Controls.Add(BotonEditar(id));
                tabla_tipo_sangre.Rows[fil].Cells[1].Controls.Add(BotonEliminar(id));

            }

        }

        /// <summary>
        /// Botón para redireccionar a una nueva página donde se edita el tipo de sangre seleccionado
        /// </summary>
        /// <param name="id">Id del tipo de sangre a editar</param>
        /// <returns></returns>
        private ImageButton BotonEditar(int id)
        {
            ImageButton button = new ImageButton();
            button.PostBackUrl = "Editar.aspx?id=" + id;
            button.ImageUrl = "~/img/24_bits/edit.png";
            button.Attributes.Add("data-id", id.ToString());
            return button;
        }

        /// <summary>
        /// Botón para redireccionar a una nueva página donde se elimina el tipo de sangre seleccionado
        /// </summary>
        /// <param name="id">Id del tipo de sangre a eliminar</param>
        /// <returns></returns>
        private ImageButton BotonEliminar(int id)
        {
            ImageButton button = new ImageButton();
            button.PostBackUrl = "Eliminar.aspx?id=" + id;
            button.ImageUrl = "~/img/24_bits/trash.png";
            button.Attributes.Add("data-id", id.ToString());
            return button;
        }

        /// <summary>
        /// Obtiene la descripción del tipo de sangre y lo crea/agrega
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Crear(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(descripcion.Text))
            {
                string tipo_sangre = descripcion.Text.Trim().ToUpper();
                TipoSangreLN tiposangreLN = new TipoSangreLN();
                if (!tiposangreLN.CrearTipoSangre(tipo_sangre).HasErrors)
                {
                    Response.Redirect("ListadoTipoSangre.aspx");
                }
                else
                {
                }
            }
        }

    }
}