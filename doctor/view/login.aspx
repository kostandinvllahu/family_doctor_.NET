<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="doctor.view.login" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, inital-scale=1">
	<title>Login Panel</title>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
	<link rel="stylesheet" href=".../../css/signin.css">
	<script src=".../../js/style.js"></script>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
	<style type="text/css">

    </style>
	</head>
	<body>
	
	<div class="wrapper" runat="server">
	<form method="post" class="form-register" runat="server">
	<h2 class="form-register-heading text-center">Login Panel</h2> 
     <asp:TextBox runat="server" ID="txtusername" CssClass="form-control" placeholder="Username" required="" autofocus=""/>
     <asp:TextBox runat="server" ID="txtpassword" TextMode="Password" CssClass="form-control" placeholder="Password" required="" autofocus=""/>
    <asp:Button Text="Login" ID="btnLogin" CssClass="btn btn-lg btn btn-primary btn-block" runat="server" OnClick="btnLogin_Click" />
	<p class="text">Dont have an account? <a href=".../../signin.aspx">Register</a></p>	
	<p class="text"><a href="#">Forgot Password</a></p><br />
         <asp:Label Text="" ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" />
	</form>
	</div>
	</body>	
	</html>
