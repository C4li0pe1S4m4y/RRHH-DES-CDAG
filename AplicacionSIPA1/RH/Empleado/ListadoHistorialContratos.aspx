<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoHistorialContratos.aspx.cs" Inherits="AplicacionSIPA1.RH.Empleado.ListadoHistorialContratos" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <div style="margin-left: 5%; width: 90%; height: 100%; align-content: center">
        <h3 style="margin-left: 35%; width: 90%; height: 100%; align-content: center">HISTORIAL CONTRATOS</h3>
        <br />
       
        <hr />
        <div class="table-responsive">
            <asp:Table runat="server" ID="tabla_contratos" Width="100%" GridLines="Both" CssClass="table-striped table">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">CÓDIGO</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">PUESTO</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">AREA</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">RENGLÓN PRESUPUESTARIO</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">SALARIO</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">JEFE INMEDIATO</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">FECHA INICIAL</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">FECHA FINAL</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">MOTIVO</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#04B486" ForeColor="White">ESTADO CONTRATO</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div class="form-group" style="margin-left:5%">
            <asp:Button ID="btnRegresar" runat="server" class="btn btn-default btn-sm" UseSubmitBehavior="false" OnClick="Regresar" Text="Regresar" />
        </div>
    </div>
</asp:Content>
