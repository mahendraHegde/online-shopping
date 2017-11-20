<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Home</title>
    <script src="js/jquery.js"></script>
<script language="javascript" type="text/javascript" src="js/home.js">
// <!CDATA[
// ]]>

</script>
<link rel="Stylesheet"  href="css/home.css" />

<link href="css/sliderstyle.css" type="text/css" rel="stylesheet" />
</head>
<body id="body" class="notransition"  onload=" removeclass();msgbox();">
    <form id="form1"  runat="server">
<div class="head">
<a href="home.aspx"><img src="css/image/shoppie.png"  alt="noImage" /></a>
<a href="LogisticLogReg.aspx?val=login">
<div class="logistic">
</div></a>
<a href="SeLoLogReg.aspx?val=login">
<div class="seller">
</div></a>
<div class="search">
    <asp:DropDownList CssClass="ddbox" ID="ddcatlist" runat="server"  DataTextField="cat_name" DataValueField="cat_name" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>All</asp:ListItem>
    </asp:DropDownList>
 <asp:TextBox CssClass="searchtxt" ID="txtsearch" runat="server" placeholder="Search Here"></asp:TextBox>
    <asp:ImageButton CssClass="searchbtn" ID="btnsearch" runat="server" ImageUrl="css/image/icon/search-icon.ico" OnClick="btnsearch_click" />
    </div>
    <div id="user" runat="server">
     <div class="userbtn" > 
     <div id="triangle" class="triangle">.</div>
     <ul>
        <li id="loginli"><a href="UserLogReg.aspx?val=login">Login</a></li>
        <li id="regli"><a href="UserLogReg.aspx?val=register">Register</a></li>
     </ul>
     </div>
    </div>
     <div id="userlogin" runat="server">
     <div class="userbtn"> 
     <div class="triangle">.</div>
     <ul>
        <li><a href="BuyerProfile.aspx">Profile</a></li>
        <li><a href="ChangePassword.aspx?user=buyer">Password</a></li>
        <li><a href="Address.aspx?user=buyer">Addresss</a></li>
        <li><a href="Help.aspx?utype=buyer">help</a></li>
        <li><a id="A1" runat="server" href="#" onserverclick="logout_Click">Logout</a></li>
     </ul>
    </div> 
    </div>    
    
   <div id="cartbtn" class="cartbtn">
   <div class="triangle1">.</div>
   <div class="cartlist">
       <div class="cartlisthead">
           <asp:Label CssClass="cartitem" ID="Label36" runat="server" Text="Items"></asp:Label>
           <asp:Label CssClass="cartamount" ID="Label37" runat="server" Text="Amount"></asp:Label>       
       </div>
       <asp:Label CssClass="itemnolabel" ID="lblitemcount" runat="server" Text=""></asp:Label>
       <asp:Label CssClass="amountlabel" ID="lblamt" runat="server" Text="hgfhfgh"></asp:Label>
       <hr />
       <asp:LinkButton CssClass="viewcartbtn" ID="LinkButton1" PostBackUrl="~/Cart.aspx" runat="server">View Cart</asp:LinkButton>
       <asp:Button CssClass="checkbtn" ID="Button1" runat="server" Text="CheckOut" OnClick="checkout_Click" />
   </div>
   </div>
   </div>
        &nbsp;
<div class="catagories">
<div class="cathead">
Categories
</div>
<ul runat="server" class="catul" id="catul">
</ul>
</div>

<div id="d" class="ad">
 <div  class="slider"> 
        <input type="radio" id="control1" name="controls" checked="checked"/>
        <input type="radio" id="control2" name="controls"/>
        <input type="radio" id="control3" name="controls"/>
        <input type="radio" id="control4" name="controls"/>
        <input type="radio" id="control5" name="controls"/>
        <div runat="server" id="slideinner" class="sliderinner">
        </div>
    </div>
</div>

<div class="content" id="content">
    
     <div  class="slider1"> 
     <div class="newproducts">
        <h1>New products</h1></div>
        <div tabindex=0  id="navbtn1"   class="navbtn1" onclick="slideleft1()">
        </div>
         <div tabindex=1   class="navbtn2" onclick="slideright1()">
        </div>
        <div class="sliderinner1">
            <ul runat="server" id="contentul1" class="contentul1">
                <li >
                    <a  runat="server" id="aimg1">

                  </a>
                </li>
                <li >
                   <a runat="server" id="aimg2" href="#">
                  </a>
                </li>
                <li >
                    <a runat="server" id="aimg3" href="#">
                  </a>
                </li>
                <li>
                    <a runat="server" id="aimg4" href="#">
                  </a>
                </li>
                <li>
                    <a runat="server" id="aimg5" href="#">
                  </a>
                </li>
                 <li>
                    <a runat="server" id="aimg6" href="#">
                    </a>
                </li>
                <li >
                    <a runat="server" id="aimg7" href="#">
                  </a>
                </li>
                <li >
                    <a runat="server" id="aimg8" href="#">
                  </a>
                </li>
                <li>
                    <a runat="server" id="aimg9" href="#">
                  </a>
                </li>
                <li>
                   <a runat="server" id="aimg10" href="View.aspx">
                  </a>
                </li>
            </ul>
        </div>
    </div>

    
    <div  class="slider2"> 
     <div class="popularproducts">
        <h1>Popular Products</h1></div>
        <div tabindex=0   class="navbtn3" onclick="slideleft2()">
        </div>
         <div tabindex=1 id="navbtn3"  class="navbtn4" onclick="slideright2()">
        </div>
        <div class="sliderinner2">
            <ul id="contentul2" class="contentul2">
                 <li>
                    <a runat="server" id="aimg11" href="#">
                  </a>
                </li>
                <li >
                   <a runat="server" id="aimg12" href="#">
                  </a>
                </li>
                <li >
                    <a runat="server" id="aimg13" href="#">
                    
                  </a>
                </li>
                <li>
                    <a runat="server" id="aimg14" href="#">
                  </a>
                </li>
                <li>
                    <a runat="server" id="aimg15" href="#">
                  </a>
                </li>
                 <li>
                    <a runat="server" id="aimg16" href="#">
                    </a>
                </li>
                <li >
                    <a runat="server" id="aimg17" href="#">
                  </a>
                </li>
                <li >
                    <a runat="server" id="aimg18" href="#">
                  </a>
                </li>
                <li>
                    <a runat="server" id="aimg19" href="#">
                  </a>
                </li>
                <li>
                   <a  runat="server" id="aimg20" href="#">
                  </a>
                </li>
            </ul>
        </div>
    </div>

    <div  class="slider3"> 
     <div class="recommendedproducts">
        <h1>Recommended Products</h1></div>
        <div tabindex=0  id="navbtn5"  class="navbtn5" onclick="slideleft3()">
        </div>
         <div tabindex=1   class="navbtn6" onclick="slideright3()">
        </div>
        <div class="sliderinner3">
            <ul id="contentul3" class="contentul3">
                                <li>
                    <a runat="server" id="aimg21" href="#">
                  </a>
                </li>
                <li >
                   <a runat="server" id="aimg22" href="#">
                  </a>
                </li>
                <li >
                    <a runat="server" id="aimg23" href="#">
                    
                  </a>
                </li>
                <li>
                    <a runat="server" id="aimg24" href="#">
                  </a>
                </li>
                <li>
                    <a runat="server" id="aimg25" href="#">
                  </a>
                </li>
                 <li>
                    <a runat="server" id="aimg26" href="#">
                    </a>
                </li>
                <li >
                    <a runat="server" id="aimg27" href="#">
                  </a>
                </li>
                <li >
                    <a runat="server" id="aimg28" href="#">
                  </a>
                </li>
                <li>
                    <a runat="server" id="aimg29" href="#">
                  </a>
                </li>
                <li>
                   <a  runat="server" id="aimg30" href="#">
                  </a>
                </li>
            </ul>
        </div>
    </div>
</div>

<div class="footer">
    <a href="Home.aspx"><div class="homeicon"></div></a>
    <a href="Help.aspx?utype=buyer"><div class="helpicon"></div></a>
    <a href="About.aspx?utype=buyer"><div class="abouticon"></div></a>
    </div>
 <div runat="server" id="msg" class="msg">
    
    </div>
    </form>
</body>
</html>
