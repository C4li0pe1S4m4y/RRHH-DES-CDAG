<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="IngresoVacaciones.aspx.cs" Inherits="AplicacionSIPA1.RH.Vacaciones.IngresoVacaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <div style="margin-left: 5%; width: 90%; height: 100%">

    <h2  style="margin-left:28%" >&nbsp;&nbsp;&nbsp; Ingreso de Vacaciones</h2>
     <br />
    <asp:Label ID="idVacacion" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="idContrato" runat ="server" Visible="false"></asp:Label>
   
    <div class="row" style="background-color:lightblue; width: 90%; margin-left:5%;" >
        <div class="col-xs-3">
            <label>Nombre:</label>
            <asp:Label ID="lblNombre" runat="server"></asp:Label>
        </div>
        <div class="col-xs-3">
            <label>Codigo:</label>
            <asp:Label ID="lblCodigo" runat="server"></asp:Label>
        </div>
        <div class="col-xs-3">
            <label>Fecha Inicio Contrato:</label>
            <asp:Label ID="lblFecha" runat="server"></asp:Label>
        </div>
    </div>
     <br />
    <div class="row" style="margin-left:15%">
        <div class="col-xs-3">
            <label>Total de Vacaciones</label>
            <asp:TextBox ID="txtTotalVacaciones" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-xs-3">
            <label>Días a Pedir</label>
            <asp:TextBox ID="txtDias" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-xs-3">
            <label>Días Disponibles</label>
            <asp:TextBox ID="txtDisponibles" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>
     <br />
    <div class="row" style="margin-left:25%">
        <div class="col-xs-3">
            <label>Fecha Inicio V.</label>
            <asp:TextBox ID="txtInicioVac" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-xs-3">
            <label>Fecha Final V.</label>
            <asp:TextBox ID="txtFinVac" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
     <br />
    <div class="row" style="margin-left:15%">
        <div class="col-xs-3">
            <asp:Label ID="lblError" runat="server" CssClass="label-danger"></asp:Label>
        </div>
        <div class="col-xs-3">

            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" Width="50%" />
        </div>
    </div>

    <div class="form-group" style="margin-left: 20%; width: 35%">
        <br />
        <asp:GridView runat="server" ID="tabla_vacaciones" DataKeyNames="ID,Cantidad" OnRowDeleting="tabla_vacaciones_RowDeleting" CssClass="table table-hover" BorderStyle="Solid" GridLines="Both" HeaderStyle-BackColor="#04B486"
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="LightBlue">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/trash.png" OnClientClick="javascript:if(!confirm('¿Desea Eliminar Esta Vacación?'))return false" Text="Eliminar" />
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="Cantidad" Visible="False">
                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
     <div class="form-group" style="margin-left:5%">
        <asp:Button ID="btnRegresar" runat="server" class="btn btn-default btn-sm" UseSubmitBehavior="false" OnClick="Regresar" Text="Regresar" />
    </div>
 </div>
</asp:Content>
