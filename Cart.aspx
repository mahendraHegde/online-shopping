<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
        <link rel="stylesheet" href="css/home.css" />
        <script src="js/jquery.js"></script>
<script src="js/home.js"></script>
</head>
<body onload="msgbox()" style=" background-size:1000% 100%">
    <form id="form1" style="height:auto" runat="server">
    <div class="head1">
        <a href="Home.aspx"><img src="css/image/shoppie.png" alt="noImage" /></a>
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
    <div runat="server" id="cartheaderdiv" class="cartheader">
<div style="position:absolute; top:100px; right:0px; height:15.5%;width:25%; background-image:url('css/image/background/cart.jpg');background-repeat:no-repeat;background-size:100% 100%;"></div>
    </div>
    <div runat="Server"  class="cartcontent" id="cartcontent">
    
    </div>
    <div class="footer">
        <a href="Home.aspx"><div class="homeicon"></div></a>
        <a href="Help.aspx?utype=buyer"><div class="helpicon"></div></a>
        <a href="About.aspx"><div class="abouticon"></div></a>
    </div>
    <div runat="server" id="msg" class="msg">
    
    </div>  
    </form>
</body>
</html>
