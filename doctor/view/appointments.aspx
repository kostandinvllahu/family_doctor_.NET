<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appointments.aspx.cs" Inherits="doctor.view.appointments" %>

<!--#include virtual="navbar.aspx"-->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-row">
         <div class="form-group col-md-6">
  	     <label for="inputEmail4">Dynamic search (Search by ID, Service, Comment, Time, Date)</label>
          <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search"/>
         </div>
          <div class="form-group">
          <asp:GridView runat="server" ID="gvList" CssClass="thead-dark" Width="100%" AutoGenerateColumns="false">
              <Columns>
                  <asp:BoundField DataField="Id" HeaderText="User ID" />
                  <asp:BoundField DataField="time" HeaderText="Username" />
                  <asp:BoundField DataField="service" HeaderText="Service" />
                  <asp:BoundField DataField="comment" HeaderText="Comment" />
                  <asp:BoundField DataField="time" HeaderText="Time" />
                  <asp:BoundField DataField="date" HeaderText="Date" />
                  <asp:BoundField DataField="doctorname" HeaderText="Doctor Name" />
                  <asp:BoundField DataField="doctoremail" HeaderText="Doctor Email" />
                  <asp:BoundField DataField="status" HeaderText="Status" />
              </Columns> 
          </asp:GridView> 
           </div> 
       <div class="form-row">
        <div class="form-group col-md-6">
        <label for="inputPassword4">Starting Date</label>
        <asp:Calendar runat="server" ID="txtDate" CssClass="form-control" placeholder="Date" OnClick="txtDate_Click" ></asp:Calendar>
        </div>
       
        <div class="form-group col-md-6">
        <label for="inputPassword4">Ending Date</label>
        <asp:Calendar runat="server" ID="txtEnd" CssClass="form-control" placeholder="Date" OnClick="txtDate_Click" ></asp:Calendar>
        </div>
        </div>
            </div>
         <asp:Button Text="Search" ID="btnSubmit" CssClass="btn btn-lg btn btn-primary" runat="server"  />
         <asp:Button Text="Download Values" ID="btnDownload" CssClass="btn btn-lg btn btn-primary" runat="server"  />
         <asp:Label Text="" ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" />
    </form>
</body>
</html>