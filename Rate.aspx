<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rate.aspx.cs" Inherits="Rate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="Stylesheet"  href="css/checkout.css" />
    <script src="js/jquery.js"></script>
<script src="js/home.js"></script>
</head>
<body onload="msgbox()">
<form id="form1" runat="server">
<div class="head">
   <a href="Home.aspx"> <img src='css/image/shoppie.png' alt="noImage" />    </a>
    </div>
    <div class="productdiv" style="background:#fff";">
        <asp:Image CssClass="prodimg" ID="img" runat="server" /><br /><br /><br />
        <asp:Label CssClass="namelbl" ID="lblname" runat="server" Text="Label"></asp:Label>
    </div>
   	<div class="stars">
		<input type="radio"  name="star" class="star-1" runat="server" id="star1" />
		<label class="star-1"  for="star1" id="lbl1">1</label>
		<input type="radio" name="star" class="star-2" runat="server" id="star2" />
		<label class="star-2" for="star2">2</label>
		<input type="radio" name="star" class="star-3" runat="server" id="star3" />
		<label class="star-3" for="star3">3</label>
		<input type="radio" name="star" class="star-4" runat="server" id="star4" />
		<label class="star-4" for="star4">4</label>
		<input type="radio" name="star" class="star-5" runat="server" id="star5" />
		<label class="star-5" for="star5">5</label>
		<span></span>
	</div>
	<div class="reviewdiv">
    <asp:TextBox CssClass="reviewtxt" ID="txtreason" runat="server" TextMode="MultiLine" Columns="20" Rows="20"></asp:TextBox><br /><br />
    <asp:Button CssClass="reviewbtn" ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
    </div>
    <div runat="server" id="msg" class="msg">
    
    </div>
    </form>
</body>
</html>
