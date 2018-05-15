<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoMunicipio.aspx.cs" Inherits="AplicacionSIPA1.RH.Catalogos.Municipio.ListadoMunicipio" MasterPageFile="~/Principal.Master" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <div style="margin-left: 5%; width: 90%; height: 100%">
        <h3 style="text-align: center">LISTADO DE MUNICIPIOS</h3>
        <div class="form-group"  style="margin-left:30%; width:60%">
            <br />
            <br />
            <table style="width:90%;" >
              <tr>
                <td style="color:#006699;width: 12%;"><b>Descripción:</b></td>
                <td>
                    <asp:TextBox ID="descripcion" CssClass="form-control" runat="server" BackColor="#FFFF99" placeholder="Ingrese descripcion del municipio" Width="95%"></asp:TextBox>
                </td>
                <td style="color:#006699;width: 10%;"><b>Código:</b></td>
                <td>
                    <asp:TextBox ID="codigo" CssClass="form-control" runat="server" BackColor="#FFFF99" placeholder="Ingrese código del municipio" Width="95%"></asp:TextBox>
                </td>
                  
                <td>
                     <asp:Button ID="btnNuevo" runat="server" class="btn btn-success" OnClick="Crear" Text="Agregar" Width="90%" />
                </td>
              </tr>
            </table>
        </div>
        <span class="gl"></span>
        <div class="form-group" style="margin-left:20%; width:65%">
            <br />
            <asp:Table runat="server" ID="tabla_municipio" CssClass="table table-hover" BorderStyle="Solid" GridLines="Both">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Descripción</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Código</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">Acción</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <br />
        <br />
        <dl class="dl-horizontal" style="margin-left:75%">
            <dt><asp:Button ID="btnRegresar" runat="server" class="btn btn-default btn-sm" OnClick="Regresar" Text="Regresar al listado" /></dt>
        </dl>
    </div>
</asp:Content>
