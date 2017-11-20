<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellerDash.aspx.cs" Inherits="sellerDash" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" href="css/dash.css" />
     <script type="text/javascript" src="js/canvasjs/canvasjs.min.js"></script>
     <script type="text/javascript" src="js/jquery.js"></script>
   <script type="text/javascript" src="js/dash.js"></script>
   <script src="js/home.js"></script>
</head>
<body onload="msgbox()">
    <form id="form1" runat="server">
    <div class="head">
        <a href="home.aspx"><img class="shoppieimg" src="css/image/shoppie.png" alt="noImage" /></a>
        <div class="changediv">
        <a href="changePassword.aspx?user=seller"><div class="changepswddiv">
        </div></a>
        <asp:Label ID="Label6" runat="server" CssClass="changepswdlbl" Text="Change Password"></asp:Label> 
        </div>
    </div>
    <div class="leftbar" id="divleftbar" runat="server">
    <div class="sellernamediv">
            <div class="sellerimg"></div>
            <asp:Label CssClass="sellernamelbl" ID="lblname" runat="server" Text=""></asp:Label><br /><br />
            <asp:Label CssClass="onlinelbl" ID="Label15" runat="server" Text="Online"></asp:Label>
        </div>
    <div class="nav">
    <ul runat="server" class="catul" id="catul">
    <a id="adashboard" runat="server" href="#" onserverclick="adashboard_Click">
    <li id="lidash" runat="server"><img src="css/image/icon/dash-icon.png" class="icon"></img><label>Dashboard</label></li></a>
    <a id="aproducts" runat="server" href="#" onserverclick="aproducts_Click">
    <li id="liproducts" runat="server"><img  src="css/image/icon/product-icon.png" class="icon1"></img><label>Products</label></li></a>
    </ul>
    </div>
    <div class="addressdiv">
                <asp:Table CssClass="addresstbl" ID="addresstbl" runat="server">
                <asp:TableHeaderRow>
                <asp:TableHeaderCell  ColumnSpan="2" CssClass="tblhead" >Personal Info</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                </asp:Table>  
            </div>
    </div>
    <div class="panel">
   <a runat="server" onserverclick="logout_Click"> <div class="sellerlabeldiv1">
            <div class="sellerimg1"></div>
            <asp:Label CssClass="sellernamelbl" ID="lblname1" runat="server" Text=""></asp:Label>
            <asp:Label CssClass="logoutlbl" ID="Label1" runat="server" Text="Logout"></asp:Label>
        </div> </a>
         </div>
    <div runat="server" id="divdash" class="dash">
    <div class="divbnts">
     <a id="A1" runat="server" onserverclick="imgorder_Click">
     <img src="css/image/icon/order-icon.png" class="img" />
     <asp:TextBox CssClass="txtnot" Enabled="false" ID="txtordnot" runat="server"></asp:TextBox>
     <asp:Label CssClass="orderlbl" ID="Label4" runat="server" Text="Orders"></asp:Label>
     </a>
        <a runat="server" onserverclick="imgreturn_ServerClick"><img src="css/image/icon/return-icon.png" class="img1" />
        <asp:TextBox CssClass="txtnot1" Enabled="false" ID="txtretnot" runat="server"></asp:TextBox>
        <asp:Label CssClass="returnlbl" ID="Label5" runat="server" Text="Returns"></asp:Label>
        </a>
        </div>
        <div class="tbls" id="divtbls" runat="server">
        <asp:Table CssClass="ordertbl" ID="ordertbl" runat="server">
                <asp:TableHeaderRow>
                <asp:TableHeaderCell  ColumnSpan="8" CssClass="tblhead" >Orders</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tblhead">No.</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Order Date</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Name</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Total</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Order Status</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Payment</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Qty</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Invoice</asp:TableCell>
                </asp:TableRow>
                </asp:Table>  
                
                 <asp:Table CssClass="ordertbl" ID="tblret" runat="server">
                <asp:TableHeaderRow>
                <asp:TableHeaderCell  ColumnSpan="6" CssClass="tblhead" >Returns</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tblhead">No.</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Reurn Date</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Name</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Total</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Return Status</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Description</asp:TableCell>
                </asp:TableRow>
                </asp:Table> 
                </div>
                <div id="divcharts" runat="server"  class="divcharts">
                
                </div>
    </div>
    <div id="divproducts" class="divproducts"  runat="server">
    <div class="divbnts">
    
    <a id="A2" onserverclick="imgadd_Click" runat="server">
     <img src="css/image/icon/add-product-icon.png" class="imgadd" />
     <asp:Label CssClass="addlbl" ID="Label2" runat="server" Text="Add a Product"></asp:Label></a>   
      <a id="A3" runat="server" onserverclick="imgupdateprdct_Click">
      
     <img src="css/image/icon/update-icon.ico" class="imgupdate" />
     <asp:Label CssClass="updatelbl" ID="Label3" runat="server" Text="Update/Delete a Product"></asp:Label> </a>     
        </div>
        <div id="productcontent" runat="server" class="productcontent">
        
                 <asp:Table CssClass="ordertbl" ID="tblproducts" runat="server">
                <asp:TableHeaderRow>
                <asp:TableHeaderCell  ColumnSpan="11" CssClass="tblhead" >Your Products</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                 <asp:TableCell CssClass="tblhead">No.</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Name</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Category</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Brand</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Price</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Qty</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Color</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Weight</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Description</asp:TableCell>
                     <asp:TableCell CssClass="tblhead">Update</asp:TableCell>
                      <asp:TableCell CssClass="tblhead">Delete</asp:TableCell>
                </asp:TableRow>
                </asp:Table> 
        </div> 
    </div>
    <div class="footer">
    <a href="Home.aspx"><div class="homeicon"></div></a>
    <a href="Help.aspx?utype=seller"><div class="helpicon"></div></a>
    <a href="About.aspx"><div class="abouticon"></div></a>
    </div>
    <div runat="server" id="msg" class="msg">
    
    </div>
    </form>
</body>
</html>
