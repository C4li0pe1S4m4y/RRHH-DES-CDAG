<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AplicacionSIPA1.RH.Catalogos.Tipo_Sangre.Editar" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <div style="margin-left: 5%; width: 90%; height: 100%; align-content:center">
        <h3 style="text-align:center">Editar Tipo de Sangre</h3>
        <hr />
         <div class="form-group"  style="margin-left:30%; width:60%">
             <table style="width:80%;" >
                  <tr>
                    <td style="color:#006699;width: 15%;"><b>Descripción:</b></td>
                    <td>
                        <asp:TextBox ID="descripcion" ClientIDMode="Static"  BackColor="#FFFF99" CssClass="form-control" runat="server" Width="90%"></asp:TextBox>
                    </td>
                  </tr>
                  <tr> <td>&nbsp;</td></tr>
                  <tr>
                   <td style="width: 15%"></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Editar" OnClick="EditarTipoSangre" CssClass="btn btn-sm btn-success" Width="50%"/>
                    </td>
                  </tr>
             </table>
          </div>
        <br />
        <br />
        <dl class="dl-horizontal" style="margin-left:75%">
            <dt><asp:Button ID="btnRegresar" runat="server" class="btn btn-default btn-sm" OnClick="Regresar" Text="Regresar al listado" /></dt>
        </dl>
    </div>
</asp:Content>
