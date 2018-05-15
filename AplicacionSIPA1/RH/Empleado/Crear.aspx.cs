using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEN;
using CapaLN;
using System.Data;

namespace AplicacionSIPA1.RH.Empleado
{
    public partial class Crear : System.Web.UI.Page
    {
        /// <summary>
        /// Se cargan todos los combobox de la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LlenarDropDowns();
                imgprv.ImageUrl = "~/Content/Imagenes/empleado_default.png";
            }
        }
        
        /// <summary>
        /// Método llamado desde el onclick con el cuál se crea el empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CrearEmpleado(object sender, EventArgs e)
        {
            try
            {
                EmpleadosLN empleado = new EmpleadosLN();
                var archivo = new ArchivoLN();
                var data = ObtenerDatos();
                
                if (data.url_Imagen != string.Empty)
                {
                    var resultado = archivo.NuevoArchivo(new Archivo
                    {
                        url = data.url_Imagen
                    });

                    data.id_archivo = resultado.id_archivo;
                }

                DataTable dt = empleado.NuevoEmpleado(data);
                if (dt.HasErrors)
                {
                    Page_Load(sender, e);
                }
                else
                {
                    Response.Redirect("ListadoEmpleados.aspx");
                }
            }
            catch (Exception ex)
            {
                l_error.Visible = true;
                l_error.InnerText = "Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Redirecciona a la página para ver el listado de empleados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("ListadoEmpleados.aspx");
        }

        /// <summary>
        /// Método con el que se obtienen los datos ingresados por el usuarios y se almacenan en el objeto empleado
        /// </summary>
        /// <returns></returns>
        private EmpleadoNew ObtenerDatos()
        {
            int? intnull = 0;
            EmpleadoNew empleado = new EmpleadoNew();
            empleado.codigo = Convert.ToInt32(codigo.Value);
            empleado.primer_nombre = primer_nombre.Value.ToUpper();
            empleado.primer_apellido = primer_apellido.Value.ToUpper();
            empleado.segundo_apellido = String.IsNullOrEmpty(segundo_apellido.Value) ? "" : segundo_apellido.Value.ToUpper();
            empleado.segundo_nombre = String.IsNullOrEmpty(segundo_nombre.Value) ? "" : segundo_nombre.Value.ToUpper();
            empleado.apellido_casada = String.IsNullOrEmpty(apellido_casada.Value) ? "" : apellido_casada.Value.ToUpper();
            empleado.cui = String.IsNullOrEmpty(cui.Value) ? "" : cui.Value;
            empleado.nit = String.IsNullOrEmpty(nit.Value) ? "" : nit.Value;
            empleado.id_genero =  Convert.ToInt32(d_genero.Value);
            empleado.id_municipio_cui = Convert.ToInt32(d_municipio_cui.Value);
            empleado.id_estado_civil = Convert.ToInt32(d_estado_civil.Value);
            empleado.id_municipio_residencial = Convert.ToInt32(d_municipio_residencia.Value);
            empleado.id_profesion = Convert.ToInt32(d_profesion.Value);
            empleado.fecha_nacimiento = Convert.ToDateTime(fecha_nacimiento.Value);
            empleado.lugar_nacimiento = String.IsNullOrEmpty(lugar_nacimiento.Value) ? "" : lugar_nacimiento.Value;
            empleado.direccion_residencial = String.IsNullOrEmpty(direccion_residencial.Value) ? "" : direccion_residencial.Value.ToUpper();
            empleado.telefono_residencial = !String.IsNullOrEmpty(telefono_residencial.Value) ? Convert.ToInt32(telefono_residencial.Value) : intnull;
            empleado.telefono_movil = !String.IsNullOrEmpty(telefono_movil.Value) ? Convert.ToInt32(telefono_movil.Value) : intnull;
            empleado.afiliacion_igss = igss.Value;
            empleado.licencia_conducir = String.IsNullOrEmpty(numero_licencia.Value) ? "" : numero_licencia.Value;
            empleado.id_tipo_licencia = String.IsNullOrEmpty(d_tipo_licencia.Value) ? intnull : Convert.ToInt32(d_tipo_licencia.Value);
            empleado.tipo_vivienda = casa_propia.Checked; //if false then alquiler
            //empleado.id_fotografia;
            empleado.correo = correo.Value;
            empleado.url_Imagen = imagen_url.Value;
            imgprv.ImageUrl = imagen_url.Value;
            return empleado;
        }

        /// <summary>
        /// Método con el cuál se llenan los combobox según los datos que se encuentran en la bd
        /// </summary>
        private void LlenarDropDowns()
        {
            GeneroLN genero = new GeneroLN();
            DataTable lista_generos = genero.ObtenerGeneros();
            ListItem li = new ListItem();
            /*li.Text = "Seleccionar Genero";
            li.Value = null;
            d_genero.Items.Add(li);*/
            for (int i = 0; i < lista_generos.Rows.Count; i++)
            {
                li = new ListItem();
                li.Text = lista_generos.Rows[i]["descripcion"].ToString();
                li.Value = lista_generos.Rows[i]["id_genero"].ToString();
                d_genero.Items.Add(li);
            }

            ProfesionLN profesion = new ProfesionLN();
            DataTable lista_profesion = profesion.ObtenerProfesion();
            li = new ListItem();
            /*li.Text = "Seleccionar Profesión";
            li.Value = "0";
            d_profesion.Items.Add(li);*/
            for (int i = 0; i < lista_profesion.Rows.Count; i++)
            {
                li = new ListItem();
                li.Text = lista_profesion.Rows[i]["descripcion"].ToString();
                li.Value = lista_profesion.Rows[i]["id_profesion"].ToString();
                d_profesion.Items.Add(li);
            }

            EstadoCivilLN estado_civil = new EstadoCivilLN();
            DataTable lista_estado_civil = estado_civil.ObtenerEstadoCivil();
            li = new ListItem();
            /*li.Text = "Seleccionar Estado Civil";
            li.Value = "0";
            d_estado_civil.Items.Add(li);*/
            for (int i = 0; i < lista_estado_civil.Rows.Count; i++)
            {
                li = new ListItem();
                li.Text = lista_estado_civil.Rows[i]["descripcion"].ToString();
                li.Value = lista_estado_civil.Rows[i]["id_estado_civil"].ToString();
                d_estado_civil.Items.Add(li);
            }

            TipoLicenciaLN tipo_licencia = new TipoLicenciaLN();
            DataTable lista_tipo_licencia = tipo_licencia.ObtenerTipoLicencia();
            li = new ListItem();
            /*li.Text = "Seleccionar Tipo de Licencia";
            li.Value = "0";
            d_tipo_licencia.Items.Add(li);*/
            for (int i = 0; i < lista_tipo_licencia.Rows.Count; i++)
            {
                li = new ListItem();
                li.Text = lista_tipo_licencia.Rows[i]["descripcion"].ToString();
                li.Value = lista_tipo_licencia.Rows[i]["id_tipo_licencia"].ToString();
                d_tipo_licencia.Items.Add(li);
            }

            MunicipioLN municipio = new MunicipioLN();

            DataTable lista_municipios = municipio.ObtenerTodosMunicipios();
            li = new ListItem();
            /*li.Text = "Seleccionar Municipio";
            li.Value = "0";
            d_municipio_cui.Items.Add(li);
            d_municipio_residencia.Items.Add(li);*/
            for (int i = 0; i < lista_municipios.Rows.Count; i++)
            {
                li = new ListItem();
                li.Text = lista_municipios.Rows[i]["descripcion"].ToString();
                li.Value = lista_municipios.Rows[i]["id_municipio"].ToString();
                d_municipio_cui.Items.Add(li);
                d_municipio_residencia.Items.Add(li);
            }

        }

    }
}