using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using CapaLN;
using CapaEN;
using CapaAD;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;

namespace AplicacionSIPA1.RH.Empleado
{
    public partial class ListadoEmpleados : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la lista de empleados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String usuario = this.Session["usuario"].ToString();
                UsuarioAD Datos = new UsuarioAD();
                DataTable Usuario = Datos.usuarioRRHH(usuario);
                

                if (Usuario.Rows.Count == 0)
                {
                    Response.Redirect("~/RH/Empleado/EditarFicha.aspx?id=" + usuario);
                }
                else
                {
                    GetEmpleados(sender, e);
                }
            }
        }

        /// <summary>
        /// Redirecciona a la página para crear un empleado nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Crear(object sender, EventArgs e)
        {
            Response.Redirect("Crear.aspx");
        }

        /// <summary>
        /// Método con el cuál se obtienen todos los empleados o un empleado en especifico, según la busqueda ingresada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetEmpleados(object sender, EventArgs e)
        {
            int codigo = String.IsNullOrEmpty(tb_codigo.Text) ? -1 : Convert.ToInt32(tb_codigo.Text);
            string primer_nombre = String.IsNullOrEmpty(tb_primer_nombre.Text) ? "" : tb_primer_nombre.Text.ToUpper();
            string segundo_nombre = String.IsNullOrEmpty(tb_segundo_nombre.Text) ? "" : tb_segundo_nombre.Text.ToUpper();
            string primer_apellido = String.IsNullOrEmpty(tb_primer_apellido.Text) ? "" : tb_primer_apellido.Text.ToUpper();
            string segundo_apellido = String.IsNullOrEmpty(tb_segundo_apellido.Text) ? "" : tb_segundo_apellido.Text.ToUpper();
            string cui = String.IsNullOrEmpty(tb_cui.Text) ? "" : tb_cui.Text.ToUpper();

            EmpleadosLN empleadoLN = new EmpleadosLN();

            DataTable empleados = empleadoLN.Search(codigo, cui, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido);

            for (int i = 0; i < empleados.Rows.Count; i++)
            {
                int fil = i + 1;
                int id = Convert.ToInt32(empleados.Rows[i]["id_empleado"]);
                tabla_empleados.Rows.Add(NewRow());
                tabla_empleados.Rows[fil].Cells.Add(NewCell());
                tabla_empleados.Rows[fil].Cells.Add(NewCell());
                tabla_empleados.Rows[fil].Cells.Add(NewCell());
                tabla_empleados.Rows[fil].Cells.Add(NewCell());
                tabla_empleados.Rows[fil].Cells.Add(NewCell());
                tabla_empleados.Rows[fil].Cells.Add(NewCell());
                tabla_empleados.Rows[fil].Cells.Add(NewCell());

                tabla_empleados.Rows[fil].Cells[0].Text = empleados.Rows[i]["codigo"].ToString();
                tabla_empleados.Rows[fil].Cells[1].Text = empleados.Rows[i]["primer_nombre"].ToString();
                tabla_empleados.Rows[fil].Cells[2].Text = empleados.Rows[i]["segundo_nombre"].ToString();
                tabla_empleados.Rows[fil].Cells[3].Text = empleados.Rows[i]["primer_apellido"].ToString();
                tabla_empleados.Rows[fil].Cells[4].Text = empleados.Rows[i]["segundo_apellido"].ToString();
                tabla_empleados.Rows[fil].Cells[5].Text = empleados.Rows[i]["cui"].ToString();
                tabla_empleados.Rows[fil].Cells[6].Controls.Add(BotonEditar(id));

            }
        }

        /// <summary>
        /// Botón para redireccionar a una nueva página donde se editan los datos del empleado seleccionado
        /// </summary>
        /// <param name="id">Id del empleado a editar</param>
        /// <returns></returns>
        private LinkButton BotonEditar(int id)
        {
            LinkButton button = new LinkButton();
            button.PostBackUrl = "Editar.aspx?id=" + id;
            button.CssClass = "btn btn-primary btn-sm";
            button.Text = "Editar";
            button.Attributes.Add("data-id", id.ToString());
            return button;
        }
        private TableRow NewRow()
        {
            TableRow tr = new TableRow();

            return tr;
        }

        private TableHeaderCell NewCellHeader()
        {
            TableHeaderCell cell = new TableHeaderCell();

            return cell;
        }

        private TableCell NewCell()
        {
            TableCell cell = new TableCell();

            return cell;
        }

        protected void generateExcelSheet_click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                GridView gv = new GridView();
                EmpleadosLN empleadoLN = new EmpleadosLN();
                gv.DataSource = empleadoLN.ReporteEmpleados();
                gv.DataBind();
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=ListaEmpleados.xls");
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gv.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "Error", "alert('Ocurrio un error innesperado en la descarga del archivo');", true);
            }
            
        }
    }
}