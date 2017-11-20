     <%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="SellerLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <script language="javascript" type="text/javascript" src="js/home.js">
    </script>
<link rel="stylesheet" href="css/home.css" />
<link rel="stylesheet" href="css/login.css" />
<script src="js/jquery.js"></script>
<script src="js/home.js"></script>
    <title>Change Password</title>
</head>
<body style="font-size: 12pt" onload="msgbox();" bgcolor="gainsboro">
    <form id="form1" runat="server">
    <div class="head1">
    <a href="home.aspx"><img src='css/image/shoppie.png' alt="noImage" />  </a>  
    </div>
       <div class="login">
  
       <div class="wrapper">
       <h1> Change Password </h1>
       </div>
       
       <div class="idpswd" style="text-align: center">
           <asp:Label ID="lblname" CssClass="lblname" runat="server" Text="" align="center"></asp:Label>
           <asp:TextBox required CssClass="pswdtxt" ID="txtold" runat="server" placeholder="Old Password" TextMode="Password"></asp:TextBox>
           <asp:TextBox required CssClass="pswdtxt" ID="txtpswd" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
           <asp:TextBox required CssClass="pswdtxt"  ID="txtconfirm" runat="server" placeholder=" Confirm Password" TextMode="Password"></asp:TextBox>
          
          </div>
       <div class="changebtns">
           <asp:Button CssClass="okbtn" ID="btnchange" runat="server" Text="Ok" Width="110px" OnClick="btnchange_Click" />         
       </div>
           
       </div>
        <div id="msg" class="msg">
    </div>
    </form>
</body>
</html>
