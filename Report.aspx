<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/report.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="reportbtns">
        <asp:Button CssClass="btns" ID="btncommission" runat="server" Text="Commission" OnClick="btncommission_Click"  />
        <asp:Button CssClass="btns" ID="btnsales" runat="server" Text="Sales Report" OnClick="btnsales_Click" />
        <asp:Button CssClass="btns" ID="btnseller" runat="server" Text="Seller" OnClick="btnseller_Click"  />
        <asp:Button CssClass="btns" ID="btnlogistic" runat="server" Text="Logistic" OnClick="btnlogistic_Click" />
    </div>
    <div runat="server" id="divcommission">
    <div class="reportddl">
        <asp:DropDownList CssClass="ddl" ID="ddyear" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddyear_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList CssClass="ddl" ID="ddmonth" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddmonth_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
            Height="1039px" ReportSourceID="CrystalReportSource1" Width="901px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="report1.rpt">
            </Report>
        </CR:CrystalReportSource>
        </div>
    </div>
    <div runat="server" id="divsales">
    <div class="reportddl">
    <asp:DropDownList CssClass="ddl" ID="ddyearsales" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddyearsales_SelectedIndexChanged" >
        </asp:DropDownList>
        <asp:DropDownList CssClass="ddl" ID="ddmonthsales" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddmonthsales_SelectedIndexChanged">
        </asp:DropDownList>
        </div>
    <CR:CrystalReportViewer ID="CrystalReportsales" runat="server" AutoDataBind="True" Height="1039px" ReportSourceID="CrystalReportSource2" Width="901px" />
        <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
            <Report FileName="sales.rpt">
            </Report>
        </CR:CrystalReportSource>
        
    </div>
    <div runat="server" id="divseller">
    <div class="reportddl">
     <asp:DropDownList CssClass="ddl" ID="ddyearseller" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddyearseller_SelectedIndexChanged" >
        </asp:DropDownList>
        <asp:DropDownList CssClass="ddl" ID="ddmonthseller" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddmonthseller_SelectedIndexChanged">
        </asp:DropDownList>
        </div>
    <CR:CrystalReportViewer ID="CrystalReportseller" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource3" />
         <CR:CrystalReportSource ID="CrystalReportSource3" runat="server">
            <Report FileName="seller.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>
    <div runat="server" id="divlogistic">
    <div class="reportddl">
    <asp:DropDownList CssClass="ddl" ID="ddyearlogistic" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddyearlogistic_SelectedIndexChanged" >
        </asp:DropDownList>
        <asp:DropDownList CssClass="ddl" ID="ddmonthlogistic" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddmonthlogistic_SelectedIndexChanged">
        </asp:DropDownList>
        </div>
        <CR:CrystalReportViewer ID="CrystalReportlogistic" runat="server" ReportSourceID="CrystalReportSource4" AutoDataBind="true" />
        <CR:CrystalReportSource ID="CrystalReportSource4" runat="server">
            <Report FileName="logistic.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
