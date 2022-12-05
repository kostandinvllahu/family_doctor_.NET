<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="doctor.view.profile" %>
<!--#include virtual="navbar.aspx"-->
<title>Users Profile</title>
<link rel="stylesheet" href=".../../css/main.css">
<form method="post" runat="server">
  <div class="form-row">
  <div class="form-group col-md-6">
  	<label for="inputEmail4">Full Name</label>
      <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" placeholder="Full Name" required=""/>
  </div>
   <div class="form-group col-md-6">
  	<label for="inputPassword4">ID Card Number</label>
       <asp:TextBox runat="server" ID="txtIdCard" CssClass="form-control" placeholder="ID Card Number" required="" OnTextChanged="txtIdCard_TextChanged"/>
  </div>
    <div class="form-group col-md-6">	
      <label for="inputEmail4">Email</label>
        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Email" required=""/>
    </div>
    <div class="form-group col-md-6">
      <label for="inputPassword4">Password</label>
        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Password" />
    </div>
  </div>
  <div class="form-group">
    <label for="inputAddress">Address</label>
      <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" placeholder="1234 Main St" required=""/>
  </div>
  <div class="form-group">
    <label for="inputAddress">Phone Number</label>
      <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" placeholder="0697830800" required=""/>
  </div>
  <div class="form-group">
    <label for="inputAddress2">Address 2</label>
      <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control" placeholder="1234 Apartment, studio or floor"/>
  </div>
  <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputCity">City</label>
        <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" placeholder="Tirana" required=""/>
    </div>
    <div class="form-group col-md-4">
      <label for="inputState">State</label>
     <asp:TextBox runat="server" ID="txtState" CssClass="form-control" placeholder="Albania" required=""/>
    </div>
    <div class="form-group col-md-2">
      <label for="inputZip">Zip</label>
        <asp:TextBox runat="server" ID="txtZip" CssClass="form-control" placeholder="1060" required=""/>
    </div>
  </div>
     <asp:Button Text="Save" ID="btnSave" CssClass="btn btn-lg btn btn-primary" runat="server" OnClick="btnSave_Click" />
    <asp:Label Text="" ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" />
</form>