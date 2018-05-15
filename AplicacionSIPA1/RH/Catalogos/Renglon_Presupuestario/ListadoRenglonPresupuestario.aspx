<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoRenglonPresupuestario.aspx.cs" Inherits="AplicacionSIPA1.RH.Catalogos.Renglon_Presupuestario.ListadoRenglonPresupuestario"  MasterPageFile="~/Principal.Master" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <div style="margin-left: 5%; width: 90%; height: 100%">
        <h3 style="text-align: center">LISTADO DE RENGLONES PRESUPUESTARIOS</h3>
        <div class="form-group"  style="margin-left:30%; width:60%">
            <br />
            <br />
            <table style="width:80%;" >
              <tr>
                <td style="color:#006699;width: 15%;"><b>Descripción:</b></td>
                <td>
                    <asp:TextBox ID="descripcion" CssClass="form-control" runat="server" BackColor="#FFFF99" placeholder="Ingrese descripcion del renglon presupuestario" Width="90%"></asp:TextBox>
                </td>
                <td>
                     <asp:Button ID="btnNuevo" runat="server" class="btn btn-success" OnClick="Crear" Text="Agregar" Width="70%" />
                </td>
              </tr>
            </table>
        </div>
        <span class="gl"></span>
        <div class="form-group" style="margin-left:20%; width:65%">
            <br />
            <asp:Table runat="server" ID="tabla_renglon_presupuestario" CssClass="table table-hover" BorderStyle="Solid" GridLines="Both">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Descripción</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Acción</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>
</asp:Content>
