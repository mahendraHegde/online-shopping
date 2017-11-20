<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="product_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" href="css/home.css" />
    <script language="javascript" type="text/javascript" src="js/home.js">
</script>
<script src="js/jquery.js"></script>
<script src="js/home.js"></script>
</head>
<body onload="msgbox()" style="background-size:1000% 100%">
    <form id="form1" runat="server">
    <div class="head">
    <a runat='server' id='homelink' href='Home.aspx'>
<img src="css/image/shoppie.png" alt="noImage" /></a>
<a href="LogisticDash.aspx"> <div class="logistic"> </div></a>
<a href="SellerDash.aspx"><div class="seller"> </div></a>
<div class="search">
    <asp:DropDownList CssClass="ddbox" ID="ddcatlist" runat="server"  DataTextField="cat_name" DataValueField="cat_name" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>All</asp:ListItem>
    </asp:DropDownList>
 <asp:TextBox CssClass="searchtxt" ID="txtsearch" runat="server" placeholder="Search Here"></asp:TextBox>
    <asp:ImageButton CssClass="searchbtn" ID="btnsearch" runat="server" ImageUrl="css/image/icon/search-icon.ico" OnClick="btnsearch_click" />
    </div>
    <div id="user" runat="server">
     <div class="userbtn" > 
     <div id="triangle" class="triangle">.</div>
     <ul>
        <li id="loginli"><a href="UserLogReg.aspx?val=login">Login</a></li>
        <li id="regli"><a href="UserLogReg.aspx?val=register">Register</a></li>
     </ul>
     </div>
    </div>
     <div id="userlogin" runat="server">
     <div class="userbtn"> 
     <div class="triangle">.</div>
     <ul>
        <li><a href="BuyerProfile.aspx">Profile</a></li>
        <li><a href="ChangePassword.aspx?user=buyer">Password</a></li>
        <li><a href="Address.aspx?user=buyer">Addresss</a></li>
        <li><a href="#">help</a></li>
        <li><a id="A1" runat="server" href="#" onserverclick="logout_Click">Logout</a></li>
     </ul>
    </div> 
    </div>    
    
   <div id="cartbtn" class="cartbtn">
   <div class="triangle1">.</div>
   <div class="cartlist">
       <div class="cartlisthead">
           <asp:Label class="cartitem" ID="Label36" runat="server" Text="Items"></asp:Label>
           <asp:Label class="cartamount" ID="Label37" runat="server" Text="Amount"></asp:Label>       
       </div>
       <asp:Label CssClass="itemnolabel" ID="lblitemcount" runat="server" Text="36"></asp:Label>
       <asp:Label CssClass="amountlabel" ID="lblamt" runat="server" Text="$3535"></asp:Label>
       <hr />
       <asp:LinkButton CssClass="viewcartbtn" ID="LinkButton1" PostBackUrl="~/Cart.aspx" runat="server">View Cart</asp:LinkButton>
       <asp:Button CssClass="checkbtn" ID="Button1" runat="server" Text="CheckOut" OnClick="checkout_Click"/>
   </div>
   </div>
   </div>
        
    <div class="sort">
    <asp:DropDownList AutoPostBack="true" CssClass="sortddl" ID="ddsort" runat="server" OnSelectedIndexChanged="ddsort_SelectedIndexChanged">
        <asp:ListItem>Sort</asp:ListItem>
        <asp:ListItem>Price Low to High</asp:ListItem>
        <asp:ListItem>Price High to Low</asp:ListItem>
        <asp:ListItem>Popular</asp:ListItem>
        <asp:ListItem>New</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList CssClass="sortddl" ID="ddcolor" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddcolor_SelectedIndexChanged">
                 <asp:ListItem>Color</asp:ListItem>
        </asp:DropDownList>  
    </div>
    
    <div runat="server" id="listcontent" class="listcontent">
         
    </div>
    
    <div runat="server" id="pagerdiv" class="footer">
    
    </div>
    <div runat="server" id="msg" class="msg">
    
    </div>
    </form>
</body>
</html>
