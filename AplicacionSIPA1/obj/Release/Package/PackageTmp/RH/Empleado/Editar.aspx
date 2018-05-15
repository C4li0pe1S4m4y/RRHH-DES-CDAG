<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AplicacionSIPA1.RH.Empleado.Editar" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">

    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="../../Scripts/select2.min.js"></script>
    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function mayusculas(t)
        {
            t.value = t.value.toUpperCase();
        }

        function letras(e) {
            tecla = (document.all) ? e.keyCode : e.which;
            if (tecla == 8) return true;
            patron = /[A-Za-záéíóúñÑ ]+/;
            te = String.fromCharCode(tecla);
            return patron.test(te);
        }

        function numeros(e) {
            tecla = (document.all) ? e.keyCode : e.which;
            if (tecla == 8) return true;
            patron = /[0-9]+/;
            te = String.fromCharCode(tecla);
            return patron.test(te);
        }

        function letrasynumeros(e) {
            tecla = (document.all) ? e.keyCode : e.which;
            if (tecla==8) return true;
            patron =/[A-Za-záéíóú-0-9 ]/;
            te = String.fromCharCode(tecla);
            return patron.test(te);
        }
       
    </script>  

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <div style="margin-left: 5%; width: 90%; height: 100%; align-content: center">
        <h3>
            <asp:Label runat="server" ID="l_empleado"></asp:Label></h3>
        <label class="danger" id="l_error" runat="server" style="color: red"></label>

        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#tab_empleado">Empleado</a></li>
            <li><a data-toggle="tab" href="#tab_condicion_medica">Condición Medica</a></li>
            <%if (RRHH.Value == "0") {  %> 
                <li><a data-toggle="tab" href="#tab_contratos" style="display: none;" >Contratos</a></li>
            <% } else { %> 
                <li><a data-toggle="tab" href="#tab_contratos" >Contratos</a></li>
            <% } %>
            <li><a data-toggle="tab" href="#tab_familiares">Familiares</a></li>
            <li><a data-toggle="tab" href="#tab_historial_educativo">Historial Educativo</a></li>
        </ul>

        <div class="tab-content">
            <div id="tab_empleado" class="tab-pane fade in active">
                <br />
                <div class="row">
                    <div class="col-lg-3">
                        <div class="panel panel-default">
                            <div class="panel-heading">Imagen</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-xs-12 form-horizontal">
                                        <asp:Image runat="server" ID="imagenEmpleado" ImageUrl="~/Content/Imagenes/empleado_default.png" Height="160px" Width="140px" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12 form-horizontal">
                                        <asp:HiddenField runat="server" ID="imagen_url" />
                                        <asp:HiddenField runat="server" ID="id_archivo" />
                                        <asp:HiddenField runat="server" ID="banderaCambioImagen" />

                                        <asp:FileUpload ID="fupload" runat="server" AllowMultiple="False" />
                                        <asp:Button ID="btnUpload" runat="server" OnClientClick="CargarImagen(); return false;" CssClass="button" Text="Cargar Imagen" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-9">
                        <div class="panel panel-default">
                            <div class="panel-heading">Información Personal</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-xs-2 form-horizontal">
                                        <label>Código</label>
                                        <input type="number" readonly="true" autocomplete="off" class="form-control" required="required" runat="server" name="codigo" id="codigo" />
                                    </div>
                                    <div class="col-xs-2 form-horizontal">
                                        <label>Primer Nombre</label>
                                        <input type="text" autocomplete="off" maxlength="50" class="form-control" required="required" runat="server" name="primer_nombre" id="primer_nombre"  onblur="mayusculas(this);" />
                                         <asp:hiddenfield id="RRHH" runat="server"/>
                                          </div>
                                    <div class="col-xs-2 form-horizontal">
                                        <label>Segundo Nombre</label>
                                        <input type="text" autocomplete="off" maxlength="50" class="form-control" runat="server" name="segundo_nombre" id="segundo_nombre"  onblur="mayusculas(this);" />
                                    </div>
                                    <div class="col-xs-2 form-horizontal">
                                        <label>Primer Apellido</label>
                                        <input type="text" autocomplete="off" maxlength="50" class="form-control" required="required" runat="server" name="primer_apellido" id="primer_apellido"  onblur="mayusculas(this);" />
                                    </div>
                                    <div class="col-xs-2 form-horizontal">
                                        <label>Seg Apellido</label>
                                        <input type="text" autocomplete="off" maxlength="50" class="form-control" runat="server" name="segundo_apellido" id="segundo_apellido"  onblur="mayusculas(this);" />
                                    </div>
                                    <div class="col-xs-2 form-horizontal">
                                        <label>Apellido Casada</label>
                                        <input type="text" autocomplete="off" maxlength="50" class="form-control" runat="server" name="apellido_casada" id="apellido_casada"  onblur="mayusculas(this);" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-xs-2 form-horizontal">
                                        <label>CUI</label>
                                        <input type="number" required="required" runat="server" name="cui" id="cui" min="0" max="9999999999999" autocomplete="off" class="form-control" maxlength="13"  onkeypress="return numeros(event)"   />
                                    </div>
                                    <div class="col-xs-3 form-horizontal">
                                        <div style="width: 100%">
                                            <label>Municipio CUI</label>
                                            <select id="d_municipio_cui" name="d_municipio_cui" required="required" runat="server" class="form-control dropdown_select">
                                            </select>
                                        </div>

                                    </div>
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Fecha de nacimiento</label>
                                        <input type="date" autocomplete="off" class="form-control"  required="required" runat="server" name="fecha_nacimiento" id="fecha_nacimiento" />
                                    </div>
                                    <div class="col-xs-4 form-horizontal">
                                        <label>Lugar de Nacimiento</label>
                                        <input required="required " autocomplete="off" type="text" maxlength="300" class="form-control" runat="server" name="lugar_nacimiento" id="lugar_nacimiento"  onblur="mayusculas(this);" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Género</label>
                                        <select id="d_genero" required="required" runat="server" class="form-control dropdown_select">
                                        </select>
                                    </div>
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Profesión</label>
                                        <select id="d_profesion" required="required" runat="server" class="form-control dropdown_select">
                                        </select>
                                    </div>
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Estado Civil</label>
                                        <select id="d_estado_civil" required="required" runat="server" class="form-control dropdown_select">
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">Dirección</div>
                            <div class="panel-body">
                                <div class="row">

                                    <div class="col-xs-7 form-horizontal">
                                        <label>Direccion residencial</label>
                                        <input required="required" autocomplete="off" type="text" maxlength="300" class="form-control" runat="server" name="direccion_residencial" id="direccion_residencial"  onblur="mayusculas(this);" />
                                    </div>
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Municipio</label>
                                        <select id="d_municipio_residencia" name="d_municipio_residencia" required="required" runat="server" class="form-control dropdown_select">
                                        </select>
                                    </div>

                                    <div class="col-xs-1 form-horizontal">
                                        <input type="radio" class="radio" runat="server" name="casa_propia" id="casa_propia" required="required" /><label>Casa propia</label>
                                    </div>
                                    <div class="col-xs-1 form-horizontal">
                                        <input type="radio" class="radio" runat="server" name="casa_propia" id="alquiler" /><label>Alquiler</label>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">Contacto</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-xs-4 form-horizontal">
                                        <label>Correo</label>
                                        <input type="text" autocomplete="off" maxlength="100" class="form-control" runat="server" name="correo" id="correo" />
                                    </div>
                                    <div class="col-xs-4 form-horizontal">
                                        <label>Teléfono móvil</label>
                                        <input type="number" min="0" max="99999999" autocomplete="off" step="1" class="form-control" runat="server" name="telefono_movil" id="telefono_movil" onkeypress="return numeros(event)"  />
                                    </div>
                                    <div class="col-xs-4 form-horizontal">
                                        <label>Teléfono residencial</label>
                                        <input type="number" min="0" max="99999999" autocomplete="off" step="1" class="form-control" runat="server" name="telefono_residencial" id="telefono_residencial" onkeypress="return numeros(event)"  />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">Información adicional</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Afiliacion Igss</label>
                                        <input type="text" autocomplete="off" maxlength="15" class="form-control" runat="server" name="igss" id="igss" />
                                    </div>
                                    <div class="col-xs-3 form-horizontal">
                                        <label>NIT</label>
                                        <input type="text" autocomplete="off" maxlength="10" class="form-control" runat="server" name="nit" id="nit" />
                                    </div>
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Tipo de Licencia</label>
                                        <select id="d_tipo_licencia" runat="server" class="form-control dropdown_select">
                                            <option value="">--Elija Tipo de Licencia--</option>
                                        </select>
                                    </div>
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Número de Licencia</label>
                                        <input type="text" autocomplete="off" maxlength="15" class="form-control" runat="server" name="numero_licencia" id="numero_licencia" onkeypress="return numeros(event)" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="pager">
                    <asp:Button runat="server" CssClass="btn btn-success" UseSubmitBehavior="false" OnClick="EditarEmpleado" Text="Guardar cambios" />
                </div>
            </div>
            <div id="tab_condicion_medica" class="tab-pane fade">
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">Tipo de Sangre</div>
                            <div class="panel-body">
                                <div class="col-xs-6 form-horizontal">
                                    <select id="d_tipo_sangre" runat="server" class="form-control dropdown_select">
                                        <option value="">-- Elija --</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Enfermedades</div>
                            <div class="panel-body">
                                <div class="form-horizontal">
                                    <select multiple="true" style="width: 100%" size="30" id="d_enfermedades" name="d_enfermedades" runat="server" class="form-control dropdown_select">
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Alergias</div>
                            <div class="panel-body">
                                <div class="form-horizontal">
                                    <select multiple="true" style="width: 100%" id="d_alergias" name="d_alergias" runat="server" class="form-control dropdown_select">
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="pager">
                    <asp:Button runat="server" CssClass="btn btn-success" UseSubmitBehavior="false" OnClick="EditarCondicionMedica" Text="Guardar cambios" />
                </div>
            </div>
            <div id="tab_contratos" class="tab-pane fade">
                <br />
                <div class="panel panel-default">
                    <div class="panel-heading">Información de Contrato</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-3 form-horizontal">
                                <label>Código de Contrato</label>
                                <input type="number" readonly="true" autocomplete="off" class="form-control" runat="server" name="cod_contrato" id="cod_contrato" />
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Puesto</label>
                                <input type="text" autocomplete="off" maxlength="64" class="form-control" runat="server" name="c_puesto" id="c_puesto" />
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Area</label>
                                <input type="text" autocomplete="off" maxlength="45" class="form-control" runat="server" name="c_area" id="c_area" />
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Salario</label>
                                <input type="number" autocomplete="off" maxlength="50" class="form-control" runat="server" name="c_salario" id="c_salario" />
                            </div>

                        </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-3 form-horizontal">
                                <label>Jefe Inmediato</label>
                                <input type="text" autocomplete="off" maxlength="64" class="form-control" runat="server" name="c_jefe_inmediato" id="c_jefe_inmediato" />
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Puesto Jefe Inmediato</label>
                                <input type="text" autocomplete="off" maxlength="64" class="form-control" runat="server" name="c_puesto_jefe" id="c_puesto_jefe" />
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Renglon Presupuestario</label>
                                <select id="c_renglon_presup" required="required" runat="server" class="form-control">
                                    <option value="-1">-- Elija Renglon presupuestario --</option>
                                </select>
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Estado Contrato</label>
                                <select id="c_estado_contrato" runat="server" class="form-control">
                                    <option value="-1">-- Elija Estado de Contrato --</option>
                                </select>
                            </div>

                        </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-4 form-horizontal">
                                <label>Fecha Inicial</label>
                                <input type="date" autocomplete="off" class="form-control" required="required" runat="server" name="c_fecha_ini" id="c_fecha_ini" />
                            </div>
                            <div class="col-xs-4 form-horizontal">
                                <label>Fecha Final</label>
                                <input type="date" autocomplete="off" class="form-control" required="required" runat="server" name="c_fecha_final" id="c_fecha_final" />
                            </div>
                            <div class="col-xs-4 form-horizontal">
                                <label>Motivo</label>
                                <input type="text" autocomplete="off" maxlength="64" class="form-control" required="required" runat="server" name="c_motivo" id="c_motivo" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group" style="margin-left: 0.5%">
                    <asp:Button runat="server" CssClass="btn btn-primary" UseSubmitBehavior="false" OnClick="IngresoVacaciones" Text="Ver vacaciones" />
                </div>
                <div class="pager">
                    <asp:Button ID="btnEditarContrato" UseSubmitBehavior="false" runat="server" CssClass="btn btn-success" OnClick="EditarContrato" Text="Guardar cambios" />
                    <asp:Button ID="btnEliminarContrato" UseSubmitBehavior="false" runat="server" class="btn btn-danger" OnClick="EliminarContrato" OnClientClick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Terminar Contrato" />
                    <asp:Button ID="btnHContrato" UseSubmitBehavior="false" runat="server" class="btn btn-primary" OnClick="HistorialContratos" Text="Ver Historial Contratos" />
                </div>
            </div>
            <div id="tab_familiares" class="tab-pane fade">
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">Familiares</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-xs-6 form-horizontal">
                                        <label>Nombre Completo</label>
                                        <input type="text" class="form-control"  runat="server" name="txtNombreCompletoP" id="txtNombreCompletoP" />
                                    </div>
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Fecha Nacimiento</label>
                                        <input type="date" class="form-control" runat="server" name="txtFechaNacimientoP" id="txtFechaNacimientoP" />
                                    </div>
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Contacto De Emergencia SI/NO</label>
                                        <input type="checkbox" class="checkbox" runat="server" name="cbContactoEmer" id="cbContactoEmer" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Numero Telefónico</label>
                                        <input type="number" class="form-control" runat="server" name="txtTelefonoP" id="txtTelefonoP" />
                                    </div>
                                    <div class="col-xs-3 form-horizontal">
                                        <label>Grado de Parentesco</label>

                                        <asp:DropDownList ID="ddlParentesco" runat="server" CssClass="form-control dropdown_select" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="pager">
                                        <asp:Button runat="server" UseSubmitBehavior="false" ID="btnGuardarFamiliar" CssClass="btn btn-success" OnClick="btnGuardarFamiliar_Click" Text="Guardar Familiar" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group" style="margin-left: 20%; width: 60%">
                        <br />
                         <asp:GridView runat="server" ID="tabla_familiares" DataKeyNames="ID" OnRowDeleting="tabla_familiares_RowDeleting1" CssClass="table table-hover" BorderStyle="Solid" GridLines="Both" HeaderStyle-BackColor="#04B486"
                            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="LightBlue">
                          <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/trash.png"  Text="Eliminar" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>

                </div>
            </div>
            <div id="tab_historial_educativo" class="tab-pane fade">
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">Constancia educativa</div>
                            <div class="panel-body">
                                <div class="row">
                                    <asp:HiddenField runat="server" ID="id_constancia" />
                                    <div class="col-xs-4 form-horizontal">
                                        <label>Nivel</label>
                                        <select id="listaNivel" runat="server" class="form-control">
                                            <option value="1">Primaria</option>
                                            <option value="2">Básicos</option>
                                            <option value="3">Diversificado</option>
                                            <option value="4">Educación Superior</option>
                                            <option value="5">Especialización o Maestría</option>
                                            <option value="6">Capacitación</option>
                                        </select>
                                    </div>
                                    <div class="col-xs-4 form-horizontal">
                                        <label>Lugar</label>
                                        <asp:TextBox runat="server" MaxLength="45" class="form-control" runat="server" name="Lugar" ID="lugar_constancia_educativa" ValidationGroup="HistorialGroup" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                            ControlToValidate="lugar_constancia_educativa"
                                            ValidationGroup="HistorialGroup"
                                            ErrorMessage="Ingrese lugar."
                                            runat="Server">
                                        </asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-xs-4 form-horizontal">
                                        <label>Grado Obtenido</label>
                                        <asp:TextBox runat="server"  MaxLength="64" class="form-control" runat="server" name="Descripcion" ID="descripcion_constancia_educativa" ValidationGroup="HistorialGroup" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                            ControlToValidate="descripcion_constancia_educativa"
                                            ValidationGroup="HistorialGroup"
                                            ErrorMessage="Ingrese la descripción"
                                            runat="Server">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-xs-4 form-horizontal">
                                        <label>Desde</label>
                                        <input type="date" autocomplete="off"  class="form-control" runat="server" name="desde_constancia" id="desde_constancia_educativa" />
                                        <asp:Label ID="ValidarFechaDesde" runat="server" Visible="False">Ingrese fecha. </asp:Label>
                                    </div>
                                    <div class="col-xs-4 form-horizontal">
                                        <label>Hasta</label>
                                        <input type="date" autocomplete="off"  class="form-control" runat="server" name="hasta_constancia" id="hasta_constancia_educativa" />
                                        <asp:Label ID="ValidarFechaHasta" runat="server" Visible="False">Ingrese fecha. </asp:Label>
                                    </div>
                                    <div class="col-xs-4 form-horizontal">
                                        <asp:FileUpload ID="CargaComprobanteEstudios" runat="server" AllowMultiple="False" />
                                        <asp:Button ID="btnCargarComprobanteEstudios" runat="server" OnClientClick="CargarArchivo(); return false;" CssClass="button" Text="Cargar" />
                                        <asp:HiddenField runat="server" ID="ComprobanteCargado" />
                                        <asp:HiddenField runat="server" ID="BanderaCargoComprobante" />
                                        <asp:HiddenField runat="server" ID="id_archivo_constancia" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="table-responsive">
                    <asp:Table runat="server" ID="tabla_historial_educativo" Width="100%" GridLines="Both" CssClass="table-striped table">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Nivel</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Lugar</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Descripción</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Fecha Desde</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Fecha Hasta</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Acciones</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>

                <div class="pager">
                    <asp:Button runat="server" CssClass="btn btn-success"
                        CausesValidation="true"
                        ValidationGroup="HistorialGroup"
                        UseSubmitBehavior="false" ID="btnAgregarConstanciaEdu" OnClick="btnAgregarConstanciaEdu_OnClick" Text="Guardar cambios" />
                </div>
            </div>
        </div>
    </div>
    <div class="form-group" style="margin-left: 5%">
        <asp:Button ID="btnRegresar" runat="server" class="btn btn-default btn-sm" UseSubmitBehavior="false" OnClick="Regresar" Text="Regresar al listado" />
    </div>


    <script>
        function CargarImagen() {
            var fileUpload = $("#<%=fupload.ClientID%>").get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                url: "FileUploadHandler.ashx",
                type: "POST",
                data: data,
                contentType: false,
                processData: false,
                success: function (result) {
                    $("#<%=imagenEmpleado.ClientID%>").attr('src',  result);
                    console.log(result);
                    $("input[id=<%=imagen_url.ClientID%>]").val(result);
                    $("input[id=<%=banderaCambioImagen.ClientID%>]").val(1);
                },
                error: function (err) {
                    alert(err.statusText);
                }
            });
            return false;
        };
        function CargarArchivo() {
            var fileUpload = $("#<%=CargaComprobanteEstudios.ClientID%>").get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                url: "FileUploadHandler.ashx",
                type: "POST",
                data: data,
                contentType: false,
                processData: false,
                success: function (result) {
                    $("input[id=<%=ComprobanteCargado.ClientID%>]").val(result);
                    $("input[id=<%=BanderaCargoComprobante.ClientID%>]").val(1);
                    alert("Archivo cargado exitosamente.");
                },
                error: function (err) {
                    alert(err.statusText);
                }
            });
            return false;
        };
        $(function () {

            $(document).ready(function () {
                $('.dropdown_select').select2();
            });
        });
    </script>

</asp:Content>
