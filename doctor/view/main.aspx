<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="doctor.view.main" %>

<!--#include virtual="navbar.aspx"-->
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scaled=1">
	<title>Home</title>
	<link rel="stylesheet" href=".../../css/main.css">
	</head>
	<body class="body">
	<div class="wrapper">
	<div class="box">
	<img src="images/checkup.png">
	<a href=".../../checkup.aspx"><p>Check up</p></a>
	</div>
	<div class="box">
	<img src="images/drugs.png"></img>
	<a href=".../../drugs.aspx"><p>Prescriptions and drugs</p></a>
	</div>
	<div class="box">
	<img src="images/retired.png"></img>
	<a href=".../../free_time.aspx"><p>Total appointments</p></a>
	</div>
	<div class="box">
	<img src="images/covid.png"></img>
	<a href=".../../covid.aspx"><p>Covid-19 Vacciness</p></a>
	</div>
	<div class="box">
	<img src="images/flu.png"></img>
	<a href=".../../flu.aspx"><p>Flu Vacciness</p></a>
	</div>
	<div class="box">
	<img src="images/disabled.png"></img>
	<a href=".../../appointments.aspx"><p>Free time</p></a>
	</div>
	</div>
	</body>
	</html>
