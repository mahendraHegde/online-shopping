<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forgot.aspx.cs" Inherits="forgot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link rel="stylesheet" href="css/home.css" />
<link rel="stylesheet" href="css/login.css" />
    <title>Forgot Password</title>
<script src="js/jquery.js"></script>
<script src="js/home.js"></script>
</head>
<body onload="msgbox()" bgcolor="#e1e3dd">

    <form id="form1" runat="server">
    <div class="head1">
<a href="home.aspx"><img src='css/image/shoppie.png' alt="noImage" /></a>
</div>
    <div class="holder">
    
    <div class="forgotwrapper">
       <h1> Forgot Password </h1>
      </div>
       
       <div>
        <asp:Panel CssClass="idpanel" ID="panelid" runat="server" BorderStyle="None">
            <asp:Label ID="Label1" runat="server" Text="Email Id:"></asp:Label>
            <asp:TextBox CssClass="usertxt" ID="txtemailid" runat="server"></asp:TextBox>
            <button type="submit" class="nxtbtn" ID="btnnext" runat="server" Font-Bold="True" Font-Size="X-Large" style="right: 0px; top: 0px" onserverclick="btnnext_ServerClick" >Next</button>
        </asp:Panel>
        
        <asp:Panel CssClass="idpanel" ID="panelqtn" runat="server" BorderStyle="None">
            <asp:Label ID="Label2" runat="server" Text="Question:"></asp:Label>
            <asp:Label ID="lblqtn" runat="server" Text="qstn"></asp:Label><br/><br/>
            <asp:TextBox CssClass="usertxt" ID="txtans" runat="server" placeholder="your answer here" style="margin-left:66px"></asp:TextBox>
            <asp:Button CssClass="nxtbtn" ID="btnsubmit" runat="server" OnClick="btnsubmit_Click"  Text="Submit"/>
        </asp:Panel>
   
    <asp:Panel CssClass="idpanel" ID="panelpswd" runat="server" BorderStyle="None">
            <asp:Label ID="Label4" runat="server" Text="New Password:"></asp:Label><br/>
            <asp:TextBox CssClass="usertxt" ID="txtpswd" runat="server" placeholder="Enter New Password" style="margin-left:66px" TextMode="Password"></asp:TextBox><br/>
             <asp:Label ID="Label5" runat="server" Text="Confirm Password:"></asp:Label><br/>
              <asp:TextBox CssClass="usertxt" ID="txtconfirm" runat="server" placeholder="Retype the Password" style=" margin-left:66px" TextMode="Password"></asp:TextBox>
            <asp:Button CssClass="nxtbtn" ID="btnchange" runat="server"  Text="Change" style=" margin-left:1px; float:right;" OnClick="btnchange_Click" />
            
        </asp:Panel>
        </div>
        </div>
         <div runat="server" id="msg" class="msg">
    
    </div>
    </form>
</body>
</html>
