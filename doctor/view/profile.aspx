<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="doctor.view.profile" %>
<!--#include virtual="navbar.aspx"-->
<title>Users Profile</title>
<form method="post" runat="server">
  <div class="form-row">
  <div class="form-group col-md-6">
  	<label for="inputEmail4">Full Name</label>
      <input type="text" class="form-control" id="inputEmail4" name="fullname" placeholder="Full Name" required value="">
  </div>
   <div class="form-group col-md-6">
  	<label for="inputPassword4">ID Card Number</label>
      <input type="text" class="form-control" id="inputPassword4" name="idcard" placeholder="ID Card Number" required value="">
  </div>
    <div class="form-group col-md-6">	
      <label for="inputEmail4">Email</label>
      <input type="email" class="form-control" id="inputEmail4" name="email" placeholder="Email" required value="">
    </div>
    <div class="form-group col-md-6">
      <label for="inputPassword4">Password</label>
      <input type="password" class="form-control" id="inputPassword4" name="password" placeholder="Password" required value="">
    </div>
  </div>
  <div class="form-group">
    <label for="inputAddress">Address</label>
    <input type="text" class="form-control" id="inputAddress" name="address" placeholder="1234 Main St" required value="">
  </div>
  <div class="form-group">
    <label for="inputAddress">Phone Number</label>
    <input type="tel" class="form-control" id="inputAddress" name="phone" placeholder="0697830800" required value="">
  </div>
  <div class="form-group">
    <label for="inputAddress2">Address 2</label>
    <input type="text" class="form-control" id="inputAddress2" name="addresstwo" placeholder="Apartment, studio, or floor" required value="">
  </div>
  <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputCity">City</label>
      <input type="text" class="form-control" id="inputCity" name="city" required value="">
    </div>
    <div class="form-group col-md-4">
      <label for="inputState">State</label>
      <select id="inputState" class="form-control"required name="state">
	    <option value="none" selected disabled hidden>Select an Option</option>
        <option>Albania</option>
		<option>Bosnia</option>
		<option>Croatia</option>
		<option>Montenegro</option>
		<option>Serbia</option>
		<option>Slovenia</option>
		<option>Greece</option>
		<option>Macedonia</option>
      </select>
    </div>
    <div class="form-group col-md-2">
      <label for="inputZip">Zip</label>
      <input type="number" class="form-control" name="zip" id="inputZip" required value="">
    </div>
  </div>
  <button type="submit" name="profile" class="btn btn-primary">Save</button>
</form>