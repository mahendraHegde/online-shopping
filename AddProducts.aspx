<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddProducts.aspx.cs" Inherits="SellerLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link rel="stylesheet" href="css/home.css" />
<link rel="stylesheet" href="css/addproduct.css" />
<script src="js/jquery.js"></script>
<script src="js/home.js"></script>
    <title>Add Products</title>
    
</head>
<body style="font-size: 12pt" bgcolor="gainsboro" onload="msgbox()">
    <form id="form1" runat="server">
    <div class="head1">
   <a href="home.aspx"> <img src='css/image/shoppie.png' alt="noImage" />  </a>  
    </div>
       <div id="addproduct" class="addproduct">
  
       <div class="productwrapper">
       <h1 runat="server" id="header"> Add a Product </h1>
       </div>
       
       <div class="content">
           <asp:Table ID="Table1" CssClass="addprdtbl" runat="server">
          <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label1" runat="server" Text="Name :"></asp:Label> </asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"> <asp:TextBox  CssClass="addtxt" ID="txtprodname" runat="server"></asp:TextBox></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"> <asp:Label CssClass="addlabel" ID="Label2" runat="server" Text="Category :"></asp:Label></asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"><asp:DropDownList CssClass="ddl" ID="ddcat" runat="server" DataTextField="cat_name" DataValueField="cat_name"></asp:DropDownList> </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"> <asp:Label CssClass="addlabel" ID="Label12" runat="server" Text="Keyword :"></asp:Label></asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"><asp:TextBox required CssClass="addtxt" ID="txtkey" runat="server" placeholder="eg:Mobile/Laptop/TV/etc"></asp:TextBox> </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"> <asp:Label CssClass="addlabel" ID="Label3" runat="server" Text="Quantity :"></asp:Label></asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"> <asp:TextBox required CssClass="addtxt" ID="txtqty" runat="server"></asp:TextBox></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"> <asp:Label CssClass="addlabel" ID="Label4" runat="server" Text="Price :"></asp:Label></asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"><asp:TextBox required CssClass="addtxt"  ID="txtprice" runat="server"></asp:TextBox> </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label5" runat="server" Text="Brand :"></asp:Label> </asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"> <asp:TextBox required CssClass="addtxt" ID="txtbrand" runat="server"></asp:TextBox></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"> <asp:Label CssClass="addlabel" ID="Label6" runat="server" Text="Color :"></asp:Label></asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"><asp:TextBox required CssClass="addtxt"  ID="txtcolor" runat="server"></asp:TextBox> </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label7" runat="server" Text="Weight :"></asp:Label> </asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"> <asp:TextBox required CssClass="addtxt" placeholder="In Grams"  ID="txtweight" runat="server"></asp:TextBox></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label8" runat="server" Text="Description:"></asp:Label> </asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"><asp:TextBox required CssClass="multitxt"  ID="txtdescription" runat="server" TextMode="MultiLine" Columns="40" Rows="20"></asp:TextBox> </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"> <asp:Label CssClass="addlabel" ID="Label9" runat="server" Text="Image-1 :"></asp:Label></asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"> <asp:FileUpload CssClass="imgload" ID="img1" runat="server" /></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label10" runat="server" Text="Image-2 :"></asp:Label> </asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"><asp:FileUpload CssClass="imgload" ID="img2" runat="server" /> </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow CssClass="addprdrow">
           <asp:TableCell CssClass="addprdcell"><asp:Label CssClass="addlabel" ID="Label11" runat="server" Text="Image-3 :"></asp:Label> </asp:TableCell>
           <asp:TableCell CssClass="addprdcell1"> <asp:FileUpload  CssClass="imgload" ID="img3" runat="server" /></asp:TableCell>
           </asp:TableRow>
           </asp:Table>
       </div>    
       <div class="productfooter">
           <asp:Button CssClass="addbtn" ID="btnadd" runat="server" Text="ADD"  OnClick="btnadd_Click" />
       </div>
        
       </div>
        <div runat="server" id="msg" class="msg">
    
    </div>  
    </form>
</body>
</html>
