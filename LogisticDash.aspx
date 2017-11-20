<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogisticDash.aspx.cs" Inherits="LogisticDash" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" href="css/dash.css" />
     <script type="text/javascript" src="js/canvasjs/canvasjs.min.js"></script>
     <script type="text/javascript" src="js/jquery.js"></script>
   <script type="text/javascript" src="js/dash.js"> </script>
   <script src="js/home.js"></script>
</head>
<body onload="msgbox()">
    <form id="form1" runat="server">
    <div class="head">
        <a href="home.aspx"><img  src="css/image/shoppie.png" alt="noImage" /></a>
        <div class="changediv">
        <a href="changePassword.aspx?user=logistic"><div class="changepswddiv">
        </div></a>
        <asp:Label ID="Label2" runat="server" CssClass="changepswdlbl" Text="Change Password"></asp:Label> 
        </div>
    </div>
    <div class="leftbar">
    <div class="sellernamediv">
            <div class="logimg"></div>
            <asp:Label CssClass="sellernamelbl" ID="lblname" runat="server" Text=""></asp:Label>
            <asp:Label CssClass="onlinelbl" ID="Label15" runat="server" Text="Online"></asp:Label>
        </div>
    <div class="nav">
    <ul runat="server" class="catul" id="catul">
    <a id="adashboard" runat="server" href="#" onserverclick="adashboard_Click" >
    <li id="lidash" runat="server"><img src="css/image/icon/dash-icon.png" class="icon"></img><label>Dashboard</label></li></a>
    <a id="atasks" runat="server" href="#" onserverclick="atasks_Click">
    <li id="liproducts" runat="server"><img  src="css/image/icon/task-icon.png" class="icon1"></img><label>Tasks</label></li></a>
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
    <a runat="server" onserverclick="logout_Click"><div class="sellerlabeldiv1">
            <div class="logimg1"></div>
            <asp:Label CssClass="sellernamelbl" ID="lblname1" runat="server" Text=""></asp:Label>
            <asp:Label CssClass="logoutlbl" ID="Label1" runat="server" Text="Logout"></asp:Label>
    </div> </a> 
    </div>
    <div runat="server" id="divdash" class="dash">
    <div class="divbnts">
     <a id="A1" runat="server" onserverclick="imgorder_Click">
     <img src="css/image/icon/order-icon.png" class="img" />
     <asp:TextBox  CssClass="txtnot" Enabled="false" ID="txtordnot" runat="server"></asp:TextBox>
     <asp:Label CssClass="orderlbl" ID="Label4" runat="server" Text="Orders"></asp:Label>
     </a>
        <a id="A2" runat="server" onserverclick="imgreturn_ServerClick"><img src="css/image/icon/return-icon.png" class="img1" />
        <asp:TextBox   CssClass="txtnot1" Enabled="false" ID="txtretnot" runat="server"></asp:TextBox>
        <asp:Label CssClass="returnlbl" ID="Label5" runat="server" Text="Returns"></asp:Label>
        </a>
        </div>
    <div id="divcharts" runat="server"  class="divcharts">
                
     </div>
     <div class="tbls" id="divtbls" runat="server">
        <asp:Table CssClass="ordertbl" ID="ordertbl" runat="server">
                <asp:TableHeaderRow>
                <asp:TableHeaderCell  ColumnSpan="8" CssClass="tblhead" >Orders</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tblhead">Number</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Order Date</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Name</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Total</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Order Status</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Product_Id</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Qty</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Invoice</asp:TableCell>
                </asp:TableRow>
                </asp:Table>  
                <asp:Table CssClass="ordertbl" ID="tblret" runat="server">
                <asp:TableHeaderRow>
                <asp:TableHeaderCell   ColumnSpan="8" CssClass="tblhead" >Returns</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tblhead">Number</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Date</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Name</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Total</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Order Status</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Qty</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Product_Id</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Invoice</asp:TableCell>
                </asp:TableRow>
                </asp:Table> 
          </div>
                <div runat="server" id="divtasks" class="divtasks">
                <asp:Table CssClass="ordertbl" ID="tbltaskorder" runat="server">
                <asp:TableHeaderRow>
                <asp:TableHeaderCell  ColumnSpan="9" CssClass="tblhead" >Orders</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tblhead">Number</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Date</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Name</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Total</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Order Status</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Product_Id</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Qty</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Invoice</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">CheckPoint</asp:TableCell>
                </asp:TableRow>
                </asp:Table> 
                <br/>
                <br/>
                <asp:Table CssClass="ordertbl" ID="tbltaskreturn" runat="server">
                <asp:TableHeaderRow>
                <asp:TableHeaderCell   ColumnSpan="9" CssClass="tblhead" >Returns</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tblhead">Number</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Date</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Name</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Total</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Order Status</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Qty</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Product_Id</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Invoice</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">CheckPoint</asp:TableCell>
                </asp:TableRow>
                </asp:Table> 
                </div>
    </div>
    <div class="footer">
    <a href="Home.aspx"><div class="homeicon"></div></a>
    <a href="Help.aspx?utype=logistic"><div class="helpicon"></div></a>
    <a href="About.aspx"><div class="abouticon"></div></a>
    </div>
    <div runat="server" id="msg" class="msg">
    
    </div>
    </form>
</body>

</html>
