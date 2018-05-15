using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace AplicacionSIPA1.RH.Catalogos.Enfermedad
{
    public partial class ListadoEnfermedad : System.Web.UI.Page
    {
        /// <summary>
        /// Se cargan todas las enfermedades existentes en el catálogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            EnfermedadLN enfermedadLN = new EnfermedadLN();
            DataTable dt = enfermedadLN.ObtenerEnfermedad();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int fil = i + 1;

                int id = Convert.ToInt32(dt.Rows[i]["id_enfermedad"]);
                tabla_enfermedad.Rows.Add(new TableRow());
                tabla_enfermedad.Rows[fil].Cells.Add(new TableCell());
                tabla_enfermedad.Rows[fil].Cells.Add(new TableCell());

                if ((fil % 2) == 0)
                    tabla_enfermedad.Rows[fil].BackColor = Color.LightBlue;
                else
                    tabla_enfermedad.Rows[fil].BackColor = Color.White;

                tabla_enfermedad.Rows[fil].Cells[0].Text = dt.Rows[i]["descripcion"].ToString();
                tabla_enfermedad.Rows[fil].Cells[1].Width = 100;
                tabla_enfermedad.Rows[fil].Cells[1].Controls.Add(BotonEditar(id));
                tabla_enfermedad.Rows[fil].Cells[1].Controls.Add(BotonEliminar(id));
            }
        }
        /// <summary>
        /// Botón para redireccionar a una nueva página donde se edita la enfermedad seleccionada
        /// </summary>
        /// <param name="id">Id de la enfermedad a editar</param>
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
        /// Botón para redireccionar a una nueva página donde se elimina la enfermedad seleccionada
        /// </summary>
        /// <param name="id">Id de la enfermedad a eliminar</param>
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
        /// Obtiene la descripción de la nueva enfermedad y la crea/agrega
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Crear(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(descripcion.Text))
            {
                string enfermedad = descripcion.Text.Trim().ToUpper();
                EnfermedadLN enfermedadLN = new EnfermedadLN();
                if (!enfermedadLN.CrearEnfermedad(enfermedad).HasErrors)
                {
                    Response.Redirect("ListadoEnfermedad.aspx");
                }
                else
                {
                }
            }
        }

    }
}