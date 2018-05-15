using CapaLN;
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Drawing;

namespace AplicacionSIPA1.RH.Catalogos.Departamento
{
    public partial class ListadoDepartamento : System.Web.UI.Page
    {
        /// <summary>
        /// Se cargan todos los departamentos existentes en el catalogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            DepartamentoLN departamentoLN = new DepartamentoLN();
            DataTable dt = departamentoLN.ObtenerDepartamento();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int fil = i + 1;

                int id = Convert.ToInt32(dt.Rows[i]["id_departamento"]);
                tabla_departamento.Rows.Add(new TableRow());
                tabla_departamento.Rows[fil].Cells.Add(new TableCell());
                tabla_departamento.Rows[fil].Cells.Add(new TableCell());

                if ((fil % 2) == 0)
                    tabla_departamento.Rows[fil].BackColor = Color.LightBlue;
                else
                    tabla_departamento.Rows[fil].BackColor = Color.White;

                tabla_departamento.Rows[fil].Cells[0].Text = dt.Rows[i]["descripcion"].ToString();
                tabla_departamento.Rows[fil].Cells[1].Width = 100;
                tabla_departamento.Rows[fil].Cells[1].Controls.Add(BotonEditar(id));
                tabla_departamento.Rows[fil].Cells[1].Controls.Add(BotonEliminar(id));
                tabla_departamento.Rows[fil].Cells[1].Controls.Add(BotonMunicipio(id));
            }
        }

        /// <summary>
        /// Botón para redireccionar a una nueva página donde se edita el departamento seleccionado
        /// </summary>
        /// <param name="id">Id del departamento a editar</param>
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
        /// Botón para redireccionar a una nueva página donde se elimina el departamento seleccionado
        /// </summary>
        /// <param name="id">Id del departamento a eliminar</param>
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
        /// Botón para redireccionar a una nueva pagina donde están los listados de municipios correspondientes al departamento seleccionado
        /// </summary>
        /// <param name="id">Id del departamento a obtener municipios</param>
        /// <returns></returns>
        private ImageButton BotonMunicipio(int id)
        {
            ImageButton button = new ImageButton();
            button.PostBackUrl = "~/RH/Catalogos/Municipio/ListadoMunicipio.aspx?id=" + id;
            button.ImageUrl = "~/img/24_bits/add.png";
            button.Attributes.Add("data-id", id.ToString());
            return button;
        }

        /// <summary>
        /// Obtiene la descripción del nuevo departamento y lo crea/agrega
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Crear(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(descripcion.Text))
            {
                string departamento = descripcion.Text.Trim().ToUpper();
                DepartamentoLN departamentoLN = new DepartamentoLN();
                if (!departamentoLN.CrearDepartamento(departamento).HasErrors)
                {
                    Response.Redirect("ListadoDepartamento.aspx");
                }
                else
                {
                    
                }
            }
        }

      
    }
}