<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyerProfile.aspx.cs" Inherits="BuyerProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="Stylesheet"  href="css/checkout.css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script src="js/home.js"></script>
    <script>
    $(document).ready(function(){
    click=0;
        $("#header").click(function(){
        if(parseInt(click)==0)
        {
            $(".ordertbl").css({'width':'100%'});
            $(".htbl").css({'display':'block','height':'auto','width':'100%','overflow':'auto'});
           $(".htbl").append($('.ordertbl'));
           $('.ordertbl').css({'margin-top':'50px'});
           $(".ordercontent").css({'height':'auto','max-width':'190px'});
          $("#header").css({'position':'fixed','margin-top':'-50px','width':'100%','z-index':'10'});
          click=1;
         }
         else
         {
           $(".divorder").append($('.ordertbl'));
           $('.ordertbl').css({'margin-top':'0'});
           $("#header").css({'position':'none','width':$(".divorder").width()+'px','z-index':'1'});
            $(".htbl").css({'display':'none'});
            click=0;
         }
        });
    });
    </script>
</head>
<body onload="msgbox()" style="overflow-x:hidden;">
    <form id="form1" runat="server">
<div class="head">
<a href="home.aspx"><img src="css/image/shoppie.png" alt="noImage" /></a>

    <div id="user" runat="server">
    </div>
     <div id="userlogin" runat="server">
     <div class="userbtn"> 
     <div class="triangle">.</div>
     <ul>
        <li><a href="BuyerProfile.aspx">Profile</a></li>
        <li><a href="ChangePassword.aspx?user=buyer">Password</a></li>
        <li><a href="Address.aspx?user=buyer">Addresss</a></li>
        <li><a href="Help.aspx?utype=buyer">help</a></li>
        <li><a id="A1" href="#" runat="server" onserverclick="logout_Click">Logout</a></li>
     </ul>
    </div> 
    </div>    
    
   </div>
   
       <div class="profile">
        <div class="photodiv">
            <div class="img" ID="Image1" runat="server">
            </div>
            <div class="addressdiv">
                <asp:Table CssClass="addresstbl" ID="addresstbl" runat="server">
                <asp:TableHeaderRow>
                <asp:TableHeaderCell  ColumnSpan="2" CssClass="tblhead" >Personal Info</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                </asp:Table>  
            </div>
        </div>
        
        <div class="contentdiv">
            <div class="divtotalpurchase"> 
            <div class="divheader">
                <asp:Image CssClass="img1" ID="Image3" runat="server" ImageUrl="~/css/image/icon/dispatch_order_icon.PNG" /><br />
                <asp:Label CssClass="headerlabel1" ID="Label1" runat="server" Text="Purchased"></asp:Label>
                </div> 
            <asp:Label class="cartitem" ID="Label5" runat="server" Text="Total Qty"></asp:Label>
           <asp:Label class="cartamount" ID="Label6" runat="server" Text="Total Amount"></asp:Label>       
           <asp:Label CssClass="itemnolabel" ID="lblpurchaseitemcount" runat="server" Text="0"></asp:Label>
           <asp:Label CssClass="amountlabel" ID="lblpurchaseamt" runat="server" Text="0"></asp:Label>         
            </div> 
            <a href="Cart.aspx"><div class="divcart">
            <div class="divheader">
                <asp:Image CssClass="img1" ID="Image2" runat="server" ImageUrl="~/css/image/icon/cart1-icon.PNG" /><br />
                <asp:Label CssClass="headerlabel2" ID="Label3" runat="server" Text="Cart"></asp:Label>
                </div> 
           <asp:Label  CssClass="cartitem" ID="Label9" runat="server" Text="Total Item"></asp:Label>
           <asp:Label  CssClass="cartamount" ID="Label10" runat="server" Text="Total Amount"></asp:Label>       
           <asp:Label CssClass="itemnolabel" ID="lblitemcount" runat="server" Text="0"></asp:Label>
           <asp:Label CssClass="amountlabel" ID="lblamt" runat="server" Text="0"></asp:Label>         
            </div></a>
        <div class="divorder">
         <asp:Table CssClass="ordertbl"  ID="ordertbl" runat="server">
                <asp:TableHeaderRow >
                <asp:TableHeaderCell ID="header" ColumnSpan="9" CssClass="tblhead" >Orders</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow ID="row">
                    <asp:TableCell  CssClass="tblhead">No.</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Order Date</asp:TableCell>
                    <asp:TableCell   CssClass="tblhead">Name</asp:TableCell>
                    <asp:TableCell  CssClass="tblhead">Total</asp:TableCell>
                    <asp:TableCell  CssClass="tblhead">Status</asp:TableCell>
                    <asp:TableCell  CssClass="tblhead">Pay</asp:TableCell>
                    <asp:TableCell  CssClass="tblhead">Invoice</asp:TableCell>
                    <asp:TableCell CssClass="tblhead">Cancel/Return</asp:TableCell>
                     <asp:TableCell CssClass="tblhead">Track</asp:TableCell>
                </asp:TableRow>
                </asp:Table> 
        </div>
        </div>       
        <div class="divfooter">
            <a href="Home.aspx"><div class="homeicon"></div></a>
            <a href="Help.aspx?utype=buyer"><div class="helpicon"></div></a>
            <a href="About.aspx"><div class="abouticon"></div></a>
        </div>
       </div>
     <div runat="server" id="msg" class="msg">
    
    </div>  
    <div class="htbl"></div>
    </form>
</body>
</html>
