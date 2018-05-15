<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AplicacionSIPA1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>Login</title>
   <%--  <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" media="screen" />--%>
    <link href="css/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="css/utilities.css" rel="stylesheet" type="text/css" media="screen" />
   
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css"/>
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css"/>
	<link rel="stylesheet" type="text/css" href="css/main.css"/>
<!--===============================================================================================-->
    <style type="text/css">

        .style11
        {
            /*border-style: inherit;
            border-color: inherit;
            border-width: medium;*/
            width: 22px;
            height: 300px;
            /*background: #EFEFEF url(imagenesM/blue_gradiente.jpg) fixed center;*/
        }
        .style23
        {
          
        }
</style>
    
     <script type="text/javascript">
         if (window.history) {
             function noBack() { window.history.forward() }
             noBack();
             window.onload = noBack;
             window.onpageshow = function (evt) { if (evt.persisted) noBack() }
             window.onunload = function () { void (0) }
         }
        </script>
  </head>
  <body id="body2">
               <div id="DivContenedorMenu_EW2">
                </div>
                <div class="limiter">
			<div class="container-login100">
				<div class="wrap-login100">
					<div class="login100-pic js-tilt" >
						 <asp:Image ID="Image1" runat="server" Height="251px" ImageUrl="~/css/Fondos/logo-cdag.png" Width="213px" />
					</div>

					<form class="login100-form validate-form" runat="server">
						<span class="login100-form-title">
							Sistema Desarrollo Humano
						</span>

						<div class="wrap-input100 validate-input" data-validate = "Valid email is required: ex@abc.xyz">
							
							<asp:TextBox ID="TextUsuario" runat="server" BorderStyle="None" CssClass="input100 =" placeholder="Usuario" ></asp:TextBox>
							<span class="focus-input100"></span>
							<span class="symbol-input100">
								<i class="fa fa-envelope" aria-hidden="true"></i>
							</span>
						</div>

						<div class="wrap-input100 validate-input" data-validate = "Password is required">
							
							<asp:TextBox ID="TextContraseña" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="input100" ></asp:TextBox>
							<span class="focus-input100"></span>
							<span class="symbol-input100">
								<i class="fa fa-lock" aria-hidden="true"></i>
							</span>
						</div>
						
						<div class="container-login100-form-btn">
							
							<asp:Button ID="btniniciar" runat="server" CssClass="login100-form-btn" Text="Iniciar Sesión" OnClick="btniniciar_Click"  />
						</div>

						 <asp:Label ID="resultado" runat="server" ForeColor="#dddddd" style="color: #CC0000"></asp:Label>

						<div class="text-center p-t-136">
							<a class="txt2" href="#">
								Todos los Derechos Reservados CDAG, 2018
								<i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
							</a>
						</div>
					</form>
				</div>
			</div>
		</div>
     </body>
</html>
