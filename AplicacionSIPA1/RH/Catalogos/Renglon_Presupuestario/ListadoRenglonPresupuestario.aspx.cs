using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using CapaLN;

namespace AplicacionSIPA1.RH.Catalogos.Renglon_Presupuestario
{
    public partial class ListadoRenglonPresupuestario : System.Web.UI.Page
    {
        /// <summary>
        /// Se cargan todos los renglones presupuestarios existentes en el catálogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            RenglonPresupuestarioLN renglonpresupuestarioLN = new RenglonPresupuestarioLN();
            DataTable dt = renglonpresupuestarioLN.ObtenerRenglonPresupuestario();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int fil = i + 1;

                int id = Convert.ToInt32(dt.Rows[i]["id_renglon_presupuestario"]);
                tabla_renglon_presupuestario.Rows.Add(new TableRow());
                tabla_renglon_presupuestario.Rows[fil].Cells.Add(new TableCell());
                tabla_renglon_presupuestario.Rows[fil].Cells.Add(new TableCell());

                if ((fil % 2) == 0)
                    tabla_renglon_presupuestario.Rows[fil].BackColor = Color.LightBlue;
                else
                    tabla_renglon_presupuestario.Rows[fil].BackColor = Color.White;

                tabla_renglon_presupuestario.Rows[fil].Cells[0].Text = dt.Rows[i]["descripcion"].ToString();
                tabla_renglon_presupuestario.Rows[fil].Cells[1].Width = 100;
                tabla_renglon_presupuestario.Rows[fil].Cells[1].Controls.Add(BotonEditar(id));
                tabla_renglon_presupuestario.Rows[fil].Cells[1].Controls.Add(BotonEliminar(id));

            }

        }

        /// <summary>
        /// Botón para redireccionar a una nueva página donde se edita el renglón presupuestario seleccionado
        /// </summary>
        /// <param name="id">Id del renglón presupuestario a editar</param>
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
        /// Botón para redireccionar a una nueva página donde se elimina el renglón presupuestario seleccionado
        /// </summary>
        /// <param name="id">Id del renglón presupuestario a eliminar</param>
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
        /// Obtiene la descripción del renglón presupuestario y lo crea/agrega
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Crear(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(descripcion.Text))
            {
                string estado_civil = descripcion.Text.Trim().ToUpper();
                RenglonPresupuestarioLN estadocivilLN = new RenglonPresupuestarioLN();
                if (!estadocivilLN.CrearRenglonPresupuestario(estado_civil).HasErrors)
                {
                    Response.Redirect("ListadoRenglonPresupuestario.aspx");
                }
                else
                {
                }
            }
        }
    }
}