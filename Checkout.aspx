<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="css_Checkout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="Stylesheet"  href="css/checkout.css" />
    <link href="css/sliderstyle.css" type="text/css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
<script src="js/home.js"></script>
</head>
<body onload="msgbox()">
    <form id="form1" runat="server">
    <div class="head">
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
    <div  class="checkoutcontecnt" id="a">
        <div  class="div1">
            <div class="div1head">
                <asp:TextBox CssClass="numcircle" ID="txt1" runat="server" Text="1" Enabled="false"></asp:TextBox>
                <asp:TextBox CssClass="nullcircle" ID="TextBox2" runat="server" Text="" Enabled="false"></asp:TextBox>
                <asp:Label CssClass="divlabel" ID="Label1" runat="server" Text="Payment Method"></asp:Label>
            </div>
            <asp:Button CssClass="div1btn" ID="btncod" runat="server" Text="Cash On Delivery" OnClick="btncod_Click"  /><br /><br /><br />
            <asp:Button CssClass="div1btn" ID="btndebit" runat="server" Text="Debit Card" OnClick="btndebit_Click" />
        </div>
        <div runat="server" id="divaddress"  class="div2">
            <div class="div1head">
                <asp:TextBox CssClass="numcircle" ID="TextBox3" runat="server" Text="2" Enabled="false"></asp:TextBox>
                <asp:TextBox CssClass="nullcircle" ID="TextBox4" runat="server" Text="" Enabled="false"></asp:TextBox>
                <asp:Label CssClass="divlabel" ID="Label2" runat="server" Text="Address"></asp:Label>
            </div>
            
            <asp:Button CssClass="divbtn2" ID="btnconinue" runat="server"  Text="Continue" OnClick="btnconinue_Click" />
            <div class="divaddress">
                <asp:TextBox CssClass="addresstxt" ID="txtname"  runat="server" placeholder="Name"></asp:TextBox><br />
                <asp:TextBox CssClass="addresstxt" ID="txtadress"  runat="server" placeholder="Address"></asp:TextBox><br />
                <asp:TextBox CssClass="addresstxt" ID="txtpin"  runat="server" placeholder="Pin" OnTextChanged="txtpin_TextChanged" AutoPostBack="True"></asp:TextBox><br />
                <asp:TextBox CssClass="addresstxt" ID="txtciry"  runat="server" placeholder="City"></asp:TextBox><br />
                <asp:TextBox CssClass="addresstxt" ID="txtstate" runat="server" placeholder="State"></asp:TextBox><br />
                <asp:TextBox CssClass="addresstxt" ID="txtcountry"  runat="server" placeholder="Country"></asp:TextBox>
                <asp:TextBox CssClass="addresstxt" ID="txtcontact"  runat="server" placeholder="Phone" MaxLength="10"></asp:TextBox><br />
            </div>            
        </div>
         
        <div runat="server" id="divdebit" class="div3">
        <asp:Button CssClass="divbtn3" ID="btndbtcont" runat="server"  Text="Continue" OnClick="btndbtcont_Click" />
            <div class="div1head">
                <asp:TextBox CssClass="numcircle" ID="TextBox10" runat="server" Text="3" Enabled="false"></asp:TextBox>
                <asp:TextBox CssClass="nullcircle" ID="TextBox11" runat="server" Text="" Enabled="false"></asp:TextBox>
                <asp:Label CssClass="divlabel" ID="Label3" runat="server" Text="Payment Information"></asp:Label>
            </div>
          
            <div class="divpayment">
                <asp:Label CssClass="paymentlbl1" ID="Label4" runat="server" Text="PAYMENT CARD"></asp:Label>
                <asp:TextBox CssClass="paymenttxt1" ID="txtcardno" runat="server" placeholder="XXXX-XXXX-XXXX-XXXX" MaxLength="16"></asp:TextBox>
                <asp:Label CssClass="paymentlbl2" ID="Label5" runat="server" Text="Expires:"></asp:Label>
                <asp:TextBox CssClass="paymenttxt2" ID="txtmm" runat="server" MaxLength="2"  placeholder="MM"></asp:TextBox>
                <asp:Label CssClass="paymentlbl3" ID="Label6" runat="server" Text="/"></asp:Label>
                <asp:TextBox CssClass="paymenttxt3" ID="txtyy" runat="server" placeholder="YY" MaxLength="2"></asp:TextBox>
            </div>  
            <div class="divphoto">
                <asp:Image CssClass="photo1" ID="Image1" runat="server" ImageUrl="css/image/payment/3LmmFFV.png" />
                <asp:Image CssClass="photo1" ID="Image2" runat="server" ImageUrl="css/image/payment/D2eQTim.png" />
                <asp:Image CssClass="photo1" ID="Image3" runat="server" ImageUrl="css/image/payment/ewMjaHv.png" />
                <asp:Image CssClass="photo1" ID="Image4" runat="server" ImageUrl="css/image/payment/Le0Vvgx.png" />
                <asp:Image CssClass="photo1" ID="Image5" runat="server" ImageUrl="css/image/payment/Pu4e7AT.png" />
                <asp:Image CssClass="photo1" ID="Image6" runat="server" ImageUrl="css/image/payment/lock.png" />
            </div> 
        </div>
        <div runat="server" id="divfinal" class="div4">
            <div class="div1head">
                <asp:TextBox CssClass="numcircle" ID="txt4" runat="server" Text="4" Enabled="false"></asp:TextBox>
                <asp:TextBox CssClass="nullcircle" ID="TextBox16" runat="server" Text="" Enabled="false"></asp:TextBox>
                <asp:Label CssClass="divlabel" ID="Label7" runat="server" Text="Finalize Order"></asp:Label>
            </div>
            <asp:Button CssClass="divbtn4" ID="btncompleteorder" runat="server" Text="Complete Order" OnClick="btncompleteorder_Click" />
            <div class="divall">
            <div class="lbls">
                <asp:Label CssClass="orderlbl" ID="lll" runat="server" Text="Shipping : "></asp:Label>
                <asp:Label CssClass="orderlbl1" ID="lblname" runat="server" Text="PAYMENT CARD"></asp:Label>
                <asp:Label CssClass="orderlbl1" ID="lbladdress" runat="server" Text="PAYMENT CARD"></asp:Label>
                <asp:Label CssClass="orderlbl1" ID="lblcity" runat="server" Text="PAYMENT CARD"></asp:Label>
                <asp:Label CssClass="orderlbl1" ID="lblstate" runat="server" Text="PAYMENT CARD"></asp:Label>
                <asp:Label CssClass="orderlbl1" ID="lblpin" runat="server" Text="PAYMENT CARD"></asp:Label>
                <asp:Label CssClass="orderlbl1" ID="lblcontact" runat="server" Text="PAYMENT CARD"></asp:Label>
                 <asp:Label CssClass="orderlbl1" ID="lblcountry" runat="server" Text="PAYMENT CARD"></asp:Label>
            </div>
            <div class="lbls1">
                <asp:Label CssClass="orderlbl" ID="Label14" runat="server" Text="Payment : "></asp:Label>
                <asp:Label CssClass="orderlbl1" ID="lblmethod" runat="server" Text="PAYMENT CARD"></asp:Label>               
            </div>
            <div class="lbls1">
                <asp:Label CssClass="orderlbl" ID="Label16" runat="server" Text="     Total : "></asp:Label>
                <asp:Label CssClass="orderlbl1" ID="lbltot" runat="server" Text=""></asp:Label>               
            </div>
            </div>
        </div>
    </div>
    <div runat="server" id="msg" class="msg">
    
    </div>
    </form>
</body>
</html>
