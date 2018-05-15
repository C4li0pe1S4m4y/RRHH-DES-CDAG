<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CargarArchivo.aspx.cs" Inherits="AplicacionSIPA1.RH.CargarArchivo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    
    <form id="form1" runat="server">
        <table> 
            <tr>
                <td>File:</td>
                <td>
                    <asp:FileUpload ID="fupload" runat="server" onchange='prvimg.UpdatePreview(this)' AllowMultiple="False" /></td>
                <td>
                    <asp:Image ID="imgprv" runat="server" Height="90px" Width="75px" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" CssClass="button" Text="Upload Selected File" /></td>
            </tr>
        </table>
    </form>
</body>
<script type="text/javascript">
    $("#btnUpload").click(function (evt) {
        var fileUpload = $("#fupload").get(0);
        var files = fileUpload.files;

        var data = new FormData();
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }

        $.ajax({
            url: "Empleado/FileUploadHandler.ashx",
            type: "POST",
            data: data,
            contentType: false,
            processData: false,
            success: function (result) {
                alert(result);
                $("#<%=imgprv.ClientID%>").attr('src',  "<%=ResolveUrl("~")%>" + result);
                console.log(result);
            },
            error: function (err) {
                alert(err.statusText);

            }
        });

        evt.preventDefault();
    });
</script>
</html>
