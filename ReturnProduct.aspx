<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnProduct.aspx.cs" Inherits="ReturnProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="Stylesheet"  href="css/home.css" />
    <script src="js/jquery.js"></script>
<script src="js/home.js"></script>
</head>
<body onload="msgbox()" style=" background:#fff;">
    <form id="form1" runat="server">
 <div class="head1">
<a href="Home.aspx"><img src="css/image/shoppie.png" alt="noImage" /></a>
</div>
<div runat="server" class="returndiv" id="returndiv">
    
</div>
<div class="reasondiv" >
    <asp:DropDownList CssClass="reasonddl" AutoPostBack="true" ID="ddlreason" runat="server">
        <asp:ListItem>Damaged</asp:ListItem>
        <asp:ListItem>Not Working</asp:ListItem>
        <asp:ListItem>Incorrect Product</asp:ListItem>
        <asp:ListItem>Other(Please Mention)</asp:ListItem>
    </asp:DropDownList><br /><br />
    <asp:TextBox CssClass="reasontxt" ID="txtreason" runat="server" TextMode="MultiLine" CausesValidation="True" Columns="20" Rows="20"></asp:TextBox><br /><br />
    <asp:Button CssClass="reasonbtn" ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
    
</div>
<div class="footer" style="margin-top:1%;">
    <a href="Home.aspx"><div class="homeicon"></div></a>
    <a href="Help.aspx?utype=buyer"><div class="helpicon"></div></a>
    <a href="About.aspx"><div class="abouticon"></div></a>
</div>
<div runat="server" id="msg" class="msg">
    
    </div>
    </form>
</body>
</html>
