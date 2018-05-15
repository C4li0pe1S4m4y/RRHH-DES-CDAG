using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEN;
using CapaAD;
using CapaLN;
using System.Data;

namespace AplicacionSIPA1.RH.Empleado
{
    public partial class Editar : System.Web.UI.Page
    {
        int id;

        /// <summary>
        /// Carga todos los datos que se tienen actualmente del empleado que se va a editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            String usuario = this.Session["usuario"].ToString();
            UsuarioAD Datos = new UsuarioAD();
            DataTable Usuario = Datos.usuarioRRHH(usuario);
            if (Usuario.Rows.Count == 0)
            {
                RRHH.Value = "0";
            } else
            {
                RRHH.Value = "1";
            }

            int idConstancia = 0;
            EmpleadosLN empleadoLN = new EmpleadosLN();
            Session["id"] = Request["id"];
            id = Convert.ToInt32(Request["id"]);
            DataTable result = empleadoLN.GetEmpleado(id);

            if (Page.IsPostBack && Request["delC"] != null && int.TryParse(Request["delC"].ToString(), out idConstancia))
            {
                ConstanciaEducativaLN ln = new ConstanciaEducativaLN();
                ln.EliminarConstancia(new ConstanciaEducativa
                {
                    id_constancia = idConstancia
                });
            }
            string eventTarget = Request.Params.Get("__EVENTTARGET");

            if (Page.IsPostBack && Request["loadC"] != null && int.TryParse(Request["loadC"].ToString(), out idConstancia)
                && (eventTarget != string.Empty)
                )
            {
                if(eventTarget != "ctl00$ContentPlaceHolder3$btnAgregarConstanciaEdu")
                {
                    ConstanciaEducativaLN ln = new ConstanciaEducativaLN();
                    var dt = ln.ConsultarConstancia(idConstancia);
                    CargarConstanciaEdicion(dt);
                }
               
            }

            if (!Page.IsPostBack)
            {
                LlenarDropDowns();
                
                if (!result.HasErrors)
                {
                    l_empleado.Text = result.Rows[0]["codigo"].ToString() + " - "
                        + result.Rows[0]["primer_nombre"].ToString() + " " + result.Rows[0]["primer_apellido"].ToString();

                    codigo.Value = result.Rows[0]["codigo"].ToString();
                    primer_nombre.Value = result.Rows[0]["primer_nombre"].ToString();
                    primer_apellido.Value = result.Rows[0]["primer_apellido"].ToString();
                    segundo_nombre.Value = result.Rows[0]["segundo_nombre"].ToString();
                    segundo_apellido.Value = result.Rows[0]["segundo_apellido"].ToString();
                    apellido_casada.Value = result.Rows[0]["apellido_casada"].ToString();
                   
                    cui.Value = result.Rows[0]["cui"].ToString();
                    fecha_nacimiento.Value = Convert.ToDateTime(result.Rows[0]["fecha_nacimiento"].ToString()).ToString("yyyy-MM-dd");
                    lugar_nacimiento.Value = result.Rows[0]["lugar_nacimiento"].ToString();
                    d_genero.Value = result.Rows[0]["id_genero"].ToString();
                    d_profesion.Value = result.Rows[0]["id_profesion"].ToString();
                    d_estado_civil.Value = result.Rows[0]["id_estado_civil"].ToString();
                    casa_propia.Checked = result.Rows[0]["tipo_vivienda"].ToString() == "1" ? true : false;
                    alquiler.Checked = result.Rows[0]["tipo_vivienda"].ToString() == "1" ? false : true;
                    direccion_residencial.Value = result.Rows[0]["direccion_residencial"].ToString();
                     correo.Value = result.Rows[0]["correo"].ToString();
                    telefono_movil.Value = result.Rows[0]["telefono_movil"].ToString();
                    telefono_residencial.Value = result.Rows[0]["telefono_residencial"].ToString();
                    igss.Value = result.Rows[0]["afiliacion_igss"].ToString();
                    nit.Value = result.Rows[0]["nit"].ToString();
                    d_tipo_licencia.Value = result.Rows[0]["id_tipo_licencia"].ToString();
                    numero_licencia.Value = result.Rows[0]["licencia_conducir"].ToString();
                    imagenEmpleado.ImageUrl = result.Rows[0]["ruta"]?.ToString().Trim() == string.Empty ?
                            "~/Content/Imagenes/empleado_default.png" :
                               result.Rows[0]["ruta"]?.ToString().Trim();
                    banderaCambioImagen.Value = "0";
                    id_archivo.Value = result.Rows[0]["id_fotografia"]?.ToString().Trim() ?? "";
                    d_tipo_sangre.Value = result.Rows[0]["id_tipo_sangre"].ToString();
                    //Carga Tabs
                    ListadoFamiliares();
                    CargarConstancias();
                    DarValoresAlergiasEnfermedades();
                    LlenarContrato(id);
                    d_municipio_cui.Value = result.Rows[0]["id_municipio_cui"].ToString();
                    d_municipio_residencia.Value = result.Rows[0]["id_municipio_residencial"].ToString();

                }

            }

        }



        /// <summary>
        /// Carga Datos para editar la constancia educativa seleccionada
        /// </summary>
        /// <param name="result"></param>
        private void CargarConstanciaEdicion(DataTable result)
        {
            id_constancia.Value = result.Rows[0]["id_constancia"].ToString();
            listaNivel.Value = result.Rows[0]["id_nivel"].ToString();
            lugar_constancia_educativa.Text = result.Rows[0]["lugar"].ToString();
            desde_constancia_educativa.Value =
                Convert.ToDateTime(result.Rows[0]["fecha_desde"].ToString()).ToString("yyyy-MM-dd");
            hasta_constancia_educativa.Value =
                Convert.ToDateTime(result.Rows[0]["fecha_hasta"].ToString()).ToString("yyyy-MM-dd");
            descripcion_constancia_educativa.Text = result.Rows[0]["descripcion"].ToString();
            id_archivo_constancia.Value = result.Rows[0]["id_archivo"].ToString();

        }
        /// <summary>
        /// Método con el cuál se obtienen los datos generales del empleado y se editan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void EditarEmpleado(object sender, EventArgs e)
        {
            try
            {
                EmpleadosLN empleado = new EmpleadosLN();
                var data = ObtenerDatos();
                var archivo = new ArchivoLN();
                if (banderaCambioImagen.Value == "1" && data.id_archivo.ToString() != "0" && data.url_Imagen != string.Empty)
                {
                    var resultado = archivo.ModificarArchivo(new Archivo
                    {
                        url = data.url_Imagen
                        ,
                        id_archivo = data.id_archivo ?? 0
                    });

                    data.id_archivo = resultado.id_archivo;
                }
                else if (data.url_Imagen != string.Empty)
                {
                    var resultado = archivo.NuevoArchivo(new Archivo
                    {
                        url = data.url_Imagen
                    });
                    data.id_archivo = resultado.id_archivo;
                }
                DataTable dt = empleado.EditarEmpleado(data);
                if (!dt.HasErrors)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "Mensaje", "alert('Datos guardados éxitosamente');", true);
                    Response.Redirect("Editar.aspx?id=" + Request["id"]);
                }
                else
                {
                    l_error.Visible = true;
                    l_error.InnerText = "Error inesperado";
                }
            }
            catch (Exception ex)
            {
                l_error.Visible = true;
                l_error.InnerText = "Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Método con el cuál se obtienen los datos del contrato y se crea en caso no exista o se edita el contrato según su código
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditarContrato(object sender, EventArgs e)
        {
            try
            {
                Contratos contrato = ObtenerContrato();
                ContratoLN contratoLN = new ContratoLN();
                if (Convert.ToDateTime(contrato.fecha_inicial) < Convert.ToDateTime(contrato.fecha_final))
                {
                    if (contrato.id_contrato == 0)
                    {
                        contratoLN.CrearContrato(contrato);
                    }
                    else
                    {
                        contratoLN.EditarContrato(contrato);
                    }

                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "Mensaje", "alert('Datos guardados éxitosamente');", true);

                    Response.Redirect("Editar.aspx?id=" + Request["id"] + "#tab_contrato");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "Mensaje", "alert('Error: Fecha final no puede ser mayor a fecha inicial');", true);
                }
            }
            catch (Exception ex)
            {
                l_error.Visible = true;
                l_error.InnerText = "Error: " + ex.Message;}
        }

        /// <summary>
        /// Redirecciona a la página para ver el historial de contratos del empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HistorialContratos(object sender, EventArgs e)
        {
            Response.Redirect("ListadoHistorialContratos.aspx?id=" + Request["id"]);
        }

        /// <summary>
        /// Método con el cuál se elimina el contrato que se tiene en curso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EliminarContrato(object sender, EventArgs e)
        {
            try
            {
                ContratoLN contratoLN = new ContratoLN();
                int id_contrato = Convert.ToInt32(String.IsNullOrEmpty(cod_contrato.Value) ? "0" : cod_contrato.Value);

                if (id_contrato != 0)
                {
                    contratoLN.EliminarContrato(id_contrato);

                    cod_contrato.Value = "";
                    c_puesto.Value = "";
                    c_area.Value = "";
                    c_jefe_inmediato.Value = "";
                    c_puesto_jefe.Value = "";
                    c_salario.Value = "";
                    c_fecha_ini.Value = "";
                    c_fecha_final.Value = "";
                    c_renglon_presup.Value = "";
                    c_estado_contrato.Value = "";
                    c_motivo.Value = "";

                }

            }
            catch (Exception ex)
            {
                l_error.Visible = true;
                l_error.InnerText = "Error: " + ex.Message;
            }

            ScriptManager.RegisterClientScriptBlock(this, typeof(string), "Mensaje", "alert('Contrato eliminado éxitosamente');", true);
            Response.Redirect("Editar.aspx?id=" + Request["id"] + "#tab_contrato");
        }

        /// <summary>
        /// Método con el que se obtienen los datos de la condición médica y se editan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditarCondicionMedica(object sender, EventArgs e)
        {
            try
            {
                EmpleadosLN empleado = new EmpleadosLN();
                DataTable dt = empleado.EditarAlergiaEnfermedad(ObtenerData());
                if (!dt.HasErrors)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "Mensaje", "alert('Datos guardados éxitosamente');", true);
                    Response.Redirect("Editar.aspx?id=" + Request["id"] + "#tab_condicion_medica");
                }
                else
                {
                    l_error.Visible = true;
                    l_error.InnerText = "Error inesperado";
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
        /// Redirecciona a la página para ver/aditar las vacaciones del empleado, si este tiene un contrato actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void IngresoVacaciones(object sender, EventArgs e)
        {
            if (Convert.ToInt32(String.IsNullOrEmpty(cod_contrato.Value) ? "0" : cod_contrato.Value) != 0)
            {
                Response.Redirect("IngresoVacaciones.aspx?id=" + cod_contrato.Value +"&emp="+id);
            }
            else
            {
                l_error.Visible = true;
                l_error.InnerText = "Para ver las vacaciones debe de contar con un contrato activo";
            }

        }

        /// <summary>
        /// Método con el cuál se llenan los combobox según los datos que se encuentran en la bd
        /// </summary>
        private void LlenarDropDowns()
        {
            GeneroLN genero = new GeneroLN();
            DataTable lista_generos = genero.ObtenerGeneros();
            ListItem li = new ListItem();

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

            for (int i = 0; i < lista_municipios.Rows.Count; i++)
            {
                li = new ListItem();
                li.Text = lista_municipios.Rows[i]["descripcion"].ToString();
                li.Value = lista_municipios.Rows[i]["id_municipio"].ToString();
                d_municipio_residencia.Items.Add(li);
            }


            MunicipioLN municipioCUI = new MunicipioLN();
            DataTable lista_municipiosCUI = municipio.ObtenerTodosMunicipios();
            ListItem liCUI = new ListItem();
            liCUI = new ListItem();

            for (int i = 0; i < lista_municipiosCUI.Rows.Count; i++)
            {
                liCUI = new ListItem();
                liCUI.Text = lista_municipios.Rows[i]["descripcion"].ToString();
                liCUI.Value = lista_municipios.Rows[i]["id_municipio"].ToString();
                d_municipio_cui.Items.Add(liCUI);
            }
           





            TipoSangreLN tipo_sangre = new TipoSangreLN();
            DataTable lista_tipo_sangre = tipo_sangre.ObtenerTipoSangre();
            li = new ListItem();

            for (int i = 0; i < lista_tipo_sangre.Rows.Count; i++)
            {
                li = new ListItem();
                li.Text = lista_tipo_sangre.Rows[i]["descripcion"].ToString();
                li.Value = lista_tipo_sangre.Rows[i]["id_tipo_sangre"].ToString();
                d_tipo_sangre.Items.Add(li);
            }

            EnfermedadLN enfermedad = new EnfermedadLN();
            DataTable lista_enfermedad = enfermedad.ObtenerEnfermedad();
            li = new ListItem();

            for (int i = 0; i < lista_enfermedad.Rows.Count; i++)
            {
                li = new ListItem();
                li.Text = lista_enfermedad.Rows[i]["descripcion"].ToString();
                li.Value = lista_enfermedad.Rows[i]["id_enfermedad"].ToString();
                d_enfermedades.Items.Add(li);
            }

            AlergiaLN alergia = new AlergiaLN();
            DataTable lista_alergia = alergia.ObtenerAlergia();
            li = new ListItem();

            for (int i = 0; i < lista_alergia.Rows.Count; i++)
            {
                li = new ListItem();
                li.Text = lista_alergia.Rows[i]["descripcion"].ToString();
                li.Value = lista_alergia.Rows[i]["id_alergia"].ToString();
                d_alergias.Items.Add(li);
            }

            ParentescoLN parentesco = new ParentescoLN();
            ddlParentesco.ClearSelection();
            ddlParentesco.Items.Clear();
            ddlParentesco.AppendDataBoundItems = true;
            ddlParentesco.Items.Add("-- Elija Parentesco --");
            ddlParentesco.Items[0].Value = "0";
            ddlParentesco.DataSource = parentesco.ObtenerParentescos();
            ddlParentesco.DataTextField = "descripcion";
            ddlParentesco.DataValueField = "id_parentesco";
            ddlParentesco.DataBind();

            EstadoContratoLN estadoContrato = new EstadoContratoLN();
            DataTable lista_estadoContrato = estadoContrato.ObtenerEstadoContrato();
            for (int i = 0; i < lista_estadoContrato.Rows.Count; i++)
            {
                li = new ListItem();
                li.Text = lista_estadoContrato.Rows[i]["descripcion"].ToString();
                li.Value = lista_estadoContrato.Rows[i]["id_estado_contrato"].ToString();
                c_estado_contrato.Items.Add(li);
            }

            RenglonPresupuestarioLN renglonPresup = new RenglonPresupuestarioLN();
            DataTable lista_renglonPresup = renglonPresup.ObtenerRenglonPresupuestario();
            for (int i = 0; i < lista_renglonPresup.Rows.Count; i++)
            {
                li = new ListItem();
                li.Text = lista_renglonPresup.Rows[i]["descripcion"].ToString();
                li.Value = lista_renglonPresup.Rows[i]["id_renglon_presupuestario"].ToString();
                c_renglon_presup.Items.Add(li);
            }
        }

        /// <summary>
        /// Método con el que se obtienen los datos generales del empleado y se almacenan en el objeto empleado para editarlo
        /// </summary>
        /// <returns>objeto empleado</returns>
        private EmpleadoNew ObtenerDatos()
        {
            int? intnull = null;
            EmpleadoNew empleado = new EmpleadoNew();
            empleado.codigo = Convert.ToInt32(codigo.Value);
            empleado.primer_nombre = primer_nombre.Value.ToUpper();
            empleado.primer_apellido = primer_apellido.Value.ToUpper();
            empleado.segundo_apellido = String.IsNullOrEmpty(segundo_apellido.Value) ? "" : segundo_apellido.Value.ToUpper();
            empleado.segundo_nombre = String.IsNullOrEmpty(segundo_nombre.Value) ? "" : segundo_nombre.Value.ToUpper();
            empleado.apellido_casada = String.IsNullOrEmpty(apellido_casada.Value) ? "" : apellido_casada.Value.ToUpper();
            empleado.cui = String.IsNullOrEmpty(cui.Value) ? "" : cui.Value;
            empleado.nit = String.IsNullOrEmpty(nit.Value) ? "" : nit.Value;
            empleado.id_genero = Convert.ToInt32(d_genero.Value);
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
            empleado.licencia_conducir = String.IsNullOrEmpty(numero_licencia.Value) ? "":numero_licencia.Value;
            empleado.id_tipo_licencia = String.IsNullOrEmpty(d_tipo_licencia.Value) ? intnull : Convert.ToInt32(d_tipo_licencia.Value);
            empleado.tipo_vivienda = casa_propia.Checked; //if false then alquiler
            empleado.id_archivo = id_archivo.Value != string.Empty ? Convert.ToInt32(id_archivo.Value) : (int?)null;
            empleado.url_Imagen = imagen_url.Value;
            empleado.correo = correo.Value;
            return empleado;
        }

        /// <summary>
        /// Método con el que se obtienen las alergías y enfermedades del empleado y se almacenan en el objeto alergiasYEnfermedades para editarlas
        /// </summary>
        /// <returns>Objeto alergiasyenfermedades</returns>
        private AlergiasYEnfermedadesNew ObtenerData()
        {
            int? intnull = -1;
            AlergiasYEnfermedadesNew alergiasyenfermedades = new AlergiasYEnfermedadesNew();
            alergiasyenfermedades.id_empleado = Convert.ToInt32(Request["id"]);
            alergiasyenfermedades.id_tipo_sangre = String.IsNullOrEmpty(d_tipo_sangre.Value) ? intnull : Convert.ToInt32(d_tipo_sangre.Value);
            alergiasyenfermedades.Alergias = d_alergias.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            alergiasyenfermedades.Enfermedades = d_enfermedades.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value).ToList();
            return alergiasyenfermedades;
        }

        /// <summary>
        /// Asigna las descripciones de alergias y enfermedades que tiene el empleado a las listas
        /// </summary>
        private void DarValoresAlergiasEnfermedades()
        {
            EmpleadosLN empleado = new EmpleadosLN();
            List<bool> StateAlergias = empleado.AlergiasSelected(Convert.ToInt32(Request["id"]), d_alergias.Items.Cast<ListItem>().ToList());
            List<bool> StateEnfermedades = empleado.EnfermedadesSelected(Convert.ToInt32(Request["id"]), d_enfermedades.Items.Cast<ListItem>().ToList());
            for (int i = 0; i < d_alergias.Items.Count; i++)
            {
                d_alergias.Items.Cast<ListItem>().ElementAt(i).Selected = StateAlergias[i];
            }

            for (int i = 0; i < d_enfermedades.Items.Count; i++)
            {
                d_enfermedades.Items.Cast<ListItem>().ElementAt(i).Selected = StateEnfermedades[i];
            }
        }

        /// <summary>
        /// Obtiene los datos del contacto del familiar y lo agrega a los familiares del empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardarFamiliar_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(txtNombreCompletoP.Value))
                {
                    if (!string.IsNullOrEmpty(txtFechaNacimientoP.Value))
                    {
                        try
                        {
                            string emergencia = "";
                            if (cbContactoEmer.Checked)
                            {
                                emergencia = "1";
                            }
                            else
                            {
                                emergencia = "0";
                            }

                            ParentescoLN parentesco = new ParentescoLN();
                            int result = parentesco.InsertarFamiliar(Request["id"], txtNombreCompletoP.Value, txtFechaNacimientoP.Value, emergencia, String.IsNullOrEmpty(txtTelefonoP.Value) ? "0" : txtTelefonoP.Value, ddlParentesco.SelectedValue);
                            if (result == 1)
                            {
                                txtNombreCompletoP.Value = "";
                                txtFechaNacimientoP.Value = "";
                                txtTelefonoP.Value = "";
                                ddlParentesco.SelectedIndex = 0;

                                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "Mensaje", "alert('Datos guardados éxitosamente');", true);

                                Response.Redirect("Editar.aspx?id=" + Request["id"] + "#tab_familiares");
                            }
                        }
                        catch (Exception ex)
                        {
                            l_error.Visible = true;
                            l_error.InnerText = "Error: " + ex.Message;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Muestra el listado de familiares ingresados para el empleado
        /// </summary>
        public void ListadoFamiliares()
        {
            ParentescoLN parentesco = new ParentescoLN();
            DataSet dsResultado = parentesco.ListadoFamiliares(int.Parse(codigo.Value));

            tabla_familiares.DataSource = dsResultado;
            tabla_familiares.DataBind();

            //int rows = tabla_familiares.Rows.Count;

            //try
            //{
            //    for (int i = 0; i < rows; i++)
            //    {
            //        if (tabla_familiares.Rows[i].Cells[2].Text == "0")
            //        {
            //            tabla_familiares.Rows[i].Cells[2].Text = "NO";
            //        }
            //        else
            //        {
            //            tabla_familiares.Rows[i].Cells[2].Text = "SI";
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        /// <summary>
        /// Obtiene los datos del contrato para mostrarlos
        /// </summary>
        /// <param name="id_empleado">Código del empleado a obtener el contrato</param>
        private void LlenarContrato(int id_empleado)
        {
            ContratoLN contrato = new ContratoLN();
            DataTable datos_contrato = contrato.ObtenerContrato(id_empleado);
            if (datos_contrato.Rows.Count > 0)
            {
                cod_contrato.Value = datos_contrato.Rows[0]["id_contrato"].ToString();
                c_puesto.Value = datos_contrato.Rows[0]["puesto"].ToString();
                c_area.Value = datos_contrato.Rows[0]["area"].ToString();
                c_jefe_inmediato.Value = datos_contrato.Rows[0]["jefe_inmediato"].ToString();
                c_puesto_jefe.Value = datos_contrato.Rows[0]["puesto_jefe_inmediato"].ToString();
                c_salario.Value = datos_contrato.Rows[0]["salario"].ToString();
                c_fecha_ini.Value = Convert.ToDateTime(datos_contrato.Rows[0]["fecha_inicial"].ToString()).ToString("yyyy-MM-dd");
                c_fecha_final.Value = Convert.ToDateTime(datos_contrato.Rows[0]["fecha_fin"].ToString()).ToString("yyyy-MM-dd");
                c_renglon_presup.Value = datos_contrato.Rows[0]["id_renglon_presupuestario"].ToString();
                c_estado_contrato.Value = datos_contrato.Rows[0]["id_estado_contrato"].ToString();
                c_motivo.Value = datos_contrato.Rows[0]["motivo"].ToString();
            }


        }

        /// <summary>
        /// Obtiene los datos del contrato que se tienen en la página
        /// </summary>
        /// <returns>Objeto contrato</returns>
        private Contratos ObtenerContrato()
        {
            Contratos contrato = new Contratos();

            contrato.id_contrato = Convert.ToInt32(String.IsNullOrEmpty(cod_contrato.Value) ? "0" : cod_contrato.Value);
            contrato.id_empleado = Convert.ToInt32(id);
            contrato.id_estado_contrato = Convert.ToInt32(String.IsNullOrEmpty(c_estado_contrato.Value) ? "0" : c_estado_contrato.Value);
            contrato.id_renglon_presupuestario = Convert.ToInt32(String.IsNullOrEmpty(c_renglon_presup.Value) ? "0" : c_renglon_presup.Value);
            contrato.puesto_jefe_inmediato = String.IsNullOrEmpty(c_puesto_jefe.Value) ? "" : c_puesto_jefe.Value;
            contrato.jefe_inmediato = String.IsNullOrEmpty(c_jefe_inmediato.Value) ? "" : c_jefe_inmediato.Value;
            contrato.motivo = String.IsNullOrEmpty(c_motivo.Value) ? "" : c_motivo.Value;
            contrato.puesto = String.IsNullOrEmpty(c_puesto.Value) ? "" : c_puesto.Value;
            contrato.salario = Convert.ToDecimal(String.IsNullOrEmpty(c_salario.Value) ? "0" : c_salario.Value);
            contrato.area = String.IsNullOrEmpty(c_area.Value) ? "" : c_area.Value;
            contrato.fecha_inicial = Convert.ToDateTime(c_fecha_ini.Value).ToString("yyyy-MM-dd");
            contrato.fecha_final = Convert.ToDateTime(c_fecha_final.Value).ToString("yyyy-MM-dd");

            return contrato;
        }

        /// <summary>
        ///Muestra el listado de constancias educativas ingresadas para el empleado
        /// </summary>
        private void CargarConstancias()
        {
            try
            {
                ConstanciaEducativaLN ln = new ConstanciaEducativaLN();
                var constancias = ln.ConsultarConstanciaParaEmpleado(Convert.ToInt32(Session["id"].ToString()));

                for (int i = 0; i < constancias.Rows.Count; i++)
                {
                    int fil = i + 1;
                    int id = Convert.ToInt32(constancias.Rows[i]["id_constancia"]);
                    tabla_historial_educativo.Rows.Add(NewRow());
                    tabla_historial_educativo.Rows[fil].Cells.Add(NewCell());
                    tabla_historial_educativo.Rows[fil].Cells.Add(NewCell());
                    tabla_historial_educativo.Rows[fil].Cells.Add(NewCell());
                    tabla_historial_educativo.Rows[fil].Cells.Add(NewCell());
                    tabla_historial_educativo.Rows[fil].Cells.Add(NewCell());
                    tabla_historial_educativo.Rows[fil].Cells.Add(NewCell());

                    tabla_historial_educativo.Rows[fil].Cells[0].Text = obtenerNivel(constancias.Rows[i]["id_nivel"].ToString());
                    tabla_historial_educativo.Rows[fil].Cells[1].Text = constancias.Rows[i]["lugar"].ToString();
                    tabla_historial_educativo.Rows[fil].Cells[2].Text = constancias.Rows[i]["descripcion"].ToString();
                    tabla_historial_educativo.Rows[fil].Cells[3].Text = Convert.ToDateTime(constancias.Rows[i]["fecha_desde"]).ToShortDateString();
                    tabla_historial_educativo.Rows[fil].Cells[4].Text = Convert.ToDateTime(constancias.Rows[i]["fecha_hasta"].ToString()).ToShortDateString();
                    tabla_historial_educativo.Rows[fil].Cells[5].Controls.Add(BotonEditarConstancia(constancias.Rows[i]["id_constancia"].ToString()));
                    
                    
                    if (constancias.Rows[i]["ruta"].ToString() != string.Empty)
                    {
                        tabla_historial_educativo.Rows[fil].Cells[5].Controls.Add(BotonDescargar(constancias.Rows[i]["ruta"].ToString()));
                    }
                    tabla_historial_educativo.Rows[fil].Cells[5].Controls.Add(BotonEliminar(constancias.Rows[i]["id_constancia"].ToString()));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Obtiene la descripción del nivel educativo a ingresar
        /// </summary>
        /// <param name="id_nivel">Id del nivel educativo</param>
        /// <returns>String con descripción</returns>
        private string obtenerNivel(string id_nivel)
        {
            switch (id_nivel)
            {
                case "1":
                    return "Primaria";
                case "2":
                    return "Básicos";
                case "3":
                    return "Diversificado";
                case "4":
                    return "Educación Superior";
                case "5":
                    return "Especialización o Maestría";
                case "6":
                    return "Capacitación";

            }
            return id_nivel;
        }

        /// <summary>
        /// Botón para descargar el archivo de la constancia educativa
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>Objeto botón</returns>
        private LinkButton BotonDescargar(string ruta)
        {
            LinkButton button = new LinkButton();
            // button.PostBackUrl = "DownloadFileHandler.ashx?FileName=" + ruta.Trim();
            button.OnClientClick = "window.open('DownloadFileHandler.ashx?FileName=" + ruta.Trim() + "','_newtab');";
            button.CssClass = "btn btn-default btn-sm";
            button.Text = "Descargar Archivo";
            return button;
        }

        /// <summary>
        /// Botón para eliminar el registro de la constancia educativa
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto botón</returns>
        private LinkButton BotonEliminar(string id)
        {
            LinkButton button = new LinkButton();
            button.PostBackUrl = "Editar.aspx?id=" + Session["id"].ToString() + "&delC=" + id;
            button.CssClass = "btn btn-danger btn-sm";
            button.Text = "Eliminar";
            return button;
        }



        /// <summary>
        /// Botón para editar el registro de la constancia educativa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private LinkButton BotonEditarConstancia(string id)
        {
            LinkButton button = new LinkButton();
            button.PostBackUrl = "Editar.aspx?id=" + Session["id"].ToString() + "&loadC=" + id;
            button.CssClass = "btn btn-primary btn-sm";
            button.Text = "Editar";

            //ConstanciaEducativaLN ln = new ConstanciaEducativaLN();
            //var dt = ln.ConsultarConstancia(int.Parse(id));
            //CargarConstanciaEdicion(dt);
            return button;
        }

        /// <summary>
        /// Obtiene los datos de la constancia educativa, los almacena en un objeto ConstanciaEducativa para poder almacenarla
        /// </summary>
        /// <returns>Objeto de constancia educativa</returns>
        private ConstanciaEducativa ObtenerDatosConstanciaEducativa()
        {
            var constancia = new ConstanciaEducativa();
            constancia.id_constancia = id_constancia.Value != string.Empty ? Convert.ToInt32(id_constancia.Value) : 0;
            constancia.id_empleado = Convert.ToInt32(Session["id"].ToString());
            constancia.lugar = lugar_constancia_educativa.Text;
            constancia.descripcion = descripcion_constancia_educativa.Text;
            constancia.fecha_desde = Convert.ToDateTime(desde_constancia_educativa.Value);
            constancia.fecha_hasta = Convert.ToDateTime(hasta_constancia_educativa.Value);
            constancia.id_nivel = Convert.ToInt32(listaNivel.Value);
            constancia.id_archivo = id_archivo_constancia.Value != string.Empty ?
                Convert.ToInt32(id_archivo_constancia.Value) : (int?)null;
            constancia.archivo_url = ComprobanteCargado.Value != string.Empty ? Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + ComprobanteCargado.Value : string.Empty;
            return constancia;

        }

        private TableHeaderRow NewRowHeader()
        {
            TableHeaderRow row = new TableHeaderRow();

            return row;
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

        /// <summary>
        /// Boton agregar constancia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregarConstanciaEdu_OnClick(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();

                if (Page.IsValid && ValidarFechaHastad())
                {
                    CrearConstancia();
                }
            }
            catch (Exception ex)
            {
                l_error.Visible = true;
                l_error.InnerText = "Error: " + ex.Message;
                //Page.ClientScript.RegisterClientScriptInclude(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('dd')</script>");
            }
        }

        private bool ValidarFechaHastad()
        {
            if (hasta_constancia_educativa.Value == string.Empty)
            {
                ValidarFechaHasta.Visible = true;
                return false;
            }
            if (desde_constancia_educativa.Value == string.Empty)
            {
                ValidarFechaDesde.Visible = true;
                return false;
            }
            ValidarFechaDesde.Visible = false;
            ValidarFechaDesde.Visible = false;
            return true;

        }


        private void CrearConstancia()
        {
            var constanciaLN = new ConstanciaEducativaLN();
            var archivo = new ArchivoLN();
            var data = ObtenerDatosConstanciaEducativa();
            if (BanderaCargoComprobante.Value == "1" && data.id_archivo.HasValue && data.archivo_url != string.Empty)
            {
                var resultado = archivo.ModificarArchivo(new Archivo
                {
                    url = data.archivo_url
                    ,
                    id_archivo = data.id_archivo ?? 0
                });

                data.id_archivo = resultado.id_archivo;
            }
            else if (!data.id_archivo.HasValue && data.archivo_url != string.Empty)
            {
                var resultado = archivo.NuevoArchivo(new Archivo
                {
                    url = data.archivo_url
                });
                data.id_archivo = resultado.id_archivo;
            }

            DataTable dt = constanciaLN.AgregarConstancia(data);
            if (!dt.HasErrors)
            {
                Response.Redirect("Editar.aspx?id=" + Request["id"]);
            }
            else
            {
                l_error.Visible = true;
                l_error.InnerText = "Error inesperado";
            }

        }

     

        protected void tabla_familiares_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            int x = 0;
            try
            {
                int idDetalle = int.Parse(e.Keys["ID"].ToString());

                if (idDetalle == 0)
                    throw new Exception("No Familiar para eliminar");
                ParentescoLN parentesco = new ParentescoLN();
                int result = parentesco.Eliminar_Familiar(idDetalle);
                if (result == 1)
                {
                    ListadoFamiliares();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}