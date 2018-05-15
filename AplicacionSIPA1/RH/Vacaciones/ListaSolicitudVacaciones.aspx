<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaSolicitudVacaciones.aspx.cs" Inherits="AplicacionSIPA1.RH.Vacaciones.ListaSolicitudVacaciones" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <div style="margin-left: 5%; width: 90%; height: 100%; align-content: center">
        <h3 style="margin-left: 35%; width: 90%; height: 100%; align-content: center">LISTA SOLICITUDES DE VACACIONES</h3>
        <br />
        <button class="btn btn-sm btn-success" id="btn_crear" type="button" runat="server" onserverclick="Crear"><span class="glyphicon glyphicon-plus-sign"></span> Crear</button>
        <hr />
        <div class="table-responsive" style="width:100%; overflow-y:hidden"  >
            <table class="table-striped" style="width:100%"> 
                <thead style="background-color:steelblue;">
                    <tr>
                        <th style="color:azure; text-align:center">Código</th>
                        <th style="color:azure; text-align:center">Primer nombre</th>
                        <th style="color:azure; text-align:center">Segundo nombre</th>
                        <th style="color:azure; text-align:center">Primer apellido</th>
                        <th style="color:azure; text-align:center">Segundo apellido</th>
                        <th style="color:azure; text-align:center">CUI</th>
                        <th style="color:azure; text-align:center">Buscar</th>
                    </tr>
                </thead>
                <tbody>
                    <tr >
                        <td>
                            <asp:TextBox CssClass="form-control" runat="server" ID="tb_codigo" TextMode="Number" AutoCompleteType="None"></asp:TextBox></td>
                        <td>
                            <asp:TextBox CssClass="form-control" runat="server" ID="tb_primer_nombre" AutoCompleteType="None"></asp:TextBox></td>
                        <td>
                            <asp:TextBox CssClass="form-control" runat="server" ID="tb_segundo_nombre" AutoCompleteType="None"></asp:TextBox></td>
                        <td>
                            <asp:TextBox CssClass="form-control" runat="server" ID="tb_primer_apellido" AutoCompleteType="None"></asp:TextBox></td>
                        <td>
                            <asp:TextBox CssClass="form-control" runat="server" ID="tb_segundo_apellido" AutoCompleteType="None"></asp:TextBox></td>
                        <td>
                            <asp:TextBox CssClass="form-control" runat="server" ID="tb_cui"  TextMode="Number" AutoCompleteType="None"></asp:TextBox></td>
                        <td style="text-align:center">
                            <button class="btn btn-sm btn-default" type="button" runat="server" onserverclick="GetEmpleados"><span class="glyphicon glyphicon-search"></span></button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <hr />
        <div class="table-responsive">
            <asp:Table runat="server" ID="tabla_empleados" Width="100%" GridLines="Both" CssClass="table-striped table">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Codigo Empleado</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Nombre Empleado</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Puesto</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Unidad</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Dias Solicitados</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Periodo</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">ACCIONES</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        
    </div>
</asp:Content>