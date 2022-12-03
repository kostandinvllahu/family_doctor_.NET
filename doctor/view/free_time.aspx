<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="free_time.aspx.cs" Inherits="doctor.view.free_time" %>
<!--#include virtual="navbar.aspx"-->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-row">
          <div class="form-group ">
          <asp:GridView runat="server" ID="gvList" CssClass="thead-dark" Width="100%" AutoGenerateColumns="false">
              <Columns>
                  <asp:BoundField DataField="Id" HeaderText="User ID" />
                  <asp:BoundField DataField="patientname" HeaderText="Username" />
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

         <div class="form-group col-md-6">
         <label for="inputPassword4">Filter</label>
       <asp:DropDownList runat="server" ID="selectService" CssClass="form-control" AppendDataBoundItems="true">
           <asp:ListItem Enabled="true" Text= "Blood Analysis" Value= "1"></asp:ListItem>
           <asp:ListItem Enabled="true" Text= "Stress Test" Value= "2"></asp:ListItem>
           <asp:ListItem Enabled="true" Text= "Tension Holter" Value= "3"></asp:ListItem>
           <asp:ListItem Enabled="true" Text= "Rythm Holter" Value= "4"></asp:ListItem>
           <asp:ListItem Enabled="true" Text= "Testicular Echo" Value= "5"></asp:ListItem>
           <asp:ListItem Enabled="true" Text= "Breast Echography" Value= "6"></asp:ListItem>
        </asp:DropDownList>
           </div>
            <!--class="thead-dark"-->
        </div>
    </form>
</body>
</html>
