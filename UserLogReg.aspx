<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogReg.aspx.cs" Inherits="logreg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>User Register/Login</title>
      <script language="javascript" type="text/javascript" src="js/jquery.js">  </script>
    <script language="javascript" type="text/javascript" src="js/home.js">  </script>
    <script language="javascript" type="text/javascript" src="js/validation.js">
    </script>
    <link rel="Stylesheet" href="css/home.css" />
    <link rel="stylesheet" href="css/loginregister.css" />
</head>
<body onload="msgbox()">
    <form id="form1" runat="server">
    <div class="head1">
      <a href="Home.aspx">  <img src="css/image/shoppie.png" alt="noImage" /> </a>
    </div> 
    <div style="background-image:url('image/background/login-icon.jpg');">         
    <div id="logregbtn" class="logregbtn">  
         <input type="button" class="signbtn" id="btnsign" onclick ="toreg()" value="SignUp" />
        <input type="button" class="logbtn" id="btnlog" onclick ="tolog()" value="Log In" />
    </div>
    <div id="register" class="register"> 
        <div class="logregwrapper">
            <h1> Sign Up For Free </h1>
        </div>
        <div class="reg">
            <asp:TextBox CssClass="smalltxt" ID="txtfirstname" runat="server" placeholder="First Name"></asp:TextBox>
            <asp:TextBox CssClass="smalltxt" ID="txtlastname" runat="server" placeholder="Last Name"></asp:TextBox>
            <asp:TextBox CssClass="smalltxt" ID="txtemail" runat="server" placeholder="Email-ID"></asp:TextBox>
            <asp:TextBox CssClass="smalltxt" ID="txtcontact" MaxLength="10" runat="server" placeholder="Contact Number"></asp:TextBox>
            <asp:TextBox CssClass="smalltxt" ID="txtpswd" runat="server" placeholder="Password(min-8 char)" TextMode="Password"></asp:TextBox>
            <asp:TextBox CssClass="smalltxt" ID="txtconfirm" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
            <asp:DropDownList CssClass="qtnddl" ID="ddquestion" runat="server">
                    <asp:ListItem>What is your nick name?</asp:ListItem>
                    <asp:ListItem>What is your pin code?</asp:ListItem>
                    <asp:ListItem>What is your mother's name?</asp:ListItem>
                    <asp:ListItem>What is your father's name?</asp:ListItem>
                    <asp:ListItem>What is your 1st teacher name?</asp:ListItem>
                </asp:DropDownList>
            <asp:TextBox CssClass="anstxt" ID="txtans" runat="server" placeholder="Security Answer"></asp:TextBox>
        </div>
        <div class="regfooter">
            <asp:Button  CssClass="regbtn" ID="btnusersignup" runat="server" Text="GET STARTED" OnClientClick ="return usersignup()" OnClick="btnusersignup_Click"  />
        </div>    
     </div>
     
   <div id="login" class="login"> 
        <div class="logwrapper">
            <h1> Log In </h1>
        </div>
        <div class="log">
            <asp:TextBox CssClass="largetxt" ID="txtuserid" runat="server" placeholder="Email-ID"></asp:TextBox><div class="user-icon"></div>
            <asp:TextBox CssClass="largetxt1" ID="txtuserpswd" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            <div class="pass-icon"></div>
            <asp:LinkButton CssClass="forgotbtn" ID="btnforgot" runat="server" OnClick="btnforgot_Click">Forgot Password?</asp:LinkButton>
        </div>
        <div class="regfooter">
            <asp:Button CssClass="regbtn" ID="btnuserlogin" runat="server" Text="LOG IN" OnClick="btnuserlogin_Click" />
        </div>   
    </div>
    </div>
         <div runat="server" id="msg" class="msg">
    
    </div>
    </form>
</body>
</html>
