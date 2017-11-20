<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bill.aspx.cs" Inherits="Bill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="css/home.css" type="text/css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
<script src="js/home.js"></script>
<script>
$(document).ready(function(){
    $("#tablebill").css({'margin-top':$(".sellerdiv").height()+'px'});
});
</script>
</head>
<body style="background-color:White ! important; background-image:none">
    <form id="form1" runat="server">
    <div class="head1">
    <a href="Home.aspx">
<img src="css/image/shoppie.png" alt="noImage" /></a>

</div>
<div runat="server" class="orddetails" id="orddetails">
</div>
<div class="billaddress">
<div runat="server" id="divseller" class="sellerdiv">
</div>
<div runat="server" id="divbuyer" class="buyerdiv">
</div>
<div runat="server" id="divlogistic" class="logisticdiv">
</div>
</div>
        <table class="billtable" runat="server" id="tablebill">
          <tr>
          <th>Description</th>
           <th>Product ID</th>
            <th>Qty</th>
             <th>Price</th>
          </tr>
        </table>
        <div runat="server" id="msg" class="msg">
    
    </div>  
    </form>
</body>
</html>
