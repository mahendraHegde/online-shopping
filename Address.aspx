<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Address.aspx.cs" Inherits="SellerLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link rel="stylesheet" href="css/home.css" />
<link rel="stylesheet" href="css/addproduct.css" />
<script src="js/jquery.js"></script>
<script src="js/home.js"></script>
    <title>Address</title>
    
</head>
<body onload="msgbox()" style="font-size: 12pt" bgcolor="gainsboro">
    <form id="form1" runat="server">
    <div class="head1">
    <a href="home.aspx"><img src='css/image/shoppie.png' alt="noImage" />   </a> 
    </div>
       <div class="address">
  
       <div class="addresswrapper">
       <h1><asp:Label ID="lblname" runat="server" Text=""></asp:Label> </h1>
       </div>
       
       <div class="addresscontent">
            <asp:Table ID="Table1" CssClass="addprdtbl" runat="server">
              <asp:TableRow CssClass="addprdrow">
                 <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label8" runat="server" Text="Address :"></asp:Label></asp:Label> </asp:TableCell>
                 <asp:TableCell CssClass="addprdcell1"><asp:TextBox required CssClass="multitxt"  ID="txtaddress" runat="server" TextMode="MultiLine" AutoPostBack="True" ></asp:TextBox></asp:TableCell>
              </asp:TableRow>
              <asp:TableRow CssClass="addprdrow">
                 <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label5" runat="server" Text="Contact No :"></asp:Label></asp:TableCell>
                 <asp:TableCell CssClass="addprdcell1"><asp:TextBox required CssClass="addtxt" MaxLength="10" ID="txtcontact" runat="server" AutoPostBack="True"></asp:TextBox></asp:TableCell>
              </asp:TableRow>
              <asp:TableRow CssClass="addprdrow">
                 <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label2" runat="server" Text="Pin :"></asp:Label></asp:TableCell>
                 <asp:TableCell CssClass="addprdcell1"><asp:TextBox required CssClass="addtxt" ID="txtpin" OnTextChanged="txtpin_TextChanged" runat="server" AutoPostBack="True"></asp:TextBox></asp:TableCell>
              </asp:TableRow>
              <asp:TableRow CssClass="addprdrow">
                 <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label1" runat="server" Text="City :"></asp:Label></asp:TableCell>
                 <asp:TableCell CssClass="addprdcell1"><asp:TextBox required CssClass="addtxt" ID="txtcity" runat="server" AutoPostBack="True"></asp:TextBox></asp:TableCell>
              </asp:TableRow>
              <asp:TableRow CssClass="addprdrow">
                 <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label3" runat="server" Text="State :"></asp:Label></asp:TableCell>
                 <asp:TableCell CssClass="addprdcell1"><asp:TextBox required CssClass="addtxt" ID="txtstate" runat="server" AutoPostBack="True"></asp:TextBox></asp:TableCell>
              </asp:TableRow>
              <asp:TableRow CssClass="addprdrow">
                 <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label4" runat="server" Text="Country :"></asp:Label></asp:TableCell>
                 <asp:TableCell CssClass="addprdcell1"><asp:TextBox required CssClass="addtxt" ID="txtcountry" runat="server" AutoPostBack="True"></asp:TextBox></asp:TableCell>
              </asp:TableRow>
           </asp:Table>                 
       </div>       
       <div class="addressfooter">
           <asp:Button CssClass="addbtn1" ID="btnadd" runat="server" Text="ADD" OnClick="btnadd_Click"  />
       </div>
           
       </div>
       <div runat="server" id="msg" class="msg">
    
    </div> 
    </form>
</body>
</html>
