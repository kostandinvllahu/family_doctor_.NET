<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="covid.aspx.cs" Inherits="doctor.view.covid" %>

 <!--#include virtual="navbar.aspx"-->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scaled=1">
<title>Check Up</title>
</head>

<form method="post" runat="server">
  <div class="form-row">
  <div class="form-group col-md-6">
  	<label for="inputEmail4">Doctor Name</label>
      <asp:TextBox runat="server" ID="txtDoctorName" CssClass="form-control" placeholder="Doctor Name"/>
  </div>
 <div class="form-group col-md-6">
  	<label for="inputPassword4">Time Schedule</label>
       <asp:DropDownList runat="server" ID="selectTime" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
  </div>
    <div class="form-group col-md-6">	
      <label for="inputEmail4">Email</label>
        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Email" required=""/>
    </div>
    
      <div class="form-group col-md-6">
  	<label for="inputPassword4">Covid-19 Vaccines</label>
       <asp:DropDownList runat="server" ID="selectService" CssClass="form-control" AppendDataBoundItems="true">
           <asp:ListItem Enabled="true" Text= "Pfizer" Value= "1"></asp:ListItem>
           <asp:ListItem Enabled="true" Text= "AstraZeneca" Value= "2"></asp:ListItem>
           <asp:ListItem Enabled="true" Text= "Sinopharm" Value= "3"></asp:ListItem>
           <asp:ListItem Enabled="true" Text= "Sinovac" Value= "4"></asp:ListItem>
           <asp:ListItem Enabled="true" Text= "Sputnik" Value= "5"></asp:ListItem>
       </asp:DropDownList>
  </div>

  <div class="form-group col-md-6">
    <label for="inputAddress">Comment</label>
      <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Rows="10" CssClass="form-control" placeholder="Tell us how do you feel today..." required=""/>
  </div>

      <div class="form-group col-md-6">
      <label for="inputPassword4">Date</label>
        <asp:Calendar runat="server" ID="txtDate" CssClass="form-control" placeholder="Date" OnClick="txtDate_Click" OnSelectionChanged="txtDate_SelectionChanged"></asp:Calendar>
    </div>
</div>
     <asp:Button Text="Save" ID="btnSubmit" CssClass="btn btn-lg btn btn-primary" runat="server" OnClick="btnSubmit_Click" />
    <asp:Label Text="" ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" />
</form>
</html>
