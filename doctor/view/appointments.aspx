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
  	     <h3>Dates that doctor is available</h3>
          
         </div>

            <div class="form-group col-md-6">
                </div>

             <div class="form-group col-md-6">
          <asp:GridView runat="server" ID="gvList" CssClass="thead-dark" Width="100%" AutoGenerateColumns="false">
              <Columns>
                  <asp:BoundField DataField="time" HeaderText="Time" />
                  <asp:BoundField DataField="doctor" HeaderText="Doctor Email" />
              </Columns> 
          </asp:GridView> 
          </div>


       <div class="form-group col-md-6">
        <label for="inputPassword4">Filter Date</label>
        <asp:Calendar runat="server" ID="txtDate" CssClass="form-control" placeholder="Date" OnClick="txtDate_Click" OnSelectionChanged="txtDate_SelectionChanged" ></asp:Calendar>
        </div>
            </div>
         <asp:Button Text="Search" ID="btnSubmit" CssClass="btn btn-lg btn btn-primary" runat="server" OnClick="btnSubmit_Click"  />
         <asp:Button Text="Download Values" ID="btnDownload" CssClass="btn btn-lg btn btn-primary" OnClick="btnDownload_Click" runat="server"  />
         <asp:Label Text="" ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" />
    </form>
</body>
</html>