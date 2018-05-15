using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEN;
using CapaLN;
using System.Data;
using System.Drawing;

namespace AplicacionSIPA1.RH.Catalogos.Profesion
{
    public partial class ListadoProfesion : System.Web.UI.Page
    {
        /// <summary>
        /// Se cargan todas las profesiones existentes en el catálogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ProfesionLN profesionLN = new ProfesionLN();
            DataTable dt = profesionLN.ObtenerProfesion();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int fil = i + 1;

                int id = Convert.ToInt32(dt.Rows[i]["id_profesion"]);
                tabla_profesion.Rows.Add(new TableRow());
                tabla_profesion.Rows[fil].Cells.Add(new TableCell());
                tabla_profesion.Rows[fil].Cells.Add(new TableCell());

                if ((fil % 2) == 0)
                    tabla_profesion.Rows[fil].BackColor = Color.LightBlue;
                else
                    tabla_profesion.Rows[fil].BackColor = Color.White;

                tabla_profesion.Rows[fil].Cells[0].Text = dt.Rows[i]["descripcion"].ToString();
                tabla_profesion.Rows[fil].Cells[1].Width = 100;
                tabla_profesion.Rows[fil].Cells[1].Controls.Add(BotonEditar(id));
                tabla_profesion.Rows[fil].Cells[1].Controls.Add(BotonEliminar(id));

            }

        }

        /// <summary>
        /// Botón para redireccionar a una nueva página donde se edita la profesión seleccionada
        /// </summary>
        /// <param name="id">Id de la profesión a editar</param>
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
        /// Botón para redireccionar a una nueva página donde se elimina la profesión seleccionada
        /// </summary>
        /// <param name="id">Id de la profesión a eliminar</param>
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
        /// Obtiene la descripción de la profesión y la crea/agrega
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Crear(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(descripcion.Text))
            {
                string profesion = descripcion.Text.Trim().ToUpper();
                ProfesionLN profesionLN = new ProfesionLN();
                if (!profesionLN.CrearProfesion(profesion).HasErrors)
                {
                    Response.Redirect("ListadoProfesion.aspx");
                }
                else
                {
                }
            }
        }

    }
}