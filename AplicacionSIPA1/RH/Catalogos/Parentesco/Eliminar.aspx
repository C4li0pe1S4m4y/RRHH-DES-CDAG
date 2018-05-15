<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="AplicacionSIPA1.RH.Catalogos.Parentesco.Eliminar" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
   <div style="margin-left: 5%; width: 90%; height: 100%; align-content:center">
        <h3 style="text-align:center">Eliminar Parentesco</h3>
        <hr />
        <h5 style="text-align:center">¿Está seguro de eliminar el siguiente registro?</h5>
        <hr />
        <div class="form-group"  style="margin-left:40%; width:60%">
            <table style="width:80%;" >
                  <tr>
                    <td style="color:#006699;width: 15%;"><b>Descripción:</b></td>
                    <td>
                        <asp:Label ID="descripcion" runat="server" Text=""></asp:Label>
                    </td>
                   </tr>
                  <tr> <td>&nbsp;</td></tr>
                  <tr>
                   <td style="width: 15%"></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Eliminar" OnClick="EliminarParentesco" CssClass="btn btn-sm btn-danger"/>
                    </td>
                  </tr>
             </table>
        </div>
        <dl class="dl-horizontal" style="margin-left:75%">
            <dt><asp:Button ID="btnRegresar" runat="server" class="btn btn-default btn-sm" OnClick="Regresar" Text="Regresar al listado" /></dt>
        </dl>
    </div>
</asp:Content>
