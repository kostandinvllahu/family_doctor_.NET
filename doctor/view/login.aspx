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
	
	<div class="wrapper">
	<form method="post" class="form-register">
	<h2 class="form-register-heading text-center">Login Panel</h2> 
	<input type="text" class="form-control" name="username" placeholder="Username" required="" autofocus=""/>
	<input type="password" class="form-control" name="password" placeholder="Password" required=""/>
	<button name="login" class="btn btn-lg btn btn-primary btn-block">Log In</button><br>
	<p class="text">Dont have an account? <a href=".../../signin.aspx">Register</a></p>	
	<p class="text"><a href="#">Forgot Password</a></p>
	</form>
	</div>
	</body>	
	</html>
