<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script type="text/javascript" src="js/jquery.js"></script>
<script language="javascript" type="text/javascript" src="js/home.js"></script>
<script type="text/javascript"></script>
<script>
$(document).ready(function(){
   var i=100;
   var cx=($(".imgzoom").offset().left+$(".imgzoom").width())/2;
   var cy=($(".imgzoom").offset().top+$(".imgzoom").height())/2;
    $(".viewimg1").mousemove(function(e){
       i=cy-((e.pageY)-$(".viewimg1").offset().top)*4;
       j=cx-((e.pageX)-$(".viewimg1").offset().left)*4;
       $(".imgzoom").css({'opacity':'1','width':$(".viewimg1").width()+'px'});
       $(".imgzoom").css("background-position",j+'px '+i+'px');
    });
      $(".viewimg1").mouseout(function(){
         $(".imgzoom").css({'opacity':'0'});
      });
});
</script>
<link rel="Stylesheet"  href="css/home.css" />
</head>
<body onload="msgbox()" style="background-size:500%">
    <form id="form1" runat="server">
    <div class="head">
    <a runat='server' id='homelink' href='Home.aspx'>
<img src="css/image/shoppie.png" alt="noImage" /></a>
<a href="LogisticDash.aspx"><div class="logistic">
</div></a>
<a href="SellerDash.aspx"><div class="seller">
</div></a>
<div class="search">
    <asp:DropDownList CssClass="ddbox" ID="ddcatlist" runat="server"  DataTextField="cat_name" DataValueField="cat_name" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
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
   <div class="viewpage">
    <div class="viewimage">
        <asp:Image CssClass="viewimg1" ID="img1" runat="server" />
        <asp:ImageButton  CssClass="viewimg2"  ID="img2" runat="server" OnClientClick="imgswitch(this);return false;" />
        <asp:ImageButton CssClass="viewimg3" ID="img3" runat="server"  OnClientClick="imgswitch(this);return false;" />
        <asp:ImageButton CssClass="viewimg4" ID="img4" runat="server"  OnClientClick="imgswitch(this);return false;" />
        <asp:Button CssClass="addcartbtn1" ID="btnaddcart" runat="server" Text="Add Cart"  OnClick="btnaddcart_Click" />
    </div>
    <div class="detail">
        <div class="prdviewdiv">
                <asp:Table CssClass="prdviewtbl" ID="prdviewtbl" runat="server">
                <asp:TableHeaderRow runat="server">
                <asp:TableHeaderCell  ColumnSpan="2" CssClass="tblhead" runat="server" >Product Details</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                </asp:Table>  
        </div>
    </div>
   
    </div>
    <div class="stars">
		<div></div>
	</div>
	<div class="expanddiv">
	Reviews
    <div class="divbtn">+</div>	
	</div>
	<div runat="server" id="reviewdiv" class="reviewdiv">
	
	</div>
	<div runat="server" id="msg" class="msg">
    
    </div>
    <div runat="server" id="imgzoom" class="imgzoom"></div>
    </form>
</body>
</html>
