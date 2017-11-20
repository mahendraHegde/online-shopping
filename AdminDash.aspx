<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminDash.aspx.cs" Inherits="AdminDash" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" href="css/dash.css" />
   <script type="text/javascript" src="js/canvasjs/canvasjs.min.js"></script>
     <script type="text/javascript" src="js/jquery.js"></script>
   <script type="text/javascript" src="js/dash.js"></script>
     <script type="text/javascript" src="js/home.js"></script>
      <script>
   $(document).ready(function(){
        $(".panel1").click(function(){
            $(".htbl").css({'display':'block'});
           $("#horders").css({'display':'block'});
          $("#header").css({'position':'fixed','left':'5%','z-index':'10'});
          $("#hreturns").css({'display':'none'});
        });
        $(".closeicon").click(function(){
           $(".htbl").css({'display':'none'}); 
        });
        
        $(".panel2").click(function(){
            $(".htbl").css({'display':'block'});
            $("#horders").css({'display':'none'});
             $("#hreturns").css({'display':'block'});
          $("#header1").css({'position':'fixed','left':'5%','z-index':'10'});
        });
    });
    </script>
</head>
<body onload="msgbox()">
    <form id="form1" runat="server">
    <div runat="server" id="main">
    <div class="head">
        <a href="home.aspx"><img  src="css/image/shoppie.png" alt="noImage" /></a>
        <div class="changediv">
        <a href="changePassword.aspx?user=admin"><div class="changepswddiv">
        </div></a>
        <asp:Label ID="Label6" runat="server" CssClass="changepswdlbl" Text="Change Password"></asp:Label> 
        </div>
    </div>
    <div class="adminleftbar">
        <div class="adminnamediv">
            <div class="adminimg"></div>
            <asp:Label CssClass="adminnamelbl" ID="Label14" runat="server" Text="Admin"></asp:Label>
            <asp:Label CssClass="onlinelbl" ID="Label15" runat="server" Text="Online"></asp:Label>
        </div>
    <div class="adminnav">
    <ul runat="server"  class="admincatul" id="catul">
    <a id="adashboard"  runat="server"  onserverclick="dashboard_Click">
    <li id="lidash" runat="server"><label>Dash Board</label></li></a>
    <a id="aproducts" runat="server" onserverclick="products_Click">
    <li id="liproducts" runat="server"><label>Products</label></li></a>
    <a id="a1" runat="server" onserverclick="sellers_Click" href="#">
    <li id="liseller" runat="server"><label>Sellers</label></li></a>
    <a id="a2" runat="server" href="#" onserverclick="buyers_Click">
    <li id="libuyer" runat="server"><label>Buyers</label></li></a>
    <a id="a3" runat="server" href="#" onserverclick="logistics_Click">
    <li id="lilogistic" runat="server"><label>Logistics</label></li></a>
      <a id="a4" runat="server" href="#" onserverclick="payments_Click">
    <li id="lipayment" runat="server"><label>Payments</label></li></a>
    <a id="a6" runat="server" href="report.aspx">
    <li id="li1" runat="server"><label>Reports</label></li></a>
    </ul>
    </div>    
    </div>
   
    <div class="panel">
        <div class="adminlabeldiv">
            <asp:Label CssClass="adminlbl" ID="Label13" runat="server" Text="Admin"></asp:Label>
        </div>  
        <a id="A5" runat="server" onserverclick="logout_Click"><div class="adminlabeldiv1">
            <div class="adminimg1"></div>
            <asp:Label CssClass="adminnamelbl" ID="Label16" runat="server" Text="Admin"></asp:Label>
             <asp:Label CssClass="adminlogoutlbl" ID="Label1" runat="server" Text="Logout"></asp:Label>
        </div> </a> 
    </div>
    <div class="admindash">
    <div class="panel1">
        <asp:Label CssClass="largelbl" ID="lblorders" runat="server" Text="150"></asp:Label>
        <asp:Label CssClass="smalllbl" ID="Label2" runat="server" Text="Orders"></asp:Label>        
    </div>
    <div class="panel2">
        <asp:Label CssClass="largelbl" ID="lblreturns" runat="server" Text="150"></asp:Label>
        <asp:Label CssClass="smalllbl" ID="Label4" runat="server" Text="Returns"></asp:Label>      
    </div>
    <a runat="server" id="amsg" onserverclick="amsg_Click">
    <div class="panel3">
        <asp:Label CssClass="largelbl" ID="lblmsg" runat="server" Text="150"></asp:Label>
        <asp:Label CssClass="smalllbl" ID="lblmessage" runat="server" Text="Messages"></asp:Label>      
    </div></a>
    <div class="panel4">
        <asp:Label CssClass="largelbl" ID="lblmember" runat="server" Text="0"></asp:Label>
        <asp:Label CssClass="smalllbl" ID="lblnewmember" runat="server" Text="New Members"></asp:Label>      
    </div>
      <div  id="admindash" runat="server">
    <div id="ch4" class="salesdiv">
    
    </div>
    <div id="ch3" class="visitorsdiv">
    
    </div>
    <div class="latestorderdiv" id="divltest" runat="server">
        <asp:Label CssClass="smalllbl" ID="lblltest" runat="server" Text="Latest Order" ForeColor="Black"></asp:Label>
         <asp:TextBox ID="txtkeyword" runat="server" CssClass="searchtxt"></asp:TextBox>
         <asp:Button ID="btnsearch" runat="server" CssClass="searchbtn" Text="Search" OnClick="btnsearch_Click" />
         <br /><br />
        <hr />  
        <div class="latest" runat="server" id="divlatest">
        <asp:Table runat="server" ID="ordertbl" CssClass="latestordertbl">
        <asp:TableRow>
        <asp:TableCell CssClass="tblhead">Image</asp:TableCell>
        <asp:TableCell CssClass="tblhead">Order Id</asp:TableCell>
         <asp:TableCell CssClass="tblhead">Name</asp:TableCell>
         <asp:TableCell CssClass="tblhead">Price</asp:TableCell>
          <asp:TableCell CssClass="tblhead">Status</asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        </div>
        
        <div  runat="server" id="divmngprdcts" class="managediv">
        <asp:Table runat="server" ID="tblprdcts" CssClass="prdctstbl">
         <asp:TableRow>
          <asp:TableCell ID="product0" CssClass="tblhead">Image</asp:TableCell>
        <asp:TableCell ID="product1"  CssClass="tblhead" >Product Id</asp:TableCell>
         <asp:TableCell ID="product2" CssClass="tblhead" >Name</asp:TableCell>
         <asp:TableCell ID="product3" CssClass="tblhead" >Category</asp:TableCell>
          <asp:TableCell ID="product4" CssClass="tblhead" >Qty</asp:TableCell>
          <asp:TableCell ID="product5" CssClass="tblhead" >Price</asp:TableCell>
          <asp:TableCell ID="product6" CssClass="tblhead">Brand</asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        <asp:Table runat="server" CssClass="sellertbl" ID="tblseller">
         <asp:TableRow >
          <asp:TableCell ID="TableCell1" CssClass="tblhead">Id</asp:TableCell>
          <asp:TableCell ID="TableCell2"  CssClass="tblhead" >Name</asp:TableCell>
          <asp:TableCell ID="TableCell3" CssClass="tblhead" >E-mail</asp:TableCell>
          <asp:TableCell ID="TableCell4" CssClass="tblhead" >Contact</asp:TableCell>
          <asp:TableCell ID="TableCell5" CssClass="tblhead" >Country</asp:TableCell>
          <asp:TableCell ID="TableCell6" CssClass="tblhead" >State</asp:TableCell>
          <asp:TableCell ID="TableCell7" CssClass="tblhead">City</asp:TableCell>
          <asp:TableCell ID="TableCell8" CssClass="tblhead">Address</asp:TableCell>
         </asp:TableRow>
        </asp:Table>
        </div>
        
       <div runat="server" id="divmngproducts" class="mngproducts">
       
        </div>
    </div>
     <div class="recentproductdiv" id="divrecentproduct" runat="server">
        <asp:Label CssClass="smalllbl" ID="Label10" runat="server" Text="Recently Added Products" ForeColor="Black"></asp:Label>
       
         <br /><br />
        <hr/>    
        <div class="recent">
         <asp:Table ID="tblrecentorder" CssClass="recentordertbl" runat="server">
          <asp:TableRow>
          <asp:TableCell CssClass="tblhead">Image</asp:TableCell>
          <asp:TableCell CssClass="tblhead">Product ID</asp:TableCell>
          <asp:TableCell CssClass="tblhead">Name</asp:TableCell>
          <asp:TableCell CssClass="tblhead">Brand</asp:TableCell>
          <asp:TableCell CssClass="tblhead">Price</asp:TableCell>
          <asp:TableCell CssClass="tblhead">Quantity</asp:TableCell>
          </asp:TableRow>
         </asp:Table>   
         </div>     
         
    </div>
    </div>
    <div runat="server" id="paymentdiv">
    <br />
    <br />
    <br /><br />
    <br />
    <br /><br />
    <asp:Table ID="tblsellerpay" CssClass="recentordertbl" runat="server" Width="40%">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell CssClass="tblhead" ColumnSpan="2">Seller Payments</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
    <asp:TableCell CssClass="tblhead">Month</asp:TableCell>
    <asp:TableCell CssClass="tblhead">Year</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell ><asp:DropDownList AutoPostBack="true" CssClass="ddl" ID="ddmonth" OnSelectedIndexChanged="ddmonth_change" runat="server">
              </asp:DropDownList></asp:TableCell>
    <asp:TableCell ><asp:DropDownList AutoPostBack="true" CssClass="ddl" ID="ddyear" OnSelectedIndexChanged="ddyear_change" runat="server">
              </asp:DropDownList></asp:TableCell>
    </asp:TableRow>
          <asp:TableRow CssClass="tblcontent" >
          <asp:TableCell CssClass="tblhead">Seller_id</asp:TableCell>
          <asp:TableCell CssClass="ordercontent">
              <asp:DropDownList AutoPostBack="true" CssClass="ddl" ID="ddseller" OnSelectedIndexChanged="ddseller_change" runat="server">
              </asp:DropDownList></asp:TableCell>
          </asp:TableRow>
          <asp:TableRow>
          <asp:TableCell CssClass="tblhead">Name</asp:TableCell>
          <asp:TableCell ID="cellname" CssClass="tblcell"></asp:TableCell>
          </asp:TableRow>
          <asp:TableRow>
          <asp:TableCell CssClass="tblhead">Payment</asp:TableCell>
          <asp:TableCell ID="cellpay" CssClass="tblcell"></asp:TableCell>
          </asp:TableRow>
           <asp:TableRow>
          <asp:TableCell ColumnSpan="2">
              <asp:Button ID="btnpayseller" CssClass="paybtn" runat="server" Text="Pay Now" OnClick="btnpayseller_Click" /></asp:TableCell>
          </asp:TableRow>
         </asp:Table>   
         <br />
         <br />
         <asp:Table ID="tbllogisticpay" CssClass="recentordertbl" runat="server" Width="40%">
          <asp:TableHeaderRow>
        <asp:TableHeaderCell CssClass="tblhead" ColumnSpan="2">Logistic Payments</asp:TableHeaderCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
    <asp:TableCell CssClass="tblhead">Month</asp:TableCell>
    <asp:TableCell CssClass="tblhead">Year</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell ><asp:DropDownList AutoPostBack="true" CssClass="ddl" ID="ddmonth1" OnSelectedIndexChanged="ddmonth1_change" runat="server">
              </asp:DropDownList></asp:TableCell>
    <asp:TableCell ><asp:DropDownList AutoPostBack="true" CssClass="ddl" ID="ddyear1" OnSelectedIndexChanged="ddyear1_change" runat="server">
              </asp:DropDownList></asp:TableCell>
    </asp:TableRow>
          <asp:TableRow CssClass="tblcontent" >
          <asp:TableCell CssClass="tblhead">Logistic_id</asp:TableCell>
          <asp:TableCell CssClass="ordercontent">
              <asp:DropDownList AutoPostBack="true" CssClass="ddl" ID="ddlogistic" OnSelectedIndexChanged="ddlogistic_change" runat="server">
              </asp:DropDownList></asp:TableCell>
          </asp:TableRow>
          <asp:TableRow>
          <asp:TableCell CssClass="tblhead">Name</asp:TableCell>
          <asp:TableCell ID="cellname1" CssClass="tblcell"></asp:TableCell>
          </asp:TableRow>
          <asp:TableRow>
          <asp:TableCell CssClass="tblhead">Payment</asp:TableCell>
          <asp:TableCell ID="cellpay1" CssClass="tblcell"></asp:TableCell>
          </asp:TableRow>          
          <asp:TableRow>
          <asp:TableCell ColumnSpan="2">
              <asp:Button  ID="btnpaylog" CssClass="paybtn" runat="server" Text="Pay Now" OnClick="btnpaylog_Click" /></asp:TableCell>
          </asp:TableRow>
         </asp:Table>   
         <br />
         <br />
    </div>
    <div runat="server" id="messagediv" >
    <div runat="server" class="msgdiv" id="msgdiv"  >
    </div>
     <div class="headdiv" runat="server" id="headdiv">
     <div class="chaticon"></div>
       <asp:Label ID="lblname" CssClass="lblname" runat="server" Text="Label"></asp:Label>
       <asp:Label ID="lblname1" CssClass="lblname1" runat="server" Text="Label"></asp:Label>
   </div>
    <div runat="server" id="chatdiv" class="chatdiv">
    

    </div>
    <div class="typediv" runat="server" id="typediv">
        <asp:TextBox ID="txtText" CssClass ="texttxt" TextMode="MultiLine"  runat="server"></asp:TextBox>
        <asp:Button ID="btnsend" CssClass="sendbtn" runat="server" Text="" OnClick="btnsend_Click" />
    </div>
    </div>
    </div>
    <div class="footer1">
    </div>
    </div>
    <div class="msg" id="msg"></div>
    <div class="htbl" id="htbl" runat="server">
    <img class="closeicon" src="css/image/icon/close-icon.png" />
     <asp:Table CssClass="hordertbl" ID="horders"  runat="server" Width="40%">
          <asp:TableHeaderRow ID="header">
        <asp:TableHeaderCell CssClass="tblhead" ColumnSpan="6">Orders</asp:TableHeaderCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
         <asp:TableCell  CssClass="tblhead">Order Id
         </asp:TableCell>
          <asp:TableCell  CssClass="tblhead">Image
         </asp:TableCell>
          <asp:TableCell  CssClass="tblhead">Name
         </asp:TableCell>
          <asp:TableCell  CssClass="tblhead">Qty
         </asp:TableCell>
          <asp:TableCell  CssClass="tblhead">Total
         </asp:TableCell>
         <asp:TableCell  CssClass="tblhead">Bill
         </asp:TableCell>
         </asp:TableRow>
         </asp:Table>
         
         <asp:Table CssClass="recentordertbl" ID="hreturns"  runat="server" Width="40%">
          <asp:TableHeaderRow ID="header1">
        <asp:TableHeaderCell CssClass="tblhead" ColumnSpan="7">Returns</asp:TableHeaderCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
         <asp:TableCell  CssClass="tblhead">Return Id
         </asp:TableCell>
          <asp:TableCell  CssClass="tblhead">Image
         </asp:TableCell>
          <asp:TableCell  CssClass="tblhead">Name
         </asp:TableCell>
         <asp:TableCell CssClass="tblhead">Bill
         </asp:TableCell>
         </asp:TableRow>
         </asp:Table>
         <div id="reports" runat="server" class="reports">
            
         </div>
    </div>
    </form>
</body>
</html>
