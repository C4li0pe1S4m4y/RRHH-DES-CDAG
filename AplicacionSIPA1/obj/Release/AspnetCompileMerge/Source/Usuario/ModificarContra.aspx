﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarContra.aspx.cs" Inherits="AplicacionSIPA1.Usuario.ModificarContra" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width:80%;">
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style13">Modificar Contraseña</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">Contraseña Actual</td>
                                <td class="auto-style12">
                                    <asp:TextBox ID="TextPass_Anterior" runat="server" class="form-control" placeholder="Contraseña Actual" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11">Nueva Contraseña</td>
                                <td class="auto-style12">
                                    <asp:TextBox ID="TextPass_Nuevo" runat="server" class="form-control" placeholder="Nueva Contraseña" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11">Confirmar Contraseña</td>
                                <td class="auto-style12">
                                    <asp:TextBox ID="TextPass_Confirmar" runat="server" class="form-control" placeholder="Confirmar Contraseña" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style12"><span class="label label-danger"><asp:Label ID="lblError" runat="server" Text="Label"  visible="false" ></asp:Label></span>
                <span class="label label-success"><asp:Label ID="lblSuccess" runat="server" Text="Label"  visible="false" ></asp:Label></span>  
                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style12">
                                    <asp:Button ID="Button1" runat="server" class="btn btn-primary" OnClick="Button1_Click" Text="ACEPTAR" />
                                    <asp:Button ID="Button2" runat="server" class="btn btn-default" OnClick="Button2_Click" Text="CANCELAR" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style11 {
            width: 30%;
        }
        .auto-style12 {
            width: 60%;
        }
        .auto-style13 {
            width: 60%;
            font-weight: bold;
            font-size: x-large;
            text-align: center;
        }
    </style>
</asp:Content>


