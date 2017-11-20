<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeLoLogReg.aspx.cs" Inherits="SellerLogReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link rel="stylesheet" href="css/home.css" />
<link rel="stylesheet" href="css/loginregister.css" />
<script language="javascript" type="text/javascript" src="js/home.js"></script>
<script language="javascript" type="text/javascript" src="js/validation.js"></script>
<script src="js/jquery.js"></script>
    <title>Seller Register/Login</title>
    
</head>
<body onload="msgbox()" style="font-size: 12pt">
    <form id="form1" runat="server">
    <div class="head1">
    <a href="home.aspx"><img src='css/image/shoppie.png' alt="noImage" />  </a>  
    </div>
    <div id="logregbtn" class="logregbtn1">  
         <input type="button" class="signbtn1" id="btnsign1" onclick ="toreg1()" value="SignUp" />
        <input type="button" class="logbtn1" id="btnlog1" onclick ="tolog1()" value="Log In" />
    </div>
     <div class="register1" id="register1">
  
       <div class="registerwrapper">
       <h1> Seller Register </h1>
       </div>
       
       <div class="panel">
            <div class="column">
                <label>First Name:</label>
                <asp:TextBox CssClass="txt" ID="txtfirstname" runat="server"></asp:TextBox> 
                <label>Email ID:</label>
                <asp:TextBox CssClass="txt" ID="txtemail" runat="server"></asp:TextBox> 
                <label>Password:</label>          
                <asp:TextBox CssClass="txt"  ID="txtpswd" runat="server" TextMode="Password"></asp:TextBox>
                <label>Security Question:</label>          
                <asp:DropDownList CssClass="dropdownlist" ID="ddquestion" runat="server">
                    <asp:ListItem>What is your nick name?</asp:ListItem>
                    <asp:ListItem>What is your pin code?</asp:ListItem>
                    <asp:ListItem>What is your mother's name?</asp:ListItem>
                    <asp:ListItem>What is your father's name?</asp:ListItem>
                    <asp:ListItem>What is your 1st teacher name?</asp:ListItem>
                </asp:DropDownList>
            </div> 
            <div class="column">
                <label>Last Name:</label>          
                <asp:TextBox CssClass="txt"  ID="txtlastname" runat="server"></asp:TextBox>
                
                <label>Contact Number:</label>          
                <asp:TextBox CssClass="txt"  ID="txtcontact" runat="server" MaxLength="10"></asp:TextBox>
                <label>Confirm Password:</label>          
                <asp:TextBox CssClass="txt"  ID="txtconfirm" runat="server" TextMode="Password"></asp:TextBox>
                <label>Security Answer:</label>          
                <asp:TextBox CssClass="txt"  ID="txtans" runat="server" ></asp:TextBox>
            </div> 
       </div>
       
       <div class="registerwrapper1">
           <asp:Button CssClass="registerbtn" ID="btnsellerregister" runat="server" Text="Register" OnClientClick ="return sellersignup()" OnClick="btnsellerregister_Click"/>
       </div>           
       </div>
    
    <div class="login1" id="login1">
  
       <div class="logwrapper1">
       <h1> Seller Login </h1>
       </div>
       
       <div class="panel1">
                <label>Email ID:</label>
                <asp:TextBox CssClass="largetxt2" ID="txtsellerid" runat="server"></asp:TextBox> 
                <div class="user-icon1"></div>
                <label>Password:</label>
                <asp:TextBox CssClass="largetxt3" ID="txtsellerpswd" runat="server" TextMode="Password"></asp:TextBox>
                <div class="pass-icon1"></div>        
       </div>
       
       <div class="logfooter1">
            <asp:LinkButton CssClass="forgotbtn1" ID="btnforgot" runat="server" OnClick="btnforgot_Click">Forgot Password?</asp:LinkButton>
            <asp:Button CssClass="registerbtn" ID="btnsellerlogin" runat="server" Text="Login" OnClick="btnsellerlogin_Click"/>
       </div>           
       </div>
     <div runat="server" id="msg" class="msg">
    
    </div>  
    </form>
</body>
</html>
