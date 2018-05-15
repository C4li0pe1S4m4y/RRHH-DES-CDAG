<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="AplicacionSIPA1.dashboard" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
         <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="525px" Width="1530px">
             <LocalReport ReportPath="Reportes\dashboard.rdlc">
                 <DataSources>
                     <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                     <rsweb:ReportDataSource DataSourceId="SqlDataSource2" Name="DataSet2" />
                     <rsweb:ReportDataSource DataSourceId="SqlDataSource3" Name="DataSet3" />
                     <rsweb:ReportDataSource DataSourceId="SqlDataSource4" Name="DataSet4" />
                 </DataSources>
             </LocalReport>
         </rsweb:ReportViewer>
        
         <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa ON aa.id_accion = d.id_accion WHERE (up.estado_financiero = 1) AND (aa.id_poa = 23)"></asp:SqlDataSource>
        
         <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT SUM(d.monto) AS monto
FROM     sipa_detalles_accion d INNER JOIN
                  sipa_acciones aa ON aa.id_accion = d.id_accion INNER JOIN
                  sipa_renglones r ON d.no_renglon = r.No_Renglon INNER JOIN
                  sipa_tipos_financiamiento f ON d.id_tipo_financiamiento = f.id_tipo
WHERE  (aa.id_poa = 23)
GROUP BY d.no_renglon"></asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT v.no_solicitud, ev.nombre_estado, u.id_unidad, u.Unidad FROM sipa_viaticos v INNER JOIN sipa_estados_viaticos ev ON ev.id_estado_viatico = v.id_estado_viatico INNER JOIN ccl_unidades u ON u.id_unidad = v.id_unidad "></asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_pedidos p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_pedido INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad "></asp:SqlDataSource>
    </div>
   
</asp:Content>
