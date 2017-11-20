<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginAdmin.aspx.cs" Inherits="SellerLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link rel="stylesheet" href="css/home.css" />
<link rel="stylesheet" href="css/login.css" />
<script src="js/jquery.js"></script>
<script src="js/home.js"></script>
    <title>Login</title>
</head>
<body onload="msgbox()" style="font-size: 12pt" background="css/image/bg.png">
    <form id="form1" runat="server">
    <div class="head1">
    <a href="Home.aspx"><img src='css/image/shoppie.png' alt="noImage" /> </a>   
    </div>
       <div class="login">
       <div class="wrapper">
       <h1> Login Form </h1>
       </div>
       
       <div class="idpswd">
           <asp:TextBox required CssClass="usertxt" ID="txtadminid" runat="server" placeholder="User-ID"></asp:TextBox>
           <div class="user-icon"></div>
           <asp:TextBox required  CssClass="pswdtxt"  ID="txtadminpswd" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
           <div class="pass-icon"></div>
           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
           &nbsp; &nbsp;<br/><asp:LinkButton CssClass="forgotbtn" ID="LinkButton1" runat="server" ForeColor="white"></asp:LinkButton></div>
       <div>
           &nbsp;</div>
       
       <div class="btns">
           <asp:Button CssClass="loginbtn" ID="btnadminlogin" runat="server" Text="Login" OnClick="btnadminlogin_Click" />
       </div>
           
       </div>
    <div runat="server" id="msg" class="msg">
    
    </div>
    </form>
</body>
</html>
