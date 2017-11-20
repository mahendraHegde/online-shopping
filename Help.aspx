<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="Help" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Help</title>
    <link rel="Stylesheet"  href="css/home.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="head1">
<a href="home.aspx"><img src="css/image/shoppie.png" alt="noImage" /></a>    
   </div>
   <div class="headdiv">
        <div class="icon"></div>
       <asp:Label ID="lblname" CssClass="lblname" runat="server" Text="Admin"></asp:Label>
   </div>
    <div runat="server" id="chatdiv" class="chatdiv">
    

    </div>
    <div class="typediv">
        <asp:TextBox ID="txtText" CssClass ="texttxt" TextMode="MultiLine"  runat="server"></asp:TextBox>
        <asp:Button ID="btnsend" CssClass="sendbtn" runat="server" Text="" OnClick="btnsend_Click" />
    </div>
    </form>
</body>
</html>
