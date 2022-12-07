﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="doctor.view.login" %>

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
    <asp:Button Text="Login" ID="btnLogin" CssClass="btn btn-lg btn btn-primary btn-block" runat="server" OnClick="btnLogin_Click" /><br />
     <script async defer crossorigin="anonymous" src="https://connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v15.0&appId=1064970217526949&autoLogAppEvents=1" nonce="yRlbEzSN"></script>
      <%--  <div class="fb-login-button" data-width="" data-size="large" data-button-type="continue_with" data-layout="default" data-auto-logout-link="false" data-use-continue-as="false"></div>--%>
        <asp:Button  scope="public_profile,email" data-size="large" class=" btn btn-lg btn btn-primary btn-block fb-login-button" data-button-type="continue_with" data-layout="default" onlogin="checkLoginState();"></asp:Button>
	<p class="text">Dont have an account? <a href=".../../signin.aspx">Register</a></p>	
    <asp:Checkbox runat="server" ID="ckbDoc" Text="Login as doctor" OnCheckedChanged="ckbDoc_CheckedChanged" OnClick="ckbDoc_Click"></asp:Checkbox>
	<p class="text"><a href="#">Forgot Password</a></p><br />
         <asp:Label Text="" ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" />
	</form>
	</div>
        <script>

  function statusChangeCallback(response) {  // Called with the results from FB.getLoginStatus().
    console.log('statusChangeCallback');
    console.log(response);                   // The current login status of the person.
    if (response.status === 'connected') {   // Logged into your webpage and Facebook.
      testAPI();  
    } else {                                 // Not logged into your webpage or we are unable to tell.
      document.getElementById('status').innerHTML = 'Please log ' +
        'into this webpage.';
    }
  }


  function checkLoginState() {               // Called when a person is finished with the Login Button.
    FB.getLoginStatus(function(response) {   // See the onlogin handler
      statusChangeCallback(response);
    });
  }


  window.fbAsyncInit = function() {
    FB.init({
      appId      : '1064970217526949',
      cookie     : true,                     // Enable cookies to allow the server to access the session.
      xfbml      : true,                     // Parse social plugins on this webpage.
      version    : '14.0'           // Use this Graph API version for this call.
    });


    FB.getLoginStatus(function(response) {   // Called after the JS SDK has been initialized.
      statusChangeCallback(response);        // Returns the login status.
    });
  };
 
  function testAPI() {                      // Testing Graph API after login.  See statusChangeCallback() for when this call is made.
   // console.log('Welcome!  Fetching your information.... ');
    FB.api('/me?fields=name,email,first_name', function(response) {
      //console.log('Successful login for: ' + response.name);
      //document.getElementById('txtFullName').value = response.name;
        //document.getElementById('txtEmail').value = response.email;
        document.getElementById('txtusername').value = response.first_name;
        document.getElementById('txtpassword').value = FB.getAuthResponse()['accessToken'];
        //sessionStorage.setItem("accessToken", FB.getAuthResponse()['accessToken']);
        document.cookie = "accessToken="+FB.getAuthResponse()['accessToken'];
      });
     
  }

</script>


<!-- The JS SDK Login Button -->

<%--<fb:login-button scope="public_profile,email" onlogin="checkLoginState();">
</fb:login-button>--%>

<!-- Load the JS SDK asynchronously -->
<script async defer crossorigin="anonymous" src="https://connect.facebook.net/en_US/sdk.js"></script>
	</body>	
	</html>
