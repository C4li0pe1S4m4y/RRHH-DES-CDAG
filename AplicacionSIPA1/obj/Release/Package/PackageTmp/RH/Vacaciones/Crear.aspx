<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="AplicacionSIPA1.RH.Vacaciones.Ingresa" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    
    <script src="../../Scripts/jquery-3.2.1.js"></script>
    <script src="../../Scripts/jquery-3.2.1.min.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/select2.js"></script>
    <script src="../../Scripts/select2.min.js"></script>
    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <link href="../../Content/css/select2.css" rel="stylesheet" />
    <script>
        var x = document.getElementById("myForm");
        x.addEventListener("focusin", myFocusFunction);
        x.addEventListener("focusout", myBlurFunction);

        function myFocusFunction() {
            document.getElementById("fechaini").style.backgroundColor = "yellow"; 
        }

        function myBlurFunction() {
            document.getElementById("fechaini").style.backgroundColor = "";
        }
</script>
    <script type="text/javascript">
        function mayusculas(t)
        {
            t.value = t.value.toUpperCase();
        }

        function fechas()
        {
            //fechaIni = document.getElementById("fechaini").value;
            //fechaFin = document.getElementById("fechafin").value;
            //var difference_ms = fechaFin - fechaIni;

            document.getElementById("txtdiastomar").Value = 5;
        }
    </script>  

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <div style="margin-left: 5%; width: 90%; height: 100%; align-content: center">
        <br />
        <div class="row">
            <div class="col-xs-1 form-horizontal">                
             <asp:Image runat="server" ID="imagenEmpleado" ImageUrl="~/Content/Imagenes/cogLogo.ico" Height="80px" Width="60px" />
            </div>
             <div class="col-xs-10 form-horizontal">      
                <h4> <strong>Confederación Deportiva Autonoma de Guatemala -CDAG-</h4>
                <h3> Solicitud Vacaciones</h3>
            
            </div>
        </div>
        <label class="danger" id="l_error" runat="server" style="color: red"></label>
         <div class="row">
            <div class="col-lg-7 col-md-6 col-xs-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><strong>Datos Solicitud</strong></div>
                    <div class="panel-body">
                         <div class="row">
                              <div class="col-xs-3 form-horizontal">
                                <label>Codigo Empleado</label>
                                <input type="number" autocomplete="off" class="form-control" disabled="true" required="required" runat="server" name="txtcodigo" id="txtcodigo" />
                            </div>
                            <div class="col-xs-3 form-horizontal">
                                <label>Fecha</label>
                                <input type="text" autocomplete="off" class="form-control" disabled="true" required="required" runat="server" name="fecha" id="fecha" />
                            </div>
                            
                        </div>
                        <div class="row">
                            <div class="col-xs-8 form-horizontal">
                                <label>Nombre Completo</label>
                                <input type="text" autocomplete="off" maxlength="50" class="form-control" disabled="true" required="required" runat="server" name="txtnombre_completo" id="txtnombre_completo" onblur="mayusculas(this);"  />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-8 form-horizontal">
                                <label>Cargo Desempeña</label>
                                <input type="text" autocomplete="off" maxlength="50" class="form-control" disabled="true" required="required" runat="server" name="txtcargo" id="txtcargo" onblur="mayusculas(this);"  />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-8 form-horizontal">
                                <label>Unidad Adminitrativa</label>
                                <input type="text" autocomplete="off" maxlength="50" class="form-control" disabled="true" required="required" runat="server" name="txtunidad" id="txtunidad" onblur="mayusculas(this);"  />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-8 form-horizontal">
                                <label>Direccion Particular</label>
                                <input type="text" autocomplete="off" maxlength="50" class="form-control" disabled="true" required="required" runat="server" name="txtdireccion" id="txtdireccion" onblur="mayusculas(this);"  />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-xs-8 form-horizontal">
                                <label>Telefono</label>
                                <input type="text" autocomplete="off" maxlength="50" class="form-control"  disabled="true" required="required" runat="server" name="txttelefono" id="txttelefono" onblur="mayusculas(this);"  />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-xs-8 form-horizontal">
                                <label>Le cubrira alguna persona</label>
                                <input type="text" autocomplete="off" maxlength="50" class="form-control" required="required" runat="server" name="txtcubrira" id="txtcubrira" onblur="mayusculas(this);"  />
                            </div>
                        </div>
                          <div class="row">
                               <br />
                            <div class="col-xs-3 form-horizontal">
                                <label>Fechas que Solicita </label>
                                <br />
                                <label>inicio </label>
                                <input type="date" autocomplete="off" class="form-control" required="required" runat="server" name="fechaini" id="fechaini" />
                            </div>
                             <div class="col-xs-3 form-horizontal">
                                 <br />
                                     
                                <label>Fecha Fin</label>
                                 <asp:TextBox runat="server" TextMode="Date" ></asp:TextBox> 
                                <input type="date" autocomplete="off" class="form-control" required="required" runat="server" name="fechafin" id="fechafin" onblur="fechas();" />
                            </div>
                            </div>
                        <br />
                       
                    </div>
                </div>
            </div>

             <div class="col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">Periodo Parcial</div>
                            <div class="panel-body">
                                <div class="row">
                                   <div class="col-xs-6 form-horizontal">
                                    <label>Periodo Parcial</label>
                                       <label>Cantidad de Dias a tomar</label>
                                    </div>
                                      <div class="col-xs-4 form-horizontal">
                                        <input type="text" autocomplete="off" maxlength="50" readonly="true" class="form-control"  required="required" runat="server" name="txtdiastomar" id="txtdiastomar" onblur="mayusculas(this);"  />
                                      </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12 form-horizontal">
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
             <div class="col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">Periodo Completo</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-xs-1 form-horizontal">
                                        <input type="radio" class="radio" runat="server" name="rdoperiodo1" id="rdoperiodo1" />
                                    </div>
                                    <div class="col-xs-6 form-horizontal">
                                    <label>22 Dias (1 a 5 años)</label>
                                    </div>
                                </div>
                                 <div class="row">
                                   <div class="col-xs-1 form-horizontal">
                                        <input type="radio" class="radio" runat="server" name="rdoperiodo2" id="rdoperiodo2" />
                                    </div>
                                      <div class="col-xs-6 form-horizontal">
                                   <label>24 Dias (6 a 12 años)</label>
                                    </div>
                                </div>
                                 <div class="row">
                                   <div class="col-xs-1 form-horizontal">
                                        <input type="radio" class="radio" runat="server" name="rdoperiodo3" id="rdoperiodo3" />
                                    </div>
                                      <div class="col-xs-8 form-horizontal">
                                   <label>26 Dias (13 años en adelante)</label>
                                    </div>
                                </div>
                                 
                                
                            </div>
                        </div>
                    </div>
        </div>
        
        <div class="row">
            <div class="col-lg-7">
                <div class="panel panel-default">
                    <div class="panel-heading"><strong>Area Exclusiva para uso de la Dirección de Gestion de Personal - Subgerencia de Desarrollo Humano</strong></div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-3 form-horizontal">
                                <label>Ultimo Periodo de Vacaciones (Años)</label>
                                <input type="text" autocomplete="off" disabled="true"  maxlength="15" class="form-control" runat="server" name="txtultimoperiodo" id="txtultimoperiodo" />
                            </div>
                        </div>
                         <div class="row">
                             <div class="col-xs-3 form-horizontal">
                                <label>Dias Disponibles</label>
                                <input type="text" autocomplete="off" disabled="true"  maxlength="10" class="form-control" runat="server" name="txtdiasdispon" id="txtdiasdispon" />
                             </div>
                              <div class="col-xs-3 form-horizontal">
                                <label>Periodo (Años)</label>
                                <input type="text" autocomplete="off"  disabled="true" maxlength ="10" class="form-control" runat="server" name="txtperiodo" id="txtperiodo" />
                              </div>
                           </div>
                         <div class="row">
                               <br />
                            <div class="col-xs-3 form-horizontal">
                                <label>Periodo Autorizado de Vacaciones: </label>
                                <br />
                                <label>Del </label>
                                <input type="date" autocomplete="off" disabled="true"  class="form-control" required="required" runat="server" name="txtautorizadel" id="txtautorizadel" />
                            </div>
                             <div class="col-xs-3 form-horizontal">
                                 <br />
                                 <br />
                                <label>Al</label>
                                <input type="date" autocomplete="off" disabled="true" class="form-control" required="required" runat="server" name="txtautorizaal" id="txtautorizaal" />
                            </div>
                              <br />
                               <br />
                              <div class="col-xs-4 form-horizontal">
                                <label>Correspondiente al Año de:</label>
                                <input type="text" autocomplete="off" disabled="true"  maxlength="10" class="form-control" runat="server" name="txtyearcorrespondiente" id="txtyearcorrespondiente" />
                              </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="pager">
            <asp:Button runat="server" CssClass="btn btn-success" UseSubmitBehavior="true"  Text="Crear Solicitud" />
        </div>
       
    </div>
 
</asp:Content>
