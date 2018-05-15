<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="AplicacionSIPA1.RH.Empleado.Crear" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    
    <script src="../../Scripts/jquery-3.2.1.js"></script>
    <script src="../../Scripts/jquery-3.2.1.min.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/select2.js"></script>
    <script src="../../Scripts/select2.min.js"></script>
    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <link href="../../Content/css/select2.css" rel="stylesheet" />
    <script type="text/javascript">
        function mayusculas(t)
        {
            t.value = t.value.toUpperCase();
        }
    </script>  

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <div style="margin-left: 5%; width: 90%; height: 100%; align-content: center">
        <h3>Crear Empleado</h3>
        <label class="danger" id="l_error" runat="server" style="color: red"></label>
        <hr />
        <div class="row">
            <div class="col-lg-3 col-md-6 col-xs-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">Imagen</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-12 form-horizontal">
                            <asp:Image runat="server" ID="imgprv" ImageUrl="" Height="160px" Width="140px" />
                        </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 form-horizontal">
                            <asp:FileUpload ID="fupload" runat="server"  AllowMultiple="False" />
                            <asp:Button ID="btnUpload"   runat="server" UseSubmitBehavior="false" OnClientClick="CargarImagen(); return false;" CssClass="button" Text="Cargar Imagen" />
                            <asp:HiddenField runat="server" ID="imagen_url" />
                        </div>  
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9 col-md-6 col-xs-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">Información Personal</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-2 form-horizontal">
                                <label>Código</label>
                                <input type="number" autocomplete="off" class="form-control" required="required" runat="server" name="codigo" id="codigo" />
                            </div>
                            <div class="col-xs-2 form-horizontal">
                                <label>Primer Nombre</label>
                                <input type="text" autocomplete="off" maxlength="50" class="form-control" required="required" runat="server" name="primer_nombre" id="primer_nombre" onblur="mayusculas(this);"  />
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
                                <input type="text" autocomplete="off" class="form-control" maxlength="20" required="required" runat="server" name="cui" id="cui" />
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Municipio CUI</label>
                                    <select id="d_municipio_cui" required="required" runat="server" class="form-control dropdown_select">
                                        <option value="">-- Elija Municipio --</option>
                                    </select>
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Fecha de nacimiento</label>
                                <input type="date" autocomplete="off" class="form-control" required="required" runat="server" name="fecha_nacimiento" id="fecha_nacimiento" />
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
                                    <option value="">-- Elija Género --</option>
                                </select>
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Profesión</label>
                                <select id="d_profesion" required="required" runat="server" class="form-control dropdown_select">
                                    <option value="">-- Elija Profesion --</option>
                                </select>
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Estado Civil</label>
                                <select id="d_estado_civil" required="required" runat="server" class="form-control dropdown_select">
                                    <option value="">-- Elija Estado Civil --</option>
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
                                <select id="d_municipio_residencia" required="required" runat="server" class="form-control dropdown_select">
                                    <option value="">---</option>
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
                                <input type="number" min="0" max="99999999" autocomplete="off" step="1" class="form-control" runat="server" name="telefono_movil" id="telefono_movil" />
                            </div>
                            <div class="col-xs-4 form-horizontal">
                                <label>Teléfono residencial</label>
                                <input type="number" min="0" max="99999999" autocomplete="off" step="1" class="form-control" runat="server" name="telefono_residencial" id="telefono_residencial" />
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
                                <label>Afiliación Igss</label>
                                <input type="text" autocomplete="off" maxlength="15" class="form-control" runat="server" name="igss" id="igss" />
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>NIT</label>
                                <input type="text" autocomplete="off" maxlength="10" class="form-control" runat="server" name="nit" id="nit" />
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Tipo de Licencia</label>
                                <select id="d_tipo_licencia" runat="server" class="form-control dropdown_select">
                                    <option value="">---</option>
                                </select>
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Número de Licencia</label>
                                <input type="number" autocomplete="off" maxlength="15" class="form-control" runat="server" name="numero_licencia" id="numero_licencia" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="pager">
            <asp:Button runat="server" CssClass="btn btn-success" UseSubmitBehavior="true" OnClick="CrearEmpleado" Text="Crear Empleado" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnRegresar" runat="server" UseSubmitBehavior="false" class="btn btn-default btn-sm" OnClick="Regresar" Text="Regresar al listado" />
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $(document).ready(function () {

                $('.dropdown_select').select2({
                });
            });
        });

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
                        $("#<%=imgprv.ClientID%>").attr('src', "<%=ResolveUrl("~")%>" + result);
                    $("input[id=<%=imagen_url.ClientID%>]").val(result);
                },
                error: function (err) {
                    alert(err.statusText);

                }
            });

            return false;
        };


    </script>
</asp:Content>
